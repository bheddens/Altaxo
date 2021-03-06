﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2012 Dr. Dirk Lellinger
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

namespace Altaxo.Drawing.ColorManagement
{
  public static class ColorSetExtensions
  {
    /// <summary>
    /// Gets a color that is located at the next index after the specified  color.
    /// </summary>
    /// <param name="c">The given color.</param>
    /// <returns>The color that is located at the next index after the specified color. If the specified color is the last color in the color set, the first color of the color set is returned.</returns>
    public static NamedColor GetNextPlotColor(this NamedColor c)
    {
      return GetNextPlotColor(c, 1);
    }

    /// <summary>
    /// Gets a color that is the specified number of steps away from the given color.
    /// </summary>
    /// <param name="c">The given color.</param>
    /// <param name="step">The number of step.</param>
    /// <returns>The color that is the specified number of steps away of the specified color in the set. The color set is given by the <see cref="NamedColor.ParentColorSet"/> in the given color.</returns>
    public static NamedColor GetNextPlotColor(this NamedColor c, int step)
    {
      return GetNextPlotColor(c, step, out var wraps);
    }

    /// <summary>
    /// Gets a color that is the specified number of steps away from the given color.
    /// </summary>
    /// <param name="c">The given color.</param>
    /// <param name="step">The number of step.</param>
    /// <param name="wraps">On return, this value contains the number of wraps that have been made to find the return color. That means, that when by the specified number of steps the end of the color set is reached, a value of one is added to the wraps value.</param>
    /// <returns>The color that is the specified number of steps away of the specified color in the set. The color set is given by the <see cref="NamedColor.ParentColorSet"/> in the given color.</returns>
    public static NamedColor GetNextPlotColor(this NamedColor c, int step, out int wraps)
    {
      var colorSet = c.ParentColorSet;
      if (colorSet == null)
      {
        wraps = 0;
        return c;
      }

      int i = colorSet.IndexOf(c);
      if (i >= 0)
      {
        wraps = Calc.BasicFunctions.NumberOfWraps(colorSet.Count, i, step);
        return colorSet[Calc.BasicFunctions.PMod(i + step, colorSet.Count)];
      }
      else
      {
        // default if the color was not found
        wraps = 0;
        return colorSet[0];
      }
    }

    /// <summary>
    /// Gets the index in the plot color set that is the specified number of steps away from the given color index.
    /// </summary>
    /// <param name="colorSet">The given color set.</param>
    /// <param name="idx">Original index in the given color set.</param>
    /// <param name="step">The number of step.</param>
    /// <param name="wraps">On return, this value contains the number of wraps that have been made to find the return color. That means, that when by the specified number of steps the end of the color set is reached, a value of one is added to the wraps value.</param>
    /// <returns>The index in the plot color set that is the specified number of steps away of the specified color index in the set.</returns>
    public static int GetNextPlotColorIndex(this IColorSet colorSet, int idx, int step, out int wraps)
    {
      if (colorSet == null)
      {
        wraps = 0;
        return idx;
      }
      if (idx >= 0)
      {
        wraps = Calc.BasicFunctions.NumberOfWraps(colorSet.Count, idx, step);
        return Calc.BasicFunctions.PMod(idx + step, colorSet.Count);
      }
      else
      {
        // default if idx<0
        wraps = 0;
        return 0;
      }
    }
  }
}
