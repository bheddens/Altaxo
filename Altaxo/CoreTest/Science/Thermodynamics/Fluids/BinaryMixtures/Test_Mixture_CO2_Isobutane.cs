﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2018 Dr. Dirk Lellinger
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

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altaxo.Science.Thermodynamics.Fluids
{

  /// <summary>
  /// Tests and test data for <see cref="Mixture_CO2_Isobutane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_CO2_Isobutane : MixtureTestBase
  {

    public Test_Mixture_CO2_Isobutane()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("124-38-9", 0.5), ("75-28-5", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 250, 0.481305268183684, 999.999999997249, -0.000449596286070934, 75.5928150709846, 2 ),
      ( 250, 4.8327243568898, 9999.99997080276, -0.0045182807658138, 75.7137643714632, 2 ),
      ( 250, 10436.0152835764, 100000.000000218, -0.995390109545363, 87.5374505051063, 1 ),
      ( 250, 10454.5042828775, 999999.999998807, -0.953982622046202, 87.5952324489076, 1 ),
      ( 250, 10624.4056560109, 10000000.0000486, -0.547185140799413, 88.1480581508077, 1 ),
      ( 300, 0.401007223186869, 999.999999999563, -0.000248941279778351, 88.773160824532, 2 ),
      ( 300, 4.01910192375948, 9999.99999545872, -0.00249507590931011, 88.8280750773077, 2 ),
      ( 300, 41.1417621239319, 99999.9999999995, -0.0255463664199207, 89.4132345763846, 2 ),
      ( 300, 9460.2995076804, 1000000.00000026, -0.957622124372474, 98.2137604308633, 1 ),
      ( 300, 9747.62904011964, 10000000.0022937, -0.588712912265285, 98.6534352298845, 1 ),
      ( 350, 0.343687203643643, 999.999999999957, -0.000152152425834903, 102.501820163287, 2 ),
      ( 350, 3.4415917479244, 9999.99999954624, -0.00152331836164827, 102.530380130163, 2 ),
      ( 350, 34.9015893526596, 99999.9928957811, -0.0154175853794441, 102.824764038432, 2 ),
      ( 350, 419.266634880856, 999999.999975813, -0.180390514732387, 106.994387952144, 2 ),
      ( 350, 8759.76412706241, 10000000.0000002, -0.607712141768647, 110.624279376422, 1 ),
      ( 400, 0.300710364813828, 999.997935829789, -9.91578745484164E-05, 116.041709301188, 2 ),
      ( 400, 3.0097918373927, 9999.99999996881, -0.000992217414689321, 116.058304083242, 2 ),
      ( 400, 30.3713684326936, 99999.9994797656, -0.00998683119614376, 116.226921771791, 2 ),
      ( 400, 336.920222167458, 999999.999463568, -0.107561591172568, 118.238394790133, 2 ),
      ( 400, 7554.92995566043, 10000000.0000011, -0.602007498790387, 123.406538937283, 1 ),
      ( 500, 0.240555802954578, 999.997970917627, -4.72462940429279E-05, 140.83121528505, 2 ),
      ( 500, 2.406581564006, 9999.99999999903, -0.000472532662009563, 140.838120098258, 2 ),
      ( 500, 24.1688159178101, 99999.9999881866, -0.00473222029333946, 140.907455368108, 2 ),
      ( 500, 252.679622568227, 999999.999999991, -0.0480259740914964, 141.630448746145, 2 ),
      ( 500, 4095.96159578257, 10000000, -0.412727800453515, 147.749001566089, 1 ),
      };

      // TestData for 500 Permille to 500 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_500_500 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 250, 0.481189466976162, 999.999996662263, -0.000211328447163748, 51.0822681054082, 2 ),
      ( 250, 4.82108479470328, 9999.99999994285, -0.00211716151009608, 51.1365934125983, 2 ),
      ( 250, 49.1698205474184, 99999.9977073512, -0.0215791458144075, 51.7037228645629, 2 ),
      ( 300, 0.400953318524737, 999.99999978588, -0.000116813841123892, 58.8717168384758, 2 ),
      ( 300, 4.01375745047879, 9999.99779025138, -0.00116913720439602, 58.8955170140759, 2 ),
      ( 300, 40.5690949958442, 99999.9987551837, -0.0117933814731614, 59.1378211988727, 2 ),
      ( 350, 0.343658427925558, 999.999999964174, -7.07121208597978E-05, 66.8263091796731, 2 ),
      ( 350, 3.43877390848062, 9999.99963555183, -0.000707414143455945, 66.8386280194911, 2 ),
      ( 350, 34.6092680014864, 99999.9999993628, -0.00710374134552299, 66.9629061730663, 2 ),
      ( 350, 371.232473094271, 999999.999999874, -0.0743424888317667, 68.3308207583738, 2 ),
      ( 350, 9892.13906063121, 10000000.0000067, -0.65261898867047, 76.4523405191281, 1 ),
      ( 400, 0.300693466382755, 999.999999992636, -4.52459519972956E-05, 74.5720678242616, 2 ),
      ( 400, 3.00815992341549, 9999.999925608, -0.000452539503841623, 74.5791947194877, 2 ),
      ( 400, 30.204918053418, 99999.9999999857, -0.00453343162693333, 74.6507796402595, 2 ),
      ( 400, 315.236151929183, 1000000.00234434, -0.0461758293087159, 75.3994662619129, 2 ),
      ( 400, 5758.71278603566, 9999999.99996839, -0.477869669155911, 83.4199487988917, 1 ),
      ( 500, 0.240548735010797, 999.999999999567, -2.01457484671928E-05, 88.6267953670749, 2 ),
      ( 500, 2.40592354210602, 9999.99999563887, -0.000201441289574506, 88.6298091693153, 2 ),
      ( 500, 24.1029029200794, 99999.9999999998, -0.00201278752823556, 88.6599747751885, 2 ),
      ( 500, 245.44261086802, 999999.998373137, -0.0199587262632068, 88.9641054182212, 2 ),
      ( 500, 2888.09287238658, 10000000, -0.167118580997316, 91.8277794534095, 2 ),
      };

      // TestData for 999 Permille to 1 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_999_001 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 250, 0.48112934864765, 999.999999866053, -8.86827200295039E-05, 26.575232227599, 2 ),
      ( 250, 4.81513986230695, 9999.99862329487, -0.00088742050211614, 26.596857194295, 2 ),
      ( 250, 48.5423754702171, 99999.9999850505, -0.00893461393264786, 26.8155792984036, 2 ),
      ( 300, 0.400925093697215, 999.999999995131, -4.87032962568744E-05, 28.9719696199642, 2 ),
      ( 300, 4.01100974963502, 9999.99985526452, -0.000487178165253447, 28.9814209518271, 2 ),
      ( 300, 40.2874176083674, 99999.9999999226, -0.00488641086332301, 29.0764387214316, 2 ),
      ( 300, 422.204036984861, 999999.999999994, -0.0504459166552808, 30.0839567167897, 2 ),
      ( 300, 18199.7694177551, 9999999.9997449, -0.779719424947993, 41.84070986218, 1 ),
      ( 350, 0.343643327382123, 999.999999997471, -2.90532686030206E-05, 31.1516067420118, 2 ),
      ( 350, 3.43733220991663, 9999.99997449197, -0.000290567117399514, 31.1564917674126, 2 ),
      ( 350, 34.4635932879416, 99999.999999999, -0.00290912630354469, 31.2054767097107, 2 ),
      ( 350, 354.059997918458, 1000000.00002133, -0.0294488351119983, 31.7091121483223, 2 ),
      ( 350, 5204.54505641369, 9999999.99986459, -0.339743743788949, 38.4131995855497, 2 ),
      ( 400, 0.300684633959674, 999.999999999517, -1.81534616592408E-05, 33.1028093836988, 2 ),
      ( 400, 3.00733769901386, 9999.99999514482, -0.000181537340077156, 33.1056386435898, 2 ),
      ( 400, 30.1226095410122, 99999.9999999999, -0.00181564587330341, 33.1339723930043, 2 ),
      ( 400, 306.247866235518, 999999.997034379, -0.0181836066148918, 33.4213492939626, 2 ),
      ( 400, 3671.68903440002, 9999999.99666434, -0.181087579321866, 36.5590843378214, 2 ),
      ( 500, 0.240545121151732, 999.999999999979, -7.40300848079482E-06, 36.4223670414428, 2 ),
      ( 500, 2.40561147122212, 9999.999999782, -7.40216292820693E-05, 36.42355957088, 2 ),
      ( 500, 24.0721322677271, 99999.9978519329, -0.000739370643589663, 36.4354886257306, 2 ),
      ( 500, 242.314417058287, 999999.999998816, -0.00730900236352477, 36.5551140899077, 2 ),
      ( 500, 2569.50489585569, 9999999.9998842, -0.063853348626485, 37.7423190006747, 2 ),
      };
    }

    [Test]
    public override void CASNumberAttribute_Test()
    {
      base.CASNumberAttribute_Test();
    }

    [Test]
    public override void Constants_Test()
    {
      base.Constants_Test();
    }

    [Test]
    public override void DeltaPhiRDelta_001_999_Test()
    {
      base.DeltaPhiRDelta_001_999_Test();
    }

    [Test]
    public override void DeltaPhiRDelta_500_500_Test()
    {
      base.DeltaPhiRDelta_500_500_Test();
    }

    [Test]
    public override void DeltaPhiRDelta_999_001_Test()
    {
      base.DeltaPhiRDelta_999_001_Test();
    }
  }
}
