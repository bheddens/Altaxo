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

using Altaxo.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altaxo.Drawing.D3D.LineCaps
{
  public class ContourArrow05 : ContourShapedLineCapBase
  {
    private class ArrowContour : ILineCapContour
    {
      private double _relativeSize;

      public ArrowContour(double relativeSize)
      {
        _relativeSize = relativeSize;
      }

      public int NumberOfNormals
      {
        get
        {
          return 4;
        }
      }

      public int NumberOfVertices
      {
        get
        {
          return 3;
        }
      }

      public bool IsVertexSharp(int idx)
      {
        return true;
      }

      public VectorD2D Normals(int idx)
      {
        switch (idx)
        {
          case 0:
            return new VectorD2D(-1, 0);

          case 1:
            return new VectorD2D(-1, 0);

          case 2:
            return VectorD2D.CreateNormalized(1, 1);

          case 3:
            return VectorD2D.CreateNormalized(1, 1);

          default:
            throw new IndexOutOfRangeException();
        }
      }

      public PointD2D Vertices(int idx)
      {
        switch (idx)
        {
          case 0:
            return new PointD2D(0, 1);

          case 1:
            return new PointD2D(0, _relativeSize);

          case 2:
            return new PointD2D(_relativeSize, 0);

          default:
            throw new IndexOutOfRangeException();
        }
      }
    }

    private double _minimumRelativeSize;
    private double _minimumAbsoluteSize;

    #region Serialization

    /// <summary>
    /// 2016-05-02 initial version.
    /// </summary>
    [Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(ContourArrow05), 0)]
    private class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
    {
      public virtual void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
      {
        var s = (ContourArrow05)obj;
        info.AddValue("MinAbsoluteSize", s._minimumAbsoluteSize);
        info.AddValue("MinRelativeSize", s._minimumRelativeSize);
      }

      public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {
        double abs = info.GetDouble("MinAbsoluteSize");
        double rel = info.GetDouble("MinRelativeSize");
        return new ContourArrow05(abs, rel);
      }
    }

    #endregion Serialization

    public ContourArrow05()
    {
      _minimumAbsoluteSize = 8;
      _minimumRelativeSize = 2;
    }

    public ContourArrow05(double minAbsoluteSizePt, double minRelativeSize)
    {
      if (!(minAbsoluteSizePt >= 0))
        throw new ArgumentOutOfRangeException(nameof(minAbsoluteSizePt), "must be >= 0");
      if (!(minRelativeSize > 1))
        throw new ArgumentOutOfRangeException(nameof(minRelativeSize), "must be > 1");

      _minimumAbsoluteSize = minAbsoluteSizePt;
      _minimumRelativeSize = minRelativeSize;
    }

    public override double MinimumRelativeSize
    {
      get
      {
        return _minimumRelativeSize;
      }
    }

    public override double MinimumAbsoluteSizePt
    {
      get
      {
        return _minimumAbsoluteSize;
      }
    }

    public override ILineCap WithMinimumAbsoluteAndRelativeSize(double absoluteSizePt, double relativeSize)
    {
      if (!(absoluteSizePt >= 0))
        throw new ArgumentOutOfRangeException(nameof(absoluteSizePt), "must be >= 0");
      if (!(relativeSize > 1))
        throw new ArgumentOutOfRangeException(nameof(relativeSize), "must be > 1");

      if (_minimumAbsoluteSize == absoluteSizePt && _minimumRelativeSize == relativeSize)
      {
        return this;
      }
      else
      {
        var result = (ContourArrow05)MemberwiseClone();
        result._minimumAbsoluteSize = absoluteSizePt;
        result._minimumRelativeSize = relativeSize;
        return result;
      }
    }

    public override double GetAbsoluteBaseInset(double thickness1, double thickness2)
    {
      double relSize = Math.Max(_minimumRelativeSize, _minimumAbsoluteSize / Math.Max(thickness1, thickness2));
      return -relSize * 0.5 * Math.Max(thickness1, thickness2);
    }

    public override void AddGeometry(Action<PointD3D, VectorD3D> AddPositionAndNormal, Action<int, int, int, bool> AddIndices, ref int vertexIndexOffset, bool isStartCap, PointD3D basePoint, VectorD3D eastVector, VectorD3D northVector, VectorD3D forwardVectorNormalized, ICrossSectionOfLine lineCrossSection, PointD3D[] baseCrossSectionPositions, VectorD3D[] baseCrossSectionNormals, ref object temporaryStorageSpace)
    {
      double relSize = Math.Max(_minimumRelativeSize, _minimumAbsoluteSize / Math.Max(lineCrossSection.Size1, lineCrossSection.Size2));

      Add(
        AddPositionAndNormal,
        AddIndices,
        ref vertexIndexOffset,
        isStartCap,
        basePoint,
        eastVector,
        northVector,
        forwardVectorNormalized,
        lineCrossSection,
        baseCrossSectionPositions,
        baseCrossSectionNormals,
        ref temporaryStorageSpace,
        new ArrowContour(relSize));
    }
  }
}
