﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2017 Dr. Dirk Lellinger
//
//    This program is free software; you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation; either version 2 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program; if not, write to the Free Software
//    Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
//
/////////////////////////////////////////////////////////////////////////////

#endregion Copyright

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Altaxo.CodeEditing.BraceMatching;
using Altaxo.CodeEditing.Completion;
using Altaxo.CodeEditing.Diagnostics;
using Altaxo.CodeEditing.Folding;
using Altaxo.CodeEditing.LiveDocumentFormatting;
using Altaxo.CodeEditing.QuickInfo;
using Altaxo.CodeEditing.ReferenceHighlighting;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Indentation;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editor;
using Microsoft.CodeAnalysis.Editor.CSharp.GoToDefinition;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Text;

namespace Altaxo.CodeEditing
{
  /// <summary>
  /// Implementation of <see cref="ICodeEditorViewAdapter"/> for CSharp.
  /// </summary>
  /// <seealso cref="Altaxo.CodeEditing.ICodeEditorViewAdapter" />
  public class CodeEditorViewAdapterCSharp : ICodeEditorViewAdapter
  {
    /// <summary>
    /// Shortcut to the roslyn host. Can also be retrieved by using <see cref="AltaxoWorkspaceBase.RoslynHost"/>.
    /// </summary>
    protected RoslynHost _roslynHost;

    /// <summary>
    /// Gets the workspace where the document (see <see cref="DocumentId" /> is contained.
    /// </summary>
    /// <value>
    /// The workspace.
    /// </value>
    public AltaxoWorkspaceBase Workspace { get; }

    /// <summary>
    /// Gets or sets the document identifier of the underlying document.
    /// </summary>
    /// <value>
    /// The document identifier.
    /// </value>
    public Microsoft.CodeAnalysis.DocumentId DocumentId { get; }

    /// <summary>
    /// Gets the source text, suitable both for use with AvalonEdit and with Roslyn.
    /// </summary>
    /// <value>
    /// The source text adapter.
    /// </value>
    public RoslynSourceTextContainerAdapter SourceTextAdapter { get; }

    /// <summary>
    /// Gets the highlighting colorizer to colorize the code by it's syntax or sematics.
    /// </summary>
    /// <value>
    /// The highlighting colorizer.
    /// </value>
    public ICSharpCode.AvalonEdit.Highlighting.HighlightingColorizer HighlightingColorizer { get; }

    /// <summary>
    /// Gets or sets the quick information provider.
    /// (If the mouse hovers over an item, it displays short information about the item).
    /// </summary>
    /// <value>
    /// The quick information provider.
    /// </value>
    public QuickInfo.IQuickInfoProvider QuickInfoProvider { get; set; }

    /// <summary>
    /// Gets or sets the folding strategy.
    /// Responsible for getting the code spans where foldings occur.
    /// </summary>
    /// <value>
    /// The folding strategy.
    /// </value>
    public SyntaxTreeFoldingStrategy FoldingStrategy { get; set; }

    /// <summary>
    /// Gets or sets the brace matching service.
    /// Responsible for highlighting matching pairs of braces, brackets, etc.
    /// </summary>
    /// <value>
    /// The brace matching service.
    /// </value>
    public IBraceMatchingService BraceMatchingService { get; set; }

    /// <summary>
    /// Gets or sets the reference highlight service.
    /// Responsible for highlighting all identical items, e.g. variable names, if the cursor is inside such an item.
    /// </summary>
    /// <value>
    /// The reference highlight service.
    /// </value>
    public IDocumentHighlightsService ReferenceHighlightService { get; set; }

    /// <summary>
    /// Gets or sets the completion provider.
    /// Responsible for displaying proposals for writing code.
    /// </summary>
    /// <value>
    /// The completion provider.
    /// </value>
    public ICodeEditorCompletionProvider CompletionProvider { get; set; }

    /// <summary>
    /// Gets or sets the renaming service.
    /// Responsible for renaming members, local variables, classes, parameters, etc.
    /// </summary>
    /// <value>
    /// The renaming service.
    /// </value>
    public Renaming.IRenamingService RenamingService { get; set; }

    /// <summary>
    /// Gets the indentation strategy.
    /// Responsible for determination of the indent of the next line if the user enters a newline.
    /// </summary>
    /// <value>
    /// The indentation strategy.
    /// </value>
    public IIndentationStrategy IndentationStrategy { get; set; }

    /// <summary>
    /// Gets or sets the live document formatter.
    /// Responsible for formatting the code if the user enters a trigger char, like a semicolon or a closing brace.
    /// </summary>
    /// <value>
    /// The live document formatter.
    /// </value>
    public ILiveDocumentFormatter LiveDocumentFormatter { get; set; }

    /// <summary>
    /// Responsible for getting an <see cref="ExternalHelp.ExternalHelpItem"/> from the symbol under the caret position.
    /// If this is successful, the event <see cref="ExternalHelpRequired"/> is fired.
    /// </summary>
    /// <value>
    /// The external help provider.
    /// </value>
    public ExternalHelp.IExternalHelpProvider ExternalHelpProvider { get; set; }

