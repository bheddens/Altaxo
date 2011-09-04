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
#endregion

using System;
using Altaxo.Calc;
using Altaxo.Data;
using Altaxo.Collections;

namespace Altaxo.Calc.LinearAlgebra
{

	public static class DataColumnWrapper
	{
		#region Inner classes

		#region ROVector
		/// <summary>
		/// Wraps a <see cref="DataColumn" />s into a read-only vector.
		/// </summary>
		class NumericColumnToROVectorWrapper : IROVector
		{
			Altaxo.Data.INumericColumn _column;
			int _start;
			int _rows;


			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="column">The <see cref="DataColumn" /> to wrap.</param>
			/// <param name="nRows">The number of rows that are part of the vector. (Starting from index 0).</param>
			public NumericColumnToROVectorWrapper(Altaxo.Data.INumericColumn column, int start, int nRows)
			{
				_column = column;
				_start = start;
				_rows = nRows;
			}
			#region IROVector Members

			/// <summary>The number of elements of this vector.</summary>
			public int Length { get { ; return _rows; } }

			/// <summary>
			/// Element accessor.
			/// </summary>
			public double this[int row]
			{
				get
				{
					return _column[row + _start];
				}
			}

			#endregion
		}

		/// <summary>
		/// Wraps a <see cref="DataColumn" />s into a read-only vector for selected rows.
		/// </summary>
		class NumericColumnSelectedRowsToROVectorWrapper : IROVector
		{
			protected Altaxo.Data.INumericColumn _column;
			protected Altaxo.Collections.IAscendingIntegerCollection _rows;


			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="column">The <see cref="DataColumn" /> to wrap.</param>
			/// <param name="selectedRows">The set of rows that are part of the vector. This collection is not cloned here, therefore it must not be subsequently changed!</param>
			public NumericColumnSelectedRowsToROVectorWrapper(Altaxo.Data.INumericColumn column, IAscendingIntegerCollection selectedRows)
			{
				_column = column;
				_rows = selectedRows;
			}
			#region IROVector Members

			/// <summary>The number of elements of this vector.</summary>
			public int Length { get { ; return _rows == null ? 0 : _rows.Count; } }

			/// <summary>
			/// Element accessor.
			/// </summary>
			public double this[int row]
			{
				get
				{
					return _column[_rows[row]];
				}
			}

			#endregion
		}


		#endregion

		#region Vector
		/// <summary>
		/// Wraps a <see cref="DataColumn" />s into a writable vector.
		/// </summary>
		class DoubleColumnToVectorWrapper : IVector
		{
			DoubleColumn _column;
			int _start;
			int _rows;


			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="column">The <see cref="DataColumn" /> to wrap.</param>
			/// <param name="nRows">The number of rows that are part of the vector. (Starting from index 0).</param>
			public DoubleColumnToVectorWrapper(DoubleColumn column, int start, int nRows)
			{
				_column = column;
				_start = start;
				_rows = nRows;
			}
			#region IROVector Members

			/// <summary>The number of elements of this vector.</summary>
			public int Length { get { ; return _rows; } }

			/// <summary>
			/// Element accessor.
			/// </summary>
			public double this[int row]
			{
				get
				{
					return _column[row + _start];
				}
				set
				{
					_column[row + _start] = value;
				}
			}

			#endregion
		}

		/// <summary>
		/// Wraps a <see cref="DataColumn" />s into a writeable vector for selected rows.
		/// </summary>
		class DoubleColumnSelectedRowsToVectorWrapper : IVector
		{
			protected Altaxo.Data.DoubleColumn _column;
			protected Altaxo.Collections.IAscendingIntegerCollection _rows;

			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="column">The <see cref="DataColumn" /> to wrap.</param>
			/// <param name="selectedRows">The set of rows that are part of the vector. This collection is not cloned here, therefore it must not be subsequently changed!</param>
			public DoubleColumnSelectedRowsToVectorWrapper(Altaxo.Data.DoubleColumn column, IAscendingIntegerCollection selectedRows)
			{
				_column = column;
				_rows = selectedRows;
			}
			#region IROVector Members

			/// <summary>The number of elements of this vector.</summary>
			public int Length { get { ; return _rows == null ? 0 : _rows.Count; } }

