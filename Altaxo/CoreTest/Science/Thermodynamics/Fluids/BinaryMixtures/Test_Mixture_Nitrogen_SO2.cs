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
  /// Tests and test data for <see cref="Mixture_Nitrogen_SO2"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Nitrogen_SO2 : MixtureTestBase
  {

    public Test_Mixture_Nitrogen_SO2()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("7727-37-9", 0.5), ("7446-09-5", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 200, 0.601835135441705, 999.999999999683, -0.000786471556813511, 28.0927796900752, 2 ),
      ( 200, 25464.1106006377, 9999999.9999993, -0.763839460699432, 56.1239663672877, 1 ),
      ( 250, 0.481245593341134, 999.999999999706, -0.000324462109796155, 29.8485933775109, 2 ),
      ( 250, 4.82660391945646, 9999.99999698841, -0.00325476170706982, 30.0024860088652, 2 ),
      ( 250, 23363.6368074753, 1000000.00030485, -0.979408623261379, 53.0971304947163, 1 ),
      ( 250, 23551.8760718661, 9999999.99999979, -0.795732006269167, 53.1109838293399, 1 ),
      ( 300, 0.400971976599979, 999.999999999901, -0.000159870979933153, 31.6388439392112, 2 ),
      ( 300, 4.01550753208053, 9999.99999899908, -0.00160099410938113, 31.7143455390728, 2 ),
      ( 300, 40.7528520224179, 99999.9886574118, -0.0162458486094437, 32.4853381436145, 2 ),
      ( 300, 21269.2679854616, 1000000.01244344, -0.981150838003838, 51.8691968331659, 1 ),
      ( 300, 21567.0223197872, 10000000.0000187, -0.814110697864383, 51.6262189315385, 1 ),
      ( 350, 0.34366652384897, 999.999999999972, -9.07981698636592E-05, 33.4249740707252, 2 ),
      ( 350, 3.43947841690449, 9999.99999969878, -0.00090863234172791, 33.4599005235955, 2 ),
      ( 350, 34.6809488601157, 99999.9967541785, -0.00915248569989268, 33.8135715931591, 2 ),
      ( 350, 381.622387220235, 999999.999614992, -0.0995409832299742, 37.8890966856737, 2 ),
      ( 350, 19311.8361691565, 10000000.0034737, -0.822059737529088, 50.8221892762436, 1 ),
      ( 400, 0.300697976077663, 999.995771756699, -5.67725557546094E-05, 35.1485181038911, 2 ),
      ( 400, 3.00851772296385, 9999.99999992717, -0.000567946408301216, 35.1649002677539, 2 ),
      ( 400, 30.2405070126944, 99999.999080331, -0.00570150985250693, 35.3300046721976, 2 ),
      ( 400, 319.685323461343, 999999.999992347, -0.0594472672143878, 37.1244614606131, 2 ),
      ( 400, 16289.6015041205, 9999999.99998897, -0.815415432638723, 51.1862942962857, 1 ),
      ( 500, 0.240550925636966, 999.993462834265, -2.5782092143885E-05, 38.2230165109333, 2 ),
      ( 500, 2.40606764691227, 9999.99999999446, -0.000257852271998294, 38.2277494227032, 2 ),
      ( 500, 24.1167295672794, 99999.9999439878, -0.00258149422616882, 38.2751940477424, 2 ),
      ( 500, 246.995509244478, 999999.999999993, -0.0261170155437962, 38.7616364506549, 2 ),
      ( 500, 3405.94280358147, 9999999.99366205, -0.293749961072139, 45.2778010799578, 2 ),
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
      ( 200, 0.601461000388634, 999.999999999652, -0.000167791311418664, 24.4363518401031, 2 ),
      ( 250, 0.481126761936028, 999.999999790219, -8.04311299907727E-05, 25.3209027746584, 2 ),
      ( 250, 4.81475545700275, 9999.99999997368, -0.000804778844523562, 25.3387069184438, 2 ),
      ( 250, 48.501434466392, 99999.999994834, -0.00809518375577386, 25.5189907880846, 2 ),
      ( 300, 0.400924559137279, 999.999999995525, -4.44942349661077E-05, 26.2272464867787, 2 ),
      ( 300, 4.01085224389707, 9999.99995475752, -0.000445052752623619, 26.2340847018385, 2 ),
      ( 300, 40.2703434573001, 99999.9999999947, -0.00446163132916492, 26.3028652922179, 2 ),
      ( 350, 0.343643391902007, 999.999999996704, -2.63651552333761E-05, 27.1432080286199, 2 ),
      ( 350, 3.4372496376971, 9999.99996679306, -0.000263676160669588, 27.1465981185125, 2 ),
      ( 350, 34.4543659533673, 99999.9999999983, -0.00263922384466823, 27.1805729073687, 2 ),
      ( 350, 353.039048400149, 1000000.00004494, -0.0266393101628849, 27.5278802819519, 2 ),
      ( 400, 0.300684877053564, 999.99999999996, -1.60860243636556E-05, 28.0483081291894, 2 ),
      ( 400, 3.00728415706335, 9999.99999398377, -0.000160861011042973, 28.0503896227568, 2 ),
      ( 400, 30.1164518376375, 100000, -0.00160868268755943, 28.0712144932342, 2 ),
      ( 400, 305.596969454097, 999999.995580748, -0.0160895875762372, 28.2804155585332, 2 ),
      ( 400, 3551.13834248521, 9999999.99898163, -0.153285478527109, 30.3738197373372, 2 ),
      ( 500, 0.24054543113633, 999.999999999979, -5.81575330066698E-06, 29.7527674712647, 2 ),
      ( 500, 2.40558020822358, 9999.99999976777, -5.81507898404965E-05, 29.753866573411, 2 ),
      ( 500, 24.0683829030064, 99999.9977294635, -0.00058083189054975, 29.7648525105943, 2 ),
      ( 500, 241.932475521316, 999999.999999246, -0.00573897045687494, 29.8741841475343, 2 ),
      ( 500, 2527.35651847478, 10000000.0001058, -0.0482386223510978, 30.8957844634753, 2 ),
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
      ( 200, 0.601371367599026, 999.9999999727, -2.16436935578805E-05, 20.8005208777836, 2 ),
      ( 200, 6.01488523769723, 9999.99972780588, -0.000216416539308957, 20.8024737636773, 2 ),
      ( 200, 60.2661369727794, 99999.999999935, -0.00216210643424064, 20.8220114141945, 2 ),
      ( 200, 614.50485060458, 999999.999996594, -0.0213936454531971, 21.0181140637502, 2 ),
      ( 200, 7133.4425585156, 10000000.0000228, -0.156987181478785, 22.7337930833677, 1 ),
      ( 250, 0.481090527720432, 999.999999999543, -7.99508422136354E-06, 20.8063814508554, 2 ),
      ( 250, 4.81125134706077, 9999.99999548195, -7.99237914236398E-05, 20.8073997540287, 2 ),
      ( 250, 48.1470185091953, 100000, -0.000796526436392732, 20.8175733367374, 2 ),
      ( 250, 484.81369570289, 999999.999998996, -0.00768751867939286, 20.9183199718272, 2 ),
      ( 250, 5023.04274847076, 10000000.0031986, -0.0422405194383186, 21.7855380266554, 1 ),
      ( 300, 0.40090633603809, 999.999999999996, -1.87868637867436E-06, 20.822541173372, 2 ),
      ( 300, 4.00913091638162, 9999.99999995969, -1.87667536062746E-05, 20.8231730135246, 2 ),
      ( 300, 40.0980011952328, 99999.9997627772, -0.000185655516434828, 20.8294846008697, 2 ),
      ( 300, 401.5698594432, 999999.999999979, -0.00165423680708606, 20.8919079217719, 2 ),
      ( 300, 3990.20747016554, 10000000.0000333, 0.00472361599874512, 21.4405491566203, 1 ),
      ( 350, 0.343632943527408, 1000, 1.14206402864057E-06, 20.8645773317766, 1 ),
      ( 350, 3.43629414548803, 10000.0000000075, 1.14346456385971E-05, 20.8650162460661, 1 ),
      ( 350, 34.3593574066027, 100000.000113557, 0.00011574652848497, 20.8694012745317, 1 ),
      ( 350, 343.188206699384, 1000000.00000009, 0.00129706417945467, 20.9128368916531, 1 ),
      ( 350, 3347.31755655015, 10000000.0000017, 0.026593198954064, 21.304909020236, 1 ),
      ( 400, 0.300678343952235, 1000.00000000001, 2.71248469807739E-06, 20.9494502102796, 1 ),
      ( 400, 3.006710172585, 10000.0000000754, 2.71346147367802E-05, 20.9497795370636, 1 ),
      ( 400, 30.0597316580696, 100000.000847994, 0.000272322027509393, 20.9530703283023, 1 ),
      ( 400, 299.833620589919, 1000000.00000061, 0.00282008154207829, 20.9857293226718, 1 ),
      ( 400, 2898.70719536109, 10000000.0000004, 0.0372871614349477, 21.2873890772164, 1 ),
      ( 500, 0.24054236792619, 1000.00000000001, 3.96470742882546E-06, 21.2827751236155, 1 ),
      ( 500, 2.40533803017086, 10000.0000001534, 3.96520712127127E-05, 21.2829902164583, 1 ),
      ( 500, 24.0447878187085, 100000.001586697, 0.000397019494290211, 21.2851401594131, 1 ),
      ( 500, 239.580350930384, 1000000.00000089, 0.00401948550063971, 21.306540510457, 1 ),
      ( 500, 2302.6345919289, 10000000.0101086, 0.0446439983797766, 21.510512055973, 1 ),
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