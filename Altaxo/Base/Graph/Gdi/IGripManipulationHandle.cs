#region Copyright
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
using System.Drawing;

namespace Altaxo.Graph.Gdi
{
  /// <summary>
  /// Used to manipulate an object by dragging it's grip area around.
  /// </summary>
  public interface IGripManipulationHandle
  {
		/// <summary>
		/// Activates this grip, providing the initial position of the mouse.
		/// </summary>
		/// <param name="initialPosition">Initial position of the mouse.</param>
		/// <param name="isActivatedUponCreation">If true the activation is called right after creation of this handle. If false,
		/// thie activation is due to a regular mouse click in this grip.</param>
		void Activate(PointD2D initialPosition, bool isActivatedUponCreation);

		/// <summary>
		/// Announces the deactivation of this grip.
		/// </summary>
		/// <returns>True if the nextgrip level should be displayed, otherwise false.</returns>
		bool Deactivate();
		
    /// <summary>
    /// Moves the grip to the new position. 
    /// </summary>
    /// <param name="newPosition"></param>
    void MoveGrip(PointD2D newPosition);

		/// <summary>
		/// Draws the grip in the graphics context.
		/// </summary>
		/// <param name="g">Graphics context.</param>
		void Show(Graphics g);

		/// <summary>
		/// Tests if the grip is hitted.
		/// </summary>
		/// <param name="point">Coordinates of the mouse pointer in unscaled page coordinates (points).</param>
		/// <returns></returns>
		bool IsGripHitted(PointD2D point);
  }
}
