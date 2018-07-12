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
	/// Tests and test data for <see cref="Trans_1_3_3_3_tetrafluoropropene"/>.
	/// </summary>
	/// <remarks>
	/// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
	/// </remarks>
  [TestFixture]
  public class Test_Trans_1_3_3_3_tetrafluoropropene : FluidTestBase
    {

    public Test_Trans_1_3_3_3_tetrafluoropropene()
      {
      _fluid = Trans_1_3_3_3_tetrafluoropropene.Instance;

    _testDataMolecularWeight = 0.1140416;

    _testDataTriplePointTemperature = 168.62;

    _testDataTriplePointPressure = 218.7;

    _testDataTriplePointLiquidMoleDensity = 13255.8957892469;

    _testDataTriplePointVaporMoleDensity = 0.156012264021837;

    _testDataCriticalPointTemperature = 382.513;

    _testDataCriticalPointPressure = 3634870.33277965;

    _testDataCriticalPointMoleDensity = 4290;

    _testDataNormalBoilingPointTemperature = 254.177474975723;

    _testDataNormalSublimationPointTemperature = null;

    _testDataIsMeltingCurveImplemented = false;

    _testDataIsSublimationCurveImplemented = false;

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. Internal energy (J/mol)
      // 4. Enthalpy (J/mol)
      // 5. Entropy (J/mol K)
      // 6. Isochoric heat capacity (J/(mol K))
      // 7. Isobaric heat capacity (J/(mol K))
      // 8. Speed of sound (m/s)
      _testDataEquationOfState = new (double temperature, double moleDensity, double pressure, double internalEnergy, double enthalpy, double entropy, double isochoricHeatCapacity, double isobaricHeatCapacity, double speedOfSound)[]
      {
      ( 168.62, 13255.8969111364, 328.049950207, 7924.27705731347, 7924.30180478642, 45.6510581435796, 94.0397372515866, 138.915494908809, 1123.85891894563 ),
      ( 171.176281906861, 13199.9552317253, 328.049997843243, 8279.28083880777, 8279.30569116463, 47.7406091429539, 94.019070073993, 138.838604493217, 1111.38776922288 ),
      ( 175, 0.225558529874888, 328.050000000006, 34573.6046674133, 36027.9943558989, 208.897667976786, 64.8693566991409, 73.1990418063495, 119.934915191036 ),
      ( 225, 0.175391340730212, 328.050000000001, 38145.9878805326, 40016.3766844167, 228.878934311428, 77.3495926395198, 85.6717759357048, 134.766362851809 ),
      ( 275, 0.143488035790897, 328.05, 42265.1394032694, 44551.3927357637, 247.047018631132, 87.1568763224751, 95.4753596690575, 148.184861056455 ),
      ( 325, 0.121407708367003, 328.050000000001, 46847.4956320826, 49549.5481163312, 263.725590321189, 96.0580899292583, 104.374810844153, 160.447881927574 ),
      ( 375, 0.105217737264171, 328.05, 51865.7641254668, 54983.5844524366, 279.263280613137, 104.623001152999, 112.938860886347, 171.788693324562 ),
      ( 168.62, 13255.9038022333, 999.999944369258, 7924.26293639783, 7924.3383744788, 45.6509743994112, 94.0397837128236, 138.915456581367, 1123.86103945132 ),
      ( 175, 13116.4123438869, 1000.00000051491, 8809.99119257897, 8810.06743293909, 50.8068664077597, 94.0203039580626, 138.766203353668, 1092.81351010984 ),
      ( 181.956707256081, 12964.6657996131, 999.99999767879, 9775.22662093756, 9775.30375366224, 56.2156946066495, 94.1128085638348, 138.757391190467, 1059.26038487708 ),
      ( 200, 0.601893265477541, 1000.00000000014, 36279.990938, 37941.4150763922, 209.846544610567, 71.6162299540219, 79.9637203819796, 127.484422845991 ),
      ( 250, 0.481290434465252, 1000.00000000002, 40143.0926906858, 42220.8401969522, 228.900311823685, 82.4501171172981, 90.781452902571, 141.604373080998 ),
      ( 300, 0.400997212529272, 1000, 44499.841834562, 46993.6247556266, 246.278475066713, 91.6687081705545, 99.9922346862749, 154.426419706145 ),
      ( 350, 0.343680324148394, 999.999999999999, 49302.4686612701, 52212.149343392, 262.350025376411, 100.378773906425, 108.698569005168, 166.208521980065 ),
      ( 400, 0.300705639802809, 1000, 54533.1110226868, 57858.6223122514, 277.417161751947, 108.786021569582, 117.103932104805, 177.165287581598 ),
      ( 168.62, 13255.9960975599, 9999.99995035245, 7924.07381054352, 7924.82818613904, 45.6498527724209, 94.0404059910578, 138.914943301045, 1123.88944026966 ),
      ( 175, 13116.5098731427, 9999.99999609558, 8809.79131782215, 8810.55371575367, 50.8057242484756, 94.0209280555086, 138.765609160297, 1092.84337922546 ),
      ( 200, 12571.0537862532, 9999.9999976631, 12283.0108131332, 12283.8062913936, 69.3563214207778, 94.8034963709405, 139.394172026224, 973.777574634365 ),
      ( 210.503586309174, 12340.3014536232, 10000.0000014454, 13750.9205088234, 13751.7308617989, 76.5095387752678, 95.4397463786869, 140.161113506443, 924.983079616653 ),
      ( 225, 5.37781839316402, 10000.0000004485, 38120.25786428, 39979.7479528929, 200.352424658304, 77.4671194029451, 86.0215584438651, 134.14993551489 ),
      ( 275, 4.38681632665593, 10000.0000000562, 42248.829039056, 44528.3865257218, 218.575672383605, 87.2415296832717, 95.679557195848, 147.836370806281 ),
      ( 325, 3.70700282468288, 10000.00000001, 46836.7037257551, 49534.3008069942, 235.280374686883, 96.1062934500638, 104.489706700415, 160.231080361157 ),
      ( 375, 3.210609519984, 10000.0000000023, 51858.0857355147, 54972.759113812, 250.830801963968, 104.649045029118, 113.005956537884, 171.644853074638 ),
      ( 168.62, 13256.1826686316, 28194.7892117484, 7923.69150887622, 7925.8184250418, 45.6475854141994, 94.0416639202629, 138.913906039542, 1123.9468513351 ),
      ( 175, 13116.7070229708, 28194.7892635711, 8809.3872908145, 8811.53682340787, 50.8034153976676, 94.0221896555119, 138.764408390053, 1092.90375792177 ),
      ( 200, 12571.3011552923, 28194.7892693479, 12282.506879296, 12284.7496693558, 69.35380160213, 94.8047293630188, 139.392131419689, 973.851808642104 ),
      ( 225, 12017.9431857861, 28194.7892657214, 15792.3681248031, 15794.714182596, 85.8877568957844, 96.5274504965473, 141.659304493237, 858.779899912166 ),
      ( 227.316781832182, 11965.7535412502, 28194.7892652994, 16120.8810535063, 16123.2373438284, 87.3403913356013, 96.7196163288679, 141.945859427994, 848.281464690198 ),
      ( 250, 13.7281518866549, 28194.7892765609, 40085.0849302352, 42138.8784422351, 200.904531859977, 82.7475455699297, 91.5575481987074, 140.305968662435 ),
      ( 300, 11.3757196727962, 28194.7892679195, 44462.6793111823, 46941.1852940033, 218.39129226464, 91.8518400227628, 100.42714363293, 153.657700794601 ),
      ( 350, 9.72503411147339, 28194.7892667363, 49277.050280537, 52176.2472338385, 234.51419902736, 100.478855896364, 108.945218821383, 165.714063093202 ),
      ( 400, 8.4976370802075, 28194.7892665131, 54514.3737496588, 57832.3301415814, 249.607145511, 108.84005978731, 117.252162917314, 176.830505058637 ),
      ( 168.62, 13256.9187420872, 99999.9999437214, 7922.18333211652, 7929.72656308061, 45.6386395879768, 94.0466270564235, 138.909817843055, 1124.17335382631 ),
      ( 175, 13117.4848141074, 99999.9999962891, 8807.7934422578, 8815.41685493282, 50.794306035997, 94.0271671870287, 138.759675805469, 1093.14196239431 ),
      ( 200, 12572.2769555043, 100000.000002801, 12280.519116555, 12288.4731252328, 69.343860809898, 94.809593776035, 139.384089981158, 974.144637305456 ),
      ( 225, 12019.195485105, 100000.000002855, 15789.8546577193, 15798.1746821441, 85.8765834614517, 96.5318107414255, 141.645830338957, 859.144892515403 ),
      ( 250, 11442.9710221123, 100000.000000145, 19374.5769214255, 19383.31591061, 100.982390783042, 98.8191373467284, 145.42252246809, 746.812326940487 ),
      ( 252.875534150222, 11374.3425556814, 100000.000001869, 19793.4565290936, 19802.2482460225, 102.648550319966, 99.109627234611, 145.958194687118, 733.958261592853 ),
      ( 275, 45.1387737634394, 100000, 42091.8713504359, 44307.2616161103, 198.856348284277, 88.06111693403, 97.7435876938683, 144.470350469275 ),
      ( 325, 37.6566905709946, 100000, 46734.4875147157, 49390.0581047937, 215.820112428416, 96.5655226979361, 105.607510402013, 158.179860939136 ),
      ( 375, 32.4126880990928, 100000.00002373, 51785.9324390068, 54871.1439993071, 231.493349833377, 104.895031727713, 113.647042128783, 170.297328567039 ),
      ( 168.62, 13256.9323212745, 101324.999951355, 7922.1555106617, 7929.79868160773, 45.638474546863, 94.0467186210254, 138.909742484579, 1124.17753238048 ),
      ( 175, 13117.499162633, 101325.000002861, 8807.76404092525, 8815.4884553694, 50.7941379804162, 94.0272590158956, 138.759588569686, 1093.14635673649 ),
      ( 200, 12572.2949551419, 101325.000000195, 12280.482451913, 12288.541839667, 69.3436774293724, 94.8096835142932, 139.383941770956, 974.150038781749 ),
      ( 225, 12019.2185817622, 101325.000003051, 15789.8083021241, 15798.2385506726, 85.8763773650549, 96.5318911816257, 141.645582060749, 859.151624106408 ),
      ( 250, 11443.0016780425, 101325.000003955, 19374.5168271465, 19383.3715842159, 100.982150311658, 98.8191991108768, 145.422097574592, 746.820870724303 ),
      ( 253.177474975723, 11367.1334342016, 101325.000005044, 19837.4680804976, 19846.381937328, 102.822512995285, 99.1405012369967, 146.015267352529, 732.617391915108 ),
      ( 275, 45.756926166617, 101325, 42089.486132277, 44303.9049861799, 198.738124997968, 88.0736406081059, 97.7764211610978, 144.419016771443 ),
      ( 325, 38.1646474339093, 101325, 46732.9576849897, 49387.9016400064, 215.705935229041, 96.5724321973607, 105.624657845727, 158.149190134099 ),
      ( 375, 32.8468002198063, 101325.000025029, 51784.8605303537, 54869.6358919407, 231.381040923686, 104.898703152256, 113.656712548092, 170.277365356419 ),
      ( 175, 13127.1992789064, 999999.999999916, 8787.90137882275, 8864.079090363, 50.6804599905359, 94.0893752674532, 138.70119120441, 1096.1170657863 ),
      ( 200, 12584.4492173999, 1000000.00000248, 12255.7386440835, 12335.2017960043, 69.2197471874902, 94.8703549493053, 139.284868859013, 977.796988889108 ),
      ( 225, 12034.7876581525, 999999.999998016, 15758.57150213, 15841.6639528157, 85.7372842535521, 96.5862991164862, 141.480109710529, 863.688361344412 ),
      ( 250, 11463.6100717568, 1000000.00000012, 19334.1168011221, 19421.3493564638, 100.820205167515, 98.8611541013192, 145.140376882697, 752.563171420802 ),
      ( 275, 10851.3219700938, 999999.999998915, 23019.673106096, 23111.8277765366, 114.885844559687, 101.563874371022, 150.400883452087, 642.278821578406 ),
      ( 300, 10167.802023921, 1000000.00004893, 26863.6806829247, 26962.0303555182, 128.281417279076, 104.734309724546, 158.196806302006, 531.17418075838 ),
      ( 322.259208935437, 9448.56775455223, 999999.999999102, 30493.0814637304, 30598.9176101154, 139.970869493754, 107.67979998166, 169.655929741531, 427.24718261616 ),
      ( 325, 465.270365169253, 1000000.0000033, 45443.1081313147, 47592.3961042109, 192.539051594084, 102.714413525491, 126.738136851255, 132.411102761342 ),
      ( 375, 361.166702698159, 1000000.00000001, 50980.3580819466, 53749.1626049808, 210.166499843485, 107.790886362671, 122.350023080227, 155.701458306047 ),
      ( 175, 13157.200158546, 3816613.84937374, 8726.64415536616, 9016.72212053983, 50.3280340254293, 94.2819532196415, 138.527749031686, 1105.30487886286 ),
      ( 188, 12878.6277148983, 3816613.84933922, 10520.8617661039, 10817.2142916858, 60.2523338207962, 94.5382291867884, 138.55443049721, 1044.22338092574 ),
      ( 201, 12600.4452685655, 3816613.84929834, 12318.2478388283, 12621.1429959399, 69.5303038736639, 95.1115637123089, 139.044992800896, 984.470819381687 ),
      ( 214, 12321.0384438667, 3816613.84924246, 14124.3861617185, 14434.1501371034, 78.2702532165144, 95.9245470780896, 139.943767271556, 926.038064918899 ),
      ( 227, 12038.68797462, 3816613.84915976, 15944.2676698873, 16261.2967229873, 86.5586651956098, 96.9175006638937, 141.215972952645, 868.818289123406 ),
      ( 240, 11751.4993627111, 3816613.84903732, 17782.5266743774, 18107.303431048, 94.4660981098366, 98.0478687949417, 142.843533212891, 812.617381286304 ),
      ( 253, 11457.3332008089, 3816613.84885363, 19643.6289709845, 19976.7443462609, 102.051337025663, 99.288567773567, 144.821221034035, 757.184875255791 ),
      ( 266, 11153.7385968068, 3816613.84941836, 21532.0239605348, 21874.2064329222, 109.364370784307, 100.631166168352, 147.15826790679, 702.271206885368 ),
      ( 279, 10837.8557831021, 3816613.84941781, 23452.4724293784, 23804.6282363756, 116.449310719681, 102.08771253403, 149.906068188057, 647.730465262319 ),
      ( 292, 10506.1108456357, 3816613.84941864, 25410.7758584187, 25774.051470631, 123.348092135253, 103.655088340779, 153.183173477106, 593.510944436691 ),
      ( 305, 10153.544590441, 3816613.84912368, 27414.5116053125, 27790.40140568, 130.103473804255, 105.281135620266, 157.156639513607, 539.342642068855 ),
      ( 318, 9772.82136231273, 3816613.84941862, 29473.5901718974, 29864.1236430336, 136.760943938826, 106.921265891704, 162.059790547023, 484.447785466976 ),
      ( 331, 9352.66745741701, 3816613.84941866, 31601.806048565, 32009.8836228822, 143.373501146663, 108.627463068959, 168.349167107772, 427.652843293671 ),
      ( 344, 8874.27868816145, 3816613.84941853, 33821.5649958282, 34251.6409471852, 150.015490274335, 110.568457041575, 177.09799929823, 367.585365686039 ),
      ( 357, 8300.74108866875, 3816613.84941833, 36177.1926697977, 36636.9846098967, 156.820211356611, 113.033373059165, 191.244471437773, 302.318098256511 ),
      ( 370, 7534.43389859063, 3816613.84941288, 38785.784685192, 39292.3408380208, 164.122719728038, 116.685114115103, 222.566921193406, 227.352743200947 ),
      ( 383, 5912.41244999113, 3816613.84941863, 42421.1429041345, 43066.6685472964, 174.127340487799, 127.826726539836, 525.705506692888, 117.410652799429 ),
      ( 396, 2128.11210130572, 3816613.84941864, 49590.5873387724, 51384.0144082754, 195.610642633065, 124.218257937871, 239.566060907796, 111.384199525019 ),
      ( 409, 1763.83910474179, 3816613.84941864, 51873.7123466275, 54037.5230021222, 202.208533949223, 121.861527570602, 182.119341133572, 126.469163429945 ),
      ( 175, 13221.0490311047, 9999999.99997042, 8597.1761399371, 9353.54577266774, 49.5737828572579, 94.6941208185045, 138.193158762388, 1124.86057710144 ),
      ( 188, 12949.7492628137, 9999999.99995937, 10376.8068739889, 11149.0225977849, 59.4704832436219, 94.9471148736364, 138.114084639871, 1065.77601575626 ),
      ( 201, 12679.9485259298, 9999999.9999449, 12157.7674663073, 12946.4142009131, 68.714879229253, 95.5105204355844, 138.474984608498, 1008.27497130977 ),
      ( 214, 12410.2847846318, 9999999.99993262, 13945.2150398628, 14750.9983215097, 77.4142753591428, 96.3059851481046, 139.211747734964, 952.374896994974 ),
      ( 227, 12139.3758451914, 9999999.99991594, 15743.5851689838, 16567.3507502989, 85.6537792995684, 97.2736068374327, 140.279217157149, 898.007325756244 ),
      ( 240, 11865.7830938714, 9999999.9998992, 17556.7932201968, 18399.5525999013, 93.5021428365186, 98.3706696771703, 141.645746973229, 845.033641962622 ),
      ( 253, 11587.9890148237, 9999999.99988487, 19388.3745376775, 20251.3370402388, 101.015813947187, 99.5694122128756, 143.288664243641, 793.279657975709 ),
      ( 266, 11304.3898909768, 9999999.99986791, 21241.577482495, 22126.1895753467, 108.241792357219, 100.857355726266, 145.193470324296, 742.586398149567 ),
      ( 279, 11013.2851631635, 9999999.99986913, 23119.5318010105, 24027.5260871584, 115.220085705821, 102.23576765012, 147.366707528343, 692.881248251459 ),
      ( 292, 10712.7838405312, 9999999.99989022, 25025.5575351632, 25959.0217167195, 121.986136497665, 103.696813294158, 149.839221150548, 644.171308176095 ),
      ( 305, 10400.6157644396, 9999999.99992785, 26963.2836365875, 27924.7651706057, 128.572140390427, 105.208121168091, 152.638575694853, 596.378957219937 ),
      ( 318, 10073.9929893252, 9999999.99996258, 28936.4419493064, 29929.0969978615, 135.007070945028, 106.748212175454, 155.778295797092, 549.250253701724 ),
      ( 331, 9729.58642892434, 9999999.99998853, 30948.8097093965, 31976.6026246493, 141.317170158688, 108.344115538917, 159.289496089845, 502.527849794505 ),
      ( 344, 9363.47596071948, 9999999.99999824, 33004.6048622175, 34072.5843221904, 147.527764256173, 110.055392847904, 163.255343401504, 456.182868247481 ),
      ( 357, 8970.9253348482, 10000000, 35109.1385593002, 36223.8507686588, 153.665651893928, 111.931926340796, 167.825820826577, 410.470222231949 ),
      ( 370, 8545.97199997709, 9999999.99999999, 37269.5000513232, 38439.6419614567, 159.761438301189, 113.992195953561, 173.226853345751, 365.84040755079 ),
      ( 383, 8080.96775140419, 10000000, 39495.2085330098, 40732.684081438, 165.851811509946, 116.229103394244, 179.768932915498, 322.874955082636 ),
      ( 396, 7566.51707870549, 10000000.0000007, 41798.5131776144, 43120.1252080879, 171.981137392244, 118.621081115318, 187.802985937387, 282.367944041876 ),
      ( 409, 6993.31762996474, 9999999.99999999, 44192.6218595516, 45622.5583402217, 178.198066319012, 121.121406691722, 197.411983548009, 245.58115524357 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new (double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 195.356625, 3005.4325626202, 12672.4750993346, 1.85563881885024 ),
      ( 222.09325, 19638.4732304376, 12083.0025917233, 10.7689277169953 ),
      ( 248.829875, 79807.8188101322, 11470.2708603763, 39.9811873413079 ),
      ( 275.5665, 236491.355923211, 10812.262166439, 111.748443679745 ),
      ( 302.303125, 564174.586723533, 10077.9341442341, 261.085671961189 ),
      ( 329.03975, 1155470.21158224, 9207.1926274073, 550.406296723544 ),
      ( 355.776375, 2123304.10340315, 8040.12372069239, 1134.77916633767 ),
      };
    }

    [Test]
    public override void CASNumberAttribute_Test()
    {
      base.CASNumberAttribute_Test();
    }

    [Test]
    public override void ConstantsAndCharacteristicPoints_Test()
    {
      base.ConstantsAndCharacteristicPoints_Test();
    }

    [Test]
    public override void EquationOfState_Test()
    {
      base.EquationOfState_Test();
    }

    [Test]
    public override void SaturatedVaporPressure_TestMonotony()
    {
      base.SaturatedVaporPressure_TestMonotony();
    }

    [Test]
    public override void SaturatedVaporPressure_TestInverseIteration()
    {
      base.SaturatedVaporPressure_TestInverseIteration();
    }

    [Test]
    public override void SaturatedVaporProperties_TestData()
    {
      base.SaturatedVaporProperties_TestData();
    }

    [Test]
    public override void MeltingPressure_TestImplemented()
    {
      base.MeltingPressure_TestImplemented();
    }

    [Test]
    public override void SublimationPressure_TestImplemented()
    {
      base.SublimationPressure_TestImplemented();
    }
  }
}
