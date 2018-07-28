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
  /// Tests and test data for <see cref="Mixture_CO2_Hexane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_CO2_Hexane : MixtureTestBase
  {

    public Test_Mixture_CO2_Hexane()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("124-38-9", 0.5), ("110-54-3", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 250, 0.481824270042699, 999.989598974949, -0.00153081489470512, 117.554573295074, 2 ),
      ( 250, 8107.03680390521, 99999.9999992987, -0.994065813649134, 136.108159699529, 1 ),
      ( 250, 8115.4893988805, 1000000.00117454, -0.940719942462205, 136.152397606304, 1 ),
      ( 250, 8195.70952308715, 10000000.0000015, -0.413001794159699, 136.591391099031, 1 ),
      ( 250, 8757.52742665836, 100000000.004264, 4.49340761576726, 140.514668444717, 1 ),
      ( 300, 0.401207270987821, 999.999987618188, -0.000751994080201402, 134.885919979923, 2 ),
      ( 300, 4.03964222888472, 9999.99036417856, -0.00757159723063731, 135.226877566946, 2 ),
      ( 300, 7585.25564701661, 100000.000000111, -0.994714673041658, 150.734756336952, 1 ),
      ( 300, 7597.44835404188, 1000000.01797355, -0.947231550163878, 150.774258780254, 1 ),
      ( 300, 7710.17704562648, 10000000.00003, -0.480030661926022, 151.173626330649, 1 ),
      ( 300, 8414.21655206913, 100000000.006458, 3.76462143604918, 154.838555561827, 1 ),
      ( 350, 0.343778596940933, 999.99999837695, -0.00042252511433539, 153.838301386292, 2 ),
      ( 350, 3.45096965906024, 9999.98233143253, -0.00424118899517267, 154.004649264189, 2 ),
      ( 350, 35.95075600747, 99999.9999996295, -0.0441554503655709, 155.750358657114, 2 ),
      ( 350, 7042.75405832243, 1000000.00000016, -0.951207533475596, 167.546196712091, 1 ),
      ( 350, 7208.74923195775, 10000000.0005051, -0.523310728661828, 167.87150325612, 1 ),
      ( 350, 8091.66372172461, 100000000.009219, 3.24675757293574, 171.312285303222, 1 ),
      ( 400, 0.300757451553821, 999.999999706132, -0.000260267650539802, 173.058998158517, 2 ),
      ( 400, 3.01465554075046, 9999.99690861191, -0.0026085226027582, 173.14861475238, 2 ),
      ( 400, 30.8927306203708, 99999.9996014268, -0.0266992651210196, 174.069897864205, 2 ),
      ( 400, 6407.38993026093, 999999.999999831, -0.953073064478503, 185.203545714741, 1 ),
      ( 400, 6673.58954194752, 10000000.0009195, -0.549449104931509, 185.323486141137, 1 ),
      ( 400, 7785.89215937862, 100000000.012418, 2.86184611859789, 188.494768596796, 1 ),
      ( 500, 0.240571617917117, 999.999999998981, -0.000117547624953391, 208.867222471712, 2 ),
      ( 500, 2.40826669165624, 9999.99985131823, -0.00117648874815747, 208.899386386817, 2 ),
      ( 500, 24.3432389571238, 99999.9999997102, -0.0118679777867732, 209.224994158353, 2 ),
      ( 500, 276.91728577176, 999999.984031232, -0.131353106826638, 212.968055305754, 2 ),
      ( 500, 5398.01966551639, 10000000.0016988, -0.554385952190936, 219.15302936643, 1 ),
      ( 500, 7218.16791678111, 100000000.018982, 2.33247081680158, 221.204912115546, 1 ),
      ( 600, 0.200464934499475, 999.999999998212, -6.061785239096E-05, 239.546482120384, 2 ),
      ( 600, 2.00574397214873, 9999.99998193074, -0.000606330970787342, 239.560619368352, 2 ),
      ( 600, 20.1678721994205, 99999.9999999989, -0.00607867417694515, 239.702929934585, 2 ),
      ( 600, 213.801950582106, 1000000.00009775, -0.0624370722598196, 241.22062252227, 2 ),
      ( 600, 3649.37657290303, 10000000, -0.450720475836528, 249.782886384361, 1 ),
      ( 600, 6706.03927476104, 99999999.9999999, 1.9891382160492, 249.683431656015, 1 ),
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
      ( 250, 0.481284811957159, 999.999999996185, -0.00041167591960236, 72.0598424203421, 2 ),
      ( 300, 0.400991657638473, 999.999998029266, -0.00021469809990099, 81.9405424274888, 2 ),
      ( 300, 4.01769734460172, 9999.99999564776, -0.0021509060875835, 82.0113906664776, 2 ),
      ( 300, 12582.0903142007, 10000000.0004503, -0.681368075178675, 97.4157813213975, 1 ),
      ( 350, 0.343676670719743, 999.999999699516, -0.000126074516276503, 92.5149883978888, 2 ),
      ( 350, 3.44067549974896, 9999.9968846832, -0.00126198471683411, 92.5494276788087, 2 ),
      ( 350, 34.8070075232233, 99999.9810613665, -0.01274666424258, 92.8987195798956, 2 ),
      ( 350, 11186.600556824, 9999999.99999871, -0.692817008970647, 105.230643831077, 1 ),
      ( 400, 0.300703173462685, 999.999999940196, -7.98107446246231E-05, 103.106396900102, 2 ),
      ( 400, 3.0091946994096, 9999.99938928895, -0.000798538585069434, 103.12515856165, 2 ),
      ( 400, 30.3112878032781, 99999.9999977851, -0.00802903491883416, 103.314376319765, 2 ),
      ( 400, 12678.9051313617, 100000000, 1.37149163120507, 115.767951991546, 1 ),
      ( 500, 0.240552093578295, 999.999999999783, -3.63924643757651E-05, 122.677776723253, 2 ),
      ( 500, 2.40630919832483, 9999.99996896663, -0.000363962110399781, 122.68482182445, 2 ),
      ( 500, 24.1422935788288, 99999.9999999973, -0.00364338412287804, 122.755532854835, 2 ),
      ( 500, 249.739971894936, 1000000.00008347, -0.036824832369178, 123.488498049581, 2 ),
      ( 500, 3817.3498601657, 10000000.0000047, -0.369868238159565, 131.314682109762, 1 ),
      ( 500, 11363.0075637488, 100000000.000001, 1.11689852308498, 131.980497931495, 1 ),
      ( 600, 0.200456372942215, 999.999999999672, -1.79101142878175E-05, 139.381105292472, 2 ),
      ( 600, 2.00488685905895, 9999.9999967178, -0.000179078236035815, 139.384396664199, 2 ),
      ( 600, 20.0811933427226, 99999.9999999998, -0.00178849272154102, 139.417369481445, 2 ),
      ( 600, 204.055670816832, 999999.999314909, -0.0176563976600636, 139.752595983678, 2 ),
      ( 600, 2349.29063723641, 10000000, -0.146751876636817, 143.098319116723, 2 ),
      ( 600, 10216.8312701978, 100000000.000087, 0.961985839293796, 146.527581207617, 1 ),
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
      ( 250, 0.48112941533446, 999.999999865342, -8.88258823802754E-05, 26.6171685329769, 2 ),
      ( 250, 4.81514675070846, 9999.99861590809, -0.000888854367385761, 26.6388583673493, 2 ),
      ( 250, 48.5430888888201, 99999.9999848429, -0.00894918375782415, 26.8582400713471, 2 ),
      ( 300, 0.400925122174969, 999.999999995104, -4.87788930046891E-05, 29.0180995788275, 2 ),
      ( 300, 4.01101276742881, 9999.99985451927, -0.000487934743765299, 29.0275767671932, 2 ),
      ( 300, 40.2877262318273, 99999.9999999217, -0.00489403846234375, 29.1228552530539, 2 ),
      ( 300, 422.241061049834, 999999.999999995, -0.0505291823240852, 30.1332577927402, 2 ),
      ( 300, 18230.3462658881, 9999999.99945689, -0.780088891550781, 41.8775432686506, 1 ),
      ( 300, 25633.9817604168, 100000000.019761, 0.563961343605813, 41.7220653222563, 1 ),
      ( 350, 0.343643341491829, 999.999999997458, -2.90988967575913E-05, 31.2029803979296, 2 ),
      ( 350, 3.43733376373744, 9999.99997435939, -0.000291023597498772, 31.2078777424787, 2 ),
      ( 350, 34.4637515995627, 99999.9999999988, -0.00291371106626065, 31.2569865169191, 2 ),
      ( 350, 354.077491493599, 1000000.0000219, -0.0294967906603211, 31.7619284695967, 2 ),
      ( 350, 5211.50063380029, 9999999.9998599, -0.340624963904196, 38.493433439124, 2 ),
      ( 350, 23328.6138691914, 100000000, 0.47301225772174, 40.9166664541528, 1 ),
      ( 400, 0.300684641620196, 999.999999999515, -1.81835083684856E-05, 33.1598760019372, 2 ),
      ( 400, 3.0073385892465, 9999.99999511835, -0.000181837875919299, 33.1627118547382, 2 ),
      ( 400, 30.1227003054833, 100000, -0.00181865812300029, 33.1911117660404, 2 ),
      ( 400, 306.257480937696, 999999.996989686, -0.0182144344206612, 33.4791737690633, 2 ),
      ( 400, 3673.42574097981, 9999999.9965109, -0.181474744987149, 36.6259720830312, 2 ),
      ( 400, 21176.8600980034, 100000000.004867, 0.419847761839053, 40.7702442519263, 1 ),
      ( 500, 0.240545123738949, 999.999999999979, -7.41833433149941E-06, 36.49046813418, 2 ),
      ( 500, 2.40561182894587, 9999.99999978054, -7.41748921126454E-05, 36.4916630395216, 2 ),
      ( 500, 24.0721690891122, 99999.9978373707, -0.000740903704151631, 36.5036158982461, 2 ),
      ( 500, 242.318168724595, 999999.999998797, -0.00732437613693318, 36.6234837571837, 2 ),
      ( 500, 2569.93419568039, 9999999.99988162, -0.0640097334037981, 37.8133886375226, 2 ),
      ( 500, 17515.7157827113, 100000000, 0.373300082501118, 41.4633011286545, 1 ),
      ( 600, 0.200453333813949, 999.999999999999, -2.69520959298825E-06, 39.2166357682976, 2 ),
      ( 600, 2.00458184080043, 9999.99999999247, -2.6944943166226E-05, 39.2172552545296, 2 ),
      ( 600, 20.0506665857803, 99999.9999278259, -0.000268734766832354, 39.2234496255914, 2 ),
      ( 600, 200.978607683073, 1000000, -0.00261632291554868, 39.2853312698154, 2 ),
      ( 600, 2043.9081290672, 9999999.99981868, -0.0192671583668893, 39.8862346846972, 2 ),
      ( 600, 14756.7047473796, 100000000.001435, 0.358384450855358, 42.6682786618998, 1 ),
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
