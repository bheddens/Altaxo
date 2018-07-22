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
	/// Tests and test data for <see cref="Mixture_CO2_Hydrogen"/>.
	/// </summary>
	/// <remarks>
	/// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
	/// </remarks>
  [TestFixture]
  public class Test_Mixture_CO2_Hydrogen : MixtureTestBase
    {

    public Test_Mixture_CO2_Hydrogen()
      {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[]{("124-38-9", 0.5), ("1333-74-0", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 50, 2.40563758113918, 999.99999990019, -8.03136463738704E-05, 12.5171166940648, 2 ),
      ( 50, 24.0737851736808, 9999.99898373561, -0.000803422288634323, 12.5202720227686, 2 ),
      ( 50, 242.499464211652, 99999.9999946778, -0.00806198338040573, 12.5516567815026, 2 ),
      ( 50, 26321.1360512826, 10000000.0109917, -0.0861168102879985, 13.5963755344632, 1 ),
      ( 50, 48432.7994360454, 100000000.00243, 3.96656068546114, 14.5755913307131, 1 ),
      ( 100, 1.20272506207302, 999.99999999999, -2.38979508620742E-06, 14.2634573747505, 2 ),
      ( 150, 0.801810254172492, 1000.00000000049, 5.65931719940816E-06, 17.0741013237286, 1 ),
      ( 150, 8.01769406068932, 10000.0000050346, 5.66070516056991E-05, 17.0744297651982, 1 ),
      ( 150, 80.1360042704699, 100000, 0.000567471725680466, 17.0777124429028, 1 ),
      ( 150, 797.169782436497, 1000000.00693136, 0.00582687599315533, 17.1103693838987, 1 ),
      ( 150, 7440.91866783798, 10000000.0000799, 0.0775749980137945, 17.4230373355323, 1 ),
      ( 200, 0.601357078460923, 1000.00000000046, 6.67730124360338E-06, 18.968415006901, 1 ),
      ( 200, 6.01320938627547, 10000.0000046586, 6.67784425624557E-05, 18.9686445547056, 1 ),
      ( 200, 60.095945403904, 100000, 0.000668331052144865, 18.9709397984313, 1 ),
      ( 200, 597.334292725739, 1000000.0019598, 0.00674128580019631, 18.9938679335275, 1 ),
      ( 200, 5596.81161726909, 10000000.001855, 0.0744708506113004, 19.2199945858908, 1 ),
      ( 200, 30755.6500866885, 99999999.9999999, 0.955286564284223, 20.9847927030399, 1 ),
      ( 250, 0.481085803455318, 1000.00000000005, 6.38486376471215E-06, 20.0147395770579, 1 ),
      ( 250, 4.81058159114324, 10000.0000005535, 6.38509247330715E-05, 20.014919680804, 1 ),
      ( 250, 48.0781780905195, 100000.005572107, 0.000638739333991452, 20.0167206503355, 1 ),
      ( 250, 478.023957101381, 1000000.00001172, 0.00641164103965058, 20.034722621114, 1 ),
      ( 250, 4508.44576523945, 9999999.99999998, 0.0670836473888033, 20.2132139346696, 1 ),
      ( 250, 27217.8595314116, 100000000.000008, 0.767548526611485, 21.6801350744277, 1 ),
      ( 250, 69886.9389813279, 1000000000, 5.88381666352806, 26.1562169917109, 1 ),
      ( 300, 0.400905057547408, 1000.00000000003, 5.8327728100506E-06, 20.5412281718057, 1 ),
      ( 300, 4.00884012891218, 10000.0000002936, 5.83287024609904E-05, 20.5413773966386, 1 ),
      ( 300, 40.0673648910513, 100000.002938025, 0.000583385087845899, 20.542869573832, 1 ),
      ( 300, 398.578015891991, 1000000.00000259, 0.00584422605943842, 20.5577836296697, 1 ),
      ( 300, 3782.99132067663, 9999999.99999999, 0.0597629281999513, 20.7056584258574, 1 ),
      ( 300, 24414.2920336931, 100000000, 0.642101255208434, 21.9522924601533, 1 ),
      ( 300, 67766.1491437922, 1000000000, 4.91604216855891, 26.2903842143852, 1 ),
      ( 350, 0.343633099126841, 1000.00000000002, 5.27212030558802E-06, 20.7822972835513, 1 ),
      ( 350, 3.43616794781223, 10000.0000001596, 5.27215809381009E-05, 20.7824248611282, 1 ),
      ( 350, 34.3453823428229, 100000.001593763, 0.000527253925199429, 20.7837005507005, 1 ),
      ( 350, 341.831186809706, 1000000.00000065, 0.00527665131664167, 20.7964484629402, 1 ),
      ( 350, 3262.32198005813, 10000000.0112114, 0.0533445592501828, 20.9227280729009, 1 ),
      ( 350, 22143.3611592044, 100000000, 0.551864273590826, 22.0032420691469, 1 ),
      ( 350, 65775.3287212898, 1000000000, 4.22437390253057, 26.1425517790248, 1 ),
      ( 400, 0.300679114135044, 1000.00000000001, 4.76526813529979E-06, 20.8835442996433, 1 ),
      ( 400, 3.0066621937237, 10000.0000000904, 4.76527735828066E-05, 20.8836556540252, 1 ),
      ( 400, 30.0537329750916, 100000.000902117, 0.000476537148091804, 20.8847691043405, 1 ),
      ( 400, 299.254155513677, 1000000.00000019, 0.00476648830141448, 20.8958940384387, 1 ),
      ( 400, 2869.40891126156, 10000000.001622, 0.0478832270082077, 21.0060042586271, 1 ),
      ( 400, 20267.1724157393, 100000000, 0.48358409739555, 21.9577663471388, 1 ),
      ( 400, 63907.1148321281, 1000000000, 3.70496200214098, 25.8830961465911, 1 ),
      ( 500, 0.240543470966896, 1000, 3.93958501814452E-06, 20.9557763007386, 1 ),
      ( 500, 2.40534961509014, 10000.0000000328, 3.93957379116289E-05, 20.9558647379523, 1 ),
      ( 500, 24.044971337813, 100000.000327366, 0.000393945919762082, 20.9567490197771, 1 ),
      ( 500, 239.600796879176, 1000000.00000002, 0.00393838706502478, 20.9655827261114, 1 ),
      ( 500, 2314.42317529218, 10000000.0000494, 0.0393278123435405, 21.0529403663727, 1 ),
      ( 500, 17346.1671306732, 100000000.000002, 0.3867296201474, 21.8189974319373, 1 ),
      ( 500, 60503.6746525349, 1000000000, 2.97569964043707, 25.3351041538683, 1 ),
      ( 600, 0.200453019011191, 1000, 3.3206964483278E-06, 21.0322642808126, 1 ),
      ( 600, 2.00447041760914, 10000.0000000137, 3.32068100936934E-05, 21.0323372216995, 1 ),
      ( 600, 20.038715891472, 100000.000136621, 0.000332052480277266, 21.0330665522811, 1 ),
      ( 600, 199.790592990607, 1000000, 0.00331899998777062, 21.040351998521, 1 ),
      ( 600, 1940.37706241663, 10000000.0000027, 0.0330656955824432, 21.1123945645562, 1 ),
      ( 600, 15173.1761887895, 100000000, 0.32110571625647, 21.7512054800627, 1 ),
      ( 600, 57487.3515505079, 1000000000, 2.48691829700394, 24.9120433113522, 1 ),
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
      ( 150, 0.801897072780589, 999.980115519325, -0.000104886095576713, 19.5013821536132, 2 ),
      ( 150, 8.0265548719459, 10000.0000412567, -0.00104967069479703, 19.5158647375318, 2 ),
      ( 200, 0.60138631250849, 999.999999961435, -4.42146199846095E-05, 21.507356973256, 2 ),
      ( 200, 6.0162578806637, 9999.99960864979, -0.000442244365192423, 21.5118754070853, 2 ),
      ( 200, 60.4036997607251, 99999.9995708866, -0.00443230324389583, 21.5572347325711, 2 ),
      ( 250, 0.481098134992688, 999.999999997101, -2.15279149109314E-05, 23.2661791203809, 2 ),
      ( 250, 4.81191371264741, 9999.99997083828, -0.000215285056320755, 23.2681690695755, 2 ),
      ( 250, 48.2126003965209, 99999.999999999, -0.00215343292569846, 23.2880859715519, 2 ),
      ( 250, 491.700407802848, 1000000.00000373, -0.0215835286721355, 23.4889019929286, 2 ),
      ( 300, 0.400910904854459, 999.999999999725, -1.10329425488783E-05, 24.7220269968602, 2 ),
      ( 300, 4.00950714767468, 9999.99999723734, -0.000110320641286441, 24.7230886773302, 2 ),
      ( 300, 40.134889747054, 100000, -0.00110232230795451, 24.7337041589181, 2 ),
      ( 300, 405.336393575066, 999999.99982041, -0.0109289765661751, 24.839677980881, 2 ),
      ( 300, 4419.0227974261, 10000000, -0.0927711849303207, 25.8282555676921, 2 ),
      ( 350, 0.343636026944072, 999.999999999973, -5.52862522044488E-06, 25.9258342783856, 2 ),
      ( 350, 3.43653123096984, 9999.999999741, -5.52766334427537E-05, 25.9264792836688, 2 ),
      ( 350, 34.3823849700183, 99999.9975127871, -0.000551801704158732, 25.9329263608339, 2 ),
      ( 350, 345.506353626445, 999999.999999526, -0.0054187903867885, 25.9970820419229, 2 ),
      ( 350, 3584.72742004926, 10000000.0001955, -0.041393983857288, 26.5911047199798, 2 ),
      ( 400, 0.300680596603102, 999.98809227431, -2.39774621208479E-06, 26.9454215867258, 2 ),
      ( 400, 3.00687068628717, 9999.99999999828, -2.39697973744244E-05, 26.9458528956209, 2 ),
      ( 400, 30.0751711340453, 99999.9999833804, -0.000238901782177308, 26.9501636415587, 2 ),
      ( 400, 301.375471553158, 999999.999999999, -0.00230811860165463, 26.9930314048197, 2 ),
      ( 400, 3048.77050759507, 10000000.0007377, -0.0137668267535855, 27.3928470950462, 1 ),
      ( 400, 19375.8275617804, 100000000, 0.551829774815459, 29.4813870604693, 1 ),
      ( 500, 0.240543728261086, 1000.0043395781, 6.5503396302832E-07, 28.6290116772687, 1 ),
      ( 500, 2.40542312230064, 10000.0000000001, 6.55496494044134E-06, 28.6292481876703, 1 ),
      ( 500, 24.0528010446072, 100000.000000696, 6.60153068468884E-05, 28.6316122040808, 1 ),
      ( 500, 240.373942865878, 1000000.01584513, 0.000707007221538002, 28.655143099053, 1 ),
      ( 500, 2376.90435243905, 10000000.0000003, 0.0120049160987636, 28.8793399895778, 1 ),
      ( 500, 16350.9687402322, 99999999.9999995, 0.471129281683587, 30.4496791846985, 1 ),
      ( 600, 0.200452855529321, 1000, 1.88438106027181E-06, 30.0150426166398, 1 ),
      ( 600, 2.00449463048656, 10000.000000004, 1.88464714516143E-05, 30.0151981438734, 1 ),
      ( 600, 20.0415416251822, 100000.00004068, 0.000188730800451721, 30.0167529035946, 1 ),
      ( 600, 200.070308904436, 999999.999999999, 0.00191398669343556, 30.03224947549, 1 ),
      ( 600, 1961.64624333134, 10000000.0000181, 0.0218623337168599, 30.1823659827691, 1 ),
      ( 600, 14144.8720072803, 99999999.9999997, 0.417144253483285, 31.3986452660788, 1 ),
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
      ( 150, 0.802240200890761, 999.999999696274, -0.000534835131585095, 21.9605355451268, 2 ),
      ( 200, 0.601470701213611, 999.999998442597, -0.000186792520082911, 24.0525047562786, 2 ),
      ( 200, 6.02485585714738, 9999.98336367702, -0.00187097065315534, 24.1172246049018, 2 ),
      ( 200, 61.3028421127908, 100000.000671146, -0.0190367523269823, 24.7866758591914, 2 ),
      ( 250, 0.481129198114254, 999.9999998672, -8.83698725731199E-05, 26.5195989804826, 2 ),
      ( 250, 4.81512476249758, 9999.99863520142, -0.000884287374092174, 26.5411109902096, 2 ),
      ( 250, 48.5408174346471, 99999.9999853956, -0.00890280328077806, 26.7586787104567, 2 ),
      ( 250, 532.378865189077, 999999.997070474, -0.0963452676073876, 29.3429599985698, 2 ),
      ( 250, 24436.7639178545, 10000000.0025782, -0.803129955125996, 41.4477935727432, 1 ),
      ( 250, 28063.3739021617, 100000000.000286, 0.714286680093402, 43.5260936863402, 1 ),
      ( 300, 0.400925026413816, 999.99999999517, -4.85354840292135E-05, 28.9036699314578, 2 ),
      ( 300, 4.01100301058939, 9999.99985648062, -0.000485498844105532, 28.9130744460178, 2 ),
      ( 300, 40.2867328322271, 99999.9999999243, -0.00486949636108113, 29.0076193433678, 2 ),
      ( 300, 422.122743317457, 999999.999999995, -0.050263048674212, 30.0098191416152, 2 ),
      ( 300, 18168.887066639, 9999999.99992191, -0.779345005640261, 41.7886194921109, 1 ),
      ( 300, 25652.6917946007, 100000000.000002, 0.562820660442562, 41.5669071944194, 1 ),
      ( 350, 0.343643292801697, 999.999999997492, -2.89526426859204E-05, 31.0698056173657, 2 ),
      ( 350, 3.43732874885695, 9999.9999747084, -0.000289560506093242, 31.0746674096665, 2 ),
      ( 350, 34.4632441411918, 99999.999999999, -0.00289902478684981, 31.1234187690936, 2 ),
      ( 350, 354.021787578206, 1000000.00002041, -0.0293440814172981, 31.6245855848312, 2 ),
      ( 350, 5191.14657981463, 9999999.99983177, -0.338039606202296, 38.2790008503292, 2 ),
      ( 350, 23342.516682229, 99999999.9999988, 0.472134937711658, 40.7510053180329, 1 ),
      ( 400, 0.300684614486645, 999.999999999521, -1.80887005285307E-05, 33.0075559171943, 2 ),
      ( 400, 3.00733575078192, 9999.99999518771, -0.000180889631133389, 33.010372177138, 2 ),
      ( 400, 30.1224137852843, 100000, -0.00180915899924794, 33.0385755326744, 2 ),
      ( 400, 306.227322417184, 999999.997107443, -0.0181177396733119, 33.3246089283206, 2 ),
      ( 400, 3668.32943044526, 9999999.99689307, -0.180337586322672, 36.4456420572032, 2 ),
      ( 400, 21186.9580906207, 100000000.00441, 0.419171049550406, 40.5917166441304, 1 ),
      ( 500, 0.240545113839548, 999.999999999979, -7.37261031680038E-06, 36.302371242314, 2 ),
      ( 500, 2.40561073994584, 9999.99999978432, -7.37176639961324E-05, 36.3035585944672, 2 ),
      ( 500, 24.0720590823163, 99999.997874689, -0.000736332627863271, 36.3154358286489, 2 ),
      ( 500, 242.307041954973, 999999.999998848, -0.00727878781262767, 36.4345386092538, 2 ),
      ( 500, 2568.73979727913, 9999999.99988842, -0.0635745175548791, 37.6164205095949, 2 ),
      ( 500, 17521.2493180829, 100000000, 0.372866375149133, 41.2573359059851, 1 ),
      ( 600, 0.200453329741625, 1000, -2.67081170206907E-06, 38.9979038982474, 2 ),
      ( 600, 2.00458136093542, 9999.99999999269, -2.67009952616647E-05, 38.9985197810432, 2 ),
      ( 600, 20.0506178132786, 99999.9999297032, -0.000266298382648017, 39.004678102058, 2 ),
      ( 600, 200.973761060324, 1000000, -0.00259226575250906, 39.0661978416449, 2 ),
      ( 600, 2043.46893967686, 9999999.99983778, -0.0190563713998214, 39.6634987107497, 2 ),
      ( 600, 14760.5667464131, 100000000.001375, 0.358029045272428, 42.4367477528136, 1 ),
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