			/// <summary>
			/// Element accessor.
			/// </summary>
			public double this[int row]
			{
				get
				{
					return _column[_rows[row]];
				}
				set
				{
					_column[_rows[row]] = value;
				}
			}

			#endregion
		}


		/// <summary>
		/// Wraps a <see cref="DataColumn" />s into a writable vector.
		/// </summary>
		class DoubleColumnToComplexDoubleVectorWrapper : IComplexDoubleVector
		{
			DoubleColumn _columnRe;
			DoubleColumn _columnIm;
			int _start;
			int _rows;


			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="column">The <see cref="DataColumn" /> to wrap.</param>
			/// <param name="nRows">The number of rows that are part of the vector. (Starting from index 0).</param>
			public DoubleColumnToComplexDoubleVectorWrapper(DoubleColumn columnRe, DoubleColumn columnIm, int start, int nRows)
			{
				_columnRe = columnRe;
				_columnIm = columnIm;
				_start = start;
				_rows = nRows;
			}
			#region IROVector Members

			/// <summary>The number of elements of this vector.</summary>
			public int Length { get { ; return _rows; } }

			/// <summary>
			/// Element accessor.
			/// </summary>
			public Complex this[int row]
			{
				get
				{
					return new Complex(_columnRe[row + _start], _columnIm[row + _start]);
				}
				set
				{
					_columnRe[row + _start] = value.Re;
					_columnIm[row + _start] = value.Im;
				}
			}

			#endregion
		}

		#endregion

		#region Matrices
		class NumericColumnToROHorzMatrixWrapper : IROMatrix
		{
			Altaxo.Data.INumericColumn _column;
			int _rows;

			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="column">The <see cref="DataColumn" /> to wrap.</param>
			/// <param name="nRows">The number of rows that are part of the vector. (Starting from index 0).</param>
			public NumericColumnToROHorzMatrixWrapper(Altaxo.Data.INumericColumn column, int nRows)
			{
				_column = column;
				_rows = nRows;
			}

			#region IROMatrix Members

			public int Rows
			{
				get
				{

					return 1;
				}
			}

			public double this[int row, int col]
			{
				get
				{
					return _column[col];
				}
			}

			public int Columns
			{
				get
				{

					return _rows;
				}
			}

			#endregion

		}

		class NumericColumnToROVertMatrixWrapper : IROMatrix
		{
			Altaxo.Data.INumericColumn _column;
			int _rows;

			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="column">The <see cref="DataColumn" /> to wrap.</param>
			/// <param name="nRows">The number of rows that are part of the vector. (Starting from index 0).</param>
			public NumericColumnToROVertMatrixWrapper(Altaxo.Data.INumericColumn column, int nRows)
			{
				_column = column;
				_rows = nRows;
			}

			#region IROMatrix Members

			public int Rows
			{
				get
				{

					return _rows;
				}
			}

			public double this[int row, int col]
			{
				get
				{
					return _column[row];
				}
			}

			public int Columns
			{
				get
				{

					return 1;
				}
			}

			#endregion

		}

		class DoubleColumnToHorzMatrixWrapper : IMatrix
		{
			Altaxo.Data.DoubleColumn _column;
			int _rows;

			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="column">The <see cref="DataColumn" /> to wrap.</param>
			/// <param name="nRows">The number of rows that are part of the vector. (Starting from index 0).</param>
			public DoubleColumnToHorzMatrixWrapper(Altaxo.Data.DoubleColumn column, int nRows)
			{
				_column = column;
				_rows = nRows;
			}

			#region IROMatrix Members

			public int Rows
			{
				get
				{

					return 1;
				}
			}

			public double this[int row, int col]
			{
				get
				{
					return _column[col];
				}
			}

			public int Columns
			{
				get
				{

					return _rows;
				}
			}

			#endregion

			#region IMatrix Members

			double Altaxo.Calc.LinearAlgebra.IMatrix.this[int row, int col]
			{
				get
				{
					return _column[col];
				}
				set
				{
					_column[col] = value;
				}
			}

			#endregion
		}

		class DoubleColumnToVertMatrixWrapper : IMatrix
		{
			Altaxo.Data.DoubleColumn _column;
			int _rows;

			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="column">The <see cref="DataColumn" /> to wrap.</param>
			/// <param name="nRows">The number of rows that are part of the vector. (Starting from index 0).</param>
			public DoubleColumnToVertMatrixWrapper(Altaxo.Data.DoubleColumn column, int nRows)
			{
				_column = column;
				_rows = nRows;
			}

