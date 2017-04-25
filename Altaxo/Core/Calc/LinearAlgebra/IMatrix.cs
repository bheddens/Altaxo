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

using System;

namespace Altaxo.Calc.LinearAlgebra
{
  /// <summary>
  /// IROMatrix represents a read-only matrix of values.
  /// </summary>
  public interface IROMatrix<T>
  {
    /// <summary>Gets an element of the matrix at (row, col).</summary>
    T this[int row, int col] { get; }

    /// <summary>The number of rows of the matrix.</summary>
    int Rows { get; }

    /// <summary>The number of columns of the matrix.</summary>
    int Columns { get; }
  }

  /// <summary>
	/// IROMatrix represents a read-only matrix of double values.
	/// </summary>
	public interface IROMatrix : IROMatrix<double>
  {
  }

  /// <summary>
  /// IMatrix represents the simplest form of a 2D matrix, which is readable and writeable.
  /// </summary>
  public interface IMatrix<T> : IROMatrix<T>
  {
    /// <summary>Get / sets an element of the matrix at (row, col).</summary>
    new T this[int row, int col] { get; set; }
  }

  /// <summary>
  /// IMatrix represents the simplest form of a 2D matrix, which is readable and writeable.
  /// </summary>
  public interface IMatrix : IMatrix<double>, IROMatrix
  {
  }

  /// <summary>
  /// IRightExtensibleMatrix extends IMatrix in a way that another matrix of appropriate dimensions
  /// can be appended to the right of the matrix.
  /// </summary>
  public interface IRightExtensibleMatrix<T> : IMatrix<T>
  {
    /// <summary>
    /// Append matrix a to the right edge of this matrix. Matrix a must have the same number of rows than this matrix, except this matrix
    /// is still empty, in which case the right dimension of this matrix is set.
    /// </summary>
    /// <param name="a">The matrix to append.</param>
    void AppendRight(IROMatrix<T> a);
  }

  /// <summary>
  /// IRightExtensibleMatrix extends IMatrix in a way that another matrix of appropriate dimensions
  /// can be appended to the right of the matrix.
  /// </summary>
  public interface IRightExtensibleMatrix : IRightExtensibleMatrix<double>, IMatrix
  {
  }

  /// <summary>
  /// IBottomExtensibleMatrix extends IMatrix in a way that another matrix of appropriate dimensions
  /// can be appended to the bottom of the matrix.
  /// </summary>
  public interface IBottomExtensibleMatrix<T> : IMatrix<T>
  {
    /// <summary>
    /// Append matrix a to the bottom of this matrix. Matrix a must have the same number of columns than this matrix, except this matrix
    /// is still empty, in which case the right dimension of this matrix is set.
    /// </summary>
    /// <param name="a">The matrix to append.</param>
    void AppendBottom(IROMatrix<T> a);
  }

  /// <summary>
  /// IBottomExtensibleMatrix extends IMatrix in a way that another matrix of appropriate dimensions
  /// can be appended to the bottom of the matrix.
  /// </summary>
  public interface IBottomExtensibleMatrix : IBottomExtensibleMatrix<double>, IMatrix
  {
  }

  /// <summary>
  /// IExtensibleMatrix extends IMatrix in a way that another matrix of appropriate dimensions
  /// can be appended either to the right or to the bottom of the matrix.
  /// </summary>
  public interface IExtensibleMatrix<T> : IRightExtensibleMatrix<T>, IBottomExtensibleMatrix<T>
  {
  }

  /// <summary>
  /// IExtensibleMatrix extends IMatrix in a way that another matrix of appropriate dimensions
  /// can be appended either to the right or to the bottom of the matrix.
  /// </summary>
  public interface IExtensibleMatrix : IRightExtensibleMatrix<double>, IBottomExtensibleMatrix<double>, IRightExtensibleMatrix, IBottomExtensibleMatrix
  {
  }
}