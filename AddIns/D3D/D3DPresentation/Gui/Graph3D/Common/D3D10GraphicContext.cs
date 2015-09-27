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

namespace Altaxo.Gui.Graph3D.Common
{
	using Altaxo.Graph3D;

	using SharpDX;

	public class D3D10GraphicContext : GraphicContext3DBase, IDisposable
	{
		protected PositionColorTriangleBuffer _positionColorTriangleBuffer;

		protected PositionColorIndexedTriangleBuffer _positionColorIndexedTriangleBuffer;

		private GraphicState _transformation = new GraphicState() { Transformation = MatrixD3D.Identity };

		public override IPositionColorTriangleBuffer GetPositionColorTriangleBuffer(int numberOfVertices)
		{
			if (null == _positionColorTriangleBuffer)
				_positionColorTriangleBuffer = new PositionColorTriangleBuffer(this);

			return _positionColorTriangleBuffer;
		}

		public override IPositionColorIndexedTriangleBuffer GetPositionColorIndexedTriangleBuffer(int numberOfVertices)
		{
			if (null == _positionColorIndexedTriangleBuffer)
				_positionColorIndexedTriangleBuffer = new PositionColorIndexedTriangleBuffer(this);

			return _positionColorIndexedTriangleBuffer;
		}

		public void Dispose()
		{
			if (null != _positionColorTriangleBuffer)
				_positionColorTriangleBuffer.Dispose();
		}

		#region Rendering

		public PositionColorTriangleBuffer BuffersNonindexedTrianglesPositionColor { get { return _positionColorTriangleBuffer; } }
		public PositionColorIndexedTriangleBuffer BuffersIndexTrianglesPositionColor { get { return _positionColorIndexedTriangleBuffer; } }

		#endregion Rendering

		#region Transformation

		internal GraphicState Transformation
		{
			get
			{
				return _transformation;
			}
		}

		public override object SaveGraphicsState()
		{
			return new GraphicState { Transformation = _transformation.Transformation };
		}

		public override void RestoreGraphicsState(object graphicsState)
		{
			var gs = graphicsState as GraphicState;
			if (null != gs)
				_transformation.Transformation = gs.Transformation;
			else
				throw new ArgumentException(nameof(graphicsState) + " is not a valid graphic state!");
		}

		public override void MultiplyTransform(MatrixD3D m)
		{
			_transformation.Transformation.PrependTransform(m);
		}

		public override void TranslateTransform(double x, double y, double z)
		{
			_transformation.Transformation.TranslatePrepend(x, y, z);
		}

		internal class GraphicState
		{
			public Altaxo.Graph3D.MatrixD3D Transformation;
		}

		#endregion Transformation
	}

	public class PositionColorTriangleBuffer : IPositionColorTriangleBuffer, IDisposable
	{
		private D3D10GraphicContext _parent;
		protected DataStream _vertexStream;
		protected int _vertexCount;

		public PositionColorTriangleBuffer(D3D10GraphicContext parent)
		{
			_parent = parent;
			_vertexStream = new DataStream(1024 * 3 * 32, true, true);
		}

		public DataStream VertexStream { get { return _vertexStream; } }
		public long VertexStreamLength { get { return _vertexCount * 32; } }
		public int VertexCount { get { return _vertexCount; } }

		public void Add(float x, float y, float z, float w, float r, float g, float b, float a)
		{
			_vertexStream.Write(new Vector4(x, y, z, w));
			_vertexStream.Write(new Vector4(r, g, b, a));
			++_vertexCount;
		}

		public void Dispose()
		{
			Disposer.RemoveAndDispose(ref _vertexStream);
			_vertexCount = 0;
		}
	}

	public class PositionColorIndexedTriangleBuffer : IPositionColorIndexedTriangleBuffer, IDisposable
	{
		private D3D10GraphicContext _parent;
		protected DataStream _vertexStream;
		protected DataStream _indexStream;
		protected int _numberOfVertices;
		protected int _numberOfTriangles;

		public PositionColorIndexedTriangleBuffer(D3D10GraphicContext parent)
		{
			_parent = parent;
			_vertexStream = new DataStream(1024 * 1024 * 3 * 32, true, true);
			_indexStream = new DataStream(1024 * 1024 * 12, true, true);
		}

		public DataStream VertexStream { get { return _vertexStream; } }

		public DataStream IndexStream { get { return _indexStream; } }

		public int VertexCount
		{
			get
			{
				return _numberOfVertices;
			}
		}

		public int VertexStreamLength
		{
			get
			{
				return _numberOfVertices * 32;
			}
		}

		public int TriangleCount
		{
			get
			{
				return _numberOfTriangles;
			}
		}

		public int IndexStreamLength
		{
			get
			{
				return _numberOfTriangles * 12;
			}
		}

		public void AddTriangleVertex(float x, float y, float z, float w, float r, float g, float b, float a)
		{
			var pt = _parent.Transformation.Transformation.TransformPoint(new PointD3D(x, y, z));

			_vertexStream.Write(new Vector4((float)pt.X, (float)pt.Y, (float)pt.Z, w));
			_vertexStream.Write(new Vector4(r, g, b, a));
			++_numberOfVertices;
		}

		public void Dispose()
		{
			Disposer.RemoveAndDispose(ref _vertexStream);
			Disposer.RemoveAndDispose(ref _indexStream);
			_numberOfTriangles = 0;
			_numberOfVertices = 0;
		}

		public void AddTriangleIndices(int v1, int v2, int v3)
		{
			_indexStream.Write(v1);
			_indexStream.Write(v3);
			_indexStream.Write(v2);
			++_numberOfTriangles;
		}
	}
}