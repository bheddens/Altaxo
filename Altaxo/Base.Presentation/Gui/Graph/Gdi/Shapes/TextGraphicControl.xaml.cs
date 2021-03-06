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
using Altaxo.Drawing;
using Altaxo.Gui.Graph.Gdi.Background;

namespace Altaxo.Gui.Graph.Gdi.Shapes
{
  /// <summary>
  /// Interaction logic for TextGraphicControl.xaml
  /// </summary>
  public partial class TextGraphicControl : UserControl, ITextGraphicView
  {
    private BackgroundControlsGlue _backgroundGlue;
    private GdiToWpfBitmap _previewBitmap;

    public TextGraphicControl()
    {
      InitializeComponent();

      _backgroundGlue = new BackgroundControlsGlue
      {
        CbStyle = _cbBackgroundStyle,
        CbBrush = _cbBackgroundBrush
      };
      _backgroundGlue.BackgroundStyleChanged += new EventHandler(EhBackgroundStyleChanged);
      _backgroundGlue.BackgroundBrushChanged += new EventHandler(EhBackgroundStyleChanged);

      _previewBitmap = new GdiToWpfBitmap(16, 16);
      m_pnPreview.Source = _previewBitmap.WpfBitmap;
    }

    private void EhBackgroundStyleChanged(object sender, EventArgs e)
    {
      if (null != _controller)
        _controller.EhView_BackgroundStyleChanged();
    }

    private void EhLineSpacingChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      if (null != _controller)
        _controller.EhView_LineSpacingChanged();
    }