			#region IROMatrix Members

			public int Rows
			{
				get
				{

					return _rows;
				}
			}

			public double this[int row, int col]
			{
				get
				{
					return _column[row];
				}
			}

			public int Columns
			{
				get
				{

					return 1;
				}
			}

			#endregion

			#region IMatrix Members

			double Altaxo.Calc.LinearAlgebra.IMatrix.this[int row, int col]
			{
				get
				{
					return _column[row];
				}
				set
				{
					_column[row] = value;
				}
			}

			#endregion
		}

		#endregion

		#endregion

		#region Wrapper for INumericColumn

		/// <summary>
		/// This returns a read-only vector of a <see cref="INumericColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <param name="nRows">The number of rows to use for the vector.</param>
		/// <returns>An IVector wrapping the <see cref="INumericColumn" />.</returns>
		public static IROVector ToROVector(this INumericColumn col, int nRows)
		{
			return new NumericColumnToROVectorWrapper(col, 0, nRows);
		}
		/// <summary>
		/// This returns a read-only vector of a <see cref="INumericColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <param name="nStart">The starting index of the wrapped column.</param>
		/// <param name="nRows">The number of rows to use for the vector.</param>
		/// <returns>An IVector wrapping the <see cref="INumericColumn" />.</returns>
		public static IROVector ToROVector(this INumericColumn col, int nStart, int nRows)
		{
			return new NumericColumnToROVectorWrapper(col, nStart, nRows);
		}

		#region ToMatrices


		/// <summary>
		/// This returns a horizontal oriented, readonly matrix of a <see cref="DoubleColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <param name="nRows">The number of rows to use for the vector.</param>
		/// <returns>An horizontal oriented <see cref="IROMatrix" /> wrapping the <see cref="DoubleColumn" />.</returns>
		public static IROMatrix ToHorzROMatrix(this INumericColumn col, int nRows)
		{
			return new NumericColumnToROHorzMatrixWrapper((INumericColumn)col, nRows);
		}

		/// <summary>
		/// This returns a vertical oriented, readonly matrix of a <see cref="DoubleColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <param name="nRows">The number of rows to use for the vector.</param>
		/// <returns>An vertical oriented <see cref="IROMatrix" /> wrapping the <see cref="DoubleColumn" />.</returns>
		public static IROMatrix ToVertROMatrix(this INumericColumn col, int nRows)
		{
			return new NumericColumnToROVertMatrixWrapper((INumericColumn)col, nRows);
		}


		#endregion

		#endregion

		#region Wrapper for DataColumn

		#region ToRoVector

		/// <summary>
		/// This returns a read-only vector of a <see cref="INumericColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <param name="nStart">The starting index of the wrapped column.</param>
		/// <param name="nRows">The number of rows to use for the vector.</param>
		/// <returns>An IVector wrapping the <see cref="INumericColumn" />.</returns>
		public static IROVector ToROVector(this DataColumn col, int nStart, int nRows)
		{
			if (!(col is INumericColumn))
				throw new ArgumentException("Argument col can not be wrapped to a vector because it is not a numeric column");

			return new NumericColumnToROVectorWrapper((INumericColumn)col, nStart, nRows);
		}


		/// <summary>
		/// This returns a read-only vector of a <see cref="INumericColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <param name="nRows">The number of rows to use for the vector.</param>
		/// <returns>An IVector wrapping the <see cref="INumericColumn" />.</returns>
		public static IROVector ToROVector(this DataColumn col, int nRows)
		{
			if (!(col is INumericColumn))
				throw new ArgumentException("Argument col can not be wrapped to a vector because it is not a numeric column");

			return new NumericColumnToROVectorWrapper((INumericColumn)col, 0, nRows);
		}

		/// <summary>
		/// This returns a read-only vector of a <see cref="INumericColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <returns>An IVector wrapping the <see cref="INumericColumn" />.</returns>
		public static IROVector ToROVector(this DataColumn col)
		{
			if (!(col is INumericColumn))
				throw new ArgumentException(string.Format("Argument col (name: {0}) can not be wrapped to a vector because it is not a numeric column", col.Name));

			return new NumericColumnToROVectorWrapper((INumericColumn)col, 0, col.Count);
		}

