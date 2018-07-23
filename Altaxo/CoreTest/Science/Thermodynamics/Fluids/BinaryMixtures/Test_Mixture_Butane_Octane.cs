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
	/// Tests and test data for <see cref="Mixture_Butane_Octane"/>.
	/// </summary>
	/// <remarks>
	/// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
	/// </remarks>
  [TestFixture]
  public class Test_Mixture_Butane_Octane : MixtureTestBase
    {

    public Test_Mixture_Butane_Octane()
      {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[]{("106-97-8", 0.5), ("111-65-9", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 100, 7631.88232791502, 1000.00007632735, -0.999842408891826, 152.668556963694, 1 ),
      ( 100, 7631.90444689579, 10000.0075830525, -0.99842409241044, 152.669571634539, 1 ),
      ( 100, 7632.1256005847, 99999.999997553, -0.984241392701253, 152.679717612105, 1 ),
      ( 100, 7634.33353519675, 1000000.00000003, -0.842459502663256, 152.781105318076, 1 ),
      ( 100, 7656.06195314216, 9999999.999997, 0.570933868262053, 153.787852397841, 1 ),
      ( 100, 7845.31770540165, 99999999.9999961, 14.3303759915011, 163.21700146614, 1 ),
      ( 150, 7187.06850852416, 1000.0002076622, -0.999888436947639, 168.31662416276, 1 ),
      ( 150, 7187.09887068972, 9999.99999975648, -0.998884374420104, 168.317401442806, 1 ),
      ( 150, 7187.4024213786, 99999.9999995206, -0.988844215369563, 168.325173504301, 1 ),
      ( 150, 7190.43085856694, 1000000.00005077, -0.888489139182459, 168.402820289627, 1 ),
      ( 150, 7220.03403075032, 9999999.99999909, 0.110536503335299, 169.171991972658, 1 ),
      ( 150, 7465.7568909485, 100000000, 9.73985057857037, 176.224445712788, 1 ),
      ( 200, 6807.2017769663, 100000.000000523, -0.991165850951796, 176.717181279241, 1 ),
      ( 200, 6811.26238400381, 1000000.00000608, -0.911711175243912, 176.783894656958, 1 ),
      ( 200, 6850.60724578618, 10000000.0000011, -0.12218241503377, 177.443432527821, 1 ),
      ( 200, 7159.19721561368, 100000000.000003, 7.39980144245435, 183.370595585062, 1 ),
      ( 250, 6452.17910733304, 99999.999999682, -0.992543810815169, 188.963645679502, 1 ),
      ( 250, 6457.62984837555, 1000000.00000461, -0.925501044177741, 189.024078587479, 1 ),
      ( 250, 6509.79822011975, 10000000.0000004, -0.260980656498116, 189.621292310349, 1 ),
      ( 250, 6891.36234489904, 100000000.000003, 5.98100980199191, 194.907396100519, 1 ),
      ( 300, 0.401540415784963, 999.999991949393, -0.00158103252118176, 180.387799832113, 2 ),
      ( 300, 6101.99629354162, 100000.000000683, -0.993429927714784, 206.734760381591, 1 ),
      ( 300, 6109.4439406062, 1000000.00761414, -0.934379368356676, 206.790181382435, 1 ),
      ( 300, 6179.42976205572, 10000000.000006, -0.351225626420108, 207.340766535207, 1 ),
      ( 350, 0.343927964358268, 999.999975816003, -0.000856635578948495, 205.838895860658, 2 ),
      ( 350, 3.46625982783735, 9999.98551898185, -0.00863361402359645, 206.248857793688, 2 ),
      ( 350, 5740.99951499238, 100000.000001818, -0.99401439866822, 227.910355307498, 1 ),
      ( 350, 5751.55381975803, 999999.999999492, -0.940253824585704, 227.958833095843, 1 ),
      ( 350, 5847.85821114604, 10000000.0000832, -0.412377436308643, 228.453568868949, 1 ),
      ( 350, 6421.01970037611, 100000000.000003, 4.35169427061733, 233.006072009967, 1 ),
      ( 400, 0.30083308123693, 999.999996010739, -0.000511598468407713, 231.340397336617, 2 ),
      ( 400, 3.02232506495755, 9999.9999999995, -0.0051395232521846, 231.560809608805, 2 ),
      ( 400, 31.7849102988616, 99999.9999968127, -0.0540191157813371, 233.898320756617, 2 ),
      ( 400, 5366.9418611517, 1000000.00000064, -0.943975697283146, 250.250252892435, 1 ),
      ( 400, 5505.41235826984, 10000000.0009309, -0.453848039077206, 250.639138900741, 1 ),
      ( 400, 6207.29484991146, 100000000.000004, 3.84396476684226, 254.895504257246, 1 ),
      ( 500, 0.240596543452223, 999.9999997864, -0.000221129768895614, 278.35225085954, 2 ),
      ( 500, 2.41077417700395, 9999.99776888346, -0.00221537625297831, 278.431020925543, 2 ),
      ( 500, 24.6099692119924, 99999.9998553629, -0.0225776459518927, 279.237175653306, 2 ),
      ( 500, 4355.92420792713, 1000000.00234404, -0.944777886518717, 294.013575439264, 1 ),
      ( 500, 4745.36843375868, 10000000.0000021, -0.493098705081102, 293.280294062758, 1 ),
      ( 500, 5810.99981326695, 100000000.000007, 3.13944842753219, 296.707712740466, 1 ),
      ( 600, 0.200475168863138, 999.999999980037, -0.000111660718206799, 318.31344455993, 2 ),
      ( 600, 2.00677027654133, 9999.9997962348, -0.00111743725888783, 318.347776497126, 2 ),
      ( 600, 20.2735313178762, 99999.9999996582, -0.0112586673804009, 318.695149846125, 2 ),
      ( 600, 228.447845544382, 999999.999723212, -0.122544652619948, 322.637400312855, 2 ),
      ( 600, 3797.25462961827, 9999999.99995947, -0.472111292982515, 331.393745491396, 1 ),
      ( 600, 5450.83124307104, 100000000.000009, 2.67747183361085, 333.146013828375, 1 ),
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
      ( 150, 8956.11781584716, 99999.9999982439, -0.991047315655146, 125.852831976745, 1 ),
      ( 150, 8960.58446872218, 1000000.00047831, -0.910517783085741, 125.912004679378, 1 ),
      ( 150, 9004.15376688752, 9999999.99999814, -0.109507696131864, 126.489104551164, 1 ),
      ( 150, 9361.09633749059, 100000000.000004, 7.56537454960013, 131.227118435277, 1 ),
      ( 200, 8454.91996663356, 100000.000000372, -0.992887458210724, 130.897726142184, 1 ),
      ( 200, 8461.05300766602, 1000000.00143244, -0.928926136953278, 130.949457142602, 1 ),
      ( 200, 8520.19004028488, 10000000.0000006, -0.294194472694171, 131.456376018573, 1 ),
      ( 200, 8971.70366032709, 100000000.000003, 5.70284870308876, 135.743204948367, 1 ),
      ( 250, 7960.79479803631, 100000.000000167, -0.993956787151776, 139.92547502843, 1 ),
      ( 250, 7969.36186007069, 1000000.00003176, -0.939632835592623, 139.975116763023, 1 ),
      ( 250, 8050.54926830758, 10000000.0030572, -0.402416205336304, 140.463153167954, 1 ),
      ( 250, 8616.72515314929, 99999999.9999686, 4.5831858322299, 144.602489774951, 1 ),
      ( 300, 0.401197478971879, 999.999999993383, -0.000725321966413877, 135.542772466784, 2 ),
      ( 300, 7462.84477454683, 1000000.00129455, -0.946279670290717, 153.399301020448, 1 ),
      ( 300, 7577.74894134734, 10000000.0000067, -0.470942512438975, 153.867295191377, 1 ),
      ( 300, 8286.61806584961, 100000000.000141, 3.83799878843458, 157.906151924883, 1 ),
      ( 350, 0.343775931495551, 999.999996128903, -0.000412490732301157, 154.745842968722, 2 ),
      ( 350, 3.45062860996532, 9999.9999896008, -0.00414050320185704, 154.894254358667, 2 ),
      ( 350, 6914.10915339827, 999999.999999714, -0.950299580251739, 169.443978395342, 1 ),
      ( 350, 7085.77701896706, 10000000.0003166, -0.515036775503949, 169.8512350802, 1 ),
      ( 350, 7975.97848251064, 100000000.000615, 3.30836326688516, 173.765942245276, 1 ),
      ( 400, 0.300756832774899, 999.999999279111, -0.000255926202984213, 173.951912103027, 2 ),
      ( 400, 3.01453067209403, 9999.99236539152, -0.00256492794436245, 174.032821933615, 2 ),
      ( 400, 30.8783552408254, 100000.000152121, -0.0262439211450708, 174.869393604804, 2 ),
      ( 400, 6555.88585725677, 10000000.0196769, -0.541358912685876, 186.699308736556, 1 ),
      ( 400, 7681.69246269205, 100000000.002186, 2.91423976795392, 190.404512298784, 1 ),
      ( 500, 0.240571789088381, 999.999999955277, -0.00011597416304766, 209.413075484226, 2 ),
      ( 500, 2.40823419125015, 9999.99954194544, -0.0011607265466622, 209.442867289822, 2 ),
      ( 500, 24.3393409037875, 99999.9999980605, -0.011707465670229, 209.744753842394, 2 ),
      ( 500, 276.253400869112, 999999.997710244, -0.129263609744368, 213.250289466339, 2 ),
      ( 500, 5269.84024950476, 10000000.0000512, -0.543546146393817, 219.641232353858, 1 ),
      ( 500, 7135.98299260665, 100000000.015454, 2.37085849641125, 222.213505751002, 1 ),
      ( 600, 0.200465138688447, 999.999999995655, -5.9351340516177E-05, 239.724018912663, 2 ),
      ( 600, 2.00572316876822, 9999.99995605647, -0.000593681443206854, 239.737484490856, 2 ),
      ( 600, 20.1653827724697, 99999.9999999933, -0.00595370252050145, 239.872937779722, 2 ),
      ( 600, 213.543475937952, 1000000.00143688, -0.0613000939792054, 241.308475096419, 2 ),
      ( 600, 3528.96519408251, 10000000.0000047, -0.431977280053947, 249.391614008122, 1 ),
      ( 600, 6643.21296657507, 100000000, 2.01741404080069, 250.088566288479, 1 ),
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
      ( 100, 13205.4337726037, 1000.00021399864, -0.999908922155258, 80.4992326417728, 1 ),
      ( 100, 13205.4808613443, 9999.99999577066, -0.999089224996909, 80.5004699360615, 1 ),
      ( 100, 13210.6526956088, 1000000.00002666, -0.908958155546889, 80.6359610434909, 1 ),
      ( 100, 13256.9663025821, 9999999.99999598, -0.0927621294685677, 81.814147637212, 1 ),
      ( 100, 13663.8334773423, 100000000, 7.80223101226288, 89.7590618584828, 1 ),
      ( 150, 12392.6616688785, 1000.00068302607, -0.999935299192176, 83.914876381682, 1 ),
      ( 150, 12392.7328500332, 10000.000002271, -0.999352995993646, 83.9153832490011, 1 ),
      ( 150, 12393.4444603989, 100000.000002408, -0.9935303313515, 83.9204499376818, 1 ),
      ( 150, 12400.540541791, 1000000.00068872, -0.935340335398153, 83.9709193206358, 1 ),
      ( 150, 12469.5897051214, 9999999.99999568, -0.356983821579972, 84.4567980061939, 1 ),
      ( 150, 13027.1348410518, 100000000.000579, 5.15495887360266, 88.0463599912057, 1 ),
      ( 200, 11588.1311026592, 100000.00000086, -0.994810542906219, 85.7222455429418, 1 ),
      ( 200, 11598.5431815233, 1000000.00302093, -0.948152014775125, 85.7670037160474, 1 ),
      ( 200, 11698.203407126, 10000000.0000034, -0.485937222181292, 86.2011616850234, 1 ),
      ( 200, 12429.8876677763, 100000000.003757, 3.83802516963769, 89.6167976522921, 1 ),
      ( 250, 0.481340521283933, 999.999987081652, -0.000522802770401239, 78.6269420383446, 2 ),
      ( 250, 4.83631471772651, 9999.99688076522, -0.00525730020889985, 78.7940405604492, 2 ),
      ( 250, 10745.5132451981, 100000.000003151, -0.995522886052903, 91.5278180157288, 1 ),
      ( 250, 10761.5257735077, 1000000.00073563, -0.955295477113985, 91.5727853809737, 1 ),
      ( 250, 10910.4952839439, 9999999.99999941, -0.559058628781516, 92.0121276689672, 1 ),
      ( 250, 11868.0504546504, 99999999.9999993, 3.05364703293891, 95.5162158289866, 1 ),
      ( 300, 0.401020557776435, 999.99999856929, -0.000282184637544754, 90.7320497436278, 2 ),
      ( 300, 4.02044893776477, 9999.98463115808, -0.00282927629074414, 90.806038729984, 2 ),
      ( 300, 41.2914833601289, 100000.00707379, -0.0290796977123223, 91.5909635467391, 2 ),
      ( 300, 9834.64385272741, 1000000, -0.959235189200623, 100.648471313922, 1 ),
      ( 300, 10074.7429856239, 10000000.0011227, -0.602066875007151, 101.062576065825, 1 ),
      ( 300, 11337.4032360815, 100000000.000003, 2.53614833650478, 104.613047199654, 1 ),
      ( 350, 0.34369306247734, 999.999999769263, -0.000169196535497904, 103.669544552605, 2 ),
      ( 350, 3.44218139308672, 9999.99760118448, -0.00169435686190363, 103.707211891985, 2 ),
      ( 350, 34.9645375921715, 99999.9998855024, -0.0171901747506184, 104.095292024038, 2 ),
      ( 350, 8691.15495135203, 1000000.00009258, -0.960461536728211, 111.839796188736, 1 ),
      ( 350, 9143.04913809565, 10000000.0000001, -0.624157208813756, 111.934885288291, 1 ),
      ( 350, 10834.2839546289, 100000000.000046, 2.17173624249019, 115.390458186779, 1 ),
      ( 400, 0.30071318450672, 999.999999997294, -0.00010853383475102, 116.572490521822, 2 ),
      ( 400, 3.01007510441298, 9999.99960547162, -0.00108623029433518, 116.593773060077, 2 ),
      ( 400, 30.401038615923, 99999.9999980361, -0.0109530439626788, 116.81004007475, 2 ),
      ( 400, 341.911630437463, 999999.998121383, -0.120589882672407, 119.402112365558, 2 ),
      ( 400, 8031.53123094101, 10000000.0000097, -0.625624879856593, 123.697931941461, 1 ),
      ( 400, 10356.3260227229, 100000000.000364, 1.90335150026105, 126.675911815366, 1 ),
      ( 500, 0.240556513616086, 999.99999999687, -5.0200489642298E-05, 140.477274325153, 2 ),
      ( 500, 2.40665288829243, 9999.9999683656, -0.000502154956062979, 140.485729259454, 2 ),
      ( 500, 24.1762099403333, 99999.9999999971, -0.005036611771599, 140.570649163854, 2 ),
      ( 500, 253.719188096542, 1000000.00037913, -0.0519265044131356, 141.458567860064, 2 ),
      ( 500, 4614.23139768819, 10000000, -0.478690128800574, 147.982373566458, 1 ),
      ( 500, 9471.66202861746, 100000000.009593, 1.53962226326922, 148.351370963102, 1 ),
      ( 600, 0.20045868205578, 999.999999999726, -2.48634180637611E-05, 161.136235736428, 2 ),
      ( 600, 2.00503553455478, 9999.99999724262, -0.000248651392163459, 161.140415743229, 2 ),
      ( 600, 20.0953714079463, 99999.9999999998, -0.00248821532545998, 161.182238259561, 2 ),
      ( 600, 205.599857485036, 999999.99844962, -0.0250299760525067, 161.602290327698, 2 ),
      ( 600, 2551.02417976112, 9999999.99999999, -0.214222665711723, 165.04982387577, 1 ),
      ( 600, 8680.16532732134, 99999999.9999997, 1.30933041489616, 167.576895316437, 1 ),
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