﻿#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2007 Dr. Dirk Lellinger
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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Altaxo.Serialization;


namespace Altaxo.Graph.Gdi.Shapes
{
	public abstract partial class GraphicBase 
	{
		protected class ShearGripHandle : IGripManipulationHandle
		{
			static readonly PointF[] _shapePoints;

			IHitTestObject _parent;
			PointD2D _drawrPosition;
			PointD2D _fixrPosition;
			PointD2D _fixaPosition;
      PointD2D _initialMousePosition;
			double _initialShear, _initialRotation, _initialScaleX, _initialScaleY;
			TransformationMatrix2D _spanningHalfYRhombus;

			private GraphicBase GraphObject { get { return (GraphicBase)_parent.HittedObject; } }

			public ShearGripHandle(IHitTestObject parent, PointD2D relPos, TransformationMatrix2D spanningHalfYRhombus)
			{
				_parent = parent;
				_drawrPosition = relPos;
				_fixrPosition = new PointD2D(relPos.X == 0 ? 1 : 0, relPos.Y == 0 ? 1 : 0);
				_fixaPosition = GraphObject.RelativeToAbsolutePosition(_fixrPosition, true);
				_spanningHalfYRhombus = spanningHalfYRhombus;
			}


			#region IGripManipulationHandle Members

			public void Activate(PointD2D initialPosition, bool isActivatedUponCreation)
			{
				_initialMousePosition = _parent.Transformation.InverseTransformPoint(initialPosition);

				_fixaPosition = GraphObject.RelativeLocalToAbsoluteParentCoordinates(_fixrPosition);

        _initialShear = GraphObject.Shear;
        _initialRotation = GraphObject.Rotation;
				_initialScaleX = GraphObject.ScaleX;
				_initialScaleY = GraphObject.ScaleY;
			}

			public bool Deactivate()
			{
				return false;
			}

			public void MoveGrip(PointD2D newPosition)
			{
        newPosition = _parent.Transformation.InverseTransformPoint(newPosition);
				PointD2D diff = new PointD2D(newPosition.X - _initialMousePosition.X, newPosition.Y - _initialMousePosition.Y);

        GraphObject.SetShearFrom(_fixrPosition, _fixaPosition, _drawrPosition, diff, _initialRotation, _initialShear, _initialScaleX, _initialScaleY);
			}

			public void Show(Graphics g)
			{
				var pts = (PointF[])_shapePoints.Clone();
				_spanningHalfYRhombus.TransformPoints(pts);
				g.FillPolygon(Brushes.Blue, pts);
			}

			public bool IsGripHitted(PointD2D point)
			{
				point = _spanningHalfYRhombus.InverseTransformPoint(point);
				return Calc.RMath.IsInIntervalCC(point.X, 0, 1) && Calc.RMath.IsInIntervalCC(point.Y, -1, 1);
			}

			#endregion


			static ShearGripHandle()
			{
				// The arrow has a length of 1 and a maximum witdth of 2*arrowWidth and a shaft width of 2*arrowShaft
				const float arrY = 0.5f; // y top of arrow
				const float bigY = 0.3f; // y 
				const float smallY = 0.15f; // y at the base
				const float bigX = 0.33f; // width of one arrow

				_shapePoints = new PointF[] {
        new PointF(0,-smallY),
        new PointF(bigX, -smallY),
        new PointF(bigX, -arrY),
        new PointF(2*bigX,-bigY),
        new PointF(2*bigX, smallY),
        new PointF(bigX, smallY),
        new PointF(bigX, arrY),
        new PointF(0, bigY),
					};
			}
		}

	}
}