    private void EhFontFamilyChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      if (_controller != null)
        _controller.EhView_FontFamilyChanged();
    }

    private void EhFontSize_Changed(object sender, DependencyPropertyChangedEventArgs e)
    {
      if (_controller != null)
        _controller.EhView_FontSizeChanged();
    }

    private void EhTextBrush_SelectionChangeCommitted(object sender, DependencyPropertyChangedEventArgs e)
    {
      if (_controller != null)
        _controller.EhView_TextFillBrushChanged();
    }

    private void EhNormal_Click(object sender, RoutedEventArgs e)
    {
      if (_controller != null)
        _controller.EhView_NormalClick();
    }

    private void EhBold_Click(object sender, RoutedEventArgs e)
    {
      if (_controller != null)
        _controller.EhView_BoldClick();
    }

    private void EhItalic_Click(object sender, RoutedEventArgs e)
    {
      if (_controller != null)
        _controller.EhView_ItalicClick();
    }

    private void EhUnderline_Click(object sender, RoutedEventArgs e)
    {
      if (_controller != null)
        _controller.EhView_UnderlineClick();
    }

    private void EhStrikeout_Click(object sender, RoutedEventArgs e)
    {
      if (_controller != null)
        _controller.EhView_StrikeoutClick();
    }

    private void EhSupIndex_Click(object sender, RoutedEventArgs e)
    {
      if (_controller != null)
        _controller.EhView_SupIndexClick();
    }

    private void EhSubIndex_Click(object sender, RoutedEventArgs e)
    {
      if (_controller != null)
        _controller.EhView_SubIndexClick();
    }

    private void EhGreek_Click(object sender, RoutedEventArgs e)
    {
      if (_controller != null)
        _controller.EhView_GreekClick();
    }

    private void EhEditText_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (_controller != null)
        _controller.EhView_EditTextChanged();
    }

    private void EhPreview_SizeChanged(object sender, SizeChangedEventArgs e)
    {
      int w = (int)e.NewSize.Width;
      int h = (int)e.NewSize.Height;

      if (w > 0 && h > 0 && (w != _previewBitmap.GdiBitmap.Width || h != _previewBitmap.GdiBitmap.Height))
      {
        _previewBitmap.Resize(w, h);
        m_pnPreview.Source = _previewBitmap.WpfBitmap;
        InvalidatePreviewPanel();
      }
    }

    #region ITextGraphicView

    public void BeginUpdate()
    {
    }

    public void EndUpdate()
    {
    }

    private ITextGraphicViewEventSink _controller;

    public ITextGraphicViewEventSink Controller { set { _controller = value; } }

    public Altaxo.Graph.Gdi.Background.IBackgroundStyle SelectedBackground
    {
      get
      {
        return _backgroundGlue.BackgroundStyle;
      }
      set
      {
        _backgroundGlue.BackgroundStyle = value;
      }
    }

    public double SelectedLineSpacing
    {
      get { return _guiLineSpacing.SelectedQuantityAsValueInSIUnits; }
      set { _guiLineSpacing.SelectedQuantityAsValueInSIUnits = value; }
    }

    public string EditText
    {
      get
      {
        return _guiText.Text;
      }
      set
      {
        _guiText.Text = value;
      }
    }

    public FontX SelectedFont
    {
      get
      {
        return Altaxo.Graph.Gdi.GdiFontManager.GetFontX(m_cbFonts.SelectedFontFamilyName, m_cbFontSize.SelectedQuantityAsValueInPoints, FontXStyle.Regular);
      }
      set
      {
        m_cbFonts.SelectedFontFamilyName = Altaxo.Graph.Gdi.GdiFontManager.GetValidFontFamilyName(value);
        m_cbFontSize.SelectedQuantityAsValueInPoints = value.Size;
      }
    }

    public Altaxo.Graph.Gdi.BrushX SelectedFontBrush
    {
      get
      {
        return m_cbFontColor.SelectedBrush;
      }
      set
      {
        m_cbFontColor.SelectedBrush = value;
      }
    }

    public void InsertBeforeAndAfterSelectedText(string insbefore, string insafter)
    {
      if (0 != _guiText.SelectionLength)
      {
        // insert \b( at beginning of selection and ) at the end of the selection
        int len = _guiText.Text.Length;
        int start = _guiText.SelectionStart;
        int end = _guiText.SelectionStart + _guiText.SelectionLength;
        _guiText.Text = _guiText.Text.Substring(0, start) + insbefore + _guiText.Text.Substring(start, end - start) + insafter + _guiText.Text.Substring(end, len - end);

        // now select the text plus the text before and after
        _guiText.Focus(); // necassary to show the selected area
        _guiText.Select(start, end - start + insbefore.Length + insafter.Length);
      }
    }

    public void RevertToNormal()
    {
      // remove a backslash x ( at the beginning and the closing brace at the end of the selection
      if (_guiText.SelectionLength >= 4)
      {
        int len = _guiText.Text.Length;
        int start = _guiText.SelectionStart;
        int end = _guiText.SelectionStart + _guiText.SelectionLength;

        if (_guiText.Text[start] == '\\' && _guiText.Text[start + 2] == '(' && _guiText.Text[end - 1] == ')')
        {
          _guiText.Text = _guiText.Text.Substring(0, start)
            + _guiText.Text.Substring(start + 3, end - start - 4)
            + _guiText.Text.Substring(end, len - end);

          // now select again the rest of the text
          _guiText.Focus(); // neccessary to show the selected area
          _guiText.Select(start, end - start - 4);
        }
      }
    }

    public void InvalidatePreviewPanel()
    {
      if (_controller != null)
      {
        using (var grfx = _previewBitmap.BeginGdiPainting())
        {
          _controller.EhView_PreviewPanelPaint(grfx);
          _previewBitmap.EndGdiPainting();
        }
      }
    }

    #endregion ITextGraphicView

    private void EhLoaded(object sender, RoutedEventArgs e)
    {
      _guiText.Focus();
    }

    private void EhMoreModifiersClicked(object sender, RoutedEventArgs e)
    {
      var menu = sender as MenuItem;
      if (null != menu && menu.Tag is string)
      {
        _guiText.AppendText((string)menu.Tag);
      }
    }

    public object LocationView
    {
      set
      {
        _guiPositionHost.Child = value as UIElement;
      }
    }
  }
}
