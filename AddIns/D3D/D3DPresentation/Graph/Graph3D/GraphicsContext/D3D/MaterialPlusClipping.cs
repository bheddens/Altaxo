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

using Altaxo.Drawing.D3D;
using Altaxo.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altaxo.Graph.Graph3D.GraphicsContext.D3D
{
  public class MaterialKey : Main.IImmutable
  {
    public IMaterial Material { get; private set; }

    public MaterialKey(IMaterial material)
    {
      if (null == material)
        throw new ArgumentNullException(nameof(material));

      this.Material = material;
    }

    public override bool Equals(object obj)
    {
      var from = obj as MaterialKey;
      return null == from ? false : Material.Equals(from.Material);
    }

    public override int GetHashCode()
    {
      return Material.GetHashCode();
    }
  }

  /// <summary>
  /// Combines a material with one or more clip planes.
  /// </summary>
  public class MaterialPlusClippingKey : MaterialKey
  {
    public PlaneD3D[] ClipPlanes { get; private set; }

    public MaterialPlusClippingKey(IMaterial material, PlaneD3D[] clipPlanes)
      : base(material)
    {
      ClipPlanes = clipPlanes;
    }

    public override bool Equals(object obj)
    {
      var from = obj as MaterialPlusClippingKey;
      if (null == from)
        return false;

      if (!(this.Material.Equals(from.Material)))
        return false;

      if (!(this.ClipPlanes != null && from.ClipPlanes != null))
        return (this.ClipPlanes != null) ^ (from.ClipPlanes != null);

      if (this.ClipPlanes.Length != from.ClipPlanes.Length)
        return false;

      for (int i = 0; i < this.ClipPlanes.Length; ++i)
      {
        if (!this.ClipPlanes[i].Equals(from.ClipPlanes[i]))
          return false;
      }

      return true;
    }

    public override int GetHashCode()
    {
      var result = 17 * Material.GetHashCode();
      if (null != ClipPlanes && ClipPlanes.Length > 0)
        result = 31 * ClipPlanes[0].GetHashCode();

      return result;
    }

    public int GetHashCode(MaterialPlusClippingKey obj)
    {
      return obj.GetHashCode();
    }
  }
}
