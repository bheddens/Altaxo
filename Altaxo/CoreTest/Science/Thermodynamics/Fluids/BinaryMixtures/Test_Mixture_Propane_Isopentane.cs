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
  /// Tests and test data for <see cref="Mixture_Propane_Isopentane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Propane_Isopentane : MixtureTestBase
  {

    public Test_Mixture_Propane_Isopentane()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("74-98-6", 0.5), ("78-78-4", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 150, 10437.4012895566, 1000.00983276838, -0.999923177938923, 88.5269483861689, 1 ),
      ( 150, 10437.4580133935, 10000.0000020743, -0.99923179111744, 88.5274533135035, 1 ),
      ( 150, 10438.025086136, 100000.000011678, -0.99231832852463, 88.5325021650203, 1 ),
      ( 150, 10443.6793313362, 1000000.00000674, -0.923224874098187, 88.5829478185481, 1 ),
      ( 150, 10498.649468613, 10000000.001221, -0.23626862879391, 89.0830101361916, 1 ),
      ( 150, 10939.5137557322, 99999999.999989, 6.32952865583341, 93.6293505803775, 1 ),
      ( 250, 0.481475526209402, 999.99999896443, -0.000803049929912162, 93.9969893124938, 2 ),
      ( 250, 4.85013113153008, 9999.99990346736, -0.00809098895298689, 94.3343397064529, 2 ),
      ( 250, 9185.6679072867, 1000000.00135579, -0.947626140803199, 109.44291604243, 1 ),
      ( 250, 10024.2679430072, 100000000.000024, 3.7992420000813, 113.477623602556, 1 ),
      ( 300, 0.401075974205374, 999.999842917986, -0.000420310419738694, 111.178370537701, 2 ),
      ( 300, 4.02605820606256, 9999.99849988662, -0.00421857432145208, 111.321386996463, 2 ),
      ( 300, 8517.3337792287, 1000000.00000008, -0.95293041130482, 123.434964657697, 1 ),
      ( 300, 8681.30622386506, 9999999.99999993, -0.538194613310946, 123.772345570047, 1 ),
      ( 300, 9616.08289843872, 99999999.9999999, 3.1691341682683, 127.150968655566, 1 ),
      ( 350, 0.343720606153344, 999.999975805259, -0.000249312311584634, 128.112402037291, 2 ),
      ( 350, 3.44495551679584, 9999.99999998967, -0.00249825956211615, 128.181959405332, 2 ),
      ( 350, 35.2636407811207, 100000.001648837, -0.0255262797360867, 128.899506816027, 2 ),
      ( 350, 7752.0097449601, 1000000.00476356, -0.955671506447053, 138.333081422099, 1 ),
      ( 350, 8020.79057465068, 10000000.0054328, -0.571569773137754, 138.496297269688, 1 ),
      ( 350, 9228.58604962706, 100000000.000948, 2.72359222233702, 141.600239738524, 1 ),
      ( 350, 11939.9293726536, 1000000000, 27.7803136557514, 156.108950154032, 1 ),
      ( 400, 0.300728822033287, 999.999994997369, -0.00016052238312391, 144.515770489905, 2 ),
      ( 400, 3.011645727749, 9999.99999999975, -0.00160717591823719, 144.553128964263, 2 ),
      ( 400, 30.5654390325675, 100000.00015528, -0.0162727648124047, 144.933287833807, 2 ),
      ( 400, 372.239878211461, 999999.998601452, -0.192239826918184, 150.226200821553, 2 ),
      ( 400, 7275.4497762194, 9999999.99999996, -0.586718955426873, 153.452210715025, 1 ),
      ( 400, 8858.5423826758, 100000000.000222, 2.39424405661229, 156.144569513365, 1 ),
      ( 500, 0.240563006358987, 999.999999633914, -7.71843458966653E-05, 174.86575921817, 2 ),
      ( 500, 2.40730318130319, 9999.99623755344, -0.000772147858593089, 174.879140286106, 2 ),
      ( 500, 24.2423768338195, 99999.9999036681, -0.00775224997824939, 175.014049828702, 2 ),
      ( 500, 261.72449178175, 1000000.00000338, -0.0809249947414158, 176.48685988907, 2 ),
      ( 500, 5267.89567281812, 10000000.00104, -0.543376608769078, 183.071972177103, 1 ),
      ( 500, 8167.47083334157, 99999999.9999999, 1.9451520987185, 183.898302438311, 1 ),
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
      ( 200, 15187.2739745011, 999999999.999999, 38.5963816588401, 100.624579448707, 1 ),
      ( 250, 0.481316681043162, 999.999999998453, -0.000473292804404523, 75.0044448517775, 2 ),
      ( 250, 4.83386738337262, 9999.99782308669, -0.0047536688957099, 75.1506734390384, 2 ),
      ( 250, 10721.7263187106, 999999.99999725, -0.955129532067501, 87.5865755731985, 1 ),
      ( 250, 10884.1967767842, 10000000.0000001, -0.557993219727496, 87.9679728903809, 1 ),
      ( 250, 11896.4818532934, 99999999.9999971, 3.04395924151459, 91.3697319926071, 1 ),
      ( 300, 0.401010851810988, 999.999975896465, -0.000257983144877089, 88.3033037135328, 2 ),
      ( 300, 4.01946632409459, 9999.99999106592, -0.00258550403341802, 88.3693588991254, 2 ),
      ( 300, 41.1802376855499, 99999.9999999997, -0.0264568144819383, 89.0554365444055, 2 ),
      ( 300, 9748.06639367856, 1000000.00000002, -0.958873136314726, 98.3511750569902, 1 ),
      ( 300, 10016.5294099685, 10000000.0011281, -0.599754184907484, 98.6090167374461, 1 ),
      ( 300, 11358.2880155817, 100000000.000007, 2.52964634474718, 101.784082651474, 1 ),
      ( 350, 0.343688746464513, 999.999995989319, -0.000156636178638043, 101.755769427839, 2 ),
      ( 350, 3.44174660056451, 9999.99999999985, -0.0015682377188532, 101.789383860193, 2 ),
      ( 350, 34.9178304014856, 100000.000153297, -0.0158755328934345, 102.132377202976, 2 ),
      ( 350, 9038.13051624139, 10000000.0000763, -0.619794257499478, 110.378828529055, 1 ),
      ( 350, 10846.126412285, 100000000.000126, 2.1682731632542, 113.165992992724, 1 ),
      ( 350, 14438.0107510531, 1000000000, 22.8007103816084, 126.968349528771, 1 ),
      ( 400, 0.30071123069665, 999.999999138829, -0.000102032673317544, 114.93661747474, 2 ),
      ( 400, 3.00987858471696, 9999.99101498357, -0.00102100420598527, 114.955230492595, 2 ),
      ( 400, 30.3803348411905, 99999.9987560659, -0.0102790176464422, 115.143753815955, 2 ),
      ( 400, 338.259569924858, 1000000.00005588, -0.111095220778682, 117.338235465177, 2 ),
      ( 400, 7847.44068761679, 10000000.0077871, -0.616842534399107, 122.738893387967, 1 ),
      ( 400, 10357.9043008859, 100000000.006312, 1.90290911759723, 124.776160026345, 1 ),
      ( 500, 0.240556229943502, 999.999999937036, -4.90167426428571E-05, 139.396757944696, 2 ),
      ( 500, 2.40662420834137, 9999.99936237666, -0.000490239255099994, 139.403430627146, 2 ),
      ( 500, 24.1731245095346, 99999.999998786, -0.00490961120251428, 139.47053686699, 2 ),
      ( 500, 253.164033978298, 1000000.00046325, -0.0498475045023161, 140.180731942254, 2 ),
      ( 500, 4303.51889956514, 10000000.016282, -0.441051743346369, 146.69709002093, 1 ),
      ( 500, 9453.6447654767, 100000000, 1.54446242299181, 146.971261012811, 1 ),
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
      ( 150, 15143.3457117765, 1000000.00085478, -0.947051674616669, 59.0504486705141, 1 ),
      ( 150, 15245.4105019959, 9999999.99999901, -0.47406152466233, 59.4391899501862, 1 ),
      ( 150, 16041.3330512594, 100000000.000006, 3.99842994951541, 62.6240384199528, 1 ),
      ( 200, 0.601701927330941, 999.999999636726, -0.000566444386491712, 47.7458821985037, 2 ),
      ( 200, 6.04806589544142, 10000.000230973, -0.00569685087630112, 47.8661645892295, 2 ),
      ( 200, 13970.5355024719, 1000000.00128219, -0.956955043193711, 61.0484144388048, 1 ),
      ( 200, 14128.2624700538, 10000000.0000004, -0.574355942266379, 61.4648363799245, 1 ),
      ( 200, 15210.9421790585, 100000000.000339, 2.95347697450033, 64.8015426733406, 1 ),
      ( 250, 0.48122140302151, 999.999973704941, -0.000275394435525728, 56.0234650289827, 2 ),
      ( 250, 4.82420741924051, 9999.99957861023, -0.00276079452768649, 56.0851260600773, 2 ),
      ( 250, 49.5116918862155, 100000.003712399, -0.0283327867474201, 56.731057638129, 2 ),
      ( 250, 12684.3413078848, 1000000.00000095, -0.962072222305869, 66.0997836322885, 1 ),
      ( 250, 12947.7266756873, 10000000.0000186, -0.628437571034833, 66.4319576854417, 1 ),
      ( 250, 14429.5912314683, 99999999.9999971, 2.33404369953452, 69.6278781222007, 1 ),
      ( 250, 18554.7295019371, 1000000000, 24.9280997478002, 84.7283279365055, 1 ),
      ( 300, 0.400969429004731, 999.999996727344, -0.000154703157470873, 65.4327112109543, 2 ),
      ( 300, 4.01529329589452, 9999.9999999999, -0.00154890757787509, 65.462374089777, 2 ),
      ( 300, 40.7294658932813, 100000.000160961, -0.0156821628649931, 65.7663416550776, 2 ),
      ( 300, 11098.4430471635, 1000000.00000058, -0.963877149608791, 73.8974586705987, 1 ),
      ( 300, 11623.8848287821, 10000000.0106181, -0.65510033514561, 73.8094172552874, 1 ),
      ( 300, 13688.0969828842, 100000000.000047, 1.92887607583557, 76.6651505236077, 1 ),
      ( 300, 18233.0325363168, 1000000000, 20.9879713903477, 90.835829409573, 1 ),
      ( 350, 0.34366765511229, 999.999999967582, -9.52744297912421E-05, 75.4011452157273, 2 ),
      ( 350, 3.43962824250991, 9999.9952092519, -0.000953334773990457, 75.4169637086903, 2 ),
      ( 350, 34.6963475198264, 99999.999604562, -0.00959340964608428, 75.5774600260703, 2 ),
      ( 350, 383.151059355684, 1000000, -0.103134641072695, 77.4607806724182, 2 ),
      ( 350, 9991.17243206977, 10000000.0013428, -0.656061473515648, 82.8050479157706, 1 ),
      ( 350, 12982.9024620622, 100000000.000003, 1.64682657346147, 84.904131849792, 1 ),
      ( 350, 17936.0989036333, 1000000000, 18.1588435266026, 98.210895775877, 1 ),
      ( 400, 0.300699275885143, 999.999999876185, -6.22800278661804E-05, 85.3584355363583, 2 ),
      ( 400, 3.00867987050748, 9999.99873701914, -0.000622993170628196, 85.3670650010872, 2 ),
      ( 400, 30.2571440562207, 99999.9999927466, -0.00624940747145536, 85.4541422639421, 2 ),
      ( 400, 321.458610068456, 1000000.01592844, -0.0646368192857959, 86.4100734017513, 2 ),
      ( 400, 7589.11265688924, 10000000.0006282, -0.603800125350613, 93.1418342709629, 1 ),
      ( 400, 12313.578374072, 99999999.9999987, 1.44186165216589, 93.5006629529529, 1 ),
      ( 500, 0.240551479359036, 999.999999991526, -2.92689879413097E-05, 103.928098823126, 2 ),
      ( 500, 2.40614865203326, 9999.99991474786, -0.000292694061015488, 103.931146519557, 2 ),
      ( 500, 24.1250663990696, 99999.9999999888, -0.00292735081894608, 103.96169283824, 2 ),
      ( 500, 247.806368328171, 1000000.00002287, -0.0293048549020069, 104.274242528123, 2 ),
      ( 500, 3251.183592564, 10000000, -0.260132712250233, 107.585785483196, 1 ),
      ( 500, 11088.0691889856, 99999999.9999989, 1.16939878856122, 110.019363669339, 1 ),
      ( 500, 17152.2082962437, 1000000000, 13.0241089955379, 121.461983466771, 1 ),
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
