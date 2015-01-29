#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2011 Dr. Dirk Lellinger
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

/*
 * BSD Licence:
 * Copyright (c) 2001, 2002 Ben Houston [ ben@exocortex.org ]
 * Exocortex Technologies [ www.exocortex.org ]
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice,
 * this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 * notice, this list of conditions and the following disclaimer in the
 * documentation and/or other materials provided with the distribution.
 * 3. Neither the name of the <ORGANIZATION> nor the names of its contributors
 * may be used to endorse or promote products derived from this software
 * without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE REGENTS OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
 * LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY
 * OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH
 * DAMAGE.
 */

using System;
using System.Diagnostics;

namespace Altaxo.Calc
{
	// Comments? Questions? Bugs? Tell Ben Houston at ben@exocortex.org
	// Version: May 4, 2002

	/// <summary>
	/// <p>A set of statistical utilities for complex number arrays</p>
	/// </summary>
	public class ComplexStats
	{
		//---------------------------------------------------------------------------------------------

		private ComplexStats()
		{
		}

		//---------------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------------

		/// <summary>
		/// Calculate the sum
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		static public ComplexFloat Sum(ComplexFloat[] data)
		{
			Debug.Assert(data != null);
			return SumRecursion(data, 0, data.Length);
		}

		static private ComplexFloat SumRecursion(ComplexFloat[] data, int start, int end)
		{
			Debug.Assert(0 <= start, "start = " + start);
			Debug.Assert(start < end, "start = " + start + " and end = " + end);
			Debug.Assert(end <= data.Length, "end = " + end + " and data.Length = " + data.Length);
			if ((end - start) <= 1000)
			{
				ComplexFloat sum = ComplexFloat.Zero;
				for (int i = start; i < end; i++)
				{
					sum += data[i];
				}
				return sum;
			}
			else
			{
				int middle = (start + end) >> 1;
				return SumRecursion(data, start, middle) + SumRecursion(data, middle, end);
			}
		}

		/// <summary>
		/// Calculate the sum
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		static public Complex Sum(Complex[] data)
		{
			Debug.Assert(data != null);
			return SumRecursion(data, 0, data.Length);
		}

		static private Complex SumRecursion(Complex[] data, int start, int end)
		{
			Debug.Assert(0 <= start, "start = " + start);
			Debug.Assert(start < end, "start = " + start + " and end = " + end);
			Debug.Assert(end <= data.Length, "end = " + end + " and data.Length = " + data.Length);
			if ((end - start) <= 1000)
			{
				Complex sum = Complex.Zero;
				for (int i = start; i < end; i++)
				{
					sum += data[i];
				}
				return sum;
			}
			else
			{
				int middle = (start + end) >> 1;
				return SumRecursion(data, start, middle) + SumRecursion(data, middle, end);
			}
		}

		//--------------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------------

		/// <summary>
		/// Calculate the sum of squares
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		static public ComplexFloat SumOfSquares(ComplexFloat[] data)
		{
			Debug.Assert(data != null);
			return SumOfSquaresRecursion(data, 0, data.Length);
		}

		static private ComplexFloat SumOfSquaresRecursion(ComplexFloat[] data, int start, int end)
		{
			Debug.Assert(0 <= start, "start = " + start);
			Debug.Assert(start < end, "start = " + start + " and end = " + end);
			Debug.Assert(end <= data.Length, "end = " + end + " and data.Length = " + data.Length);
			if ((end - start) <= 1000)
			{
				ComplexFloat sumOfSquares = ComplexFloat.Zero;
				for (int i = start; i < end; i++)
				{
					sumOfSquares += data[i] * data[i];
				}
				return sumOfSquares;
			}
			else
			{
				int middle = (start + end) >> 1;
				return SumOfSquaresRecursion(data, start, middle) + SumOfSquaresRecursion(data, middle, end);
			}
		}

		/// <summary>
		/// Calculate the sum of squares
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		static public Complex SumOfSquares(Complex[] data)
		{
			Debug.Assert(data != null);
			return SumOfSquaresRecursion(data, 0, data.Length);
		}

		static private Complex SumOfSquaresRecursion(Complex[] data, int start, int end)
		{
			Debug.Assert(0 <= start, "start = " + start);
			Debug.Assert(start < end, "start = " + start + " and end = " + end);
			Debug.Assert(end <= data.Length, "end = " + end + " and data.Length = " + data.Length);
			if ((end - start) <= 1000)
			{
				Complex sumOfSquares = Complex.Zero;
				for (int i = start; i < end; i++)
				{
					sumOfSquares += data[i] * data[i];
				}
				return sumOfSquares;
			}
			else
			{
				int middle = (start + end) >> 1;
				return SumOfSquaresRecursion(data, start, middle) + SumOfSquaresRecursion(data, middle, end);
			}
		}

		//--------------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------------

