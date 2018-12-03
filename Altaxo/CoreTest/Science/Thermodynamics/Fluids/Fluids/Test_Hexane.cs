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
  /// Tests and test data for <see cref="Hexane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Hexane : FluidTestBase
  {

    public Test_Hexane()
    {
      _fluid = Hexane.Instance;

      _testDataMolecularWeight = 0.08617536;

      _testDataTriplePointTemperature = 177.83;

      _testDataTriplePointPressure = 1.277;

      _testDataTriplePointLiquidMoleDensity = 8839.37936679518;

      _testDataTriplePointVaporMoleDensity = 0.000863774629696469;

      _testDataCriticalPointTemperature = 507.82;

      _testDataCriticalPointPressure = 3042947.90932014;

      _testDataCriticalPointMoleDensity = 2705.8779;

      _testDataNormalBoilingPointTemperature = 341.864512243106;

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
      ( 200, 0.00115191050025021, 1.9155002798934, 8764.86246263019, 10427.7523134279, 105.505537382704, 102.26522349619, 110.580120494236, 144.448536190891 ),
      ( 250, 0.000921524291501047, 1.91550011243564, 14254.011778795, 16332.6331782543, 131.795091254471, 117.55817201745, 125.872827628633, 160.707109006195 ),
      ( 300, 0.000767935740766981, 1.91550005527033, 20557.693872653, 23052.0432740199, 156.248794231359, 134.954447359046, 143.269024705935, 175.294919498252 ),
      ( 350, 0.000658230210694576, 1.91550003106259, 27776.3247094959, 30686.4008499412, 179.747998366464, 153.942796256773, 162.257342303826, 188.661351165084 ),
      ( 400, 0.000575951251466077, 1.9155000191359, 35956.0170439681, 39281.8193827251, 202.674546367296, 173.189256044258, 181.503787546694, 201.11243683481 ),
      ( 450, 0.000511956578486233, 1.91550001257108, 45082.887089758, 48824.4153620089, 225.132243016083, 191.711777656059, 200.026301588535, 212.839410120705 ),
      ( 500, 0.000460760872452753, 1.91550000864331, 55107.0403968202, 59264.2944588819, 247.115234486142, 209.0363786916, 217.350898318354, 223.96567538283 ),
      ( 550, 0.000418873492469339, 1.91550000613783, 65964.3123327639, 70537.2921001051, 268.591752510931, 225.03361779932, 233.348134796048, 234.577588721701 ),
      ( 600, 0.000383967350920034, 1.91550000445762, 77588.9511902135, 82577.6566097442, 289.535444455022, 239.74564518643, 248.060160480349, 244.740305607104 ),
      ( 225, 8353.49614276803, 999.999999325723, -22190.5093840979, -22190.3896737417, -78.814676178041, 129.923853940641, 171.961539115886, 1388.4057833494 ),
      ( 242.664582558974, 8173.41200542528, 1000.00000416252, -19113.8287185699, -19113.7063706443, -65.6529074053864, 134.285360026887, 176.467098943483, 1303.58959638526 ),
      ( 250, 0.481826058337339, 1000.00000000073, 14244.5132390662, 16319.9510089774, 79.7267416815045, 117.645832123865, 126.036788658933, 160.505420905662 ),
      ( 300, 0.401207973432792, 1000.00000000009, 20552.4261620453, 23044.8990594405, 104.20088701066, 134.992065214495, 143.341829377505, 175.183081484431 ),
      ( 350, 0.343778922315234, 1000.00000000002, 27773.0363597673, 30681.8825253942, 127.708256415364, 153.961215699229, 162.294572516611, 188.591946418487 ),
      ( 400, 0.300757621589374, 1000.00000000001, 35953.7756541045, 39278.7121751324, 150.638596638526, 173.199195814956, 181.524941577793, 201.066020542065 ),
      ( 450, 0.267316177521463, 1000, 45081.2533920146, 48822.1418383179, 173.098266454097, 191.717559896963, 200.039347794716, 212.806740799277 ),
      ( 500, 0.240571677443013, 1000, 55105.7862239786, 59262.5515199968, 195.082380063947, 209.039951134919, 217.359488915386, 223.941854474111 ),
      ( 550, 0.218694055859838, 1000, 65963.3096809604, 70535.9076698189, 216.559583447553, 225.035937489004, 233.354101248351, 234.559794024278 ),
      ( 600, 0.200464960292759, 999.999999999999, 77588.1236084456, 82576.5265619573, 237.503719097226, 239.747216169271, 248.064490486762, 244.726800833513 ),
      ( 177.83, 8839.39093778791, 1971.25271153584, -30053.3301717256, -30053.1071639725, -117.985505674096, 118.906934100794, 161.664802087596, 1638.92467535441 ),
      ( 225, 8353.50388128272, 1971.25454445196, -22190.5413020452, -22190.3053226798, -78.8148180363166, 129.923903557953, 171.961464207984, 1388.41144109416 ),
      ( 250, 8098.45264278284, 1971.25454860329, -17812.041922096, -17811.7985108377, -60.3679817086331, 136.194269982784, 178.490785035861, 1269.36333659854 ),
      ( 252.847865270425, 8069.2902564699, 1971.25454744805, -17302.5738720122, -17302.3295810666, -58.3416344475284, 136.952080287619, 179.301621906784, 1256.21166839974 ),
      ( 275, 0.863927823388174, 1971.25454475466, 17283.2856933033, 19565.0209163035, 86.4592496260055, 126.092576379135, 134.507605057758, 167.886869767941 ),
      ( 325, 0.730298309848873, 1971.25454475161, 24040.0302879649, 26739.2759498638, 110.386580859678, 144.385918423139, 152.750548114767, 181.936382907789 ),
      ( 375, 0.632640209099354, 1971.2545447512, 31740.4442737176, 34856.3615303167, 133.584982864185, 163.634468222625, 171.97735978437, 194.876088636128 ),
      ( 425, 0.558080642076317, 1971.25454475111, 40399.8785563043, 43932.0823206512, 156.279144644761, 182.595901249503, 190.928088555247, 206.981135980487 ),
      ( 475, 0.499267748767376, 1971.2545447511, 49983.8620020794, 53932.1533740293, 178.505924579028, 200.546585339705, 208.872941023475, 218.416753371865 ),
      ( 525, 0.451680615472298, 1971.25454475109, 60433.4976544289, 64797.7640790348, 200.241377531618, 217.206352393525, 225.529266827475, 229.290946344028 ),
      ( 575, 0.412381425522957, 1971.25454475109, 71682.9048272215, 76463.0777999766, 221.455084955343, 232.548106535566, 240.86885478957, 239.681064067801 ),
      ( 177.83, 8839.43809450551, 9999.9981678424, -30053.5221149564, -30052.3908215347, -117.98658505802, 118.907383708481, 161.664586372872, 1638.96320494287 ),
      ( 200, 8609.23610943647, 10000.0021680786, -26417.8512691157, -26416.6897256243, -98.7246287155978, 124.133953009757, 166.323768439476, 1515.79602128061 ),
      ( 225, 8353.56784801908, 10000.0000000234, -22190.8051349274, -22189.6080416396, -78.81599065129, 129.924313709626, 171.960845079995, 1388.45820827696 ),
      ( 250, 8098.52841849484, 10000.0000030682, -17812.355102162, -17811.1203099274, -60.3692344565592, 136.194663242829, 178.489863610684, 1269.41557327038 ),
      ( 275, 7840.83634818284, 10000.0000016783, -13257.4116348002, -13256.1362606491, -43.0095306328946, 143.171276414147, 186.089880617638, 1156.29379934138 ),
      ( 281.91790912366, 7768.6253251523, 10000.0000011885, -11962.1866941614, -11960.8994651367, -38.3579632805411, 145.227904103062, 188.382537593575, 1125.81519979065 ),
      ( 300, 4.0397144299829, 10000.0000009013, 20504.5585477863, 22979.981049605, 84.896223145427, 135.333952613251, 144.009853983132, 174.1641749081 ),
      ( 350, 3.45100270063463, 10000.0000001565, 27743.256361935, 30640.964902794, 108.478230520071, 154.128027472248, 162.633587862611, 187.962499825633 ),
      ( 400, 3.01467270533867, 10000.0000000362, 35933.5105940329, 39250.6202697623, 131.443040315215, 173.289063877838, 181.716865589529, 200.646029345065 ),
      ( 450, 2.67729730241183, 10000.0000000102, 45066.4960194161, 48801.6060466073, 153.920594581891, 191.769791737503, 200.157475336438, 212.511526415476 ),
      ( 500, 2.40827266887032, 10000.0000000033, 55094.4632897376, 59246.8170199712, 175.914862758911, 209.072204410688, 217.437179268318, 223.726776548224 ),
      ( 550, 2.18858922653182, 10000.0000000012, 65954.2606814687, 70523.4141245969, 197.398261993646, 225.056873446474, 233.408017705883, 234.399217095927 ),
      ( 600, 2.00574655646508, 10000.0000000004, 77580.6563841258, 82566.3311533371, 218.346406239592, 239.761391656938, 248.103598146098, 244.604985939907 ),
      ( 177.83, 8839.96654001709, 99999.9981806478, -30055.6728992391, -30044.3606394327, -117.998681758237, 118.912423223682, 161.662172879444, 1639.39498299999 ),
      ( 200, 8609.84493423241, 100000.00216474, -26420.348186725, -26408.7335754365, -98.7371155621233, 124.138760500565, 166.319452481256, 1516.26803268593 ),
      ( 225, 8354.28457306573, 99999.9999995522, -22193.7610969635, -22181.7911910877, -78.8291307704458, 129.928911007295, 171.953915576476, 1388.98223508139 ),
      ( 250, 8099.37737498946, 100000.000003407, -17815.8636285646, -17803.5170005, -60.3832714091076, 136.199071341309, 178.47955182827, 1270.00083143752 ),
      ( 275, 7841.85100376285, 100000.0000015, -13261.597032522, -13248.8449412168, -43.0247535607037, 143.175480113056, 186.074984185866, 1156.95270745939 ),
      ( 300, 7578.42695971219, 100000.000001161, -8504.17180301545, -8490.97645251161, -26.4706607669457, 150.839799352604, 194.723183783401, 1048.25581034151 ),
      ( 325, 7305.40369265601, 100000.000002015, -3518.32464157215, -3504.63614409698, -10.5109859567875, 159.052958262542, 204.33868553229, 942.5765550578 ),
      ( 340.445955093102, 7129.93958747149, 99999.9999997233, -313.481545756943, -299.456181478199, -0.877226072224813, 164.32510553957, 210.738542509745, 878.191366370984 ),
      ( 350, 35.954657294766, 99999.9999999999, 27431.4887584751, 30212.7696139752, 88.4344072145413, 155.878791887609, 166.407628858951, 181.273774426405 ),
      ( 400, 30.8946245962125, 99999.9999999999, 35725.242001307, 38962.051035467, 111.774646269098, 174.212984389017, 183.76274310062, 196.295334303958 ),
      ( 450, 27.2004131363193, 100000, 44916.2795076712, 48592.6942554485, 134.440780680152, 192.301511907952, 201.389493969172, 209.495397774315 ),
      ( 500, 24.3438622803052, 100000.000035324, 54979.8499157409, 59087.6615227851, 156.540293336887, 209.398724950171, 218.237275571476, 221.547917302437 ),
      ( 550, 22.0530841671224, 100000.000012239, 65862.9880529438, 70397.5011965213, 178.087247630922, 225.268097264421, 233.958848163363, 232.781701345135 ),
      ( 600, 20.1681357012241, 100000.000004576, 77505.5164436758, 82463.8329428308, 199.0762353267, 239.904089108857, 248.500978926313, 243.38297969962 ),
      ( 177.83, 8839.9743176042, 101324.998179516, -30055.7045519675, -30044.2424148007, -117.998859808887, 118.912497410211, 161.66213741061, 1639.40133797932 ),
      ( 200, 8609.85389436135, 101325.002163718, -26420.3849316388, -26408.6164390015, -98.7372993475281, 124.138831271362, 166.319389034548, 1516.27497949207 ),
      ( 225, 8354.29512040723, 101325.000000009, -22193.8045943088, -22181.6761024924, -78.8293241595899, 129.928978684402, 171.953813706033, 1388.98994690152 ),
      ( 250, 8099.38986710086, 101325.000002592, -17815.9152526139, -17803.4050510228, -60.3834779819811, 136.199136235053, 178.479400250622, 1270.00944362252 ),
      ( 275, 7841.86593228829, 101325.000001936, -13261.6586092844, -13248.7375773671, -43.0249775650647, 143.175542002106, 186.074765260948, 1156.96240232068 ),
      ( 300, 7578.44502292202, 101325.000001161, -8504.24584020204, -8490.87568317185, -26.470907663099, 150.839857311612, 194.722869170425, 1048.26684061686 ),
      ( 325, 7305.42592585355, 101325.000002195, -3518.41473291208, -3504.54490505664, -10.5112632899419, 159.053010235487, 204.338227334368, 942.58928472329 ),
      ( 340.864512243106, 7125.12238569201, 101325.000000178, -225.35057523416, -211.129766872517, -0.61848788026434, 164.469616792605, 210.916304265454, 876.465930911737 ),
      ( 350, 36.4545098180511, 101325, 27426.6894032273, 30206.1808984011, 88.3110159865809, 155.905867075313, 166.469319419413, 181.169372929261 ),
      ( 400, 31.3156968751575, 101325, 35722.0953475853, 38957.6931503083, 111.657256255077, 174.226953161342, 183.794740345467, 196.229119241391 ),
      ( 450, 27.5673937914061, 101325, 44914.0309511957, 48589.5688263643, 134.326308971661, 192.309472127329, 201.408358403862, 209.450096665704 ),
      ( 500, 24.6703921930923, 101325.000037273, 54978.1433940912, 59085.2933430751, 156.427423529582, 209.403587173067, 218.249380401223, 221.515451027986 ),
      ( 550, 22.34781411278, 101325.000012908, 65861.6335662956, 70395.6340507082, 177.975335786061, 225.271232462799, 233.967119469128, 232.757726580148 ),
      ( 600, 20.4370279541795, 101325.000004824, 77504.4038250998, 82462.3165035968, 198.964935258973, 239.906202749193, 248.506916039052, 243.364936288922 ),
      ( 177.83, 8845.23410128261, 999999.998301265, -30077.0957376191, -29964.0405050666, -118.119357994186, 118.962771690132, 161.638499313418, 1643.69991975773 ),
      ( 200, 8615.91029882429, 1000000.00212155, -26445.2055688607, -26329.1412219213, -98.8616270701022, 124.186789994208, 166.27697724537, 1520.97167246898 ),
      ( 225, 8361.41931969567, 999999.999999498, -22223.1671724879, -22103.5702521846, -78.9600737722188, 129.974844433519, 171.885693133397, 1394.20043141555 ),
      ( 250, 8107.82008961076, 1000000.00000241, -17850.7351216738, -17727.3974071031, -60.5230397592868, 136.243127631284, 178.378139895526, 1275.82336761122 ),
      ( 275, 7851.92860389334, 1000000.00000102, -13303.1476390368, -13175.7903933908, -43.1761733434926, 143.217524878208, 185.928800392216, 1163.50003779556 ),
      ( 300, 7590.6016279718, 1000000.00000087, -8554.06053571885, -8422.3186726871, -26.6373435641032, 150.879236092168, 194.513740561312, 1055.69404836012 ),
      ( 325, 7320.35643495946, 1000000.00000143, -3578.91405672828, -3442.30868663649, -10.6978865618389, 159.088458051564, 204.035020081915, 951.143234397014 ),
      ( 350, 7036.87347668084, 1000000.00095805, 1644.51485660586, 1786.6234228991, 4.79758299494145, 167.668881419505, 214.423416050333, 848.565136456265 ),
      ( 375, 6734.15899848472, 1000000.0003009, 7138.0358106, 7286.53245294627, 19.9712776017312, 176.459086517793, 225.741511263379, 746.423930029959 ),
      ( 400, 6402.81290981414, 999999.999999954, 12928.1475247611, 13084.3288803755, 34.9341541239492, 185.34372597746, 238.358054059357, 642.567561936874 ),
      ( 425, 6025.56970877165, 1000000.00000001, 19058.5476060278, 19224.5070170598, 49.8193874563909, 194.286118211254, 253.461325455545, 533.302623080868 ),
      ( 437.240650414559, 5813.7713789867, 1000000.00000003, 22210.1080200454, 22382.1134077382, 57.1434428683645, 198.715072699279, 262.784210338738, 475.657643376661 ),
      ( 450, 338.458286937607, 1000000.00000478, 43013.3867348182, 45967.9605733046, 110.883984841675, 199.101397044538, 224.450555295681, 169.628102783194 ),
      ( 500, 277.020609861478, 1000000.00000006, 53660.9731004727, 57270.8128178139, 134.696299719652, 213.153621214957, 229.699646973923, 196.29283077105 ),
      ( 550, 240.030031382372, 1000000, 64861.6918824049, 69027.8372361376, 157.099030645458, 227.582796086878, 240.944593274056, 215.295434085224 ),
      ( 600, 213.834314956451, 999999.999999999, 76704.216923824, 81380.7348166779, 178.588141233392, 241.426128653341, 253.201100475732, 230.756300133794 ),
      ( 200, 8630.53255291337, 3195095.30313094, -26504.995618699, -26134.7872586075, -99.1626360860284, 124.303584280396, 166.178435225131, 1532.32078882626 ),
      ( 220, 8428.75263923837, 3195095.30329327, -23147.1729275633, -22768.1019736455, -83.1219778487832, 128.904701545794, 170.558478353666, 1431.09077620319 ),
      ( 240, 8228.29537988971, 3195095.30358473, -19697.2694569752, -19308.9635982194, -68.0758454010255, 133.765699543687, 175.456107885529, 1335.72719725951 ),
      ( 260, 8027.58429989498, 3195095.30386504, -16143.5545481231, -15745.5400042077, -53.8174991034232, 139.050687611552, 180.997885053829, 1244.87989238209 ),
      ( 280, 7825.1512243642, 3195095.30407915, -12472.9107298032, -12064.5997320386, -40.1809882264905, 144.799787691782, 187.204900420306, 1157.65792796192 ),
      ( 300, 7619.53327436455, 3195095.30422771, -8672.50502716717, -8253.17549749933, -27.0356426348296, 150.975913314529, 194.036370383159, 1073.40172945173 ),
      ( 320, 7409.17216014848, 3195095.30432417, -4730.65988268738, -4299.42475475911, -14.2797461021224, 157.501342097626, 201.425995698113, 991.5518374464 ),
      ( 340, 7192.29686512945, 3195095.30439237, -637.079163693907, -192.840645136196, -1.83415537104831, 164.283781476001, 209.310783287807, 911.573479366868 ),
      ( 360, 6966.76447470023, 3195095.30445742, 3617.43851779545, 4076.05819929328, 10.3637476120284, 171.233416917282, 217.655007655348, 832.908090723378 ),
      ( 380, 6729.81588110291, 3195095.3045462, 8041.74501105606, 8516.512131137, 22.3657500204381, 178.273272443076, 226.474922415855, 754.92889883329 ),
      ( 400, 6477.6588968783, 3195095.30466687, 12645.6417310365, 13138.8901955715, 34.2185402174618, 185.345536516105, 235.875139797261, 676.877553078801 ),
      ( 420, 6204.67649784449, 3195095.30478613, 17442.1450070308, 17957.0945464461, 45.9705588060324, 192.416999951504, 246.122338851214, 597.746459885846 ),
      ( 440, 5901.71765634291, 3195095.30464727, 22451.9786788661, 22993.3626437891, 57.6828151724593, 199.488879046827, 257.833006660017, 516.027141867755 ),
      ( 460, 5551.69258058011, 3195095.30478623, 27714.5150882725, 28290.0324207636, 69.4527153823794, 206.625692315064, 272.576676433453, 429.088745300436 ),
      ( 480, 5114.4488097322, 3195095.30478615, 33324.0565432339, 33948.775926231, 81.4909797450897, 214.069891763181, 295.67270477784, 331.239907919745 ),
      ( 500, 4428.75516234361, 3195095.30478615, 39658.304508225, 40379.7477101327, 94.6080749233598, 223.078655211318, 367.830116482568, 203.770149849693 ),
      ( 520, 1523.5704933351, 3195095.30478615, 52425.4946214401, 54522.6048757822, 122.306630176127, 232.555620997252, 418.568633035143, 116.848211573791 ),
      ( 540, 1151.60330368896, 3195095.30478614, 58559.1225323954, 61333.5981652381, 135.171231220362, 233.73112215916, 303.435331811888, 149.165077981357 ),
      ( 560, 990.40744302762, 3195095.30478614, 63922.2402584309, 67148.2815480833, 145.746825613916, 237.200585915259, 282.194916249146, 169.445432590229 ),
      ( 580, 888.706458863713, 3195095.30479627, 69116.190414751, 72711.4104932474, 155.508391169174, 241.363921911701, 275.371435439332, 184.831425570238 ),
      ( 600, 815.309023800936, 3195095.30478822, 74276.9382122331, 78195.8146278195, 164.805047233004, 245.815800418245, 273.606923537812, 197.425047314508 ),
      ( 200, 8674.40693884829, 9999999.99900011, -26683.2074625065, -25530.3908988501, -100.072930215388, 124.662433673924, 165.914365647841, 1566.4615695767 ),
      ( 220, 8478.35261469026, 9999999.99913719, -23349.715029689, -22170.2406136556, -84.0633174236955, 129.250926040634, 170.165879519227, 1467.94037872445 ),
      ( 240, 8284.49073067144, 9999999.99935763, -19927.4959391984, -18720.4211382894, -69.0576323206848, 134.10104166364, 174.912429207373, 1375.58918268808 ),
      ( 260, 8091.45315513584, 9999999.99955834, -16405.5032968276, -15169.6313455439, -54.8497511921693, 139.37582629412, 180.272199359445, 1288.12285078817 ),
      ( 280, 7898.044677797, 9999999.9997079, -12771.5011298477, -11505.3649648017, -41.2749213065408, 145.114308971087, 186.255021099228, 1204.73301108556 ),
      ( 300, 7703.16772198804, 9999999.99980753, -9013.8141382373, -7715.64689578412, -28.2043425455327, 151.278124210862, 192.804333452869, 1124.86649200719 ),
      ( 320, 7505.76423169495, 9999999.99987111, -5122.31758527802, -3790.00821728007, -15.539035827062, 157.787886032096, 199.830914345995, 1048.10314333491 ),
      ( 340, 7304.76617212247, 9999999.9999122, -1088.84977435115, 280.119438938071, -3.20380685121025, 164.548954480406, 207.237240581551, 974.09432589857 ),
      ( 360, 7099.048840047, 9999999.99993994, 3092.77061872976, 4501.41003300287, 8.8582114489716, 171.467976897832, 214.933448743117, 902.5368013838 ),
      ( 380, 6887.38258297219, 9999999.99996016, 7426.96952630019, 8878.89990471178, 20.6902193635872, 178.46230969108, 222.84677936828, 833.166015964767 ),
      ( 400, 6668.37932053891, 9999999.99997659, 11916.7702791217, 13416.3850309665, 32.3255759389579, 185.464454308336, 230.926491761892, 765.760027752117 ),
      ( 420, 6440.43116002634, 9999999.99998909, 16564.1942778261, 18116.8853557241, 43.7908546570687, 192.423319907296, 239.145882414162, 700.150903772 ),
      ( 440, 6201.64070547258, 9999999.99999664, 21370.6527616157, 22983.1292778983, 55.1082349483437, 199.303684140017, 247.502366936693, 636.244996499059 ),
      ( 460, 5949.74954757745, 9999999.99999954, 26337.2772024626, 28018.0202186239, 66.2973221807695, 206.084757911392, 256.015436090963, 574.058277733551 ),
      ( 480, 5682.09074895858, 9999999.99999992, 31465.1081816151, 33225.0237552678, 77.376411590361, 212.758226446934, 264.720075420857, 513.778717868409 ),
      ( 500, 5395.64047887525, 9999999.99999996, 36754.9786520437, 38608.3267465195, 88.3630299763278, 219.325314589187, 273.648923531744, 455.872152059932 ),
      ( 520, 5087.35187758845, 10000000, 42206.7645593875, 44172.4237550986, 99.273250594803, 225.790906014565, 282.790257845541, 401.236414378199 ),
      ( 540, 4755.11872370893, 10000000.0000003, 47817.5121162712, 49920.5090299214, 110.118886781079, 232.1506300306, 292.009980746215, 351.338998705839 ),
      ( 560, 4399.72354544636, 9999999.99999993, 53578.211292938, 55851.0813714114, 120.901946436299, 238.367932784504, 300.959760970098, 308.11514673721 ),
      ( 580, 4027.40962957817, 10000000, 59470.1486834236, 61953.1342547342, 131.607570524883, 244.353455613289, 309.035911316232, 273.385129968971 ),
      ( 600, 3651.46475165497, 10000000.0000046, 65462.2737628553, 68200.9007742408, 142.197411744852, 249.984578980808, 315.359959034468, 248.158467729146 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new (double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 219.07875, 142.433484667115, 8413.86317266773, 0.0782234513438748 ),
      ( 260.3275, 2938.84274086748, 7992.50922382594, 1.36299724294819 ),
      ( 301.57625, 23378.2504742441, 7560.4805552658, 9.49022262377584 ),
      ( 342.825, 104417.542530783, 7102.43265677561, 38.5681856641099 ),
      ( 384.07375, 323130.809372551, 6597.55386239907, 113.558272898577 ),
      ( 425.3225, 785203.711604845, 6008.65631006091, 278.101230838866 ),
      ( 466.57125, 1623520.89266222, 5237.91050156969, 640.2689359882 ),
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