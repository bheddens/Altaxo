using System;
using System.Collections;
using NUnit.Framework;
using Altaxo.Calc.LinearAlgebra;

namespace AltaxoTest.Calc.LinearAlgebra {
	[TestFixture]
	public class DoubleMatrixEnumeratorTest{
		private const double TOLERENCE = 0.001;

		//Test Current Method
		[Test]
		public void Current(){
			DoubleMatrix test = new DoubleMatrix(new double[2,2]{{1,2},{3,4}});
			IEnumerator enumerator = test.GetEnumerator();
			bool movenextresult;
			
			movenextresult=enumerator.MoveNext();
			Assert.IsTrue(movenextresult);
			Assert.AreEqual(enumerator.Current,test[0,0]);
			
			movenextresult=enumerator.MoveNext();
			Assert.IsTrue(movenextresult);
			Assert.AreEqual(enumerator.Current,test[1,0]);
			
			movenextresult=enumerator.MoveNext();
			Assert.IsTrue(movenextresult);
			Assert.AreEqual(enumerator.Current,test[0,1]);
			
			movenextresult=enumerator.MoveNext();
			Assert.IsTrue(movenextresult);
			Assert.AreEqual(enumerator.Current,test[1,1]);
			
			movenextresult=enumerator.MoveNext();
			Assert.IsFalse(movenextresult);
		}
		
		//Test foreach
		[Test]
		public void ForEach(){
			DoubleMatrix test = new DoubleMatrix(new double[2,2]{{1,2},{3,4}});
			foreach (double f in test) 
				Assert.IsTrue(test.Contains(f));
		}
		
		//Test Current Exception with index=-1.
		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void CurrentException() {
			DoubleMatrix test = new DoubleMatrix(new double[2,2]{{1,2},{3,4}});
			IEnumerator enumerator = test.GetEnumerator();
			object value=enumerator.Current;
		}
		
		//Test Current Exception with index>length
		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void CurrentException2() {
			DoubleMatrix test = new DoubleMatrix(new double[2,2]{{1,2},{3,4}});
			IEnumerator enumerator = test.GetEnumerator();
			enumerator.MoveNext();
			enumerator.MoveNext();
			enumerator.MoveNext();
			enumerator.MoveNext();
			enumerator.MoveNext();
			object value=enumerator.Current;
		}
		
	}
}