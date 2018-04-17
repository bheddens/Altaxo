﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2018 Dr. Dirk Lellinger
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

using Altaxo.Graph;
using Altaxo.Gui.Workbench;
using Altaxo.Main;
using Altaxo.Text;
using Altaxo.Text.GuiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altaxo.Gui.Text.Viewing
{
	[UserControllerForObject(typeof(TextDocument))]
	[UserControllerForObject(typeof(Altaxo.Text.GuiModels.TextDocumentViewOptions))]
	[ExpectedTypeOfView(typeof(ITextDocumentView))]
	public class TextDocumentController : AbstractViewContent, IDisposable, IMVCANController, ITextDocumentController
	{
		protected ITextDocumentView _view;

		private Altaxo.Text.GuiModels.TextDocumentViewOptions _options;

		public TextDocument TextDocument { get { return _options.Document; } }

		public TextDocumentController()
		{
		}

		public TextDocumentController(TextDocument doc)
		{
			InitializeDocument(doc);
		}

		public bool InitializeDocument(params object[] args)
		{
			if (null == args || args.Length == 0)
				return false;

			TextDocumentViewOptions newOptions = null;

			if (args[0] is TextDocumentViewOptions notesViewOptions)
			{
				newOptions = notesViewOptions;
			}
			else if (args[0] is TextDocument notesDoc)
			{
				newOptions = new TextDocumentViewOptions(notesDoc);
			}

			if (newOptions == null)
				return false; // not successfull

			if (newOptions.Document == null)
				throw new InvalidProgramException("The provided options do not contain any document");

			if (_options?.Document != null && !object.ReferenceEquals(this.TextDocument, _options.Document))
			{
				throw new InvalidProgramException("The already initialized document and the document in the option class are not identical");
			}

			InternalInitializeDocument(newOptions);

			return true;
		}

		public void PrintShowDialog()
		{
			_view?.PrintShowDialog();
		}

		public UseDocument UseDocumentCopy
		{
			set { }
		}

		protected void InternalInitializeDocument(TextDocumentViewOptions options)
		{
			if (null == options?.Document)
				throw new ArgumentNullException("No document stored inside options");

			_options = options;

			this.Title = GetTitleFromDocumentName(TextDocument);

			TextDocument.TunneledEvent += new WeakActionHandler<object, object, Altaxo.Main.TunnelingEventArgs>(EhDocumentTunneledEvent, (handler) => TextDocument.TunneledEvent -= handler);
		}

		private void EhDocumentTunneledEvent(object arg1, object arg2, TunnelingEventArgs e)
		{
			if (e is Altaxo.Main.DocumentPathChangedEventArgs && _view != null)
			{
				_view.SetDocumentNameAndLocalImages(TextDocument.Name, TextDocument.Images);
				this.Title = GetTitleFromDocumentName(TextDocument);
			}
		}

		private static string GetTitleFromDocumentName(TextDocument doc)
		{
			if (!Altaxo.Main.ProjectFolder.IsValidFolderName(doc.Name))
				return doc.Name;
			else
				return doc.Name + "FolderNotes";
		}

		protected void Initialize(bool initData)
		{
			if (initData)
			{
			}
			if (null != _view)
			{
				_view.IsInInitializationMode = true;
				_view.SetDocumentNameAndLocalImages(TextDocument.Name, TextDocument.Images);
				_view.SourceText = TextDocument.SourceText;
				_view.StyleName = TextDocument.StyleName;

				_view.IsViewerSelected = _options.IsViewerSelected;
				_view.WindowConfiguration = _options.WindowConfiguration;
				_view.FractionOfEditorWindow = _options.FractionOfSourceEditorWindowVisible;
				_view.IsLineNumberingEnabled = _options.IsLineNumberingEnabled ?? _options.Document.GetPropertyValue(TextDocumentViewOptions.PropertyKeyIsLineNumberingEnabled, () => true);
				_view.IsWordWrappingEnabled = _options.IsWordWrappingEnabled ?? _options.Document.GetPropertyValue(TextDocumentViewOptions.PropertyKeyIsWordWrappingEnabled, () => true);
				_view.IsSpellCheckingEnabled = _options.IsSpellCheckingEnabled ?? _options.Document.GetPropertyValue(TextDocumentViewOptions.PropertyKeyIsSpellCheckingEnabled, () => true);
				_view.IsHyphenationEnabled = TextDocument.IsHyphenationEnabled ?? TextDocument.GetPropertyValue(TextDocumentViewOptions.PropertyKeyIsHyphenationEnabled, () => true);
				_view.IsFoldingEnabled = _options.IsFoldingEnabled ?? _options.Document.GetPropertyValue(TextDocumentViewOptions.PropertyKeyIsFoldingEnabled, () => true);
				_view.HighlightingStyle = _options.HighlightingStyle ?? _options.Document.GetPropertyValue(TextDocumentViewOptions.PropertyKeyHighlightingStyle, () => "default");
				_view.IsInInitializationMode = false;
			}
		}

		private void AttachView()
		{
			_view.SourceTextChanged += EhSourceTextChanged;
			_view.Controller = this;
		}

		private void DetachView()
		{
			_view.SourceTextChanged -= EhSourceTextChanged;
			_view.Controller = null;
		}

		private void EhDocumentChanged(object sender, EventArgs e)
		{
		}

		private void EhSourceTextChanged(object sender, EventArgs e)
		{
			if (null != _view)
			{
				TextDocument.SourceText = _view.SourceText;
			}
		}

		public bool Apply(bool disposeController)
		{
			throw new NotImplementedException();
		}

		public bool Revert(bool disposeController)
		{
			throw new NotImplementedException();
		}

		public string InsertImageInDocumentAndGetUrl(string fileName)
		{
			var imageProxy = MemoryStreamImageProxy.FromFile(fileName);
			return TextDocument.AddImage(imageProxy);
		}

		public string InsertImageInDocumentAndGetUrl(System.IO.MemoryStream memoryStream, string fileExtension)
		{
			var imageProxy = MemoryStreamImageProxy.FromStream(memoryStream, fileExtension);
			return TextDocument.AddImage(imageProxy);
		}

		public bool CanAcceptImageFileName(string fileName)
		{
			var extension = System.IO.Path.GetExtension(fileName).ToLowerInvariant();
			switch (extension)
			{
				case ".jpg":
				case ".jpeg":
				case ".png":
				case ".bmp":
				case ".tif":
					return true;

				default:
					return false;
			}
		}

		public void EhIsViewerSelectedChanged(bool isViewerSelected)
		{
			_options.IsViewerSelected = isViewerSelected;
		}

		public void EhViewerConfigurationChanged(ViewerConfiguration windowConfiguration)
		{
			_options.WindowConfiguration = windowConfiguration;
		}

		public void EhFractionOfEditorWindowChanged(double fractionOfEditor)
		{
			_options.FractionOfSourceEditorWindowVisible = fractionOfEditor;
		}

		public void EhReferencedImageUrlsChanged(IEnumerable<(string Url, int urlSpanStart, int urlSpanEnd)> referencedImageUrls)
		{
			this.TextDocument.ReferencedImageUrls = referencedImageUrls;
		}

		public override object ViewObject
		{
			get
			{
				return _view;
			}
			set
			{
				if (null != _view)
				{
					DetachView();
				}

				_view = value as ITextDocumentView;

				if (null != _view)
				{
					AttachView();
					Initialize(false);
				}
			}
		}

		public override object ModelObject
		{
			get
			{
				return (TextDocumentViewOptions)_options.Clone();
			}
		}
	}
}
