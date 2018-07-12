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
	/// Tests and test data for <see cref="Neon"/>.
	/// </summary>
	/// <remarks>
	/// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
	/// </remarks>
  [TestFixture]
  public class Test_Neon : FluidTestBase
    {

    public Test_Neon()
      {
      _fluid = Neon.Instance;

    _testDataMolecularWeight = 0.020179;

    _testDataTriplePointTemperature = 24.556;

    _testDataTriplePointPressure = 43368;

    _testDataTriplePointLiquidMoleDensity = 62065.0134179135;

    _testDataTriplePointVaporMoleDensity = 219.817931603622;

    _testDataCriticalPointTemperature = 44.4918;

    _testDataCriticalPointPressure = 2678644.86195707;

    _testDataCriticalPointMoleDensity = 23882;

    _testDataNormalBoilingPointTemperature = 27.1044323270234;

    _testDataNormalSublimationPointTemperature = null;

    _testDataIsMeltingCurveImplemented = true;

    _testDataIsSublimationCurveImplemented = true;

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
      ( 24.556, 4.90099762390103, 1000.00000000005, 1509.19774245565, 1713.23783321662, 101.095593010012, 12.4903947196905, 20.8239136821578, 129.797209312732 ),
      ( 25, 4.8138082481493, 1000.00000000004, 1514.74619246839, 1722.48192859466, 101.468679920008, 12.4848085474911, 20.8167689088294, 130.97631720777 ),
      ( 59, 2.0386536330374, 999.999999999999, 1938.93597230924, 2429.45578587369, 119.324335036249, 12.4717925294503, 20.7880407759474, 201.28396530803 ),
      ( 93, 1.29328156645375, 999.999999999997, 2362.99192821788, 3136.21875363537, 128.783800008342, 12.4715981281155, 20.7866192526375, 252.715921820446 ),
      ( 127, 0.947039172290793, 1000, 2787.03371400492, 3842.95624525682, 135.260586406605, 12.4715636930687, 20.7862379603421, 295.320761159249 ),
      ( 161, 0.747041119345006, 1000, 3211.07092741295, 4549.68532775116, 140.191420951093, 12.4715498476961, 20.786080561857, 332.510170822527 ),
      ( 195, 0.616787273977182, 1000, 3635.10604428305, 5256.4105721015, 144.173925900358, 12.4715418867453, 20.7860006110722, 365.939232291591 ),
      ( 229, 0.525211813348892, 999.999999999999, 4059.14001525371, 5963.13374613293, 147.514698836075, 12.4715365341029, 20.7859546534519, 396.560148704534 ),
      ( 263, 0.457313784421928, 999.999999999999, 4483.17328909014, 6669.85568105884, 150.392138620754, 12.4715326381885, 20.7859259525819, 424.980396566635 ),
      ( 297, 0.404961472539447, 1000, 4907.20610670291, 7376.57681925283, 152.91925093513, 12.4715296643859, 20.785906925267, 451.615651956114 ),
      ( 331, 0.36336432822043, 1000, 5331.23860941576, 8083.29741743768, 155.172156417056, 12.471527319493, 20.7858937275664, 476.765183511136 ),
      ( 365, 0.329516787655218, 1000, 5755.27088573172, 8790.01763449624, 157.2045793864, 12.4715254252389, 20.7858842429169, 500.65294627534 ),
      ( 399, 0.301437745321193, 1000, 6179.30299393927, 9496.73757378747, 159.055854373785, 12.4715238655903, 20.7858772291146, 523.451714974767 ),
      ( 433, 0.277768338956075, 1000, 6603.33497400009, 10203.4573052861, 160.755646512991, 12.4715225612845, 20.7858719190929, 545.298100507834 ),
      ( 467, 0.257545418311767, 999.999931782313, 7027.36685422522, 10910.1768779383, 162.326882774539, 12.4715214561692, 20.7858678190931, 566.302335928759 ),
      ( 501, 0.240067337639537, 999.9999359894, 7451.39865522759, 11616.8963269305, 163.78764780135, 12.4715205093051, 20.7858646000919, 586.554900024191 ),
      ( 535, 0.224810765642221, 999.99993981424, 7875.43039236769, 12323.6156781458, 165.152460976588, 12.4715196901291, 20.7858620363095, 606.13114450373 ),
      ( 569, 0.21137747092184, 999.999943292603, 8299.46207732173, 13030.3349510083, 166.433154484727, 12.4715189753698, 20.7858599688676, 625.094614419701 ),
      ( 603, 0.199459038777464, 999.999946459963, 8723.49371912017, 13737.0541603477, 167.639498428803, 12.471518347003, 20.7858582834949, 643.499486422339 ),
      ( 637, 0.188812901266712, 999.999949349483, 9147.52532485391, 14443.7733176588, 168.779653801931, 12.4715177908603, 20.7858568964145, 661.392395442309 ),
      ( 671, 0.179245654711437, 999.999951991266, 9571.55690016609, 15150.492431971, 169.860507528442, 12.4715172956575, 20.7858557451571, 678.813827449654 ),
      ( 24.556, 49.3009107025399, 10000.0000007444, 1506.32908411684, 1709.16509380193, 81.8328901795709, 13.6786373133588, 22.3278057235865, 127.652404661998 ),
      ( 25, 48.4045200950376, 10000.0000005484, 1512.34017550411, 1718.93245202941, 82.227111401865, 13.159855686021, 21.7301045027978, 129.610508200376 ),
      ( 59, 20.3963595465723, 10000.0000000003, 1938.42918117296, 2428.71275247237, 100.171269786964, 12.4743373815019, 20.8077838407461, 201.261999828823 ),
      ( 93, 12.9338380522955, 9999.99999999997, 2362.70687770945, 3135.87258146783, 109.636259782009, 12.4723910592021, 20.7935434448261, 252.730000584484 ),
      ( 127, 9.47028248176584, 10000, 2786.84268952797, 3842.77740100612, 116.114607016893, 12.4720468336489, 20.7897293689381, 295.3432513578 ),
      ( 161, 7.47012684441069, 10000, 3210.93276291931, 4549.59811737474, 121.046087482282, 12.4719084258685, 20.7881553851438, 332.534644297279 ),
      ( 195, 6.16759102052651, 10000, 3635.00186950191, 5256.38045422304, 125.028916347065, 12.4718288350466, 20.7873559513953, 365.963668961529 ),
      ( 229, 5.25187307692962, 10000, 4059.05951739355, 5963.14209012896, 128.369871984422, 12.4717753182891, 20.7868964307734, 396.5838404828 ),
      ( 263, 4.57293133153828, 10000, 4483.1101944028, 6669.89133651894, 131.247423379996, 12.4717363650136, 20.7866094580951, 425.003105177822 ),
      ( 297, 4.04944156441047, 10000, 4907.15630954871, 7376.63261657522, 133.774607928689, 12.4717066308988, 20.7864192078849, 451.637325075343 ),
      ( 331, 3.63349750551767, 10000, 5331.19927596796, 8083.36849716996, 136.027562244436, 12.4716831847287, 20.786287245641, 476.785845387523 ),
      ( 365, 3.29504427272819, 10000, 5755.23997861235, 8790.10056691039, 138.06001936826, 12.4716642442094, 20.7861924088107, 500.67265179045 ),
      ( 399, 3.01427180025373, 10000, 6179.27900031074, 9496.82985924729, 139.91131889792, 12.4716486492437, 20.7861222772306, 523.470529317431 ),
      ( 433, 2.77759234787378, 9999.99999999999, 6603.31674064089, 10203.5570738398, 141.611129061962, 12.4716356073549, 20.7860691813807, 545.316089995267 ),
      ( 467, 2.57537530046952, 10000, 7027.35348268495, 10910.2827000992, 143.182378232744, 12.4716245571225, 20.7860281843979, 566.319563937175 ),
      ( 501, 2.40060438156711, 10000, 7451.38943255541, 11617.0070898355, 144.643153518799, 12.4716150892053, 20.7859959964732, 586.571425339268 ),
      ( 535, 2.24804690684019, 9999.99999999999, 7875.42474384209, 12323.7305018637, 146.007974576346, 12.4716068980272, 20.7859703601167, 606.147020833914 ),
      ( 569, 2.11372089070508, 9999.99999999998, 8299.45953329717, 13030.4531304056, 147.28867420034, 12.4715997509063, 20.7859496867369, 625.109890460514 ),
      ( 603, 1.99454244021749, 10000, 8723.49389121811, 13737.1751237466, 148.495022927196, 12.4715934676257, 20.7859328337507, 643.514206169266 ),
      ( 637, 1.88808607382213, 9999.99999999999, 9147.52788850884, 14443.8965968255, 149.635182063523, 12.4715879065192, 20.7859189634744, 661.406598600028 ),
      ( 671, 1.79241791002633, 9999.99999999998, 9571.56158159657, 15150.6176399313, 150.716038764222, 12.4715829547588, 20.7859074512776, 678.82754986182 ),
      ( 24.7101452737803, 61921.0725477602, 65052.0000007418, -93.7065267268582, -92.6559635288359, -3.55878443519629, 18.5939743285833, 42.0307724424663, 666.345286301251 ),
      ( 50, 157.386739703464, 65052.000002504, 1822.16734906992, 2235.49314846744, 81.079311606974, 12.5043885109573, 21.0040811550375, 184.952751180255 ),
      ( 100, 78.2687638148711, 65052.0000000006, 2448.44434495821, 3279.58050744913, 95.5598685189169, 12.4765261311339, 20.8284905241065, 262.174753831878 ),
      ( 150, 52.1481694059683, 65051.9999999999, 3072.79731934323, 4320.24283355825, 103.999250215005, 12.4743299240098, 20.8033645572278, 321.122348106812 ),
      ( 200, 39.1073291309603, 65051.9999999996, 3696.75135055497, 5360.17356438495, 109.98269517168, 12.473523574932, 20.7950990372748, 370.774404873827 ),
      ( 250, 31.2859100477688, 65051.9999999996, 4320.55083764249, 6399.82549836596, 114.622542886831, 12.4730701982498, 20.7914073911626, 414.508481734605 ),
      ( 300, 26.0722261704798, 65051.9999999997, 4944.27371669824, 7439.34259093402, 118.413075743704, 12.4727737234358, 20.7894626609348, 454.044393311103 ),
      ( 350, 22.3482498704986, 65051.9999999997, 5567.9529902215, 8478.78495142457, 121.617692919837, 12.4725643288203, 20.7883249774828, 490.400921496759 ),
      ( 400, 19.5552370068384, 65051.9999999999, 6191.6051024047, 9518.18201769605, 124.393536736, 12.4724089662734, 20.7876091204513, 524.240977161963 ),
      ( 450, 17.3828434050555, 65051.9999999998, 6815.23917884566, 10557.5498287294, 126.84193520336, 12.4722895255515, 20.7871338501094, 556.024698838689 ),
      ( 500, 15.644881934999, 65052, 7438.86069099312, 11596.8978222592, 129.032060317985, 12.4721951568184, 20.7868050472458, 586.086980567305 ),
      ( 550, 14.2228751653399, 65052.0000000001, 8062.47311716791, 12636.2318856149, 131.013242824754, 12.4721189468211, 20.7865700513769, 614.680583908768 ),
      ( 600, 13.037839198511, 65051.9999999998, 8686.0787727074, 13675.5558639289, 132.82190314325, 12.4720562820946, 20.7863976243944, 642.001854088166 ),
      ( 650, 12.0350926823686, 65051.9999999999, 9309.67925717172, 14714.8723634368, 134.485697347217, 12.4720039691773, 20.7862683410212, 668.206922705727 ),
      ( 700, 11.175577012802, 65052, 9933.2757100691, 15754.1832055372, 136.026121771259, 12.4719597302901, 20.7861696427471, 693.422375723571 ),
      ( 25, 61657.5851928465, 99999.999998018, -81.9871881876929, -80.3653277193459, -3.08702540408345, 18.4717501917407, 40.4388533667701, 652.081068542021 ),
      ( 26.0608346211275, 60715.6987858216, 99999.9999990674, -40.8579031452024, -39.2108826546399, -1.47444292851909, 18.1910071022353, 37.7825372716674, 616.020620123483 ),
      ( 50, 242.697583251651, 99999.9999999998, 1819.68658282218, 2231.72200015186, 77.454574473493, 12.5224924360384, 21.1243325633733, 184.766530030744 ),
      ( 100, 120.340239606619, 100000.000000003, 2447.4345064113, 3278.41174500493, 91.9747522615263, 12.4792136606027, 20.8514126102981, 262.240859794066 ),
      ( 150, 80.1536224164561, 99999.9999999991, 3072.20545625677, 4319.80970651045, 100.420280469468, 12.4758425051964, 20.8127640006605, 321.216392232545 ),
      ( 200, 60.1062609768075, 99999.9999999974, 3696.36272950452, 5360.08292062709, 106.40572622263, 12.4746041455919, 20.8000620839464, 370.869053994249 ),
      ( 250, 48.0851233939814, 99999.9999999974, 4320.28245600166, 6399.92773798744, 111.046442917606, 12.4739076569348, 20.7943899012652, 414.59820130138 ),
      ( 300, 40.0724362078581, 99999.9999999979, 4944.08445262887, 7439.565373262, 114.837418203097, 12.4734521442354, 20.7914018167398, 454.128213136648 ),
      ( 350, 34.3492851145435, 99999.9999999985, 5567.8194398821, 8479.08818001837, 118.042284601277, 12.4731303987682, 20.7896536753175, 490.479055946872 ),
      ( 400, 30.0568492307941, 99999.9999999989, 6191.51268749139, 9518.54138674527, 120.818278917207, 12.4728916627062, 20.7885536404849, 524.313942558215 ),
      ( 450, 26.7181691911164, 99999.9999999993, 6815.17821832077, 10557.9496367026, 123.266772939318, 12.472708117205, 20.7878232673623, 556.093050157497 ),
      ( 500, 24.0471150824321, 99999.9999999995, 7438.82444012837, 11597.3274313273, 125.456961014153, 12.472563094617, 20.7873179534833, 586.151231577657 ),
      ( 550, 21.8616167047666, 99999.9999999995, 8062.45669802187, 12636.683817199, 127.43818616757, 12.4724459740632, 20.7869567891146, 614.741187183102 ),
      ( 600, 20.0402964145623, 99999.9999999998, 8686.07855005596, 13676.0247031146, 129.24687596749, 12.4723496674845, 20.7866917764708, 642.059201118135 ),
      ( 650, 18.4991230791784, 99999.9999999995, 9309.69245439618, 14715.3540942473, 130.9106908461, 12.4722692682784, 20.7864930669399, 668.261350298358 ),
      ( 700, 17.1780732899991, 99999.9999999999, 9933.30016226, 15754.6747897754, 132.451129898731, 12.4722012766102, 20.7863413624269, 693.474173713726 ),
      ( 25, 61657.9232551317, 101324.999999112, -81.9952232671447, -80.3518821578465, -3.08734716531578, 18.4726387492602, 40.4394844604855, 652.081160918359 ),
      ( 26.1044323270234, 60678.2762399033, 101324.999997049, -39.2207392365261, -37.5508664867394, -1.41163534989861, 18.1828252269264, 37.7411245344816, 614.923133293927 ),
      ( 50, 245.942576042898, 101325, 1819.59225545608, 2231.57866964378, 77.3432419663951, 12.5231850028586, 21.1289341932202, 184.759468129785 ),
      ( 100, 121.935629729782, 101325.000000003, 2447.39622083599, 3278.36744905326, 91.8649282747738, 12.4793154542424, 20.8522818583218, 262.243372618807 ),
      ( 150, 81.2152656837158, 101324.999999999, 3072.18302155878, 4319.7932971269, 100.310689490217, 12.4758998198648, 20.8131202289294, 321.219959712919 ),
      ( 200, 60.9022552639999, 101324.999999997, 3696.34799880281, 5360.0794905312, 106.296211068797, 12.4746450974971, 20.8002501699564, 370.872643147294 ),
      ( 250, 48.7219220428693, 101324.999999997, 4320.2722827054, 6399.93161779574, 110.936960696385, 12.4739393978829, 20.7945029359395, 414.601603149692 ),
      ( 300, 40.6031417926235, 101324.999999998, 4944.07727814084, 7439.57382167201, 114.727952750027, 12.4734778587698, 20.7914753137367, 454.131391158486 ),
      ( 350, 34.8042151648436, 101324.999999998, 5567.81437719015, 8479.09967755079, 117.932828594362, 12.4731518556498, 20.7897040379431, 490.482018360994 ),
      ( 400, 30.4549456882541, 101324.999999999, 6191.50918406888, 9518.55501226348, 120.708828614934, 12.4729099598747, 20.7885894431476, 524.316708975005 ),
      ( 450, 27.0720585732715, 101324.999999999, 6815.17590724062, 10557.9647951177, 123.157326259186, 12.4727239847983, 20.7878494013248, 556.095641631909 ),
      ( 500, 24.3656358685923, 101324.999999999, 7438.82306574614, 11597.343719443, 125.347516720718, 12.4725770423518, 20.7873373971219, 586.153667593962 ),
      ( 550, 22.1511971362383, 101325, 8062.4560754437, 12636.7009515473, 127.328743490842, 12.4724583711747, 20.7869714503515, 614.74348490191 ),
      ( 600, 20.3057579734516, 101325, 8686.07854148782, 13676.0424784399, 129.13743440842, 12.4723607894413, 20.7867029281191, 642.061375382798 ),
      ( 650, 18.7441748635893, 101325, 9309.69295458672, 14715.3723583157, 130.80125007084, 12.4722793256321, 20.7865015868007, 668.263413878337 ),
      ( 700, 17.4056298067862, 101325, 9933.30108914342, 15754.693427414, 132.341689678081, 12.4722104336026, 20.7863478728797, 693.476137597381 ),
      ( 25, 61718.8500542935, 340833.493620301, -83.4421043039075, -77.9197477901281, -3.1453638882888, 18.6321711659977, 40.5550026521612, 652.140002993049 ),
      ( 30.8207644027057, 56407.3980162123, 340833.493620144, 142.357791377594, 148.400145848938, 4.98296823791121, 17.2032399243151, 41.6458998668632, 535.988758954859 ),
      ( 50, 845.681415738313, 340833.493620205, 1802.19935713328, 2205.22759835654, 66.9077562817087, 12.6562216233785, 22.015522280978, 183.481178843153 ),
      ( 100, 410.690756887427, 340833.493620571, 2440.4769060087, 3270.37991187059, 81.710101185821, 12.4975971409891, 21.0096264091954, 262.705508305718 ),
      ( 150, 272.94892197267, 340833.493620064, 3068.13359272201, 4316.84156034018, 90.1979448143251, 12.4862212926005, 20.8773455744324, 321.867166033202 ),
      ( 200, 204.609178386175, 340833.493619832, 3693.68919369062, 5359.46731913009, 96.1971342936693, 12.4820281593751, 20.8341519506729, 371.522239337268 ),
      ( 250, 163.689007458539, 340833.493619843, 4318.43572956208, 6400.637209745, 100.843820677329, 12.4796649451193, 20.8148838867673, 415.216849197888 ),
      ( 300, 136.424992687281, 340833.493619918, 4942.78181565091, 7441.10332482768, 104.637836715257, 12.4781179641083, 20.8047328808403, 454.706000710014 ),
      ( 350, 116.952928726558, 340833.49361999, 5566.90003912889, 8481.17929088561, 107.844416787891, 12.4770246839393, 20.798792092827, 491.017587338575 ),
      ( 400, 102.348024780078, 340833.493620047, 6190.87632022614, 9521.01868840978, 110.621446388904, 12.4762131495662, 20.7950522995232, 524.81682426273 ),
      ( 450, 90.9872733570752, 340833.493620087, 6814.75832907886, 10560.7052186235, 113.070597968422, 12.4755890305597, 20.792568299632, 556.564125935645 ),
      ( 500, 81.8973947277646, 340833.493620116, 7438.57464869087, 11600.288153169, 115.261219437398, 12.4750957765581, 20.790849136372, 586.594049597264 ),
      ( 550, 74.4591720523286, 340833.493620137, 8062.34345288272, 12639.7982408651, 117.242738233986, 12.474697337532, 20.7896200219771, 615.158869042702 ),
      ( 600, 68.2598224494292, 340833.493620152, 8686.0768415589, 13679.255572322, 119.051631077173, 12.474369646381, 20.7887178915714, 642.454445441632 ),
      ( 650, 63.0135676979819, 340833.493620164, 9309.78317584609, 14718.6737699122, 120.715588376867, 12.4740960380047, 20.7880413061625, 668.636478018379 ),
      ( 700, 58.516266872416, 340833.493620172, 9933.46841342043, 15758.0623569011, 122.256128222349, 12.4738646221803, 20.7875246618827, 693.831181752032 ),
      ( 36.5380140592183, 49922.132277627, 1000000.00000182, 393.140070495782, 413.171266167486, 12.4762049672319, 16.426182203641, 51.1160966031967, 420.408125401848 ),
      ( 50, 2651.1663659492, 1000000, 1750.24355422667, 2127.43602801621, 56.9017424381024, 13.1186800975349, 25.1794917300584, 179.953276790837 ),
      ( 100, 1208.95876107904, 1000000.00001603, 2421.45126104016, 3248.609334756, 72.5720666334083, 12.5467350210545, 21.4444739912413, 264.061577307761 ),
      ( 150, 798.837886394719, 999999.999987277, 3057.05036092776, 4308.86880496831, 81.1752684311505, 12.514237733408, 21.0523202529123, 323.672919134549 ),
      ( 200, 598.282308617178, 999999.999971008, 3686.41234832516, 5357.86407866686, 87.2116697035618, 12.5021506856154, 20.9264456176414, 373.318581949975 ),
      ( 250, 478.648076199831, 999999.99997254, 4313.40580785339, 6402.62343912837, 91.8745268781646, 12.4953008769338, 20.8704436561604, 416.913509615592 ),
      ( 300, 399.025377551831, 999999.999978482, 4939.23099764219, 7445.33726615537, 95.6767924471807, 12.4908060162859, 20.8409317564784, 456.288964586955 ),
      ( 350, 342.169937431199, 999999.999983965, 5564.39190186651, 8486.91632786182, 98.8880289870052, 12.4876248090255, 20.8236428682364, 492.492397561406 ),
      ( 400, 299.520678945449, 999999.99998815, 6189.13892558392, 9527.80657120007, 101.667875614258, 12.4852609303783, 20.8127471247583, 526.193793269389 ),
      ( 450, 266.337098392221, 999999.999991185, 6813.61092948193, 10568.251218153, 104.118818553111, 12.48344143886, 20.8055024215271, 557.85395132349 ),
      ( 500, 239.779264937546, 999999.999993363, 7437.89118543464, 11608.3935858562, 106.310621913156, 12.4820024586052, 20.8004836382725, 587.806514015502 ),
      ( 550, 218.041135968899, 999999.999994935, 8062.0326610913, 12648.3232046224, 108.292942207187, 12.4808394026186, 20.7968924635519, 616.302543172659 ),
      ( 600, 199.918913361199, 999999.999996081, 8686.07063950321, 13688.0986276674, 110.102389695941, 12.4798823829642, 20.794254727065, 643.536723305121 ),
      ( 650, 184.579147684516, 999999.999996932, 9310.02951455462, 14727.7595915519, 111.766736324054, 12.4790829669625, 20.7922751907771, 669.663711952431 ),
      ( 700, 171.426400078183, 999999.999997563, 9933.92667711042, 15767.3338975939, 113.307551890144, 12.4784065740299, 20.7907627512133, 694.808834232622 ),
      ( 59, 6773.5043130004, 2812577.10505501, 1758.66185324176, 2173.89405434287, 50.2274623956582, 13.5280061390846, 30.3233734260749, 197.550418189714 ),
      ( 93, 3714.74974783851, 2812577.10505493, 2273.7837285151, 3030.92143521835, 61.8102068884457, 12.7021184412117, 23.007040078603, 258.534178132312 ),
      ( 127, 2649.60841578064, 2812577.10505493, 2728.25005403475, 3789.75676132918, 68.7736020246171, 12.6146631092847, 21.8497497546523, 302.921843107128 ),
      ( 161, 2074.85916204419, 2812577.10505492, 3168.68285202433, 4524.23370410429, 73.9000670943805, 12.5793564465253, 21.4119033349551, 340.415998827893 ),
      ( 195, 1709.73326261381, 2812577.10505493, 3603.13387503448, 5248.17241207219, 77.9802330634438, 12.5584752274446, 21.1947920720828, 373.701310423152 ),
      ( 229, 1455.70254605453, 2812577.10505493, 4034.40027501999, 5966.51004062973, 81.3761749588664, 12.5442150388657, 21.0707957257683, 404.028622023066 ),
      ( 263, 1268.20857092362, 2812577.10505493, 4463.74985303015, 6681.50580385657, 84.2874251762485, 12.5337457289761, 20.9933732397868, 432.111858871829 ),
      ( 297, 1123.90685960447, 2812577.10505492, 4891.85016966718, 7394.35033773692, 86.8364969153698, 12.5257099374257, 20.9419304626907, 458.408364593422 ),
      ( 331, 1009.30632396027, 2812577.10505492, 5319.08909524563, 8105.7327913032, 89.1042985776237, 12.5193477534641, 20.906136624131, 483.234008882306 ),
      ( 365, 916.038039703249, 2812577.10505493, 5745.70842058896, 8816.07993700117, 91.1471725892208, 12.5141914694909, 20.8803261458348, 506.818819332574 ),
      ( 399, 838.623255043454, 2812577.10505493, 6171.86709699239, 9525.66999732955, 93.0059785895745, 12.5099343293864, 20.8611761795473, 529.337028355838 ),
      ( 433, 773.319589531684, 2812577.10505492, 6597.67406706704, 10234.6918578076, 94.7113158710904, 12.5063656811843, 20.8466326042382, 550.924673787532 ),
      ( 467, 717.48107527348, 2812577.10505493, 7023.20655735656, 10943.2780435388, 96.2867069261984, 12.5033356925453, 20.8353705013236, 571.690568264202 ),
      ( 501, 669.182709846263, 2812577.10505493, 7448.52085822137, 11651.5241093082, 97.7506310980447, 12.500734757009, 20.8265047707598, 591.723478490988 ),
      ( 535, 626.98984159332, 2812577.10505493, 7873.6589732697, 12359.5005586892, 99.117874548026, 12.4984808179046, 20.8194264110806, 611.097013602628 ),
      ( 569, 589.810980485277, 2812577.10505493, 8298.6528798263, 13067.2604475268, 100.400455663457, 12.4965112322596, 20.813705692084, 629.873064158449 ),
      ( 603, 556.800747590752, 2812577.10505493, 8723.52734795817, 13774.8443895117, 101.60827701158, 12.4947773681188, 20.8090326977814, 648.104288745471 ),
      ( 637, 527.294066749154, 2812577.10505493, 9148.30185796307, 14482.2839419923, 102.749595593069, 12.4932409139223, 20.8051796203596, 665.835954402998 ),
      ( 671, 500.760440240376, 2812577.10505493, 9572.99193630115, 15189.6039508301, 103.831369068819, 12.4918712959743, 20.8019761687662, 683.107326462079 ),
      ( 59, 30103.1589114048, 10000000, 1206.85056328843, 1539.04161438145, 31.7523327778679, 15.1193868968118, 52.8859055822801, 281.513177549939 ),
      ( 93, 13309.9514019225, 9999999.99999996, 2055.26125498723, 2806.5787991336, 49.1607476742816, 13.1784103349665, 28.2384215101091, 288.09076061132 ),
      ( 127, 9143.71862676526, 10000000, 2588.63694113415, 3682.28389246621, 57.2180293728157, 12.9270227619368, 24.1596095449045, 327.737450433587 ),
      ( 161, 7098.43883669222, 10000000, 3068.10033177168, 4476.86079728551, 62.7682213149764, 12.8237322451765, 22.7703636784054, 363.046472031763 ),
      ( 195, 5842.6811268869, 10000000, 3526.86270075155, 5238.40570349765, 67.0616965249668, 12.7596067200406, 22.0954511991735, 394.753644721324 ),
      ( 229, 4981.1849266923, 10000000, 3974.98723861443, 5982.54169546942, 70.5801530085735, 12.714620807126, 21.7093188745333, 423.769285520239 ),
      ( 263, 4348.88106903083, 10000000, 4416.79041875323, 6716.23246862022, 73.5677846257304, 12.6810766845499, 21.4661276367855, 450.710303673728 ),
      ( 297, 3863.02433963906, 9999999.99999999, 4854.48746381208, 7443.13281543167, 76.1672550794272, 12.6550556976175, 21.3028095413977, 475.993507494224 ),
      ( 331, 3477.03032038178, 10000000, 5289.35005154671, 8165.3675373252, 78.4697292485935, 12.6342840140791, 21.187931414233, 499.911607866783 ),
      ( 365, 3162.45943075509, 10000000, 5722.16707379183, 8884.26297382123, 80.5372329533514, 12.617333050051, 21.1042310755902, 522.678465945673 ),
      ( 399, 2900.87550969855, 10000000, 6153.45671975514, 9600.69186189303, 82.4139822387476, 12.6032537384106, 21.0415304700156, 544.455801395149 ),
      ( 433, 2679.75981724813, 10000000, 6583.57469109359, 10315.2524092367, 84.1326597416992, 12.5913884011686, 20.9934919080279, 565.369485474543 ),
      ( 467, 2490.29133797933, 10000000, 7012.77386227535, 11028.3682818882, 85.7181340446321, 12.5812658470904, 20.9559941586456, 585.51987562087 ),
      ( 501, 2326.06366294868, 10000000, 7441.23922383913, 11740.3476959277, 87.1897835036853, 12.5725392177624, 20.9262608108174, 604.98861840586 ),
      ( 535, 2182.3051424691, 10000000, 7869.10937026958, 12451.4199763317, 88.5630116472129, 12.5649473529258, 20.9023655125296, 623.843279801464 ),
      ( 569, 2055.384898092, 9999999.99999998, 8296.4902543326, 13161.7590462182, 89.8502710042732, 12.5582898182016, 20.8829379248799, 642.140591093764 ),
      ( 603, 1942.4888440202, 10000000, 8723.46429227767, 13871.4990059823, 91.0617757618683, 12.552410229704, 20.8669821036917, 659.928784227743 ),
      ( 637, 1841.40081654298, 10000000, 9150.09656641148, 14580.7447502077, 92.2060106342939, 12.5471848075862, 20.8537605845268, 677.249310890288 ),
      ( 671, 1750.35087836258, 9999999.99999999, 9576.43915595524, 15289.5793746495, 93.2901023235426, 12.5425143304472, 20.8427182807631, 694.138133755268 ),
      ( 59, 61569.0973631174, 100000000.000018, 537.494442793537, 2161.6858680835, 12.6077296203364, 17.928311738389, 30.1213008106378, 846.582423136804 ),
      ( 93, 52224.5416004236, 100000000.000001, 1260.47708080259, 3175.28565423371, 26.1891428048247, 16.4866894653652, 29.1939597793065, 741.378001127527 ),
      ( 127, 44977.7869793012, 99999999.9999971, 1912.06646616897, 4135.38616942643, 35.0033722190071, 15.4621730774765, 27.2954465867687, 694.950844996538 ),
      ( 161, 39468.650579867, 99999999.9999995, 2503.08179941845, 5036.73822118144, 41.2990184900408, 14.7854682218053, 25.8185545953276, 677.36916469731 ),
      ( 195, 35182.3730320059, 99999999.9999999, 3054.09631200085, 5896.42874674107, 46.1465751912599, 14.3566070558985, 24.8137175169345, 673.39983966703 ),
      ( 229, 31759.522867001, 100000000, 3578.67345452049, 6727.33536668991, 50.0759141510613, 14.0716781427511, 24.0997601845462, 676.581251965465 ),
      ( 263, 28965.8446579484, 100000000, 4084.83264269459, 7537.1745709511, 53.3740589657228, 13.8701717388719, 23.5607315271394, 683.852664454363 ),
      ( 297, 26643.6928299288, 100000000, 4577.51220058015, 8330.74568207677, 56.2122551043878, 13.719287020292, 23.1355575853646, 693.558186238631 ),
      ( 331, 24683.0630218412, 99999999.9999997, 5059.93834097856, 9111.29938606089, 58.7008653468802, 13.6009171334596, 22.7908155985447, 704.72862021611 ),
      ( 365, 23005.0461162859, 100000000, 5534.3290608276, 9881.20145980129, 60.9152165923257, 13.5046335485836, 22.5063146661811, 716.77455692695 ),
      ( 399, 21551.7913500383, 99999999.9999998, 6002.27248694774, 10642.258016495, 62.9089851154683, 13.4241259471254, 22.2686340193489, 729.329974241939 ),
      ( 433, 20280.0820019118, 99999999.9999999, 6464.94336768228, 11395.8898988932, 64.7217213486886, 13.3553812251756, 22.0682079273563, 742.164220843978 ),
      ( 467, 19157.0778783577, 99999999.9999998, 6923.23411858956, 12143.2369099846, 66.3833643006023, 13.2957246768085, 21.8979025449079, 755.130225682899 ),
      ( 501, 18157.4270519142, 100000000, 7377.8379059156, 12885.2261341094, 67.9170907234482, 13.2432962913227, 21.7522417216426, 768.133332387322 ),
      ( 535, 17261.2702839593, 100000000, 7829.30336056506, 13622.619747768, 69.3411869353543, 13.1967532927058, 21.6269394754798, 781.112243408994 ),
      ( 569, 16452.8396229397, 99999999.9999999, 8278.07177287044, 14356.0499390572, 70.6703193931546, 13.1550944443062, 21.5185935433717, 794.027195394393 ),
      ( 603, 15719.4590682074, 100000000, 8724.50307459173, 15086.0451331381, 71.9164210358869, 13.1175522779366, 21.4244727576411, 806.852512431798 ),
      ( 637, 15050.8214014204, 99999999.9998616, 9168.89442311689, 15813.0500696934, 73.0893242186912, 13.0835245817145, 21.3423638646141, 819.571846454535 ),
      ( 671, 14438.4574486096, 99999999.9999032, 9611.49377452262, 16537.4413943311, 74.1972219834949, 13.0525293697239, 21.2704583462706, 832.175090769471 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new (double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 27.047975, 99611.6895824193, 59861.2749962954, 467.280988836633 ),
      ( 29.53995, 198805.026868815, 57625.392859915, 882.696807323988 ),
      ( 32.031925, 356926.982462716, 55128.4594125008, 1530.50739637798 ),
      ( 34.5239, 590713.914563188, 52323.7483419478, 2499.00355432316 ),
      ( 37.015875, 917846.791969919, 49139.7513965055, 3930.32690044154 ),
      ( 39.50785, 1358055.99005409, 45337.2826974479, 6106.89057526154 ),
      ( 41.999825, 1935412.57688496, 40021.9301356079, 9808.7772377321 ),
      };

      // TestData contains:
		   // 0. Temperature (Kelvin)
		   // 1. Pressure (Pa
		   _testDataMeltingLine = new (double temperature, double pressure)[]
      {
      ( 24.556, 43368.1400994478 ),
      ( 24.5805906452515, 63095.7344480193 ),
      ( 24.6103401251243, 100000 ),
      ( 24.6486340154146, 158489.319246111 ),
      ( 24.7004283767662, 251188.643150958 ),
      ( 24.7719008996867, 398107.170553497 ),
      ( 24.8715295439727, 630957.344480193 ),
      ( 25.0111883895083, 999999.999999999 ),
      ( 25.2076058387598, 1584893.19246111 ),
      ( 25.4843968522104, 2511886.43150958 ),
      ( 25.8749243191067, 3981071.70553497 ),
      ( 26.4263389913232, 6309573.44480193 ),
      ( 27.2052883044138, 10000000 ),
      ( 28.3059858570362, 15848931.9246111 ),
      ( 29.8616189231927, 25118864.3150958 ),
      ( 32.0604754573482, 39810717.0553497 ),
      ( 35.1687436394083, 63095734.4480193 ),
      ( 39.5627444992121, 100000000 ),
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

    [Test]
    public override void MeltingPressure_TestMonotony()
    {
      base.MeltingPressure_TestMonotony();
    }

    [Test]
    public override void MeltingPressure_TestDerivative()
    {
      base.MeltingPressure_TestDerivative();
    }

    [Test]
    public override void MeltingPressure_TestData()
    {
      base.MeltingPressure_TestData();
    }

    [Test]
    public override void MeltingTemperature_TestData()
    {
      base.MeltingTemperature_TestData();
    }
  }
}
