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
	/// ArrayMath provides some basic methods for manipulating numeric arrays.
	/// </summary>
	public class ArrayMath
	{

    /// <summary>
    /// Copies an array of <see>Complex</see> elements into an array of the real part values and an array of the imaginary part values.
    /// </summary>
    /// <param name="src">The source array.</param>
    /// <param name="destreal">The array where the real part values are stored into.</param>
    /// <param name="destimag">The destination array where the imaginary part values are stored into.</param>
    /// <param name="n">The number of elements to copy. The copying is done from index 0 to n-1.</param>
    public static void CopyFromComplexToSplittedArrays(Complex[] src, double[] destreal, double[] destimag, int n)
    {
      for(int i=0;i<n;i++)
      {
        destreal[i]=src[i].Re;
        destimag[i]=src[i].Im;
      }
    }

    /// <summary>
    /// Copies two arrays with real and imaginary part values into an array of <see>Complex</see> values.
    /// </summary>
    /// <param name="srcreal">The source array containing the real part values.</param>
    /// <param name="srcimag">The source array containing the imaginary part values.</param>
    /// <param name="dest">The destination array.</param>
    /// <param name="n">The number of elements to copy. The copying is done from index 0 to n-1.</param>
    public static void CopyFromSplittedArraysToComplex(double[] srcreal, double[] srcimag, Complex[] dest, int n)
    {
      for(int i=0;i<n;i++)
      {
        dest[i].Re = srcreal[i];
        dest[i].Im = srcimag[i];
      }
    }

    /// <summary>
    /// Multiplies two splitted complex array and stores the result in a splitted complex array.
    /// </summary>
    /// <param name="src1real">Real part of the first input array. Must be at least of length n.</param>
    /// <param name="src1imag">Imaginary part of the first input array. Must be at least of length n.</param>
    /// <param name="src2real">Real part of the first input array. Must be at least of length n.</param>
    /// <param name="src2imag">Imaginary part of the first input array. Must be at least of length n.</param>
    /// <param name="destreal">Real part of the resulting array. Must be at least of length n.</param>
    /// <param name="destimag">Imaginary part of the resulting array. Must be at least of length n.</param>
    /// <param name="n">Normally, the size of the arrays. The multiplication is done from index 0 to n-1.</param>
    /// <remarks>The resulting array may be identical to one of the input arrays.</remarks>
    public static void MultiplySplittedComplexArrays(
      double[] src1real, double[] src1imag, 
      double[] src2real, double[] src2imag,
      double[] destreal, double[] destimag,
      int n)
    {
      for(int i=0;i<n;i++)
      {
        double real = src1real[i]*src2real[i] - src1imag[i]*src2imag[i];
        double imag = src1real[i]*src2imag[i] + src1imag[i]*src2real[i];
        destreal[i]=real;
        destimag[i]=imag;
      }
    }

    /// <summary>
    /// Multiplies the elements of array arr1 and array arr2 by a factor. 
    /// </summary>
    /// <param name="arr1">The first array.</param>
    /// <param name="arr2">The second array.</param>
    /// <param name="factor">The factor the elements of both arrays are multiplied with.</param>
    /// <param name="n">The multiplication is done from index 0 to n-1.</param>
    public static void NormalizeArrays(double[] arr1, double[] arr2, double factor, int n)
    {
      for(int i=0;i<n;i++)
      {
        arr1[i]*=factor;
        arr2[i]*=factor;
      }
    }
	}
}
