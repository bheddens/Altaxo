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

namespace Altaxo.Gui.Common.Drawing
{
	public interface IWpfColorView
	{
		Color SelectedColor { get; set; }
	}

	/// <summary>
	/// Dummy controller to enable the use of <see cref="ColorPickerControl"/> directly from here in dialogs.
	/// </summary>
	internal class ColorController : IMVCAController
	{
		private Color _doc;
		private IWpfColorView _view;

		public ColorController(Color c)
		{
			_doc = c;
		}

		public object ViewObject
		{
			get
			{
				return _view;
			}
			set
			{
				_view = value as IWpfColorView;

				if (null != _view)
					_view.SelectedColor = _doc;
			}
		}

		public object ModelObject
		{
			get { return _doc; }
		}

		public void Dispose()
		{
		}

		public bool Apply()
		{
			if (null != _view)
				_doc = _view.SelectedColor;
			return true;
		}
	}
}