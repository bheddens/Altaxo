﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2014 Dr. Dirk Lellinger
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

namespace Altaxo.Gui.Graph.Scales.Ticks
{
  /// <summary>
  /// Interaction logic for TickSpacingControl.xaml
  /// </summary>
  public partial class TickSpacingControl : UserControl, ITickSpacingView
  {
    public TickSpacingControl()
    {
      InitializeComponent();
    }

    public event Action TickSpacingTypeChanged;

    public void InitializeTickSpacingType(Collections.SelectableListNodeList names)
    {
      //ComboBox _cbTickSpacingType = (ComboBox)LogicalTreeHelper.FindLogicalNode((DependencyObject)_tickSpacingGroupBox.Header, "_cbTickSpacingType");
      GuiHelper.Initialize(_cbTickSpacingType, names);
    }

    private void EhTickSpacingType_SelectionChangeCommitted(object sender, SelectionChangedEventArgs e)
    {
      e.Handled = true;
      if (null != TickSpacingTypeChanged)
      {
        ComboBox _cbTickSpacingType = (ComboBox)sender;
        GuiHelper.SynchronizeSelectionFromGui(_cbTickSpacingType);
        TickSpacingTypeChanged();
      }
    }

    public void SetTickSpacingView(object guiobject)
    {
      _guiDetailsHost.Child = guiobject as UIElement;
    }
  }
}
