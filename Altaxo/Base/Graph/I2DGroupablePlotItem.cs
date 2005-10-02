#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2004 Dr. Dirk Lellinger
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
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Altaxo.Graph
{
  /// <summary>
  /// Interface for two dimensional groupable plot styles.
  /// </summary>
  public interface I2DGroupablePlotStyle
  {
   

    /// <summary>
    /// Returns true if the color property get is supported, i.e. the style provides a color.
    /// </summary>
    bool IsColorSupported { get; }


    /// <summary>
    /// Returns the color of the style. If not supported, returns Color.Black.
    /// </summary>
    System.Drawing.Color Color { get; }


    /// <summary>
    /// Returns true if the line style property is supported.
    /// </summary>
    bool IsXYLineStyleSupported { get; }

    /// <summary>
    /// Returns the line style property. If not supported, returns null.
    /// </summary>
    System.Drawing.Drawing2D.DashStyle XYLineStyle { get; }



    /// <summary>
    /// Returns true if the scatter style property is supported.
    /// </summary>
    bool IsXYScatterStyleSupported { get; }

    /// <summary>
    /// Returns the scatter style property. If not supported, returns null.
    /// </summary>
    XYPlotScatterStyles.ShapeAndStyle XYScatterStyle { get; }


    /// <summary>
    /// Sets this style according to a template with step times increment.
    /// </summary>
    /// <param name="pstemplate">The template style.</param>
    /// <param name="style">Information of what in particular to vary (color, line style, symbol style).</param>
    /// <param name="changeConcurrently">If true, the varying styles are changed concurrently.</param>
    /// <param name="changeStrictly">If true, the slave styles are enforced to have the same structure and properties than the master style (except for the varying styles).</param>
    /// <param name="step">The number of steps distance to the template style. For instance, if step==1 the next color is used, if step==-1 the previous color is used.</param>
    void SetIncrementalStyle(I2DGroupablePlotStyle pstemplate, PlotGroupStyle style, bool changeConcurrently, bool changeStrictly, int step);
  }
}