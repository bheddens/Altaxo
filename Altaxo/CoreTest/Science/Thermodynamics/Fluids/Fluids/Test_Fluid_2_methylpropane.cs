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
  /// Tests and test data for <see cref="Fluid_2_methylpropane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Fluid_2_methylpropane : FluidTestBase
  {

    public Test_Fluid_2_methylpropane()
    {
      _fluid = Fluid_2_methylpropane.Instance;

      _testDataMolecularWeight = 0.0581222;

      _testDataTriplePointTemperature = 113.73;

      _testDataTriplePointPressure = 0.02289;

      _testDataTriplePointLiquidMoleDensity = 12737.6244574213;

      _testDataTriplePointVaporMoleDensity = 2.420743019024E-05;

      _testDataCriticalPointTemperature = 407.81;

      _testDataCriticalPointPressure = 3629000.01638371;

      _testDataCriticalPointMoleDensity = 3879.756788;

      _testDataNormalBoilingPointTemperature = 261.400977163319;

      _testDataNormalSublimationPointTemperature = null;

      _testDataIsMeltingCurveImplemented = true;

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
      ( 125, 3.3036379416345E-05, 0.0343350001265651, 20961.4609345675, 22000.7697430133, 207.748485833989, 45.805594149765, 54.1200750695437, 145.352055089691 ),
      ( 175, 2.35974106919055E-05, 0.0343350000359277, 23557.2895829136, 25012.3221067873, 227.902105065752, 57.7769991613528, 66.0914734022829, 169.223449289961 ),
      ( 225, 1.83535410801315E-05, 0.0343350000150512, 26734.7577587289, 28605.5139177254, 245.901380472291, 69.4342828540081, 77.748755713182, 189.844190362891 ),
      ( 275, 1.50165334487216E-05, 0.034335000007775, 30518.6224184232, 32805.102192535, 262.713562366343, 82.1125202715541, 90.4269926925904, 208.140699692571 ),
      ( 325, 1.2706297472649E-05, 0.0343350000045491, 34961.1245929813, 37663.3279750804, 278.913731217087, 95.6794892174973, 103.993961458777, 224.792920604885 ),
      ( 375, 1.10121244490073E-05, 0.0343350000028808, 40089.1934611925, 43207.1204481125, 294.756717541116, 109.408801224134, 117.723273377907, 240.251983733126 ),
      ( 425, 9.71658038235175E-06, 0.0343350000019224, 45893.8601262088, 49427.5107163161, 310.310683482843, 122.659926651323, 130.974398756905, 254.790150601864 ),
      ( 475, 8.69378243970477E-06, 0.0343350000013291, 52341.1921948271, 56290.5663871832, 325.564831653753, 135.079490341881, 143.393962418462, 268.573924623169 ),
      ( 525, 7.86580315519389E-06, 0.0343350000009406, 59385.959295633, 63751.0570896541, 340.488688465669, 146.552480174362, 154.866952232243, 281.714211299564 ),
      ( 575, 7.18182026930208E-06, 0.0343350000006752, 66980.9906718739, 71761.8120671734, 355.056466726998, 157.100268823725, 165.414740868887, 294.292285364952 ),
      ( 125, 12554.5446222241, 288.21496873829, -5413.70763790375, -5413.68468088082, -30.1431559387248, 69.6267756749389, 100.242988578013, 1903.65221290655 ),
      ( 150, 12147.4798418007, 288.214864520827, -2849.27361319233, -2849.24988688298, -11.4539662068443, 72.7202476666797, 104.893292362116, 1714.39490870921 ),
      ( 169.484880204331, 11827.2774770893, 288.214864069121, -770.558915507659, -770.534546850998, 1.57067021103702, 75.1138220140224, 108.478907133257, 1582.02490391065 ),
      ( 175, 0.198168480592779, 288.21486841422, 23555.6423190612, 25010.0354069634, 152.768972550406, 57.7953644187746, 66.1286953517386, 169.169793103612 ),
      ( 225, 0.154091654860511, 288.214868414214, 26733.9462498486, 28604.3581723834, 170.774055399818, 69.4403216816404, 77.7620120964087, 189.817179538561 ),
      ( 275, 0.126063771180834, 288.214868414214, 30518.136452723, 32804.3989190487, 187.588076999606, 82.1150534662851, 90.4330610965142, 208.124689772067 ),
      ( 325, 0.106665137483468, 288.214868414215, 34960.7954916141, 37662.848619881, 203.78900040746, 95.6807390553555, 103.997236813091, 224.782492489621 ),
      ( 375, 0.0924412336868329, 288.214868414214, 40088.9514558527, 43206.7686562442, 219.632354011004, 109.409492046937, 117.725255000774, 240.24478752943 ),
      ( 425, 0.0815648388541441, 288.214868414214, 45893.671810957, 49427.2393685366, 235.186522207955, 122.660342910764, 130.975701251937, 254.784998131161 ),
      ( 475, 0.0729785369654553, 288.214868414215, 52341.0395384152, 56290.3495739212, 250.440792092484, 135.079759542443, 143.394874405554, 268.570148107349 ),
      ( 525, 0.0660279017219277, 288.214934690019, 59385.8317694979, 63750.8793807914, 265.36472546776, 146.552664476892, 154.867622360698, 281.711404968527 ),
      ( 575, 0.0602861455310801, 288.214915987033, 66980.8816924585, 71761.6636357733, 279.932557646244, 157.100401152114, 165.415252262924, 294.290187795198 ),
      ( 125, 12554.5494875137, 1000.00010700979, -5413.71680764843, -5413.63715523971, -30.1432292968418, 69.6268384078013, 100.242964362929, 1903.65410402399 ),
      ( 150, 12147.48585183, 1000.00000298966, -2849.2854413442, -2849.20311978275, -11.4540450613648, 72.7203038260321, 104.893255278799, 1714.39754941168 ),
      ( 175, 11735.9051219952, 999.999998594701, -169.470311393957, -169.385102797927, 5.06066528447067, 75.8112568676933, 109.506747476487, 1546.10590334604 ),
      ( 182.355067841401, 11613.3974740713, 1000.00000090099, 641.056257702916, 641.142365149351, 9.59736803154294, 76.7650470416385, 110.897323219284, 1499.01306483482 ),
      ( 200, 0.60193569932282, 1000.00000000018, 25069.4449892003, 26730.7520044267, 151.614626296005, 63.5554957348667, 71.909042544664, 179.746911000479 ),
      ( 250, 0.481305543931031, 1000.00000000002, 28545.2790597112, 30622.9613399371, 168.935096646387, 75.6419345846687, 83.9735440166378, 199.163910830662 ),
      ( 300, 0.401007351913777, 1000, 32653.6045239606, 35147.3243902613, 185.396361595904, 88.8330845009368, 97.1567029243069, 216.594626190241 ),
      ( 350, 0.343687272365898, 1000, 37438.2940950542, 40347.9159530768, 201.402641382926, 102.573314808816, 110.893338445856, 232.621417620615 ),
      ( 400, 0.300710405222713, 1000, 42907.9259608445, 46233.3845503448, 217.100394804685, 116.124815147941, 124.442970025316, 247.602971908251 ),
      ( 450, 0.26728965539071, 1000, 49039.3046691665, 52780.5643095303, 232.50845688509, 128.986356619012, 137.30343270591, 261.75322507428 ),
      ( 500, 0.24055581999322, 1000, 55791.3908646139, 59948.4301747756, 247.601602847306, 140.935833344267, 149.252235998116, 275.207635089798 ),
      ( 550, 0.218684144323104, 1000, 63117.1541174481, 67689.9593525753, 262.350204879016, 151.938306711179, 160.254262733168, 288.060794342819 ),
      ( 125, 12554.6110042122, 10000.0001016777, -5413.83274777036, -5413.03622766326, -30.1441568349896, 69.6276315902569, 100.242658206019, 1903.67801533171 ),
      ( 150, 12147.5618420532, 9999.99999987898, -2849.4349930022, -2848.61178253989, -11.4550420913004, 72.721013888422, 104.892786433021, 1714.43093822315 ),
      ( 175, 11735.9986870911, 10000.0000027525, -169.6601794465, -168.808100278006, 5.05958030282048, 75.8119138014514, 109.506056989884, 1546.14881416004 ),
      ( 200, 11315.9971451914, 9999.99999954888, 2627.90303018197, 2628.78673489409, 19.995034793068, 79.1994003618424, 114.370011274602, 1389.15304675606 ),
      ( 213.369677008588, 11086.3485960869, 10000.0000008614, 4175.56430528492, 4176.4663155288, 27.4847808930913, 81.2110501133091, 117.180765529659, 1308.1318100669 ),
      ( 225, 5.3800777693333, 10000.0000005568, 26706.3052963118, 28565.0144877583, 141.162582934785, 69.6485129233517, 78.2210515400726, 188.897140519515 ),
      ( 275, 4.38805832104427, 10000.0000000738, 30501.6856890727, 32780.5979706429, 158.039815825198, 82.2012264970888, 90.6399910421032, 207.582643677656 ),
      ( 325, 3.70785046603058, 10000.0000000146, 34949.6798819772, 37646.6602730769, 174.266394152665, 95.7230448433363, 104.108282486322, 224.430242640527 ),
      ( 375, 3.21118645896762, 10000.0000000037, 40080.7855387805, 43194.8993181525, 190.122183411509, 109.432824883549, 117.792266162519, 240.001971352088 ),
      ( 425, 2.83224510574036, 10000.0000000011, 45887.3206462082, 49418.0885093896, 205.683186600668, 122.674387148429, 131.01968900967, 254.611245113598 ),
      ( 475, 2.53347520954006, 10000.0000000004, 52335.8923919708, 56283.0397579069, 220.941565475377, 135.088837092873, 143.425651491458, 268.442842385657 ),
      ( 525, 2.29181375776379, 10000.0000000001, 59381.5326343502, 63744.8889350635, 235.868148506675, 146.558877328274, 154.890227411354, 281.616828519192 ),
      ( 575, 2.09228987175436, 10000.0000000001, 66977.2081740525, 71756.6606461974, 250.437780446039, 157.104861175522, 165.43249794092, 294.219511867126 ),
      ( 125, 12555.2260373739, 100000.00010054, -5414.99168407217, -5407.02687325929, -30.1534300421029, 69.6355605103648, 100.239599185633, 1903.91707925598 ),
      ( 150, 12148.3215221085, 100000.000004244, -2850.92983409838, -2842.69824425922, -11.4650095859818, 72.7281113175681, 104.888102609752, 1714.76473153386 ),
      ( 175, 11736.9339755898, 100000.000004003, -171.557864261529, -163.037751580315, 5.04873425583767, 75.8184798772567, 109.499160451555, 1546.5777565584 ),
      ( 200, 11317.1553573216, 100000.000001251, 2625.511012758, 2634.34715548503, 19.9830722192483, 79.2056641902816, 114.359897637101, 1389.68420725641 ),
      ( 225, 10884.3044071921, 99999.9999981356, 5550.37184993187, 5559.55939157505, 33.7584410015527, 83.099801030714, 119.771004712413, 1239.53030968276 ),
      ( 250, 10431.9519248612, 100000.000000944, 8620.018423999, 8629.60435774575, 46.6911594327029, 87.5835312903444, 125.987220304166, 1093.71227336167 ),
      ( 260.065243644769, 10242.3023388284, 100000.000000247, 9901.81154495538, 9911.57497476756, 51.7181428177536, 89.5547548521091, 128.775540958003, 1035.79476792288 ),
      ( 275, 45.2871240521669, 100000, 30341.9337081214, 32550.0668606, 138.308681931527, 83.0794415744406, 92.8082235910247, 202.309401945692 ),
      ( 325, 37.7487379970479, 99999.9999999999, 34844.2928601733, 37493.3880433771, 154.795847371659, 96.132941062831, 105.202630041169, 221.087207010577 ),
      ( 375, 32.4732638756288, 100000.000039454, 40004.1431390465, 43083.5995319255, 170.77252552144, 109.653955543839, 118.435265252295, 237.723298865954 ),
      ( 425, 28.5332307873816, 100000.000011298, 45828.0076518651, 49332.6931449471, 186.398668566811, 122.80604793737, 131.436130132751, 252.990507317248 ),
      ( 475, 25.4643840296282, 100000.00000365, 52287.9539535241, 56215.0075153655, 201.69580252552, 135.173461486405, 143.714873996398, 267.259770245648 ),
      ( 525, 23.0008242271752, 100000.000001274, 59341.5567002659, 63689.2269843214, 216.647211475114, 146.61661815654, 155.101712474511, 280.740194317062 ),
      ( 575, 20.9769419366157, 100000.000000466, 66943.0844588699, 71710.2235539119, 231.233662261461, 157.146239438476, 165.593384516919, 293.565754750315 ),
      ( 125, 12555.235090212, 101325.000094226, -5415.00873987817, -5406.93840114168, -30.1535665347991, 69.6356772022484, 100.23955418464, 1903.92059814117 ),
      ( 150, 12148.3327032712, 101324.999997529, -2850.95183231186, -2842.61118158452, -11.4651562915813, 72.7282157641227, 104.888033716346, 1714.76964442655 ),
      ( 175, 11736.9477401956, 101324.999997789, -171.585788884913, -162.952794835635, 5.04857462908555, 75.8185765002041, 109.499059032153, 1546.58406929464 ),
      ( 200, 11317.1724007174, 101325.00000188, 2625.47581733327, 2634.42902546814, 19.9828961751487, 79.2057563633689, 114.359748946108, 1389.69202340687 ),
      ( 225, 10884.3257920939, 101325.000002705, 5550.32744453985, 5559.63670281989, 33.7582435634961, 83.099890132404, 119.770783119074, 1239.53986396357 ),
      ( 250, 10431.9793384728, 101324.999999134, 8619.9618410463, 8629.67476289091, 46.6909329994632, 87.5836165469465, 125.986878801035, 1093.72398098824 ),
      ( 260.400977163319, 10235.9173006109, 101325.000002102, 9944.99291095119, 9954.8918772115, 51.8840997905338, 89.6221747407144, 128.871369321855, 1033.88076578677 ),
      ( 275, 45.9096476092165, 101325, 30339.4758077411, 32546.528252632, 138.190146880058, 83.0935253250826, 92.8439372272605, 202.228119649646 ),
      ( 325, 38.2592674580007, 101325, 34842.7080108637, 37491.0859525279, 154.681486186144, 96.1392259021736, 105.219677042969, 221.036885216971 ),
      ( 375, 32.9090369717918, 101325.000041631, 40003.0014482998, 43081.9429599728, 170.660024097684, 109.65727873941, 118.445039150449, 237.689359366342 ),
      ( 425, 28.9144795681776, 101325.000011916, 45827.1282025357, 49331.4278311353, 186.287151136648, 122.808006926053, 131.442382393848, 252.966502566464 ),
      ( 475, 25.8037355630977, 101325.000003848, 52287.2449420363, 56214.0019713075, 201.58486494686, 135.174714156873, 143.719186781321, 267.242307928803 ),
      ( 525, 23.3068240254854, 101325.000001343, 59340.9663325788, 63688.4055156501, 216.536643329598, 146.61747046618, 155.104853219222, 280.727285967663 ),
      ( 575, 21.2556942855371, 101325.000000491, 66942.5809902525, 71709.5388999471, 231.123343562704, 157.146849244227, 165.595767605663, 293.556146373555 ),
      ( 125, 12561.3630384543, 1000000.00010471, -5426.53472675849, -5346.92553171784, -30.2459454860302, 69.7145596690764, 100.209261750005, 1906.30284165148 ),
      ( 150, 12155.8962167194, 999999.999998168, -2865.81102400937, -2783.54641906624, -11.564405426998, 72.7987671376241, 104.841723495024, 1718.09325248115 ),
      ( 175, 11746.2508525616, 999999.999997875, -190.435767396447, -105.302220314078, 4.94064837897249, 75.8838158090835, 109.431018426469, 1550.85074257624 ),
      ( 200, 11328.6785856471, 1000000.0000027, 2601.73985243491, 2690.011400828, 19.8639696310604, 79.267976959429, 114.260245880326, 1394.96872425863 ),
      ( 225, 10898.7405952172, 999999.999998362, 5520.41991783307, 5612.17363848197, 33.6250244328952, 83.1600414837996, 119.622997403512, 1245.98003874505 ),
      ( 250, 10450.4162475919, 1000000.00000197, 8581.92719050932, 8677.61715886176, 46.5384229215687, 87.6412263288825, 125.760232199963, 1101.59826023406 ),
      ( 275, 9974.80775730772, 999999.999999209, 11808.384089074, 11908.6366477528, 58.8509760444941, 92.6980162731369, 132.916195439122, 960.044580436934 ),
      ( 300, 9457.49020953576, 1000000.000356, 15229.4160956934, 15335.1523934004, 70.7714102733819, 98.2702805115958, 141.495637050764, 818.997457333679 ),
      ( 325, 8871.77828987599, 1000000.00000004, 18890.3842780472, 19003.1012517278, 82.5092686143108, 104.317237352537, 152.496477249573, 674.342568483708 ),
      ( 338.336421803302, 8513.07584792229, 999999.999998294, 20969.1513794636, 21086.617735674, 88.7909981397879, 107.764395273784, 160.289679094952, 592.913378470541 ),
      ( 350, 419.421130720356, 1000000.00000133, 36238.4056585791, 38622.6441405169, 140.40766148124, 107.075672909388, 126.800673071038, 195.445418064669 ),
      ( 400, 336.980684061389, 1000000.00000001, 42086.1247881643, 45053.6539294424, 157.574377865621, 118.325670910663, 132.000075038495, 224.303598867065 ),
      ( 450, 287.492329699363, 1000000, 48414.1933903775, 51892.5470600066, 173.673080398941, 130.2430307834, 141.826054351986, 245.765898410352 ),
      ( 500, 252.698421987279, 1000000, 55288.4046323205, 59245.6909190166, 189.158008642902, 141.736298216268, 152.292036427984, 263.784314458865 ),
      ( 550, 226.318241256032, 999999.999999998, 62697.680481024, 67116.2372639424, 204.153183113773, 152.486557918154, 162.445756853527, 279.73859196372 ),
      ( 125, 12580.3734339904, 3810450.01720418, -5462.04582444669, -5159.15735796374, -30.5323456116598, 69.9578759369991, 100.117393502548, 1913.69749633756 ),
      ( 148, 12211.459455314, 3810450.01718069, -3119.72658643072, -2807.68771580068, -13.274567599283, 72.7744284079195, 104.340079843644, 1742.25837624841 ),
      ( 171, 11839.9862152631, 3810450.01714457, -681.924727399763, -360.095803964661, 2.09029136344446, 75.5797950369551, 108.497083913249, 1589.36908792367 ),
      ( 194, 11463.4072660434, 3810450.01709842, 1851.84560681381, 2184.24677940284, 16.0446981253403, 78.607734729679, 112.793166562876, 1447.07570023111 ),
      ( 217, 11078.9189174725, 3810450.01704946, 4487.24856517339, 4831.18555446212, 28.9337821279866, 82.0385207889567, 117.452045306025, 1311.5502181097 ),
      ( 240, 10683.0053459395, 3810450.01699181, 7234.48878543061, 7591.17212439759, 41.0183212669933, 85.9579161840753, 122.648371968425, 1180.95081189236 ),
      ( 263, 10270.9506554542, 3810450.01693467, 10107.1807175968, 10478.173641695, 52.5013699383692, 90.3737449638801, 128.518260873445, 1054.18298448 ),
      ( 286, 9836.06680044535, 3810450.01688933, 13121.8636382083, 13509.2593416126, 63.5461304732035, 95.2425738893119, 135.205873487961, 930.245707597567 ),
      ( 309, 9368.23437241172, 3810450.01694144, 16298.9428822184, 16705.6844159447, 74.291917354728, 100.500191868028, 142.950538686213, 807.835194141673 ),
      ( 332, 8850.76759078537, 3810450.01720275, 19666.3625602657, 20096.8845435986, 84.8734371239634, 106.096382319445, 152.270167099672, 684.967681385036 ),
      ( 355, 8252.37231430278, 3810450.01720293, 23270.0805186058, 23731.8204731397, 95.4549018743154, 112.049231843363, 164.500705911134, 558.255753547711 ),
      ( 378, 7499.14450357063, 3810450.01720133, 27210.4446820586, 27718.5626434323, 106.329952480692, 118.60391836847, 184.317234204034, 420.462738391235 ),
      ( 401, 6278.36465426627, 3810450.01720289, 31891.1899642666, 32498.1075657496, 118.586729021146, 127.69806539246, 252.641295895375, 246.395800745849 ),
      ( 424, 1943.9687671681, 3810450.01720288, 41556.6564647042, 43516.7959903787, 145.353014307954, 133.469027712111, 228.296803345486, 155.989303325087 ),
      ( 447, 1513.14976972178, 3810450.0172029, 45481.4354082208, 47999.6593761652, 155.659737824007, 135.00418836758, 177.813179993348, 188.495772749683 ),
      ( 470, 1304.01509592979, 3810450.01721469, 49032.7382541729, 51954.828672534, 164.289815582371, 138.72449447246, 168.271683787675, 209.983693053484 ),
      ( 493, 1167.12072977874, 3810450.01720426, 52530.8561089846, 55795.6854620942, 172.268534035243, 143.00412180586, 166.405417258676, 226.721645477234 ),
      ( 516, 1066.36808574182, 3810450.01720312, 56056.9397217649, 59630.2368488562, 179.870383859618, 147.470073693698, 167.329666735417, 240.71167350848 ),
      ( 539, 987.279425273073, 3810450.01720293, 59642.8749456236, 63502.4206017574, 187.211830267797, 151.964840844985, 169.527184006478, 252.886282910395 ),
      ( 562, 922.596301261246, 3810450.0172029, 63303.2046242041, 67433.3425967862, 194.353094755446, 156.411525628276, 172.367640323668, 263.762885774101 ),
      ( 125, 12621.4492987197, 9999999.99999664, -5537.49715850499, -4745.19512065495, -31.1502122972901, 70.4759766070143, 99.9292008076713, 1929.70821418974 ),
      ( 148, 12260.9147571544, 9999999.99998859, -3214.60355548464, -2399.0037247988, -13.9309914287775, 73.2371007994865, 104.066231320586, 1763.89973558803 ),
      ( 171, 11899.2079106352, 9999999.99997077, -799.29195306239, 41.1001196765891, 1.3870260913777, 76.0062722501578, 108.115116967086, 1616.47045533434 ),
      ( 194, 11534.4003104661, 9999999.99995025, 1708.11361102604, 2575.08542844046, 15.284795935294, 79.0129233383983, 112.267050572496, 1479.74891949238 ),
      ( 217, 11164.5069704308, 9999999.99993237, 4312.05677240709, 5207.75239303927, 28.1045667890272, 82.4303374353416, 116.725633109468, 1350.23347398525 ),
      ( 240, 10787.184903052, 9999999.99993178, 7020.90464539684, 7947.93056455972, 40.1025860970288, 86.3384452568089, 121.634186683137, 1226.42399946823 ),
      ( 263, 10399.5201972014, 9999999.99993262, 9845.43333488204, 10807.0161589265, 51.4748574871569, 90.7391849754356, 127.075085924775, 1107.64486298085 ),
      ( 286, 9997.78008165153, 9999999.99994243, 12797.5883404089, 13797.8103815293, 62.3731405476956, 95.5807551123764, 133.093099412516, 993.488023306788 ),
      ( 309, 9577.05460091034, 9999999.99995974, 15889.8581357671, 16934.0205026612, 72.9169724276516, 100.783283661525, 139.727991274306, 883.583929845092 ),
      ( 332, 9130.72193470858, 9999999.99998186, 19135.3410862214, 20230.5447373115, 83.2038142303795, 106.261471097524, 147.049422268962, 777.565765177854 ),
      ( 355, 8649.66081249694, 9999999.99999708, 22548.4550036901, 23704.5697019161, 93.3181628137924, 111.942251948886, 155.192925050533, 675.168749381903 ),
      ( 378, 8121.13961110945, 9999999.99999991, 26146.1730864915, 27377.5273641991, 103.34014621263, 117.777137322697, 164.398911223796, 576.455298513581 ),
      ( 401, 7527.48917337273, 10000000.0000001, 29949.543616292, 31278.0078318732, 113.354033047169, 123.748028206263, 175.05781001209, 482.254549988208 ),
      ( 424, 6845.48519304731, 10000000.000015, 33984.7506488899, 35445.5674818839, 123.456548021345, 129.831599863664, 187.718022808718, 394.886487501109 ),
      ( 447, 6052.16775613336, 9999999.99999998, 38277.2786272691, 39929.5791587383, 133.751751627049, 135.90883592348, 202.403163312549, 319.345488039392 ),
      ( 470, 5165.14900653247, 10000000, 42801.8502218924, 44737.9027902409, 144.238471200814, 141.614123977651, 214.327848240837, 265.474373738789 ),
      ( 493, 4321.76204355133, 10000000, 47371.9096133098, 49685.7806453629, 154.516543460536, 146.516170824128, 213.652969292574, 241.55708388491 ),
      ( 516, 3665.65594705865, 9999999.9999646, 51779.784469461, 54507.8091789236, 164.077691111741, 150.783226687471, 205.401771698674, 239.243008893931 ),
      ( 539, 3193.7892035408, 9999999.99999914, 56015.8285984736, 59146.905624131, 172.874675903415, 154.834016319816, 198.508861705607, 246.161063140357 ),
      ( 562, 2849.72551436157, 9999999.99999998, 60153.8889165004, 63662.9988113319, 181.080048695147, 158.847624537207, 194.659785105663, 256.200346965573 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new(double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 150.49, 25.5756433308858, 12139.4664722992, 0.0204415399995958 ),
      ( 187.25, 1402.04750551938, 11531.4162362802, 0.902067226952112 ),
      ( 224.01, 17627.4950759464, 10900.4480509896, 9.57540306165717 ),
      ( 260.77, 98845.9721157599, 10228.8008632096, 47.5211270695752 ),
      ( 297.53, 344365.426566225, 9487.38070153898, 154.296675709285 ),
      ( 334.29, 892264.74881375, 8619.34216094366, 396.4474864291 ),
      ( 371.05, 1910074.00744664, 7473.90031308557, 928.419401261456 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa
      _testDataMeltingLine = new(double temperature, double pressure)[]
     {
      ( 113.73, 0.0251188643150958 ),
      ( 113.73, 0.0398107170553497 ),
      ( 113.730000000001, 0.0630957344480193 ),
      ( 113.730000000001, 0.1 ),
      ( 113.730000000002, 0.158489319246111 ),
      ( 113.730000000004, 0.251188643150958 ),
      ( 113.730000000006, 0.398107170553497 ),
      ( 113.73000000001, 0.630957344480193 ),
      ( 113.730000000017, 1 ),
      ( 113.730000000027, 1.58489319246111 ),
      ( 113.730000000042, 2.51188643150958 ),
      ( 113.73000164479, 3.98107170553497 ),
      ( 113.73000261238, 6.30957344480193 ),
      ( 113.730004145907, 10 ),
      ( 113.730006576382, 15.8489319246111 ),
      ( 113.730010428424, 25.1188643150958 ),
      ( 113.730016533495, 39.8107170553497 ),
      ( 113.730026209371, 63.0957344480193 ),
      ( 113.730041544575, 100 ),
      ( 113.73006584917, 158.489319246111 ),
      ( 113.730104369196, 251.188643150958 ),
      ( 113.730165418915, 398.107170553497 ),
      ( 113.730262175178, 630.957344480194 ),
      ( 113.730415520951, 999.999999999999 ),
      ( 113.730658551173, 1584.89319246111 ),
      ( 113.731043760337, 2511.88643150958 ),
      ( 113.731654231485, 3981.07170553497 ),
      ( 113.732621728686, 6309.57344480194 ),
      ( 113.734155022102, 9999.99999999999 ),
      ( 113.736584911629, 15848.9319246111 ),
      ( 113.740435482637, 25118.8643150958 ),
      ( 113.746536859596, 39810.7170553497 ),
      ( 113.756203459324, 63095.7344480194 ),
      ( 113.771515377742, 99999.9999999999 ),
      ( 113.795761541323, 158489.319246111 ),
      ( 113.834135023067, 251188.643150958 ),
      ( 113.894817549484, 398107.170553497 ),
      ( 113.990655143376, 630957.344480194 ),
      ( 114.141707570059, 999999.999999999 ),
      ( 114.379033099969, 1584893.19246111 ),
      ( 114.75008125491, 2511886.43150958 ),
      ( 115.325859374799, 3981071.70553497 ),
      ( 116.209313792616, 6309573.44480194 ),
      ( 117.542736425036, 9999999.99999999 ),
      ( 119.509441281895, 15848931.9246112 ),
      ( 122.322927495573, 25118864.3150958 ),
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
