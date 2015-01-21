﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2011 Dr. Dirk Lellinger
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

using ICSharpCode.Core.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Altaxo.Gui.Pads.ProjectBrowser
{
	public class IndexToImageConverter : IValueConverter
	{
		private static List<ImageSource> _imageList;

		private static void Initialize()
		{
			_imageList = new List<ImageSource>();

			_imageList.Add(PresentationResourceService.GetBitmapSource("Icons.16x16.Desktop"));
			_imageList.Add(PresentationResourceService.GetBitmapSource("Icons.16x16.ClosedFolderBitmap"));
			_imageList.Add(PresentationResourceService.GetBitmapSource("Icons.16x16.OpenFolderBitmap"));
			_imageList.Add(PresentationResourceService.GetBitmapSource("Icons.16x16.StandardWorksheet"));
			_imageList.Add(PresentationResourceService.GetBitmapSource("Icons.16x16.PlotLineScatter"));
			_imageList.Add(PresentationResourceService.GetBitmapSource("Icons.16x16.PropertyBag"));
		}

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (null == _imageList)
				Initialize(); // this late initialization is done here to avoid errors during xaml browsing

			if (value is int)
			{
				int i = (int)value;
				if (i >= 0 && i < _imageList.Count)
					return _imageList[i];
				else
					return null;
			}
			else
				return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}