    /// <summary>
    /// Event that is fired when external help is required.
    /// </summary>
    public event Action<ExternalHelp.ExternalHelpItem> ExternalHelpRequired;

    /// <summary>
    /// Occurs when the diagnostics was updated and new diagnostics is available (diagnostics is responsible for the wriggles under the text
    /// that show in advance the errors in code).
    /// </summary>
    public event Action<DiagnosticsUpdatedArgs> DiagnosticsUpdated;

    /// <summary>
    /// Occurs after the source text has changed. This event is routed from the <see cref="SourceTextAdapter"/>.
    /// </summary>
    public event EventHandler<TextChangeEventArgs> SourceTextChanged;

    public CodeEditorViewAdapterCSharp(AltaxoWorkspaceBase workspace, Microsoft.CodeAnalysis.DocumentId documentID, RoslynSourceTextContainerAdapter sourceText)
    {
      Workspace = workspace ?? throw new ArgumentNullException(nameof(workspace));
      DocumentId = documentID ?? throw new ArgumentNullException(nameof(documentID));
      SourceTextAdapter = sourceText ?? throw new ArgumentNullException(nameof(sourceText));
      _roslynHost = workspace.RoslynHost;
      SourceTextAdapter.TextChanged += EhSourceTextAdapter_TextChanged;

      HighlightingColorizer = new SemanticHighlighting.SemanticHighlightingColorizer(Workspace, DocumentId);
      QuickInfoProvider = _roslynHost.GetService<QuickInfo.IQuickInfoProvider>();
      FoldingStrategy = new SyntaxTreeFoldingStrategy();
      BraceMatchingService = _roslynHost.GetService<IBraceMatchingService>();
      ReferenceHighlightService = new ReferenceHighlighting.CSharp.CSharpDocumentHighlightsService();
      CompletionProvider = new Completion.CodeEditorCompletionProvider(_roslynHost, Workspace, DocumentId);
      RenamingService = new Renaming.RenamingService();
      IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy();
      LiveDocumentFormatter = new LiveDocumentFormatterCSharp();
      ExternalHelpProvider = new ExternalHelp.ExternalHelpProvider();

      Workspace.SubscribeToDiagnosticsUpdateNotification(DocumentId, EhDiagnosticsUpdated);
    }

    private void EhSourceTextAdapter_TextChanged(object sender, TextChangeEventArgs e)
    {
      SourceTextChanged?.Invoke(sender, e);
    }

    #region Syntax highlighting

    /*
		/// <summary>
		/// Gets the highlighting service.
		/// </summary>
		/// <value>
		/// The highlighting service.
		/// </value>
		public ICSharpCode.AvalonEdit.Highlighting.IHighlightingDefinition HighlightingService { get; set; } = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinitionByExtension(".cs");
		*/

    public Gui.CodeEditing.SemanticHighlighting.ISemanticHighlightingColors SemanticHighlightingColors
    {
      set
      {
        if (null == value)
          throw new ArgumentNullException(nameof(value));

        if (HighlightingColorizer is SemanticHighlighting.SemanticHighlightingColorizer shc)
          shc.HighlightingColors = value;
      }
    }

    #endregion Syntax highlighting

    #region QuickInfo

    public virtual async Task<QuickInfo.QuickInfoItem> GetToolTipAsync(int cursorPosition)
    {
      // TODO: consider invoking this with a delay, then showing the tool-tip without one
      var document = Workspace.CurrentSolution.GetDocument(DocumentId);
      var quickInfoProvider = QuickInfoProvider;
      if (null != quickInfoProvider)
      {
        return await quickInfoProvider.GetItemAsync(document, cursorPosition, CancellationToken.None).ConfigureAwait(true);
      }
      else
      {
        return null;
      }
    }

    #endregion QuickInfo

    #region Folding

    /// <summary>
    /// Central routine of the folding strategy. Uses the document's syntax tree
    /// to calculate all folding positions.
    /// </summary>
    /// <returns>
    /// Enumeration of foldings.
    /// </returns>
    public IEnumerable<NewFolding> GetNewFoldings()
    {
      var document = Workspace.CurrentSolution.GetDocument(DocumentId);
      //var text = document.GetTextAsync().Result;

      var syntaxTree = document.GetSyntaxTreeAsync().Result;
      return FoldingStrategy?.GetNewFoldings(syntaxTree);
    }

    #endregion Folding

    #region Brace matching

    /// <summary>
    /// Gets the matching braces asynchronously.
    /// </summary>
    /// <param name="position">The cursor position.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Matching braces</returns>
    public virtual async Task<BraceMatchingResult?> GetMatchingBracesAsync(int position, CancellationToken cancellationToken = default(CancellationToken))
    {
      var service = BraceMatchingService;

      if (null != service)
      {
        return await service.GetMatchingBracesAsync(Workspace.CurrentSolution.GetDocument(DocumentId), position, cancellationToken);
      }
      else
      {
        return null;
      }
    }

    #endregion Brace matching

    #region Diagnostics

    /// <summary>
    /// Called from the roslyn host when diagnostics was updated.
    /// </summary>
    /// <param name="a">a.</param>
    public void EhDiagnosticsUpdated(DiagnosticsUpdatedArgs a)
    {
      DiagnosticsUpdated?.Invoke(a);
    }

