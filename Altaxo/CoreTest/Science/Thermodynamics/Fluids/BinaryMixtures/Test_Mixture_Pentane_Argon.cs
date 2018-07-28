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
  /// Tests and test data for <see cref="Mixture_Pentane_Argon"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Pentane_Argon : MixtureTestBase
  {

    public Test_Mixture_Pentane_Argon()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("109-66-0", 0.5), ("7440-37-1", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 200, 0.601375795556887, 999.999999993305, -2.90123413984448E-05, 12.5447768368959, 2 ),
      ( 200, 6.01532880675933, 9999.99993253526, -0.000290146130597008, 12.5470211519235, 2 ),
      ( 200, 60.3109616604051, 99999.9999999923, -0.00290373145426437, 12.569512513194, 2 ),
      ( 200, 30319.9699176192, 99999999.9999997, 0.983373828770005, 17.6839238660252, 1 ),
      ( 250, 0.481093119979116, 999.999999999571, -1.33890701205573E-05, 12.5571825536701, 2 ),
      ( 250, 4.81151095418449, 9999.99999570337, -0.000133880665421066, 12.5583003077487, 2 ),
      ( 250, 48.1731136887447, 100000, -0.00133779664271582, 12.5694775803483, 2 ),
      ( 250, 487.556700331829, 999999.999387852, -0.0132702960166575, 12.6811879757569, 2 ),
      ( 250, 5424.5067989544, 10000000, -0.113123650831574, 13.7305329018487, 2 ),
      ( 250, 26991.3187571831, 99999999.9999996, 0.782375596085192, 16.4396856033522, 1 ),
      ( 300, 0.400908025384145, 999.999999999972, -6.13580336907606E-06, 12.5716559697088, 2 ),
      ( 300, 4.00930160963791, 9999.9999997091, -6.13460269470977E-05, 12.5723189723356, 2 ),
      ( 300, 40.1151173030663, 99999.9972104991, -0.000612256797408729, 12.5789451574277, 2 ),
      ( 300, 403.325284477581, 999999.999999319, -0.00599942295832236, 12.6448092458989, 2 ),
      ( 300, 4197.29622853941, 10000000.0000986, -0.0448480553617345, 13.2483372273609, 2 ),
      ( 300, 24123.4663818199, 100000000.000239, 0.661890373242168, 15.6422249868341, 1 ),
      ( 350, 0.343634172765442, 1000, -2.37061643219174E-06, 12.5874985200119, 2 ),
      ( 350, 3.43641484942262, 9999.99999998755, -2.36964770139017E-05, 12.5879402992363, 2 ),
      ( 350, 34.3714456788072, 99999.9998856921, -0.000235995131028063, 12.5923551995858, 2 ),
      ( 350, 344.412394650922, 1000000, -0.00226197666729326, 12.6362106873751, 2 ),
      ( 350, 3477.87460615881, 10000000.0000284, -0.011944417889049, 13.0413233986907, 1 ),
      ( 350, 21707.4144825166, 100000000.000296, 0.583022898130164, 15.1018982880596, 1 ),
      ( 400, 0.300679257702502, 999.996727162195, -2.72535565126787E-07, 12.6035566107703, 2 ),
      ( 400, 3.00679991389817, 9999.99999999999, -2.71807683097535E-06, 12.6038759842094, 2 ),
      ( 400, 30.0687127799517, 99999.9999999219, -2.64516844350088E-05, 12.6070678533896, 2 ),
      ( 400, 300.736706740959, 999999.999682613, -0.000191305621029099, 12.6387987873878, 2 ),
      ( 400, 2989.98727710356, 10000000.000081, 0.00562024601591405, 12.9362005133926, 1 ),
      ( 400, 19691.5984121288, 100000000.000967, 0.526941428658764, 14.7168437128197, 1 ),
      ( 500, 0.240542926974335, 1000.01635695296, 1.6805396165878E-06, 12.6336330589571, 1 ),
      ( 500, 2.40539296026684, 10000.0000000023, 1.68091791296981E-05, 12.6338292765438, 1 ),
      ( 500, 24.0502815181613, 100000.000023756, 0.000168497458812394, 12.6357907180665, 1 ),
      ( 500, 240.129002154728, 1000000, 0.00172547728956373, 12.655331181521, 1 ),
      ( 500, 2355.45900205894, 10000000.000017, 0.0212164129562313, 12.8432382754593, 1 ),
      ( 500, 16593.7402211724, 100000000.000001, 0.449602898976831, 14.2141844295661, 1 ),
      ( 600, 0.200452296036163, 1000.01948334477, 2.38049273371131E-06, 12.659783083512, 1 ),
      ( 600, 2.00448010717994, 10000.0000000046, 2.38068098286716E-05, 12.6599211328281, 1 ),
      ( 600, 20.040502572248, 100000.000046482, 0.000238302522780401, 12.6613013285697, 1 ),
      ( 600, 199.971575941188, 1000000, 0.00240637601427803, 12.6750731789518, 1 ),
      ( 600, 1953.15510727292, 10000000.0000031, 0.0263024272841728, 12.8097325369487, 1 ),
      ( 600, 14362.3042149816, 100000000, 0.395686790539992, 13.9080098351197, 1 ),
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
      ( 250, 0.481154866057282, 999.999999858139, -0.000141716259117018, 55.1212334238789, 2 ),
      ( 250, 4.81770147077249, 9999.99999808438, -0.00141866093486487, 55.1463803987696, 2 ),
      ( 300, 0.400937742432688, 999.999999734076, -8.02542089256815E-05, 62.3816773012078, 2 ),
      ( 300, 4.01227717977682, 9999.99999999709, -0.000802916827211922, 62.3930555409779, 2 ),
      ( 300, 40.4166001872969, 99999.9956910365, -0.00806707190030233, 62.5079002216452, 2 ),
      ( 350, 0.343650146267504, 999.999999979031, -4.88997836129202E-05, 70.3146421453322, 2 ),
      ( 350, 3.43801486872799, 9999.99978801751, -0.000489075893888377, 70.3206037370115, 2 ),
      ( 350, 34.5324949739568, 99999.9998998289, -0.00489859733921054, 70.3805303590499, 2 ),
      ( 400, 0.300688504007913, 999.999999995814, -3.10284207399758E-05, 78.3502142689233, 2 ),
      ( 400, 3.00772496181739, 9999.99995793313, -0.000310274589699797, 78.3537058440808, 2 ),
      ( 400, 30.1614714354895, 99999.9999999972, -0.00310177252658396, 78.388727547389, 2 ),
      ( 400, 310.268402632271, 1000000.00001479, -0.0309062361251101, 78.7491128583842, 2 ),
      ( 500, 0.240546446347724, 999.9999999998, -1.29166444647247E-05, 93.39506332555, 2 ),
      ( 500, 2.40574404101863, 9999.99999799672, -0.000129127648360599, 93.3965974157019, 2 ),
      ( 500, 24.0853412691536, 99999.9810316239, -0.00128739441369006, 93.4119547757724, 2 ),
      ( 500, 243.584084671981, 999999.99995073, -0.0124833499739212, 93.5669614572225, 2 ),
      ( 500, 2619.62227853734, 9999999.99999999, -0.0817632707372393, 95.0266947691862, 1 ),
      ( 500, 11315.2774113198, 100000000.000062, 1.12582803364579, 98.0867261292103, 1 ),
      ( 600, 0.200453754914719, 999.999999999992, -4.75476127178695E-06, 106.473231826864, 2 ),
      ( 600, 2.00462307859448, 9999.99999992874, -4.75157344231916E-05, 106.474085163268, 2 ),
      ( 600, 20.0547435828653, 99999.9993704916, -0.000471973535840585, 106.482621723915, 2 ),
      ( 600, 201.339660647936, 999999.999999998, -0.00440488425053781, 106.568229849177, 2 ),
      ( 600, 2036.03848984199, 9999999.99999998, -0.0154764571212895, 107.380241378946, 1 ),
      ( 600, 10181.0863380148, 100000000.007704, 0.968874205565405, 110.231747277082, 1 ),
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
      ( 250, 0.481517991756407, 999.999978649749, -0.000895736327420803, 97.723074732171, 2 ),
      ( 250, 9354.29686731895, 10000000.0000073, -0.485705141285962, 114.795491702901, 1 ),
      ( 250, 10047.9806683815, 100000000.012559, 3.7878941503177, 118.48950886601, 1 ),
      ( 300, 0.401091437649423, 999.999997960012, -0.000463415920303197, 112.20773483586, 2 ),
      ( 300, 4.0277973811961, 9999.99999999988, -0.00465309558217304, 112.374980986353, 2 ),
      ( 300, 8749.80644746084, 10000000.0000978, -0.541812075620053, 125.79945323669, 1 ),
      ( 300, 9637.23342870558, 100000000.019625, 3.15996529014447, 129.250934408181, 1 ),
      ( 350, 0.343726960538845, 999.999999695017, -0.000272363532251028, 128.049531231548, 2 ),
      ( 350, 3.4457397238546, 9999.99678921995, -0.00272983541106602, 128.130944229328, 2 ),
      ( 350, 35.3517097511434, 100000.004231179, -0.0279583538140434, 128.973229721201, 2 ),
      ( 350, 8103.70734294346, 10000000.0023377, -0.575955390067313, 139.24496928886, 1 ),
      ( 350, 9247.19334038193, 100000000, 2.71608259074752, 142.439460663834, 1 ),
      ( 400, 0.300731548560971, 999.999999938447, -0.000174156794388523, 144.100985276485, 2 ),
      ( 400, 3.0120444762364, 9999.99936453166, -0.00174391007680809, 144.144745132674, 2 ),
      ( 400, 30.6091166315059, 99999.9999931427, -0.0176809813276775, 144.590700247198, 2 ),
      ( 400, 382.716962200476, 999999.993530414, -0.214356288033299, 151.072538479319, 2 ),
      ( 400, 7380.48699800044, 10000000.000001, -0.5926025285329, 153.690408302352, 1 ),
      ( 400, 8874.57903148168, 100000000.000001, 2.38809506402474, 156.49905356349, 1 ),
      ( 500, 0.240563318420611, 999.999999995595, -8.30514225650867E-05, 174.157915350606, 2 ),
      ( 500, 2.40743370181087, 9999.99995529905, -0.000830888448619998, 174.173596527094, 2 ),
      ( 500, 24.2567984963994, 99999.9999999896, -0.00834671418353962, 174.331785279351, 2 ),
      ( 500, 263.668093548913, 999999.999999999, -0.0877040294973112, 176.071524300511, 2 ),
      ( 500, 5452.78304571865, 9999999.99999997, -0.558861342404465, 182.828647815672, 1 ),
      ( 500, 8178.23202401968, 100000000, 1.94126332669845, 183.769460487282, 1 ),
      ( 600, 0.20046166399682, 999.999999999513, -4.43039879903324E-05, 200.287276202332, 2 ),
      ( 600, 2.0054163306467, 9999.99999510567, -0.000443051737431989, 200.294208923022, 2 ),
      ( 600, 20.1345083379971, 99999.9999999997, -0.00443169813659219, 200.363879979494, 2 ),
      ( 600, 209.771602703298, 999999.987980452, -0.0444236480309158, 201.094074287347, 2 ),
      ( 600, 3071.31437170687, 10000000.0000854, -0.347338766126511, 207.325881042446, 1 ),
      ( 600, 7549.20936934615, 100000000, 1.65528180420532, 208.058317743405, 1 ),
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
