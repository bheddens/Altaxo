﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2016 Dr. Dirk Lellinger
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
//    along with ctrl program; if not, write to the Free Software
//    Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
//
/////////////////////////////////////////////////////////////////////////////

#endregion Copyright

using Altaxo.Drawing;
using Altaxo.Drawing.ColorManagement;
using Altaxo.Drawing.D3D;
using Altaxo.Drawing.DashPatternManagement;
using Altaxo.Drawing.DashPatterns;
using Altaxo.Graph;
using Altaxo.Graph.Graph3D.Plot.Groups;
using Altaxo.Graph.Graph3D.Plot.Styles;
using Altaxo.Gui.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace Altaxo.Gui.Drawing.DashPatternManagement
{
	public abstract class DashPatternComboBoxBase : Altaxo.Gui.Drawing.StyleListComboBoxBase<DashPatternListManager, DashPatternList, IDashPattern>
	{
		public DashPatternComboBoxBase(DashPatternListManager manager) : base(manager)
		{
		}
	}

	public partial class DashPatternComboBox : DashPatternComboBoxBase
	{
		private DashPatternToItemNameConverter _itemToItemNameConverter;

		#region Constructors

		public DashPatternComboBox()
			: base(DashPatternListManager.Instance)
		{
			UpdateTreeViewTreeNodes();

			InitializeComponent();

			_itemToItemNameConverter = new DashPatternToItemNameConverter(GuiComboBox);

			UpdateComboBoxSourceSelection(SelectedItem);
			UpdateTreeViewSelection();

			var valueBinding = new Binding();
			valueBinding.Source = this;
			valueBinding.Path = new PropertyPath("SelectedItem");
			valueBinding.Converter = _itemToItemNameConverter;
			//valueBinding.ValidationRules.Add(new ValidationWithErrorString(_itemToItemNameConverter.EhValidateText));
			GuiComboBox.SetBinding(ComboBox.TextProperty, valueBinding);
		}

		#endregion Constructors

		#region Implementation of abstract base class members

		protected override TreeView GuiTreeView { get { return _guiTreeView; } }

		protected override ComboBox GuiComboBox { get { return _guiComboBox; } }

		public override string GetDisplayName(IDashPattern item)
		{
			return (string)_itemToItemNameConverter.Convert(item, typeof(string), null, System.Globalization.CultureInfo.InvariantCulture);
		}

		#endregion Implementation of abstract base class members
	}
}