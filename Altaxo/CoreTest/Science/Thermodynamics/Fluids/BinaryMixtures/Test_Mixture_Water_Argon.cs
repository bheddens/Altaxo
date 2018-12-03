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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Altaxo.Science.Thermodynamics.Fluids
{

  /// <summary>
  /// Tests and test data for <see cref="Mixture_Water_Argon"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Water_Argon : MixtureTestBase
  {

    public Test_Mixture_Water_Argon()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("7732-18-5", 0.5), ("7440-37-1", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 300, 0.400908016028172, 999.999999999973, -6.09579190266417E-06, 12.4846481759298, 2 ),
      ( 300, 4.00930007254025, 9999.99999971592, -6.09459936849952E-05, 12.4853094377461, 2 ),
      ( 300, 40.1149577279888, 99999.9972754839, -0.000608264624276218, 12.4919182157143, 2 ),
      ( 300, 403.309432125102, 999999.999999323, -0.00596033651260445, 12.5576085097193, 2 ),
      ( 350, 0.343634170697205, 999.999999999999, -2.34836794679511E-06, 12.4849066613733, 2 ),
      ( 350, 3.43641414240496, 9999.99999998795, -2.34740646703188E-05, 12.4853472991011, 2 ),
      ( 350, 34.3713700371031, 99999.9998893322, -0.000233778261211172, 12.4897507933632, 2 ),
      ( 350, 344.405000090359, 999999.999999999, -0.00224053805803292, 12.5334931821736, 2 ),
      ( 350, 3477.39369773838, 10000000.0000274, -0.011807757622593, 12.9376417401944, 1 ),
      ( 350, 21737.7129874742, 100000000.000294, 0.58081647217566, 14.9967683423628, 1 ),
      ( 400, 0.300679259095869, 999.996875394957, -2.60731021833939E-07, 12.4852766193918, 2 ),
      ( 400, 3.00679960926499, 10000, -2.60008763451509E-06, 12.4855951754232, 2 ),
      ( 400, 30.0686779740053, 99999.9999999335, -2.52774924444793E-05, 12.4887788781287, 2 ),
      ( 400, 300.733351096621, 999999.999791025, -0.000180132879067475, 12.5204289324019, 2 ),
      ( 400, 2989.82152348311, 10000000.0000766, 0.00567601367052502, 12.8171261463276, 1 ),
      ( 400, 19716.1809782464, 100000000.00093, 0.525037630083387, 14.5958802283965, 1 ),
      ( 500, 0.240542930698961, 1000.01633518371, 1.68170678034066E-06, 12.4862271320406, 1 ),
      ( 500, 2.40539297238113, 10000.0000000023, 1.6820817777036E-05, 12.4864228454045, 1 ),
      ( 500, 24.0502792002236, 100000.000023699, 0.000168610531444924, 12.4883792482349, 1 ),
      ( 500, 240.128813881169, 999999.999999999, 0.00172627939830876, 12.507869686349, 1 ),
      ( 500, 2355.51031804371, 10000000.0000162, 0.0211941822678387, 12.6953177600979, 1 ),
      ( 500, 16611.0909982154, 100000000.000001, 0.448088769916702, 14.0641125675628, 1 ),
      ( 600, 0.200452300080616, 1000.01941538298, 2.37705929111582E-06, 12.48731930872, 1 ),
      ( 600, 2.00448020945997, 10000.0000000045, 2.37724580532063E-05, 12.4874569937403, 1 ),
      ( 600, 20.0405098283374, 100000.000046087, 0.000237957044120285, 12.48883354805, 1 ),
      ( 600, 199.972307169618, 1000000, 0.00240272728137685, 12.5025691410791, 1 ),
      ( 600, 1953.25776251486, 10000000.000003, 0.0262485061371586, 12.6368834864637, 1 ),
      ( 600, 14375.4848644091, 100000000, 0.394407131160141, 13.7330504656086, 1 ),
      };

      // TestData for 500 Permille to 500 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_500_500 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 300, 0.400926796187268, 999.999848113857, -4.46170337845277E-05, 18.8779873144597, 2 ),
      ( 350, 0.343645247365444, 999.999999998909, -2.63076271453006E-05, 19.0187465944213, 2 ),
      ( 350, 3.43726651730729, 9999.9999889773, -0.000263130181401525, 19.0249328718965, 2 ),
      ( 400, 0.300686654745082, 999.99999999979, -1.65412395222824E-05, 19.2102062685738, 2 ),
      ( 400, 3.00731430841741, 9999.99999790047, -0.00016542942148198, 19.2136828875437, 2 ),
      ( 400, 30.1180435109655, 99999.9999996609, -0.001655997655, 19.2485511438318, 2 ),
      ( 500, 0.240547084349344, 999.99999999999, -7.23158738064875E-06, 19.6920579614055, 2 ),
      ( 500, 2.40562741590183, 9999.99999988664, -7.23170096246653E-05, 19.6935033720607, 2 ),
      ( 500, 24.0719453046417, 99999.9988579919, -0.00072328276806269, 19.7079650483543, 2 ),
      ( 500, 242.300370251602, 999999.999999458, -0.0072431809294601, 19.8533174844864, 2 ),
      ( 600, 0.20045512179742, 999.995037302797, -3.26601957652751E-06, 20.2412892199421, 2 ),
      ( 600, 2.00461000946544, 9999.99999999403, -3.26594022909926E-05, 20.2420452991719, 2 ),
      ( 600, 20.0519923406808, 99999.9999277118, -0.00032649821313006, 20.249605851763, 2 ),
      ( 600, 201.109050570077, 1000000, -0.00325493336473302, 20.3251827257536, 2 ),
      ( 600, 2068.83053929193, 10000000.0000046, -0.0310735934965767, 21.0727051703244, 2 ),
      };

      // TestData for 999 Permille to 1 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_999_001 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 300, 0.401105412933375, 999.999999769159, -0.000481591640581388, 25.391938168553, 2 ),
      ( 300, 55508.4633878924, 10000000.0002373, -0.927774573558769, 73.8173149219203, 1 ),
      ( 300, 57515.9326724225, 100000000.000144, -0.302954459239249, 69.8045449390441, 1 ),
      ( 300, 68615.9217042319, 1000000000, 4.84284571221802, 61.5895445260034, 1 ),
      ( 350, 0.34370784619891, 999.999999727325, -0.000200111760529016, 25.5828542046035, 2 ),
      ( 350, 3.44332602724771, 9999.99982999569, -0.0020141470489375, 25.8740716130458, 2 ),
      ( 350, 54234.7328982305, 10000000.0000287, -0.936638562070133, 69.685921235276, 1 ),
      ( 350, 56203.4160601528, 99999999.9999793, -0.388579751364491, 67.1070795064399, 1 ),
      ( 400, 0.30071565284267, 999.99999999405, -0.000104650033269502, 25.9455213248815, 2 ),
      ( 400, 3.01000007461561, 9999.99993818661, -0.00104925087079042, 26.0474417388859, 2 ),
      ( 400, 30.3958968137002, 99999.9999987137, -0.0107737736130129, 27.1505578209125, 2 ),
      ( 400, 52251.6867615764, 10000000.0000148, -0.942454645662977, 65.1787617924612, 1 ),
      ( 400, 54439.8497798036, 100000000.003426, -0.447676317686991, 63.5349309301656, 1 ),
      ( 500, 0.2405571420816, 999.999999998941, -4.07210105625435E-05, 26.8999823882509, 2 ),
      ( 500, 2.40645400845016, 9999.99998924006, -0.000407464646683889, 26.9226539428419, 2 ),
      ( 500, 24.1537716624809, 99999.9999999996, -0.00410027172374564, 27.1548364614583, 2 ),
      ( 500, 251.556203105288, 999999.999999979, -0.0437630104832039, 30.055604229898, 2 ),
      ( 500, 46450.0693003873, 9999999.99999596, -0.948213780954331, 57.9705508616953, 1 ),
      ( 500, 49853.3841642508, 99999999.9999985, -0.517490436438106, 57.2697712749007, 1 ),
      ( 500, 63189.1948788401, 1000000000, 2.80677973208719, 55.0278427406592, 1 ),
      ( 600, 0.200460135881577, 999.999999999995, -2.00235414852935E-05, 27.9958918290166, 2 ),
      ( 600, 2.00496277209817, 9999.99999930108, -0.000200279280204645, 28.0041284268629, 2 ),
      ( 600, 20.0859284823121, 99999.9912073483, -0.00200719039641081, 28.0871394253112, 2 ),
      ( 600, 204.6563812549, 999999.999796331, -0.020523470944506, 28.982776661549, 2 ),
      ( 600, 2759.67766016532, 10000000.0000012, -0.273624869841835, 47.1314279333831, 2 ),
      ( 600, 43873.7682939787, 99999999.9999995, -0.543107123562843, 52.7222223764494, 1 ),
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