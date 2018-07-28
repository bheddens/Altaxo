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
  /// Tests and test data for <see cref="Mixture_Isobutane_Helium"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Isobutane_Helium : MixtureTestBase
  {

    public Test_Mixture_Isobutane_Helium()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("75-28-5", 0.5), ("7440-59-7", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 200, 0.601356671448285, 1000.00000000002, 7.35870015784211E-06, 12.5227717541234, 1 ),
      ( 200, 6.01316847941008, 10000.0000002309, 7.35863477997436E-05, 12.522908906848, 1 ),
      ( 200, 60.0918941781547, 100000.002294746, 0.000735797874763415, 12.5242800327771, 1 ),
      ( 200, 596.97263070733, 1000000.00000168, 0.0073512012421666, 12.5379511850613, 1 ),
      ( 200, 5605.61430253223, 10000000.0154146, 0.0727835777825162, 12.6706635167151, 1 ),
      ( 250, 0.481086079202422, 1000.00000000001, 5.8162542474576E-06, 12.5348770209287, 1 ),
      ( 250, 4.81060897879302, 10000.0000000727, 5.81619545370745E-05, 12.5349855363833, 1 ),
      ( 250, 48.0809257568821, 100000.000723017, 0.00058156067121072, 12.5360704122742, 1 ),
      ( 250, 478.310066479377, 1000000.00000014, 0.00580964319557268, 12.5468913441341, 1 ),
      ( 250, 4549.36772382828, 10000000.0004505, 0.0574851419522176, 12.6523575475207, 1 ),
      ( 300, 0.4009054866363, 1000, 4.76703755591425E-06, 12.5480731967159, 1 ),
      ( 300, 4.00888287461759, 10000.0000000276, 4.76699036884261E-05, 12.5481622166817, 1 ),
      ( 300, 40.0716395570344, 100000.00027446, 0.000476651816832838, 12.5490522158597, 1 ),
      ( 300, 399.00741804438, 1000000.00000002, 0.0047617653929608, 12.5579321928625, 1 ),
      ( 300, 3828.60053196775, 10000000.0000226, 0.0471382282387176, 12.6447658276921, 1 ),
      ( 350, 0.343633533457251, 1000, 4.01274911923691E-06, 12.5618147708792, 1 ),
      ( 350, 3.4362112384672, 10000.0000000119, 4.0127118891659E-05, 12.5618897592276, 1 ),
      ( 350, 34.349708968051, 100000.000119096, 0.00040123394404148, 12.5626394935753, 1 ),
      ( 350, 342.262916782642, 1000000, 0.00400860133564444, 12.5701219492759, 1 ),
      ( 350, 3305.09816913361, 10000000.0000017, 0.0397116660002031, 12.6434850862741, 1 ),
      ( 400, 0.300679511779865, 1000.01820870329, 3.4474077137329E-06, 12.5753664259295, 1 ),
      ( 400, 3.00670183276333, 10000.0000000057, 3.44731539828256E-05, 12.5754308845598, 1 ),
      ( 400, 30.0576938857252, 100000.000057158, 0.000344701988974874, 12.5760753579999, 1 ),
      ( 400, 299.648541231968, 1000000, 0.00344405845328222, 12.5825086952337, 1 ),
      ( 400, 2907.52758557933, 10000000.0000001, 0.0341451266607593, 12.6457229297175, 1 ),
      ( 500, 0.24054378562822, 1000.01099392614, 2.66161483306395E-06, 12.6001768914931, 1 ),
      ( 500, 2.40538036581115, 10000.0000000017, 2.66156640476421E-05, 12.6002266972039, 1 ),
      ( 500, 24.048043783903, 100000.000016414, 0.000266137330097257, 12.6007246832486, 1 ),
      ( 500, 239.906421718083, 1000000, 0.00265944086504227, 12.6056973881915, 1 ),
      ( 500, 2343.5689024806, 10000000.0019009, 0.0264022466215727, 12.6547206732512, 1 ),
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
      ( 200, 0.601385629317041, 999.992881830098, -4.07932772261005E-05, 37.99624707726, 2 ),
      ( 250, 0.481097875117769, 999.999999998738, -1.8702631750816E-05, 44.0503297636252, 2 ),
      ( 250, 4.81178838255169, 9999.99998742523, -0.000186959455672647, 44.0515903879687, 2 ),
      ( 250, 48.1986780556914, 100000.000324532, -0.00186292088091549, 44.0641761748962, 2 ),
      ( 300, 0.400910739863336, 999.999999999955, -8.33625840464634E-06, 50.6494476448115, 2 ),
      ( 300, 4.00940797898683, 9999.99999955913, -8.33043956737136E-05, 50.6502300936319, 2 ),
      ( 300, 40.1239318134085, 100000, -0.000827237888282439, 50.6580417658727, 2 ),
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
      ( 200, 0.601932308274481, 999.999999992682, -0.00094896322194864, 63.5041649099036, 2 ),
      ( 250, 0.481304357520082, 999.999999999691, -0.000447700494152194, 75.5786739348052, 2 ),
      ( 250, 4.83263129203439, 9999.99999633048, -0.00449910564426335, 75.6988036839579, 2 ),
      ( 300, 0.401006830087893, 999.999999999562, -0.000247956674599255, 88.7566828292271, 2 ),
      ( 300, 4.01906205927423, 9999.99999545503, -0.00248517724578208, 88.8112473650795, 2 ),
      ( 300, 41.1373432983412, 99999.9999999996, -0.025441689658218, 89.3924897299307, 2 ),
      ( 300, 9453.45634188621, 999999.999999574, -0.957591447691851, 98.1566380935324, 1 ),
      ( 300, 9742.92105167584, 10000000.0024124, -0.588514167636746, 98.5932299103165, 1 ),
      ( 350, 0.343687005727738, 999.999999999953, -0.000151572082910857, 102.483192672744, 2 ),
      ( 350, 3.44157170321729, 9999.99999950605, -0.00151749838180971, 102.511577951573, 2 ),
      ( 350, 34.8994653819034, 99999.9923174726, -0.0153576594100491, 102.804111820848, 2 ),
      ( 350, 418.803840453846, 999999.999983171, -0.179484810831701, 106.937350241613, 2 ),
      ( 350, 8752.44895379741, 10000000, -0.607384271320841, 110.574773382087, 1 ),
      ( 400, 0.300710254050146, 999.997816955754, -9.87849899796118E-05, 116.021150334744, 2 ),
      ( 400, 3.0097805986293, 9999.99999996526, -0.00098848247326671, 116.03764666051, 2 ),
      ( 400, 30.3702033215087, 99999.9994243036, -0.00994884617126138, 116.205246926589, 2 ),
      ( 400, 336.745179217244, 999999.999469111, -0.107097690171203, 118.202038877066, 2 ),
      ( 400, 7543.32768195192, 10000000.000001, -0.60139535095991, 123.36956897437, 1 ),
      ( 500, 0.240555760240437, 999.997826465353, -4.70641614657099E-05, 140.807364713584, 2 ),
      ( 500, 2.40657718704593, 9999.99999999888, -0.000470710204145679, 140.814231819287, 2 ),
      ( 500, 24.1683705506858, 99999.9999865688, -0.00471387526337781, 140.883185838671, 2 ),
      ( 500, 252.62751637511, 999999.99999999, -0.0478296184350767, 141.601912563991, 2 ),
      ( 500, 4081.45463670991, 10000000, -0.410640420949058, 147.685815861858, 1 ),
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
