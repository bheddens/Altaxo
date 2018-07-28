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
  /// Tests and test data for <see cref="Mixture_Nitrogen_Pentane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Nitrogen_Pentane : MixtureTestBase
  {

    public Test_Mixture_Nitrogen_Pentane()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("7727-37-9", 0.5), ("109-66-0", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 150, 10489.2831737122, 100000.000004918, -0.992355901738165, 103.99949517145, 1 ),
      ( 150, 10494.5968876766, 1000000.00002705, -0.923597720057591, 104.050828881441, 1 ),
      ( 150, 10546.3665275261, 10000000.0000027, -0.239727607797966, 104.558809290167, 1 ),
      ( 150, 10967.1499163977, 100000000.000009, 6.31102553621356, 109.139467358055, 1 ),
      ( 200, 9863.87869092261, 99999.9999995657, -0.993903429309, 107.196681659785, 1 ),
      ( 200, 9871.34473637451, 1000000.0000003, -0.939080402590338, 107.242536717633, 1 ),
      ( 200, 9943.19306508979, 10000000.0000011, -0.395206002483424, 107.695999881943, 1 ),
      ( 200, 10485.4297693386, 100000000.000007, 4.73518073618178, 111.714460715821, 1 ),
      ( 250, 0.481518470872582, 999.999977961148, -0.000896730446512271, 97.7314624742156, 2 ),
      ( 250, 9241.45396668815, 99999.999998428, -0.994794253436097, 114.353685336765, 1 ),
      ( 250, 9252.21580136741, 1000000.00286028, -0.948003084909462, 114.39553257059, 1 ),
      ( 250, 9353.75151671811, 10000000.0000013, -0.485675156417671, 114.811920630509, 1 ),
      ( 250, 10046.9241712156, 99999999.9999968, 3.78839762688644, 118.504207123416, 1 ),
      ( 300, 0.401091630501053, 999.999997893341, -0.000463896514342174, 112.216101378188, 2 ),
      ( 300, 4.02781699779235, 9999.99999999989, -0.00465794320015158, 112.383589861154, 2 ),
      ( 300, 8599.78629200483, 1000000.00000003, -0.953381915331533, 125.449548393494, 1 ),
      ( 300, 8749.60969572516, 10000000.0000943, -0.541801772387007, 125.81484228346, 1 ),
      ( 300, 9636.32250526359, 100000000.000002, 3.16035853171533, 129.266004894792, 1 ),
      ( 350, 0.343727053009933, 999.999999684919, -0.00027263248373452, 128.05792440348, 2 ),
      ( 350, 3.44574906269152, 9999.99668217301, -0.00273253823102099, 128.139454896329, 2 ),
      ( 350, 35.3527467535939, 100000.004607912, -0.0279868668304111, 128.983001143171, 2 ),
      ( 350, 7863.90924531235, 1000000.00364535, -0.956302478528441, 139.027042472664, 1 ),
      ( 350, 8103.9383492953, 10000000.002457, -0.575967477641832, 139.25895850186, 1 ),
      ( 350, 9246.40650992427, 100000000.000002, 2.71639881380794, 142.453712768841, 1 ),
      ( 400, 0.300731598827417, 999.999999936386, -0.000174323912481545, 144.109455656037, 2 ),
      ( 400, 3.01204953434307, 9999.99934317685, -0.00174558643510009, 144.153278316511, 2 ),
      ( 400, 30.6096560079394, 99999.9999926452, -0.017698290889273, 144.599883635621, 2 ),
      ( 400, 382.858980114886, 999999.993071557, -0.214647714997575, 151.097671127802, 2 ),
      ( 400, 7381.30134876482, 10000000.0000031, -0.592647475138658, 153.702960126, 1 ),
      ( 400, 8873.90234121856, 100000000, 2.38835342735264, 156.512546652436, 1 ),
      ( 500, 0.2405633375746, 999.999999995444, -8.31310373504292E-05, 174.166711807485, 2 ),
      ( 500, 2.40743562272914, 9999.99995377758, -0.000831685696062134, 174.182415016557, 2 ),
      ( 500, 24.2569962485309, 99999.9999999886, -0.0083547985127224, 174.340827415629, 2 ),
      ( 500, 263.695359882684, 1000000, -0.0877983617086943, 176.083251137575, 2 ),
      ( 500, 5455.61937227051, 10000000, -0.559090686352825, 182.837732421903, 1 ),
      ( 500, 8177.73660356912, 99999999.9999998, 1.94144151316655, 183.782068171043, 1 ),
      ( 600, 0.200461673069553, 999.999999999495, -4.4349245176666E-05, 200.29660006943, 2 ),
      ( 600, 2.00541723922803, 9999.99999493811, -0.000443504600184033, 200.303542155268, 2 ),
      ( 600, 20.1346005166034, 100000, -0.00443625596714538, 200.373307640512, 2 ),
      ( 600, 209.782272870293, 999999.987119364, -0.0444722515231117, 201.104528044016, 2 ),
      ( 600, 3073.62507599526, 10000000.0001494, -0.347829426853014, 207.343710514314, 1 ),
      ( 600, 7548.84104243644, 100000000, 1.65541136207199, 208.070663084347, 1 ),
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
      ( 250, 0.481181372550793, 999.999999999844, -0.000196794736029969, 59.2857586204652, 2 ),
      ( 250, 4.82036841801309, 9999.99999154098, -0.0019711423023433, 59.3271295369312, 2 ),
      ( 250, 14350.8854982755, 100000000.000029, 2.35231354641867, 71.4690594316233, 1 ),
      ( 300, 0.40095011456322, 999.999998523496, -0.00011110876441662, 66.5523979102097, 2 ),
      ( 300, 4.01351849226206, 9999.99999982357, -0.00111195136042408, 66.5708342982156, 2 ),
      ( 300, 40.5449625572845, 99999.9873328995, -0.011207457342376, 66.7578724228225, 2 ),
      ( 300, 13552.8762760623, 100000000.001072, 1.95808474400128, 76.5084960259991, 1 ),
      ( 350, 0.343656771583838, 999.999999745106, -6.81777170013779E-05, 74.5051240760779, 2 ),
      ( 350, 3.43867867052862, 9999.99738629166, -0.000682021102508436, 74.5146098012909, 2 ),
      ( 350, 34.6001667646644, 99999.998607939, -0.00684483909428394, 74.6102436790052, 2 ),
      ( 350, 12802.226527954, 100000000.000001, 1.6841685787968, 82.8434305947975, 1 ),
      ( 400, 0.300692392545466, 999.999999946778, -4.39599647158971E-05, 82.5821421092484, 2 ),
      ( 400, 3.00811425811062, 9999.99946175542, -0.000439649807455371, 82.5875832585977, 2 ),
      ( 400, 30.200847331193, 99999.9999992495, -0.0044015294461738, 82.6422593079345, 2 ),
      ( 400, 314.691672781773, 1000000.000017, -0.044527707198762, 83.2155847227812, 2 ),
      ( 400, 12101.0249773061, 100000000.000001, 1.48474137258941, 89.7019872472347, 1 ),
      ( 500, 0.24054804221128, 999.999999996906, -1.95508408110866E-05, 97.7921524812038, 2 ),
      ( 500, 2.40590368391407, 9999.99996909222, -0.000195473728962502, 97.7944332481922, 2 ),
      ( 500, 24.1013619999359, 99999.999999999, -0.00195126194199787, 97.8172820171827, 2 ),
      ( 500, 245.241380441603, 999999.995722603, -0.0191568042826739, 98.0495279807321, 2 ),
      ( 500, 2801.17970410408, 9999999.99999999, -0.141278444426923, 100.256003377599, 1 ),
      ( 500, 10851.2104337706, 99999999.9946251, 1.21674200083235, 103.221933535781, 1 ),
      ( 600, 0.200454490906974, 999.999999999818, -8.52144194957268E-06, 111.134684980615, 2 ),
      ( 600, 2.00469858290738, 9999.99999818434, -8.51776182949046E-05, 111.135893480013, 2 ),
      ( 600, 20.0622930621914, 99999.9841197714, -0.000848097716484596, 111.147986264373, 2 ),
      ( 600, 202.092728143303, 999999.999998762, -0.00811481638793163, 111.269554122048, 2 ),
      ( 600, 2099.56572651659, 10000000.000001, -0.0452655031750834, 112.415324924221, 1 ),
      ( 600, 9798.33551683562, 100000000, 1.04578402526835, 115.466417790282, 1 ),
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
      ( 150, 28153.3437398325, 100000000.003555, 1.8480138573082, 28.0915342291131, 1 ),
      ( 200, 0.601371427440298, 999.999999985902, -2.17489602988736E-05, 20.8576883658652, 2 ),
      ( 200, 6.01489153629019, 9999.99984951337, -0.000217469241569376, 20.8596483447862, 2 ),
      ( 200, 60.2667726174855, 99999.9999999808, -0.00217263656201538, 20.8792572951622, 2 ),
      ( 200, 25093.0556984486, 100000000, 1.39651302521191, 26.0583135355847, 1 ),
      ( 250, 0.481090550805457, 999.999999999532, -8.04882958483019E-06, 20.8743062408967, 2 ),
      ( 250, 4.81125390477003, 9999.99999537202, -8.04611191862079E-05, 20.875327439648, 2 ),
      ( 250, 48.1472765381112, 100000, -0.00080188708318569, 20.8855300014832, 2 ),
      ( 250, 484.839245265363, 999999.999998928, -0.00773981626364995, 20.9865681644377, 2 ),
      ( 250, 5024.81959585692, 10000000.0164112, -0.0425792022707737, 21.8562057296934, 1 ),
      ( 250, 22516.9658311771, 100000000, 1.13655197683512, 24.8497159400062, 1 ),
      ( 300, 0.400906345593511, 999.999999999995, -1.90770163526072E-06, 20.9031890355286, 2 ),
      ( 300, 4.00913205610138, 9999.99999995761, -1.9056790097326E-05, 20.9038223412663, 2 ),
      ( 300, 40.0981168193591, 99999.9997493299, -0.000188544271074882, 20.9101485728307, 2 ),
      ( 300, 401.581007927564, 999999.999999975, -0.00168195811741928, 20.9727169871377, 2 ),
      ( 300, 3990.82797948575, 10000000.0000355, 0.0045673919100694, 21.5225276080675, 1 ),
      ( 300, 20362.2470416703, 100000000.000036, 0.96886701487794, 24.0837947916268, 1 ),
      ( 350, 0.343632947026623, 1000, 1.12643258535586E-06, 20.9592998724973, 1 ),
      ( 350, 3.43629466252187, 10000.0000000072, 1.12784202352227E-05, 20.9597396670472, 1 ),
      ( 350, 34.3594105749211, 100000.000110398, 0.000114193171214137, 20.9641334874842, 1 ),
      ( 350, 343.193226204647, 1000000.00000009, 0.0012824135535994, 21.0076558956406, 1 ),
      ( 350, 3347.52791899481, 10000000.0000017, 0.0265286807612384, 21.4004413215091, 1 ),
      ( 350, 18562.2344585327, 100000000.000009, 0.851249873054848, 23.5923874221363, 1 ),
      ( 400, 0.300678344613279, 1000.00000000001, 2.70468119580691E-06, 21.058517158023, 1 ),
      ( 400, 3.00671038968649, 10000.0000000751, 2.70566459550553E-05, 21.058847085026, 1 ),
      ( 400, 30.0597547169215, 100000.0008452, 0.000271548955553082, 21.0621438716924, 1 ),
      ( 400, 299.835735139373, 1000000.00000061, 0.00281300351696428, 21.0948621159881, 1 ),
      ( 400, 2898.74425346467, 10000000.0000004, 0.0372738945807953, 21.3970280732635, 1 ),
      ( 400, 17052.1995340417, 100000000, 0.763286745022231, 23.2961359843345, 1 ),
      ( 500, 0.240542366512864, 1000.00000000002, 3.96481973560275E-06, 21.4188536220233, 1 ),
      ( 500, 2.40533801352265, 10000.000000154, 3.96532316058025E-05, 21.4190690718861, 1 ),
      ( 500, 24.0447873117383, 100000.001593605, 0.000397034823800424, 21.4212225828, 1 ),
      ( 500, 239.58022569856, 1000000.00000091, 0.00402000453101658, 21.4426583795714, 1 ),
      ( 500, 2302.55510387714, 10000000.0100762, 0.0446800552185984, 21.6469554367685, 1 ),
      ( 500, 14684.713238805, 100000000.000065, 0.63805268365214, 23.1298555118477, 1 ),
      ( 600, 0.200451919316624, 1000.00000000001, 4.22295126492276E-06, 21.9732899548404, 1 ),
      ( 600, 2.00444317526201, 10000.0000001317, 4.22322746260874E-05, 21.9734487583057, 1 ),
      ( 600, 20.0368107543901, 100000.001335421, 0.000422598206527878, 21.9750363394275, 1 ),
      ( 600, 199.60383767499, 1000000.00000048, 0.00425315002628061, 21.9908664236142, 1 ),
      ( 600, 1918.32083449317, 10000000.0091388, 0.0449387774434922, 22.144400211571, 1 ),
      ( 600, 12924.1101114805, 100000000, 0.550998722671072, 23.3531939855694, 1 ),
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
