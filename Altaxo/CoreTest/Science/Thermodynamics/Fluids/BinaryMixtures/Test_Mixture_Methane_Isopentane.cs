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
  /// Tests and test data for <see cref="Mixture_Methane_Isopentane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Methane_Isopentane : MixtureTestBase
  {

    public Test_Mixture_Methane_Isopentane()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("74-82-8", 0.5), ("78-78-4", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 150, 10438.0879978116, 100000.000005614, -0.992318374858632, 88.5047192162779, 1 ),
      ( 150, 10443.7477305124, 1000000.00001432, -0.923225377271423, 88.5551730474982, 1 ),
      ( 150, 10498.7699947694, 9999999.99999502, -0.236277400032128, 89.0553283234709, 1 ),
      ( 150, 10939.9921375122, 100000000.000005, 6.32920811817991, 93.6033250485045, 1 ),
      ( 200, 9814.2549006865, 1000000.00024043, -0.938725751542996, 97.1471712589317, 1 ),
      ( 200, 9891.14535719183, 10000000.000002, -0.392020769939201, 97.5900319734028, 1 ),
      ( 200, 10460.6957370605, 100000000.002088, 4.74876766355638, 101.561858767069, 1 ),
      ( 250, 0.481475158462291, 999.999998987373, -0.000802291317480939, 93.9669234205943, 2 ),
      ( 250, 4.85009350625908, 9999.99988573279, -0.00808329860101413, 94.3039046586747, 2 ),
      ( 250, 9173.64306090931, 99999.9999997985, -0.994755748968905, 109.36333799796, 1 ),
      ( 250, 9185.3382609935, 1000000.00993244, -0.94762426098357, 109.40326371501, 1 ),
      ( 250, 9295.04090164312, 10000000.0000107, -0.482424143999062, 109.803873300228, 1 ),
      ( 250, 10024.5930817507, 100000000.000376, 3.79908631902607, 113.437116008205, 1 ),
      ( 300, 0.401075826585857, 999.999843362685, -0.000419947084233071, 111.140429929738, 2 ),
      ( 300, 4.02604339268954, 9999.99850386488, -0.00421491500925703, 111.283262055212, 2 ),
      ( 300, 8516.71744737772, 999999.999999755, -0.952927005220924, 123.389953579029, 1 ),
      ( 300, 8680.88210910046, 9999999.99999997, -0.538172053373192, 123.727190326558, 1 ),
      ( 300, 9616.36472654603, 100000000, 3.16901196383308, 127.10529441862, 1 ),
      ( 300, 12120.9407989251, 1000000000, 32.0756005318565, 142.980749044997, 1 ),
      ( 350, 0.343720536082831, 999.99997586866, -0.000249113072668481, 128.066693845456, 2 ),
      ( 350, 3.44494859074569, 9999.99999998974, -0.00249625864930808, 128.136157511254, 2 ),
      ( 350, 35.2628822853969, 100000.00164122, -0.02550532350301, 128.852722110697, 2 ),
      ( 350, 7750.91637066885, 1000000.00455072, -0.955665253510037, 138.282174859264, 1 ),
      ( 350, 8020.09135669896, 10000000.005474, -0.571532423137471, 138.44492791462, 1 ),
      ( 350, 9228.8311387064, 100000000.001018, 2.72349331828205, 141.548468779205, 1 ),
      ( 400, 0.300728784241452, 999.999995009781, -0.000160401305406991, 144.462760326444, 2 ),
      ( 400, 3.01164205171859, 9999.99999999975, -0.0016059618362921, 144.500067053645, 2 ),
      ( 400, 30.5650508744127, 100000.00015462, -0.0162602765514612, 144.879695765516, 2 ),
      ( 400, 372.150530228147, 999999.998630971, -0.192045899032745, 150.161946838902, 2 ),
      ( 400, 7274.35975765698, 9999999.9999998, -0.586657029665306, 153.394724175211, 1 ),
      ( 400, 8858.75681770053, 100000000.000226, 2.39416188004469, 156.086574279966, 1 ),
      ( 500, 0.240562991893527, 999.999999634783, -7.7128788838214E-05, 174.800093531725, 2 ),
      ( 500, 2.40730183020124, 9999.99624662123, -0.00077159160811225, 174.813456945753, 2 ),
      ( 500, 24.2422391320881, 99999.999904295, -0.00774661830829748, 174.948187848334, 2 ),
      ( 500, 261.70611983431, 1000000.00000338, -0.0808604792523259, 176.418929112683, 2 ),
      ( 500, 5265.48411002043, 10000000.0010521, -0.543167479851803, 183.003511723176, 1 ),
      ( 500, 8167.64406062853, 99999999.9999998, 1.94508962162739, 183.82903036405, 1 ),
      ( 500, 11473.6475060023, 1000000000, 19.9649492400283, 195.738422107988, 1 ),
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
      ( 250, 0.481207360503847, 999.993336577852, -0.000248503584243037, 59.9815449890348, 2 ),
      ( 250, 4.82288915039993, 9999.99998291837, -0.00249049282701952, 60.0357495941649, 2 ),
      ( 300, 0.40096309249585, 999.999997464688, -0.00014118722966725, 69.3384100562279, 2 ),
      ( 300, 4.01473908297276, 9999.99999999197, -0.00141335877087545, 69.3620638557642, 2 ),
      ( 300, 40.6716761686888, 100000.000002213, -0.0142858141263752, 69.6039637498408, 2 ),
      ( 350, 0.343664201866757, 999.999999549309, -8.75120460981903E-05, 78.9043598122864, 2 ),
      ( 350, 3.43935267772051, 9999.99534526278, -0.00087557325666046, 78.9163938193237, 2 ),
      ( 350, 34.6685526033384, 99999.9972158438, -0.00880163306915748, 79.0381978643084, 2 ),
      ( 400, 0.30069706201329, 999.999999902061, -5.72030619916034E-05, 88.4329723753872, 2 ),
      ( 400, 3.00851995240833, 9999.99900486505, -0.000572155098860263, 88.4398287356531, 2 ),
      ( 400, 30.2413927678853, 99999.9999962716, -0.00573408261996226, 88.5088820339786, 2 ),
      ( 400, 319.420318315615, 1000000.00058276, -0.0586702098508938, 89.249903805017, 2 ),
      ( 500, 0.240550272788649, 999.999999993541, -2.65383700804032E-05, 106.564313256279, 2 ),
      ( 500, 2.40607735015175, 9999.99993532888, -0.000265353224283296, 106.567156406374, 2 ),
      ( 500, 24.118313836135, 99999.9999999949, -0.00265047294897861, 106.595664867846, 2 ),
      ( 500, 247.011918413988, 1000000.00000089, -0.0261850904969941, 106.887928822416, 2 ),
      ( 500, 2993.74126629793, 10000000.0000111, -0.196510761686771, 109.603948654289, 1 ),
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
      ( 200, 0.601396408338164, 999.99999888263, -6.32816428457475E-05, 25.2505934764264, 2 ),
      ( 200, 6.01739281229764, 9999.98825855713, -0.000633047914216221, 25.256029720862, 2 ),
      ( 200, 60.5203771719793, 99999.9981847188, -0.00635392707810181, 25.3111218002006, 2 ),
      ( 250, 0.481101985651448, 999.999999907091, -3.18120971920736E-05, 26.0213023098259, 2 ),
      ( 250, 4.81239785437272, 9999.9990594645, -0.000318146253033858, 26.02383203703, 2 ),
      ( 250, 48.2623351956175, 99999.9999983301, -0.00318399670983562, 26.0492219843423, 2 ),
      ( 250, 497.039164469824, 999999.996588206, -0.0320950234245864, 26.3124321221558, 2 ),
      ( 250, 7033.8323861407, 10000000, -0.316039031956119, 29.2933733831426, 2 ),
      ( 300, 0.40091240211759, 999.999999998947, -1.70480981716065E-05, 27.5469105021766, 2 ),
      ( 300, 4.00973921647415, 9999.99998942497, -0.000170470746480835, 27.5483368117924, 2 ),
      ( 300, 40.1589746560702, 100000, -0.00170367705492217, 27.5626089956219, 2 ),
      ( 300, 407.808280948886, 999999.995359699, -0.0169263693651369, 27.7061733718059, 2 ),
      ( 300, 4692.31818757755, 9999999.99999999, -0.145612997036394, 29.0910757406068, 2 ),
      ( 300, 21227.5762639212, 100000000, 0.888607358368031, 31.9193482451251, 1 ),
      ( 300, 35367.2588426087, 1000000000, 10.3355001332647, 40.4184417485496, 1 ),
      ( 350, 0.343636512111442, 999.999999999875, -9.2210551032281E-06, 29.7469287939358, 2 ),
      ( 350, 3.43665027887667, 9999.99999875495, -9.21957861956053E-05, 29.7478278033034, 2 ),
      ( 350, 34.3949941550398, 99999.9879777006, -0.000920477237749934, 29.756813952758, 2 ),
      ( 350, 346.772533024028, 999999.999979268, -0.00905259011248773, 29.8462544440942, 2 ),
      ( 350, 3696.51136250243, 10000000.0014848, -0.0703847230020226, 30.6631799538832, 2 ),
      ( 350, 19433.1455475535, 100000000, 0.768284720447302, 33.3398603455044, 1 ),
      ( 400, 0.30068059528232, 999.999999999986, -4.72191968024315E-06, 32.4056123156628, 2 ),
      ( 400, 3.00693370061336, 9999.99999987055, -4.72061244079065E-05, 32.4062208790786, 2 ),
      ( 400, 30.0820787499997, 99999.9987825741, -0.000470752060551634, 32.4123016199814, 2 ),
      ( 400, 302.061000073519, 999999.99999994, -0.00457465404610797, 32.4726123538535, 2 ),
      ( 400, 3101.43514336502, 9999999.99999746, -0.0305159979374327, 33.0177849616384, 1 ),
      ( 400, 17854.8635884029, 100000000.003382, 0.684018329291861, 35.3958111529331, 1 ),
      ( 500, 0.240543402495955, 999.996799714607, -2.53113482584806E-07, 38.3291090990962, 2 ),
      ( 500, 2.40543947277027, 9999.99999999997, -2.52296045779751E-06, 38.3294275087204, 2 ),
      ( 500, 24.0549212438849, 99999.9999999428, -2.44109911194511E-05, 38.3326089656672, 2 ),
      ( 500, 240.582288431222, 1000000.00049695, -0.000161890708267105, 38.3641609925335, 1 ),
      ( 500, 2389.05863801197, 10000000.0003572, 0.00685406614576029, 38.654617899219, 1 ),
      ( 500, 15286.0726406672, 100000000.001645, 0.57361112988691, 40.456928390675, 1 ),
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
