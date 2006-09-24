#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2005 Dr. Dirk Lellinger
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
using System.Drawing.Drawing2D;
using Altaxo.Serialization;
using Altaxo.Graph.Scales;

namespace Altaxo.Graph.Gdi.Axis
{

  /// <remarks>AbstractXYAxisLabelStyle is the abstract base class of all LabelStyles.</remarks>
  public abstract class AxisLabelStyleBase : Main.IChangedEventSource, System.ICloneable
  {
    [field:NonSerialized]
    public event System.EventHandler Changed;

    /// <summary>
    /// Abstract paint function for the AbstractXYAxisLabelStyle.
    /// </summary>
    /// <param name="g">The graphics context.</param>
    /// <param name="layer">The layer the lables belongs to.</param>
    /// <param name="styleInfo">The information which identifies the axis styles.</param>
    /// <param name="axisstyle">The axis style the axis is formatted with.</param>
    /// <param name="useMinorTicks">If true, the minor ticks where used instead of the (default) major ticks.</param>
    public abstract void Paint(Graphics g, XYPlotLayer layer, A2DAxisStyleInformation styleInfo, AxisLineStyle axisstyle, bool useMinorTicks);
 
    #region IChangedEventSource Members



    protected virtual void OnChanged()
    {
      if(null!=Changed)
        Changed(this,new EventArgs());
    }

    #endregion

    /// <summary>
    /// Creates a cloned copy of this object.
    /// </summary>
    /// <returns>The cloned copy of this object.</returns>
    public abstract object Clone();

    public abstract IHitTestObject HitTest(XYPlotLayer layer, PointF pt);

    public abstract float FontSize { get; set; }
    
  }


}