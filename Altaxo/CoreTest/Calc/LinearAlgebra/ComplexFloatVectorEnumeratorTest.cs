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

using Altaxo.Calc;
using Altaxo.Calc.LinearAlgebra;
using NUnit.Framework;
using System;
using System.Collections;

namespace AltaxoTest.Calc.LinearAlgebra
{
  [TestFixture]
  public class ComplexFloatVectorEnumeratorTest
  {
    private const double TOLERENCE = 0.001;

    //Test Current Method
    [Test]
    public void Current()
    {
      ComplexFloatVector test = new ComplexFloatVector(new ComplexFloat[2] { 1f, 2f });
      IEnumerator enumerator = test.GetEnumerator();
      bool movenextresult;

      movenextresult = enumerator.MoveNext();
      Assert.IsTrue(movenextresult);
      Assert.AreEqual(enumerator.Current, test[0]);

      movenextresult = enumerator.MoveNext();
      Assert.IsTrue(movenextresult);
      Assert.AreEqual(enumerator.Current, test[1]);

      movenextresult = enumerator.MoveNext();
      Assert.IsFalse(movenextresult);
    }

    //Test foreach
    [Test]
    public void ForEach()
    {
      ComplexFloatVector test = new ComplexFloatVector(new ComplexFloat[2] { 1f, 2f });
      foreach (ComplexFloat f in test)
        Assert.IsTrue(test.Contains(f));
    }

    //Test Current Exception with index=-1.
    [Test]
    public void CurrentException()
    {
      Assert.Throws(typeof(InvalidOperationException), () =>
      {
        ComplexFloatVector test = new ComplexFloatVector(new ComplexFloat[2] { 1f, 2f });
        IEnumerator enumerator = test.GetEnumerator();
        object value = enumerator.Current;
      });
    }

    //Test Current Exception with index>length
    [Test]
    public void CurrentException2()
    {
      Assert.Throws(typeof(InvalidOperationException), () =>
      {
        ComplexFloatVector test = new ComplexFloatVector(new ComplexFloat[2] { 1f, 2f });
        IEnumerator enumerator = test.GetEnumerator();
        enumerator.MoveNext();
        enumerator.MoveNext();
        enumerator.MoveNext();
        object value = enumerator.Current;
      });
    }
  }
}
