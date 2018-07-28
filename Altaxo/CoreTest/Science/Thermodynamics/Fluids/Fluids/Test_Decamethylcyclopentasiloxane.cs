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
  /// Tests and test data for <see cref="Decamethylcyclopentasiloxane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Decamethylcyclopentasiloxane : FluidTestBase
  {

    public Test_Decamethylcyclopentasiloxane()
    {
      _fluid = Decamethylcyclopentasiloxane.Instance;

      _testDataMolecularWeight = 0.3707697;

      _testDataTriplePointTemperature = 226;

      _testDataTriplePointPressure = 0.005304;

      _testDataTriplePointLiquidMoleDensity = 2829.84826067343;

      _testDataTriplePointVaporMoleDensity = 2.82276629227225E-06;

      _testDataCriticalPointTemperature = 619.23462341;

      _testDataCriticalPointPressure = 1161463.19229172;

      _testDataCriticalPointMoleDensity = 789.09027;

      _testDataNormalBoilingPointTemperature = 484.050286854326;

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
      ( 300, 3.1896194104594E-06, 0.00795600000752305, -52935.3475368285, -50441.006054759, -15.1802373671457, 402.431531033208, 410.746005577126, 82.8641157823847 ),
      ( 350, 2.73395943183596E-06, 0.00795600000393722, -31409.6397333494, -28499.574605355, 52.3557961655435, 457.833529489987, 466.148002793464, 89.3937894348143 ),
      ( 400, 2.39221447718287E-06, 0.00795600000226298, -7225.19450336627, -3899.4057506654, 117.977901242241, 508.84352880608, 517.158001546706, 95.4805046284642 ),
      ( 450, 2.12641285672571E-06, 0.00795600000139136, 19407.7631921884, 23149.2755594726, 181.641092340527, 555.836528469684, 564.151000925553, 101.203518616365 ),
      ( 500, 1.91377156500062E-06, 0.00795600000089798, 48297.7583700033, 52454.9943465424, 243.354304477373, 599.187528290325, 607.502000589348, 106.620985675747 ),
      ( 550, 1.73979232849306E-06, 0.00795600000059978, 79272.0660379676, 83845.0256207306, 303.159753202461, 639.271528188341, 647.586000394855, 111.777040708739 ),
      ( 600, 1.59480963251019E-06, 0.00795600000040984, 112176.711200121, 117165.394387272, 361.121313530669, 676.463528127223, 684.778000276016, 116.706098389957 ),
      ( 650, 1.4721319672798E-06, 0.00795600000028361, 146876.46885867, 152280.875649038, 417.317566470619, 711.138528088951, 719.453000199993, 121.435595556517 ),
      ( 300, 2590.01540137714, 78.4881934648617, -111339.664480841, -111339.6341767, -285.924339098911, 426.445398806636, 513.482448583619, 787.529228000128 ),
      ( 312.61686153067, 2549.73136250229, 78.4882172860541, -104776.787751845, -104776.756968909, -264.497479530064, 440.770124442749, 526.816233154886, 751.825906633913 ),
      ( 325, 0.0290556808744318, 78.4882205933819, -42521.5843858959, -39820.2806053175, -57.653977597865, 430.725656443573, 439.057851721892, 86.1633884130334 ),
      ( 375, 0.0251778213257198, 78.4882205933816, -19637.9780447456, -16520.6225127479, 8.93935812673887, 483.874791582548, 492.198854772109, 92.4708905599281 ),
      ( 425, 0.022214079696668, 78.4882205933815, 5796.41953132339, 9329.68409439031, 73.5855751538152, 532.824736757102, 541.144892895493, 98.3732064133191 ),
      ( 475, 0.019874954612024, 78.4882205933815, 33581.0069613948, 37530.1088398915, 136.271264126555, 577.947459645108, 586.265549122503, 103.940567619448 ),
      ( 525, 0.0179816935099719, 78.4882917730945, 63533.7962701588, 67898.6961462227, 197.024342067674, 619.616759855127, 627.933669606452, 109.224605719768 ),
      ( 575, 0.0164178223068907, 78.4882687428667, 95491.492682875, 100272.167444468, 255.899177901323, 658.207110567203, 666.523303816392, 114.264731985466 ),
      ( 625, 0.015104249315092, 78.4882537434808, 129309.52545039, 134505.960712158, 312.967765468843, 694.093260807452, 702.408995920171, 119.09188673668 ),
      ( 300, 2590.02022664492, 999.999973959155, -111339.79603944, -111339.409942079, -285.924777628867, 426.445553440317, 513.48212801719, 787.536174197978 ),
      ( 325, 2510.13255770767, 999.999999436639, -98173.334929629, -98172.9365442942, -243.783566340891, 454.446521394397, 539.698124559397, 718.351641922045 ),
      ( 350, 2429.67052341888, 999.999999054548, -84361.5651233854, -84361.1535449474, -202.852669444247, 481.006885271245, 565.116025855671, 654.802935455466 ),
      ( 353.45142186411, 2418.48375333762, 999.999999435783, -82405.1563639751, -82404.7428817683, -197.290333323739, 484.570964381165, 568.5655060864, 646.406831162255 ),
      ( 375, 0.321478284709214, 1000.00000000259, -19659.1314753619, -16548.5014652911, -12.2757983574399, 484.000724481531, 492.438391204308, 92.2815747518474 ),
      ( 425, 0.283388418996874, 1000.00000000055, 5782.22214417831, 9310.94785407253, 52.393437072445, 532.895530230422, 541.282774439143, 98.2527268616948 ),
      ( 475, 0.253427496779299, 1000.00000000014, 33570.9126106335, 37516.8143486403, 115.091285361554, 577.989989148566, 586.350693179069, 103.860018892013 ),
      ( 525, 0.229222433370935, 1000.00000000004, 63526.2796296361, 67888.8543798212, 175.851306578686, 619.643713331323, 627.989308404109, 109.168866853226 ),
      ( 575, 0.209250877817281, 1000.00000000001, 95485.6807285351, 100264.633201428, 234.730350420333, 658.224964619899, 666.561398162116, 114.225273543522 ),
      ( 625, 0.192487351189143, 1000, 129304.890016155, 134500.036574213, 291.80162780045, 694.105537072105, 702.436118612238, 119.063594385063 ),
      ( 300, 2590.06734818675, 9999.99996650104, -111341.080783354, -111337.219879901, -285.929060237355, 426.447063632088, 513.478998151836, 787.604009176308 ),
      ( 325, 2510.18841564817, 9999.99999817436, -98174.8216650873, -98170.8379003883, -243.788141061551, 454.447984022366, 539.693901652594, 718.425918806293 ),
      ( 350, 2429.73702720922, 9999.99999817639, -84363.2926395044, -84359.1769677727, -202.857605381604, 481.008305963445, 565.11042776266, 654.884623887011 ),
      ( 375, 2348.12261050606, 9999.99999389783, -69925.7636151462, -69921.5048937535, -163.023534186654, 506.302709671677, 589.784831039634, 595.873960073549 ),
      ( 400, 2264.75284785628, 9999.99998978863, -54879.9529250803, -54875.5374322378, -124.190085510075, 530.461973593206, 613.788163140433, 540.525912193149 ),
      ( 405.093694971363, 2247.49414458083, 10000.0000062188, -51741.2590953678, -51736.8096955639, -116.392871934872, 535.254929415036, 618.605205496716, 529.628744612212 ),
      ( 425, 2.87046813855226, 10000.0000059906, 5641.55430507767, 9125.30661421639, 32.9168289935106, 533.596619264677, 542.674808101625, 97.0512823897683 ),
      ( 475, 2.55469340181089, 10000.000001454, 33471.4204309611, 37385.7844772946, 95.7367169381322, 578.409067778919, 587.200204466715, 103.063006942055 ),
      ( 525, 2.30428862362663, 10000.0000004039, 63452.419410305, 67792.1535468496, 156.565701304507, 619.908519017758, 628.54062283139, 108.61991580931 ),
      ( 575, 2.09992760217351, 10000.0000001231, 95428.678827604, 100190.747762634, 215.486376849382, 658.40004906201, 666.937255258422, 113.837841699148 ),
      ( 625, 1.92955883746504, 10000.0000000397, 129259.48296034, 134442.014742153, 272.584171855053, 694.22577977887, 702.702974996468, 118.786392941997 ),
      ( 300, 2590.53809287025, 99999.9997969779, -111353.915168242, -111315.313149583, -285.971854379005, 426.462160829272, 513.447795636574, 788.281813087641 ),
      ( 325, 2510.74632701901, 99999.9999522593, -98189.671209383, -98149.8424147031, -243.833846942539, 454.462605426034, 539.651814707091, 719.167970053287 ),
      ( 350, 2430.40110755893, 99999.9999317495, -84380.5432463886, -84339.3977747129, -202.906910493906, 481.022508186216, 565.054659975593, 655.700551801235 ),
      ( 375, 2348.91771157009, 99999.9998416956, -69945.9039183842, -69903.3311201337, -163.07726279377, 506.316478571255, 589.71135889792, 596.776365390119 ),
      ( 400, 2265.71229636711, 100000.000004864, -54903.6179679556, -54859.4817375237, -124.249273810419, 530.475197280405, 613.69095219922, 541.531918985074 ),
      ( 425, 2180.14183057461, 100000.000015538, -39269.4458332534, -39223.577257818, -86.3396099165163, 553.603330925981, 637.097448738777, 489.212905801861 ),
      ( 450, 2091.41356409298, 100000.000020997, -23055.8013483751, -23007.9867976148, -49.2715745625154, 575.791020198415, 660.102798778409, 439.070317811207 ),
      ( 475, 1998.42481949022, 100000.000014991, -6269.34508389052, -6219.30567333091, -12.9684594785509, 597.122742652296, 683.012808514586, 390.244183596092 ),
      ( 482.495051773118, 1969.48273276012, 100000.000011928, -1124.93900236485, -1074.16424900015, -2.22129419970841, 603.364203752404, 689.939421479836, 375.701641029861 ),
      ( 500, 26.0561891924875, 100000, 47277.8025024731, 51115.6622624426, 105.374088178841, 603.12620692758, 616.542945228135, 98.4994290759915 ),
      ( 550, 23.0135533198099, 100000, 78518.8622232268, 82864.1277548177, 165.865326175038, 641.762559723549, 653.246283865272, 106.327060749578 ),
      ( 600, 20.7376895493235, 99999.9999999999, 111594.679207297, 116416.817168334, 224.232344836788, 678.119530100412, 688.578698368227, 112.923843446444 ),
      ( 650, 18.9351203160842, 99999.9999999999, 146411.025657074, 151692.217343776, 280.685198708247, 712.284467441295, 722.137016157331, 118.76791009937 ),
      ( 300, 2590.5450168951, 101324.99979311, -111354.103941885, -111314.990551023, -285.972483970679, 426.462383029498, 513.447337568596, 788.291784465439 ),
      ( 325, 2510.7545316587, 101324.999950145, -98189.8895862277, -98149.5331918958, -243.834519274414, 454.462820619403, 539.651197018147, 719.178884969171 ),
      ( 350, 2430.4108713224, 101324.999930295, -84380.7968809083, -84339.1063992182, -202.907635639362, 481.022717210678, 565.053841834183, 655.712551113922 ),
      ( 375, 2348.92939837254, 101324.999836651, -69946.1999634946, -69903.0632902907, -163.078052815981, 506.316681228677, 589.710281638436, 596.789633219977 ),
      ( 400, 2265.72639365986, 101325.000004802, -54903.9657084327, -54859.2449512008, -124.250143852696, 530.475391945104, 613.689527992971, 541.546705209857 ),
      ( 425, 2180.159013911, 101325.0000154, -39269.8577518446, -39223.3817840969, -86.340579993006, 553.603513740082, 637.095538683068, 489.229564086425 ),
      ( 450, 2091.43481465376, 101325.000021082, -23056.2950536938, -23007.8474524054, -49.2726727722251, 575.791183424603, 660.100167080684, 439.089374650474 ),
      ( 475, 1998.45165920751, 101325.000015405, -6269.94713279312, -6219.24538099013, -12.9697283741232, 597.122870956723, 683.009015209683, 390.266478343046 ),
      ( 483.050286854326, 1967.34500367967, 101325.000011731, -742.418360173202, -690.914938138828, -1.42883799896356, 603.82400814754, 690.450487293783, 374.647571624214 ),
      ( 500, 26.4332118560327, 101325, 47263.0319863477, 51096.2778496148, 105.234344534361, 603.182690297144, 616.690822865604, 98.3777742185229 ),
      ( 550, 23.3355572237858, 101325, 78508.3022994792, 82850.3884570243, 165.736389637891, 641.797340380842, 653.332218466328, 106.249266987047 ),
      ( 600, 21.0223974178183, 101325, 111586.669598413, 116406.529007698, 224.109433276026, 678.142265217664, 688.633974251961, 112.871411815612 ),
      ( 650, 19.1920526578094, 101325, 146404.694472974, 151684.223547149, 280.565969271211, 712.300030903585, 722.17501563243, 118.731662990989 ),
      ( 300, 2595.19918761788, 999999.999999541, -111480.972700894, -111095.645823185, -286.396646824545, 426.612663891059, 513.145150861206, 795.00608794274 ),
      ( 325, 2516.25985970088, 1000000.0000003, -98336.4167740798, -97939.0015404564, -244.2868434608, 454.608334484149, 539.24474863502, 726.518024224484 ),
      ( 350, 2436.94826079644, 1000000.00000025, -84550.6455000781, -84140.2962053936, -203.39464666392, 481.164060738589, 564.517563647227, 663.76629279038 ),
      ( 375, 2356.73323342212, 999999.999999872, -70143.9620889311, -69719.6459271278, -163.607477939676, 506.45378321864, 589.00792359606, 605.674088884424 ),
      ( 400, 2275.10722286819, 1000000.00000593, -55135.5339845276, -54695.994260881, -124.831554109158, 530.607283675212, 612.767715694923, 551.417479544959 ),
      ( 425, 2191.5411326862, 1000000.00001976, -39543.0374465977, -39086.7375464475, -86.9864182931194, 553.727860985593, 635.87161016986, 500.303462479398 ),
      ( 450, 2105.42279829912, 1000000.00002736, -23381.8812999701, -22906.9173160923, -50.0000466540964, 575.903353197718, 658.437568808392, 451.682580258107 ),
      ( 475, 2015.95860526411, 1000000.00002294, -6663.78432175439, -6167.74239043114, -13.8038322039256, 597.213909468912, 680.662275052229, 404.868770788242 ),
      ( 500, 1921.99342250307, 1000000.00001206, 10605.8901208024, 11126.183264527, 21.6737925835641, 617.739388899859, 702.895583013003, 359.032282490825 ),
      ( 525, 1821.62997532397, 1000000.00000218, 28433.6836414576, 28982.6425483422, 56.5180320049857, 637.571147543838, 725.827518757553, 312.99839964943 ),
      ( 550, 1711.26614122786, 999999.99999828, 46851.7196281711, 47436.0822681523, 90.8516657338792, 656.841821758767, 751.067253090077, 264.78054325389 ),
      ( 575, 1582.40865305892, 999999.999936596, 65961.7512219384, 66593.699232336, 124.909943325687, 675.831126221386, 783.670042693893, 210.206958480867 ),
      ( 600, 1402.7683423706, 1000000.00000001, 86189.2553853688, 86902.1314674666, 159.472272476034, 695.643089814428, 857.513829490741, 135.694364546762 ),
      ( 608.418851574393, 1295.98056349353, 999999.999999998, 93712.0899785944, 94483.7064890336, 172.01863542782, 703.788732494683, 975.545958868141, 93.4866253901375 ),
      ( 625, 316.311420283766, 1000000, 121249.238843451, 124410.680182189, 220.847209105797, 713.270479801603, 830.686970815702, 68.9625630601686 ),
      ( 300, 2596.32361462044, 1219536.3519055, -111511.617170985, -111041.900551286, -286.499412328928, 426.649247689294, 513.073838868037, 796.631773417233 ),
      ( 319, 2536.49327863217, 1219536.35190585, -101584.506494388, -101103.71028563, -254.385104617793, 448.064203138541, 532.968621361173, 744.120466294618 ),
      ( 338, 2476.54745781643, 1219536.35190554, -91284.6090552629, -90792.1749821518, -222.992005497801, 468.619592243066, 552.376631813819, 695.105666528482 ),
      ( 357, 2416.25045242951, 1219536.35190426, -80621.0857130951, -80116.3630546149, -192.267308218586, 488.400703868119, 571.316518578891, 649.063544514664 ),
      ( 376, 2355.38218331857, 1219536.35190207, -69602.7610724112, -69084.9952675498, -162.165477303843, 507.474324008065, 589.806834781877, 605.580194081025 ),
      ( 395, 2293.72842527844, 1219536.35190069, -58238.0961245204, -57706.4131499971, -132.646732179963, 525.894685301956, 607.869513772546, 564.312548438771 ),
      ( 414, 2231.06996716152, 1219536.35190051, -46535.0965527873, -45988.4815340516, -103.675724341278, 543.707480057593, 625.533438641283, 524.960560966337 ),
      ( 433, 2167.16911377144, 1219536.35190084, -34501.1493579645, -33938.4169232176, -75.220336406296, 560.952660263565, 642.838810586879, 487.245840262296 ),
      ( 452, 2101.75126179252, 1219536.35190238, -22142.7655350228, -21562.5178272792, -47.2505178018848, 577.666502534419, 659.843312360062, 450.893221503416 ),
      ( 471, 2034.47777174512, 1219536.35190358, -9465.18221539092, -8865.74762394906, -19.7370410557702, 593.883307472839, 676.631884974261, 415.611706133302 ),
      ( 490, 1964.90304963213, 1219536.35190456, 3528.27023512552, 4148.93004433742, 7.35001021424161, 609.637123286634, 693.333898703121, 381.06980454695 ),
      ( 509, 1892.40123764937, 1219536.35190495, 16837.2350053936, 17481.673577744, 34.0433804869448, 624.964095784136, 710.156259574354, 346.857088170836 ),
      ( 528, 1816.02964772901, 1219536.35190563, 30466.275999081, 31137.8158902005, 60.3821801010519, 639.906667577577, 727.453668144272, 312.417094676408 ),
      ( 547, 1734.24643405866, 1219536.35190608, 44428.8146172004, 45132.0228394898, 86.4187072339693, 654.522590517606, 745.896662301434, 276.920626671671 ),
      ( 566, 1644.23938782113, 1219536.35190635, 58756.2890533358, 59497.9914848305, 112.234034062439, 668.907411359152, 766.950493514781, 238.997467617107 ),
      ( 585, 1539.94122005746, 1219536.35189797, 73524.7013273579, 74316.6382766477, 137.98304224537, 683.263789314175, 794.691397525556, 196.029516130208 ),
      ( 604, 1403.10873596309, 1219536.35179439, 88971.5244235884, 89840.6918092203, 164.093670628077, 698.226028825808, 847.946915870489, 141.329384957173 ),
      ( 623, 732.778645042818, 1219536.35190631, 111779.159086388, 113443.422039677, 202.425926374072, 723.73960606212, 3484.07093802346, 36.1014591061149 ),
      ( 642, 395.23327537559, 1219536.35190631, 131736.63940987, 134822.2509408, 236.304786668382, 726.430211119124, 869.85458043166, 67.6680548330131 ),
      ( 661, 330.340646254847, 1219536.35190631, 147007.465650539, 150699.21949837, 260.680129958668, 735.098838236542, 814.606465460643, 81.6001646069824 ),
      ( 300, 2637.78443571496, 10000000.0000002, -112639.124635404, -108848.064280129, -290.368219677837, 428.073766055435, 510.870631961453, 857.566058870225 ),
      ( 319, 2583.01830862775, 9999999.99999871, -102828.091711718, -98956.6518668677, -258.404934117449, 449.451045339916, 530.238728207707, 808.670613559786 ),
      ( 338, 2528.7742427141, 10000000.0000005, -92656.9389751781, -88702.4539005169, -227.186263033119, 469.973826521899, 549.06011040563, 763.52812829235 ),
      ( 357, 2474.91383795892, 9999999.99999907, -82136.3310373488, -78095.786333681, -196.660427925481, 489.72550267993, 567.341609144628, 721.647148799367 ),
      ( 376, 2421.33166295461, 9999999.99999847, -71276.8261322342, -67146.8673360088, -166.78344322872, 508.770925023146, 585.087090992193, 682.654841994643 ),
      ( 395, 2367.95041927295, 9999999.99999864, -60088.9148261212, -55865.8534315042, -137.517672522191, 527.162206500132, 602.299446281239, 646.260622774315 ),
      ( 414, 2314.71717890787, 9999999.99999911, -48583.0267151801, -44262.8444954597, -108.830647036701, 544.942572861669, 618.981932806422, 612.231847165573 ),
      ( 433, 2261.60029538469, 9999999.99999878, -36769.5151478446, -32347.8673348309, -80.6940987920562, 562.148959057199, 635.139114550613, 580.377215593945 ),
      ( 452, 2208.58672522023, 9999999.99999898, -24658.6266071322, -20130.8442539163, -53.0831675095003, 578.813783085248, 650.777517076607, 550.535324292526 ),
      ( 471, 2155.67959895538, 9999999.99999988, -12260.459685214, -7621.55137766879, -25.9757486861437, 594.966171350615, 665.906056249913, 522.566780515089 ),
      ( 490, 2102.8959597645, 9999999.99999991, 415.082220241507, 5170.42922329524, 0.648042265854672, 610.632813546923, 680.536264491585, 496.348842859003 ),
      ( 509, 2050.26464717617, 10000000.0000002, 13358.3407521038, 18235.7598763974, 26.806308854677, 625.838565438912, 694.682325842453, 471.771868701362 ),
      ( 528, 1997.82434719299, 9999999.99999989, 26559.9515121746, 31565.3965674669, 52.5157298124629, 640.606879608464, 708.360928328477, 448.737064729826 ),
      ( 547, 1945.62186238387, 9999999.99999986, 40010.8888619841, 45150.633739104, 77.7918440936558, 654.96011803148, 721.590943999509, 427.155203669609 ),
      ( 566, 1893.71067951617, 10000000.0010929, 53702.5038031639, 58983.1414999676, 102.649273559907, 668.919780736342, 734.39295394088, 406.94609929763 ),
      ( 585, 1842.14992446493, 10000000.0004017, 67626.5527719314, 73054.9925897743, 127.101891089968, 682.506669232921, 746.788653011583, 388.038690864914 ),
      ( 604, 1791.00378123283, 10000000.0001635, 81775.2162584292, 87358.6773906441, 151.16294168536, 695.74099217437, 758.800201144939, 370.371538543447 ),
      ( 623, 1740.34139136423, 10000000.0000729, 96141.107857723, 101887.106918421, 174.845125220273, 708.642416098331, 770.449627604417, 353.893377175016 ),
      ( 642, 1690.2371344747, 10000000.0000349, 110717.276419001, 116633.606025109, 198.160651249047, 721.230068376918, 781.758417622279, 338.563205963991 ),
      ( 661, 1640.7710371935, 10000000.0000171, 125497.205776483, 131591.9013637, 221.121277755326, 733.522512078927, 792.747386622076, 324.349354041825 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new(double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 324.3086558525, 165.485397516361, 2512.34152887457, 0.0614149739782977 ),
      ( 373.46298377875, 2572.41050066599, 2353.11975247338, 0.833558572365257 ),
      ( 422.617311705, 17938.6335549219, 2187.37328013093, 5.24277801834694 ),
      ( 471.77163963125, 75046.6035070168, 2010.23392631749, 20.6435075194307 ),
      ( 520.9259675575, 225011.65613379, 1813.97454600981, 61.7642961528028 ),
      ( 570.08029548375, 542655.652257692, 1578.0210390525, 164.532641738686 ),
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
