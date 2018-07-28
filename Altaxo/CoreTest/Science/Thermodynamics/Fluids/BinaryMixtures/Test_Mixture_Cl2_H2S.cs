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
  /// Tests and test data for <see cref="Mixture_Cl2_H2S"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Cl2_H2S : MixtureTestBase
  {

    public Test_Mixture_Cl2_H2S()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("7782-50-5", 0.5), ("7783-06-4", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 200, 0.601526761639245, 999.999999785116, -0.000275406319412733, 25.0719411542305, 2 ),
      ( 200, 6.03025986098871, 9999.9977347438, -0.00276088989321072, 25.1633829012892, 2 ),
      ( 200, 28500.0970283243, 100000.000001601, -0.997889968248335, 43.0369235514186, 1 ),
      ( 200, 28522.2099106225, 1000000.00166792, -0.978916041212195, 43.0524055382122, 1 ),
      ( 200, 28735.3581104237, 10000000.000002, -0.790724342097009, 43.2063645535272, 1 ),
      ( 250, 0.481152104164772, 999.999999994936, -0.000131405994113002, 25.336627773387, 2 ),
      ( 250, 4.81722608027441, 9999.99994811268, -0.00131554990187941, 25.3697835619106, 2 ),
      ( 250, 48.7578378046626, 99999.9999999711, -0.0133096553182253, 25.7066595884665, 2 ),
      ( 250, 25854.9791129237, 1000000.00360994, -0.98139279565838, 39.0351102524096, 1 ),
      ( 250, 26209.7756718928, 9999999.99999996, -0.816446777753529, 39.1805357338009, 1 ),
      ( 300, 0.400936872837995, 999.999999998405, -7.35142981885066E-05, 25.8166888259414, 2 ),
      ( 300, 4.01202516501984, 9999.99998379786, -0.000735584260228621, 25.831367328304, 2 ),
      ( 300, 40.3896472220024, 99999.9999999986, -0.00740059432757938, 25.9792802614542, 2 ),
      ( 300, 435.409206157816, 999999.999999985, -0.0792399596166075, 27.6276089424351, 2 ),
      ( 300, 23234.4260640492, 10000000.001679, -0.827451129111079, 36.7776575129005, 1 ),
      ( 350, 0.343650452069584, 999.999999999986, -4.52182964281548E-05, 26.4649632458925, 2 ),
      ( 350, 3.43790421289561, 9999.99999786912, -0.000452335197017041, 26.4724513353267, 2 ),
      ( 350, 34.5201675503969, 99999.9999999999, -0.00453868803959096, 26.5476786560729, 2 ),
      ( 350, 360.599223198198, 999999.990470374, -0.0470447775724415, 27.3393025650458, 2 ),
      ( 350, 18974.4808196679, 9999999.9999997, -0.81889627650432, 35.85273521644, 1 ),
      ( 400, 0.300689424290321, 999.999999999946, -2.95175211583959E-05, 27.221014367219, 2 ),
      ( 400, 3.00769344945608, 9999.99999946038, -0.00029523042562613, 27.2252672003568, 2 ),
      ( 400, 30.1572554624897, 99999.9943762713, -0.00295784837014982, 27.2679248904838, 2 ),
      ( 400, 310.030071450314, 999999.999878322, -0.0301568255025609, 27.708004319677, 2 ),
      ( 400, 5050.56648277219, 10000000, -0.404659755079913, 34.6637500683812, 2 ),
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
      ( 200, 0.601576305640798, 999.999999891333, -0.000357146662869885, 24.2297680140983, 2 ),
      ( 200, 6.03524237119601, 9999.99999949441, -0.00358358837988451, 24.3057174709248, 2 ),
      ( 200, 25802.2962552466, 100000.000001601, -0.997669349082586, 40.0980136690101, 1 ),
      ( 200, 25820.6445658133, 1000000.0043846, -0.976710052464205, 40.1144618493512, 1 ),
      ( 200, 25998.1809518338, 9999999.99999899, -0.768690949653979, 40.2780307031891, 1 ),
      ( 250, 0.481171432080861, 999.999999999926, -0.00017097512191653, 24.998899034986, 2 ),
      ( 250, 4.81914393705918, 9999.999999258, -0.00171239950403939, 25.0405804309352, 2 ),
      ( 250, 48.9608545268068, 99999.9924644026, -0.0174003925381571, 25.467508550489, 2 ),
      ( 250, 23592.3007817496, 1000000.0054115, -0.97960821325714, 37.2779891848265, 1 ),
      ( 250, 23869.2225442807, 10000000.0000019, -0.798447912225276, 37.4062074982435, 1 ),
      ( 300, 0.400945561511593, 999.999999999975, -9.45890616304543E-05, 25.737353671822, 2 ),
      ( 300, 4.0128751513003, 9999.99999974648, -0.000946649642623693, 25.7583237901817, 2 ),
      ( 300, 40.4770713185901, 99999.9972249648, -0.00954386380187632, 25.9704207604527, 2 ),
      ( 300, 447.991998444858, 999999.999999998, -0.10510089948288, 28.4548637721104, 2 ),
      ( 300, 21513.7608254583, 10000000.0003228, -0.813650602648157, 35.7894732120438, 1 ),
      ( 350, 0.343654957263583, 999.98575283156, -5.77324021334487E-05, 26.4378371032009, 2 ),
      ( 350, 3.43833710730939, 9999.99999994077, -0.000577586693840909, 26.4495229830146, 2 ),
      ( 350, 34.5640378506788, 99999.9993670877, -0.00580158352518883, 26.5672130056476, 2 ),
      ( 350, 365.919393966093, 999999.999994083, -0.0608994149495804, 27.8403655118682, 2 ),
      ( 350, 18576.4578214556, 10000000.0000121, -0.815015801043509, 35.0855624236304, 1 ),
      ( 400, 0.300692065484234, 999.997935133856, -3.77067663227651E-05, 27.1001369695057, 2 ),
      ( 400, 3.00794174974932, 9999.99999998846, -0.000377160360782588, 27.1068345051086, 2 ),
      ( 400, 30.1821872371587, 99999.9998539281, -0.00378085598066014, 27.1741393849654, 2 ),
      ( 400, 312.817645278603, 999999.999999879, -0.0387986999020404, 27.8824491676722, 2 ),
      ( 400, 12838.8496476618, 10000000.0000106, -0.765803996785877, 39.1761215227381, 1 ),
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
      ( 200, 0.601631622431773, 999.999999989369, -0.000448464554612601, 23.3824939372163, 2 ),
      ( 200, 6.04082961068471, 9999.99999999761, -0.00450459499515624, 23.3967078612351, 2 ),
      ( 200, 23555.7415166502, 100000.000001186, -0.997447069065971, 36.7562385782216, 1 ),
      ( 200, 23571.251555849, 1000000.00003114, -0.974487489110979, 36.7740111462878, 1 ),
      ( 200, 23721.8558348655, 10000000.0148922, -0.746494617853895, 36.9503531197104, 1 ),
      ( 250, 0.481195337725598, 999.999999997884, -0.000220052311324422, 24.6604150182172, 2 ),
      ( 250, 4.82152662525171, 9999.99997814542, -0.00220513755311285, 24.7038285683194, 2 ),
      ( 250, 49.2180498593941, 99999.9999999893, -0.022534515378593, 25.1519823636006, 2 ),
      ( 250, 21655.0325691532, 1000000.00002491, -0.97778394246042, 35.0637121687201, 1 ),
      ( 250, 21878.172688535, 10000000.0160351, -0.780105287040694, 35.1986762361512, 1 ),
      ( 300, 0.400956360355399, 999.999999999538, -0.000120925144852148, 25.6580560989475, 2 ),
      ( 300, 4.01393782668469, 9999.99999528369, -0.00121055193088224, 25.6856642607331, 2 ),
      ( 300, 40.587528900683, 99999.9999999998, -0.0122387697303308, 25.9662710297112, 2 ),
      ( 300, 19571.8060004386, 999999.999999973, -0.979516051067773, 34.461514824009, 1 ),
      ( 300, 19935.2574236408, 10000000.0000013, -0.798895060079027, 34.4443788224341, 1 ),
      ( 350, 0.343660451750513, 999.999999999883, -7.312631491598E-05, 26.4108149746362, 2 ),
      ( 350, 3.43886939545946, 9999.99999881994, -0.000731689368976094, 26.4276375255262, 2 ),
      ( 350, 34.6183276381774, 99999.9870556957, -0.00736013281742532, 26.5975208368007, 2 ),
      ( 350, 372.978121545375, 999999.992316392, -0.0786716391070939, 28.4879756122156, 2 ),
      ( 350, 17702.5681276489, 10000000.0000282, -0.80588391545729, 34.0305451193058, 1 ),
      ( 400, 0.300695198904127, 999.991246174134, -4.75324912895058E-05, 26.9793883410106, 2 ),
      ( 400, 3.00823941930036, 9999.99999973831, -0.000475480581850694, 26.989690167297, 2 ),
      ( 400, 30.2122058187641, 99999.9966607991, -0.0047700990595334, 27.0934272838794, 2 ),
      ( 400, 316.302528595494, 999999.999891526, -0.0493882318172185, 28.2090565119901, 2 ),
      ( 400, 14652.1121853725, 10000000.0013642, -0.794786647673598, 35.3133002765358, 1 ),
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
