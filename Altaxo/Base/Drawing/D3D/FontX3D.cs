﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2015 Dr. Dirk Lellinger
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
using System.Threading.Tasks;
using Altaxo.Drawing;
using Altaxo.Graph;

namespace Altaxo.Drawing.D3D
{
  public class FontX3D
  {
    private FontX _font;
    private double _depth;

    #region Serialization

    /// <summary>
    /// 2015-11-14 initial version.
    /// </summary>
    [Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(FontX3D), 0)]
    private class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
    {
      public virtual void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
      {
        var s = (FontX3D)obj;
        info.AddValue("Font", s._font);
        info.AddValue("Depth", s._depth);
      }

      public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {
        var font = (FontX)info.GetValue("Font", null);
        var depth = info.GetDouble("Depth");
        var s = new FontX3D(font, depth);
        return s;
      }
    }

    #endregion Serialization

    public FontX3D(FontX font, double depth)
    {
      _font = font;
      _depth = depth;
    }

    public FontX Font
    {
      get { return _font; }
    }

    public double Depth
    {
      get
      {
        return _depth;
      }
    }

    public double Size
    {
      get
      {
        return _font.Size;
      }
    }

    public FontXStyle Style
    {
      get
      {
        return _font.Style;
      }
    }

    /// <summary>Gets the name of the font family.</summary>
    /// <value>The name of the font family.</value>
    public string FontFamilyName { get { return _font.FontFamilyName; } }

    public FontX3D WithSize(double newSize)
    {
      return new FontX3D(_font.WithSize(newSize), _depth);
    }

    public FontX3D WithFamily(string newFamily)
    {
      return new FontX3D(_font.WithFamily(newFamily), _depth);
    }

    public FontX3D WithStyle(FontXStyle style)
    {
      return new FontX3D(_font.WithStyle(style), _depth);
    }

    public FontX3D WithDepth(double newDepth)
    {
      return new FontX3D(_font, newDepth);
    }
  }
}
