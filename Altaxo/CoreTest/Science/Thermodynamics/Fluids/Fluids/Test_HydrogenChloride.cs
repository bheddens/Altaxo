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
	/// Tests and test data for <see cref="HydrogenChloride"/>.
	/// </summary>
	/// <remarks>
	/// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
	/// </remarks>
  [TestFixture]
  public class Test_HydrogenChloride : FluidTestBase
    {

    public Test_HydrogenChloride()
      {
      _fluid = HydrogenChloride.Instance;

    _testDataMolecularWeight = 0.036460939169;

    _testDataTriplePointTemperature = 159.066;

    _testDataTriplePointPressure = 13770;

    _testDataTriplePointLiquidMoleDensity = 34377.7319460934;

    _testDataTriplePointVaporMoleDensity = 10.5440829035986;

    _testDataCriticalPointTemperature = 324.55;

    _testDataCriticalPointPressure = 8288160.90444714;

    _testDataCriticalPointMoleDensity = 11800;

    _testDataNormalBoilingPointTemperature = 188.178727145864;

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
      ( 159.066, 0.756546217667316, 1000.00000000004, 14185.2220905223, 15507.018402033, 120.164636046466, 20.8334056633257, 29.1755657210798, 225.254919127439 ),
      ( 175, 0.68753954516971, 1000.00000000001, 14517.3188532544, 15971.7806467984, 122.949217561361, 20.8278089631227, 29.1611364125267, 236.283112299454 ),
      ( 191, 0.629873903226432, 1000, 14850.652271486, 16438.2716265309, 125.499980880726, 20.8232856463015, 29.1508469828547, 246.859383156921 ),
      ( 207, 0.581145543110506, 1000, 15183.8852179583, 16904.6245608906, 127.844730479965, 20.8199368649031, 29.1437153239138, 256.999131483333 ),
      ( 223, 0.539422474617954, 1000, 15517.0480524109, 17370.8825644198, 130.014376284713, 20.8175910462544, 29.1388504409844, 266.752496340758 ),
      ( 239, 0.503293296240429, 1000, 15850.163269883, 17837.076283567, 132.033339640886, 20.8160373669895, 29.135588368579, 276.160628892456 ),
      ( 255, 0.471702540054477, 999.999999999999, 16183.2474401133, 18303.2275442791, 133.921252784319, 20.815117390805, 29.1334860523392, 285.257770418471 ),
      ( 271, 0.443844914977552, 1000, 16516.3134147036, 18769.352632356, 135.694138826295, 20.8147550753656, 29.1322878624055, 294.072723698361 ),
      ( 287, 0.419095212763563, 1000, 16849.3723701807, 19235.4650038949, 137.365250687523, 20.8149612581355, 29.1318902308198, 302.629928521281 ),
      ( 303, 0.396960569451644, 999.999999999999, 17182.4355799497, 19701.5774720056, 138.945680352772, 20.8158284988156, 29.1323119015572, 310.950268182075 ),
      ( 319, 0.377047170292497, 1000, 17515.5159114626, 20167.7039632235, 140.444809776364, 20.8175218509471, 29.1336695988312, 319.051689345691 ),
      ( 335, 0.359036537024086, 1000, 17848.6290595638, 20633.8609144847, 141.870650221023, 20.8202672296603, 29.1361570940259, 326.949690520009 ),
      ( 351, 0.34266832307263, 1000, 18181.7945197858, 21100.068350974, 143.230101420393, 20.8243380264837, 29.1400260500907, 334.657716420905 ),
      ( 367, 0.327727621679188, 999.999999999999, 18515.0363006625, 21566.3506661598, 144.529152093744, 20.8300405984224, 29.145567893245, 342.187483267856 ),
      ( 383, 0.314035462401884, 999.999999999999, 18848.3833767452, 22032.7371193179, 145.773036886, 20.8376994100858, 29.1530966598274, 349.549251701558 ),
      ( 399, 0.301441598328296, 999.999999999999, 19181.8698918609, 22499.2620684739, 146.966360489639, 20.8476426611312, 29.1629331481632, 356.75205842459 ),
      ( 415, 0.289818964264454, 999.999999999998, 19515.5351317905, 22965.9649631783, 148.113196757276, 20.8601891475177, 29.175390818232, 363.803914022159 ),
      ( 431, 0.279059370802397, 1000, 19849.4232942462, 23432.8901282917, 149.217168559925, 20.8756369263865, 29.1907638212246, 370.711972121661 ),
      ( 447, 0.269070124088564, 999.999999999998, 20183.5830902285, 23900.0863749665, 150.281512687613, 20.8942541370226, 29.2093173949346, 377.482673652269 ),
      ( 463, 0.259771347054611, 1000, 20518.0672140167, 24367.6064774435, 151.309133035725, 20.9162721189775, 29.2312806929151, 384.121869146836 ),
      ( 479, 0.251093837903865, 999.999999999999, 20852.9317193522, 24835.5065541152, 152.302644548235, 20.9418807902563, 29.2568419638177, 390.634921562561 ),
      ( 159.066, 7.60463446898962, 10000.0000003809, 14165.3053963912, 15480.2929925945, 100.894525527137, 21.073200172769, 29.6700942242439, 224.692483287943 ),
      ( 175, 6.89979380690843, 10000.0000001228, 14502.4152218946, 15951.7338943034, 103.719229902812, 21.0071401311696, 29.5128016649287, 235.847908206842 ),
      ( 191, 6.31464043932014, 10000.0000000442, 14839.3676847986, 16422.9891270862, 106.296108882256, 20.9539842534264, 29.4006889779858, 246.517262980264 ),
      ( 207, 5.8222680407061, 10000.0000000177, 15175.1922048332, 16892.7359403849, 108.657960670467, 20.9141305280192, 29.3224045018274, 256.726413515862 ),
      ( 223, 5.40185605826506, 10000.0000000078, 15510.2180421388, 17361.4336043727, 110.838981771661, 20.8853280657503, 29.2681175295842, 266.532248373012 ),
      ( 239, 5.03849521407877, 10000.0000000037, 15844.6845518505, 17829.4041109882, 112.865653658848, 20.8649253694749, 29.2304801501637, 275.980524082349 ),
      ( 255, 4.72119273130152, 10000.0000000019, 16178.7610063591, 18296.8698337539, 114.758898781849, 20.85065992193, 29.2043101605562, 285.108756462833 ),
      ( 271, 4.44164525860487, 10000.000000001, 16512.5662480984, 18763.9842289981, 116.535552853879, 20.8408451423552, 29.186090933175, 293.948102482314 ),
      ( 287, 4.19345241554506, 10000.0000000006, 16846.1846936121, 19230.8546526489, 118.209385829537, 20.8343264715568, 29.1735072696431, 302.524699797329 ),
      ( 303, 3.97159477591568, 10000.0000000003, 17179.6783153051, 19697.5585534003, 119.791823009043, 20.8303761820819, 29.165084887577, 310.860660150408 ),
      ( 319, 3.77207685159669, 10000.0000000002, 17513.0952765958, 20164.1547309564, 121.292464446393, 20.828589196835, 29.1599309882974, 318.97482376304 ),
      ( 335, 3.59167657658864, 10000.0000000001, 17846.4760460321, 20630.6911018037, 122.719466397143, 20.8287967774427, 29.1575529696229, 326.883344008573 ),
      ( 351, 3.42776558387325, 10000.0000000001, 18179.8576763097, 21097.2100317471, 124.079826574031, 20.8309988475747, 29.1577320915182, 334.600149992097 ),
      ( 367, 3.27817775956299, 10000.0000000001, 18513.2767509918, 21563.7519641886, 125.379601004698, 20.8353114830722, 29.1604343130085, 342.137319976091 ),
      ( 383, 3.14111146440562, 10000, 18846.7713516614, 22030.3578347639, 126.624071334981, 20.841925946457, 29.165746124165, 349.505388224654 ),
      ( 399, 3.01505570023287, 10000, 19180.3822927735, 22497.0706044447, 127.817875609852, 20.8510765190314, 29.1738274879751, 356.713600617037 ),
      ( 415, 2.89873360559076, 10000, 19514.1538022203, 22963.9361418989, 128.965111723882, 20.8630152542835, 29.184876903184, 363.770129492135 ),
      ( 431, 2.79105868884565, 10000, 19848.1337810897, 23431.0036218295, 130.069420144701, 20.8779923884558, 29.1991054189075, 370.682254979178 ),
      ( 447, 2.69110055514885, 10000, 20182.3737469211, 23898.3255647999, 131.134050732404, 20.8962415100066, 29.2167175232915, 377.456518029035 ),
      ( 463, 2.59805779937871, 10000, 20516.928544579, 24365.9576163692, 132.161917228533, 20.917968785929, 29.2378974650327, 384.098849093932 ),
      ( 479, 2.51123637033306, 10000, 20851.8558937482, 24833.9581435152, 133.155642095538, 20.9433456419876, 29.262799935804, 390.614675628821 ),
      ( 159.066, 34377.9120775341, 20654.9999494778, -1707.42116907965, -1706.82034725246, -9.83739166701162, 39.3195454551571, 58.1417732622928, 1239.20744723822 ),
      ( 163.105630907967, 34131.2156774262, 20655.0000027834, -1472.40802414336, -1471.80285964533, -8.37836088532256, 39.0247125833587, 58.2178450103254, 1220.24975144525 ),
      ( 175, 14.3121536138194, 20655.0000022991, 14484.6221625824, 15927.8011948669, 97.5862483265072, 21.2213178786506, 29.9371045474275, 235.327863550513 ),
      ( 225, 11.0758204525093, 20655.00000013, 15544.1699225323, 17409.0430566441, 105.034133695443, 20.9596177274025, 29.4107950619232, 267.477081979079 ),
      ( 275, 9.04779129302854, 20655.0000000162, 16591.7254780861, 18874.6030700937, 110.916589738542, 20.8676355067659, 29.242337269377, 295.974454384501 ),
      ( 325, 7.65082008162377, 20655.0000000033, 17635.3742537447, 20335.0848441968, 115.796304704781, 20.8403154706331, 29.1875286732196, 321.877721304287 ),
      ( 375, 6.62851536889674, 20655.0000000008, 18678.0191961263, 21794.1015841858, 119.972049819233, 20.8438999647778, 29.1789863991341, 345.786369558708 ),
      ( 425, 5.84757370823916, 20655.0000000002, 19721.2975585934, 23253.5317860812, 123.625355167203, 20.8749875008909, 29.2037450989479, 368.069797095323 ),
      ( 475, 5.23141297190444, 20655.0000000001, 20766.7941608489, 24715.0582552588, 126.876478018627, 20.9384492215059, 29.2634588851025, 388.972556116667 ),
      ( 159.066, 34380.0070010078, 99999.9999486789, -1708.06991625813, -1705.1612490218, -9.84147081717848, 39.3206325946505, 58.1379601781252, 1239.47868925104 ),
      ( 175, 33391.7140107687, 100000.00000033, -778.826984911301, -775.832229985929, -4.27382680352965, 38.2114384776648, 58.5690379854035, 1163.92817937278 ),
      ( 186.947281679469, 32618.5145124641, 99999.9999991189, -75.9650298968926, -72.8992863615483, -0.388449885239058, 37.4663281254607, 59.1417442228925, 1105.71536752468 ),
      ( 200, 61.6155617903059, 99999.9999999999, 14928.5888455375, 16551.5554645927, 88.0024706347282, 22.0488234335983, 31.543493461874, 249.223725827371 ),
      ( 250, 48.623708800549, 100000.000024794, 16026.1994185375, 18082.8093006628, 94.8425289848883, 21.2520672127392, 30.0059605629777, 280.692536660963 ),
      ( 300, 40.3233288783149, 100000.000003913, 17088.6893257253, 19568.6433073444, 100.261864680528, 20.9854556703471, 29.5134782693826, 308.387917001243 ),
      ( 350, 34.4858150886499, 100000.000000899, 18139.4646454012, 21039.207619254, 104.795977552957, 20.8987448960017, 29.3382742027591, 333.541671566826 ),
      ( 400, 30.138635013807, 100000.000000257, 19186.4038321087, 22504.4041315399, 108.709053674151, 20.8857557134057, 29.2829964627612, 356.777704938451 ),
      ( 450, 26.770392985448, 100000.000000084, 20233.1084712012, 23968.578475487, 112.158139993653, 20.9193611860014, 29.2930970773443, 378.456906684333 ),
      ( 159.066, 34380.0419751659, 101324.999951742, -1708.08074612569, -1705.1335420465, -9.84153892001693, 39.3206507463385, 58.1378965485239, 1239.48321752344 ),
      ( 175, 33391.7551264972, 101325.000000488, -778.840174537277, -775.805742845483, -4.27390219403192, 38.2114554006376, 58.5689468028657, 1163.93338179706 ),
      ( 187.178727145864, 32603.2579069822, 101324.999999305, -62.2922583950152, -59.1844401429747, -0.3153503587455, 37.45257911678, 59.1550479558274, 1104.57871269207 ),
      ( 200, 62.4528650200637, 101325, 14927.0828318924, 16549.5063983284, 87.8854276938769, 22.0657355521459, 31.5775542128131, 249.177070331897 ),
      ( 250, 49.2750304051702, 101325.00002616, 16025.4823036656, 18081.797625909, 94.7302055103301, 21.2579913149963, 30.0179352675101, 280.668805485062 ),
      ( 300, 40.8607676496367, 101325.000004127, 17088.2679550651, 19568.0304713483, 100.151014082168, 20.9877463913645, 29.5186542997785, 308.374209085294 ),
      ( 350, 34.9444031504481, 101325.000000948, 18139.1758524919, 21038.7818227157, 104.685708482867, 20.8997496020696, 29.3409544761212, 333.533098322901 ),
      ( 400, 30.5389219844946, 101325.000000271, 19186.1850439143, 22504.0821213461, 108.599063360232, 20.886257979159, 29.2846029430028, 356.772093741173 ),
      ( 450, 27.1256816323007, 101325.000000088, 20232.9320713876, 23968.3220746173, 112.048304845133, 20.9196461144335, 29.2941707246681, 378.453159668068 ),
      ( 175, 33399.0868062177, 337828.322754746, -781.191676476783, -771.076779482298, -4.2873475947565, 38.2144753643947, 58.5527113678201, 1164.86103102769 ),
      ( 200, 31742.6989643982, 337828.322754105, 698.220651639028, 708.863361105321, 3.61522088899448, 36.7302161536961, 60.0249079149908, 1041.50065270037 ),
      ( 211.364151184297, 30929.5089710045, 337828.32307928, 1385.92501868436, 1396.8475432998, 6.96068885176816, 36.1486022978102, 61.1056402837452, 982.941132527119 ),
      ( 225, 190.92566112075, 337828.322753196, 15295.2888513589, 17064.7122005835, 80.680074740938, 23.4137304647382, 34.4440377372552, 259.43512881979 ),
      ( 275, 151.742553656482, 337828.322753195, 16461.3980716702, 18687.7236119533, 87.2047417287806, 21.7506235744114, 31.1396604421606, 291.66057371648 ),
      ( 325, 126.951379644286, 337828.322753194, 17552.5744903998, 20213.6587866066, 92.3054524384647, 21.2010359584905, 30.076464538197, 319.290713423688 ),
      ( 375, 109.411310485222, 337828.322753195, 18618.1883642703, 21705.8794014672, 96.5768939024228, 21.0122359731254, 29.6732653623084, 344.131638711281 ),
      ( 425, 96.2329433142134, 337828.322772053, 19674.4399030791, 23184.9666638475, 100.279640869942, 20.9645377692315, 29.5167569187667, 366.975488022337 ),
      ( 475, 85.9328328551291, 337828.322759568, 20728.2237827233, 24659.5304967601, 103.559863301562, 20.9922676703429, 29.4810890403748, 388.241743528578 ),
      ( 175, 33419.5387164863, 1000000.00000054, -787.746532809117, -757.823917524567, -4.32487391580892, 38.2229236462608, 58.5076740378831, 1167.44834544131 ),
      ( 200, 31769.953206806, 1000000.0000018, 689.116310500836, 720.592592303718, 3.56960886562896, 36.7363053711169, 59.9441754599892, 1044.7842896323 ),
      ( 225, 29924.3908877603, 1000000.00005341, 2216.91980226941, 2250.33735799524, 10.7735528566453, 35.5282908840414, 62.7134281331205, 914.479640153883 ),
      ( 239.746277705606, 28696.7117395134, 999999.999999142, 3158.48600876693, 3193.33320690853, 14.8321447593433, 34.9513945972933, 65.3476716016221, 832.870963829263 ),
      ( 250, 545.217243654034, 1000000.00000002, 15475.6713879094, 17309.8026661097, 73.4389052538557, 25.876717277236, 40.8520790649991, 262.604501101124 ),
      ( 300, 426.585031430982, 1000000, 16785.6358124701, 19129.8343340298, 80.0951440198431, 22.6582167442507, 33.5495243147659, 298.658456871568 ),
      ( 350, 356.512581278598, 1000000, 17937.1086373969, 20742.0587359701, 85.0700173057598, 21.6118295375368, 31.3112248919493, 327.643041807755 ),
      ( 400, 307.935231001315, 1000000, 19035.0756600994, 22282.5118068121, 89.1852893334987, 21.2367239242785, 30.4306741425141, 352.984844618687 ),
      ( 450, 271.653816889796, 1000000, 20111.9809653379, 23793.13667833, 92.7442499146257, 21.1165287379973, 30.0465239558838, 375.954768237146 ),
      ( 175, 33649.7096327185, 8702568.94963467, -861.023081780302, -602.400673307186, -4.74921565696463, 38.3203787759618, 58.0253631079943, 1196.53220321706 ),
      ( 191, 32654.6511015992, 8702568.94962883, 63.7708871716018, 330.274085216876, 0.350243300836008, 37.3235831331104, 58.6147449122332, 1123.19424681702 ),
      ( 207, 31606.3169225853, 8702568.94963301, 999.851620402555, 1275.19433024593, 5.10063510519253, 36.4329331283819, 59.5657801275451, 1048.0914348265 ),
      ( 223, 30488.3492552911, 8702568.94965237, 1953.27101565187, 2238.71018052047, 9.58353372393781, 35.6397733908341, 60.9556164573873, 970.994828419555 ),
      ( 239, 29279.5105222748, 8702568.94966641, 2931.57632921814, 3228.80018284253, 13.8705701801766, 34.9414455055808, 62.9160745048226, 891.663180018657 ),
      ( 255, 27950.1711544896, 8702568.9496693, 3944.92393688243, 4256.28406779424, 18.0309149258587, 34.3400024997806, 65.6821434703607, 809.462202035455 ),
      ( 271, 26454.6000042122, 8702568.94966943, 5008.42700625992, 5337.38941537908, 22.1416053204618, 33.8776438986983, 69.7380978811369, 722.580572225949 ),
      ( 287, 24710.1778056471, 8702568.94966225, 6149.0200099335, 6501.20561612826, 26.3123340019247, 33.6634309197178, 76.3656815436733, 627.734982398387 ),
      ( 303, 22520.7473022381, 8702568.94966923, 7429.81108817084, 7816.23560743199, 30.7678871333479, 33.8806277718614, 89.986731323073, 518.024365103295 ),
      ( 319, 19097.5910306285, 8702568.94966933, 9094.68918143964, 9550.37853700874, 36.3345340501602, 35.6294474966062, 142.988327976372, 366.912953888353 ),
      ( 335, 6297.93266115563, 8702568.94966951, 14133.8069320916, 15515.6205236127, 54.5682440161676, 35.6737295661621, 156.288376436147, 239.633180779803 ),
      ( 351, 4782.11904823804, 8702568.94966952, 15413.0208479233, 17232.8352151286, 59.5880141934486, 30.742650482, 81.2929867390455, 271.998302157084 ),
      ( 367, 4095.26703489541, 8702568.9496695, 16230.9041703574, 18355.9350598002, 62.7200988620946, 28.0249382663235, 61.8870633813949, 293.010181811064 ),
      ( 383, 3657.01186719293, 8702568.94967655, 16884.0231346419, 19263.7170666599, 65.1426302300917, 26.2658475952424, 52.5079073371605, 309.615564475262 ),
      ( 399, 3339.07988299532, 8702568.94967104, 17449.8000244652, 20056.0775783476, 67.1701811472082, 25.0589860861219, 46.9620319526902, 323.714166742796 ),
      ( 415, 3091.73055235309, 8702568.9496699, 17961.7252329639, 20776.5141682567, 68.9409908089238, 24.2020845723215, 43.3246087342693, 336.155704024834 ),
      ( 431, 2890.57847561599, 8702568.94966961, 18437.566948941, 21448.2338528434, 70.5294726739939, 23.5795117999157, 40.7809612405246, 347.407308223989 ),
      ( 447, 2721.91555148539, 8702568.94966953, 18887.9056956239, 22085.1279404215, 71.9806225653924, 23.119955935587, 38.9221883976779, 357.757112486469 ),
      ( 463, 2577.29739131932, 8702568.94966951, 19319.5347503097, 22696.1605828508, 73.3238342550476, 22.7771987553186, 37.5194028818343, 367.396404289406 ),
      ( 479, 2451.16638477032, 8702568.94966952, 19737.056362623, 23287.4350736484, 74.5794191006563, 22.5201965314763, 36.4343809795872, 376.458894101874 ),
      ( 175, 33687.1645646445, 9999999.99997034, -872.858616073336, -576.009649138743, -4.81861265702676, 38.3366385343429, 57.9509571131306, 1201.25986904417 ),
      ( 191, 32698.6875299117, 9999999.99996449, 49.4260018822537, 355.248674147519, 0.273120348718344, 37.3380416620581, 58.5103350312103, 1128.59142081625 ),
      ( 207, 31658.8921553258, 9999999.9999692, 982.306653102731, 1298.17367557803, 5.01350367389418, 36.4443184597313, 59.4180303000026, 1054.29953632368 ),
      ( 223, 30552.305778107, 9999999.99998471, 1931.53617507132, 2258.84371357961, 9.48318961453299, 35.6461416622203, 60.7430994693449, 978.192937342593 ),
      ( 239, 29359.1436975068, 9999999.99999645, 2904.17477879242, 3244.78416791591, 13.7522959645434, 34.9399090856343, 62.6017174592674, 900.088577862025 ),
      ( 255, 28052.4060008679, 9999999.99999963, 3909.51300820703, 4265.98867021228, 17.8872690693571, 34.3262357076217, 65.1952870470505, 819.494711208539 ),
      ( 271, 26591.7740718883, 10000000.0000002, 4960.93810474435, 5336.99424800753, 21.9596451893062, 33.8383606323831, 68.9237666425699, 735.001628311168 ),
      ( 287, 24907.9654120493, 10000000.0000004, 6081.17302709827, 6482.65102156998, 26.0654730304192, 33.5535821131938, 74.7881897691723, 644.209337785182 ),
      ( 303, 22850.3156070067, 10000000, 7319.08049274833, 7756.71120962708, 30.3827108569838, 33.5610430093032, 85.8488912959842, 542.533437178294 ),
      ( 319, 19947.7430837314, 9999999.99999987, 8822.4914222678, 9323.8012675984, 35.4162093497994, 34.2229333000656, 116.646358755668, 416.472621480266 ),
      ( 335, 11582.6240774912, 9999999.99999999, 12040.0218662239, 12903.3840830322, 46.2961242624392, 38.9256193214044, 427.569931615171, 228.194040695745 ),
      ( 351, 6290.17261719261, 10000000, 14683.0342757492, 16272.81576643, 56.1756560092709, 32.7176515725213, 112.370241278152, 260.029453706268 ),
      ( 367, 5096.32087530678, 10000000, 15738.7600193222, 17700.9598581222, 60.1605705518373, 29.368095749899, 73.8938520233279, 285.593493662757 ),
      ( 383, 4443.97742356922, 10000000.0000156, 16501.8358553593, 18752.0723095274, 62.9661574850966, 27.235334920001, 59.2497338700958, 304.456107300158 ),
      ( 399, 4003.11600962978, 10000000.0000033, 17133.6672975812, 19631.7213074944, 65.2173029199858, 25.7871520276218, 51.3942013210442, 319.917625965666 ),
      ( 415, 3674.12359083508, 10000000.0000008, 17690.4307182878, 20412.168230043, 67.1357373210404, 24.765780186042, 46.5055608915564, 333.277534294424 ),
      ( 431, 3413.8826227245, 10000000.0000002, 18198.9919186064, 21128.2080355974, 68.8290982857553, 24.0267346679322, 43.1965793643191, 345.191754616618 ),
      ( 447, 3199.9528845422, 10000000.0000001, 18674.3960199073, 21799.442031774, 70.3585358077639, 23.4822563591332, 40.8310838680832, 356.042568938102 ),
      ( 463, 3019.22950607906, 10000000, 19125.9179491406, 22438.021245649, 71.7623321460469, 23.0761156144732, 39.0734629983816, 366.073926367496 ),
      ( 479, 2863.422859446, 9999999.99999999, 19559.6616254846, 23051.9854948047, 73.0661200921609, 22.7708705090471, 37.7293078172861, 375.451461601916 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new (double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 179.7515, 61249.9606657735, 33086.7026866361, 41.9084297841625 ),
      ( 200.437, 194056.932760102, 31706.2590688155, 122.235915691579 ),
      ( 221.1225, 487276.937323025, 30199.4902627443, 290.007993463071 ),
      ( 241.808, 1036079.91261614, 28516.8378115499, 599.563328423671 ),
      ( 262.4935, 1950982.25038917, 26583.3416790166, 1136.75576632125 ),
      ( 283.179, 3358455.52143169, 24260.3515113173, 2068.87442544481 ),
      ( 303.8645, 5409425.60734743, 21179.9679341731, 3824.82382209106 ),
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
