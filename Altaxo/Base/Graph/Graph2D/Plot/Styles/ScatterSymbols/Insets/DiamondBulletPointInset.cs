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
//    along with this program; if not, write to the Free Software
//    Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
//
/////////////////////////////////////////////////////////////////////////////

#endregion Copyright

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altaxo.Graph.Graph2D.Plot.Styles.ScatterSymbols.Insets
{
  public class DiamondBulletPointInset : InsetBase
  {
    #region Serialization

    /// <summary>
    /// 2016-10-27 initial version.
    /// </summary>
    [Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(DiamondBulletPointInset), 0)]
    private class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
    {
      public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
      {
        info.AddBaseValueEmbedded(obj, obj.GetType().BaseType);
      }

      public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {
        var s = (DiamondBulletPointInset)o ?? new DiamondBulletPointInset();
        info.GetBaseValueEmbedded(s, s.GetType().BaseType, parent);
        return s;
      }
    }

    #endregion Serialization

    private ClipperLib.IntPoint GetPoint(double w, double h)
    {
      const double Scale = 2 * 0.707106781186547524400844;
      return new ClipperLib.IntPoint((int)(Scale * (w + h) * ClipperScalingDouble), (int)(Scale * (h - w) * ClipperScalingDouble));
    }

    public override List<List<ClipperLib.IntPoint>> GetCopyOfClipperPolygon(double relativeWidth)
    {
      double w = relativeWidth;

      return new List<List<ClipperLib.IntPoint>>(1)
      {
        new List<ClipperLib.IntPoint>(4)
        {
        GetPoint(-w, -w),
        GetPoint(w, -w),
        GetPoint(w, w),
        GetPoint(-w, w)
      }
      };
    }
  }
}
