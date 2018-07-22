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
	/// Tests and test data for <see cref="MethylHexadecanoate"/>.
	/// </summary>
	/// <remarks>
	/// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
	/// </remarks>
  [TestFixture]
  public class Test_MethylHexadecanoate : FluidTestBase
    {

    public Test_MethylHexadecanoate()
      {
      _fluid = MethylHexadecanoate.Instance;

    _testDataMolecularWeight = 0.27045066;

    _testDataTriplePointTemperature = 242;

    _testDataTriplePointPressure = 8.149E-07;

    _testDataTriplePointLiquidMoleDensity = double.NaN;

    _testDataTriplePointVaporMoleDensity = double.NaN;

    _testDataCriticalPointTemperature = 755;

    _testDataCriticalPointPressure = 1349955.55188433;

    _testDataCriticalPointMoleDensity = 897;

    _testDataNormalBoilingPointTemperature = 602.268911473709;

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
      ( 325, 3120.93712659018, 1.04884604861789, -191273.421384841, -191273.421048773, -419.029690797834, 501.632951482977, 591.460810846433, 1278.24363591589 ),
      ( 350, 0.000360423040276658, 1.0488465636831, -92549.1721920064, -89639.129141268, -121.326154321693, 459.838990682463, 468.153864887954, 104.66354522057 ),
      ( 400, 0.000315369110849298, 1.04884649525148, -68273.5042278047, -64947.7298917358, -55.4601033632384, 510.64686995516, 518.961572081692, 111.791474598004 ),
      ( 450, 0.000280327618768943, 1.04884646005482, -41536.9500040187, -37795.4475981523, 8.44636908166985, 558.302900659361, 566.617509537163, 118.491845847513 ),
      ( 500, 0.00025229461973275, 1.04884644072298, -12493.6545615386, -8336.42583492522, 70.4814396384368, 602.929436789639, 611.243994561909, 124.833634692313 ),
      ( 550, 0.000229358618424904, 1.04884642935457, 18706.311321984, 23279.2653995653, 130.715856906642, 644.573968373748, 652.888497317794, 130.869144234355 ),
      ( 600, 0.000210245327326621, 1.04884642222407, 51914.4025385482, 56903.0814098492, 189.204538949773, 683.258605005356, 691.573116979866, 136.639121016924 ),
      ( 650, 0.000194072565191268, 1.04884641749271, 86983.4732543853, 92387.8765839287, 245.991424869736, 719.022539221367, 727.337040696462, 142.176007532799 ),
      ( 700, 0.000180210210282997, 1.04884641420341, 123769.240241005, 129589.36781622, 301.114899069291, 751.942797408556, 760.257292044857, 147.506113144703 ),
      ( 750, 0.000168196176847632, 1.04884641182932, 162132.299146051, 168368.150825245, 354.612113448986, 782.136867983864, 790.45135794299, 152.651114982199 ),
      ( 800, 0.000157683902260073, 1.0488464100641, 201939.987400084, 208591.563084291, 406.521717736021, 809.755234674565, 818.069721292124, 157.629123406749 ),
      ( 850, 0.000148408368900296, 1.04884640872029, 243067.762579512, 250135.062196725, 456.885173339904, 834.970316490103, 843.284800629161, 162.455454852849 ),
      ( 900, 0.00014016345241216, 1.04884640767783, 285400.022423191, 292883.045919171, 505.747051686028, 857.965626845206, 866.280109087496, 167.143203101817 ),
      ( 950, 0.00013278642329954, 1.04884640685676, 328830.426985787, 336729.174318493, 553.154712079561, 878.926854739531, 887.241335492415, 171.703668892118 ),
      ( 1000, 0.000126147098118072, 1.04884640620195, 373261.833730457, 381576.304866529, 599.157664100002, 898.035307218833, 906.349786777295, 176.146688175462 ),
      ( 325, 3120.93979202037, 999.999999131668, -191273.510718812, -191273.190302506, -419.029965672014, 501.633281927162, 591.460747452071, 1278.24765989125 ),
      ( 350, 3054.65780422058, 999.999691186523, -176289.954966743, -176289.627597933, -374.62120554688, 521.70418907382, 607.404052514516, 1193.7646957663 ),
      ( 375, 2989.36067415238, 1000.00003335404, -160895.769008995, -160895.434489296, -332.144308007691, 541.62784857558, 624.258071062333, 1113.78901709018 ),
      ( 400, 2924.41069096375, 1000.00011391803, -145071.690124077, -145071.348174803, -291.299857967733, 561.360843265482, 641.760000079321, 1037.11454457708 ),
      ( 425, 2859.20503345089, 1000.00026502694, -128803.870531575, -128803.520783917, -251.856127536454, 580.867315264419, 659.733492483699, 962.888415761851 ),
      ( 449.058423260235, 2795.64934218016, 1000.00045516503, -112720.209857562, -112719.852158748, -215.049010599546, 599.39266974554, 677.365599806669, 893.188227184734 ),
      ( 475, 0.253724766104629, 1000.00000000174, -27318.5997901524, -23377.3211544304, -17.3961747610812, 581.116090860498, 589.533917753676, 121.464983172967 ),
      ( 525, 0.229406401146119, 1000.00000000053, 2828.68246806941, 7187.7587405906, 43.7490694406642, 624.199187056098, 632.580134806661, 127.717170646602 ),
      ( 575, 0.209372687630149, 1000.00000000018, 35055.5930735126, 39831.7652252818, 103.115070857584, 664.331247918451, 672.691057736135, 133.65955934515 ),
      ( 625, 0.192572238509937, 1000.00000000007, 69215.2578356615, 74408.1143332427, 160.754156205722, 701.531181368974, 709.878272157732, 139.339207226824 ),
      ( 675, 0.178275775817252, 1000.00000000003, 105162.351675636, 110771.638722156, 216.708713373164, 735.850779007982, 744.189807203942, 144.790933623554 ),
      ( 725, 0.165959878294076, 1000.00000000001, 142755.138172533, 148780.690916239, 271.017046097302, 767.384789002162, 775.718438831267, 150.041701205248 ),
      ( 775, 0.155238380480458, 1000.00000000001, 181857.586886013, 188299.292841106, 323.717339824623, 796.266757388589, 804.59664770628, 155.113107190506 ),
      ( 825, 0.145819806559468, 1000, 222341.082150257, 229198.861100829, 374.849856091098, 822.658588512141, 830.985741410514, 160.022892291264 ),
      ( 875, 0.137479862838493, 1000, 264085.557587943, 271359.350122743, 424.457794236773, 846.7389477222, 855.064037530669, 164.785911079674 ),
      ( 925, 0.130043058371311, 1000, 306980.075611614, 314669.836314909, 472.587290638053, 868.693082126181, 877.016572108783, 169.414789350042 ),
      ( 975, 0.123370077096268, 1000, 350922.95276745, 359028.646007957, 519.286936497268, 888.704975703879, 897.027195793404, 173.920389052136 ),
      ( 325, 3120.96380523047, 9999.99999979704, -191274.315529902, -191271.111391494, -419.032442055549, 501.636258953415, 591.460176496677, 1278.2839123379 ),
      ( 350, 3054.68499076066, 9999.99967662459, -176290.841806, -176287.568146128, -374.623739419114, 521.707183198318, 607.403055817738, 1193.80543104801 ),
      ( 375, 2989.39159078095, 10000.0000331391, -160896.75122603, -160893.406063736, -332.146927303858, 541.630895422176, 624.256570211494, 1113.83494809916 ),
      ( 400, 2924.44605874693, 10000.0001147106, -145072.784140436, -145069.364689397, -291.302593065491, 561.363971765255, 641.757883741972, 1037.16654949468 ),
      ( 425, 2859.24579637141, 10000.0002647401, -128805.096917686, -128801.599491799, -251.859013215358, 580.870548318308, 659.730601970027, 962.947569937479 ),
      ( 450, 2793.18539027814, 10000.0004611683, -112083.476028646, -112079.895886599, -213.632560525424, 600.115698513899, 678.057430910857, 890.556232849529 ),
      ( 475, 2725.61866937258, 10000.0006259366, -94900.0590283596, -94896.3901363248, -176.474517192029, 619.064746146568, 696.666105020736, 819.525662809637 ),
      ( 500, 2655.81630818586, 10000.0006264438, -77248.2874032034, -77244.522082313, -140.261752982291, 637.685641293201, 715.524375268763, 749.500588309527 ),
      ( 510.71769809058, 2624.99872683612, 10000.0005503976, -69535.8623747654, -69532.0528488985, -125.000115165192, 645.561402936703, 723.686244203468, 719.719751412688 ),
      ( 525, 2.3232861428432, 10000.0000056399, 2670.0180126218, 6974.26612964543, 24.3014032349394, 624.895855172707, 633.905691499604, 126.162092758897 ),
      ( 575, 2.1123676607822, 10000.0000019229, 34937.4784233989, 39671.5028016266, 83.7645822351471, 664.756423141722, 673.538182605892, 132.516339978497 ),
      ( 625, 1.93816873289543, 10000.0000007343, 69123.0913354173, 74282.6008409676, 141.461777716374, 701.797686636529, 710.445278959716, 138.471161679124 ),
      ( 675, 1.79135078755836, 10000.0000003041, 105087.524772337, 110669.904320641, 197.45301939308, 736.023844709021, 744.5876034423, 144.116892301847 ),
      ( 725, 1.66567712743459, 10000.0000001333, 142692.433860961, 148695.998318579, 251.785752902747, 767.501810927921, 776.010185008387, 149.510428300503 ),
      ( 775, 1.55675800618718, 10000.0000000607, 181803.735735729, 188227.341691386, 304.503067092339, 796.349308138958, 804.819230836882, 154.690492268789 ),
      ( 825, 1.46138251583475, 10000.0000000282, 222293.958101825, 229136.793493431, 355.647957074367, 822.719299216363, 831.161362807523, 159.685177863672 ),
      ( 875, 1.37713253546126, 10000.0000000132, 264043.724261395, 271305.189474446, 405.265209755398, 846.785364780854, 855.206509768067, 164.515919763461 ),
      ( 925, 1.30214475610105, 10000.0000000062, 306942.525423889, 314622.163154757, 453.401922563612, 868.72982158245, 877.134791101291, 169.199715243976 ),
      ( 975, 1.23495636294598, 10000.0000000029, 350888.953413496, 358986.405517915, 500.10729256977, 888.734934993989, 897.127093143844, 173.750443739702 ),
      ( 325, 3121.20385335334, 100000.000002447, -191282.359799735, -191250.320879914, -419.057197824882, 501.666019919019, 591.454486020702, 1278.64630260438 ),
      ( 350, 3054.95674315869, 99999.9994551309, -176299.705345371, -176266.971657839, -374.649068392845, 521.73711336386, 607.393115741205, 1194.21260259532 ),
      ( 375, 2989.70060329706, 100000.000032727, -160906.567198777, -160873.119033458, -332.173108301453, 541.661350496582, 624.241599870264, 1114.29401183849 ),
      ( 400, 2924.79952445548, 100000.000117511, -145083.716290138, -145049.525912548, -291.329929120832, 561.395240446339, 641.736775151489, 1037.68626151367 ),
      ( 425, 2859.65312817559, 100000.000266754, -128817.350263134, -128782.380986867, -251.887851061991, 580.902858912094, 659.701776694517, 963.538646499719 ),
      ( 450, 2793.65909667453, 100000.00046517, -112097.312488184, -112061.517139859, -213.663315630992, 600.149221558343, 678.018626117277, 891.231850563255 ),
      ( 475, 2726.17569866892, 100000.000632313, -94915.8205082576, -94879.1390864838, -176.50770793226, 619.099585444883, 696.614037181096, 820.302188360553 ),
      ( 500, 2656.48016497334, 100000.00063931, -77266.4307201937, -77228.7869229775, -140.298049962494, 637.721802511682, 715.454191131751, 750.398612625945 ),
      ( 525, 2583.71749248866, 100000.000405261, -59143.0479226914, -59104.3440006504, -104.930055066382, 655.990207178667, 734.546209854027, 681.263053143622 ),
      ( 550, 2506.83174792068, 100000.000107189, -40538.817451095, -40498.9264611273, -70.3125805711398, 673.89054762553, 753.946426491623, 612.727190659576 ),
      ( 575, 2424.46627764658, 99999.9999996714, -21444.6872235379, -21403.4410321919, -36.3627261977653, 691.426264641061, 773.780077600273, 544.716646852479 ),
      ( 600, 2334.80374161415, 99999.9999998303, -1847.17789181539, -1804.34773944862, -3.00062651182045, 708.627191118014, 794.29040667757, 477.238952669317 ),
      ( 600.638283908396, 2332.3984747753, 99999.9999996531, -1340.06823800118, -1297.19391739038, -2.15581946823864, 709.062476953696, 794.826457760345, 475.52337581582 ),
      ( 625, 20.7941169862946, 100000, 68136.0554538982, 72945.1079405178, 120.722162770403, 704.698578322785, 717.219074294638, 129.147093919936 ),
      ( 675, 18.8488777944144, 100000, 104303.826745144, 109609.182379082, 177.140525605862, 737.858480731718, 749.101016448609, 137.09168953639 ),
      ( 725, 17.3004452000907, 99999.9999999997, 142045.126346588, 147825.324419149, 231.745428956479, 768.719426317669, 779.208898097593, 144.081061140842 ),
      ( 775, 16.0219495211364, 100000, 181253.244287211, 187494.682001646, 284.647131854112, 797.196637338418, 807.201650622386, 150.430231452451 ),
      ( 825, 14.9399641398502, 99999.9999999998, 221815.535635442, 228508.992129977, 335.923311327351, 823.336226886166, 833.00852850567, 156.314949268583 ),
      ( 875, 14.0077799629949, 100000.000120544, 263621.116326217, 270760.006313404, 385.637895892507, 847.25357952338, 856.685615571476, 161.842757599923 ),
      ( 925, 13.1936166198812, 100000.000054827, 306564.572292589, 314143.995201099, 433.849156990234, 869.09844511166, 878.350046921087, 167.084372005446 ),
      ( 975, 12.474757320628, 100000.000024567, 350547.681410034, 358563.869417091, 480.613145594063, 889.034391556175, 898.146249567956, 172.089034771876 ),
      ( 325, 3121.20738625534, 101324.999999947, -191282.478177129, -191250.014778366, -419.057562175339, 501.666457940376, 591.454402503051, 1278.65163597309 ),
      ( 350, 3054.96074242432, 101324.99945113, -176299.835770503, -176266.668405029, -374.649441159323, 521.737553852038, 607.392969765914, 1194.2185946055 ),
      ( 375, 2989.70515056149, 101325.000034675, -160906.71162761, -160872.820325648, -332.173493581571, 541.661798681228, 624.24137999112, 1114.30076693444 ),
      ( 400, 2924.80472537838, 101325.000114047, -145083.877126948, -145049.233788459, -291.330331365858, 561.395700569419, 641.736465128787, 1037.69390825586 ),
      ( 425, 2859.65912097111, 101325.000267229, -128817.530516969, -128782.097972047, -251.888275362233, 580.90333432526, 659.701353404664, 963.54734215121 ),
      ( 450, 2793.66606492269, 101325.000464389, -112097.516001224, -112061.246455004, -213.663768081917, 600.1497147617, 678.018056432994, 891.241788370636 ),
      ( 475, 2726.18389095928, 101325.000632066, -94916.0522928773, -94878.8849539578, -176.508196133479, 619.100097955981, 696.61327307581, 820.313608161643 ),
      ( 500, 2656.48992579146, 101325.000640405, -77266.6974680121, -77228.5550306339, -140.298583736595, 637.722334406471, 715.453161703794, 750.411815845443 ),
      ( 525, 2583.72931227241, 101325.000405582, -59143.3587966967, -59104.1422270954, -104.930647546834, 655.990756011792, 734.544807835365, 681.278423944191 ),
      ( 550, 2506.84634719018, 101325.000106788, -40539.1853645399, -40498.7660543495, -70.3132499298662, 673.891106127186, 753.944484303153, 612.745226460128 ),
      ( 575, 2424.48475501988, 101324.999999905, -21445.1310080297, -21403.338623157, -36.3634985471875, 691.426815887845, 773.777321672049, 544.738005415061 ),
      ( 600, 2334.82785138184, 101325.000000144, -1847.72625263661, -1804.32904888124, -3.00154118852276, 708.62769822503, 794.286359370225, 477.26453665103 ),
      ( 601.268911473709, 2330.04021925471, 101324.999999792, -839.260126003645, -795.773752179505, -1.3223910432532, 709.492873288991, 795.3526819178, 473.854556691885 ),
      ( 625, 21.0934291935476, 101325, 68120.5097891023, 72924.1384011345, 120.587386093367, 704.744962748781, 717.337411553753, 128.999647811313 ),
      ( 675, 19.1137445268145, 101325, 104291.763979876, 109592.923041506, 177.013020261755, 737.88704014642, 749.175875469592, 136.983992013417 ),
      ( 725, 17.5398071905866, 101325, 142035.305267156, 147812.164664697, 231.622363438923, 768.738037759531, 779.260209067002, 143.999440789598 ),
      ( 775, 16.2412619377221, 101325, 181244.971337498, 187483.710690914, 284.526990497301, 797.209420664515, 807.238999446178, 150.367032222492 ),
      ( 825, 15.1428919715786, 101325, 221808.392863226, 228499.651058172, 335.805211311507, 823.345445902184, 833.03701287752, 156.265433430991 ),
      ( 875, 14.1969524223792, 101325.000126866, 263614.836318737, 270751.931458053, 385.521287685402, 847.260527834252, 856.708148598106, 161.803776028676 ),
      ( 925, 13.3710101174023, 101325.00005768, 306558.975040474, 314136.93655333, 433.733679269117, 869.103888225235, 878.368391810379, 167.053717083138 ),
      ( 975, 12.6419098601007, 101325.000025836, 350542.640273924, 358557.64759063, 480.498549648315, 889.038797751335, 898.161527125055, 172.065094809521 ),
      ( 325, 3123.59598734928, 1000000.00000025, -191362.420618385, -191042.276782866, -419.303953589675, 501.96270493759, 591.399467626415, 1282.25687527167 ),
      ( 350, 3057.66304796081, 1000000.00000564, -176387.858756125, -176060.81160138, -374.901389982633, 522.035314243859, 607.296369229558, 1198.26633553285 ),
      ( 375, 2992.77548353338, 1000000.00003441, -161004.1122423, -160669.974247139, -332.433731691149, 541.964572368723, 624.095655570833, 1118.86024770096 ),
      ( 400, 2928.31318840342, 1000000.00012161, -145192.244263316, -144850.750735888, -291.601812129302, 561.70631042922, 641.531070539295, 1042.85004745334 ),
      ( 425, 2863.69707820943, 1000000.00028178, -128938.844595582, -128589.645649963, -252.174357746655, 581.223991747045, 659.421342767325, 969.403523668502 ),
      ( 450, 2798.35431066363, 1000000.00049485, -112234.293303366, -111876.940413246, -213.968449553998, 600.482047116048, 677.642155771334, 897.924280211735 ),
      ( 475, 2731.68504831905, 1000000.00069455, -95071.5556259431, -94705.4812128954, -176.83642515443, 619.445066283942, 696.110902953797, 827.977911668934 ),
      ( 500, 2663.02769135409, 1000000.00075841, -77445.249834887, -77069.7374044286, -140.656702136574, 638.079943064099, 714.779680588213, 759.251427971201 ),
      ( 525, 2591.619129483, 1000000.00057718, -59350.8227370903, -58964.9635692825, -105.327046481592, 656.359378592203, 733.633661871675, 691.536766669575 ),
      ( 550, 2516.54584880809, 1000000.0002328, -40783.7190618235, -40386.3489917704, -70.7593858182265, 674.266078221383, 752.693704156005, 624.732039057856 ),
      ( 575, 2436.67997884406, 1000000.0000261, -21738.4318465257, -21328.0373717862, -36.8755466779703, 691.797571922616, 772.024754308292, 558.85314738791 ),
      ( 600, 2350.58871192392, 999999.999999617, -2207.21110711888, -1781.7857679573, -3.60328733533195, 708.971908710067, 791.758950926477, 494.038366764344 ),
      ( 625, 2256.38409582026, 999999.999998954, 17822.2444464905, 18265.4314029362, 29.1285758574791, 725.834614214695, 812.166266989578, 430.497803927156 ),
      ( 650, 2151.39606282975, 999999.999998093, 38372.3774654712, 38837.1919258467, 61.3993601306423, 742.468095543328, 833.885663953309, 368.289011661059 ),
      ( 675, 2031.21932623507, 999999.999996114, 59492.4197193197, 59984.7348460419, 93.3210313615906, 759.011773680749, 858.720126396327, 306.66804655844 ),
      ( 700, 1886.2020160264, 999999.999984952, 81316.4871646908, 81846.6530702981, 125.119964498998, 775.747458828702, 892.902780113526, 242.461102485011 ),
      ( 725, 1682.30835350233, 999999.999952086, 104361.447854962, 104955.869203385, 157.54952349989, 793.692964778734, 972.545248216867, 164.624700411128 ),
      ( 735.131239941941, 1543.52634796389, 999999.999999931, 114649.656266293, 115297.523405923, 171.713230877962, 802.620507690211, 1096.95384271743, 119.533974992167 ),
      ( 750, 282.513326048315, 1000000, 152297.415403873, 155837.07144059, 226.619514702961, 800.548772873158, 917.968596981493, 84.7447645813685 ),
      ( 800, 209.903729232531, 1000000, 194990.189782544, 199754.27855627, 283.322216216243, 819.880053707915, 864.844589719339, 114.800408866858 ),
      ( 850, 177.710522680649, 1000000, 237471.681090712, 243098.809889365, 335.874997318093, 841.642169248614, 871.441044819916, 131.901642401743 ),
      ( 900, 157.298217590269, 999999.999999999, 280662.838364764, 287020.189486216, 386.080552339144, 862.767187916085, 885.958803110991, 144.552810784726 ),
      ( 950, 142.5578494826, 1000000, 324705.285973051, 331719.982137656, 434.412485286256, 882.598193075223, 902.103343583372, 154.850261445632 ),
      ( 1000, 131.143838528274, 1000000, 369602.85062266, 377228.065891805, 481.094159706494, 900.972098647603, 918.131933062685, 163.667416682443 ),
      ( 325, 3124.70043882429, 1417453.32947751, -191399.321990004, -190945.69343993, -419.417917078525, 502.099752051954, 591.375094073887, 1283.92344193207 ),
      ( 359, 3035.52272089576, 1417453.32947619, -170940.040589634, -170473.085320375, -359.525127925137, 529.367230493426, 613.205506281471, 1171.17302613804 ),
      ( 393, 2947.9109448177, 1417453.32945134, -149711.958635552, -149231.125477432, -303.007915994837, 556.34190089487, 636.512615114733, 1066.1384137885 ),
      ( 427, 2860.38340086404, 1417453.32934494, -127675.426300215, -127179.879679117, -249.207436239495, 582.92280799059, 660.739776609468, 966.339656622835 ),
      ( 461, 2771.52409824484, 1417453.32898073, -104805.683190625, -104294.248586871, -197.650148241291, 609.019510122382, 685.551285620518, 870.230599012313 ),
      ( 495, 2679.83345517004, 1417453.32806974, -81086.9672455251, -80558.0338801568, -147.982475883918, 634.543593667698, 710.75088187605, 776.828623114008 ),
      ( 529, 2583.57406592805, 1417453.32947887, -56508.4617564332, -55959.8212710792, -99.9308018251565, 659.419225423595, 736.251050497597, 685.555469339967 ),
      ( 563, 2480.58706841652, 1417453.32947861, -31060.809393854, -30489.3908988026, -53.2749261133621, 683.600280083932, 762.07053026468, 596.21444005939 ),
      ( 597, 2368.04799834371, 1417453.32947836, -4732.33536856999, -4133.76079133601, -7.82869593804477, 707.090290287669, 788.362120256069, 509.038131349702 ),
      ( 631, 2242.08044147301, 1417453.32921389, 22496.9286197065, 23129.133112906, 36.5778170809695, 729.964743854297, 815.552047063057, 424.636558685253 ),
      ( 665, 2096.79473386175, 1417453.3298507, 50672.4893631962, 51348.4989443725, 80.1294686529304, 752.396373152495, 845.032396574234, 343.295145222067 ),
      ( 699, 1920.15959261782, 1417453.32931205, 79939.1646463875, 80677.360229068, 123.134856101222, 774.725358067212, 882.690262972561, 262.296763647764 ),
      ( 733, 1666.69237565168, 1417453.32947852, 110982.556565151, 111833.015444177, 166.641265995556, 798.154403156073, 968.77245930243, 167.704269913586 ),
      ( 767, 532.768486471367, 1417453.32947854, 159202.809359448, 161863.352100755, 233.14304907151, 820.830241579693, 1196.34025828608, 68.2416789996143 ),
      ( 801, 356.187833771476, 1417453.32951668, 191707.185026252, 195686.695821183, 276.327086257243, 826.671028179191, 920.768704329448, 99.0981005435088 ),
      ( 835, 295.656726138345, 1417453.32948412, 221621.71314036, 226415.966760083, 313.902460521218, 839.041315772413, 894.436280288099, 116.392824575344 ),
      ( 869, 260.048683338284, 1417453.32947854, 251313.808660729, 256764.531622609, 349.527777671953, 852.525045782826, 892.673988250762, 128.997807237908 ),
      ( 903, 235.312398431133, 1417453.32947854, 281172.149377797, 287195.858026083, 383.878191255536, 866.036926679001, 898.089399431824, 139.118407973829 ),
      ( 937, 216.607535524278, 1417453.32947854, 311320.862840848, 317864.74103995, 417.216798214449, 879.185974610853, 906.23896149723, 147.680195176684 ),
      ( 971, 201.710259562935, 1417453.32947854, 341804.949785379, 348832.124965015, 449.679825896491, 891.807915081709, 915.475522575111, 155.164209316585 ),
      ( 325, 3146.7296752049, 9999999.99999956, -192126.917488087, -188949.015020393, -421.695675617981, 504.841822880511, 591.018592440631, 1317.11284697194 ),
      ( 359, 3061.37371173987, 9999999.99999833, -171762.700575995, -168496.193137962, -361.860407089309, 532.115233021211, 612.385580811007, 1209.66810154081 ),
      ( 393, 2978.43259815027, 9999999.9999919, -150648.739366785, -147291.268727295, -305.441380894268, 559.145030739456, 635.134583128359, 1110.95452966815 ),
      ( 427, 2896.73263197553, 9999999.99997107, -128750.494725581, -125298.329382606, -251.782791171913, 585.813745831397, 658.658589538774, 1018.73492356472 ),
      ( 461, 2815.29444772721, 9999999.99993267, -106050.393407972, -102498.367079783, -200.418096088873, 612.016131025944, 682.549325943544, 931.730974465209 ),
      ( 495, 2733.25568627477, 9999999.99988226, -82542.8901889062, -78884.2496708976, -151.005442212136, 637.647964534319, 706.50606375582, 849.263347191851 ),
      ( 529, 2649.82933281465, 9999999.99984704, -58231.7569478782, -54457.928997523, -103.288988659859, 662.611256383271, 730.289797045381, 771.078426279672 ),
      ( 563, 2564.29503602799, 9999999.99986332, -33128.5097206195, -29228.802448498, -57.074427043363, 686.822323607506, 753.698473689499, 697.272293420054 ),
      ( 597, 2476.02474312759, 9999999.99992744, -7251.44615756512, -3212.71430414432, -12.2128004184665, 710.216772862158, 776.553611418783, 628.242402598027 ),
      ( 631, 2384.53998747694, 9999999.99998129, 19375.1266799081, 23568.8076634517, 31.4108015378681, 732.74892203901, 798.701329107216, 564.596647130755 ),
      ( 665, 2289.57651836027, 9999999.99999815, 46722.1454554474, 51089.7653710988, 73.8862649936521, 754.384984321145, 820.040029739189, 506.950417493307 ),
      ( 699, 2191.09250634067, 9999999.99999989, 74758.4738183168, 79322.4070940966, 115.287422125195, 775.091821282957, 840.579756023517, 455.600248759337 ),
      ( 733, 2089.1399904385, 10000000, 103455.444505512, 108242.1031525, 155.681907943582, 794.827003495163, 860.499885508005, 410.218418951173 ),
      ( 767, 1983.60195426375, 9999999.99999987, 132791.782076784, 137833.116089642, 195.139988904137, 813.537443663888, 880.130874370883, 369.852767969041 ),
      ( 801, 1873.97717142581, 10000000.00036, 162755.317845403, 168091.562145941, 233.737912612259, 831.167726857028, 899.801482858539, 333.404786256141 ),
      ( 835, 1759.54372894777, 10000000.0000074, 193337.18234497, 199020.473891232, 271.550921654977, 847.67038383655, 919.519940508806, 300.433242743346 ),
      ( 869, 1640.26936433165, 10000000.0000001, 224513.993073959, 230610.55271072, 308.630882270641, 863.012043482471, 938.454608650354, 271.856032823878 ),
      ( 903, 1518.48277588296, 9999999.99999823, 256218.378948365, 262803.899810913, 344.968960975944, 877.184510170441, 954.603061108857, 249.784697111392 ),
      ( 937, 1399.73770989131, 9999999.99999995, 288324.256210825, 295468.451819284, 380.476655587592, 890.236604275901, 965.977590573219, 235.788680133567 ),
      ( 971, 1290.45527681145, 9999999.99999995, 320688.622648746, 328437.825724353, 415.038689471894, 902.300299047643, 972.783792206184, 229.151913230855 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new (double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 306.125, 0.0248182154034175, 3172.06283306443, 9.75073182627687E-06 ),
      ( 370.25, 10.3694914812879, 3001.71835143216, 0.00336863176266352 ),
      ( 434.375, 483.602759465978, 2834.5617888533, 0.134093848966475 ),
      ( 498.5, 6499.99206938826, 2660.05686678499, 1.58581067294581 ),
      ( 562.625, 41279.3964316678, 2465.29526384617, 9.24148041484249 ),
      ( 626.75, 164940.729634483, 2229.47156047832, 36.2301104775076 ),
      ( 690.875, 497899.501461574, 1910.64254845992, 121.933551613622 ),
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
