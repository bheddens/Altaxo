#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2004 Dr. Dirk Lellinger
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

namespace Altaxo.Calc
{
	/// <summary>
	/// VectorMath provides common static functions concerning vectors.
	/// </summary>
	public class VectorMath
	{
	
    #region Inner types

    /// <summary>
    /// Serves as Wrapper for an double array to plug-in where a IROVector is neccessary.
    /// </summary>
    private class RODoubleArrayWrapper : IROVector
    {
      protected double[] _x;
      
      /// <summary>
      /// Constructor, takes a double array for wrapping.
      /// </summary>
      /// <param name="x"></param>
      public RODoubleArrayWrapper(double[] x) { _x = x; }

      /// <summary>Gets the value at index i with LowerBound &lt;= i &lt;=UpperBound.</summary>
      /// <value>The element at index i.</value>
      public double this[int i] { get { return _x[i]; }}
 
      /// <summary>The smallest valid index of this vector</summary>
      public int LowerBound { get { return _x.GetLowerBound(0); }}
    
      /// <summary>The greates valid index of this vector. Is by definition LowerBound+Length-1.</summary>
      public int UpperBound { get { return _x.GetUpperBound(0); }}
    
      /// <summary>The number of elements of this vector.</summary>
      public int Length { get { return _x.Length; }}  // change this later to length property
    }

    private class RWDoubleArrayWrapper : RODoubleArrayWrapper, IVector
    {
      public RWDoubleArrayWrapper(double[] x)
        : base(x)
      {
      }

      #region IVector Members

      public new double this[int i]
      {
        get { return _x[i]; }
        set { _x[i] = value; }
      }

      #endregion
    }


    #endregion

    #region Type conversion
    /// <summary>
    /// Wraps a double[] array to get a IROVector.
    /// </summary>
    /// <param name="x">The array to wrap.</param>
    /// <returns>A wrapper objects with the <see>IROVector</see> interface that wraps the provided array.</returns>
    public static IROVector ToROVector(double[] x)
    {
      return new RODoubleArrayWrapper(x);
    }

    /// <summary>
    /// Wraps a double[] array to get a IVector.
    /// </summary>
    /// <param name="x">The array to wrap.</param>
    /// <returns>A wrapper objects with the <see>IVector</see> interface that wraps the provided array.</returns>
    public static IVector ToVector(double[] x)
    {
      return new RWDoubleArrayWrapper(x);
    }
    #endregion

    /// <summary>
    /// Returns the maximum of the elements in xarray.
    /// </summary>
    /// <param name="xarray">The array to search for maximum element.</param>
    /// <returns>Maximum element of xarray. Returns NaN if the array is empty.</returns>
    public static double Max(IROVector xarray)
    {
      double max = xarray.Length==0 ? double.NaN : xarray[xarray.LowerBound];

      int last = xarray.UpperBound;
      for(int i=xarray.LowerBound+1;i<=last;i++)
      {
        max = Math.Max(max,xarray[i]);
      }
      return max;
    }

    /// <summary>
    /// Returns the maximum of the elements in xarray.
    /// </summary>
    /// <param name="xarray">The array to search for maximum element.</param>
    /// <returns>Maximum element of xarray. Returns <see>Double.NaN</see> if the array is empty.</returns>
    public static double Max(double[] xarray)
    {
      double max = xarray.Length==0 ? double.NaN : xarray[xarray.GetLowerBound(0)];

      int last = xarray.GetUpperBound(0);
      for(int i=xarray.GetLowerBound(0)+1;i<=last;i++)
      {
        max = Math.Max(max,xarray[i]);
      }
      return max;
    }

	}
}
