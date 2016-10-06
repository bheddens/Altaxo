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

using Altaxo.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Altaxo.Gui.Graph.Gdi
{
	/// <summary>
	/// Interaction logic for GraphExportOptionsControl.xaml
	/// </summary>
	public partial class EmbeddedObjectRenderingOptionsControl : UserControl, IEmbeddedObjectRenderingOptionsView
	{
		public EmbeddedObjectRenderingOptionsControl()
		{
			InitializeComponent();
		}

		public void SetSourceDpi(Altaxo.Collections.SelectableListNodeList list)
		{
			GuiHelper.Initialize(_cbSourceResolution, list);
		}

		public string SourceDpiResolution
		{
			get { return _cbSourceResolution.Text; }
		}

		public double OutputScaling
		{
			get { return _guiOutputScale.SelectedQuantityInSIUnits; }
			set { _guiOutputScale.SelectedQuantityInSIUnits = value; }
		}

		public bool RenderEnhancedMetafile
		{
			get
			{
				return _guiRenderEnhancedMetafile.IsChecked == true;
			}
			set
			{
				_guiRenderEnhancedMetafile.IsChecked = value;
			}
		}

		public bool RenderEnhancedMetafileAsVectorFormat
		{
			get
			{
				return _guiRenderEnhancedMetafileAsVectorFormat.IsChecked == true;
			}
			set
			{
				_guiRenderEnhancedMetafileAsVectorFormat.IsChecked = value;
			}
		}

		public bool RenderWindowsMetafile
		{
			get
			{
				return _guiRenderWindowsMetafile.IsChecked == true;
			}
			set
			{
				_guiRenderWindowsMetafile.IsChecked = value;
			}
		}

		public bool RenderBitmap
		{
			get
			{
				return _guiRenderBitmap.IsChecked == true;
			}
			set
			{
				_guiRenderBitmap.IsChecked = value;
			}
		}

		public NamedColor BackgroundColor
		{
			get
			{
				return _cbBackgroundColor.SelectedColor;
			}
			set
			{
				_cbBackgroundColor.SelectedColor = value;
			}
		}

		public Altaxo.Graph.Gdi.BrushX BackgroundBrush
		{
			get
			{
				return _cbBackgroundBrush.SelectedBrush;
			}
			set
			{
				_cbBackgroundBrush.SelectedBrush = value;
			}
		}
	}
}