		/// <summary>
		/// Calculate the mean (average)
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		static public ComplexFloat Mean(ComplexFloat[] data)
		{
			return ComplexStats.Sum(data) / data.Length;
		}

		/// <summary>
		/// Calculate the mean (average)
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		static public Complex Mean(Complex[] data)
		{
			return ComplexStats.Sum(data) / data.Length;
		}

		/// <summary>
		/// Calculate the variance
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		static public ComplexFloat Variance(ComplexFloat[] data)
		{
			Debug.Assert(data != null);
			if (data.Length == 0)
			{
				throw new DivideByZeroException("length of data is zero");
			}
			return ComplexStats.SumOfSquares(data) / data.Length - ComplexStats.Sum(data);
		}

		/// <summary>
		/// Calculate the variance
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		static public Complex Variance(Complex[] data)
		{
			Debug.Assert(data != null);
			if (data.Length == 0)
			{
				throw new DivideByZeroException("length of data is zero");
			}
			return ComplexStats.SumOfSquares(data) / data.Length - ComplexStats.Sum(data);
		}

		/// <summary>
		/// Calculate the standard deviation
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		static public ComplexFloat StdDev(ComplexFloat[] data)
		{
			Debug.Assert(data != null);
			if (data.Length == 0)
			{
				throw new DivideByZeroException("length of data is zero");
			}
			return ComplexMath.Sqrt(ComplexStats.Variance(data));
		}

		/// <summary>
		/// Calculate the standard deviation
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		static public Complex StdDev(Complex[] data)
		{
			Debug.Assert(data != null);
			if (data.Length == 0)
			{
				throw new DivideByZeroException("length of data is zero");
			}
			return ComplexMath.Sqrt(ComplexStats.Variance(data));
		}

		//--------------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------------

		/// <summary>
		/// Calculate the root mean squared (RMS) error between two sets of data.
		/// </summary>
		/// <param name="alpha"></param>
		/// <param name="beta"></param>
		/// <returns></returns>
		static public float RMSError(ComplexFloat[] alpha, ComplexFloat[] beta)
		{
			Debug.Assert(alpha != null);
			Debug.Assert(beta != null);
			Debug.Assert(beta.Length == alpha.Length);

			return (float)Math.Sqrt(SumOfSquaredErrorRecursion(alpha, beta, 0, alpha.Length));
		}

		static private float SumOfSquaredErrorRecursion(ComplexFloat[] alpha, ComplexFloat[] beta, int start, int end)
		{
			Debug.Assert(0 <= start, "start = " + start);
			Debug.Assert(start < end, "start = " + start + " and end = " + end);
			Debug.Assert(end <= alpha.Length, "end = " + end + " and alpha.Length = " + alpha.Length);
			Debug.Assert(beta.Length == alpha.Length);
			if ((end - start) <= 1000)
			{
				float sumOfSquaredError = 0;
				for (int i = start; i < end; i++)
				{
					ComplexFloat delta = beta[i] - alpha[i];
					sumOfSquaredError += (delta.Re * delta.Re) + (delta.Im * delta.Im);
				}
				return sumOfSquaredError;
			}
			else
			{
				int middle = (start + end) >> 1;
				return SumOfSquaredErrorRecursion(alpha, beta, start, middle) + SumOfSquaredErrorRecursion(alpha, beta, middle, end);
			}
		}

		/// <summary>
		/// Calculate the root mean squared (RMS) error between two sets of data.
		/// </summary>
		/// <param name="alpha"></param>
		/// <param name="beta"></param>
		/// <returns></returns>
		static public double RMSError(Complex[] alpha, Complex[] beta)
		{
			Debug.Assert(alpha != null);
			Debug.Assert(beta != null);
			Debug.Assert(beta.Length == alpha.Length);

			return Math.Sqrt(SumOfSquaredErrorRecursion(alpha, beta, 0, alpha.Length));
		}

		static private double SumOfSquaredErrorRecursion(Complex[] alpha, Complex[] beta, int start, int end)
		{
			Debug.Assert(0 <= start, "start = " + start);
			Debug.Assert(start < end, "start = " + start + " and end = " + end);
			Debug.Assert(end <= alpha.Length, "end = " + end + " and alpha.Length = " + alpha.Length);
			Debug.Assert(beta.Length == alpha.Length);
			if ((end - start) <= 1000)
			{
				double sumOfSquaredError = 0;
				for (int i = start; i < end; i++)
				{
					Complex delta = beta[i] - alpha[i];
					sumOfSquaredError += (delta.Re * delta.Re) + (delta.Im * delta.Im);
				}
				return sumOfSquaredError;
			}
			else
			{
				int middle = (start + end) >> 1;
				return SumOfSquaredErrorRecursion(alpha, beta, start, middle) + SumOfSquaredErrorRecursion(alpha, beta, middle, end);
			}
		}
	}
}