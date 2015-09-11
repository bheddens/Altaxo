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

namespace Altaxo.Graph3D
{
	public class GridPartitioning3D
		:
		Main.SuspendableDocumentNodeWithSetOfEventArgs,
		Main.ICopyFrom
	{
		protected Altaxo.Graph.LinearPartitioning _xPartitioning;
		protected Altaxo.Graph.LinearPartitioning _yPartitioning;
		protected Altaxo.Graph.LinearPartitioning _zPartitioning;

		#region Serialization

		#region Version 0

		/// <summary>
		/// 2015-09-49 initial version.
		/// </summary>
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(GridPartitioning3D), 0)]
		private class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public virtual void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				var s = (GridPartitioning3D)obj;

				info.AddValue("XPartitioning", s._xPartitioning);
				info.AddValue("YPartitioning", s._yPartitioning);
				info.AddValue("ZPartitioning", s._zPartitioning);
			}

			protected virtual GridPartitioning3D SDeserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				var s = (o == null ? new GridPartitioning3D() : (GridPartitioning3D)o);

				s._xPartitioning = (Altaxo.Graph.LinearPartitioning)info.GetValue("XPartitioning", s);
				if (null != s._xPartitioning) s._xPartitioning.ParentObject = s;

				s._yPartitioning = (Altaxo.Graph.LinearPartitioning)info.GetValue("YPartitioning", s);
				if (null != s._yPartitioning) s._yPartitioning.ParentObject = s;

				s._zPartitioning = (Altaxo.Graph.LinearPartitioning)info.GetValue("ZPartitioning", s);
				if (null != s._yPartitioning) s._yPartitioning.ParentObject = s;

				return s;
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				var s = SDeserialize(o, info, parent);
				return s;
			}
		}

		#endregion Version 0

		#endregion Serialization

		public GridPartitioning3D()
		{
			_xPartitioning = new Altaxo.Graph.LinearPartitioning() { ParentObject = this };
			_yPartitioning = new Altaxo.Graph.LinearPartitioning() { ParentObject = this };
			_zPartitioning = new Altaxo.Graph.LinearPartitioning() { ParentObject = this };
		}

		public GridPartitioning3D(GridPartitioning3D from)
		{
			_xPartitioning = new Altaxo.Graph.LinearPartitioning() { ParentObject = this };
			_yPartitioning = new Altaxo.Graph.LinearPartitioning() { ParentObject = this };
			_zPartitioning = new Altaxo.Graph.LinearPartitioning() { ParentObject = this };
			CopyFrom(from);
		}

		public bool CopyFrom(object obj)
		{
			if (object.ReferenceEquals(this, obj))
				return true;

			var from = obj as GridPartitioning3D;
			if (null != from)
			{
				using (var suspendToken = SuspendGetToken())
				{
					ChildCopyToMember(ref _xPartitioning, from._xPartitioning);
					ChildCopyToMember(ref _yPartitioning, from._yPartitioning);
					ChildCopyToMember(ref _zPartitioning, from._zPartitioning);

					suspendToken.Resume();
				}
				return true;
			}
			return false;
		}

		public object Clone()
		{
			return new GridPartitioning3D(this);
		}

		protected override IEnumerable<Main.DocumentNodeAndName> GetDocumentNodeChildrenWithName()
		{
			if (null != _xPartitioning)
				yield return new Main.DocumentNodeAndName(_xPartitioning, () => _xPartitioning = null, "XPartitioning");
			if (null != _yPartitioning)
				yield return new Main.DocumentNodeAndName(_yPartitioning, () => _yPartitioning = null, "YPartitioning");
			if (null != _zPartitioning)
				yield return new Main.DocumentNodeAndName(_zPartitioning, () => _zPartitioning = null, "ZPartitioning");
		}

		public Altaxo.Graph.LinearPartitioning XPartitioning { get { return _xPartitioning; } }

		public Altaxo.Graph.LinearPartitioning YPartitioning { get { return _yPartitioning; } }

		public Altaxo.Graph.LinearPartitioning ZPartitioning { get { return _zPartitioning; } }

		public virtual bool IsEmpty { get { return _xPartitioning.Count == 0 && _yPartitioning.Count == 0 && _zPartitioning.Count == 0; } }

		public RectangleD3D GetTileRectangle(double columnPosX, double columnPosY, double columnPosZ,
			double columnSpanX, double columnSpanY, double columnSpanZ, VectorD3D totalSize)
		{
			double xstart, xsize;
			double ystart, ysize;
			double zstart, zsize;
			_xPartitioning.GetAbsolutePositionAndSizeFromGridIndexAndSpan(totalSize.X, columnPosX, columnSpanX, out xstart, out xsize);
			_yPartitioning.GetAbsolutePositionAndSizeFromGridIndexAndSpan(totalSize.Y, columnPosY, columnSpanY, out ystart, out ysize);
			_zPartitioning.GetAbsolutePositionAndSizeFromGridIndexAndSpan(totalSize.Z, columnPosZ, columnSpanZ, out zstart, out zsize);
			return new RectangleD3D(xstart, ystart, zstart, xsize, ysize, zsize);
		}
	}
}