    #endregion Diagnostics

    #region Reference Highlighting

    /// <summary>
    /// Finds references to resolved expression in the current file.
    /// </summary>
    public virtual async Task<ImmutableArray<DocumentHighlights>> FindReferencesInCurrentFile(int cursorPosition)
    {
      var service = ReferenceHighlightService;

      if (null == service)
        return ImmutableArray<DocumentHighlights>.Empty;

      var document = Workspace.CurrentSolution.GetDocument(DocumentId);

      var builder = ImmutableHashSet<Document>.Empty.ToBuilder();
      builder.Add(document);

      return await service.GetDocumentHighlightsAsync(document, cursorPosition, builder.ToImmutable(), CancellationToken.None);
    }

    #endregion Reference Highlighting

    #region Completion

    public async Task<CompletionResult> GetCompletionData(int position, char? triggerChar, bool useSignatureHelp)
    {
      return await CompletionProvider?.GetCompletionData(position, triggerChar, useSignatureHelp);
    }

    #endregion Completion

    #region Symbol renaming

    /// <summary>
    /// Renames the symbol at the caret position or the start of the selection.
    /// </summary>
    /// <param name="caretPositionOrSelectionStart">The caret position or selection start.</param>
    /// <returns></returns>
    public async Task RenameSymbol(int caretPositionOrSelectionStart, object topLevelWindow, Action FocusBackOnEditor)
    {
      var service = RenamingService;

      if (null != service)
      {
        await service.RenameSymbol(Workspace, DocumentId, SourceTextAdapter, caretPositionOrSelectionStart, topLevelWindow, FocusBackOnEditor).ConfigureAwait(false);
      }
    }

    #endregion Symbol renaming

    #region QuickClassBrowser

    /// <summary>
    /// Finds references to resolved expression in the current file.
    /// </summary>
    public virtual async Task<SyntaxTree> GetDocumentSyntaxTreeAsync()
    {
      var document = Workspace.CurrentSolution.GetDocument(DocumentId);
      return await document.GetSyntaxTreeAsync();
    }

    #endregion QuickClassBrowser

    #region Document formatting

    public async Task FormatDocument()
    {
      var document = Workspace.CurrentSolution.GetDocument(DocumentId);

      var syntaxTree = await document.GetSyntaxRootAsync();
      var textChanges = await Formatter.GetFormattedTextChangesAsync(syntaxTree, Workspace);
      SourceTextAdapter.ApplyTextChanges(textChanges, (modifiedSourceText) => Workspace.TryApplyChanges(document.WithText(modifiedSourceText).Project.Solution));
    }

    /// <summary>
    /// Formats the document after entering a trigger character. Trigger chars are e.g. closing curly brace (then format whole paragraph)
    /// or semicolon (then format line).
    /// </summary>
    /// <param name="caretPosition">The caret position after (!) the trigger char.</param>
    /// <returns></returns>
    public async Task FormatDocumentAfterEnteringTriggerChar(int caretPosition, char triggerChar)
    {
      var formatter = LiveDocumentFormatter;

      if (null != formatter)
      {
        await formatter.FormatDocumentAfterEnteringTriggerChar(Workspace, DocumentId, SourceTextAdapter, caretPosition, triggerChar).ConfigureAwait(false);
      }
    }

    #endregion Document formatting

    #region External Help

    /// <summary>
    /// Gets the external help item for the symbol under the caret position.
    /// </summary>
    /// <param name="caretPosition">The caret position.</param>
    /// <returns>The external help item.</returns>
    public async Task GetExternalHelpItemAndFireHelpEvent(int caretPosition)
    {
      var helpProvider = ExternalHelpProvider;

      if (null != helpProvider) // && null != ExternalHelpRequired)
      {
        var document = Workspace.CurrentSolution.GetDocument(DocumentId);
        var helpItem = await helpProvider.GetExternalHelpItem(document, caretPosition, CancellationToken.None).ConfigureAwait(false);
        if (null != helpItem)
        {
          ExternalHelpRequired?.Invoke(helpItem);
        }
      }
    }

    #endregion External Help

    #region GoToDefinition

    private IGoToDefinitionService _goToDefinitionService;

    /// <summary>
    /// Try to go to the definition of the symbol under the caret. This function is designed here for solutions
    /// containing only of a single code document.
    /// </summary>
    /// <param name="caretOffset">The caret offset.</param>
    /// <returns>The position of the symbol in the document where it is defined. If the symbol under the caret is not defined in the document,
    /// the return value is null.</returns>
    public int? GoToDefinition(int caretOffset)
    {
      if (null == _goToDefinitionService)
        _goToDefinitionService = new CSharpGoToDefinitionService();

      var document = Workspace.CurrentSolution.GetDocument(DocumentId);
      var definitions = _goToDefinitionService.FindDefinitionsAsync(document, caretOffset, CancellationToken.None).Result;
      var location = definitions.FirstOrDefault();

      return location?.SourceSpan.Start;
    }

    #endregion GoToDefinition
  }
}
