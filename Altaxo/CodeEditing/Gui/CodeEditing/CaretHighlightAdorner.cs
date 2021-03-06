﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

// Originated from: SharpDevelop, AvalonEdit.Addin, src/CaretHighlightAdorner.cs

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;

using ICSharpCode.AvalonEdit.Editing;

namespace Altaxo.Gui.CodeEditing
{
  /// <summary>
  /// Animated rectangle around the caret, that is displayed for 1 second in order to help finding the caret.
  /// </summary>
  public sealed class CaretHighlightAdorner : Adorner
  {
    private Pen pen;
    private RectangleGeometry geometry;

    public CaretHighlightAdorner(TextArea textArea)
      : base(textArea.TextView)
    {
      Rect min = textArea.Caret.CalculateCaretRectangle();
      min.Offset(-textArea.TextView.ScrollOffset);

      Rect max = min;
      double size = Math.Max(min.Width, min.Height) * 0.25;
      max.Inflate(size, size);

      pen = new Pen(TextBlock.GetForeground(textArea.TextView).Clone(), 1);

      geometry = new RectangleGeometry(min, 2, 2);
      geometry.BeginAnimation(RectangleGeometry.RectProperty, new RectAnimation(min, max, new Duration(TimeSpan.FromMilliseconds(300))) { AutoReverse = true });
      pen.Brush.BeginAnimation(Brush.OpacityProperty, new DoubleAnimation(1, 0, new Duration(TimeSpan.FromMilliseconds(200))) { BeginTime = TimeSpan.FromMilliseconds(450) });
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
      drawingContext.DrawGeometry(null, pen, geometry);
    }
  }
}
