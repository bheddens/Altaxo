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
  /// Tests and test data for <see cref="Dodecafluoro_2_methylpentan_3_one"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Dodecafluoro_2_methylpentan_3_one : FluidTestBase
  {

    public Test_Dodecafluoro_2_methylpentan_3_one()
    {
      _fluid = Dodecafluoro_2_methylpentan_3_one.Instance;

      _testDataMolecularWeight = 0.3160444;

      _testDataTriplePointTemperature = 165;

      _testDataTriplePointPressure = 0.2315;

      _testDataTriplePointLiquidMoleDensity = 6234.03057076796;

      _testDataTriplePointVaporMoleDensity = 0.000168712105650828;

      _testDataCriticalPointTemperature = 441.81;

      _testDataCriticalPointPressure = 1869026.58306407;

      _testDataCriticalPointMoleDensity = 1920;

      _testDataNormalBoilingPointTemperature = 322.201649728291;

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
      ( 175, 0.000238655224830505, 0.347250014094454, 68458.626673646, 69913.6545882499, 405.492452663323, 248.237801470671, 256.55234596094, 68.9787324064079 ),
      ( 225, 0.000185620501026192, 0.347250005679844, 80926.3753124637, 82797.1277550015, 470.233888738407, 251.088885751976, 259.403385514809, 78.2002260291162 ),
      ( 275, 0.000151871251140688, 0.347250002636556, 93643.7699129685, 95930.2461224446, 522.918004682085, 258.436670364278, 266.751150410388, 86.4142357367349 ),
      ( 325, 0.00012850641984636, 0.347250001395318, 106848.764625605, 109550.964265207, 568.397996698316, 270.454283873851, 278.768755191527, 93.8771157423947 ),
      ( 375, 0.000111372221133428, 0.347250000820638, 120744.316724545, 123862.239643624, 609.330949443592, 285.770340615886, 294.084807965999, 100.75957583446 ),
      ( 425, 9.82696025322947E-05, 0.347250000519229, 135451.922559548, 138985.568687863, 647.166538683659, 302.667065583684, 310.981530979114, 107.182079150943 ),
      ( 475, 8.79254315951963E-05, 0.347250000345031, 151014.004501931, 154963.373803224, 682.691734889146, 319.759784381014, 328.07424872698, 113.230640200869 ),
      ( 165, 6234.03348121603, 657.783837553128, 25227.1306309886, 25227.2361459557, 138.490753502058, 295.329649594118, 369.777238408622, 946.080339619356 ),
      ( 175, 6146.59787588303, 657.783897171986, 28895.6573851423, 28895.7644010738, 160.078201731863, 290.754384574551, 364.077025609861, 912.005448023077 ),
      ( 200, 5932.05042294429, 657.783896978135, 37853.9101628384, 37854.0210492689, 207.942450607698, 282.308730907254, 353.371695466748, 826.763347579195 ),
      ( 225, 5719.58202861935, 657.783896383749, 46600.218591737, 46600.3335973254, 249.156514644585, 277.576660204054, 346.99750650204, 742.190998392927 ),
      ( 227.612265950208, 5697.33069831415, 657.783897226895, 47506.0812753811, 47506.1967301321, 253.159385848797, 277.271617252455, 346.555090219359, 733.4245341273 ),
      ( 250, 0.316781827605544, 657.783896108385, 87233.0425708044, 89309.4997371778, 434.941536621346, 254.181243881071, 262.544802040017, 82.3363410689345 ),
      ( 300, 0.263846780817426, 657.783896108255, 100167.345145317, 102660.397719505, 483.59772698497, 263.950735979668, 272.289337807895, 90.1848325847896 ),
      ( 350, 0.226103061815205, 657.783896108241, 113698.311672219, 116607.533205212, 526.569472878843, 277.823071835188, 286.150526665003, 97.3564538903741 ),
      ( 400, 0.197818018795418, 657.783896108238, 127990.773645542, 131315.970713603, 565.825996250867, 294.125831502354, 302.44809952049, 104.005212473897 ),
      ( 450, 0.175827366269387, 657.783896108237, 143124.871339197, 146865.949363993, 602.436648697671, 311.259674261357, 319.5792406587, 110.236960453952 ),
      ( 500, 0.158238729417657, 657.783896108236, 159111.58733781, 163268.49569096, 636.984691312793, 328.08421991434, 336.402292460786, 116.12644226958 ),
      ( 165, 6234.0349959242, 999.999941336676, 25227.1178309399, 25227.2782406813, 138.490675925809, 295.329696353037, 369.777223374904, 946.08125491062 ),
      ( 175, 6146.59950601948, 1000.00000175607, 28895.6436205236, 28895.8063121063, 160.078123076695, 290.754431495877, 364.077003846204, 912.006442966184 ),
      ( 200, 5932.05240582531, 1000.00000091471, 37853.8936078476, 37854.0621835669, 207.94236783251, 282.30877707969, 353.371654284104, 826.764578537362 ),
      ( 225, 5719.58448594898, 1000.00000075432, 46600.1985538357, 46600.3733917113, 249.156425586969, 277.576702672858, 346.997438958833, 742.192524977753 ),
      ( 232.825537664162, 5652.8394463619, 1000.00000009433, 49310.6859947735, 49310.8628970205, 260.998405528705, 276.762340089937, 345.791411809371, 715.97859275496 ),
      ( 250, 0.481850514343674, 1000.00000000079, 87229.8532341667, 89305.1856665973, 431.446021060156, 254.203151774917, 262.592402553874, 82.2955955180241 ),
      ( 300, 0.401222447932356, 1000.0000000001, 100165.46231674, 102657.845295692, 480.108697330393, 263.963284392378, 272.314481612522, 90.1626143791541 ),
      ( 350, 0.343786240782974, 1000.00000000002, 113697.129083539, 116605.913326103, 523.08334151968, 277.829620089779, 286.16384517061, 97.3429334655693 ),
      ( 400, 0.300761719665431, 1000.00000000001, 127989.96156305, 131314.852779634, 562.341213789974, 294.129343239948, 302.455676191197, 103.996326298149 ),
      ( 450, 0.267318614889133, 1000, 143124.27390553, 146865.12824302, 598.952568901568, 311.261590556138, 319.583814053955, 110.230818097428 ),
      ( 500, 0.240573114503181, 1000, 159111.117783525, 163267.858249163, 633.501000068765, 328.085281943015, 336.405233555332, 116.122071810418 ),
      ( 165, 6234.07483033401, 9999.99994185874, 25226.7812129736, 25228.3853002221, 138.488635782756, 295.330926042768, 369.776828101275, 946.105325492841 ),
      ( 175, 6146.64237585135, 10000.0000023167, 28895.2816373175, 28896.9085417949, 160.076054565569, 290.755665453605, 364.076431604841, 912.032608136033 ),
      ( 200, 5932.10455163456, 10000.0000014787, 37853.458247547, 37855.1439899197, 207.940190990257, 282.309991338277, 353.370571429337, 826.796950024654 ),
      ( 225, 5719.6491077472, 9999.99999978216, 46599.6716076934, 46601.4199666943, 249.154083555828, 277.57781953807, 346.995663007778, 742.232670071479 ),
      ( 250, 5505.08867781681, 9999.99999975437, 55234.1767073344, 55235.9932085, 285.546255291753, 275.973291448797, 344.354269475832, 659.03077208823 ),
      ( 268.040074263074, 5346.53168989676, 10000.0000000116, 61445.3950677373, 61447.2654391444, 309.535775695769, 276.488896654177, 344.531637234227, 600.008206378098 ),
      ( 275, 4.42243699163359, 10000.0000028342, 93571.869892351, 95833.0666084947, 437.282713141447, 258.93441348663, 267.787533772022, 85.5369296882735 ),
      ( 325, 3.72234313810822, 10000.000000404, 106805.364289221, 109491.844183572, 482.891006198663, 270.726432846051, 279.312081303473, 93.3734318435731 ),
      ( 375, 3.21824466616516, 10000.0000000805, 120715.868191824, 123823.152142362, 523.881728945836, 285.906564641591, 294.374077184764, 100.440720145074 ),
      ( 425, 2.83605203408541, 10000.0000000202, 135431.713094983, 138957.741489326, 561.745657031408, 302.743661264495, 311.153733543863, 106.966939310416 ),
      ( 475, 2.53567915792643, 10000.0000000059, 150998.623416837, 154942.340021813, 597.286032801983, 319.801253472343, 328.180698436585, 113.07954670683 ),
      ( 165, 6234.47305155133, 99999.9999418857, 25223.4163798263, 25239.4562277998, 138.468239439592, 295.3432196464, 369.772886024581, 946.345944500162 ),
      ( 175, 6147.07092525713, 100000.000000881, 28891.6633791873, 28907.9312897445, 160.05537524053, 290.768001400685, 364.070722400021, 912.294152932098 ),
      ( 200, 5932.62576421357, 100000.000000855, 37849.1069995099, 37865.9629422198, 207.918430677857, 282.322129877202, 353.359765595086, 827.120485690723 ),
      ( 225, 5720.29490921052, 100000.000001225, 46594.4057518361, 46611.8873680094, 249.130674928004, 277.588985103838, 346.977943621937, 742.633822289515 ),
      ( 250, 5505.90614163951, 100000.000000897, 55227.7374184793, 55245.8997331698, 285.520492204562, 275.982397878874, 344.326431821886, 659.528802493249 ),
      ( 275, 5285.14397671353, 100000.000000713, 63836.909968316, 63855.8309287366, 318.344554860929, 277.030015599462, 344.993552679863, 578.089540975509 ),
      ( 300, 5052.88935006547, 100000.000001619, 72501.0787659929, 72520.869422996, 348.500496943966, 280.339273365463, 348.702475616121, 498.290019726772 ),
      ( 320.823000611981, 4845.76994665576, 100000.000015869, 79813.423716907, 79834.0602723185, 372.066992947806, 284.584304430502, 354.065707586652, 432.87781902067 ),
      ( 325, 39.4283287963553, 100000, 106387.702367636, 108923.94985904, 462.445876219373, 273.369824535317, 285.039497072547, 88.442806698079 ),
      ( 375, 33.2372750985326, 99999.9999999999, 120450.128293358, 123458.79851989, 504.024066972937, 287.180782816471, 297.213915255336, 97.4516486275497 ),
      ( 425, 28.9308510626381, 100000, 135245.746209116, 138702.26395149, 542.162089643685, 303.454434837564, 312.793309565494, 104.994764963622 ),
      ( 475, 25.6898061264688, 100000.000060418, 150858.316242335, 154750.910821217, 577.845604293338, 320.181808321759, 329.174581727181, 111.712126872117 ),
      ( 165, 6234.4789125847, 101324.999942575, 25223.3668602822, 25239.6192209627, 138.467939229149, 295.343400590862, 369.772828133073, 946.34948576837 ),
      ( 175, 6147.07723243564, 101325.000003023, 28891.6101317497, 28908.0935752094, 160.055070873446, 290.768182963971, 364.070638527027, 912.298002001897 ),
      ( 200, 5932.63343428955, 101325.00000165, 37849.0429714267, 37866.1222332965, 207.918110427757, 282.322308528552, 353.35960681722, 827.125246423178 ),
      ( 225, 5720.30441119301, 101324.99999988, 46594.3282756513, 46612.0414938153, 249.130330459489, 277.589149443889, 346.977683297112, 742.639724089773 ),
      ( 250, 5505.91816661049, 101325.000000148, 55227.6426951197, 55246.0456202875, 285.520113151406, 275.982531957315, 344.326022991113, 659.536127851718 ),
      ( 275, 5285.15959935212, 101324.99999949, 63836.7923369769, 63855.9639434524, 318.344126905878, 277.030097069698, 344.992913949416, 578.098665549168 ),
      ( 300, 5052.91035222094, 101325.000000449, 72500.9293390864, 72520.9821389458, 348.499998578266, 280.339267096609, 348.701456087133, 498.301480972523 ),
      ( 321.201649728291, 4841.88109384121, 101325.000016949, 79947.3081148264, 79968.2348988703, 372.484114295587, 284.672792784655, 354.181697076843, 431.709237454574 ),
      ( 325, 39.987732504518, 101325, 106381.141165244, 108915.043281063, 462.315796920574, 273.411700022606, 285.137593101585, 88.3640574720737 ),
      ( 375, 33.6943900583254, 101325, 120446.076970804, 123453.254124764, 503.903699834027, 287.200222963477, 297.259254359753, 97.4059067701553 ),
      ( 425, 29.3229797424244, 101325, 135242.951603684, 138698.432625396, 542.046036432373, 303.465197105185, 312.818729347142, 104.965220947438 ),
      ( 475, 26.0352532528687, 101325.000063714, 150856.224969348, 154748.063434662, 577.731750416872, 320.187510722925, 329.189712239553, 111.691886166242 ),
      ( 165, 6238.44304424558, 999999.999947466, 25189.9019934743, 25350.1983996217, 138.264782018912, 295.46582836244, 369.734520653317, 948.743506440786 ),
      ( 175, 6151.34162151651, 1000000.00000222, 28855.6372685548, 29018.2034307891, 159.849157157571, 290.891000297613, 364.014936794461, 914.898984394083 ),
      ( 200, 5937.8135457138, 1000000.00000037, 37805.8281883212, 37974.2403474942, 207.701632200695, 282.443113727221, 353.253946637308, 830.338086142103 ),
      ( 225, 5726.71174551049, 999999.999999599, 46542.1040154413, 46716.7242939604, 248.897744844168, 277.700333995513, 346.804688897281, 746.615836996691 ),
      ( 250, 5514.00880111895, 999999.999999572, 55163.9064188207, 55345.2626763219, 285.26458256709, 276.073541365082, 344.055268963187, 664.460090712076 ),
      ( 275, 5295.63658206022, 1000000.0000001, 63757.8456327481, 63946.6803430808, 318.056301104192, 277.086339176672, 344.57232470022, 584.212808604739 ),
      ( 300, 5066.92476793486, 999999.999999772, 72401.0352588972, 72598.3936263093, 348.166018750278, 280.338202092431, 348.036290561516, 505.946665681727 ),
      ( 325, 4821.83627406686, 1000000.00000474, 81164.3342958162, 81371.7241662237, 376.252325973006, 285.486048760627, 354.299999262918, 429.549134087576 ),
      ( 350, 4551.38461484449, 1000000.00000022, 90118.9914504176, 90338.704809016, 402.829057211631, 292.248884025528, 363.636152416754, 354.61050771378 ),
      ( 375, 4239.21980709028, 1000000.00009735, 99355.1113052277, 99591.0037678985, 428.357266796994, 300.438470614668, 377.598416313612, 279.803369951368 ),
      ( 400, 3844.01755831109, 999999.999999982, 109050.826727324, 109310.971220639, 453.440970654725, 310.181820705825, 403.534774102316, 200.450765836907 ),
      ( 408.263959917019, 3674.33747106575, 999999.999999974, 112437.959350605, 112710.117258765, 461.851656033973, 313.977851224727, 420.541669185938, 170.666454351422 ),
      ( 425, 385.710258830281, 1000000, 132718.681225814, 135311.300885536, 516.819321539244, 314.168351161015, 352.039722310819, 78.5264258509159 ),
      ( 475, 299.165124370967, 1000000.00000011, 149225.37331166, 152568.008928371, 555.213527589017, 324.836094551288, 344.47679045172, 96.7038996008785 ),
      ( 175, 6155.87937962232, 1962477.91208809, 28817.4214562502, 29136.2187865853, 159.629767228219, 291.021821799839, 363.957851417383, 917.663569112825 ),
      ( 192, 6010.83766474332, 1962477.91169854, 34927.0362463598, 35253.5261669261, 192.996094646379, 284.841320245689, 356.100013055039, 860.536623880609 ),
      ( 209, 5867.67178489452, 1962477.91076499, 40921.0414228653, 41255.4974017796, 222.952520530396, 280.468519183331, 350.341961575164, 803.727858882124 ),
      ( 226, 5725.10149053227, 1962477.91221731, 46832.9094495631, 47175.6942745069, 250.187672451519, 277.696778934774, 346.446061002958, 747.531894008884 ),
      ( 243, 5581.93437691063, 1962477.91221778, 52692.6269508128, 53044.2036229313, 275.22523733273, 276.348859835832, 344.234734921506, 692.163270364969 ),
      ( 260, 5436.98167689371, 1962477.91221726, 58527.4447392256, 58888.3946244454, 298.471687503045, 276.271229435804, 343.562761233914, 637.754388619611 ),
      ( 277, 5288.99254305358, 1962477.91221659, 64362.3005147445, 64733.3499908483, 320.247637495841, 277.327641353146, 344.305359048277, 584.377908209315 ),
      ( 294, 5136.58670455696, 1962477.91221748, 70220.1304179588, 70602.1891711921, 340.809462658261, 279.394445062479, 346.356872269464, 532.069639824996 ),
      ( 311, 4978.1670425881, 1962477.91221763, 76122.2294007626, 76516.4463676559, 360.365010533394, 282.358268866007, 349.638566664325, 480.841658637928 ),
      ( 328, 4811.78541150819, 1962477.91221723, 82088.8236091066, 82496.6717869417, 379.085822224431, 286.115683089782, 354.117919917012, 430.680239343044 ),
      ( 345, 4634.9091906649, 1962477.91221762, 88140.1034032674, 88563.5157791065, 397.117694298017, 290.57400024973, 359.848457300253, 381.520797954478 ),
      ( 362, 4443.96791084876, 1962477.91221756, 94298.2025145449, 94739.8073936951, 414.591505256567, 295.652615324179, 367.052477013464, 333.181476639097 ),
      ( 379, 4233.37787425393, 1962477.9122173, 100591.218508862, 101054.791090973, 431.637366795878, 301.291004376234, 376.310095766013, 285.226195130821 ),
      ( 396, 3993.16658231419, 1962477.91221731, 107062.435110154, 107553.894174474, 448.409896571509, 307.483794988889, 389.093356396603, 236.710633393581 ),
      ( 413, 3701.80318959788, 1962477.91221734, 113796.958618059, 114327.099690316, 465.153983598504, 314.392529881528, 409.823868566898, 185.585879240602 ),
      ( 430, 3292.5053993019, 1962477.91215886, 121041.892405781, 121637.936352307, 482.494581480323, 322.918389810581, 460.416639163538, 126.184868234922 ),
      ( 447, 1263.86429270593, 1962477.91221728, 134612.80731973, 136165.567314251, 515.446180360695, 342.562930999313, 852.084928713176, 46.7454136643507 ),
      ( 464, 844.496167927225, 1962477.91221727, 142528.11362094, 144851.958283295, 534.553436536679, 332.278607753092, 418.22835182473, 68.6890134483861 ),
      ( 481, 716.131890490106, 1962477.91221727, 148864.963445534, 151605.349592664, 548.851462777962, 332.981962242784, 383.698048538375, 79.8796969838531 ),
      ( 498, 639.279613464195, 1962477.91222236, 154950.92194895, 158020.749096398, 561.959872824204, 335.8337350638, 372.89995838659, 87.9780029863967 ),
      ( 175, 6192.65556605627, 9999999.99995647, 28510.1649189701, 30124.9810335251, 157.841281584653, 292.087195792927, 363.574733598311, 939.953795119816 ),
      ( 192, 6052.40648379195, 9999999.99986566, 34581.5049213377, 36233.7402803879, 191.161166196446, 285.897228893969, 355.47297216479, 886.021405621967 ),
      ( 209, 5914.95356559181, 9999999.99973131, 40532.1019123664, 42222.7322594756, 221.052986829412, 281.491938118994, 349.434321835083, 832.856955607626 ),
      ( 226, 5779.22469279296, 9999999.99961549, 46394.3960919041, 48124.7319987406, 248.204602357033, 278.658335702128, 345.20189563486, 780.774393784029 ),
      ( 243, 5644.3032462577, 10000000.0000001, 52197.0051097493, 53968.7029728345, 273.137660966483, 277.215249075345, 342.577332505339, 730.02001227034 ),
      ( 260, 5509.36946183628, 9999999.99999962, 57965.4150948717, 59780.504837767, 296.255474182653, 277.004987910271, 341.390245286333, 680.77339744733 ),
      ( 277, 5373.67042336767, 9999999.99999941, 63722.2957061791, 65583.2211467335, 317.874273616726, 277.885198525829, 341.482715832462, 633.170500229736 ),
      ( 294, 5236.50521009296, 10000000, 69487.6350308134, 71397.3056219408, 338.244502140005, 279.723021815103, 342.70270272418, 587.326658198635 ),
      ( 311, 5097.21831655624, 10000000.0000001, 75278.8116783767, 77240.6660426521, 357.565902977148, 282.391861822782, 344.902850554345, 543.351403042455 ),
      ( 328, 4955.19722139565, 10000000.0000004, 81110.6752021882, 83128.7583486717, 375.998618962641, 285.770095269068, 347.942620516381, 501.353217261879 ),
      ( 345, 4809.87052143998, 9999999.99999997, 86995.6774432632, 89074.7354876377, 393.671646420462, 289.740794964409, 351.692380026961, 461.434715540445 ),
      ( 362, 4660.70293166371, 9999999.9999998, 92944.0718496612, 95089.6709463257, 410.689465072344, 294.191834841792, 356.03774848735, 423.680252939459 ),
      ( 379, 4507.18560429496, 10000000.0000001, 98964.1646522599, 101182.844085046, 427.13731243111, 299.016975503453, 360.882291911051, 388.142870206226 ),
      ( 396, 4348.82577264752, 10000000, 105062.578958791, 107362.050246626, 443.085364451317, 304.117978589944, 366.147524082516, 354.842593381837 ),
      ( 413, 4185.14617815761, 10000000, 111244.463590891, 113633.866391727, 458.591927750565, 309.404778103709, 371.766645765114, 323.781898589146 ),
      ( 430, 4015.71642521422, 9999999.99999878, 117513.489141609, 120003.704819491, 473.705486338443, 314.793102786343, 377.664632186354, 294.975595451602 ),
      ( 447, 3840.26110119871, 9999999.99999987, 123871.38638787, 126475.375995993, 488.465233381721, 320.203887148959, 383.720357597276, 268.494356255541 ),
      ( 464, 3658.9060235806, 9999999.99999991, 130316.83290561, 133049.890255417, 502.899832927608, 325.566646575086, 389.717429246252, 244.514736974904 ),
      ( 481, 3472.58650375532, 9999999.99999991, 136843.813676242, 139723.511558263, 517.024818478087, 330.824294318944, 395.313014164058, 223.339678481743 ),
      ( 498, 3283.4877150127, 9999999.99999996, 143440.316404317, 146485.858482723, 530.840531409031, 335.936858270264, 400.086750554696, 205.329509311937 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new(double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 199.60125, 38.0910355802673, 5935.44109614256, 0.0229554651676903 ),
      ( 234.2025, 1029.80898108501, 5641.06461928594, 0.529954888802452 ),
      ( 268.80375, 9871.60555083731, 5339.71765960667, 4.47021603790103 ),
      ( 303.405, 50168.277051206, 5019.19279695825, 20.6974286110366 ),
      ( 338.00625, 170018.318239661, 4663.06685304315, 66.6906810675176 ),
      ( 372.6075, 441356.84864802, 4243.68819203745, 174.225932220686 ),
      ( 407.20875, 958920.156098489, 3692.16039288386, 419.730539146155 ),
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
