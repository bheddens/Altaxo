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
  /// Tests and test data for <see cref="Tetrafluoromethane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Tetrafluoromethane : FluidTestBase
  {

    public Test_Tetrafluoromethane()
    {
      _fluid = Tetrafluoromethane.Instance;

      _testDataMolecularWeight = 0.08801;

      _testDataTriplePointTemperature = 89.54;

      _testDataTriplePointPressure = 101.2;

      _testDataTriplePointLiquidMoleDensity = 21165.5015778192;

      _testDataTriplePointVaporMoleDensity = 0.135950515056038;

      _testDataCriticalPointTemperature = 227.51;

      _testDataCriticalPointPressure = 3775836.94017957;

      _testDataCriticalPointMoleDensity = 7109.4194;

      _testDataNormalBoilingPointTemperature = 145.10484436567;

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
      ( 150, 0.121720469656355, 151.8, 29373.4064095358, 30620.5261456703, 175.93921905713, 31.9575218374536, 40.2733625341137, 133.628957457737 ),
      ( 200, 0.0912880372830201, 151.8, 31140.5994222991, 32803.4679045009, 188.451463042934, 38.8639109612701, 47.1790652195047, 151.446757021531 ),
      ( 250, 0.0730297192366262, 151.800031033385, 33265.7768495874, 35344.3831022218, 199.761040345438, 46.1354436165644, 54.4503276279592, 166.955520038109 ),
      ( 300, 0.0608578052898787, 151.800016650743, 35748.0479618189, 38242.3872816101, 210.309242424889, 53.0485617745504, 61.3633171265609, 181.062358067303 ),
      ( 350, 0.0521636968833079, 151.800008877952, 38556.7328794946, 41466.8028696936, 220.238094661311, 59.1354314221117, 67.4501160067747, 194.201480921168 ),
      ( 400, 0.0456431647810901, 151.80000431371, 41644.1522654554, 44969.9515399308, 229.586196117636, 64.183957722514, 72.4985991085632, 206.601399424362 ),
      ( 450, 0.0405716633501038, 151.800001476226, 44958.4147775086, 48699.942458203, 238.368105667417, 68.2377742564895, 76.5523871915057, 218.386258540423 ),
      ( 500, 0.0365144744944478, 151.799999640474, 48456.2036367415, 52613.459129041, 246.611609273793, 71.5962385282957, 79.9108316324114, 229.612271599591 ),
      ( 550, 0.0331949631972722, 151.799998419598, 52115.5628873541, 56688.5457678434, 254.377129090719, 74.8144302835306, 83.1290089523101, 240.279934696645 ),
      ( 600, 0.0304287078132369, 151.799997592951, 55948.6835409014, 60937.3934961403, 261.7686511523, 78.7031508532124, 87.0177186504981, 250.343359415376 ),
      ( 125, 0.962647181632046, 1000.00000000002, 28612.3167155987, 29651.1189051035, 153.20603442877, 28.9388560157635, 37.2670329704393, 123.258008443062 ),
      ( 175, 0.687400684103495, 1000, 30213.2717111501, 31668.0273189426, 166.718742966282, 35.3112068978741, 43.6316603165359, 142.899679851336 ),
      ( 225, 0.534590741851475, 999.999999999999, 32157.3447784892, 34027.9345992868, 178.542445996544, 42.5058355101116, 50.8235203237453, 159.408347286424 ),
      ( 275, 0.437373031897634, 1000, 34463.4149950139, 36749.7928168501, 189.442319414461, 49.6722969723261, 57.9887784189247, 174.14546513358 ),
      ( 325, 0.370076487683556, 999.999999999999, 37114.1337187363, 39816.2778248355, 199.672465966985, 56.214644954854, 64.5305071663638, 187.73285661553 ),
      ( 375, 0.320728845746973, 1000, 40068.7373509281, 43186.6358912699, 209.308961439735, 61.792807460338, 70.1083093786104, 200.483108777315 ),
      ( 425, 0.282993843552114, 1000, 43275.8487447886, 46809.4945211351, 218.372015497623, 66.3225112777793, 74.6377840994383, 212.565654526341 ),
      ( 475, 0.253203774251785, 1000.00002006955, 46686.2688058536, 50635.6570921243, 226.879602425173, 69.9752342427108, 78.2903515395265, 224.068408531729 ),
      ( 525, 0.229088372165579, 999.999955287361, 50265.7646651387, 54630.8921739439, 234.874077871076, 73.1781871398938, 81.4931935055156, 235.018899018418 ),
      ( 575, 0.20916717988278, 999.999911767403, 54007.8566209233, 58788.72096268, 242.436622596446, 76.6143068310944, 84.9292309824744, 245.392799571261 ),
      ( 125, 9.6697030435053, 10000.0000002562, 28604.5432298941, 29638.7011513178, 133.998802247914, 28.9597983738535, 37.4150869797901, 122.903340681412 ),
      ( 175, 6.88611438917589, 10000.000000015, 30208.5801572811, 31660.7779331028, 147.547051411321, 35.3256257304853, 43.700005956633, 142.730694168089 ),
      ( 225, 5.35041307109107, 10000.0000000016, 32154.1278898509, 34023.1424625823, 159.383279767343, 42.5120826591076, 50.8584262892539, 159.317044725336 ),
      ( 275, 4.37566699586299, 10000.0000000002, 34460.9747056699, 36746.3405731947, 170.288578651783, 49.6750471367745, 58.0092950103471, 174.094354676343 ),
      ( 325, 3.70164808984624, 10000, 37112.1559857795, 39813.6553604582, 180.521513961058, 56.2158940273606, 64.5439336429129, 187.705505184476 ),
      ( 375, 3.20768383157538, 10000, 40067.0635386298, 43184.5777716609, 190.159631275501, 61.7933753061162, 70.1178068931543, 200.471056751537 ),
      ( 425, 2.83008956962449, 10000, 43274.3899639685, 46807.8470344905, 199.223716364459, 66.3227543425196, 74.6448931101791, 212.564037665796 ),
      ( 475, 2.53206054582526, 10000, 46684.970848711, 50634.3234881997, 207.732003300153, 69.9753172147873, 78.2959000255177, 224.074193824274 ),
      ( 525, 2.29083773198567, 10000, 50264.5921473552, 54629.8074833765, 215.72697734843, 73.1781901196364, 81.4976633589594, 235.030068164809 ),
      ( 575, 2.09158894790233, 10000, 54006.7851483499, 58787.8392890447, 223.289891625007, 76.6142703614272, 84.9329213850545, 245.407930886332 ),
      ( 124.314051905733, 19428.9842844983, 19547.7542634647, 16873.6689290478, 16874.6750420786, 26.6064817565029, 40.7122309912611, 75.0183156905972, 831.566746883776 ),
      ( 150, 15.7667241700259, 19547.754305263, 29360.5125556561, 30600.3233175152, 135.460750342375, 32.0031335911745, 40.4941519728138, 133.111433544013 ),
      ( 200, 11.7858590255594, 19547.7543044945, 31132.3419932566, 32790.9189592718, 148.0178331044, 38.8845722762828, 47.282817800488, 151.181320247734 ),
      ( 250, 9.41656584396931, 19547.7543044341, 33259.7966655514, 35335.6866055079, 159.344797865255, 46.1443542285423, 54.5072101289398, 166.808245639041 ),
      ( 300, 7.84234197865168, 19547.7543044265, 35743.3436817304, 38235.9350986361, 169.90124202775, 53.0525494503785, 61.3987094546412, 180.98085040318 ),
      ( 350, 6.71978979362649, 19547.7543044254, 38552.8287891359, 41461.8117937777, 179.834620614875, 59.1372519236472, 67.4742618317136, 194.160708526 ),
      ( 400, 5.87867771387159, 19547.7543044252, 41640.795005588, 44965.9907818931, 189.185483102593, 64.1847692856433, 72.5162035666382, 206.587690732109 ),
      ( 450, 5.2248625719745, 19547.7543044251, 44955.4560006829, 48696.7514003508, 197.969210411764, 68.238095812666, 76.5658615475599, 218.391408943002 ),
      ( 500, 4.70201033703289, 19547.7543044252, 48453.5496048444, 52610.8680502055, 206.213980765737, 71.5963162821284, 79.9215265007161, 229.630990123103 ),
      ( 550, 4.27433362275234, 19547.7543044252, 52113.1506394245, 56686.4376192644, 213.980422565619, 74.8143865346977, 83.1377372524097, 240.308596546701 ),
      ( 600, 3.91800185800683, 19547.7543044251, 55946.4686589442, 60935.683828528, 221.372638941836, 78.7030484650987, 87.0249991192273, 250.37934444803 ),
      ( 125, 19392.8721826299, 99999.9999623518, 16923.6328585014, 16928.7893922537, 27.0073399309191, 40.6196245018422, 75.0420576293282, 828.664150249701 ),
      ( 143.918041853583, 18289.3739672268, 99999.9998440119, 18377.0689818889, 18382.5366375901, 37.8297527181744, 42.074777958751, 79.3154912491913, 710.25431921765 ),
      ( 150, 82.7665954445528, 100000, 29303.769996975, 30511.9869045678, 121.505447064918, 32.2576201811217, 41.5997288471372, 130.873137403337 ),
      ( 200, 60.9539094199105, 100000, 31097.5274472652, 32738.1113072947, 134.271325860961, 38.9768363825331, 47.7368772717098, 150.068956477122 ),
      ( 250, 48.4357323634149, 100000.000006225, 33234.8473410478, 35299.4388136392, 145.673069030086, 46.182291193563, 54.7480853348456, 166.196694962045 ),
      ( 300, 40.235901433356, 100000.000000938, 35723.7899882761, 38209.132591239, 156.264209686923, 53.0692607277913, 61.5468625646084, 180.643724972521 ),
      ( 350, 34.4295530201313, 100000.000000141, 38536.6276834859, 41441.1091892919, 166.2164881086, 59.1448308513535, 67.5748273991064, 193.992526597473 ),
      ( 400, 30.0960167538326, 100000.000000016, 41626.8747750545, 44949.5736164978, 175.578836021416, 64.1881367274814, 72.5893376958791, 206.531448280467 ),
      ( 450, 26.7355681662451, 100000.000000001, 44943.1937314444, 48683.5294287518, 184.37010999706, 68.2394271155539, 76.6217589197785, 218.413073860172 ),
      ( 500, 24.0524498031425, 100000, 48442.5533194626, 52600.1339741756, 192.620133549108, 71.5966369370646, 79.9658569096087, 229.708675833625 ),
      ( 550, 21.8600878386939, 99999.9999999992, 52103.1577496923, 56677.7047843566, 200.390396296488, 74.8142042352397, 83.1738986049367, 240.427330382474 ),
      ( 600, 20.0348309358326, 99999.9999999974, 55937.2942470445, 60928.6016516479, 207.785488978521, 78.7026236797102, 87.0551535492748, 250.52831087276 ),
      ( 125, 19392.9126859833, 101324.99996287, 16923.6080902158, 16928.8329371279, 27.0071416979056, 40.6195897144885, 75.0418217270618, 828.671987278034 ),
      ( 144.10484436567, 18278.1009689638, 101324.999840375, 18391.8524934848, 18397.3960124758, 37.9324314134136, 42.1040452302222, 79.3710910375526, 709.007170386842 ),
      ( 150, 83.9006739861879, 101325, 29302.7882602362, 30510.4662821873, 121.389308217815, 32.2627529738989, 41.6207974251019, 130.834935725624 ),
      ( 200, 61.7728069857509, 101325, 31096.9462708516, 32737.2311299057, 134.158959875087, 38.9784468560821, 47.7446886256795, 150.050479015441 ),
      ( 250, 49.081939718311, 101325.000006564, 33234.4344755856, 35298.8394397758, 145.561971674849, 46.1829293343405, 54.7521201167863, 166.18661396254 ),
      ( 300, 40.7709852711394, 101325.000000989, 35723.467397652, 38208.6906348916, 156.153690674714, 53.0695382705523, 61.5493208832473, 180.638185759123 ),
      ( 350, 34.886633908205, 101325.000000148, 38536.3607617382, 41440.7682281266, 166.106282034692, 59.1449560459725, 67.5764892050097, 193.989769437768 ),
      ( 400, 30.4951656121261, 101325.000000017, 41626.645588971, 44949.3033927943, 175.468819535704, 64.1881922028634, 72.5905436850991, 206.530530386977 ),
      ( 450, 27.0899285493157, 101325.000000001, 44942.9919195053, 48683.3118622303, 184.260217882736, 68.2394490078645, 76.6226796088989, 218.413434759794 ),
      ( 500, 24.3711193615946, 101325, 48442.3723834523, 52599.957371513, 192.510327930589, 71.5966421929821, 79.9665865885763, 229.709955881426 ),
      ( 550, 22.1496336056232, 101324.999999999, 52102.9933456885, 56677.5611152554, 200.280653557851, 74.8142012216327, 83.1744935849031, 240.429283833177 ),
      ( 600, 20.3001524838379, 101324.999999997, 55937.1433204856, 60928.4851382708, 207.675793559376, 78.7026166825221, 87.0556495796999, 250.530760308894 ),
      ( 125, 19420.1885251209, 999999.999975472, 16906.9297292333, 16958.4225352214, 26.873396500027, 40.5972450661009, 74.8844841251785, 833.937088297779 ),
      ( 150, 17957.68956111, 999999.999754355, 18839.028005531, 18894.7144565274, 40.9772907690569, 43.031680119104, 80.8756525019946, 676.144502496665 ),
      ( 175, 16282.8228165225, 1000000.00000181, 20961.2653584078, 21022.6797710849, 54.0805350751858, 46.4623868080539, 90.0403446841408, 513.043596072435 ),
      ( 187.387447351473, 15285.9714699925, 999999.999999503, 22115.6854190503, 22181.1048791064, 60.4733858837291, 48.0078495548238, 97.6532748809687, 429.204892447886 ),
      ( 200, 709.128452588512, 1000000.00000028, 30623.5649817486, 32033.7467285816, 112.668745846469, 40.998188771409, 57.2237215700569, 135.896168873135 ),
      ( 250, 516.972707617622, 999999.999999999, 32938.0955823136, 34872.4336726323, 125.332317653017, 46.7285997370589, 58.0954320634057, 159.277552302899 ),
      ( 300, 415.898360417831, 1000000, 35500.4083135675, 37904.8419328666, 136.375095020246, 53.2760504582341, 63.3625687270049, 176.986426390579 ),
      ( 350, 350.268073385811, 1000000, 38354.5965397755, 41209.5527175786, 146.552880966782, 59.2327048574591, 68.7451600807083, 192.218388261921 ),
      ( 400, 303.445525168296, 1000000, 41471.7467341827, 44767.2311524993, 156.047164469377, 64.2259245413107, 73.4192469874237, 205.972645049167 ),
      ( 450, 268.094082618731, 1000000.00000433, 44807.153003494, 48537.186841751, 164.923477210147, 68.2540443598286, 77.2474843538785, 218.690470953677 ),
      ( 500, 240.346840966464, 999999.999999847, 48320.8735978757, 52481.5274095868, 173.232069456091, 71.6000201416226, 80.458240649542, 230.584590675034 ),
      ( 550, 217.935083669891, 999999.999992391, 51992.7504009173, 56581.2727404737, 181.044671306737, 74.8120739487193, 83.5737147920418, 241.74126850714 ),
      ( 600, 199.426695766539, 999999.999974602, 55836.0205508591, 60850.3943593951, 188.471521605172, 78.6978616430163, 87.387673459256, 252.165009400725 ),
      ( 125, 19507.5413184752, 3964628.78718835, 16853.5430954028, 17056.77879397, 26.4417489283636, 40.5399518585518, 74.400535083605, 850.633031128702 ),
      ( 150, 18091.1417669963, 3964628.78718961, 18757.4287326577, 18976.5762490639, 40.4265571382795, 43.0447675710549, 79.9459028494326, 697.145779631265 ),
      ( 175, 16513.5898987306, 3964628.78718854, 20826.0666289251, 21066.1494220368, 53.2960017868007, 46.3420168068975, 87.5672500451175, 543.558053298098 ),
      ( 200, 14559.6550870333, 3964628.78718862, 23129.6452931809, 23401.9476769592, 65.7522319394006, 49.1337357901349, 101.348220383235, 389.439227530841 ),
      ( 225, 10908.5864751138, 3964628.78718853, 26219.915658104, 26583.3567690338, 80.6505606136802, 55.1332189753818, 208.844702298171, 183.485316977433 ),
      ( 250, 2790.16722533213, 3964628.78718855, 31559.5657788199, 32980.4945142711, 108.134020983039, 51.2350226826024, 92.6066740979404, 135.84164425855 ),
      ( 275, 2177.17000252162, 3964628.78718976, 33192.0392264058, 35013.0402426783, 115.895380156651, 51.9477989689117, 75.1014866571836, 153.718313452672 ),
      ( 300, 1849.58698848826, 3964628.78718858, 34696.8013653108, 36840.322492927, 122.257060250669, 54.2566121077103, 71.9778058687312, 167.057671260164 ),
      ( 325, 1629.22012432215, 3964628.78718854, 36203.6517012278, 38637.103589037, 128.009780802595, 56.9146554672274, 72.0439179695749, 178.213959084625 ),
      ( 350, 1465.60589752509, 3964628.78718855, 37745.9835500897, 40451.0960185121, 133.386510767299, 59.561782183153, 73.1758694199944, 188.039922807832 ),
      ( 375, 1337.14760797903, 3964628.78718854, 39333.9060690382, 42298.8956958609, 138.485313087887, 62.0589430818013, 74.6793499428208, 196.951962537309 ),
      ( 400, 1232.55316743557, 3964628.78718856, 40969.1497014467, 44185.7482968949, 143.355747449729, 64.3509657013569, 76.2698474055732, 205.187096579737 ),
      ( 425, 1145.16111507863, 3964628.78718855, 42649.987450897, 46112.0581892283, 148.026543801883, 66.4255529030973, 77.8232236656241, 212.89324621688 ),
      ( 450, 1070.71041112941, 3964628.787257, 44373.4073753706, 48076.2095019279, 152.516854276559, 68.2984245624052, 79.2940997967172, 220.168067879249 ),
      ( 475, 1006.31224830518, 3964628.78718435, 46136.3181463354, 50076.0781898622, 156.841609570662, 70.0071901604735, 80.6838334627848, 227.077989699622 ),
      ( 500, 949.920253811052, 3964628.78718855, 47936.355996358, 52109.9998062279, 161.014377079669, 71.6085627818543, 82.0262390512908, 233.668475102713 ),
      ( 525, 900.03411460527, 3964628.78718855, 49772.5074406469, 54177.4835663878, 165.04902359353, 73.1769891080967, 83.380573734965, 239.970037138673 ),
      ( 550, 855.522957713479, 3964628.78718855, 51645.6390632621, 56279.79733037, 168.960749711293, 74.8039305688536, 84.8278200709626, 246.002126648665 ),
      ( 575, 815.51467595484, 3964628.78718855, 53558.9770422709, 58420.4821801725, 172.766768520482, 76.5974650330332, 86.4685907839784, 251.776017668371 ),
      ( 600, 779.323683318056, 3964628.78718855, 55518.557907952, 60605.8263588589, 176.486770341611, 78.682055697026, 88.421886482759, 257.297337454251 ),
      ( 125, 19674.3664987327, 10000000.0000003, 16751.8195850721, 17260.0951628725, 25.603854410254, 40.4881951358691, 73.5555232954048, 881.84157005066 ),
      ( 150, 18336.6964667036, 9999999.99999893, 18607.0859426662, 19152.4404463063, 39.3901981880207, 43.1612785678074, 78.4621021989183, 735.047551834272 ),
      ( 175, 16905.1826457984, 10000000.0000002, 20594.0346943479, 21185.569267474, 51.9152069266298, 46.326744160086, 84.2155024937307, 594.785022984679 ),
      ( 200, 15291.0226558642, 9999999.9999943, 22721.2951060791, 23375.2736021583, 63.6003281979779, 48.5503527517009, 91.4527258777564, 467.163883499738 ),
      ( 225, 13317.8278129753, 9999999.99999996, 25048.0293895444, 25798.9025905222, 75.0048615091107, 50.9280751514027, 103.655962467101, 344.353926849331 ),
      ( 250, 10653.4509563855, 10000000, 27696.6384720548, 28635.3014499893, 86.9392513587597, 54.0116600777002, 124.220734347446, 232.725312438145 ),
      ( 275, 7594.1570455484, 10000000, 30500.3024385058, 31817.1042823473, 99.0711763088292, 56.0400292472745, 122.016200864408, 177.890636428824 ),
      ( 300, 5676.29394326315, 9999999.99999932, 32799.2114795642, 34560.9243330481, 108.635760103504, 56.7332259170393, 98.9932058581092, 174.52213545701 ),
      ( 325, 4639.69478902234, 10000000, 34719.497242035, 36874.8114285759, 116.05005904621, 58.2423788339156, 87.8175785005368, 182.624611654793 ),
      ( 350, 3992.39203847064, 10000000, 36503.3166085831, 39008.0806456917, 122.375678182683, 60.289514106775, 83.5506692789456, 192.297929367131 ),
      ( 375, 3539.08188016635, 9999999.99999999, 38250.07326388, 41075.6648547504, 128.082165817072, 62.4699269128107, 82.1567547268306, 201.794129169993 ),
      ( 400, 3197.75041909671, 10000000, 39998.9203160719, 43126.1187178861, 133.375542495536, 64.5862546725836, 82.0146075230452, 210.801037657338 ),
      ( 425, 2928.1571735058, 10000000, 41765.9181465268, 45181.0353712717, 138.35855256473, 66.5584615529557, 82.4407013470561, 219.298972059729 ),
      ( 450, 2707.97936187613, 10000000, 43557.5066718424, 47250.2970013344, 143.089393112325, 68.3691176728884, 83.1293658097521, 227.329078860035 ),
      ( 475, 2523.66571529545, 9999999.99999998, 45376.0786255717, 49338.5685620922, 147.605475038858, 70.0388018175203, 83.9487235661675, 234.938655769519 ),
      ( 500, 2366.41913101651, 10000000, 47222.6799230683, 51448.474022233, 151.934235692829, 71.6150271006768, 84.8587693900385, 242.167775863162 ),
      ( 525, 2230.22854702731, 10000000, 49098.5369870805, 53582.3823819075, 156.098583877572, 73.1670298771705, 85.8750976451974, 249.046776613994 ),
      ( 550, 2110.81811639145, 10000000, 51006.0546754844, 55743.5542839753, 160.119882075304, 74.7831907435736, 87.0514258847554, 255.596839822609 ),
      ( 575, 2005.04641321994, 9999999.99999999, 52949.5546406617, 57936.9703603511, 164.019697196286, 76.5696941343442, 88.4705521487683, 261.83158597759 ),
      ( 600, 1910.54342641291, 9999999.99999998, 54935.8773457485, 60169.9902487853, 167.82088923894, 78.6497991875491, 90.2393848564967, 267.759178114443 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new(double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 124.0325, 17210.0908644357, 19444.717635355, 16.8360152659731 ),
      ( 141.27875, 76774.5281741897, 18447.4846672639, 67.259372827903 ),
      ( 158.525, 238349.270062556, 17376.6659821264, 193.720232171583 ),
      ( 175.77125, 580849.812385098, 16189.003623514, 456.058600427198 ),
      ( 193.0175, 1198959.61137812, 14793.1949456757, 957.306944306532 ),
      ( 210.26375, 2205448.24140234, 12947.185052907, 1951.02212222123 ),
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
