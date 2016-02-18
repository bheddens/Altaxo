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

using Altaxo.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altaxo.Graph.Graph3D
{
	/// <summary>
	/// Holds information about a hitted point on the screen.
	/// </summary>
	public class HitTestPointData
	{
		/// <summary>Transformation that transform the coordinates of the object under test to hit coordinates. It is a hit if in hit coordinates
		/// the object touches the ray xhit=0, yhit=0, zhit=-Infinity to +Infinity.</summary>
		private Matrix4x3 _hitTransformation;

		/// <summary>
		/// Transformation that transforms the coordinates under test to world coordinates (i.e. to the graph's root layer coordinates).
		/// Upon construction this is the identity matrix. As this object is distributed to leaf elements, the transformation is updates,
		/// for instance by the local transformations of the layers.
		/// </summary>
		private Matrix4x3 _worldTransformation;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="transformation">The original hit ray matrix. Usually obtained using the mouse coordinates and the camera settings.</param>
		public HitTestPointData(Matrix4x3 transformation)
		{
			_hitTransformation = transformation;
			_worldTransformation = Matrix4x3.Identity;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="from">Another HitTestData object to copy from.</param>
		public HitTestPointData(HitTestPointData from)
		{
			this._hitTransformation = from._hitTransformation;
			this._worldTransformation = from._worldTransformation;
		}

		public HitTestPointData NewFromAdditionalTransformation(Matrix4x3 additionalTransformation)
		{
			var result = new HitTestPointData(this);
			result._hitTransformation.PrependTransform(additionalTransformation);
			result._worldTransformation.PrependTransform(additionalTransformation);
			return result;
		}

		/// <summary>Transformation that transform the coordinates of the object under test to hit coordinates. It is a hit if in hit coordinates
		/// the object touches the ray xhit=0, yhit=0, zhit=-Infinity to +Infinity.</summary>
		public Matrix4x3 HitTransformation
		{
			get
			{
				return _hitTransformation;
			}
		}

		/// <summary>
		/// Transformation that transforms the coordinates under test to world coordinates (i.e. to the graph's root layer coordinates).
		/// Upon construction this is the identity matrix. As this hit data is distributed to leaf elements, the transformation is updates,
		/// for instance by the local transformations of the layers. Intended to use for construction of the IObjectOutline objects that indicate the hitted object.
		/// </summary>
		public Matrix4x3 WorldTransformation
		{
			get
			{
				return _worldTransformation;
			}
		}

		/// <summary>
		/// Gets the transformation of this item plus an additional transformation. Both together transform world coordinates to page coordinates.
		/// </summary>
		/// <param name="additionalTransformation">The additional transformation matrix.</param>
		/// <returns></returns>
		public Matrix4x3 GetHitTransformationWithAdditionalTransformation(Matrix4x3 additionalTransformation)
		{
			Matrix4x3 result = _hitTransformation;
			result.PrependTransform(additionalTransformation);
			return result;
		}

		/// <summary>
		/// Test if the triangle spanned by p0, p1 and p2 in the x-y plane (z component ignored) includes the point x=0, y=0.
		/// </summary>
		/// <param name="p0">The point p0.</param>
		/// <param name="p1">The point p1.</param>
		/// <param name="p2">The point p2.</param>
		/// <param name="z">The minimum z component of all three provided points.</param>
		/// <returns>True if the point x=0, y=0 is included in the triangle, otherwise false.</returns>
		private static bool HitTestWithAlreadyTransformedPoints(PointD3D p0, PointD3D p1, PointD3D p2, out double z)
		{
			if (
				(p0.X * p1.Y - p0.Y * p1.X) <= 0 &&
				(p1.X * p2.Y - p1.Y * p2.X) <= 0 &&
				(p2.X * p0.Y - p2.Y * p0.X) <= 0
				)
			{
				z = Math.Min(Math.Min(p0.Z, p1.Z), p2.Z);
				return true;
			}
			else
			{
				z = double.NaN;
				return false;
			}
		}

		/// <summary>
		/// Determines whether the specified 3D-rectangle r is hit by a ray given by x=0, y=0, z>0.
		/// </summary>
		/// <param name="r">The rectangle r.</param>
		/// <param name="z">If there was a hit, this is the z coordinate of the hit.</param>
		/// <returns>True if the rectangle is hit by a ray given by x=0, y=0, z>0.</returns>
		public bool IsHit(RectangleD3D r, out double z)
		{
			return IsRectangleHitByRay(r, _hitTransformation, out z);
		}

		/// <summary>
		/// Determines whether the specified 3D-rectangle r is hit by a ray given by x=0, y=0, z>0.
		/// </summary>
		/// <param name="r">The rectangle r.</param>
		/// <param name="rectangleToWorldTransformation">An additional transformation that transformes the given rectangle into the same coordinates as the hit data.</param>
		/// <param name="z">If there was a hit, this is the z coordinate of the hit.</param>
		/// <returns>True if the rectangle is hit by a ray given by x=0, y=0, z>0.</returns>
		public bool IsHit(RectangleD3D r, Matrix4x3 rectangleToWorldTransformation, out double z)
		{
			rectangleToWorldTransformation.AppendTransform(_hitTransformation);

			return IsRectangleHitByRay(r, rectangleToWorldTransformation, out z);
		}

		/// <summary>
		/// Determines whether the specified 3D-rectangle r is hit by a ray given by the provided transformation matrix that would transform
		/// the hit ray in a ray at x=0, y=0, and z=-Infinity .. +Infinity.
		/// </summary>
		/// <param name="r">The rectangle r.</param>
		/// <param name="rayTransformation">The hit ray transformation.</param>
		/// <param name="z">If there was a hit, this is the z coordinate of the hit (otherwise, NaN is returned).</param>
		/// <returns>True if the rectangle is hit by a ray given by the provided hit ray matrix.</returns>
		public static bool IsRectangleHitByRay(RectangleD3D r, Matrix4x3 rayTransformation, out double z)
		{
			PointD3D[] vertices = new PointD3D[8];

			int i = 0;
			foreach (var v in r.Vertices)
				vertices[i++] = rayTransformation.TransformPoint(v);

			foreach (var ti in r.TriangleIndices)
			{
				if (HitTestWithAlreadyTransformedPoints(vertices[ti.Item1], vertices[ti.Item2], vertices[ti.Item3], out z) && z < 0)
					return true;
			}

			z = double.NaN;
			return false;
		}

		/// <summary>
		/// Determines whether a polyline is hit.
		/// </summary>
		/// <param name="points">The points that make out the polyline.</param>
		/// <param name="maxDistance">The maximum distance to the polyline that is considered as a hit.</param>
		/// <returns>True if the polyline is hit; otherwise false.</returns>
		public bool IsHit(IEnumerable<PointD3D> points, double maxDistance)
		{
			double maxDistanceSq = maxDistance * maxDistance;
			bool prevPointHasValue = false;
			PointD3D prevPoint = PointD3D.Empty;
			foreach (var p in points)
			{
				var currPoint = _hitTransformation.Transform(p);
				if (prevPointHasValue)
				{
					// determine how far the line p0 and p1 is away from x=0 and y=0
					var distsq = Math2D.SquareDistanceLineToPoint(PointD2D.Empty, new PointD2D(prevPoint.X, prevPoint.Y), new PointD2D(currPoint.X, currPoint.Y));
					if (distsq <= maxDistanceSq)
						return true;
				}
				prevPoint = currPoint;
				prevPointHasValue = true;
			}
			return false;
		}

		public bool IsHit(LineD3D line, double thickness1, double thickness2)
		{
			if (!(line.Length > 0))
				return false;

			var eastnorth = Math3D.GetEastNorthVector(line);
			var e = eastnorth.Item1; // east vector
			var n = eastnorth.Item2; // north vector

			double thickness1By2 = thickness1 / 2;
			double thickness2By2 = thickness2 / 2;
			PointD3D[] pts = new PointD3D[8];

			pts[0] = _hitTransformation.Transform(line.P0 - thickness1By2 * e - thickness2By2 * n);
			pts[1] = _hitTransformation.Transform(line.P1 - thickness1By2 * e - thickness2By2 * n);
			pts[2] = _hitTransformation.Transform(line.P0 + thickness1By2 * e - thickness2By2 * n);
			pts[3] = _hitTransformation.Transform(line.P1 + thickness1By2 * e - thickness2By2 * n);
			pts[4] = _hitTransformation.Transform(line.P0 - thickness1By2 * e + thickness2By2 * n);
			pts[5] = _hitTransformation.Transform(line.P1 - thickness1By2 * e + thickness2By2 * n);
			pts[6] = _hitTransformation.Transform(line.P0 + thickness1By2 * e + thickness2By2 * n);
			pts[7] = _hitTransformation.Transform(line.P1 + thickness1By2 * e + thickness2By2 * n);

			double z;
			foreach (var ti in RectangleD3D.GetTriangleIndices())
			{
				if (HitTestWithAlreadyTransformedPoints(pts[ti.Item1], pts[ti.Item2], pts[ti.Item3], out z) && z < 0)
					return true;
			}

			z = double.NaN;
			return false;
		}
	}
}