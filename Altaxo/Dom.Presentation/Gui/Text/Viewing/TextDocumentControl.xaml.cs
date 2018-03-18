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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Altaxo.Gui.Text.Viewing
{
	/// <summary>
	/// Interaction logic for TextDocumentControl.xaml
	/// </summary>
	public partial class TextDocumentControl : UserControl, ITextDocumentView
	{
		private ImageProvider _imageProvider = new ImageProvider("", null);
		private ITextDocumentController _controller;

		public TextDocumentControl()
		{
			InitializeComponent();
			_guiEditor.ImageProvider = _imageProvider;
		}

		public ITextDocumentController Controller
		{
			set
			{
				_controller = value;
			}
		}

		/// <inheritdoc/>
		public void SetDocumentNameAndLocalImages(string documentName, IReadOnlyDictionary<string, Altaxo.Graph.MemoryStreamImageProxy> localImages)
		{
			var folder = Altaxo.Main.ProjectFolder.GetFolderPart(documentName);
			if (_imageProvider.AltaxoFolderLocation != folder || _imageProvider.LocalImages != localImages)
			{
				_guiEditor.ImageProvider = _imageProvider = new ImageProvider(folder, localImages);
			}
		}

		public string SourceText { get => _guiEditor.SourceText; set => _guiEditor.SourceText = value; }
		public string StyleName { set => _guiEditor.StyleName = value; }

		public event EventHandler SourceTextChanged
		{
			add
			{
				_guiEditor.SourceTextChanged += value;
			}
			remove
			{
				_guiEditor.SourceTextChanged -= value;
			}
		}

		private void EhPreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.F12 && Altaxo.Gui.Markdown.Commands.ToggleBetweenEditorAndViewer.CanExecute(null, null))
			{
				Altaxo.Gui.Markdown.Commands.ToggleBetweenEditorAndViewer.Execute(null, null);
				e.Handled = true;
			}

			if (e.Key == Key.F5 && Altaxo.Gui.Markdown.Commands.RefreshViewer.CanExecute(null, null))
			{
				Altaxo.Gui.Markdown.Commands.RefreshViewer.Execute(null, null);
				e.Handled = true;
			}
		}

		#region Pasting of images

		private string InsertImageInDocumentAndGetUrl(string fileName)
		{
			return _controller?.InsertImageInDocumentAndGetUrl(fileName);
		}

		private string InsertImageInDocumentAndGetUrl(ImageSource imgSource)
		{
			// before we can give the image to the controller, we have to create a stream from it

			if (imgSource is BitmapSource bmpSource)
			{
				var pngStream = new System.IO.MemoryStream();
				BitmapEncoder pngEncoder = new PngBitmapEncoder();
				pngEncoder.Frames.Add(BitmapFrame.Create(bmpSource));
				pngEncoder.Save(pngStream);
				pngStream.Seek(0, System.IO.SeekOrigin.Begin);

				var jpgStream = new System.IO.MemoryStream();
				BitmapEncoder jpgEncoder = new JpegBitmapEncoder();
				jpgEncoder.Frames.Add(BitmapFrame.Create(bmpSource));
				jpgEncoder.Save(jpgStream);
				jpgStream.Seek(0, System.IO.SeekOrigin.Begin);

				var stream = pngStream.Length < jpgStream.Length ? pngStream : jpgStream;
				var altStream = pngStream.Length < jpgStream.Length ? jpgStream : pngStream;
				altStream.Dispose();

				return _controller?.InsertImageInDocumentAndGetUrl(stream);
			}

			return null;
		}

		private void EhPreviewExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (e.Command == ApplicationCommands.Paste)
			{
				if (Clipboard.ContainsFileDropList())
				{
					var fileList = Clipboard.GetFileDropList();
					foreach (var fileName in fileList)
					{
						if (true == _controller.CanAcceptImageFileName(fileName))
						{
							string url = InsertImageInDocumentAndGetUrl(fileName);

							if (null != url)
							{
								_guiEditor.InsertSourceTextAtCaretPosition(string.Format("![](local:{0})", url));
								e.Handled = true;
							}
						}
					}
				}
				else if (Clipboard.ContainsImage())
				{
					var bitmap = Clipboard.GetImage();
					var url = InsertImageInDocumentAndGetUrl(bitmap);
					if (null != url)
					{
						_guiEditor.InsertSourceTextAtCaretPosition(string.Format("![](local:{0})", url));
						e.Handled = true;
					}
				}
			}
		}

		private void EhPreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			if (e.Command == ApplicationCommands.Paste)
			{
				if (Clipboard.ContainsFileDropList())
				{
					var fileList = Clipboard.GetFileDropList();
					foreach (var fileName in fileList)
					{
						if (true == _controller.CanAcceptImageFileName(fileName))
						{
							e.CanExecute = true;
							e.Handled = true;
						}
					}
				}
				else if (Clipboard.ContainsImage())
				{
					e.CanExecute = true;
					e.Handled = true;
				}
			}
		}

		#endregion Pasting of images
	}
}
