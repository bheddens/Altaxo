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
	/// Tests and test data for <see cref="Mixture_CO2_Octane"/>.
	/// </summary>
	/// <remarks>
	/// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
	/// </remarks>
  [TestFixture]
  public class Test_Mixture_CO2_Octane : MixtureTestBase
    {

    public Test_Mixture_CO2_Octane()
      {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[]{("124-38-9", 0.5), ("111-65-9", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 100, 7636.80777746112, 1000.00007178185, -0.999842510533563, 150.321176454317, 1 ),
      ( 100, 7636.82972212773, 10000.0071694372, -0.998425108844471, 150.322383171713, 1 ),
      ( 100, 7637.04913385266, 99999.9999985146, -0.984251552197951, 150.334448604035, 1 ),
      ( 100, 7639.2397659253, 1000000.00000532, -0.842560682301763, 150.454930360291, 1 ),
      ( 100, 7660.80623150353, 9999999.99999457, 0.569960993827705, 151.643010251739, 1 ),
      ( 100, 7849.13674668973, 99999999.9999958, 14.3229168415017, 162.231662973574, 1 ),
      ( 150, 7190.68403405774, 100000.00000081, -0.988849306586291, 168.08366308289, 1 ),
      ( 150, 7193.70926699688, 1000000.00003744, -0.888539958837258, 168.16417240912, 1 ),
      ( 150, 7223.28365748402, 10000000.0001431, 0.110036887674113, 168.960016121562, 1 ),
      ( 150, 7468.89269681437, 100000000.001239, 9.73534141592745, 176.160846275803, 1 ),
      ( 200, 6810.08755119463, 99999.9999998591, -0.99116959446231, 176.650053497768, 1 ),
      ( 200, 6814.14824095728, 1000000.00000562, -0.911748566809071, 176.717523301285, 1 ),
      ( 200, 6853.49502193646, 9999999.9999998, -0.122552294652456, 177.383932594461, 1 ),
      ( 200, 7162.14484245113, 100000000.002143, 7.39634441187069, 183.343104327282, 1 ),
      ( 250, 6454.80949328447, 100000.000000489, -0.992546849305261, 188.913998828649, 1 ),
      ( 250, 6460.26210497849, 1000000.00000061, -0.925531399380956, 188.974700178243, 1 ),
      ( 250, 6512.44884494574, 10000000.0000012, -0.261281447344762, 189.574261492728, 1 ),
      ( 250, 6894.16018085566, 100000000.003422, 5.9781766884534, 194.868832168832, 1 ),
      ( 300, 0.401539838864254, 999.999991985616, -0.00157960258515676, 180.326004822919, 2 ),
      ( 300, 6104.38419998679, 100000.000001167, -0.993432497818582, 206.679016956047, 1 ),
      ( 300, 6111.83565185054, 1000000.00468727, -0.934405047811367, 206.734548386039, 1 ),
      ( 300, 6181.85695753603, 10000000.0000049, -0.35148035902914, 207.286038043116, 1 ),
      ( 300, 6650.38002042962, 100000000.005141, 5.02831062704893, 212.157140305105, 1 ),
      ( 350, 0.343927696945761, 999.999975572375, -0.000855863285867143, 205.766372874572, 2 ),
      ( 350, 3.46623236371745, 9999.98556115604, -0.00862576367534017, 206.175967751679, 2 ),
      ( 350, 5743.12571024324, 100000.000001636, -0.994016614659113, 227.843634889856, 1 ),
      ( 350, 5753.68695604691, 999999.99999979, -0.940275975305104, 227.892156696846, 1 ),
      ( 350, 5850.0525700959, 10000000.000082, -0.412597856642039, 228.38720207762, 1 ),
      ( 350, 6423.5301942483, 100000000.007323, 4.34960265588562, 232.939710399469, 1 ),
      ( 400, 0.300832942427059, 999.999995969901, -0.000511141853986062, 231.256939166042, 2 ),
      ( 400, 3.02231104507696, 9999.99999999946, -0.00513491284556725, 231.477142668953, 2 ),
      ( 400, 31.7831870970745, 99999.9999891371, -0.0539678314760659, 233.812289194087, 2 ),
      ( 400, 5368.77276964887, 1000000.00000016, -0.943994803464514, 250.171830641081, 1 ),
      ( 400, 5507.35267145241, 10000000.0009486, -0.454040458130341, 250.560669709753, 1 ),
      ( 400, 6209.66715985065, 100000000.009939, 3.84211418127525, 254.816269867407, 1 ),
      ( 500, 0.240596495680009, 999.999999784162, -0.000220935824718624, 278.248222290799, 2 ),
      ( 500, 2.41076946093728, 9999.99774544158, -0.00221342889271153, 278.326914382207, 2 ),
      ( 500, 24.6094576718358, 99999.9998522982, -0.0225573334008709, 279.132251565984, 2 ),
      ( 500, 4356.61800212298, 1000000.00247204, -0.944786680920265, 293.915536339146, 1 ),
      ( 500, 5813.11228264861, 100000000.015903, 3.13794414477138, 296.605631360526, 1 ),
      ( 600, 0.200475148341673, 999.999999979827, -0.000111562935315908, 318.191479029062, 2 ),
      ( 600, 2.00676829899749, 9999.99979408348, -0.00111645748799914, 318.225776654606, 2 ),
      ( 600, 20.2733262592109, 99999.9999996513, -0.0112486710756111, 318.572799082492, 2 ),
      ( 600, 228.415123666762, 999999.999729851, -0.122418955732273, 322.510507570421, 2 ),
      ( 600, 3797.61840310119, 9999999.9999621, -0.472161861801044, 331.275324179577, 1 ),
      ( 600, 5452.71097874808, 99999999.9999997, 2.67620406668728, 333.024719368096, 1 ),
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
      ( 250, 11291.9648655961, 100000000.000113, 3.26043371827929, 121.494251437133, 1 ),
      ( 300, 0.401059617283537, 999.999999996527, -0.000384111951342672, 104.664864608587, 2 ),
      ( 300, 9697.30119508116, 10000000.0002074, -0.586580268639869, 124.86105282463, 1 ),
      ( 300, 10775.2809016182, 99999999.9993448, 2.7206043085958, 128.63159201642, 1 ),
      ( 350, 0.343709221057027, 999.999997028772, -0.000220765700886703, 118.495871672944, 2 ),
      ( 350, 3.44395045705192, 9999.99999389485, -0.00221171548127855, 118.568450047361, 2 ),
      ( 350, 8850.61400388538, 10000000, -0.611740675055113, 134.974724597736, 1 ),
      ( 350, 10285.6610063451, 99999999.9995098, 2.34089701805458, 138.283336022449, 1 ),
      ( 400, 0.30072062979388, 999.999999433932, -0.000137854444457639, 132.229549591954, 2 ),
      ( 400, 3.01094680637642, 9999.99409561687, -0.00137998543344436, 132.268744470724, 2 ),
      ( 400, 30.4932194191222, 100000.000001296, -0.0139474282500239, 132.666632476761, 2 ),
      ( 400, 9821.30005545179, 99999999.9999782, 2.06150074247588, 148.898428011711, 1 ),
      ( 500, 0.240558332471493, 999.999999965068, -6.23265739298132E-05, 157.401245054574, 2 ),
      ( 500, 2.40693400407805, 9999.99964542584, -0.000623453353593791, 157.415703730242, 2 ),
      ( 500, 24.2057028630149, 99999.9999994955, -0.00625344090172805, 157.561222246143, 2 ),
      ( 500, 257.148140904604, 1000000, -0.0645729016410228, 159.114018334689, 2 ),
      ( 500, 8966.16671239593, 100000000.00004, 1.68278905591115, 169.764385594192, 1 ),
      ( 600, 0.200459023353736, 999.999999996859, -3.11315897157244E-05, 178.742215369682, 2 ),
      ( 600, 2.0051520290335, 9999.99996844021, -0.000311298877001702, 178.748830952739, 2 ),
      ( 600, 20.1078395472939, 99999.9999999982, -0.00311128763784902, 178.815196329972, 2 ),
      ( 600, 206.852914149121, 1000000.00000538, -0.0309404942628727, 179.498564116207, 2 ),
      ( 600, 2670.42805124091, 10000000, -0.249360855640661, 185.807134536006, 1 ),
      ( 600, 8209.90860591926, 100000000, 1.44159578830319, 188.325142249483, 1 ),
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
      ( 100, 35300.1992176559, 1000.00000556712, -0.999965928898009, -1.48381778199202, 1 ),
      ( 100, 35300.2556513471, 10000.0028099212, -0.999659289426828, -1.48011256141329, 1 ),
      ( 100, 35300.8199777503, 100000.000002448, -0.996592949689799, -1.44306721545864, 1 ),
      ( 100, 35306.4621885938, 1000000.00002116, -0.965934941595803, -1.07329777046568, 1 ),
      ( 100, 35362.776709761, 10000000.0008507, -0.659891895241265, 2.5566807300609, 1 ),
      ( 100, 35913.215335281, 99999999.9999781, 2.34895298358941, 32.7572395140199, 1 ),
      ( 150, 31586.5176454747, 10000.0163015832, -0.999746153581505, 46.065944681824, 1 ),
      ( 150, 31588.0802315331, 100000.000001872, -0.997461665523492, 46.0787918710376, 1 ),
      ( 150, 31603.6730888534, 1000000.00000101, -0.974629179060015, 46.2065108215469, 1 ),
      ( 150, 31756.3948080721, 10000000.0000397, -0.747511915054579, 47.4123747630707, 1 ),
      ( 150, 33035.0923989312, 99999999.9999943, 1.42714965437339, 54.9498605156468, 1 ),
      ( 200, 28027.3148237599, 1000000.00026491, -0.978543847237702, 44.2001166937093, 1 ),
      ( 200, 28335.4361800984, 9999999.99999832, -0.787771628284317, 44.745820935213, 1 ),
      ( 200, 30471.3685946784, 99999999.9999998, 0.973519326408025, 47.8006762043171, 1 ),
      ( 250, 0.481129513421684, 999.999999863942, -8.90297329191036E-05, 26.6563971183098, 2 ),
      ( 250, 4.81515658889157, 9999.9984740804, -0.000890895708297476, 26.6781475562022, 2 ),
      ( 300, 0.400925166325945, 999.999999983925, -4.88890103667036E-05, 29.0635334644544, 2 ),
      ( 300, 4.01101718924885, 9999.99983700092, -0.00048903662360678, 29.0730366057575, 2 ),
      ( 300, 40.2881752378282, 99999.9999999182, -0.00490512877703374, 29.1685772182213, 2 ),
      ( 300, 422.29397229513, 999999.999999996, -0.0506481460948963, 30.1819194969744, 2 ),
      ( 300, 18214.2584958375, 9999999.99914874, -0.779894654752789, 41.9148329851711, 1 ),
      ( 300, 25595.6131940546, 100000000.019704, 0.566305767008584, 41.7776799469483, 1 ),
      ( 350, 0.343643363944002, 999.999999999855, -2.91642305369551E-05, 31.2549351817089, 2 ),
      ( 350, 3.43733601075747, 9999.9999790012, -0.000291677117128482, 31.2598457102367, 2 ),
      ( 350, 34.4639781178337, 99999.9999999989, -0.00292026452507054, 31.3090870230435, 2 ),
      ( 350, 354.102104253477, 1000000.00002269, -0.0295642479337277, 31.8154273246491, 2 ),
      ( 350, 5218.99101510785, 9999999.9999004, -0.341571309747449, 38.5710984400986, 2 ),
      ( 350, 23296.3060578315, 100000000.000693, 0.475055062371838, 40.9773788028643, 1 ),
      ( 400, 0.300684653939811, 999.99999999951, -1.8224479501326E-05, 33.2181186102967, 2 ),
      ( 400, 3.00733982170012, 9999.99999506833, -0.000182247616615449, 33.2209619747554, 2 ),
      ( 400, 30.122824044583, 99999.9999999998, -0.00182275847096857, 33.2494372215871, 2 ),
      ( 400, 306.270364609085, 999999.996917605, -0.0182557345385303, 33.5382741295854, 2 ),
      ( 400, 3675.29638753201, 9999999.99632677, -0.181891356675692, 36.6939979195551, 2 ),
      ( 400, 21150.2226232964, 100000000.005138, 0.421635977479994, 40.8360795561321, 1 ),
      ( 500, 0.240545127910206, 999.999999999977, -7.4356750547063E-06, 36.5599137658659, 2 ),
      ( 500, 2.40561224605716, 9999.99999977826, -7.43482701567907E-05, 36.5611117403306, 2 ),
      ( 500, 24.0722107856527, 99999.9978147857, -0.000742634564805932, 36.5730953144773, 2 ),
      ( 500, 242.322322360615, 999999.999998772, -0.00734139154462722, 36.6932724842831, 2 ),
      ( 500, 2570.30460132844, 9999999.9998735, -0.0641446186158356, 37.8862060445349, 2 ),
      ( 500, 17498.1320864066, 100000000, 0.374680097891708, 41.5386689677941, 1 ),
      ( 600, 0.200453335264834, 1000, -2.70230568307745E-06, 39.2953574215818, 2 ),
      ( 600, 2.00458198299679, 9999.99999999239, -2.70158769232067E-05, 39.2959784513532, 2 ),
      ( 600, 20.0506807579323, 99999.9999270132, -0.000269441393385026, 39.3021882579447, 2 ),
      ( 600, 200.979977447225, 999999.999999999, -0.00262312051011454, 39.3642241854822, 2 ),
      ( 600, 2043.99536111836, 9999999.99981531, -0.0193090133236245, 39.9665870106617, 2 ),
      ( 600, 14744.738655191, 100000000.001474, 0.359486847713694, 42.7518457733696, 1 ),
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