		/// <summary>
		/// This returns a read-only vector of a <see cref="INumericColumn" /> for selected rows.
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <param name="selectedRows">The rows of the source column that are part of the vector.</param>
		/// <returns>An IROVector wrapping the <see cref="INumericColumn" />.</returns>
		public static IROVector ToROVector(this INumericColumn col, IAscendingIntegerCollection selectedRows)
		{
			return new NumericColumnSelectedRowsToROVectorWrapper(col, (IAscendingIntegerCollection)selectedRows.Clone());
		}


		/// <summary>
		/// This returns a read-only vector of a <see cref="INumericColumn" />, but the data are copyied before. Thus, if you change the data
		/// into the numeric column, the data of the returned vector is not influenced.
		/// </summary>
		/// <param name="col">The column to wrap.</param>
		/// <returns>A read-only vector which contains data copied from the numeric column.</returns>
		public static IROVector ToROVectorCopy(this DataColumn col)
		{
			if (!(col is INumericColumn))
				throw new ArgumentException("Argument col can not be wrapped to a vector because it is not a numeric column");

			INumericColumn ncol = col as INumericColumn;

			double[] vec = new double[col.Count];
			for (int i = col.Count - 1; i >= 0; i--)
				vec[i] = ncol[i];

			return VectorMath.ToROVector(vec);
		}
		#endregion

		#region ToVector
		/// <summary>
		/// This returns a read and writeable vector of a <see cref="DoubleColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <param name="nStart">The starting index of the wrapped column.</param>
		/// <param name="nRows">The number of rows to use for the vector.</param>
		/// <returns>An IVector wrapping the <see cref="DoubleColumn" />.</returns>
		public static IVector ToVector(this DataColumn col, int nStart, int nRows)
		{
			if (!(col is DoubleColumn))
				throw new ArgumentException("Argument col can not be wrapped to a vector because it is not a DoubleColumn");

			return new DoubleColumnToVectorWrapper((DoubleColumn)col, nStart, nRows);
		}


		/// <summary>
		/// This returns a read and writeable vector of a <see cref="DoubleColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <param name="nRows">The number of rows to use for the vector.</param>
		/// <returns>An IVector wrapping the <see cref="DoubleColumn" />.</returns>
		public static IVector ToVector(this DataColumn col, int nRows)
		{
			if (!(col is DoubleColumn))
				throw new ArgumentException("Argument col can not be wrapped to a vector because it is not a DoubleColumn");

			return new DoubleColumnToVectorWrapper((DoubleColumn)col, 0, nRows);
		}

		/// <summary>
		/// This returns a read and writeable vector of a <see cref="DoubleColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <returns>An IVector wrapping the <see cref="DoubleColumn" />.</returns>
		public static IVector ToVector(this DataColumn col)
		{
			if (!(col is DoubleColumn))
				throw new ArgumentException("Argument col can not be wrapped to a vector because it is not a DoubleColumn");

			return new DoubleColumnToVectorWrapper((DoubleColumn)col, 0, col.Count);
		}

		#endregion

		#region ToMatrices

		/// <summary>
		/// This returns a read and writeable, horizontal oriented matrix of a <see cref="DoubleColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <param name="nRows">The number of rows to use for the vector.</param>
		/// <returns>An horizontal oriented <see cref="IMatrix" /> wrapping the <see cref="DoubleColumn" />.</returns>
		public static IMatrix ToHorzMatrix(this DataColumn col, int nRows)
		{
			if (!(col is DoubleColumn))
				throw new ArgumentException("Argument col can not be wrapped to a IMatrix because it is not a DoubleColumn");

			return new DoubleColumnToHorzMatrixWrapper((DoubleColumn)col, nRows);
		}

		/// <summary>
		/// This returns a read and writeable, vertical oriented matrix of a <see cref="DoubleColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <param name="nRows">The number of rows to use for the vector.</param>
		/// <returns>An vertical oriented <see cref="IMatrix" /> wrapping the <see cref="DoubleColumn" />.</returns>
		public static IMatrix ToVertMatrix(this DataColumn col, int nRows)
		{
			if (!(col is DoubleColumn))
				throw new ArgumentException("Argument col can not be wrapped to a IMatrix because it is not a DoubleColumn");

			return new DoubleColumnToVertMatrixWrapper((DoubleColumn)col, nRows);
		}

		#endregion

		#endregion

