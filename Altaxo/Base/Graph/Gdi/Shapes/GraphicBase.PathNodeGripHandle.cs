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
		/// <summary>
		/// Shows a single round grip, which can be customized to a move action.
		/// </summary>
		protected class PathNodeGripHandle : IGripManipulationHandle
		{
			PointD2D _gripCenter;
			double _gripRadius;
			IHitTestObject _parent;
			PointD2D _drawrPosition;
			PointD2D _fixrPosition;
			PointD2D _fixaPosition;

			Action<PointD2D> _moveAction;

			public static Pen PathOutlinePen = new Pen(Color.Blue, 0);

			public PathNodeGripHandle(IHitTestObject parent, PointD2D relPos, PointD2D gripCenter, double gripRadius)
			{
				_parent = parent;
				_drawrPosition = relPos;
				_fixrPosition = new PointD2D(relPos.X == 0 ? 1 : 0, relPos.Y == 0 ? 1 : 0);
				_fixaPosition = GraphObject.RelativeToAbsolutePosition(_fixrPosition, true);

				_gripCenter = gripCenter;
				_gripRadius = gripRadius;
			}


			public PathNodeGripHandle(IHitTestObject parent, PointD2D relPos, PointD2D gripCenter, double gripRadius, Action<PointD2D> moveAction)
				: this(parent, relPos, gripCenter, gripRadius)
			{
				_moveAction = moveAction;
			}

			private GraphicBase GraphObject { get { return (GraphicBase)_parent.HittedObject; } }


			#region IGripManipulationHandle Members

			/// <summary>
			/// Activates this grip, providing the initial position of the mouse.
			/// </summary>
			/// <param name="initialPosition">Initial position of the mouse.</param>
			/// <param name="isActivatedUponCreation">If true the activation is called right after creation of this handle. If false,
			/// thie activation is due to a regular mouse click in this grip.</param>
			public void Activate(PointD2D initialPosition, bool isActivatedUponCreation)
			{
			}


			/// <summary>
			/// Announces the deactivation of this grip.
			/// </summary>
			/// <returns>The grip level, that should be displayed next, or -1 when the level should not change.</returns>
			public bool Deactivate()
			{
				return false;
			}

			public void MoveGrip(PointD2D newPosition)
			{
				if (_moveAction != null)
				{
					_moveAction(newPosition);
				}
				else
				{
					newPosition = _parent.Transformation.InverseTransformPoint(newPosition);
					var diff = GraphObject.ToUnrotatedDifference(_fixaPosition, newPosition);
					GraphObject.SetBoundsFrom(_fixrPosition, _fixaPosition, _drawrPosition, diff,new PointD2D(0,0));
				}
			}


			public void Show(Graphics g)
			{
				g.FillEllipse(Brushes.Blue, 
          (float)(_gripCenter.X - _gripRadius), 
          (float)(_gripCenter.Y - _gripRadius),
          (float)(2 * _gripRadius),
          (float)(2 * _gripRadius)
          );
			}

			public bool IsGripHitted(PointD2D point)
			{
				return (Calc.RMath.Pow2(point.X - _gripCenter.X) + Calc.RMath.Pow2(point.Y - _gripCenter.Y)) < Calc.RMath.Pow2(_gripRadius);
			}

			#endregion
		}

	}
}
