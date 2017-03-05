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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Altaxo.CodeEditing;
using Altaxo.CodeEditing.Completion;
using Microsoft.CodeAnalysis;

namespace Altaxo.Gui.CodeEditing
{
	public class CodeTextEditorFactory
	{
		private RoslynHost _roslynHost;

		private string _workingDirectory = Environment.CurrentDirectory;

		public CodeTextEditorFactory()
		{
			_roslynHost = new RoslynHost(null);
		}

		public CodeEditorView NewFromFileName(string fileName, IEnumerable<System.Reflection.Assembly> referencedAssemblies)
		{
			var editor = new CodeEditorView();
			editor.FontFamily = new FontFamily("Consolas");
			editor.FontSize = 12;

			// create the source text container that is connected with this editor
			var sourceTextContainer = new RoslynSourceTextContainerAdapter(editor.Document, editor); // DocumentView.xaml.cs line 82

			var workspace = new AltaxoWorkspaceForCSharpRegularDll(
				_roslynHost,
				_workingDirectory,
				referencedAssemblies?.Select(ass => _roslynHost.CreateMetadataReference(ass.Location))
				);

			var document = workspace.CreateAndOpenDocument(sourceTextContainer, sourceTextContainer.UpdateText);

			editor.Adapter = new CodeEditorViewAdapterCSharp(workspace, document.Id, sourceTextContainer);
			editor.Document.UndoStack.ClearAll(); // DocumentView.xaml.cs line 94

			// editor.TextArea.TextView.LineTransformers.Insert(0, new RoslynHighlightingColorizer(_viewModel.DocumentId, _roslynHost));

			//editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");

			return editor;
		}

		public CodeEditor NewCodeEditor(string fileName, IEnumerable<System.Reflection.Assembly> referencedAssemblies)
		{
			var codeEditor = new CodeEditor();

			var editor = codeEditor.primaryTextEditor;
			editor.FontFamily = new FontFamily("Consolas");
			editor.FontSize = 12;

			// create the source text container that is connected with this editor
			var sourceTextContainer = new RoslynSourceTextContainerAdapter(codeEditor.Document, codeEditor); // DocumentView.xaml.cs line 82

			var workspace = new AltaxoWorkspaceForCSharpRegularDll(
				_roslynHost,
				_workingDirectory,
				referencedAssemblies?.Select(ass => _roslynHost.CreateMetadataReference(ass.Location))
				);

			var document = workspace.CreateAndOpenDocument(sourceTextContainer, sourceTextContainer.UpdateText);

			codeEditor.Adapter = new CodeEditorViewAdapterCSharp(workspace, document.Id, sourceTextContainer);
			editor.Document.UndoStack.ClearAll(); // DocumentView.xaml.cs line 94

			return codeEditor;
		}

		public CodeEditorWithDiagnostics NewCodeEditorWithDiagnostics(string initialText, IEnumerable<System.Reflection.Assembly> referencedAssemblies)
		{
			var codeEditor = new CodeEditorWithDiagnostics();
			codeEditor.DocumentText = initialText;

			var editor = codeEditor.primaryTextEditor;
			editor.FontFamily = new FontFamily("Consolas");
			editor.FontSize = 12;

			// create the source text container that is connected with this editor
			var sourceTextContainer = new RoslynSourceTextContainerAdapter(codeEditor.Document, codeEditor); // DocumentView.xaml.cs line 82
			var workspace = new AltaxoWorkspaceForCSharpRegularDll(
			_roslynHost,
			_workingDirectory,
			referencedAssemblies?.Select(ass => _roslynHost.CreateMetadataReference(ass.Location))
			);

			var document = workspace.CreateAndOpenDocument(sourceTextContainer, sourceTextContainer.UpdateText);
			codeEditor.Adapter = new CodeEditorViewAdapterCSharp(workspace, document.Id, sourceTextContainer);

			editor.Document.UndoStack.ClearAll(); // DocumentView.xaml.cs line 94

			return codeEditor;
		}

		/// <summary>
		/// Uninitializes the specified code editor and removes the corresponding workspace from Roslyn.
		/// </summary>
		/// <param name="codeEditor">The code editor.</param>
		public void Uninitialize(CodeEditorWithDiagnostics codeEditor)
		{
			var adapter = codeEditor.Adapter;
			codeEditor.Adapter = null;
			if (null != adapter)
			{
				adapter.Workspace.CloseDocument(adapter.DocumentId);
				if (null == adapter.Workspace.GetOpenDocumentIds().FirstOrDefault()) // dispose workspace if it has no open documents
					adapter.Workspace.Dispose();
			}
		}

		/// <summary>
		/// Uninitializes the specified code editor and removes the corresponding workspace from Roslyn.
		/// </summary>
		/// <param name="codeEditor">The code editor.</param>
		public void Uninitialize(CodeEditor codeEditor)
		{
			var adapter = codeEditor.Adapter;
			codeEditor.Adapter = null;
			if (null != adapter)
			{
				adapter.Workspace.CloseDocument(adapter.DocumentId);
				if (null == adapter.Workspace.GetOpenDocumentIds().FirstOrDefault()) // dispose workspace if it has no open documents
					adapter.Workspace.Dispose();
			}
		}

		/// <summary>
		/// Uninitializes the specified code editor and removes the corresponding workspace from Roslyn.
		/// </summary>
		/// <param name="codeEditor">The code editor.</param>
		public void Uninitialize(CodeEditorView codeEditor)
		{
			var adapter = codeEditor.Adapter;
			codeEditor.Adapter = null;
			if (null != adapter)
			{
				adapter.Workspace.CloseDocument(adapter.DocumentId);
				if (null == adapter.Workspace.GetOpenDocumentIds().FirstOrDefault()) // dispose workspace if it has no open documents
					adapter.Workspace.Dispose();
			}
		}
	}
}