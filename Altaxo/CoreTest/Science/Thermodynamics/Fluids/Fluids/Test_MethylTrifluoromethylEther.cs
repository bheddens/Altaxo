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
  /// Tests and test data for <see cref="MethylTrifluoromethylEther"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_MethylTrifluoromethylEther : FluidTestBase
  {

    public Test_MethylTrifluoromethylEther()
    {
      _fluid = MethylTrifluoromethylEther.Instance;

      _testDataMolecularWeight = 0.1000398;

      _testDataTriplePointTemperature = 240;

      _testDataTriplePointPressure = 65350;

      _testDataTriplePointLiquidMoleDensity = 12615.4015268133;

      _testDataTriplePointVaporMoleDensity = 34.015411047301;

      _testDataCriticalPointTemperature = 377.921;

      _testDataCriticalPointPressure = 3644938.93617025;

      _testDataCriticalPointMoleDensity = 4648.140744;

      _testDataNormalBoilingPointTemperature = 249.572197590653;

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
      ( 240, 0.501419152581175, 1000.00000000004, 35861.156566969, 37855.4960229956, 210.116171831772, 71.549703231507, 79.8951477494003, 149.157833411354 ),
      ( 250, 0.481319183821619, 1000.00000000002, 36586.9872955942, 38664.6106973048, 213.418857656479, 73.583821043736, 81.9233417672637, 152.021760679941 ),
      ( 259, 0.464563832056703, 1000.00000000001, 37257.49009317, 39410.0468162641, 216.347997202941, 75.3899281247895, 83.7253604230046, 154.551358032913 ),
      ( 268, 0.448939079424148, 1000.00000000001, 37944.1246094756, 40171.5983265837, 219.238243791916, 77.1722227900125, 85.5044351988923, 157.038180979196 ),
      ( 277, 0.434333587662442, 1000.00000000001, 38646.6784956366, 40949.0562725475, 222.091400246229, 78.9304102578008, 87.2600572842847, 159.484511817799 ),
      ( 286, 0.420650317491006, 1000.00000000001, 39364.9365700837, 41742.2080433696, 224.909083403049, 80.6643325170908, 88.9919125113533, 161.892416962258 ),
      ( 295, 0.407804268670951, 1000, 40098.68208881, 42550.8388630856, 227.692752307513, 82.3739296809213, 90.6998261327446, 164.263777948659 ),
      ( 304, 0.395720644909768, 1000, 40847.6976547651, 43374.7328571564, 230.443730752883, 84.0592121174118, 92.3837232476517, 166.60031635163 ),
      ( 313, 0.384333350791744, 1000, 41611.7658698461, 44213.6738175689, 233.163225552659, 85.7202406359123, 94.0436007467345, 168.903614088015 ),
      ( 322, 0.37358375101568, 1000, 42390.6698045922, 45067.4457545131, 235.852341548745, 87.3571124570569, 95.6795074640552, 171.175130182139 ),
      ( 331, 0.363419638913282, 1000, 43184.1933387999, 45935.8332969218, 238.51209408677, 88.9699512645514, 97.2915300977598, 173.416214776752 ),
      ( 340, 0.353794373436072, 1000, 43992.1214104052, 46818.6219855499, 241.143419496789, 90.5589001200679, 98.879783169932, 175.628120968596 ),
      ( 349, 0.344666152854547, 1000, 44814.2401988, 47715.598489186, 243.747183981062, 92.1241163864581, 100.444401818495, 177.81201490191 ),
      ( 358, 0.335997400212947, 1000, 45650.3372609558, 48626.5507654836, 246.32419121322, 93.6657680645056, 101.985536583418, 179.96898444888 ),
      ( 367, 0.327754240749126, 1000, 46500.2016333275, 49551.2681815875, 248.875188882738, 95.1840311299278, 103.503349605764, 182.100046730437 ),
      ( 376, 0.319906055456928, 999.999999999999, 47363.6239087463, 50489.5416053391, 251.400874367159, 96.6790875827487, 104.998011834623, 184.206154675298 ),
      ( 385, 0.312425098046257, 999.999999999999, 48240.3962948916, 51441.1634747804, 253.901899676202, 98.1511240075957, 106.46970095841, 186.28820277379 ),
      ( 394, 0.305286164965029, 1000, 49130.3126590898, 52405.9278515259, 256.378875783048, 99.6003305031202, 107.91859986072, 188.347032151785 ),
      ( 403, 0.298466310048169, 999.999999999999, 50033.1685628858, 53383.6304620483, 258.83237643603, 101.026899880069, 109.344895458986, 190.383435066183 ),
      ( 412, 0.291944596870255, 1000, 50948.7612889098, 54374.0687298433, 261.262941526901, 102.431027056312, 110.748777824593, 192.398158904887 ),
      ( 240, 5.03985616563589, 10000.0000003497, 35828.3199202364, 37812.5035301843, 190.834680133394, 71.9620323737174, 80.5781109345562, 148.605315065666 ),
      ( 250, 4.83398967275069, 10000.0000002148, 36559.0858516017, 38627.7704531814, 194.16249888368, 73.9130323614873, 82.475148949302, 151.538423308967 ),
      ( 259, 4.66302247073956, 10000.0000001411, 37233.192776381, 39377.7245822839, 197.109402814662, 75.6575409309227, 84.180844580581, 154.120054840455 ),
      ( 268, 4.50405012064502, 10000.0000000944, 37922.7879606842, 40143.0119218381, 200.013836080622, 77.3899520560347, 85.8819473856691, 156.651126605204 ),
      ( 277, 4.35579789539307, 10000.0000000643, 38627.7845523248, 40923.5751836213, 202.878394918935, 79.1082311203581, 87.574910764751, 159.135385577197 ),
      ( 286, 4.217175433338, 10000.0000000446, 39348.0706151365, 41719.3260106299, 205.705316027339, 80.810360762376, 89.2564584281206, 161.576058649291 ),
      ( 295, 4.08724316958727, 10000.0000000314, 40083.5120422846, 42530.1489525718, 208.49653480566, 82.4946203951539, 90.9238647021239, 163.975943921922 ),
      ( 304, 3.96518579687564, 10000.0000000224, 40833.9567321416, 43355.9066513363, 211.253738905203, 84.1596463040434, 92.5749799273974, 166.337488513322 ),
      ( 313, 3.85029127108909, 10000.0000000162, 41599.2386392263, 44196.444745451, 213.978413059449, 85.8044038150307, 94.2081602603329, 168.66285173296 ),
      ( 322, 3.74193410365399, 10000.0000000119, 42379.1812257372, 45051.5960045669, 216.67187513356, 87.4281326451804, 95.8221741870015, 170.95395530747 ),
      ( 331, 3.63956195142565, 10000.0000000088, 43173.6002350812, 45921.1836348064, 219.335304662413, 89.0302907748861, 97.4161143951928, 173.212523057998 ),
      ( 340, 3.54268475100835, 10000.0000000066, 43982.3058570266, 46805.0238527953, 221.969765377858, 90.6105057495968, 98.9893239846369, 175.440112295522 ),
      ( 349, 3.45086583106345, 10000.000000005, 44805.1043942368, 47702.9278650854, 224.576223064728, 92.1685353528459, 100.541337940065, 177.638138814707 ),
      ( 358, 3.36371457681246, 10000.0000000038, 45641.7995374111, 48614.7033827427, 227.155559826824, 93.7042369475182, 102.071837947383, 179.807896961357 ),
      ( 367, 3.28088032493529, 10000.0000000029, 46492.1933398088, 49540.1557796458, 229.708585597599, 95.2175439981689, 103.580617972515, 181.950575901035 ),
      ( 376, 3.20204724357674, 10000.0000000022, 47356.0869632956, 50479.0889802277, 232.236047527157, 96.7084482445315, 105.067558188184, 184.0672729416 ),
      ( 385, 3.12693000862579, 10000.0000000017, 48233.2812514528, 51431.3061424533, 234.73863772014, 98.1769862073149, 106.53260524764, 186.15900455319 ),
      ( 394, 3.05527012937443, 10000.0000000013, 49123.5771718323, 52396.61018579, 237.216999681086, 99.6232289710956, 107.975757337145, 188.226715572427 ),
      ( 403, 2.9868328081128, 10000.0000000011, 50026.7761589939, 53374.8042015543, 239.671733736345, 101.0472744309, 109.397052812663, 190.271286961174 ),
      ( 412, 2.92140424204114, 10000.0000000008, 50942.680382051, 54365.6917736597, 242.103401637052, 102.449241387549, 110.796561524034, 192.293542403523 ),
      ( 240, 12616.2443006558, 98024.9996552832, 15489.7978262378, 15497.5675711254, 82.4964814468066, 91.5111346095592, 132.674164120102, 749.645784150647 ),
      ( 247.818107300403, 12406.5794948246, 98024.9999989045, 16532.2747794181, 16540.1758290217, 86.771306228446, 92.2388450341989, 134.066331915763, 716.438867099915 ),
      ( 250, 49.5193398675381, 98024.9999999999, 36290.6165123403, 38270.1461317216, 174.104152812339, 77.1222728559931, 88.2308643213553, 146.634218558299 ),
      ( 300, 40.2367895387451, 98024.9999999999, 40356.8680369331, 42793.0713504606, 190.579741658761, 84.4385473175038, 93.8528847445617, 162.565213440606 ),
      ( 350, 34.1363086655531, 98025.0000468312, 44807.9198497533, 47679.4957136588, 205.629154615207, 92.7676214680152, 101.666959996427, 176.177665724837 ),
      ( 400, 29.7166756214747, 98025.0000108238, 49660.3361108692, 52958.9890712288, 219.717130687559, 100.782520538478, 109.45900380166, 188.464026163465 ),
      ( 240, 12616.2952321905, 99999.9996580305, 15489.7188440381, 15497.645101138, 82.4961522222988, 91.5112989425068, 132.673626196713, 749.656946638261 ),
      ( 248.27177239638, 12394.3249795213, 100000.000002143, 16593.0208387496, 16601.0890473989, 87.0162374944623, 92.2833235210279, 134.150991426897, 714.520680641755 ),
      ( 250, 50.5709901041606, 100000, 36284.1113262974, 38261.529600965, 173.911822826151, 77.2493722679078, 88.4420385377228, 146.517396756509 ),
      ( 300, 41.0675219868433, 99999.9999999999, 40353.6545224304, 42788.6687419891, 190.403117356548, 84.4606036380585, 93.8984730784013, 162.502882405057 ),
      ( 350, 34.8335694413664, 100000.000050779, 44805.895384735, 47676.6893244461, 205.457498123309, 92.7772119173477, 101.688786616645, 176.139099570868 ),
      ( 400, 30.3204521692107, 100000.00001173, 49658.8938762597, 52956.9977255577, 219.547665132963, 100.787183863255, 109.471130451955, 188.438596755103 ),
      ( 240, 12616.3294004308, 101324.999657499, 15489.6658576791, 15497.6971159351, 82.4959313557673, 91.5114091927022, 132.67326534036, 749.66443509615 ),
      ( 248.572197590653, 12386.2014147476, 101324.999997965, 16633.2680593078, 16641.4485334181, 87.178270457979, 92.3128966584338, 134.207322202033, 713.250346883812 ),
      ( 250, 51.2779119649027, 101325, 36279.7197622308, 38255.7167581567, 173.784493851763, 77.3374672836386, 88.5878181449098, 146.438766421477 ),
      ( 300, 41.6253108898827, 101325, 40351.4976703455, 42785.7137238435, 190.286444568952, 84.4753888284736, 93.9290799200227, 162.461035894021 ),
      ( 350, 35.3015667073684, 101325.000053565, 44804.536769548, 47674.8059814925, 205.344160639954, 92.7836461574093, 101.703440331676, 176.113217101609 ),
      ( 400, 30.7256306417789, 101325.000012369, 49657.9261183643, 52955.6615234952, 219.435798435306, 100.790312633681, 109.479270094652, 188.421533671802 ),
      ( 250, 12358.509943995, 488054.05385121, 16807.8283555556, 16847.3196903576, 87.8787269289951, 92.4842691060572, 134.351353414365, 709.610414510039 ),
      ( 275, 11648.6467068597, 488054.054125669, 20230.6500692529, 20272.5479880763, 100.932844710881, 95.2357171586033, 139.985521911426, 602.748163790601 ),
      ( 291.698827473317, 11126.496382559, 488054.053849623, 22607.1954774622, 22651.0596047731, 109.328059419501, 97.3380424160679, 145.136150198488, 528.931021066856 ),
      ( 300, 223.71715375748, 488054.053849305, 39663.7901348314, 41845.3575544597, 174.873162950766, 89.7853985791228, 106.084376108127, 148.924875610422 ),
      ( 350, 179.983999962789, 488054.053849291, 44391.6460082679, 47103.2984548754, 191.08152068675, 94.6824586033633, 106.420929974148, 168.222201551649 ),
      ( 400, 153.076565219151, 488054.053849291, 49368.8816801064, 52557.1819476919, 205.638467247236, 101.711424572187, 112.005729022614, 183.34053955705 ),
      ( 250, 12373.1948044181, 1000000.00000001, 16785.2433506913, 16866.0632210487, 87.7881013173535, 92.5244439404538, 134.184997561759, 712.799322614851 ),
      ( 275, 11669.1780437339, 1000000.00027788, 20199.9713852004, 20285.6672239758, 100.820877678678, 95.2620514290158, 139.683956979181, 607.072420291533 ),
      ( 300, 10876.7735865949, 999999.999999611, 23779.015238087, 23870.9542668843, 113.294266430338, 98.4559053174517, 147.738567187229, 497.121916225884 ),
      ( 317.494859787349, 10226.0533171837, 999999.999999747, 26430.0411752427, 26527.8306125733, 121.899526216574, 101.117821431569, 156.714313518032, 413.723510855725 ),
      ( 325, 464.714067966819, 1000000.00000154, 41180.3380971563, 43332.1989271429, 174.636810002474, 97.1327417872505, 121.401366699585, 143.019115633347 ),
      ( 375, 361.08947769956, 1000000.00000001, 46352.9071840271, 49122.3038620218, 191.217812376845, 99.9441267034103, 114.530844445184, 167.148353467621 ),
      ( 250, 12451.6287324622, 3827185.88291877, 16664.8325331991, 16972.1968118128, 87.3015757872883, 92.7509516557584, 133.343308660432, 729.6741593558 ),
      ( 259, 12214.3476415033, 3827185.88288988, 17866.0414048882, 18179.3766721672, 92.0452426184919, 93.6677282435036, 134.945089594885, 693.568797062418 ),
      ( 268, 11971.0380420645, 3827185.88285303, 19081.9990293177, 19401.7027901282, 96.6843307172985, 94.6446226388541, 136.711999647997, 657.486150623466 ),
      ( 277, 11720.5193114832, 3827185.88281522, 20314.2173457211, 20640.7545733904, 101.231545498693, 95.6699741306844, 138.666624135556, 621.363578925079 ),
      ( 286, 11461.3214042823, 3827185.88279091, 21564.4471719554, 21898.3690425489, 105.699287652668, 96.7361824999238, 140.844136420435, 585.117432624391 ),
      ( 295, 11191.5866819587, 3827185.88280727, 22834.8013956537, 23176.7713049765, 110.100139892734, 97.8395015044587, 143.296529304985, 548.640438311347 ),
      ( 304, 10908.9213470334, 3827185.88297884, 24127.9256264723, 24478.7564521084, 114.447452054268, 98.9803482663934, 146.100093629831, 511.797319626625 ),
      ( 313, 10610.1628747747, 3827185.88297918, 25447.2526336398, 25807.9620711997, 118.756134232117, 100.164330005678, 149.368667381407, 474.417600707257 ),
      ( 322, 10290.9990742989, 3827185.88297826, 26797.4082227594, 27169.3046591838, 123.043853108375, 101.404457360918, 153.278130383551, 436.283414389826 ),
      ( 331, 9945.30521077566, 3827185.8829787, 28184.9073799339, 28569.7307515517, 127.333026012747, 102.725605386249, 158.115110613436, 397.107230902118 ),
      ( 340, 9563.89091514502, 3827185.88285896, 29619.4597384307, 30019.6301206334, 131.654517866771, 104.173785325976, 164.38465767449, 356.486239963127 ),
      ( 349, 9131.83351197071, 3827185.88297823, 31116.7344229089, 31535.8381963144, 136.0554598885, 105.83728226342, 173.087405123131, 313.794333214249 ),
      ( 358, 8621.68271461166, 3827185.88297875, 32705.3756434439, 33149.2780705759, 140.619167903145, 107.903618369438, 186.616252972557, 267.877741304746 ),
      ( 367, 7969.99361062741, 3827185.88297877, 34451.0562589022, 34931.2556254206, 145.533891032586, 110.867612682529, 213.031351165475, 215.968546162989 ),
      ( 376, 6915.99869364853, 3827185.8829754, 36619.510010604, 37172.8915325656, 151.563518219549, 117.058492179228, 319.975852981686, 147.33955090961 ),
      ( 385, 2683.41786557826, 3827185.88297878, 42822.8982684536, 44249.1337914678, 170.158432417804, 117.708134180563, 357.420062532612, 104.316192698958 ),
      ( 394, 2128.12489447766, 3827185.88297876, 44776.6801665429, 46575.064224222, 176.136249293196, 112.69908523714, 208.462512297225, 120.162485896371 ),
      ( 403, 1869.65165952818, 3827185.88297877, 46229.0036462919, 48276.0084257515, 180.406194726698, 111.399267807603, 174.852655930428, 131.117808579304 ),
      ( 412, 1700.75405919156, 3827185.88297876, 47524.2890596368, 49774.5767260369, 184.08441879921, 111.124816832109, 159.790209287639, 139.863724958397 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new(double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 257.240125, 140078.004706543, 12148.5775162466, 69.7944868340856 ),
      ( 274.48025, 268986.580385921, 11655.3365378823, 130.18772246295 ),
      ( 291.720375, 473675.760626473, 11125.0214025618, 226.318701276084 ),
      ( 308.9605, 778553.54035191, 10540.8899535805, 374.213773289631 ),
      ( 326.200625, 1210830.52285207, 9874.38296837577, 599.742271068641 ),
      ( 343.44075, 1801426.2846134, 9070.22950877876, 952.671494467525 ),
      ( 360.680875, 2588649.17336475, 7991.77037423818, 1564.75988866501 ),
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
