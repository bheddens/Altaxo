/*
 * ComplexDoubleMatrixEnumerator.cs
 * 
 * Copyright (c) 2004, dnAnalytics Project. All rights reserved.
*/

using System;
using System.Collections;

namespace Altaxo.Calc.LinearAlgebra {
	///<summary>
	/// Defines an Enumerator for the ComplexDoubleMatrix that supports 
	/// simple iteration over each vector component.
	///</summary>
  /// <remarks>
  /// <para>Copyright (c) 2003-2004, dnAnalytics Project. All rights reserved. See <a>http://www.dnAnalytics.net</a> for details.</para>
  /// <para>Adopted to Altaxo (c) 2005 Dr. Dirk Lellinger.</para>
  /// </remarks>
	
	sealed internal class ComplexDoubleMatrixEnumerator: IEnumerator 
  {
		private ComplexDoubleMatrix m;
		private int index;
		private int length;

		///<summary> Constructor </summary>
		public ComplexDoubleMatrixEnumerator (ComplexDoubleMatrix matrix) {
			m=matrix;
			index=-1;
			length=m.RowLength*m.ColumnLength;
		}
		
		///<summary> Return the current <c>ComplexDoubleMatrix</c> component</summary>
		public Complex Current {
			get {
				if (index<0 || index>=length)
					throw new InvalidOperationException();
				return m[index % m.RowLength, index / m.RowLength];
			}
		}
		object IEnumerator.Current {
			get { return Current; }
		}
		
		///<summary> Move the index to the next component </summary>
		public bool MoveNext() {
			if (length!=m.RowLength*m.ColumnLength)
				throw new InvalidOperationException();
			index ++;
			if (index>=length)
			{
				index=length;
				return false;
			}
			else
			{
				return true;
			}
		}
		
		///<summary> Set the enumerator to it initial position </summary>
		public void Reset() {
			index=-1;
		}
	}
}