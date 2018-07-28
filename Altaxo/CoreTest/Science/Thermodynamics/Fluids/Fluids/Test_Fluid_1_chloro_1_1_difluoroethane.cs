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
  /// Tests and test data for <see cref="Fluid_1_chloro_1_1_difluoroethane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Fluid_1_chloro_1_1_difluoroethane : FluidTestBase
  {

    public Test_Fluid_1_chloro_1_1_difluoroethane()
    {
      _fluid = Fluid_1_chloro_1_1_difluoroethane.Instance;

      _testDataMolecularWeight = 0.10049503;

      _testDataTriplePointTemperature = 142.72;

      _testDataTriplePointPressure = 3.632;

      _testDataTriplePointLiquidMoleDensity = 14439.0154849552;

      _testDataTriplePointVaporMoleDensity = 0.00306135934636108;

      _testDataCriticalPointTemperature = 410.26;

      _testDataCriticalPointPressure = 4054766.81273453;

      _testDataCriticalPointMoleDensity = 4438;

      _testDataNormalBoilingPointTemperature = 264.026730893869;

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
      _testDataEquationOfState = new(double temperature, double moleDensity, double pressure, double internalEnergy, double enthalpy, double entropy, double isochoricHeatCapacity, double isobaricHeatCapacity, double speedOfSound)[]
      {
      ( 144.144699717105, 14407.9545710881, 5.44799987937357, 5170.52307040027, 5170.52344852472, 27.1056956813573, 67.5134720712653, 109.999890618924, 1446.98506932505 ),
      ( 150, 0.00436840427833493, 5.44800287030804, 33008.6428845677, 34255.7808606308, 227.467187532528, 45.2828108859971, 53.5992504774659, 121.19701165073 ),
      ( 200, 0.00327623637963744, 5.44800068883566, 35544.3299430338, 37207.2138309902, 244.374948398471, 55.9944162770485, 64.3092493306579, 137.854725277687 ),
      ( 250, 0.00262097898704247, 5.4480002764735, 38597.0524235306, 40675.6651493125, 259.81264643902, 66.0106076715968, 74.3251972970366, 152.607232935856 ),
      ( 300, 0.00218414643141219, 5.44800014322284, 42133.5709092741, 44627.9092305836, 274.198448250611, 75.316390004824, 83.6309157391746, 166.013643167937 ),
      ( 350, 0.0018721244932467, 5.44800008505617, 46114.391739059, 49024.4546674106, 287.736317267885, 83.7688564976689, 92.0833586655071, 178.413622342845 ),
      ( 400, 0.00163810846563607, 5.44800005467051, 50495.8003474139, 53821.5874787044, 300.536416797572, 91.3441648612149, 99.6586561544375, 190.016770145939 ),
      ( 450, 0.00145609617134465, 5.44800003687603, 55235.0032139447, 58976.5143476804, 312.671874494031, 98.091740864984, 106.40622630674, 200.964087243486 ),
      ( 142.72, 14439.0231066305, 999.999995423129, 5013.79040584503, 5013.85966260763, 26.0129573201477, 67.327383091183, 110.002255920351, 1457.86654731337 ),
      ( 150, 14281.2998784575, 999.999996771035, 5814.691252636, 5814.76127427306, 31.4862105835498, 68.2700170513394, 110.050269088788, 1403.71278747657 ),
      ( 175, 13753.5728618219, 1000.00000350118, 8577.34986952449, 8577.4225779046, 48.5185937092272, 71.4226625870713, 111.19275662407, 1239.47072621742 ),
      ( 186.882023223968, 13507.0162335552, 1000.0000014301, 9904.1457297806, 9904.21976537693, 55.8536370811397, 72.9206495258078, 112.178367898325, 1170.085686626 ),
      ( 200, 0.60206429996724, 1000.00000000033, 35537.6659314208, 37198.6180922693, 201.002356302779, 56.1112169602048, 64.4936319135651, 137.747712265311 ),
      ( 250, 0.481313263692065, 1000.00000000002, 38594.3638748718, 40672.0128312483, 216.462649680169, 66.0388997200324, 74.3750516033681, 152.554900418974 ),
      ( 300, 0.401004176655933, 1000, 42132.0988840171, 44625.8384962556, 230.854300338256, 75.3261372204975, 83.6504841334826, 165.982466052627 ),
      ( 350, 0.343684163519065, 1000, 46113.4278072979, 49023.0759847431, 244.39432213913, 83.7730405923273, 92.093052967994, 178.393127392668 ),
      ( 400, 0.300708244718598, 1000, 50495.0958739195, 53820.5783559039, 257.195414580413, 91.3462582803933, 99.6642726957892, 190.002540288884 ),
      ( 450, 0.26728820335925, 1000, 55234.4510692242, 58975.7310338171, 269.331406461816, 98.092915368023, 106.409855125569, 200.95389395061 ),
      ( 142.72, 14439.0448122513, 3837.56603069175, 5013.74798820634, 5014.01376520756, 26.012660109592, 67.3275204088697, 110.002225697818, 1457.87660071007 ),
      ( 150, 14281.3229779393, 3837.56603747116, 5814.64637457836, 5814.91508680085, 31.4859113946727, 68.2701491037998, 110.0502194744, 1403.72320661381 ),
      ( 175, 13753.6014748991, 3837.56603857573, 8577.29521412718, 8577.57423675595, 48.5182813905804, 71.422777895844, 111.192631010494, 1239.48255040224 ),
      ( 200, 13235.6503491647, 3837.56603271726, 11384.3082575888, 11384.5981992185, 63.507816891445, 74.5970384460804, 113.548103902354, 1098.16910330032 ),
      ( 203.342944431162, 13166.4169201926, 3837.56603543769, 11764.5439218203, 11764.8353880604, 65.3932797998342, 75.0289672571387, 113.941168112072, 1080.49817688687 ),
      ( 225, 2.05695098115057, 3837.56603382624, 36992.3798046225, 38858.037308857, 197.653844955279, 61.2971372302178, 69.7542778791899, 145.148004900368 ),
      ( 275, 1.6804909106891, 3837.56603381151, 40299.6629240777, 42583.2611330308, 212.57299432143, 70.8261716468033, 79.195300524422, 159.300089272661 ),
      ( 325, 1.42116385557053, 3837.56603381023, 44066.6364878852, 46766.9345701704, 226.530459330683, 79.6774504487302, 88.0198017588753, 172.22760678299 ),
      ( 375, 1.23134581833889, 3837.56603381, 48254.6151933594, 51371.177556796, 239.694249069682, 87.6752314713544, 96.0065041587782, 184.239349731872 ),
      ( 425, 1.08631999242659, 3837.56603380997, 52820.8522507403, 56353.4817342848, 252.156941210088, 94.8230697054376, 103.148797204817, 195.519042449548 ),
      ( 142.72, 14439.0919498463, 9999.99999970319, 5013.65587114822, 5014.34843547529, 26.0120146596031, 67.3278186342697, 110.002160080938, 1457.89843321577 ),
      ( 150, 14281.3731424605, 10000.0000062955, 5814.54891447308, 5815.2491272542, 31.4852616492926, 68.2704358950029, 110.050111746876, 1403.74583335264 ),
      ( 175, 13753.6636126941, 10000.0000028019, 8577.1765217263, 8577.90360072753, 48.5176031353026, 71.4230283267918, 111.192358249492, 1239.50822826298 ),
      ( 200, 13235.7277444252, 10000.0000022352, 11384.1626277549, 11384.9181585572, 63.507088726992, 74.5972522893458, 113.547612437229, 1098.19849828464 ),
      ( 217.335451611829, 12875.4614979595, 10000.0000026398, 13371.1379500524, 13371.9146212423, 73.0335922408241, 76.8594705756926, 115.767595318006, 1008.99686507878 ),
      ( 225, 5.38422647085508, 10000.0000008446, 36966.1153110831, 38823.3923136339, 189.573360843889, 61.6917879578998, 70.4003287050248, 144.688054992046 ),
      ( 275, 4.38798975969589, 10000.0000000733, 40287.5602835711, 42566.5081726306, 204.565768068022, 70.9290913557437, 79.387845095157, 159.052194042232 ),
      ( 325, 3.70750352850434, 10000.0000000126, 44059.3571451422, 46756.5899119163, 218.544890444213, 79.7164996375815, 88.103967179144, 172.071914628287 ),
      ( 375, 3.21092332054577, 10000.000000003, 48249.5557616804, 51363.924745834, 231.717594797853, 87.6933332565796, 96.0516922956922, 184.133918295034 ),
      ( 425, 2.83206776423186, 10000.0000000009, 52817.0112311995, 56348.0001878543, 244.18474349074, 94.8326790221991, 103.176524418164, 195.444575933037 ),
      ( 142.72, 14439.7801886755, 100000.000005104, 5012.31095779671, 5019.23627097312, 26.002589947659, 67.3321753709352, 110.001204636441, 1458.21716681686 ),
      ( 150, 14282.1055623956, 99999.9999952488, 5813.12601849666, 5820.12778721755, 31.4757743595859, 68.2746257120981, 110.048541802747, 1404.07615747796 ),
      ( 175, 13754.5707761566, 99999.999997427, 8575.4437652801, 8582.71407575542, 48.5077001629557, 71.4266875137651, 111.188380612739, 1239.88307149261 ),
      ( 200, 13236.8575375555, 100000.000002813, 11382.036820172, 11389.5914833328, 63.4964579159652, 74.6003778645163, 113.540445399421, 1098.62756409425 ),
      ( 225, 12716.079883697, 100000.000000301, 14260.0381934962, 14267.9022523032, 77.0532517196356, 77.8795742746874, 116.87625003185, 971.751126098055 ),
      ( 250, 12180.0608353661, 100000.000001959, 17232.5185451877, 17240.7286848047, 89.5780935309307, 81.2626737936279, 121.095884421773, 854.085499574556 ),
      ( 262.702509105916, 11897.540458792, 100000.000000854, 18786.1064759058, 18794.5115744509, 95.6399723158808, 83.0130347751624, 123.587559068404, 796.612416701546 ),
      ( 275, 45.2994767152824, 100000, 40096.4365575414, 42303.9675766859, 184.718589031702, 72.8335104364208, 82.9083464234941, 155.228786268899 ),
      ( 325, 37.7126283677744, 99999.9999999999, 43950.3193897834, 46601.951066706, 199.06313268488, 80.3273076433915, 89.4260000782994, 169.747085646546 ),
      ( 375, 32.4459779904697, 100000.000031918, 48174.7735270047, 51256.8196302626, 212.372953014006, 87.9644004792357, 96.7340107313593, 182.577100297437 ),
      ( 425, 28.5150817148422, 100000.000008864, 52760.5262656642, 56267.4423954824, 224.906905221581, 94.9746514809943, 103.589359675508, 194.351036846785 ),
      ( 142.72, 14439.7903184562, 101325.000001334, 5012.29116356989, 5019.30823222301, 26.0024512206605, 67.3322395294944, 110.001190610203, 1458.22185758146 ),
      ( 150, 14282.1163422572, 101324.999999363, 5813.10507689839, 5820.19961370031, 31.4756347134655, 68.2746874142426, 110.048518736835, 1404.08101875587 ),
      ( 175, 13754.5841269329, 101324.999999708, 8575.41826504802, 8582.78489998693, 48.5075544067518, 71.4267414094024, 111.188322135969, 1239.88858761293 ),
      ( 200, 13236.8741631447, 101324.999998358, 11382.0055383794, 11389.6602912123, 63.4963014592443, 74.60042391449, 113.540340033042, 1098.63387758951 ),
      ( 225, 12716.1008373716, 101324.999998753, 14259.999392496, 14267.9676369519, 77.053079212771, 77.8796109910584, 116.87607697304, 971.758441193879 ),
      ( 250, 12180.0877694324, 101325.000000378, 17232.4696193123, 17240.7885248833, 89.5778977543271, 81.2626975833053, 121.095605277911, 854.094119024725 ),
      ( 263.026730893869, 11890.2436596879, 101324.999998234, 18826.1262048716, 18834.6478973532, 95.792236717462, 83.057963498836, 123.654130624829, 795.169616033888 ),
      ( 275, 45.9226703301247, 101325, 40093.4057549658, 42299.8323253635, 184.597913754499, 72.8675835479341, 82.9712546674746, 155.169407560968 ),
      ( 325, 38.2221720030468, 101325, 43948.6745957412, 46599.6228461944, 198.948587685353, 80.3368874288139, 89.4468343965602, 169.712118750987 ),
      ( 375, 32.8810079961783, 101325.000033678, 48173.6598623654, 51255.2259763196, 212.260527858454, 87.9684866896699, 96.7443785346495, 182.553937616684 ),
      ( 425, 28.8958399623149, 101325.000009348, 52759.689191546, 56266.2493102861, 224.795488193152, 94.9767646750767, 103.595549921812, 194.334852921631 ),
      ( 150, 14289.4078681973, 999999.999996338, 5798.94540558256, 5868.92731170632, 31.3811058583724, 68.3166603263165, 110.033187041744, 1407.36602153426 ),
      ( 175, 13763.6081114693, 1000000.00000094, 8558.18794202275, 8630.84330912578, 48.4089455935593, 71.4634559414372, 111.149209063321, 1243.61391666696 ),
      ( 200, 13248.1008299366, 999999.999997121, 11360.8871402045, 11436.3696574976, 63.390533454079, 74.6318845138688, 113.469855065195, 1102.8940766798 ),
      ( 225, 12730.2312695874, 999999.999999942, 14233.8357669497, 14312.3889352954, 76.9365831963946, 77.9048646499448, 116.760515145107, 976.688483145563 ),
      ( 250, 12198.2161307431, 999999.999999748, 17199.5344967662, 17281.5136967805, 89.4458891756626, 81.2794198945452, 120.909847014067, 859.892940753935 ),
      ( 275, 11638.7796205063, 999999.999999759, 20279.3089842099, 20365.2286452573, 101.198458054342, 84.7278874879625, 125.948414630584, 748.902071815233 ),
      ( 300, 11033.8584238714, 1000000.00030644, 23497.8855555358, 23588.5156834468, 112.41306006023, 88.2380206521967, 132.153320613901, 640.591299442932 ),
      ( 325, 10353.531753647, 999999.999999261, 26892.7575512952, 26989.3429507312, 123.297148088439, 91.8453884021248, 140.383608864544, 531.3758484557 ),
      ( 337.72903631008, 9960.48614548837, 1000000.00000004, 28710.6226109164, 28811.0193170002, 128.794624109668, 93.7606678484987, 146.090941979811, 473.670213437563 ),
      ( 350, 413.46774533183, 1000000.00000068, 44912.4687730812, 47331.0371167814, 183.410001293388, 90.4384652252568, 110.102508918368, 153.250372728949 ),
      ( 400, 333.851665971128, 1000000.00000001, 49710.4651826287, 52705.8074316815, 197.767642580182, 93.872874433709, 107.217709304146, 174.353649492245 ),
      ( 450, 285.696780540786, 1000000, 54645.8202682291, 58146.0347197435, 210.578847062565, 99.3831262216453, 110.736339162528, 190.294076349283 ),
      ( 150, 14315.5127036278, 4257505.15337083, 5748.34049418691, 6045.74550101505, 31.0415086337045, 68.4707764848188, 109.982674467253, 1419.0756006308 ),
      ( 166, 13980.8252222108, 4257505.15336608, 7504.21948636336, 7808.74408242242, 42.2088429390392, 70.4785973437471, 110.490297457874, 1311.9559641023 ),
      ( 182, 13652.9827097849, 4257505.15337347, 9272.42987527846, 9584.26687411405, 52.4194623367986, 72.4732174869466, 111.530516673366, 1216.07522436024 ),
      ( 198, 13328.4757974094, 4257505.15336747, 11060.6628052827, 11380.092064718, 61.8758865148695, 74.4940259600009, 113.016171099957, 1128.46135152676 ),
      ( 214, 13004.2875772044, 4257505.15337438, 12875.4368960317, 13202.829313963, 70.7276371367845, 76.5575099075041, 114.885791716867, 1047.10964254683 ),
      ( 230, 12677.6449066095, 4257505.15337067, 14722.4169067598, 15058.2446716746, 79.0880277440308, 78.6647094091739, 117.094796249983, 970.598265575528 ),
      ( 246, 12345.8188634723, 4257505.15337347, 16606.6629160705, 16951.5169270078, 87.0450017620236, 80.8084937431794, 119.61455513067, 897.863375554271 ),
      ( 262, 12005.9355926406, 4257505.15337244, 18532.8923733902, 18887.5090644861, 94.6686070569686, 82.9790881930404, 122.434816222017, 828.063614977702 ),
      ( 278, 11654.7620965929, 4257505.15337244, 20505.7954188433, 20871.097182885, 102.016463632914, 85.1677368288899, 125.56850634248, 760.494033446023 ),
      ( 294, 11288.4214865281, 4257505.15337034, 22530.4457931378, 22907.6026133763, 109.138059479236, 87.3690127334443, 129.060233575522, 694.525228036255 ),
      ( 310, 10901.9614759997, 4257505.15286996, 24612.8872088881, 25003.4137359028, 116.078533712012, 89.5824982049544, 133.002480429708, 629.550805278461 ),
      ( 326, 10488.623378914, 4257505.15337032, 26761.0697394402, 27166.9862262434, 122.882694264085, 91.8147263244564, 137.56914379658, 564.926381208585 ),
      ( 342, 10038.4584298278, 4257505.15337129, 28986.5510438433, 29410.6704624904, 129.600542645436, 94.0828547921754, 143.092272551015, 499.872584246637 ),
      ( 358, 9535.33743622838, 4257505.15337111, 31308.084140795, 31754.5817274661, 136.297354154586, 96.4237420577898, 150.264264643967, 433.275901712816 ),
      ( 374, 8949.17644433193, 4257505.15336913, 33760.7982372186, 34236.5409136373, 143.078078438465, 98.9213351823509, 160.801095835594, 363.181464706104 ),
      ( 390, 8208.5624007578, 4257505.15337129, 36428.0497934607, 36946.7161500664, 150.17097380934, 101.818363643253, 180.642927796891, 285.106464904534 ),
      ( 406, 7005.09185214399, 4257505.15337098, 39664.421933659, 40272.1948570173, 158.517781151411, 106.452696049141, 262.70750374137, 182.121364297575 ),
      ( 422, 2390.74648304252, 4257505.15337125, 47658.222057756, 49439.0487508285, 180.680699422585, 109.823384837136, 252.561840814118, 118.156913375524 ),
      ( 438, 1877.17729489832, 4257505.15337126, 50313.5852344467, 52581.6209521927, 187.99890937166, 106.412656542707, 166.724301354529, 138.264432085199 ),
      ( 454, 1633.36333862551, 4257505.15337126, 52451.7952607404, 55058.3831843765, 193.554939631226, 105.783653118893, 146.191137247666, 151.946782462266 ),
      ( 470, 1474.18859791621, 4257505.15338496, 54430.8422030108, 57318.8750906638, 198.449135327135, 106.128844421962, 137.428136008422, 162.770990879312 ),
      ( 150, 14360.3502871894, 10000000.0000037, 5661.76793485418, 6358.12977840368, 30.4540197186213, 68.7491745269042, 109.911506945252, 1439.00748129489 ),
      ( 166, 14031.8967499073, 9999999.9999952, 7406.68298830028, 8119.34501669365, 41.6101274850821, 70.7367380181942, 110.337120007247, 1333.44308612594 ),
      ( 182, 13711.1629354063, 9999999.9999976, 9162.35889044077, 9891.6916280873, 51.8025455342675, 72.7127210029369, 111.28446010132, 1239.27670748557 ),
      ( 198, 13394.853351011, 9999999.9999968, 10936.1784834222, 11682.7338758515, 61.233845776928, 74.7153375118167, 112.661193951264, 1153.57298010089 ),
      ( 214, 13080.2270377897, 10000000.0000002, 12734.2619472918, 13498.7746710473, 70.0531390531267, 76.7599342709839, 114.399295277084, 1074.36967459657 ),
      ( 230, 12764.8750591431, 9999999.99999929, 14561.7517460023, 15345.1515014771, 78.3728684074862, 78.8463061514391, 116.445331157808, 1000.29714537854 ),
      ( 246, 12446.5602351818, 10000000.0000023, 16423.0110967125, 17226.4459261794, 86.2795742713724, 80.9658209895681, 118.758153856053, 930.357743893402 ),
      ( 262, 12123.0890233878, 9999999.99913726, 18321.8076750607, 19146.679948113, 93.8412081243662, 83.1067477332572, 121.309081807264, 863.796097367487 ),
      ( 278, 11792.1957372517, 9999999.99947186, 20261.5037538735, 21109.5222418877, 101.112310931094, 85.2576222755062, 124.082817063223, 800.021633946522 ),
      ( 294, 11451.4234430009, 9999999.99969871, 22245.2586876797, 23118.5125717469, 108.13780397867, 87.409070598674, 127.078827914174, 738.561425768514 ),
      ( 310, 11097.9859414704, 9999999.99985257, 24276.2501166891, 25177.3145127509, 114.955867511245, 89.5546230551739, 130.313610851392, 679.030931030365 ),
      ( 326, 10728.5914865323, 9999999.99994621, 26357.9279586988, 27290.0167620147, 121.600246730719, 91.690977319246, 133.824681426479, 621.115667752399 ),
      ( 342, 10339.2001174012, 9999999.99998861, 28494.328137319, 29461.5209458959, 128.102263371415, 93.8180536103553, 137.677691750926, 564.560044835691 ),
      ( 358, 9924.66979715566, 9999999.99999909, 30690.4930352246, 31698.0832326199, 134.492805832348, 95.9391047730053, 141.979051399353, 509.16193778714 ),
      ( 374, 9478.21755823663, 9999999.9999998, 32953.0769062419, 34008.1275989019, 140.804625163342, 98.0611192419129, 146.898121464869, 454.775286418121 ),
      ( 390, 8990.58077452327, 9999999.99999998, 35291.2549646591, 36403.5301614225, 147.075381570603, 100.195736558561, 152.704960221454, 401.333497176093 ),
      ( 406, 8448.75852788674, 10000000.0000488, 37718.049026483, 38901.6548742584, 153.351964874187, 102.360476964914, 159.825248935826, 348.939230271887 ),
      ( 422, 7834.58278369093, 9999999.99999997, 40251.7678169371, 41528.1599715795, 159.695846509239, 104.57707820116, 168.861651665643, 298.158250965173 ),
      ( 438, 7125.8709042195, 10000000, 42914.6292417822, 44317.9664807544, 166.183203681239, 106.848824282352, 180.226908687027, 250.826512827892 ),
      ( 454, 6312.94096689814, 10000000, 45715.2850982348, 47299.3328586106, 172.867310755045, 109.057537634773, 192.098803965999, 211.394742615191 ),
      ( 470, 5449.7551028509, 9999999.99999759, 48593.7969352435, 50428.7417742816, 179.641081928582, 110.808982697633, 197.138943870457, 185.925646917628 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new(double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 176.1625, 320.031308283754, 13729.3723932921, 0.218644059776435 ),
      ( 209.605, 5599.71650998038, 13036.4992223968, 3.23067252126299 ),
      ( 243.0475, 39710.7259272765, 12330.2615423423, 20.0858049545209 ),
      ( 276.49, 163605.932563387, 11581.5421633616, 75.4916411205947 ),
      ( 309.9325, 477879.90659786, 10752.808481145, 210.324805470562 ),
      ( 343.375, 1112867.50334723, 9780.06356627642, 494.012056158458 ),
      ( 376.8175, 2225479.20370633, 8506.42444917384, 1093.52127642185 ),
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
