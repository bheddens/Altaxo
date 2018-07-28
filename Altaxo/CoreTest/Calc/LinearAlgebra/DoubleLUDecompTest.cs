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

using Altaxo.Calc.LinearAlgebra;
using NUnit.Framework;
using System;

namespace AltaxoTest.Calc.LinearAlgebra
{
  [TestFixture]
  public class DoubleLUDecompTest
  {
    private static DoubleLUDecomp lu;
    private const double TOLERENCE = 0.001;

    static DoubleLUDecompTest()
    {
      DoubleMatrix a = new DoubleMatrix(3);
      a[0, 0] = -1;
      a[0, 1] = 5;
      a[0, 2] = 6;
      a[1, 0] = 3;
      a[1, 1] = -6;
      a[1, 2] = 1;
      a[2, 0] = 6;
      a[2, 1] = 8;
      a[2, 2] = 9;
      lu = new DoubleLUDecomp(a);
    }

    [Test]
    public void LUWide()
    {
      Assert.Throws(typeof(NotSquareMatrixException), () =>
      {
        DoubleMatrix wm = new DoubleMatrix(2, 3);
        DoubleLUDecomp wlu = new DoubleLUDecomp(wm);
      });
    }

    [Test]
    public void LULong()
    {
      Assert.Throws(typeof(NotSquareMatrixException), () =>
      {
        DoubleMatrix lm = new DoubleMatrix(3, 2);
        DoubleLUDecomp llu = new DoubleLUDecomp(lm);
      });
    }

    [Test]
    public void LTest()
    {
      Assert.AreEqual(lu.L[0, 0], 1.000, TOLERENCE);
      Assert.AreEqual(lu.L[0, 1], 0.000, TOLERENCE);
      Assert.AreEqual(lu.L[0, 2], 0.000, TOLERENCE);
      Assert.AreEqual(lu.L[1, 0], .500, TOLERENCE);
      Assert.AreEqual(lu.L[1, 1], 1.000, TOLERENCE);
      Assert.AreEqual(lu.L[1, 2], 0.000, TOLERENCE);
      Assert.AreEqual(lu.L[2, 0], -.167, TOLERENCE);
      Assert.AreEqual(lu.L[2, 1], -.633, TOLERENCE);
      Assert.AreEqual(lu.L[2, 2], 1.000, TOLERENCE);
    }

    [Test]
    public void UTest()
    {
      Assert.AreEqual(lu.U[0, 0], 6.000, TOLERENCE);
      Assert.AreEqual(lu.U[0, 1], 8.000, TOLERENCE);
      Assert.AreEqual(lu.U[0, 2], 9.000, TOLERENCE);
      Assert.AreEqual(lu.U[1, 0], 0.000, TOLERENCE);
      Assert.AreEqual(lu.U[1, 1], -10.000, TOLERENCE);
      Assert.AreEqual(lu.U[1, 2], -3.500, TOLERENCE);
      Assert.AreEqual(lu.U[2, 0], 0.000, TOLERENCE);
      Assert.AreEqual(lu.U[2, 1], 0.000, TOLERENCE);
      Assert.AreEqual(lu.U[2, 2], 5.283, TOLERENCE);
    }

    [Test]
    public void GetDeterminantTest()
    {
      double det = lu.GetDeterminant();
      Assert.AreEqual(det, 317.000, TOLERENCE);
    }

    [Test]
    public void IsSingularTest()
    {
      Assert.IsFalse(lu.IsSingular);
      DoubleMatrix b = new DoubleMatrix(3);
      DoubleLUDecomp dlu = new DoubleLUDecomp(b);
      Assert.IsTrue(dlu.IsSingular);
    }

    [Test]
    public void GetInverseTest()
    {
      DoubleMatrix inv = lu.GetInverse();
      Assert.AreEqual(inv[0, 0], -0.195584, TOLERENCE);
      Assert.AreEqual(inv[0, 1], 0.009464, TOLERENCE);
      Assert.AreEqual(inv[0, 2], 0.129338, TOLERENCE);
      Assert.AreEqual(inv[1, 0], -0.066246, TOLERENCE);
      Assert.AreEqual(inv[1, 1], -0.141956, TOLERENCE);
      Assert.AreEqual(inv[1, 2], 0.059937, TOLERENCE);
      Assert.AreEqual(inv[2, 0], 0.189274, TOLERENCE);
      Assert.AreEqual(inv[2, 1], 0.119874, TOLERENCE);
      Assert.AreEqual(inv[2, 2], -0.028391, TOLERENCE);
    }