		#region Wrapper for DoubleColumn

		#region ToVector
		/// <summary>
		/// This returns a read and writeable vector of a <see cref="DoubleColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <returns>An IVector wrapping the <see cref="DoubleColumn" />.</returns>
		public static IVector ToVector(this DoubleColumn col)
		{
			return new DoubleColumnToVectorWrapper(col, 0, col.Count);
		}

		/// <summary>
		/// This returns a read and writeable vector of a <see cref="DoubleColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <param name="nRows">The number of rows to use for the vector.</param>
		/// <returns>An IVector wrapping the <see cref="DoubleColumn" />.</returns>
		public static IVector ToVector(this DoubleColumn col, int nRows)
		{
			return new DoubleColumnToVectorWrapper(col, 0, nRows);
		}

		/// <summary>
		/// This returns a read and writeable vector of a <see cref="DoubleColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <param name="nStart">The starting index of the wrapped column.</param>
		/// <param name="nRows">The number of rows to use for the vector.</param>
		/// <returns>An IVector wrapping the <see cref="DoubleColumn" />.</returns>
		public static IVector ToVector(this DoubleColumn col, int nStart, int nRows)
		{
			return new DoubleColumnToVectorWrapper(col, nStart, nRows);
		}

		/// <summary>
		/// This returns a read and writeable vector of a <see cref="DoubleColumn" />
		/// </summary>
		/// <param name="col">The column to wrap as a IVector.</param>
		/// <param name="selectedRows">The indices of the rows to use for the vector.</param>
		/// <returns>An IVector wrapping the <see cref="DoubleColumn" />.</returns>
		public static IVector ToVector(this DoubleColumn col, IAscendingIntegerCollection selectedRows)
		{
			return new DoubleColumnSelectedRowsToVectorWrapper(col, (IAscendingIntegerCollection)selectedRows.Clone());
		}


		/// <summary>
		/// This returns a read and writeable complex vector that wraps two <see cref="DoubleColumn" />s.
		/// </summary>
		/// <param name="columnRe">The column that represents the real part of the vector.</param>
		/// <param name="columnIm">The column that represents the imaginary part of the vector.</param>
		/// <returns>An <see cref="IDoubleComplexVector"/>  wrapping the <see cref="DoubleColumn" />s.</returns>
		public static IComplexDoubleVector ToComplexDoubleVector(this DoubleColumn columnRe, DoubleColumn columnIm)
		{
			if (columnIm.Count != columnRe.Count)
				throw new ArgumentException("The provided columns have different length. Thus the resulting vector length is undetermined.");

			return new DoubleColumnToComplexDoubleVectorWrapper(columnRe, columnIm, 0, columnRe.Count);
		}

		/// <summary>
		/// This returns a read and writeable complex vector that wraps two <see cref="DoubleColumn" />s.
		/// </summary>
		/// <param name="columnRe">The column that represents the real part of the vector.</param>
		/// <param name="columnIm">The column that represents the imaginary part of the vector.</param>
		/// <param name="nRows">The number of rows to use for the vector.</param>
		/// <returns>An <see cref="IDoubleComplexVector"/>  wrapping the <see cref="DoubleColumn" />s.</returns>
		public static IComplexDoubleVector ToComplexDoubleVector(this DoubleColumn columnRe, DoubleColumn columnIm, int nRows)
		{
			return new DoubleColumnToComplexDoubleVectorWrapper(columnRe, columnIm, 0, nRows);
		}

		/// <summary>
		/// This returns a read and writeable complex vector that wraps two <see cref="DoubleColumn" />s.
		/// </summary>
		/// <param name="columnRe">The column that represents the real part of the vector.</param>
		/// <param name="columnIm">The column that represents the imaginary part of the vector.</param>
		/// <param name="nStart">The starting index of the wrapped column.</param>
		/// <param name="nRows">The number of rows to use for the vector.</param>
		/// <returns>An <see cref="IDoubleComplexVector"/>  wrapping the <see cref="DoubleColumn" />s.</returns>
		public static IComplexDoubleVector ToComplexDoubleVector(this DoubleColumn columnRe, DoubleColumn columnIm, int nStart, int nRows)
		{
			return new DoubleColumnToComplexDoubleVectorWrapper(columnRe, columnIm, nStart, nRows);
		}

		#endregion
		#endregion




	}

}
