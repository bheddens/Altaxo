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
using System.Threading.Tasks;
using Altaxo.Geometry;

namespace Altaxo.Graph.Graph3D.GraphicsContext.D3D
{
  public class PositionNormalUIndexedTriangleBuffer : IndexedTriangleBuffer, IPositionNormalUIndexedTriangleBuffer
  {
    protected const int FloatsPerVertex = 8;

    protected const double UOfColorRegular = 1000.0 / 1024;
    protected const double UOfColorBelow = 12.0 / 1024;
    protected const double UOfColorAbove = 1012.0 / 1024;

    public PositionNormalUIndexedTriangleBuffer(ITransformationContext parent)
      : base(parent)
    {
    }

    protected override int BytesPerVertex { get { return FloatsPerVertex * 4; } }

    public void AddTriangleVertex(double x, double y, double z, double nx, double ny, double nz, double u)
    {
      var pt = _parent.Transformation.Transform(new PointD3D(x, y, z));
      var no = _parent.TransposedInverseTransformation.Transform(new VectorD3D(nx, ny, nz));

      int offs = _numberOfVertices * FloatsPerVertex;

      if (offs + FloatsPerVertex >= _vertexStream.Length)
        Array.Resize(ref _vertexStream, _vertexStream.Length * 2);

      double tu = UOfColorBelow + u * UOfColorRegular;

      _vertexStream[offs + 0] = (float)pt.X;
      _vertexStream[offs + 1] = (float)pt.Y;
      _vertexStream[offs + 2] = (float)pt.Z;
      _vertexStream[offs + 3] = (float)no.X;
      _vertexStream[offs + 4] = (float)no.Y;
      _vertexStream[offs + 5] = (float)no.Z;
      _vertexStream[offs + 6] = (float)tu;
      _vertexStream[offs + 7] = double.IsNaN(u) ? 1E15f : 0;
      ++_numberOfVertices;
    }

    public float[] GetColorArrayForColorProvider(Gdi.Plot.IColorProvider colorProvider)
    {
      int numberOfColors = 1024;
      var result = new float[4 * numberOfColors];

      for (int i = 0, offs = 0; i < numberOfColors; ++i, offs += 4)
      {
        double tu = i / (double)numberOfColors;
        double u = (tu - UOfColorBelow) / UOfColorRegular;

        var c = colorProvider.GetAxoColor(u);

        result[offs + 0] = c.ScR;
        result[offs + 1] = c.ScG;
        result[offs + 2] = c.ScB;
        result[offs + 3] = c.ScA;
      }
      return result;
    }
  }
}