    [Test]
    public void GetInverseSingularTest()
    {
      Assert.Throws(typeof(SingularMatrixException), () =>
      {
        DoubleMatrix a = new DoubleMatrix(3, 3);
        DoubleLUDecomp dlu = new DoubleLUDecomp(a);
        dlu.GetInverse();
      });
    }

    [Test]
    public void SolveMatrix()
    {
      DoubleMatrix b = new DoubleMatrix(3);
      b[0, 0] = 2;
      b[0, 1] = 2;
      b[0, 2] = 2;
      b[1, 0] = 13;
      b[1, 1] = 13;
      b[1, 2] = 13;
      b[2, 0] = 25;
      b[2, 1] = 25;
      b[2, 2] = 25;
      DoubleMatrix x = lu.Solve(b);
      Assert.AreEqual(x[0, 0], 2.965, TOLERENCE);
      Assert.AreEqual(x[0, 1], 2.965, TOLERENCE);
      Assert.AreEqual(x[0, 2], 2.965, TOLERENCE);
      Assert.AreEqual(x[1, 0], -0.479, TOLERENCE);
      Assert.AreEqual(x[1, 1], -0.479, TOLERENCE);
      Assert.AreEqual(x[1, 2], -0.479, TOLERENCE);
      Assert.AreEqual(x[2, 0], 1.227, TOLERENCE);
      Assert.AreEqual(x[2, 1], 1.227, TOLERENCE);
      Assert.AreEqual(x[2, 2], 1.227, TOLERENCE);

      b = new DoubleMatrix(3, 2);
      b[0, 0] = 2;
      b[0, 1] = 2;
      b[1, 0] = 13;
      b[1, 1] = 13;
      b[2, 0] = 25;
      b[2, 1] = 25;
      x = lu.Solve(b);
      Assert.AreEqual(x[0, 0], 2.965, TOLERENCE);
      Assert.AreEqual(x[0, 1], 2.965, TOLERENCE);
      Assert.AreEqual(x[1, 0], -0.479, TOLERENCE);
      Assert.AreEqual(x[1, 1], -0.479, TOLERENCE);
      Assert.AreEqual(x[2, 0], 1.227, TOLERENCE);
      Assert.AreEqual(x[2, 1], 1.227, TOLERENCE);

      b = new DoubleMatrix(3, 4);
      b[0, 0] = 2;
      b[0, 1] = 2;
      b[0, 2] = 2;
      b[0, 3] = 2;
      b[1, 0] = 13;
      b[1, 1] = 13;
      b[1, 2] = 13;
      b[1, 3] = 13;
      b[2, 0] = 25;
      b[2, 1] = 25;
      b[2, 2] = 25;
      b[2, 3] = 25;
      x = lu.Solve(b);
      Assert.AreEqual(x[0, 0], 2.965, TOLERENCE);
      Assert.AreEqual(x[0, 1], 2.965, TOLERENCE);
      Assert.AreEqual(x[0, 2], 2.965, TOLERENCE);
      Assert.AreEqual(x[0, 3], 2.965, TOLERENCE);
      Assert.AreEqual(x[1, 0], -0.479, TOLERENCE);
      Assert.AreEqual(x[1, 1], -0.479, TOLERENCE);
      Assert.AreEqual(x[1, 2], -0.479, TOLERENCE);
      Assert.AreEqual(x[1, 3], -0.479, TOLERENCE);
      Assert.AreEqual(x[2, 0], 1.227, TOLERENCE);
      Assert.AreEqual(x[2, 1], 1.227, TOLERENCE);
      Assert.AreEqual(x[2, 2], 1.227, TOLERENCE);
      Assert.AreEqual(x[2, 3], 1.227, TOLERENCE);
    }

    [Test]
    public void SolveVector()
    {
      DoubleVector b = new DoubleVector(3);
      b[0] = 2;
      b[1] = 13;
      b[2] = 25;
      DoubleVector x = lu.Solve(b);
      Assert.AreEqual(x[0], 2.965, TOLERENCE);
      Assert.AreEqual(x[1], -0.479, TOLERENCE);
      Assert.AreEqual(x[2], 1.227, TOLERENCE);
    }
  }
}
