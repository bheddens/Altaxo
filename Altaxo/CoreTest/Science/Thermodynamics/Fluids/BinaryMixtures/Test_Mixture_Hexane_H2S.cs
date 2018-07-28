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
  /// Tests and test data for <see cref="Mixture_Hexane_H2S"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Hexane_H2S : MixtureTestBase
  {

    public Test_Mixture_Hexane_H2S()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("110-54-3", 0.5), ("7783-06-4", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 200, 0.60152718815863, 999.999999782021, -0.000276120944440393, 25.1508670794169, 2 ),
      ( 200, 6.03030325334091, 9999.99736075218, -0.0027680713826668, 25.24267768261, 2 ),
      ( 200, 28446.4452373933, 100000.00000033, -0.997885988607476, 43.123262232386, 1 ),
      ( 200, 28468.5411274969, 1000000.00167583, -0.978876293936512, 43.1387710858503, 1 ),
      ( 200, 28681.5157765617, 10000000.0000006, -0.790331480879884, 43.2929975174395, 1 ),
      ( 200, 30300.1865015484, 100000000.000001, 0.984677862865784, 44.7094412161257, 1 ),
      ( 250, 0.481152254470951, 999.999999994854, -0.000131724101320411, 25.4295429877477, 2 ),
      ( 250, 4.81724143160771, 9999.99994727719, -0.00131873821061711, 25.4628120472303, 2 ),
      ( 250, 48.7594507536835, 99999.9999999701, -0.0133423004435904, 25.8008522240806, 2 ),
      ( 250, 25806.9234689315, 1000000.00363311, -0.981358146877848, 39.1344443566258, 1 ),
      ( 250, 26161.3997243299, 10000000.000002, -0.816107364211692, 39.280178738788, 1 ),
      ( 250, 28474.9290184268, 99999999.9999957, 0.689517381452604, 40.6797222979068, 1 ),
      ( 300, 0.400936939186294, 999.999999998382, -7.36855297653011E-05, 25.9259929297629, 2 ),
      ( 300, 4.01203202524517, 9999.99998356302, -0.000737298672118696, 25.940717026215, 2 ),
      ( 300, 40.3903533185021, 99999.9999999988, -0.00741795247992378, 26.0890917627291, 2 ),
      ( 300, 435.504162368182, 999999.999999984, -0.0794407250771699, 27.7430890233773, 2 ),
      ( 300, 23192.9614373952, 10000000.0016839, -0.827142645374074, 36.8926608197923, 1 ),
      ( 300, 26668.9211180495, 100000000.000879, 0.503275644950607, 38.2325340818582, 1 ),
      ( 350, 0.343650485366669, 999.999999999985, -4.53209451233767E-05, 26.592498907702, 2 ),
      ( 350, 3.43790772613213, 9999.99999783784, -0.000453362404430199, 26.6000083898338, 2 ),
      ( 350, 34.5205260909999, 100000, -0.00454903293592771, 26.6754512399351, 2 ),
      ( 350, 360.641461834327, 999999.990114773, -0.0471563939729385, 27.4694255983885, 2 ),
      ( 350, 18945.7177673414, 9999999.99999996, -0.81862132909202, 35.9824332701819, 1 ),
      ( 350, 24867.1461757166, 100000000.010497, 0.381883181950909, 36.7527955136164, 1 ),
      ( 400, 0.300689442275892, 999.999999999947, -2.95830947005452E-05, 27.3672262667659, 2 ),
      ( 400, 3.0076954057518, 9999.99999945238, -0.000295886423065773, 27.3714910798486, 2 ),
      ( 400, 30.1574545049179, 99999.9942924355, -0.00296443469615115, 27.4142691449053, 2 ),
      ( 400, 310.052020073216, 999999.999874095, -0.0302254864140269, 27.8556135107664, 2 ),
      ( 400, 5062.26447323093, 9999999.98963569, -0.406035483011781, 34.8407686173145, 2 ),
      ( 400, 23077.4376411564, 99999999.9999998, 0.302919984562799, 35.8956343622845, 1 ),
      ( 500, 0.240547785977795, 999.997872444706, -1.39199342110017E-05, 29.0838158809132, 2 ),
      ( 500, 2.40577926846285, 9999.99999999966, -0.000139203481416928, 29.0855641522623, 2 ),
      ( 500, 24.0879843316591, 99999.9999968776, -0.00139241935114322, 29.1030732848853, 2 ),
      ( 500, 243.950669546027, 999999.999999998, -0.0139627900634582, 29.2807817947077, 2 ),
      ( 500, 2805.0114005425, 9999999.99999999, -0.142447558270892, 31.2681251206862, 2 ),
      ( 500, 19650.235179208, 100000000.000102, 0.224130069527167, 35.3116896554883, 1 ),
      ( 600, 0.200455077303798, 999.998358201498, -6.88101188988146E-06, 30.9068234582154, 2 ),
      ( 600, 2.00467491293715, 9999.99999999993, -6.88057991972405E-05, 30.9077275531756, 2 ),
      ( 600, 20.0591627694547, 99999.9999992468, -0.000687614574721571, 30.9167760418897, 2 ),
      ( 600, 201.832543499331, 999999.993071431, -0.00683163124251219, 31.0079936196693, 2 ),
      ( 600, 2140.31431840641, 9999999.99999938, -0.0634380369093902, 31.9679794521286, 2 ),
      ( 600, 16661.753235788, 100000000, 0.20307686190609, 35.6056218491527, 1 ),
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
      ( 250, 0.481349110847391, 999.999999998421, -0.000542917580010358, 71.4691960355326, 2 ),
      ( 300, 0.401020778401996, 999.999999528572, -0.000285014594299696, 80.394832417462, 2 ),
      ( 300, 4.0205525929491, 9999.99500856336, -0.0028572616922123, 80.4865371183828, 2 ),
      ( 350, 0.343691986627037, 999.999999895271, -0.000168347008409529, 90.2083571332799, 2 ),
      ( 350, 3.44214415169027, 9999.9989160181, -0.00168583293102979, 90.2536946983312, 2 ),
      ( 350, 34.9613232885596, 99999.9860875268, -0.0171020555531776, 90.7151854871841, 2 ),
      ( 400, 0.300712141916297, 999.99999997081, -0.000107347496783556, 100.207596885982, 2 ),
      ( 400, 3.01003245900694, 9999.99970148734, -0.0010743560900169, 100.232399502333, 2 ),
      ( 400, 30.3972868025589, 99999.9999992636, -0.0108332258288472, 100.48319869223, 2 ),
      ( 500, 0.240555914434333, 999.999999998861, -4.99902813606516E-05, 118.970755031772, 2 ),
      ( 500, 2.40664226777266, 9999.99998847943, -0.000500023631453654, 118.980031225179, 2 ),
      ( 500, 24.1755663513655, 99999.9999999996, -0.00501239356063506, 119.073291241656, 2 ),
      ( 500, 253.581888393697, 1000000.00001243, -0.0514153416080523, 120.056789992996, 2 ),
      ( 500, 4785.09542871407, 9999999.99999999, -0.497305973182804, 128.354654668659, 1 ),
      ( 500, 9819.56646367003, 99999999.9999998, 1.44963858502755, 128.332175898731, 1 ),
      ( 600, 0.200458344230189, 999.99999999989, -2.54587379216564E-05, 135.221899583887, 2 ),
      ( 600, 2.00504283989357, 9999.99999890719, -0.000254573990121729, 135.226215072346, 2 ),
      ( 600, 20.0964575622214, 99999.988925396, -0.00254440241341106, 135.269500039669, 2 ),
      ( 600, 205.658552863083, 999999.9997977, -0.0253104574345725, 135.714686686144, 2 ),
      ( 600, 2560.79082297674, 9999999.99999998, -0.21722134031734, 140.123295061947, 2 ),
      ( 600, 8984.57925036767, 99999999.9999998, 1.23108100254707, 142.751392179407, 1 ),
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
      ( 200, 8609.19663701966, 100000.000000968, -0.993014930856019, 124.060380686556, 1 ),
      ( 200, 8615.26929088252, 1000000.00000168, -0.930198542905766, 124.108413710309, 1 ),
      ( 200, 8673.83372348142, 10000000.0000005, -0.30669831807453, 124.584090055282, 1 ),
      ( 250, 0.481825041636878, 999.991029948647, -0.00153241145860756, 117.553449179929, 2 ),
      ( 250, 8098.56930102338, 99999.9999991579, -0.994059609102417, 136.102870305746, 1 ),
      ( 250, 8107.02330148207, 1000000.00130101, -0.940658036510389, 136.146930128968, 1 ),
      ( 250, 8187.2514540713, 10000000.000002, -0.41239537656626, 136.584438054969, 1 ),
      ( 250, 8748.94714777821, 100000000.000001, 4.4987951425728, 140.504202906644, 1 ),
      ( 300, 0.401207595813415, 999.99998773132, -0.00075279852431554, 134.882858349245, 2 ),
      ( 300, 4.03967543851394, 9999.99033143704, -0.00757975128223159, 135.224132261666, 2 ),
      ( 300, 7577.39830650536, 99999.999999798, -0.994709192427386, 150.725798754936, 1 ),
      ( 300, 7589.59174673402, 1000000.01819417, -0.94717692497132, 150.765232871851, 1 ),
      ( 300, 7702.31797361188, 10000000.000031, -0.479500108031412, 151.164127167183, 1 ),
      ( 300, 8406.11452202612, 100000000.000001, 3.76921372261972, 154.829566208708, 1 ),
      ( 350, 0.343778755935922, 999.999998392075, -0.00042298284272587, 153.833703842305, 2 ),
      ( 350, 3.45098565956863, 9999.98249715232, -0.00424580134619712, 154.000218878022, 2 ),
      ( 350, 35.9526406799671, 99999.9999996253, -0.0442055523010187, 155.747763007991, 2 ),
      ( 350, 7035.55143380317, 999999.999999757, -0.951157582113051, 167.536543512451, 1 ),
      ( 350, 7201.52408602448, 10000000.0004992, -0.522832473612927, 167.861724061175, 1 ),
      ( 350, 8084.02734738282, 100000000.000001, 3.25076918537989, 171.304124945351, 1 ),
      ( 400, 0.300757538503905, 999.999999708918, -0.000260552109752239, 173.053209203206, 2 ),
      ( 400, 3.01466419237186, 9999.99693797787, -0.00261138041091019, 173.142919125905, 2 ),
      ( 400, 30.893682920682, 99999.9996088812, -0.0267292627497968, 174.065185282903, 2 ),
      ( 400, 6400.95545781228, 1000000.00000009, -0.953025891607207, 185.193805916755, 1 ),
      ( 400, 6667.07333716885, 10000000.0007734, -0.549008747454299, 185.313735236811, 1 ),
      ( 400, 7778.70725138536, 100000000, 2.86541318214014, 188.487018185819, 1 ),
      ( 500, 0.24057165048507, 999.999999998989, -0.000117678416607909, 208.859811308428, 2 ),
      ( 500, 2.4082698621278, 9999.99985275477, -0.00117779912800175, 208.892009382835, 2 ),
      ( 500, 24.3435681259933, 99999.9999997154, -0.0118813345935563, 209.217967249622, 2 ),
      ( 500, 276.970977509002, 999999.983445835, -0.131521492830761, 212.965699770924, 2 ),
      ( 500, 5393.49592156368, 10000000.001867, -0.554012195556614, 219.141928765785, 1 ),
      ( 500, 7211.83498169031, 100000000.000002, 2.33539717706889, 221.197467788308, 1 ),
      ( 600, 0.200464949254269, 999.999999998229, -6.06868807457357E-05, 239.538164666862, 2 ),
      ( 600, 2.00574536760529, 9999.99998210539, -0.000607021711071913, 239.552316894922, 2 ),
      ( 600, 20.1680133889641, 99999.9999999988, -0.00608562774639903, 239.694779393712, 2 ),
      ( 600, 213.818972397713, 1000000.00009547, -0.0625117059882167, 241.214210245766, 2 ),
      ( 600, 3648.63269736111, 9999999.99999998, -0.45060848737427, 249.768215703968, 1 ),
      ( 600, 6700.47557521814, 100000000.000002, 1.99162024264056, 249.676114647826, 1 ),
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
