#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2005 Dr. Dirk Lellinger
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
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Altaxo.Gui.Common.Drawing
{
  public class LineThicknessComboBox : ComboBox
  {
    static List<float> _thicknessValues;

    public LineThicknessComboBox()
      : this(1)
    {
    }

    public LineThicknessComboBox(float thickness)
    {
      DropDownStyle = ComboBoxStyle.DropDown;
      DrawMode = DrawMode.OwnerDrawFixed;
      ItemHeight = Font.Height;
      SetDataSource(thickness);
    }

    void SetDefaultValues()
    {
      _thicknessValues = new List<float>();
      _thicknessValues.AddRange(new float[] { 0, 0.125f, 0.25f, 0.5f, 1, 2, 3, 5, 10 });
    }

    void SetDataSource(float thickness)
    {
      this.BeginUpdate();

      if (_thicknessValues == null)
        SetDefaultValues();

      Items.Clear();

      if (!_thicknessValues.Contains(thickness))
      {
        _thicknessValues.Add(thickness);
        _thicknessValues.Sort();
      }

      foreach(float val in _thicknessValues)
      Items.Add(val);

      SelectedItem = thickness;

      this.EndUpdate();
    }

    public float Thickness
    {
      get
      {
        return (float)SelectedItem;
      }
      set
      {
        SetDataSource(value);
      }
    }


    protected override void OnDrawItem(DrawItemEventArgs e)
    {
      Graphics grfx = e.Graphics;
      Rectangle rectColor = new Rectangle(e.Bounds.Left, e.Bounds.Top, 2 * e.Bounds.Height, e.Bounds.Height);
      rectColor.Inflate(-1, -1);

      Rectangle rectText = new Rectangle(e.Bounds.Left + 2 * e.Bounds.Height,
        e.Bounds.Top,
        e.Bounds.Width - 2 * e.Bounds.Height,
        e.Bounds.Height);

      if (this.Enabled)
        e.DrawBackground();

      //grfx.DrawRectangle(new Pen(e.ForeColor), rectColor);


      float itemThickness = (float)Items[e.Index];
      SolidBrush foreColorBrush = new SolidBrush(e.ForeColor);

      if (itemThickness >= rectColor.Height)
        grfx.FillRectangle(foreColorBrush, rectColor);
      else
         grfx.DrawLine(new Pen(foreColorBrush, itemThickness),
        rectColor.Left,0.5f*(rectColor.Top+rectColor.Bottom),
        rectColor.Right,0.5f*(rectColor.Top+rectColor.Bottom));

      string text = Altaxo.Serialization.GUIConversion.ToString(itemThickness);
      grfx.DrawString(text, Font, foreColorBrush, rectText);
    }

    protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
    {
      double w;
      if (Altaxo.Serialization.GUIConversion.IsDouble(this.Text, out w))
      {
        this.SetDataSource((float)w);
      }
      else
      {
        e.Cancel = true;
      }

      base.OnValidating(e);
    }
   
   
  }
}
