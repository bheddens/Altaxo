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

using Altaxo.Calc.Regression.Nonlinear;
using Altaxo.Collections;
using Altaxo.Drawing;
using Altaxo.Graph;
using Altaxo.Main.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Altaxo.Gui.Analysis.NonLinearFitting
{
  /// <summary>
  /// Interaction logic for FitFunctionSelectionControl.xaml
  /// </summary>
  public partial class FitFunctionSelectionControl : UserControl, IFitFunctionSelectionView
  {
    public event Action<IFitFunctionInformation> SelectionChanged;

    public event Action<IFitFunctionInformation> ItemDoubleClicked;

    public event Action<IFitFunctionInformation> EditItem;

    public event Action<IFitFunctionInformation> EditCopyOfItem;

    public event Action<IFitFunctionInformation> RemoveItem;

    #region Node classes

    private enum RootNodeType { RootNodeBuiltin, RootNodeDocument, RootNodeUser };

    private class MyNGTreeNode : NGTreeNode
    {
      public MyNGTreeNode(string text)
        : base(text)
      {
      }

      public virtual bool IsMenuRemoveEnabled { get { return false; } }

      public virtual bool IsMenuEditEnabled { get { return false; } }

      public virtual bool IsMenuEditCopyEnabled { get { return false; } }

      public object MySelf { get { return this; } }
    }

    private class RootNode : MyNGTreeNode
    {
      public RootNodeType RootNodeType;

      public string NodeType { get { return RootNodeType.ToString(); } }

      public RootNode(string text, RootNodeType type)
        :
        base(text)
      {
        RootNodeType = type;
        this.Tag = type;
      }
    }

    private class CategoryNode : MyNGTreeNode
    {
      public CategoryNode(string text)
        : base(text)
      {
      }

      public string NodeType { get { return "CategoryNode"; } }
    }

    private class LeafNode : MyNGTreeNode
    {
      public LeafNode(string text)
        : base(text)
      {
      }

      public virtual string NodeType { get { return "LeafNode"; } }

      private bool _canBeRemoved;
      private bool _canBeEdited;
      private bool _canBeACopyEdited;

      public override bool IsMenuEditEnabled { get { return _canBeEdited; } }

      public override bool IsMenuEditCopyEnabled { get { return _canBeACopyEdited; } }

      public override bool IsMenuRemoveEnabled { get { return _canBeRemoved; } }

      public void SetMenuEnabled(bool canBeEdited, bool canBeACopyEdited, bool canBeRemoved)
      {
        _canBeEdited = canBeEdited;
        _canBeACopyEdited = canBeACopyEdited;
        _canBeRemoved = canBeRemoved;
      }
    }

    private class BuiltinLeafNode : LeafNode
    {
      public object FunctionType;

      public override string NodeType { get { return "BuiltinLeafNode"; } }

      public BuiltinLeafNode(string text, object functionType)
        : base(text)
      {
        FunctionType = functionType;
        this.Tag = functionType;
      }
    }

    private class DocumentLeafNode : LeafNode
    {
      public Altaxo.Main.Services.IFitFunctionInformation FunctionInstance;

      public override string NodeType { get { return "DocumentLeafNode"; } }

      public DocumentLeafNode(string text, Altaxo.Main.Services.IFitFunctionInformation func)
        : base(text)
      {
        FunctionInstance = func;
        this.Tag = func;
      }
    }

    private class UserFileLeafNode : LeafNode
    {
      public Altaxo.Main.Services.FileBasedFitFunctionInformation FunctionInfo;

      public override string NodeType { get { return "UserFileLeafNode"; } }

      public UserFileLeafNode(string text, Altaxo.Main.Services.FileBasedFitFunctionInformation func)
        : base(text)
      {
        FunctionInfo = func;
        this.Tag = func;
      }
    }

    #endregion Node classes

    public FitFunctionSelectionControl()
    {
      InitializeComponent();
    }

    private System.Drawing.Graphics _rtfGraphics;

    private void EhFitFunctions_AfterSelect(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
      var node = e.NewValue as NGTreeNode;
      if (node == null)
        return;
      var fitInfo = node.Tag as IFitFunctionInformation;

      SelectionChanged?.Invoke(fitInfo);

      if (fitInfo != null)
      {
        if (_rtfGraphics == null)
        {
          var bmp = new System.Drawing.Bitmap(4, 4);
          _rtfGraphics = System.Drawing.Graphics.FromImage(bmp);
        }
        string rtf = Altaxo.Main.Services.RtfComposerService.GetRtfText(fitInfo.Description, _rtfGraphics, GetRtfBackgroundColor(), 12);
        var stream = new System.IO.MemoryStream(ASCIIEncoding.Default.GetBytes(rtf));
        this._rtfDescription.SelectAll();
        this._rtfDescription.Selection.Load(stream, DataFormats.Rtf);
      }
    }

    #region IFitFunctionSelectionView

    public void SetFitFunctions(NGTreeNodeCollection list)
    {
      this._guiFitFunctions.ItemsSource = list;
    }

    public void SetRtfDocumentation(string rtfString)
    {
      this._rtfDescription.AppendText(rtfString);
    }

    public NamedColor GetRtfBackgroundColor()
    {
      var brush = _rtfDescription.Background;
      if (brush is SolidColorBrush)
        return new NamedColor(GuiHelper.ToAxo(((SolidColorBrush)brush).Color));
      else
        return NamedColors.Transparent;
    }

    #endregion IFitFunctionSelectionView

    private void EhRemoveItem(object sender, RoutedEventArgs e)
    {
      var node = ((FrameworkElement)sender).Tag as NGTreeNode;

      if (node != null)
        RemoveItem?.Invoke(node.Tag as IFitFunctionInformation);
    }

    private void EhEditItem(object sender, RoutedEventArgs e)
    {
      var node = ((FrameworkElement)sender).Tag as NGTreeNode;
      if (node != null)
        EditItem?.Invoke(node.Tag as IFitFunctionInformation);
    }

    private void EhEditCopyOfThisItem(object sender, RoutedEventArgs e)
    {
      var node = ((FrameworkElement)sender).Tag as NGTreeNode;
      if (node != null)
        EditCopyOfItem?.Invoke(node.Tag as IFitFunctionInformation);
    }

    private void EhMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      var source = e.OriginalSource as DependencyObject;
      while (null != source && !(source is TreeView))
      {
        if (source is FrameworkElement fwe && fwe.Tag is NGTreeNode ngtn && ngtn.Tag is IFitFunctionInformation ffinfo)
        {
          ItemDoubleClicked?.Invoke(ffinfo);
          break;
        }
        source = VisualTreeHelper.GetParent(source);
      }
    }
  }
}
