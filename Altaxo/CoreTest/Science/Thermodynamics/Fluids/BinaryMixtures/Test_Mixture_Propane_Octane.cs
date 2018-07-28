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
  /// Tests and test data for <see cref="Mixture_Propane_Octane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Propane_Octane : MixtureTestBase
  {

    public Test_Mixture_Propane_Octane()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("74-98-6", 0.5), ("111-65-9", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 250, 6452.50694272554, 100000.000000758, -0.992544189645013, 188.936408839641, 1 ),
      ( 250, 6457.95914709938, 1000000.00000218, -0.925504842964916, 188.99683973401, 1 ),
      ( 250, 6510.14108595143, 10000000.0000001, -0.261019578001872, 189.594039985293, 1 ),
      ( 250, 6891.78749351053, 100000000.009377, 5.98057914995338, 194.880331963715, 1 ),
      ( 300, 0.401540180352515, 999.999991959714, -0.00158044712469205, 180.362496943245, 2 ),
      ( 300, 6102.27336733252, 100000.000000133, -0.993430226029054, 206.706108413383, 1 ),
      ( 300, 6109.72322117481, 1000000.00463159, -0.934382368126188, 206.761526404272, 1 ),
      ( 300, 6179.72882046764, 10000000.0000049, -0.351257022851799, 207.312089476579, 1 ),
      ( 300, 6648.13063507801, 100000000.014082, 5.03035032526862, 212.181190856865, 1 ),
      ( 350, 0.343927862701682, 999.999975399662, -0.000856340256487104, 205.810658011887, 2 ),
      ( 350, 3.46624932510763, 9999.98553620037, -0.00863061020468815, 206.220424486849, 2 ),
      ( 350, 5741.21607344888, 100000.000001501, -0.994014624444904, 227.879517297356, 1 ),
      ( 350, 5751.77396499213, 1000000.00000052, -0.940256111329842, 227.927985996201, 1 ),
      ( 350, 5848.10871826606, 10000000.0000817, -0.412402607461133, 228.422656112889, 1 ),
      ( 350, 6421.40235021317, 99999999.9999993, 4.35137536442984, 232.975106939402, 1 ),
      ( 400, 0.300833031191965, 999.999995941127, -0.000511432198859131, 231.309229400807, 2 ),
      ( 400, 3.02231996367036, 9999.99999999948, -0.00513784405574515, 231.529542927251, 2 ),
      ( 400, 31.7842804841866, 99999.9999908296, -0.0540003708941511, 233.865925481871, 2 ),
      ( 400, 5367.08631896036, 1000000.00000002, -0.943977205205272, 250.217142533487, 1 ),
      ( 400, 5505.60727546705, 10000000.0009532, -0.453867374710393, 250.605852870052, 1 ),
      ( 400, 6207.65724173009, 99999999.9999995, 3.84368198492545, 254.861992517989, 1 ),
      ( 500, 0.240596527888302, 999.999999782598, -0.000221065094315318, 278.315765558373, 2 ),
      ( 500, 2.4107726075233, 9999.99772898967, -0.00221472665847207, 278.394502873532, 2 ),
      ( 500, 24.6097980846286, 99999.9998498176, -0.0225708493198606, 279.200315569049, 2 ),
      ( 500, 4355.72010920613, 1000000.00259619, -0.944775298927654, 293.977570876115, 1 ),
      ( 500, 4745.4189686166, 10000000.0000006, -0.493104103168271, 293.242802120008, 1 ),
      ( 500, 5811.32319747592, 100000000, 3.13921807857184, 296.669398744508, 1 ),
      ( 600, 0.200475162963466, 999.999999979679, -0.000111631293048787, 318.272470206164, 2 ),
      ( 600, 2.00676968388441, 9999.99979256876, -0.00111714225967746, 318.306787393296, 2 ),
      ( 600, 20.2734692677438, 99999.9999996458, -0.0112556411827207, 318.654010913656, 2 ),
      ( 600, 228.437464815781, 999999.999725251, -0.122504779012697, 322.594438164676, 2 ),
      ( 600, 3797.09732864395, 9999999.99996423, -0.472089424328263, 331.352667210169, 1 ),
      ( 600, 5451.11931411172, 99999999.9999999, 2.67727749313173, 333.103484424981, 1 ),
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
      ( 300, 0.401137863867772, 999.999999989504, -0.000576814759008678, 122.908189806466, 2 ),
      ( 300, 7749.94114284273, 1000000.00378765, -0.948269738343382, 139.352442699073, 1 ),
      ( 300, 7890.4441197539, 10000000.0000481, -0.491908851333607, 139.785255022324, 1 ),
      ( 300, 8713.95640487744, 100000000.000014, 3.60074004277969, 143.767641483894, 1 ),
      ( 350, 0.343748567487482, 999.999986443109, -0.000332918846751857, 140.633210806856, 2 ),
      ( 350, 3.44785337486058, 9999.99996992467, -0.00333891916377067, 140.741902175247, 2 ),
      ( 350, 7332.18014450357, 10000000.0000108, -0.5313343093906, 154.644642539568, 1 ),
      ( 350, 8376.32959486568, 99999999.9999712, 3.10244276108505, 158.388166009894, 1 ),
      ( 400, 0.300742704568112, 999.999995463905, -0.000208960504323088, 158.371111040793, 2 ),
      ( 400, 3.01310555549398, 9999.99999999974, -0.00209317037394386, 158.431288247979, 2 ),
      ( 400, 30.7224350194743, 100000.000147302, -0.0213019865769702, 159.04819992948, 2 ),
      ( 400, 6720.75479826054, 10000000.0005825, -0.552609981672345, 170.375265404561, 1 ),
      ( 400, 8056.00137348936, 99999999.9904618, 2.73237102695173, 173.736130166105, 1 ),
      ( 500, 0.240567081246148, 999.999999705051, -9.64066635121438E-05, 191.171432047373, 2 ),
      ( 500, 2.40776150710067, 9999.9969623468, -0.000964637329120152, 191.193592869978, 2 ),
      ( 500, 24.2901069199669, 99999.9999173624, -0.00970428077457952, 191.417735802729, 2 ),
      ( 500, 268.398385850148, 999999.999999998, -0.103780418743694, 193.948444510697, 2 ),
      ( 500, 5180.47557044398, 10000000.0129764, -0.535672186945393, 201.374587104458, 1 ),
      ( 500, 7462.00016719218, 99999999.9994961, 2.22358460983469, 203.097619064739, 1 ),
      ( 600, 0.200463258165959, 999.999999970507, -4.99710136995111E-05, 219.237284939536, 2 ),
      ( 600, 2.00553470218314, 9999.99970214723, -0.000499763985509433, 219.246950035286, 2 ),
      ( 600, 20.1461161150694, 99999.9999997455, -0.00500305034558002, 219.344142395865, 2 ),
      ( 600, 211.134042743575, 1000000.00108394, -0.0505877773321885, 220.369991903278, 2 ),
      ( 600, 3208.79721085897, 10000000, -0.375301000214722, 228.003961894963, 1 ),
      ( 600, 6927.72712448709, 100000000.008187, 1.89349215442671, 228.801956735298, 1 ),
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
      ( 250, 0.481221703075508, 999.999973511184, -0.000276022358311734, 56.0862699715499, 2 ),
      ( 250, 4.82423793474615, 9999.99957568996, -0.00276710707716754, 56.1481440073076, 2 ),
      ( 250, 12672.9432500488, 999999.999999869, -0.962038110198212, 66.1758614662649, 1 ),
      ( 250, 12935.8770489936, 10000000.0000207, -0.628097211113817, 66.5085126504122, 1 ),
      ( 250, 14415.6676233873, 99999999.999996, 2.33726392485712, 69.7068215477475, 1 ),
      ( 300, 0.400969560739556, 999.999996704552, -0.000155036216987633, 65.5018985856723, 2 ),
      ( 300, 4.0153067079683, 9999.99999999991, -0.00155224720384152, 65.5316599152146, 2 ),
      ( 300, 40.7308866151163, 100000.000162779, -0.0157165010589953, 65.836650079615, 2 ),
      ( 300, 11090.5131469605, 999999.999999661, -0.96385132133897, 73.9745969515468, 1 ),
      ( 300, 11614.5547285681, 10000000.0107698, -0.654823275004455, 73.8890508426088, 1 ),
      ( 300, 13675.3153249524, 100000000.000043, 1.93161354170034, 76.74793244152, 1 ),
      ( 350, 0.343667721385154, 999.999999967365, -9.54718212698602E-05, 75.4788891513078, 2 ),
      ( 350, 3.43963503284769, 9999.99517663332, -0.000955311598727576, 75.4947613613849, 2 ),
      ( 350, 34.6970503601556, 99999.9995969077, -0.00961347632815223, 75.6558068998523, 2 ),
      ( 350, 383.253603766379, 999999.999999999, -0.103374612985106, 77.5462173365096, 2 ),
      ( 350, 9985.81169681566, 10000000.0012693, -0.655876836781813, 82.8892516506113, 1 ),
      ( 350, 12971.223424829, 99999999.9999989, 1.64920971250969, 84.993596712378, 1 ),
      ( 400, 0.30069931253985, 999.99999987537, -6.24064885403862E-05, 85.4452983964257, 2 ),
      ( 400, 3.00868366703208, 9999.9987286327, -0.000624258806997741, 85.4539586439466, 2 ),
      ( 400, 30.2575324573496, 99999.9999926252, -0.00626216830264309, 85.5413481483077, 2 ),
      ( 400, 321.506625398887, 1000000.01600422, -0.0647765151593726, 86.5008978419363, 2 ),
      ( 400, 7592.54797409876, 10000000.0005256, -0.603979391390227, 93.2280001478103, 1 ),
      ( 400, 12302.9511932287, 100000000.000002, 1.44397089957684, 93.5978787302524, 1 ),
      ( 500, 0.240551492749771, 999.999999991468, -2.93292233373281E-05, 104.031645510314, 2 ),
      ( 500, 2.40615009109537, 9999.99991417747, -0.000293296531564784, 104.034703781258, 2 ),
      ( 500, 24.125212345648, 99999.9999999886, -0.00293338721256681, 104.065356451252, 2 ),
      ( 500, 247.822081855082, 1000000.00002333, -0.0293664077045049, 104.37903164127, 2 ),
      ( 500, 3253.63696615764, 10000000, -0.260690605426133, 107.702786196002, 1 ),
      ( 500, 11079.3404043408, 99999999.9999982, 1.1711079250446, 110.131307736133, 1 ),
      ( 600, 0.200456554253321, 999.999999999303, -1.42489008050633E-05, 120.204383704815, 2 ),
      ( 600, 2.00482260439361, 9999.99999301476, -0.000142468822503366, 120.205917012849, 2 ),
      ( 600, 20.0739282026133, 99999.9999999998, -0.00142266155071051, 120.221237479121, 2 ),
      ( 600, 203.303089659084, 999999.99933275, -0.0140154864061859, 120.373151935835, 2 ),
      ( 600, 2246.60877894836, 9999999.99999998, -0.107749867944743, 121.705148568125, 2 ),
      ( 600, 10014.7957422898, 100000000.01179, 1.00157550031751, 124.884587012691, 1 ),
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