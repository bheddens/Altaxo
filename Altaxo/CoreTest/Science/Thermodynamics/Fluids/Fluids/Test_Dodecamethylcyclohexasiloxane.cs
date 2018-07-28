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
  /// Tests and test data for <see cref="Dodecamethylcyclohexasiloxane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Dodecamethylcyclohexasiloxane : FluidTestBase
  {

    public Test_Dodecamethylcyclohexasiloxane()
    {
      _fluid = Dodecamethylcyclohexasiloxane.Instance;

      _testDataMolecularWeight = 0.444924;

      _testDataTriplePointTemperature = 270.2;

      _testDataTriplePointPressure = 0.1597;

      _testDataTriplePointLiquidMoleDensity = 2245.07628990766;

      _testDataTriplePointVaporMoleDensity = 7.11098197032619E-05;

      _testDataCriticalPointTemperature = 645.78;

      _testDataCriticalPointPressure = 961731.132404021;

      _testDataCriticalPointMoleDensity = 627.2885478;

      _testDataNormalBoilingPointTemperature = 518.109977174844;

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
      ( 275, 0.000104768200765651, 0.239550007347703, -481709.309842111, -479422.83354876, -1102.1549563605, 1071.23523038864, 1079.54976135468, 71.9646158087967 ),
      ( 325, 8.86499581290659E-05, 0.239550004279729, -417230.813693049, -414528.612706886, -886.375110643745, 1516.43524391548, 1524.74974810269, 78.1453362111691 ),
      ( 375, 7.68299384846409E-05, 0.239550002737443, -329748.39477831, -326630.469559805, -635.60416282594, 1981.75166136587, 1990.06615318699, 83.8878276245072 ),
      ( 425, 6.77911095959592E-05, 0.239550001864675, -219437.965697085, -215904.316472394, -359.006536577846, 2425.02601705172, 2433.34050235526, 89.2713203855753 ),
      ( 475, 6.065519638219E-05, 0.23955000132721, -87888.0521149158, -83938.6790089778, -65.8651259372729, 2830.25021140889, 2838.56469291844, 94.3535159305549 ),
      ( 525, 5.48785068964791E-05, 0.239550000974923, 62932.7916396412, 67297.8885513848, 236.554837807606, 3196.40055952757, 3204.71503865314, 99.1786276405521 ),
      ( 575, 5.01064602356828E-05, 0.239550000732804, 231183.108187108, 235963.928855861, 543.202874642219, 3528.44111084918, 3536.75558838437, 103.781361631319 ),
      ( 625, 4.60979417222548E-05, 0.239550000560138, 415309.509568754, 420506.053961201, 850.775183366422, 3832.40122004275, 3840.71569646528, 108.189465257782 ),
      ( 270.2, 2245.07820722532, 391.90363833749, -558936.898637339, -558936.724076098, -1392.89875151238, 1121.25522465813, 1187.98701871604, 697.53403791798 ),
      ( 275, 2233.2327916815, 391.903641798394, -553146.27841498, -553146.102927837, -1371.65696677073, 1157.90716524284, 1224.93454367072, 689.037661783448 ),
      ( 300, 2171.5639849314, 391.903638840976, -519991.776610753, -519991.596140068, -1256.39410668576, 1362.22408981762, 1430.7505041977, 646.183154841283 ),
      ( 325, 2109.76330688864, 391.903635743636, -481484.800308711, -481484.614551554, -1133.22389632761, 1581.50645010473, 1651.50511020655, 605.324047049495 ),
      ( 350, 2047.56746060069, 391.903631014073, -437365.427503151, -437365.236103532, -1002.54389987924, 1806.96126039707, 1878.46760174912, 565.953391420184 ),
      ( 361.681092738633, 2018.28666584313, 391.903632425381, -414801.947323619, -414801.753147222, -939.138777369015, 1912.47605150557, 1984.71949466195, 547.928273966642 ),
      ( 375, 0.125811356825719, 391.903638468657, -329754.476823753, -326639.466793207, -697.147553291047, 1981.77240063495, 1990.11939883885, 83.8100439854029 ),
      ( 425, 0.110976866193213, 391.903638468615, -219442.590710281, -215911.191312263, -420.544588810221, 2425.03793021402, 2433.37421095509, 89.2148661853449 ),
      ( 475, 0.0992768407614851, 391.903638468601, -87891.7463970831, -83944.1626961658, -127.400072477973, 2830.25756049203, 2838.58761224164, 94.3110166386188 ),
      ( 525, 0.0898110872262408, 391.903638468597, 62929.7324745135, 67293.3767702491, 175.021842054434, 3196.40536680568, 3204.73150825703, 99.1457995953536 ),
      ( 575, 0.0819946428275136, 391.903638468595, 231180.505702821, 235960.130626525, 481.671179968434, 3528.444414456, 3536.76794894802, 103.755535603223 ),
      ( 625, 0.0754306213430652, 391.903638468594, 415307.249545508, 420502.800523223, 789.244398792461, 3832.40358814647, 3840.72529957307, 108.168883977982 ),
      ( 270.2, 2245.08118341766, 999.999999451623, -558936.979099417, -558936.533681226, -1392.89904930102, 1121.25539216031, 1187.98684960662, 697.537119846909 ),
      ( 275, 2233.23583703527, 1000.00000469213, -553146.361144491, -553145.913363747, -1371.65726760687, 1157.907333904, 1224.93436656369, 689.040801695149 ),
      ( 300, 2171.56742279203, 999.999999530342, -519991.872075725, -519991.411578856, -1256.39442490403, 1362.2242650819, 1430.75027919849, 646.186620784575 ),
      ( 325, 2109.76720197286, 999.999995879928, -481484.910334352, -481484.436348409, -1133.22423486992, 1581.50663297104, 1651.50482393602, 605.327888335088 ),
      ( 350, 2047.5718964497, 999.99999253726, -437365.554396489, -437365.066013154, -1002.54426243374, 1806.96145195735, 1878.46723523015, 565.957672739123 ),
      ( 375, 1984.67276008564, 999.999995741755, -387564.840436007, -387564.336574607, -865.198375629777, 2031.98575943807, 2105.10972715047, 527.584474762846 ),
      ( 379.154918345877, 1974.12565725649, 999.999995725289, -378740.746694712, -378740.240141346, -841.797232992702, 2068.99919509872, 2142.40918469914, 521.270723484042 ),
      ( 400, 0.30127079794989, 1000.00000000152, -277379.009069033, -274059.736153084, -569.266844981784, 2207.6689566182, 2216.05102965456, 86.4519676958682 ),
      ( 450, 0.267637169347406, 1000.00000000051, -156206.169743678, -152469.767948521, -283.333661175443, 2632.70687315983, 2641.06818505541, 91.7223744527686 ),
      ( 500, 0.240782458141697, 1000.00000000019, -14773.9103642808, -10620.7838960241, 15.2155814566434, 3017.97898832497, 3026.32775402718, 96.7007011949871 ),
      ( 550, 0.218837607184286, 1000.00000000008, 144976.322288626, 149545.920781621, 320.262285563914, 3366.30891747144, 3374.64956204713, 101.43170607354 ),
      ( 600, 0.200565491264753, 1000.00000000004, 321341.047920891, 326326.950499117, 627.701364301646, 3683.58781921792, 3691.92291584175, 105.949442919607 ),
      ( 650, 0.185113557534362, 1000.00000000002, 512914.210854357, 518316.30032484, 934.892482829027, 3975.50394739787, 3983.83508729885, 110.280674189083 ),
      ( 270.2, 2245.12522873901, 9999.99999918252, -558938.169840068, -558933.715745539, -1392.90345636508, 1121.25787103859, 1187.98434735371, 697.582730079086 ),
      ( 275, 2233.28090579341, 10000.0000048342, -553147.585437882, -553143.107720825, -1371.66171976356, 1157.90982993006, 1224.9317459862, 689.087269920087 ),
      ( 300, 2171.61829968588, 9999.9999995406, -519993.28482106, -519988.679960251, -1256.39913425293, 1362.22685880269, 1430.74695008172, 646.23791331863 ),
      ( 325, 2109.82484442225, 9999.99999592372, -481486.538532747, -481481.798802801, -1133.22924493028, 1581.50933916277, 1651.50058840108, 605.384734607738 ),
      ( 350, 2047.63754028155, 9999.99999010642, -437367.432174492, -437362.548497673, -1002.54962775977, 1806.96428677028, 1878.4618126313, 566.021029631967 ),
      ( 375, 1984.74803792479, 9999.99999331409, -387567.011973434, -387561.97355052, -865.204166676525, 2031.98874094385, 2105.10270795361, 527.655607220494 ),
      ( 400, 1920.77654027127, 9999.99999826312, -332152.534789969, -332147.328562285, -722.226037173995, 2252.07618486569, 2327.01375477267, 489.822664392464 ),
      ( 425, 1855.23332338976, 9999.99999976018, -271278.278011074, -271272.887853473, -574.672163172219, 2464.47711719421, 2541.57916016423, 452.064154978563 ),
      ( 433.934375425584, 1831.30966395198, 10000.0000000487, -248236.698871748, -248231.238298805, -521.021208660994, 2538.21850403396, 2616.21151405548, 438.498167751298 ),
      ( 450, 2.71011399199282, 10000.0000055622, -156302.065761241, -152612.184068032, -302.692190803083, 2632.92489717301, 2641.72746778498, 90.5806692006685 ),
      ( 500, 2.42961715420615, 10000.0000020354, -14851.6513618611, -10735.7765686973, -4.08497396334106, 3018.11636555501, 3026.78367395116, 95.8349330387694 ),
      ( 550, 2.20302436781518, 10000.000000818, 144911.196113246, 149450.410543605, 300.998960492269, 3366.40074997088, 3374.98240579631, 100.759217153758 ),
      ( 600, 2.01579791428376, 10000.0000003511, 321285.141529267, 326245.956266445, 608.46335051971, 3683.65218017783, 3692.17609157195, 105.418295544116 ),
      ( 650, 1.85831744003039, 10000.000000158, 512865.314704739, 518246.526646653, 915.672460436083, 3975.55089405313, 3984.03399263637, 109.856322719534 ),
      ( 270.2, 2245.56535508642, 100000.000000661, -558950.064783163, -558905.532567801, -1392.94749686626, 1121.28263904588, 1187.95938803289, 698.03850342141 ),
      ( 275, 2233.73124882328, 99999.9999997371, -553159.815300029, -553115.047157016, -1371.7062100402, 1157.9347688392, 1224.90560777614, 689.551605848085 ),
      ( 300, 2172.1266132199, 99999.999993746, -520007.395447691, -519961.357615741, -1256.44618942564, 1362.25277124598, 1430.71375508859, 646.750384223619 ),
      ( 325, 2110.40066096217, 99999.9999597301, -481502.798655115, -481455.414287867, -1133.27929795396, 1581.53637206848, 1651.45837181524, 605.952595480625 ),
      ( 350, 2048.29315587153, 99999.9999250806, -437386.181196018, -437337.360059435, -1002.6032209469, 1806.99260055704, 1878.40779062438, 566.653791433978 ),
      ( 375, 1985.49968282545, 99999.9999197841, -387588.688893296, -387538.323737973, -865.261999757746, 2032.01851488923, 2105.03282325682, 528.365831921125 ),
      ( 400, 1921.64624141247, 99999.999940872, -332177.723660744, -332125.68494634, -722.289041730509, 2252.10762314278, 2326.92189161769, 490.62718723451 ),
      ( 425, 1856.25200041802, 99999.9999664686, -271307.782537293, -271253.910541495, -574.741623839778, 2464.51045552556, 2541.45571002433, 452.986033331895 ),
      ( 450, 1788.67023771027, 99999.999984763, -205180.538616083, -205124.631161553, -423.603911527673, 2667.81846189982, 2747.41641293445, 414.971455820787 ),
      ( 475, 1717.98710949988, 99999.9999944898, -134014.321751272, -133956.114096836, -269.736596818736, 2861.56823067077, 2944.64107506823, 376.053149366651 ),
      ( 500, 1642.83241170148, 99999.9999996048, -58020.9011376084, -57960.0306560624, -113.854485841853, 3045.91089231472, 3133.79748645527, 335.578765774638 ),
      ( 516.518317102969, 1589.69815431081, 100000.000071528, -5252.94295840259, -5190.03793470337, -10.03104684784, 3162.79163051232, 3255.04102911929, 307.565355429715 ),
      ( 525, 25.1950032796668, 100000, 62073.7155173839, 66042.756477212, 127.287598535321, 3197.88192756638, 3210.29931856685, 89.9179963887163 ),
      ( 575, 22.4011056573753, 100000, 230474.383625066, 234938.448994405, 434.354690664261, 3529.36952719051, 3540.55622502301, 96.8131007209079 ),
      ( 625, 20.2498591591694, 100000, 414705.268346321, 419643.574297685, 742.199399980919, 3833.04346800885, 3843.51704717108, 102.793006557286 ),
      ( 270.2, 2245.5718302907, 101325.000000247, -558950.239734104, -558905.117597001, -1392.94814483148, 1121.28300340418, 1187.95902143277, 698.045208956097 ),
      ( 275, 2233.73787420013, 101324.999999804, -553159.995173479, -553114.633987115, -1371.70686461153, 1157.93513570575, 1224.90522387914, 689.558437208069 ),
      ( 300, 2172.13409054924, 101324.99999251, -520007.602959292, -519960.955286649, -1256.44688166274, 1362.25315239887, 1430.71326768727, 646.757922772736 ),
      ( 325, 2110.40913001944, 101324.999959272, -481503.037743873, -481455.025726431, -1133.28003420064, 1581.53676965956, 1651.45775217208, 605.96094749688 ),
      ( 350, 2048.3027968404, 101324.999923587, -437386.456833529, -437336.989049723, -1002.60400914354, 1806.99301693337, 1878.40699806072, 566.663096157868 ),
      ( 375, 1985.51073335451, 101324.999917742, -387589.007504791, -387537.975295186, -865.26285014085, 2032.01895267076, 2105.03179855399, 528.376273111415 ),
      ( 400, 1921.65902370795, 101324.999938274, -332178.093785736, -332125.3659091, -722.289967914091, 2252.10808530911, 2326.92054564149, 490.639010900202 ),
      ( 425, 1856.26696618988, 101324.99996518, -271308.21591148, -271253.630551825, -574.742644572475, 2464.51094551074, 2541.4539029985, 452.999575935836 ),
      ( 450, 1788.68804693863, 101324.999983607, -205181.052041557, -205124.404377278, -423.605053718361, 2667.81898367968, 2747.41391403489, 414.987191297153 ),
      ( 475, 1718.00877845799, 101324.999994049, -134014.940560626, -133955.962398661, -269.737901131117, 2861.56878877331, 2944.63747666561, 376.071772555172 ),
      ( 500, 1642.85961773193, 101324.99999957, -58021.6662176307, -57959.9902235859, -113.856018031304, 3045.91149145911, 3133.79200080268, 335.60135330775 ),
      ( 517.109977174844, 1587.7627245578, 101325.000072371, -3326.77560425036, -3262.95939386502, -6.30389556702384, 3166.90906770158, 3259.33053014126, 306.564480262245 ),
      ( 525, 25.5653350240022, 101325, 62061.0100925347, 66024.3847130852, 127.153162343796, 3197.90761622049, 3210.40130666565, 89.7801492152525 ),
      ( 575, 22.7201708247375, 101325, 230464.314696924, 234924.008278526, 434.227434239721, 3529.38346101925, 3540.61763235464, 96.7149608209842 ),
      ( 625, 20.5326730463936, 101325, 414696.866904315, 419631.684683328, 742.076408678376, 3833.05259415067, 3843.55962319772, 102.719443801393 ),
      ( 275, 2238.20065772641, 1000000.00000021, -553280.823153587, -552834.035687705, -1372.1480222011, 1158.18204832151, 1224.65083424741, 694.160810651327 ),
      ( 295, 2189.36734331153, 1000000.00000066, -527189.333114763, -526732.580161425, -1280.59335620811, 1320.12893786195, 1387.73361020083, 660.115360155039 ),
      ( 315, 2140.54344384051, 1000000.00000087, -497720.10893861, -497252.937855081, -1183.96649968764, 1492.9005010169, 1561.60324158186, 627.457843115286 ),
      ( 335, 2091.61278296162, 999999.999999549, -464706.839681969, -464228.739716169, -1082.3783066818, 1671.66982936329, 1741.45944628337, 595.940315730714 ),
      ( 355, 2042.44811893803, 1000000.00000096, -428070.599040928, -427580.990521265, -976.174170395163, 1852.48731920296, 1923.38189742169, 565.318023427007 ),
      ( 375, 1992.90560701119, 1000000.0000434, -387801.706044604, -387299.926132637, -865.832777762262, 2032.31223127405, 2104.36344662259, 535.361060572596 ),
      ( 395, 1942.81791292802, 1000000.00062359, -343942.00185398, -343427.28557822, -751.892255811259, 2208.94490077239, 2282.24447732424, 505.854700338948 ),
      ( 415, 1891.98519845223, 999999.999999685, -296569.020466676, -296040.47510553, -634.89924510069, 2380.9070111535, 2455.59617763621, 476.595005774993 ),
      ( 435, 1840.16277107398, 999999.99999976, -245782.712092682, -245239.281905027, -515.375974232824, 2547.30351163782, 2623.58691479515, 447.382718603446 ),
      ( 455, 1787.04343340068, 1000000.00000026, -191694.819182505, -191135.235693201, -393.800699879864, 2707.68738014983, 2785.85394945053, 418.016420471528 ),
      ( 475, 1732.231189996, 999999.999999857, -134420.654216713, -133843.364068738, -270.597514204761, 2861.93894004432, 2942.39408638973, 388.284971739487 ),
      ( 495, 1675.20034997098, 999999.999999694, -74072.8140109075, -73475.8704870974, -146.132228177911, 3010.16488129108, 3093.48204172651, 357.958745371907 ),
      ( 515, 1615.22882475884, 999999.999999923, -10756.2074263509, -10137.1000994685, -20.7116284904612, 3152.61803490706, 3239.62496017041, 326.778966693742 ),
      ( 535, 1551.28328267036, 1000000.0000001, 55436.4318099927, 56081.059397469, 105.416287843587, 3289.63675071015, 3381.56798027295, 294.444623065696 ),
      ( 555, 1481.80829410205, 999999.999999858, 124429.816480161, 125104.667609002, 232.063746873424, 3421.60213943193, 3520.38700718745, 260.597213500386 ),
      ( 575, 1404.30674003118, 999999.999999981, 196174.591961515, 196886.687098207, 359.110494575056, 3548.9131835073, 3657.76992870639, 224.803376791866 ),
      ( 595, 1314.40274857719, 999999.999999963, 270665.089099007, 271425.890916473, 486.526813272763, 3671.9895057756, 3796.83606068976, 186.5079846538 ),
      ( 615, 1203.22729299359, 999999.99992261, 347988.57011231, 348819.668281164, 614.448570954305, 3791.36923250921, 3945.40169728564, 144.626259434935 ),
      ( 635, 1044.0303138746, 999999.999999392, 428581.232909069, 429539.05950348, 743.593870298586, 3908.52230576533, 4147.11441370762, 93.3995311455096 ),
      ( 655, 387.030823979509, 1000000, 522214.521498388, 524798.2950328, 891.20053095313, 4024.09435430752, 4339.04687998539, 43.7385855160363 ),
      ( 275, 2238.24907568565, 1009817.68902452, -553282.130395108, -552830.966268652, -1372.15281112438, 1158.18472488396, 1224.64811983929, 694.210752674165 ),
      ( 295, 2189.42057093557, 1009817.68902361, -527190.796436208, -526729.570437682, -1280.59835444609, 1320.13169274896, 1387.730338647, 660.169276839132 ),
      ( 315, 2140.60206478915, 1009817.68902454, -497721.74474809, -497250.000043348, -1183.97173354759, 1492.90334333227, 1561.59930082276, 627.516167430178 ),
      ( 335, 2091.67750224327, 1009817.68902476, -464708.667451293, -464225.888586988, -1082.38380708474, 1671.67276866112, 1741.45469128234, 596.003580104249 ),
      ( 355, 2042.51979830299, 1009817.68902487, -428072.642168366, -427578.244175326, -976.179974321646, 1852.49036565209, 1923.37613771964, 565.386882927282 ),
      ( 375, 1992.98531430813, 1009817.68906711, -387803.993045874, -387297.307079943, -865.838930210053, 2032.31539582113, 2104.35642806312, 535.436324290788 ),
      ( 395, 1942.90699227394, 1009817.68964761, -343944.568037512, -343424.822268073, -751.898812515896, 2208.94819529993, 2282.23585451018, 505.93737452504 ),
      ( 415, 1892.08537232883, 1009817.6890241, -296571.910343838, -296038.204146543, -634.906276420276, 2380.91044861917, 2455.58547118299, 476.686354068331 ),
      ( 435, 1840.27629299137, 1009817.68902405, -245785.982939294, -245237.251374979, -515.383570862634, 2547.30710615962, 2623.57344273817, 447.484347835223 ),
      ( 455, 1787.17332363885, 1009817.68902419, -191698.546470298, -191133.510233651, -393.808981544621, 2707.69114695269, 2785.83671286215, 418.130405975187 ),
      ( 475, 1732.38161375143, 1009817.68902435, -134424.940212141, -133842.033027599, -270.606643400367, 2861.94289506345, 2942.37156988651, 388.41404588546 ),
      ( 495, 1675.37725208224, 1009817.68902436, -74077.8020094569, -73475.0615295028, -146.142432902809, 3010.16903990698, 3093.45184662632, 358.106591270447 ),
      ( 515, 1615.4410550212, 1009817.68902441, -10762.1066180713, -10137.0032223853, -20.7232419405039, 3152.62240834657, 3239.58308581884, 326.950694590905 ),
      ( 535, 1551.54472917548, 1009817.68902418, 55429.2999492568, 56080.1465990732, 105.402753230108, 3289.64133555862, 3381.50730314301, 294.647580811084 ),
      ( 555, 1482.1422815284, 1009817.68902434, 124420.924214171, 125102.247256911, 232.047449425096, 3421.60688406276, 3520.29373391588, 260.842452608657 ),
      ( 575, 1404.75614697848, 1009817.68902409, 196162.993351977, 196881.849568549, 359.089924941424, 3548.91786317931, 3657.61416874045, 225.108581456941 ),
      ( 595, 1315.0572467172, 1009817.6890242, 270648.86193123, 271416.750699225, 486.498901218095, 3671.99314747104, 3796.54110361807, 186.904742818583 ),
      ( 615, 1204.32073607221, 1009817.68890604, 347962.867648607, 348801.363290722, 614.405545354913, 3791.36650406883, 3944.69341209138, 145.189220206374 ),
      ( 635, 1046.68151874353, 1009817.68902351, 428523.834094003, 429488.614374289, 743.499639109999, 3908.46045017401, 4143.34846671967, 94.5048567207846 ),
      ( 655, 400.065873031927, 1009817.68902422, 521872.799529795, 524396.928072356, 890.549657097784, 4025.07487030608, 4383.35021267189, 41.9161232555435 ),
      ( 295, 2234.8274931858, 10000000.0000003, -528406.791048265, -523932.172747528, -1284.88931443755, 1322.4664482649, 1385.35412668821, 706.257667314637 ),
      ( 315, 2190.17807586599, 10000000.0000005, -499070.160792315, -494504.322009527, -1188.43217276698, 1495.29678005873, 1558.79260992282, 676.91441467089 ),
      ( 335, 2145.86810724576, 9999999.99999954, -466201.364647411, -461541.245991361, -1087.03194804049, 1674.13019777457, 1738.14426736178, 649.019829719708 ),
      ( 355, 2101.849194821, 9999999.99829831, -429723.305994971, -424965.590730271, -981.036671378155, 1855.01705520155, 1919.47065414931, 622.387168463843 ),
      ( 375, 2058.07544195512, 10000000.0000013, -389628.55673895, -384769.64836458, -870.928370297008, 2034.91658731728, 2099.74095507612, 596.853806996201 ),
      ( 395, 2014.50270675727, 10000000.0000561, -345961.763807404, -340997.759556374, -757.249407322874, 2211.62909234029, 2276.76427171678, 572.283989614258 ),
      ( 415, 1971.08814319005, 10000000.0005409, -298803.998181971, -293730.658344232, -640.551822713675, 2383.67616756423, 2449.06984023283, 548.567427897162 ),
      ( 435, 1927.79003819608, 10000000.0000006, -248259.729225115, -243072.442330865, -521.364792708122, 2550.16257146456, 2615.76876742378, 525.616926498773 ),
      ( 455, 1884.56797902187, 10000000.0000005, -194446.563395293, -189140.307472814, -400.175629136892, 2710.64090117779, 2776.41847987723, 503.366310657235 ),
      ( 475, 1841.38340464063, 10000000.0000005, -137487.562595526, -132056.863060167, -277.420426477539, 2864.990770099, 2930.90157171466, 481.769046702618 ),
      ( 495, 1798.20061539091, 10000000.0000003, -77505.793889665, -71944.6791205955, -153.4812496326, 3013.31758779437, 3079.32415367034, 460.797572011396 ),
      ( 515, 1754.98833137759, 9999999.99999977, -14620.7051136876, -8922.66153059997, -28.6875044492964, 3155.87188003619, 3221.93464883577, 440.443192396181 ),
      ( 535, 1711.72189751021, 9999999.99999966, 51054.0722330866, 56896.1427321234, 96.6802241823391, 3292.9877125001, 3359.06162425098, 420.716319712964 ),
      ( 555, 1668.38621935484, 9999999.99999963, 119411.850723301, 125405.666713861, 222.38506552134, 3425.03762956338, 3491.06813033798, 401.646742857775 ),
      ( 575, 1624.97946106554, 10000000.0000001, 190353.24878906, 196507.17272447, 348.228291962677, 3552.40114296434, 3618.31970089302, 383.283522899163 ),
      ( 595, 1581.51741923037, 10000000.0000001, 263786.034150346, 270109.07547661, 474.043799874935, 3675.44388151193, 3741.16332379532, 365.693975529157 ),
      ( 615, 1538.03827802014, 10000000.0000002, 339624.646128079, 346126.434895569, 599.692956048718, 3794.50482525382, 3859.91509582389, 348.961081802468 ),
      ( 635, 1494.60714139423, 10000000.0000002, 417789.551938434, 424480.273348122, 725.059987447056, 3909.88945812104, 3974.85474271216, 333.178632859171 ),
      ( 655, 1451.31936777376, 10000000, 498206.557430027, 505096.839625695, 850.048003029339, 4021.86710091722, 4086.22555139782, 318.443609663774 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new(double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 317.1475, 17.5250656897642, 2129.2020332379, 0.00664652073986764 ),
      ( 364.095, 424.665621398204, 2012.21373598458, 0.1404366314703 ),
      ( 411.0425, 4054.6345890947, 1891.99258181287, 1.19517347411158 ),
      ( 457.99, 21237.7686336847, 1765.34415518826, 5.73850073394539 ),
      ( 504.9375, 74908.1279428081, 1626.74805610725, 19.3124202649351 ),
      ( 551.885, 203312.594942702, 1464.85449503995, 53.1312974562407 ),
      ( 598.8325, 465223.166678144, 1249.73991972508, 137.221249238088 ),
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
