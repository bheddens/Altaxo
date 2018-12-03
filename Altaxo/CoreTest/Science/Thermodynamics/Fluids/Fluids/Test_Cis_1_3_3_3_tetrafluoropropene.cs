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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Altaxo.Science.Thermodynamics.Fluids
{

  /// <summary>
  /// Tests and test data for <see cref="Cis_1_3_3_3_tetrafluoropropene"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Cis_1_3_3_3_tetrafluoropropene : FluidTestBase
  {

    public Test_Cis_1_3_3_3_tetrafluoropropene()
    {
      _fluid = Cis_1_3_3_3_tetrafluoropropene.Instance;

      _testDataMolecularWeight = 0.1140416;

      _testDataTriplePointTemperature = 273;

      _testDataTriplePointPressure = 67800;

      _testDataTriplePointLiquidMoleDensity = 11250.7668439848;

      _testDataTriplePointVaporMoleDensity = 31.0763256550948;

      _testDataCriticalPointTemperature = 423.27;

      _testDataCriticalPointPressure = 3532513.65355718;

      _testDataCriticalPointMoleDensity = 4126.7;

      _testDataNormalBoilingPointTemperature = 282.895072851183;

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
      ( 273, 0.440796851131229, 1000.00000000003, 45999.1140586851, 48267.7328054699, 242.049723713888, 78.1751688284804, 86.5168917760684, 148.336208994971 ),
      ( 275, 0.437584200822162, 1000.00000000003, 46156.0238021644, 48441.2982661902, 242.683174754162, 78.7073435636975, 87.0481559811909, 148.831591982328 ),
      ( 283, 0.425190166048084, 1000.00000000002, 46794.2222962344, 49146.1111211676, 245.209414886148, 80.8109110320915, 89.1484638939177, 150.798306450594 ),
      ( 291, 0.413480926484082, 1000.00000000002, 47449.0771854559, 49867.5684288204, 247.723232744068, 82.8744866703696, 91.2093020577067, 152.741882705789 ),
      ( 299, 0.402400949597092, 1000.00000000001, 48120.2717190131, 50605.3553178497, 250.224234628911, 84.8984021617226, 93.2309036172967, 154.663053412285 ),
      ( 307, 0.391900602527909, 1000.00000000001, 48807.4916122869, 51359.1590339484, 252.712065018116, 86.883028386651, 95.2135619107198, 156.562519256036 ),
      ( 315, 0.381935378403189, 1000.00000000001, 49510.4253949161, 52128.669361162, 255.186403992393, 88.8287660357357, 97.1576161463647, 158.440950372449 ),
      ( 323, 0.37246524355052, 1000.00000000001, 50228.7646768597, 52913.578944273, 257.646964674727, 90.7360386574118, 99.0634407775398, 160.298987722966 ),
      ( 331, 0.363454083612088, 1000, 50962.204353397, 53713.5835374243, 260.093490756961, 92.6052874600817, 100.931437545482, 162.137244429885 ),
      ( 339, 0.354869231140595, 1000, 51710.4427642477, 54528.3821972774, 262.525754156102, 94.4369673926968, 102.76202946979, 163.956307071831 ),
      ( 347, 0.346681060767927, 1000, 52473.181817936, 55357.6774341226, 264.943552821311, 96.2315441662216, 104.555656273975, 165.756736938944 ),
      ( 355, 0.33886264074711, 1000, 53250.1270896237, 56201.1753308676, 267.346708699303, 97.989491973639, 106.312770877874, 167.539071245689 ),
      ( 363, 0.331389431783219, 1000, 54040.9878985496, 57058.5856373156, 269.735065857611, 99.711291732743, 108.033836689563, 169.303824299062 ),
      ( 371, 0.324239025734634, 1000, 54845.477369684, 57929.6218453044, 272.108488760265, 101.397429723108, 109.719325500903, 171.051488620347 ),
      ( 379, 0.317390918088621, 1000, 55663.312483093, 58814.0012489284, 274.466860687633, 103.04839652234, 111.369715842052, 172.78253601919 ),
      ( 387, 0.310826309173199, 1000, 56494.2141136702, 59711.4449930639, 276.810082290775, 104.664686171068, 112.985491687251, 174.49741861938 ),
      ( 395, 0.304527929919496, 1000, 57337.9070632799, 60621.6781126689, 279.138070270104, 106.246795513845, 114.5671414312, 176.196569836299 ),
      ( 403, 0.298479888679619, 1000, 58194.1200868879, 61544.4295647682, 281.450756168203, 107.795223676148, 116.115157075079, 177.880405306556 ),
      ( 411, 0.292667536168354, 1000, 59062.5859139019, 62479.432254607, 283.74808526697, 109.310471647274, 117.630033575969, 179.549323770683 ),
      ( 419, 0.28707734605891, 1000, 59943.0412656802, 63426.4230571323, 286.030015579817, 110.79304194606, 119.112268324303, 181.203707910149 ),
      ( 427, 0.281696809143488, 999.999999999999, 60835.226869955, 64385.1428347135, 288.296516930291, 112.243438351759, 120.562360722176, 182.843925140159 ),
      ( 273, 4.4297539495287, 10000.000000334, 45965.4207434266, 48222.8824702564, 222.781387041761, 78.5063537714042, 87.0998222092428, 147.787864705389 ),
      ( 275, 4.39683573727404, 10000.0000003053, 46123.2282471235, 48397.591129396, 223.419010457341, 79.0247590742174, 87.6086182472809, 148.295947055475 ),
      ( 283, 4.2700752155787, 10000.0000002153, 46764.6808186545, 49106.55994147, 225.960152943695, 81.0799536289965, 89.6296315706822, 150.309411606156 ),
      ( 291, 4.15063139028181, 10000.0000001542, 47422.3253077948, 49831.5973100178, 228.486449912594, 83.1040078742936, 91.6252133425928, 152.29406416603 ),
      ( 299, 4.03785645219076, 10000.000000112, 48095.9266078252, 50572.4881494537, 230.997977628189, 85.0953354958677, 93.5926196488243, 154.251531332962 ),
      ( 307, 3.93118255379655, 10000.0000000824, 48785.2350700444, 51328.9989027428, 233.494745286348, 87.0528886890304, 95.5299239477583, 156.183236355056 ),
      ( 315, 3.83010871444826, 10000.0000000613, 49489.9910560611, 52100.8830034198, 235.976719499919, 88.9759895014694, 97.4357683341378, 158.090439514772 ),
      ( 323, 3.73419046679683, 10000.0000000461, 50209.9281550835, 52887.8847534313, 238.443840739818, 90.8642256391925, 99.3092068349504, 159.974267979641 ),
      ( 331, 3.6430315337329, 10000.000000035, 50944.7755402335, 53689.7421724022, 240.896034615094, 92.7173816400498, 101.149600392022, 161.835738489106 ),
      ( 339, 3.55627704773571, 10000.0000000268, 51694.2597376901, 54506.1891418949, 243.333219698973, 94.5353910780877, 102.956543214611, 163.675774960839 ),
      ( 347, 3.47360796464407, 10000.0000000207, 52458.1059788256, 55336.9570471687, 245.755312975574, 96.3183021596383, 104.729809427723, 165.495222382909 ),
      ( 355, 3.39473641681773, 10000.0000000161, 53236.0392474956, 56181.7760506464, 248.162233615544, 98.0662523179843, 106.469313512773, 167.294857928467 ),
      ( 363, 3.31940181479081, 10000.0000000126, 54027.7850997749, 57040.3760899509, 250.553905563065, 99.7794491021797, 108.175080467936, 169.075399956488 ),
      ( 371, 3.24736755206975, 10000.0000000099, 54833.0703111743, 57912.4876668218, 252.93025927057, 101.458155599228, 109.847223002596, 170.837515380309 ),
      ( 379, 3.17841820081347, 10000.0000000079, 55651.6233914777, 58797.8424753757, 255.291232819658, 103.102679192192, 111.485923923526, 172.581825760388 ),
      ( 387, 3.11235711060391, 10000.0000000063, 56483.1749969972, 59696.1739057458, 257.636772599302, 104.713362812886, 113.091422410895, 174.308912389069 ),
      ( 395, 3.04900434088915, 10000.000000005, 57327.4582626785, 60607.2174502593, 259.966833665241, 106.290578083399, 114.664003243488, 176.01932057107 ),
      ( 403, 2.98819487166299, 10000.000000004, 58184.2090711298, 61530.7110328438, 262.281379870797, 107.834719902295, 116.203988281882, 177.713563256401 ),
      ( 411, 2.92977704770783, 10000.0000000032, 59053.1662716851, 62466.395277567, 264.580383835201, 109.346202145139, 117.711729694851, 179.392124147412 ),
      ( 419, 2.87361122010272, 10000.0000000026, 59934.0718596559, 63414.0137286346, 266.863826797934, 110.825454230886, 119.187604541428, 181.055460375362 ),
      ( 427, 2.81956855527842, 10000.0000000021, 60826.6711236837, 64373.3130314612, 269.131698394765, 112.272918365462, 120.632010414248, 182.704004821872 ),
      ( 273, 11251.5973997814, 99999.9998586893, 22780.4843068381, 22789.3719337505, 113.961871792652, 99.3061079745879, 135.592032772319, 681.385924747845 ),
      ( 275, 11209.7834438418, 100000.000000857, 23052.2990615481, 23061.2198404822, 114.954018891777, 99.5803205346427, 136.256662165759, 675.782913089639 ),
      ( 281.557754573981, 11070.5007205539, 100000.00041437, 23952.9503049988, 23961.9833201206, 118.190975600999, 100.528994262203, 138.468758826078, 656.894110330233 ),
      ( 300, 41.7162923624538, 100000, 47926.9770304531, 50324.1219907757, 211.312014092511, 87.5998783161483, 98.0447722884236, 150.232001251939 ),
      ( 350, 35.1135542263338, 100000, 52598.2935621341, 55446.1966640367, 227.085221113892, 97.8364602988687, 107.151960973214, 163.574600739475 ),
      ( 400, 30.4660303395108, 100000.00004602, 57759.3986032188, 61041.7428709697, 242.014826115279, 107.675234939126, 116.572811141889, 175.356944401724 ),
      ( 273, 11251.6315676991, 101324.999860665, 22780.4248155303, 22789.430176153, 113.961653776257, 99.3059963339329, 135.591595668117, 681.394558405742 ),
      ( 275, 11209.8182548245, 101325.000000119, 23052.2382442055, 23061.2771953907, 114.9537976364, 99.5802103032222, 136.256211645364, 675.791670686084 ),
      ( 281.895072851183, 11063.2810552313, 101325.000410466, 23999.6061779905, 24008.7648534237, 118.356603693669, 100.579529713237, 138.583405849725, 655.911171745882 ),
      ( 300, 42.2927992998219, 101325, 47923.0057186819, 50318.803624649, 211.189137063381, 87.6399165228003, 98.1194241180578, 150.166300881319 ),
      ( 350, 35.5892727314988, 101325, 52596.044086326, 55443.1098514637, 226.96931190159, 97.8495635299867, 107.179349269635, 163.535655048111 ),
      ( 400, 30.8751642656678, 101325.000048544, 57757.8815936322, 61039.6455116048, 241.901578610912, 107.681430516661, 116.587042511737, 175.331345525908 ),
      ( 273, 11251.6412376942, 101699.999858511, 22780.4079786621, 22789.4466600163, 113.961592074346, 99.3059647384866, 135.591471964042, 681.397001849414 ),
      ( 275, 11209.8281068117, 101699.999999792, 23052.2210320574, 23061.2934280863, 114.953735017829, 99.5801791066492, 136.256084144539, 675.794149204968 ),
      ( 281.989905719409, 11061.2497888162, 101700.000408873, 24012.7296821973, 24021.9239416481, 118.403156411823, 100.593766782114, 138.61565982663, 655.634505658194 ),
      ( 300, 42.4560851729983, 101700, 47921.8803228258, 50317.2966591554, 211.154614892046, 87.6512968288674, 98.140640541837, 150.147688840957 ),
      ( 350, 35.7239617057166, 101700, 52595.4072069082, 55442.2359219811, 226.936766402998, 97.8532746931495, 107.187108635865, 163.524628838718 ),
      ( 400, 30.9909833752989, 101700.000049276, 57757.4521754771, 61039.0518206931, 241.869786980882, 107.683184392579, 116.591072195068, 175.32409932483 ),
      ( 275, 11219.9718875471, 489391.893793833, 23034.4983982861, 23078.1163234199, 114.889202494926, 99.5481586953427, 136.125423485037, 678.34576672112 ),
      ( 300, 10672.5006960943, 489391.893962269, 26541.9630443926, 26587.8184542818, 127.099108377047, 103.464506617813, 144.780355252502, 603.09246567362 ),
      ( 325, 10062.0230734406, 489391.893766538, 30277.7609249088, 30326.39844941, 139.063731809931, 107.876594486328, 154.588337447799, 518.696206427321 ),
      ( 330.154597990709, 9925.49526904313, 489391.893793361, 31079.7801629017, 31129.086709379, 141.514113285078, 108.820143335956, 156.878716824085, 500.140058639454 ),
      ( 350, 189.530958457407, 489391.893793902, 51866.7171531728, 54448.8382893559, 211.749015270835, 102.692171638023, 118.043718802652, 151.015025875006 ),
      ( 400, 157.567865633442, 489391.893793898, 57293.8388573589, 60399.7506613075, 227.636463640693, 109.609681294511, 121.292723383663, 167.515509479167 ),
      ( 275, 11233.206753654, 1000000.00000242, 23011.373326902, 23100.3951015326, 114.804827175797, 99.5066684552077, 135.956778486334, 681.674187085974 ),
      ( 300, 10689.5991528535, 1000000.00018143, 26511.317947536, 26604.8668248964, 126.99658639869, 103.426001128755, 144.51940968383, 607.131467117386 ),
      ( 325, 10085.6049162319, 1000000.00000105, 30235.5875906024, 30334.7388074413, 138.93343606755, 107.828930027889, 154.123860408001, 523.849779136481 ),
      ( 350, 9386.12947056997, 999999.999999786, 34226.0051851686, 34332.5453733405, 150.778625429411, 112.479168825952, 166.418463010593, 431.141419425445 ),
      ( 358.645548454973, 9108.34994250793, 999999.999999773, 35685.3270651428, 35795.1164349312, 154.906341008258, 114.176476555564, 172.11688674777, 395.905957957817 ),
      ( 375, 395.436725249535, 1000000.00000078, 53645.0950735183, 56173.9446622097, 211.449493886436, 111.286523305837, 134.157289470495, 144.536931362052 ),
      ( 425, 318.381653302921, 1000000.00000001, 59565.5973436601, 62706.4818438375, 227.806404102121, 115.567813812933, 130.23273033151, 165.41437926319 ),
      ( 283, 11137.8364769867, 3709139.33618581, 23978.939464139, 24311.9609933965, 118.279401843521, 100.478756463276, 137.682373061879, 676.937355199495 ),
      ( 291, 10970.2635126371, 3709139.3361823, 25085.6921897436, 25423.8006893169, 122.153490123714, 101.744531130577, 140.284453351958, 654.179648899276 ),
      ( 299, 10798.2107065371, 3709139.3361855, 26213.1330619283, 26556.6287981191, 125.99365860738, 103.07172396037, 142.930466932386, 630.617313766387 ),
      ( 307, 10621.307676827, 3709139.33618994, 27361.6127095347, 27710.8295337758, 129.802966465885, 104.442379020889, 145.629719422377, 606.341498452006 ),
      ( 315, 10439.0630077787, 3709139.33619857, 28531.575141006, 28886.8885760753, 133.584562680723, 105.842857019936, 148.398317348335, 581.41715738537 ),
      ( 323, 10250.8429353444, 3709139.3362115, 29723.6120928559, 30085.449588524, 137.341854216978, 107.263029603031, 151.259827415998, 555.884653367835 ),
      ( 331, 10055.8395111623, 3709139.33622176, 30938.5251594852, 31307.3794288979, 141.078680162775, 108.695744955853, 154.24682892906, 529.760452909269 ),
      ( 339, 9853.02365875222, 3709139.33623044, 32177.4035949525, 32553.8504060728, 144.799515907456, 110.136539563219, 157.403701073233, 503.036645853025 ),
      ( 347, 9641.07546387319, 3709139.33623394, 33441.7292624322, 33826.4518330762, 148.509738847741, 111.583610073401, 160.7913085853, 475.678894542295 ),
      ( 355, 9418.27852741107, 3709139.33623498, 34733.5270959581, 35127.3505877395, 152.216003322851, 113.038115399489, 164.494855033542, 447.622153251726 ),
      ( 363, 9182.35473639191, 3709139.33623487, 36055.5928179994, 36459.5348832667, 155.926805360718, 114.504978489871, 168.637410791451, 418.762981488019 ),
      ( 371, 8930.19458212927, 3709139.33623507, 37411.8568753475, 37827.2049735465, 159.65338587239, 115.994559884681, 173.404367303753, 388.946232193006 ),
      ( 379, 8657.39161394376, 3709139.3362351, 38808.0030127654, 39236.4391401391, 163.411270842921, 117.526037562551, 179.090750564906, 357.941641629587 ),
      ( 387, 8357.37693523147, 3709139.33623514, 40252.6029010503, 40696.4191085734, 167.223109624131, 119.134504660503, 186.201600440798, 325.400483218461 ),
      ( 395, 8019.63874947981, 3709139.33623513, 41759.419757027, 42221.9267915833, 171.124469934056, 120.887214146125, 195.693904308361, 290.7679844043 ),
      ( 403, 7625.48261400538, 3709139.33623509, 43352.8200357461, 43839.2337519642, 175.177541021872, 122.926262337727, 209.679378929482, 253.081044752392 ),
      ( 411, 7135.28283180411, 3709139.33623503, 45083.8189183673, 45603.6496557982, 179.512076301954, 125.609091367572, 234.189337271033, 210.391796408961 ),
      ( 419, 6427.99610350163, 3709139.33621549, 47105.1532160812, 47682.1820873643, 184.518815984166, 130.228921367644, 299.470449962316, 157.356231558465 ),
      ( 427, 3094.57780447325, 3709139.33623564, 52908.8137765684, 54107.4067900884, 199.651579398303, 147.512516509246, 1206.20490604372, 87.4514054871892 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new (double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 291.78375, 141553.743021263, 10847.5591090504, 62.3118372735869 ),
      ( 310.5675, 267272.106334294, 10415.0707996897, 114.622964040064 ),
      ( 329.35125, 465673.891887247, 9945.88131213051, 197.706148801794 ),
      ( 348.135, 760429.50810179, 9426.81064169552, 325.71970799858 ),
      ( 366.91875, 1178202.17369138, 8833.94995451611, 521.797447241217 ),
      ( 385.7025, 1749574.21409332, 8118.314766646, 831.111797337543 ),
      ( 404.48625, 2512412.97879152, 7147.94678123813, 1375.65251721814 ),
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