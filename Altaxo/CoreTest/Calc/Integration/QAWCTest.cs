﻿#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2007 Dr. Dirk Lellinger
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
using Altaxo.Calc.Integration;

using NUnit.Framework;

namespace AltaxoTest.Calc.Integration
{
	[TestFixture]
	public class QAWCTests
	{


		[Test]
		public void TestSin()
		{
			double result, abserr;
			GSL_ERROR error;
			error = QawcIntegration.Integration(z=>Math.Sqrt(z)/(1+z), 0, 100, 1, 0, 1E-6, 100, out result, out abserr);

			NUnit.Framework.Assert.AreEqual(1.37079, result, 1.37079 * 1E-6);
		}
	}
}
