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
	/// Tests and test data for <see cref="Tetradecamethylhexasiloxane"/>.
	/// </summary>
	/// <remarks>
	/// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
	/// </remarks>
  [TestFixture]
  public class Test_Tetradecamethylhexasiloxane : FluidTestBase
    {

    public Test_Tetradecamethylhexasiloxane()
      {
      _fluid = Tetradecamethylhexasiloxane.Instance;

    _testDataMolecularWeight = 0.45899328;

    _testDataTriplePointTemperature = 214.15;

    _testDataTriplePointPressure = 1.033E-06;

    _testDataTriplePointLiquidMoleDensity = double.NaN;

    _testDataTriplePointVaporMoleDensity = double.NaN;

    _testDataCriticalPointTemperature = 653.2;

    _testDataCriticalPointPressure = 877473.909155454;

    _testDataCriticalPointMoleDensity = 622.35694;

    _testDataNormalBoilingPointTemperature = 532.723355998617;

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
      ( 300, 0.000381694222301849, 0.952066644696176, -117029.783119505, -114535.46544565, -207.110637179227, 529.866533624347, 538.181514119667, 74.2936641810914 ),
      ( 350, 0.00032716496622838, 0.952066558535037, -88681.2505204286, -85771.2000663393, -118.575245749053, 603.214151231485, 611.528883772439, 80.1712623671461 ),
      ( 400, 0.00028626872707269, 0.952066518209985, -56792.5919610137, -53466.8129702536, -32.4037226606469, 671.507489762387, 679.82210966585, 85.6475808486261 ),
      ( 450, 0.000254460803793962, 0.952066497159477, -21611.1559072642, -17869.6504063605, 51.3777577267152, 734.961097504699, 743.275660383112, 90.7950996907249 ),
      ( 500, 0.000229014576786387, 0.952066485207184, 16626.4372204652, 20783.6681643069, 132.774007629026, 793.789586567933, 802.104118030712, 95.6668165225068 ),
      ( 550, 0.000208194988931885, 0.952066477955558, 57694.2977483803, 62267.253528152, 211.808971334681, 848.207591087955, 856.522104028283, 100.3028714373 ),
      ( 600, 0.000190845359081206, 0.952066473315137, 101377.267734727, 106365.947982959, 288.519046801013, 898.429753785126, 906.74425517868, 104.734529343232 ),
      ( 650, 0.000176164917578374, 0.952066470213878, 147470.921371709, 152875.325854175, 362.949088413131, 944.670721062507, 952.985214914541, 108.986704287449 ),
      ( 325, 1866.45206855359, 1000.00000092841, -174338.538014684, -174338.002238803, -409.964926970984, 647.366578497016, 725.943242659989, 748.95358755526 ),
      ( 350, 1818.47071481834, 1000.00075232214, -155860.484431969, -155859.934518933, -355.202163354558, 674.861687706501, 752.426387278747, 692.789029536184 ),
      ( 375, 1770.02384880759, 1000.00012162266, -136712.501979239, -136711.937015032, -302.369883326576, 702.406995991325, 779.483632728402, 639.001245383516 ),
      ( 392.995941066741, 1734.62739563741, 1000.00004281222, -122508.06774139, -122507.491248683, -265.375774635819, 722.132518282703, 799.164825964424, 601.436431907634 ),
      ( 400, 0.301617793610367, 1000.00000000608, -56823.7297240249, -53508.275459752, -90.3243543358251, 671.677778172593, 680.149394379933, 85.3910080467857 ),
      ( 450, 0.267791203880475, 1000.00000000147, -21632.6545427374, -17898.4019402964, -6.51277990539339, 735.060461451827, 743.47106787032, 90.6247162778701 ),
      ( 500, 0.240852471863489, 1000.00000000042, 16610.8178214008, 20762.7370118636, 74.9000146128467, 793.85112458282, 802.228344785065, 95.5482063419806 ),
      ( 550, 0.218868946577197, 1000.00000000014, 57682.4731020761, 62251.4172836913, 153.944721199196, 848.247594476662, 856.605205437069, 100.217348181642 ),
      ( 600, 0.200578407062403, 1000.00000000005, 101368.008709787, 106353.590231974, 230.66086578913, 898.456828738481, 906.80224391838, 104.671229424042 ),
      ( 650, 0.185117580277815, 1000.00000000002, 147463.465614541, 152865.43769358, 305.094869379131, 944.689683889659, 953.027145652897, 108.93894983644 ),
      ( 300, 1914.40473147399, 9999.99767144214, -192167.113886711, -192161.890332095, -467.033435428664, 620.254845702322, 700.433650066302, 808.219608385075 ),
      ( 325, 1866.49126377861, 10000.0000004296, -174340.145993214, -174334.78834692, -409.969874787625, 647.368947085298, 725.939857865408, 749.029114487495 ),
      ( 350, 1818.51625858385, 10000.0007494562, -155862.318698537, -155856.819709621, -355.207404332593, 674.864002143678, 752.421796029784, 692.872648257931 ),
      ( 375, 1770.07713138712, 10000.000121416, -136714.60514771, -136708.955676315, -302.375492025248, 702.409253351304, 779.477474138364, 639.094369164126 ),
      ( 400, 1720.75371154942, 10000.0000313623, -116886.18273287, -116880.371325947, -251.196691228794, 729.771638991892, 806.845743408964, 587.133311484789 ),
      ( 425, 1670.07389147503, 10000.0000170078, -96371.3284337183, -96365.3406746928, -201.456484036104, 756.786722737508, 834.376674790299, 536.483002559719 ),
      ( 448.211932031853, 1621.3081706617, 10000.0000231132, -76706.3616372006, -76700.1937783049, -156.410969219185, 781.458344598376, 860.040753147793, 490.201185221934 ),
      ( 450, 2.72653819126584, 10000.000016663, -21830.3148804789, -18162.6603988007, -26.0983619234433, 735.975415948792, 745.317633816932, 89.0463210436723 ),
      ( 500, 2.43694149891901, 10000.0000045456, 16468.2387688447, 20571.7431036765, 55.4694531802049, 794.413101082225, 803.382609307959, 94.4612948383013 ),
      ( 550, 2.20626649287265, 10000.000001425, 57574.9870995978, 62107.5311207893, 134.604250352128, 848.611294745791, 857.369915827513, 99.438805979291 ),
      ( 600, 2.01712609282295, 10000.0000004948, 101284.067426846, 106241.615711048, 211.376075791814, 898.70232764128, 907.332641478471, 104.097522154875 ),
      ( 650, 1.85873135299764, 10000.0000001852, 147395.991926381, 152776.005549144, 285.846245461301, 944.861328340454, 953.40912535189, 108.507497166979 ),
      ( 300, 1914.74341212523, 99999.997831859, -192181.249444855, -192129.023127115, -467.080570889898, 620.279114361371, 700.409464353122, 808.904312250827 ),
      ( 325, 1866.88276413814, 99999.999999686, -174356.205862106, -174302.640634593, -410.019308776089, 647.392622638266, 725.906142266045, 749.783572350298 ),
      ( 350, 1818.97106906656, 100000.000721488, -155880.634926142, -155825.658790225, -355.259758008998, 674.887136469559, 752.376078316512, 693.707757819248 ),
      ( 375, 1770.6090728065, 100000.000113813, -136735.6012046, -136679.12346389, -302.43150639118, 702.431818203987, 779.416180966158, 640.024155276261 ),
      ( 400, 1721.38143231774, 100000.000029016, -116910.411720505, -116852.318843382, -251.257292819272, 729.79349923517, 806.763586667222, 588.176153415158 ),
      ( 425, 1670.82330691553, 100000.000014994, -96399.533968383, -96339.683235154, -201.522884730202, 756.807581370737, 834.265557273293, 537.663568884789 ),
      ( 450, 1618.37556488929, 100000.000020393, -75200.0115684097, -75138.2212138159, -153.056721776848, 783.359710889936, 861.869512249769, 488.006299813026 ),
      ( 475, 1563.31557268014, 100000.000089355, -53308.8694579577, -53244.9028463299, -105.715048810005, 809.374797920143, 889.635119751167, 438.704009985318 ),
      ( 500, 1504.63658715273, 100000.00106605, -30719.8166063738, -30653.3553745256, -59.3694221777269, 834.812247301118, 917.782919169663, 389.17957888512 ),
      ( 525, 1440.8105794604, 99999.9998833944, -7417.85519333044, -7348.44981741985, -13.8931728862655, 859.669216379396, 946.827517020721, 338.678018945377 ),
      ( 531.130700423411, 1424.11343588375, 99999.999999816, -1591.42714180119, -1521.20801635789, -2.85805471665372, 865.680673185873, 954.19791224901, 326.026291826601 ),
      ( 550, 24.1705258233315, 100000, 56384.2871079568, 60521.5574648752, 113.261515667715, 852.695114376979, 867.264238825501, 90.6584338911355 ),
      ( 600, 21.4403402765235, 100000, 100385.814957357, 105049.920037326, 190.721736452831, 901.342230533018, 913.610675308247, 97.9710676778994 ),
      ( 650, 19.3965796910069, 99999.9999999998, 146688.735301999, 151844.283424041, 265.609138079512, 946.66544818774, 957.706339322808, 104.059402187354 ),
      ( 300, 1914.7483937895, 101324.997834189, -192181.457345851, -192128.539167064, -467.081264349149, 620.279471512788, 700.409109523081, 808.914384237906 ),
      ( 325, 1866.88852176801, 101325.000000676, -174356.442029065, -174302.167229676, -410.020035955329, 647.392971054793, 725.905647689317, 749.794668648456 ),
      ( 350, 1818.97775638934, 101325.000722045, -155880.904223428, -155825.199858509, -355.260528011114, 674.887476921815, 752.375407885735, 693.720037887383 ),
      ( 375, 1770.61689218859, 101325.000114966, -136735.909830603, -136678.684012549, -302.43233006337, 702.432150289813, 779.415282552587, 640.037824135607 ),
      ( 400, 1721.39065652997, 101325.000027547, -116910.767762379, -116851.905470055, -251.258183707351, 729.793820992072, 806.762383244598, 588.191479414641 ),
      ( 425, 1670.8343145158, 101325.000014324, -96399.9482839786, -96339.3049280611, -201.523860524342, 756.807888480432, 834.26393113432, 537.680911631759 ),
      ( 450, 1618.38890073824, 101325.000020597, -75200.4992604866, -75137.8906996058, -153.057806675993, 783.359995092331, 861.867275267544, 488.026156194811 ),
      ( 475, 1563.33205828526, 101325.000089149, -53309.4524982839, -53244.6390125295, -105.716277692813, 809.375043708776, 889.631952929864, 438.727094814908 ),
      ( 500, 1504.65753931706, 101325.00106139, -30720.5289032779, -30653.1879978468, -59.3708486347254, 834.812424421151, 917.778236768635, 389.206978320577 ),
      ( 525, 1440.8382954484, 101324.999895383, -7418.75352680127, -7348.42988242322, -13.8948865575004, 859.669260493624, 946.820115506875, 338.71151791048 ),
      ( 531.723355998617, 1422.50348013537, 101325.000000001, -1026.74757039044, -955.517516183217, -1.79533197087734, 866.260143505967, 954.909145019443, 324.831433006402 ),
      ( 550, 24.5283593756759, 101325, 56364.8265488435, 60495.7591745487, 113.115669260418, 852.763393499751, 867.453029622416, 90.5122360053776 ),
      ( 600, 21.7455003000136, 101325, 100371.692314018, 105031.276991402, 190.588391586783, 901.384043394096, 913.719380263575, 97.8748524436633 ),
      ( 650, 19.666461654408, 101325, 146677.851205175, 151830.023557302, 265.482830216813, 946.69330191598, 957.776971389549, 103.991963227018 ),
      ( 300, 1917.80695937504, 921347.604613081, -192308.993887053, -191828.576606206, -467.507802198352, 620.499747819549, 700.19623629513, 815.101874886194 ),
      ( 319, 1881.77365618191, 921347.604613895, -178833.162542591, -178343.545950507, -423.929774027548, 641.051991029486, 719.404217021502, 770.329209500489 ),
      ( 338, 1845.81585735549, 921347.604613828, -164986.471726191, -164487.317056486, -381.743238678764, 661.878477608026, 739.230174921163, 727.464823364934 ),
      ( 357, 1809.76917286155, 921347.604612381, -150759.299304314, -150250.20255406, -340.76795821961, 682.815034594359, 759.467875573463, 686.21338019282 ),
      ( 376, 1773.47185752476, 921347.605532316, -136145.428278613, -135625.911940295, -300.861043910171, 703.736054585847, 779.963636481197, 646.321235715119 ),
      ( 395, 1736.75851803539, 921347.604841735, -121141.169565925, -120610.671171776, -261.907295578193, 724.544906889346, 800.604684567275, 607.566197551435 ),
      ( 414, 1699.45343454841, 921347.604695135, -105744.66653664, -105202.52305335, -223.812261124186, 745.167153542222, 821.311557592391, 569.749201471192 ),
      ( 433, 1661.36278937642, 921347.604661542, -89955.314866214, -89400.7414698715, -186.497124398279, 765.545710064369, 842.033612958651, 532.68728479861 ),
      ( 452, 1622.264870017, 921347.604664431, -73773.2439392638, -73205.304867357, -149.89482625664, 785.637406711639, 862.747260110197, 496.207324346855 ),
      ( 471, 1581.89686106674, 921347.604719737, -57198.8089225487, -56616.376763161, -113.947000552649, 805.410619377607, 883.457061890445, 460.140023375127 ),
      ( 490, 1539.93598330001, 921347.605035804, -40232.0346629845, -39633.7321263677, -78.6014042275103, 824.843805140358, 904.200549537295, 424.313552424362 ),
      ( 509, 1495.9710896516, 921347.604613292, -22871.9280803887, -22256.0421110763, -43.8095535200546, 843.924945227631, 925.058813392345, 388.545986983136 ),
      ( 528, 1449.45748965788, 921347.604613341, -5115.51939136139, -4479.86942495168, -9.52423636769951, 862.652140636961, 946.17748428997, 352.63500716016 ),
      ( 547, 1399.64048413548, 921347.60461324, 13043.6360207733, 13701.9104955806, 24.3036018581668, 881.036084466172, 967.808873272048, 316.341560377527 ),
      ( 566, 1345.41546082377, 921347.604613278, 31618.0796395248, 32302.8849145059, 57.7295871665807, 899.10630756923, 990.403054194626, 279.359271180467 ),
      ( 585, 1285.04340438823, 921347.604613307, 50631.6677769958, 51348.6455860465, 90.8246617547978, 916.92650902797, 1014.83130155036, 241.246195515792 ),
      ( 604, 1215.47510454682, 921347.604613281, 70131.8729524928, 70889.8873298887, 123.69510963213, 934.636396320184, 1043.05371603248, 201.241378199706 ),
      ( 623, 1130.28295431413, 921347.604605449, 90227.4078434478, 91042.5555912651, 156.543423936907, 952.595009600906, 1080.87813716607, 157.645678216842 ),
      ( 642, 1009.14452635582, 921347.604613222, 111279.140123581, 112192.138787846, 189.978297183696, 972.182521665495, 1160.52203661968, 104.686073644787 ),
      ( 661, 379.597038817911, 921347.604613227, 144063.087284973, 146490.260077159, 242.491866357802, 994.125218251611, 1512.07499589223, 44.6531950630977 ),
      ( 300, 1918.09778513959, 999999.999999718, -192321.109495439, -191799.759641564, -467.548440726333, 620.520796345675, 700.176508088702, 815.690601189805 ),
      ( 319, 1882.09744484043, 1000000.00000102, -178846.478862479, -178315.156744837, -423.97179329296, 641.072635698091, 719.378775147811, 770.961308530007 ),
      ( 338, 1846.17715158188, 999999.999999167, -165001.132895699, -164459.473066824, -381.786916256322, 661.898756990602, 739.198040784795, 728.144902952932 ),
      ( 357, 1810.17348019992, 1000000.00000028, -150775.475701699, -150223.042462046, -340.81360235649, 682.834961301323, 759.427780226291, 686.946927856656 ),
      ( 376, 1773.92592490804, 1000000.00087635, -136163.323433954, -135599.602036777, -300.909006164817, 703.755611746222, 779.913923223865, 647.114828819456 ),
      ( 395, 1737.27071038681, 1000000.00021491, -121161.02952024, -120585.413990526, -261.9579867957, 724.564041387599, 800.543166426455, 608.427784649274 ),
      ( 414, 1700.03426722559, 1000000.00007419, -105766.792764585, -105178.569327356, -223.866172614838, 745.185764623466, 821.235304841699, 570.688484332602 ),
      ( 433, 1662.02569400341, 1000000.00004179, -89980.0825181648, -89378.4071026464, -186.554857144653, 765.563630782761, 841.938628646637, 533.71624662822 ),
      ( 452, 1623.02732493966, 1000000.00004383, -73801.1282516774, -73184.9956797375, -149.957132655559, 785.654373640178, 862.627969956154, 497.340976160288 ),
      ( 471, 1582.78211106775, 1000000.00008727, -57230.4245899019, -56598.6256877696, -114.014846221962, 805.426222045475, 883.305484126998, 461.397486196797 ),
      ( 490, 1540.97574995873, 1000000.00033433, -40268.1965841564, -39619.2571051535, -78.6760630662866, 824.857398624541, 904.004886977612, 425.719675649309 ),
      ( 509, 1497.21002718805, 999999.999999932, -22913.7490101632, -22245.8400449273, -43.8927603777168, 843.935491934436, 924.800943390717, 390.133861967603 ),
      ( 528, 1450.96089685062, 999999.999999749, -5164.57499126536, -4475.37654203747, -9.61844522905406, 862.657906891369, 945.828198848402, 354.450063050426 ),
      ( 547, 1401.50854009577, 1000000.0000002, 12985.010019709, 13698.5268991222, 24.1947522125235, 881.034015058838, 967.318112478428, 318.448673010961 ),
      ( 566, 1347.81180520023, 1000000.00000011, 31546.2061907654, 32288.1495363733, 57.6003596445357, 899.090611603215, 989.677653032203, 281.856214059876 ),
      ( 585, 1288.25954201619, 999999.999999968, 50540.2532218619, 51316.4943187723, 90.6652079220146, 916.885043838687, 1013.6762607474, 244.292401972984 ),
      ( 604, 1220.10272379953, 1000000.00000004, 70008.6843987521, 70828.2875194516, 123.486193577793, 934.539647634953, 1040.97878908998, 205.131530818491 ),
      ( 623, 1137.82847875295, 999999.999961669, 90042.7242362842, 90921.5913226992, 156.237939609378, 952.351523017493, 1076.17165662011, 163.05904939963 ),
      ( 642, 1026.07554393068, 1000000.00000002, 110911.643844249, 111886.230955223, 189.381442670396, 971.31152744685, 1140.09230199262, 114.139564143258 ),
      ( 661, 690.398801089923, 1000000, 136214.389341435, 137662.827546168, 228.890665402292, 1004.21923200606, 2722.53159090849, 34.5814597330403 ),
      ( 300, 1948.83072705334, 10000000.0000015, -193589.050617495, -188457.768633287, -471.921825126944, 622.84309511467, 698.551841172233, 878.332361692544 ),
      ( 319, 1915.98388697268, 10000000.0000002, -180227.715503445, -175008.464930414, -428.459116712395, 643.346384931125, 717.279183820372, 837.612078169001 ),
      ( 338, 1883.57421980037, 10000000.000001, -166506.685607623, -161197.63014547, -386.410655666793, 664.129575446058, 736.566040728616, 799.120546650829 ),
      ( 357, 1851.49797594678, 10000000.0005109, -152417.849708531, -147016.817608889, -345.597283291908, 685.026279238595, 756.192069592812, 762.607563378082 ),
      ( 376, 1819.6667725105, 10000000.0000351, -137956.784804335, -132461.273125437, -305.877828678679, 705.908663609381, 775.986421292529, 727.870878412682 ),
      ( 395, 1788.00482247331, 10000000.0000028, -123121.948711086, -117529.122632368, -267.139498573339, 726.677707279085, 795.814995395074, 694.747278163283 ),
      ( 414, 1756.44697544639, 10000000.0000007, -107914.076838704, -102220.765204598, -229.291036155431, 747.256242364843, 815.571330686384, 663.105821365911 ),
      ( 433, 1724.93738579497, 9999999.99910374, -92335.7260618873, -86538.4141817839, -192.257766836323, 767.583896792856, 835.169968646482, 632.842698301374 ),
      ( 452, 1693.42868699181, 9999999.99994066, -76390.9263954976, -70485.747112333, -155.97795525001, 787.613357507096, 854.541534422952, 603.877303635396 ),
      ( 471, 1661.8815915538, 9999999.99999781, -60084.9128153011, -54067.6369450942, -120.400089268697, 807.307566673603, 873.629036923151, 576.149196590694 ),
      ( 490, 1630.26486048366, 9999999.99999965, -43423.9172600236, -37289.9446507919, -85.4808295733971, 826.637586457645, 892.385057481223, 549.615676618059 ),
      ( 509, 1598.55559655577, 9999999.99999984, -26415.005908521, -20159.3586094557, -51.1834432862801, 845.580949029282, 910.769610199889, 524.249733353345 ),
      ( 528, 1566.73981393416, 9999999.99999964, -9065.95012359958, -2683.26940593201, -17.4765932188719, 864.120362997953, 928.74853674644, 500.038145083096 ),
      ( 547, 1534.81322104342, 9999999.99989751, 8614.8785005129, 15130.3292816178, 15.6666101091638, 882.242685140818, 946.292355343207, 476.979506837683 ),
      ( 566, 1502.78212471612, 9999999.99999789, 26618.5973302452, 33272.9218896932, 48.2693622810707, 899.938093201209, 963.37552260949, 455.081979990209 ),
      ( 585, 1470.66432307682, 9999999.99991784, 44935.8937160708, 51735.5419043103, 80.3517763867391, 917.199415546248, 979.976087576826, 434.360584977559 ),
      ( 604, 1438.48980889901, 10000000.0000002, 63557.1047553883, 70508.8397889885, 111.93139157297, 934.021588896538, 996.075716038646, 414.833925715373 ),
      ( 623, 1406.30106687864, 10000000.0000003, 82472.3016560841, 89583.1545420852, 143.023608697783, 950.401227248405, 1011.6600365532, 396.520353043806 ),
      ( 642, 1374.15273731415, 10000000.0000002, 101671.382715281, 108948.594140516, 173.642074554312, 966.336293548721, 1026.71920778503, 379.433746901042 ),
      ( 661, 1342.11045669546, 9999999.99999973, 121144.176050585, 128595.127609834, 203.799027892954, 981.825869965009, 1041.24854234541, 363.579297446357 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new (double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 323.9125, 10.3019159346454, 1868.53063519175, 0.00382550149449333 ),
      ( 378.79375, 449.236249629636, 1762.60215035935, 0.142886780384395 ),
      ( 433.675, 5671.88831573037, 1652.03229701837, 1.59352640519746 ),
      ( 488.55625, 33924.3386719477, 1531.09178095952, 8.78883381382126 ),
      ( 543.4375, 127771.071325318, 1389.73813307526, 32.5964668975362 ),
      ( 598.31875, 361532.518747276, 1202.90169610245, 102.359095444888 ),
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