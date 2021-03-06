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
using System.Windows.Controls;
using Altaxo.Collections;

namespace Altaxo.Gui.Common
{
  public class MultipleChoiceListView : ListView
  {
    private SelectableListNodeList _choices;

    public void Initialize(SelectableListNodeList choices)
    {
      SelectionChanged -= EhSelectionChanged; // prevent firing event here

      _choices = choices;
      Items.Clear();
      foreach (var choice in _choices)
      {
        var item = new ListViewItem
        {
          Content = choice.Text,
          Tag = choice
        };
        Items.Add(item);
      }
      int selIndex = _choices.FirstSelectedNodeIndex;
      if (selIndex >= 0)
        SelectedIndex = selIndex;

      SelectionChanged += EhSelectionChanged; // now allow event again
    }

    private void EhSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      e.Handled = true;
      _choices.ClearSelectionsAll();
      if (SelectedIndex >= 0)
        _choices[SelectedIndex].IsSelected = true;
    }
  }
}
