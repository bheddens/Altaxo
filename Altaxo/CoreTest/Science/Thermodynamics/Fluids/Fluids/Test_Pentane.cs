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
  /// Tests and test data for <see cref="Pentane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Pentane : FluidTestBase
  {

    public Test_Pentane()
    {
      _fluid = Pentane.Instance;

      _testDataMolecularWeight = 0.07214878;

      _testDataTriplePointTemperature = 143.47;

      _testDataTriplePointPressure = 0.076322;

      _testDataTriplePointLiquidMoleDensity = 10566.4030720912;

      _testDataTriplePointVaporMoleDensity = 6.39813368355026E-05;

      _testDataCriticalPointTemperature = 469.7;

      _testDataCriticalPointPressure = 3370998.11650181;

      _testDataCriticalPointMoleDensity = 3215.5776;

      _testDataNormalBoilingPointTemperature = 309.21362367526;

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
      ( 150, 9.17938179478089E-05, 0.114483001815484, 8810.72196989037, 10057.897480997, 126.669513188569, 72.5912542125254, 80.9058070559296, 138.802349174933 ),
      ( 200, 6.8845324810373E-05, 0.114483000555251, 12767.5496949906, 14430.4512917305, 151.741197004408, 85.2343015502314, 93.5488235350621, 159.048906791113 ),
      ( 250, 5.50762520018749E-05, 0.114483000235452, 17335.3604668884, 19413.987753138, 173.930301272477, 97.7651284783254, 106.079643121676, 176.806338785932 ),
      ( 300, 4.58968743451955E-05, 0.114483000121835, 22578.7612432857, 25073.1141105593, 194.525695935515, 112.289065580195, 120.603577807287, 192.697375761535 ),
      ( 350, 3.93401771299108E-05, 0.114483000071607, 28586.8142884274, 31496.8926974177, 214.298852404169, 128.156196225337, 136.470707466425, 207.246764809263 ),
      ( 400, 3.44226545927336E-05, 0.114483000045787, 35397.5367360445, 38723.3406695376, 233.574111238523, 144.227888429099, 152.5423992006, 220.802753443689 ),
      ( 450, 3.05979149920027E-05, 0.114483000031001, 42999.9139713637, 46741.4434207044, 252.444110220635, 159.732767867091, 168.047278387282, 233.576323373572 ),
      ( 500, 2.75381233803605E-05, 0.114483000021836, 51355.3455200324, 55512.6004803861, 270.913288497412, 174.318020979792, 182.632531352709, 245.70090609034 ),
      ( 550, 2.50346575512488E-05, 0.114483000015805, 60414.7657328129, 64987.7462012473, 288.964570889641, 187.889973977906, 196.204484258072, 257.269224378612 ),
      ( 600, 2.29484360461749E-05, 0.11448300001165, 70127.8665672537, 75116.5725418699, 306.583093642394, 200.474509119269, 208.78901933754, 268.351300873186 ),
      ( 175, 10166.8582769753, 507.229054895501, -20607.1115726388, -20607.0616821966, -86.6211581945666, 105.250032876884, 142.793800652205, 1638.71209835986 ),
      ( 200, 9857.27817492607, 507.229060618699, -17013.1406255759, -17013.0891682616, -67.4280297495297, 107.278260889229, 144.954016961271, 1500.45395206573 ),
      ( 209.60852810086, 9738.71035913912, 507.229060831836, -15614.732570666, -15614.6804868641, -60.5989725095926, 108.321042311564, 146.157886000886, 1449.46801139009 ),
      ( 225, 0.271318755998539, 507.229058954319, 14969.7650859252, 16839.2600903806, 93.2787775010165, 91.3181637040188, 99.6647620892091, 168.109538433194 ),
      ( 275, 0.221908747598858, 507.229058954292, 19864.2513687186, 22150.0065020457, 114.547891980348, 104.801990048763, 113.130453461376, 184.899402706977 ),
      ( 325, 0.187742080192421, 507.229058954288, 25482.2817263014, 28184.0151812329, 134.672346587608, 120.136908788717, 128.458673535936, 200.083593042407 ),
      ( 375, 0.162698637171647, 507.229058954286, 31890.8241541809, 35008.4228493633, 154.176441949837, 136.229249768021, 144.548046437138, 214.112824097414 ),
      ( 425, 0.143552253802918, 507.229058954288, 39101.1854050624, 42634.5960309287, 173.246053532564, 152.08320102667, 160.40049403339, 227.263163225042 ),
      ( 475, 0.128438620988064, 507.229058954288, 47086.0014163949, 51035.1956311274, 191.917757087343, 167.151458745538, 175.467907546408, 239.702533409602 ),
      ( 525, 0.116204710121279, 507.229058954287, 55799.8614250948, 60164.8226940908, 210.180496710045, 181.231351760795, 189.547286723069, 251.541726781792 ),
      ( 575, 0.106098930126659, 507.229058954287, 65192.3581797592, 69973.0761224262, 228.016967381193, 194.302384257529, 202.617985616074, 262.861090371151 ),
      ( 175, 10166.8617275957, 1000.00000103707, -20607.1219687537, -20607.023609985, -86.6212176010814, 105.250059312103, 142.793782787667, 1638.71446664056 ),
      ( 200, 9857.28227402514, 1000.00000135886, -17013.1531412536, -17013.0516934129, -67.4280923280774, 107.27828603702, 144.953986514171, 1500.45662280333 ),
      ( 218.084219941642, 9633.982871199, 1000.00000020156, -14370.8253459124, -14370.7215466828, -54.7815427510568, 109.371601091039, 147.396860076957, 1405.28038525768 ),
      ( 225, 0.535257468105491, 1000.00000000048, 14966.2594332288, 16834.5192139656, 87.6193634883661, 91.3531847411217, 99.7311111367684, 168.022044960832 ),
      ( 275, 0.437628999817974, 1000.00000000005, 19862.3877691663, 22147.4282953105, 108.897286304127, 104.815727337802, 113.157776628125, 184.851774927393 ),
      ( 325, 0.370196960384315, 1000.00000000001, 25481.1365233103, 28182.4012742738, 129.024994790998, 120.143215677777, 128.472036876481, 200.054027280696 ),
      ( 375, 0.320793942921514, 1000, 31890.0433474223, 35007.3091875839, 148.530531936342, 136.232491546375, 144.555455734188, 214.092900256895 ),
      ( 425, 0.283032610477459, 1000, 39100.6108881774, 42633.7726617026, 167.600873944399, 152.085016822244, 160.405014793212, 227.249001808358 ),
      ( 475, 0.253228549339439, 1000, 47085.5540841423, 51034.5558953858, 186.272987581879, 167.152547724903, 175.470880675684, 239.692104447786 ),
      ( 525, 0.229105086693659, 999.999999999999, 55799.4980390854, 60164.3072820034, 204.535976805767, 181.232042663517, 189.54936228975, 251.533863364132 ),
      ( 575, 0.209178930199824, 999.999999999998, 65192.0533606997, 69972.649566277, 222.372609526421, 194.302844034379, 202.619505820118, 262.855071839167 ),
      ( 150, 10482.326652512, 10000.0024488365, -24164.3453239983, -24163.3913370848, -108.553697401506, 104.084761678695, 142.005470839186, 1788.35476588166 ),
      ( 175, 10166.9247479639, 9999.99999364865, -20607.3118364782, -20606.3282548897, -86.6223025786679, 105.250542121542, 142.793456555103, 1638.75771971797 ),
      ( 200, 9857.35713734548, 10000.0000014772, -17013.3817177877, -17012.3672470871, -67.4292352319354, 107.278745333207, 144.953430502187, 1500.50539947276 ),
      ( 225, 9548.38722527557, 10000.0000004694, -13347.877856836, -13346.8305595528, -50.1638412262912, 110.321733867264, 148.530779353432, 1369.75765911262 ),
      ( 250, 9235.38758951231, 10000.0000002081, -9574.84230695674, -9573.75951536805, -34.267174336537, 114.442494996053, 153.5531880082, 1244.11114168979 ),
      ( 254.043642752677, 9184.07088327856, 10000.0000009921, -8952.03533625679, -8950.94649448628, -31.7958753481037, 115.206685417011, 154.498370532854, 1224.15283719273 ),
      ( 275, 4.4015832693892, 10000.0000005331, 19828.1366727984, 22100.0464353782, 89.6277024909582, 105.068468967773, 113.664132687312, 183.9748368842 ),
      ( 325, 3.71377633668972, 10000.0000000894, 25460.1495706048, 28152.8265369843, 109.815503934487, 120.258811423846, 128.718008999514, 199.511695836945 ),
      ( 375, 3.2142193605508, 10000.0000000206, 31875.7531439899, 34986.9284802952, 129.347540598111, 136.29182472441, 144.69143554131, 213.728097248912 ),
      ( 425, 2.83397574264378, 10000.0000000059, 39090.1036433996, 42618.7153564544, 148.431277407069, 152.11822694915, 160.487852321915, 226.989973943861 ),
      ( 475, 2.53454234163482, 10000.0000000019, 47077.3763744201, 51022.8618515149, 167.110901806394, 167.172456401183, 175.525308146997, 239.501469596254 ),
      ( 525, 2.29250971042667, 10000.0000000007, 55792.8567683735, 60154.8884555325, 185.378458945296, 181.244670408361, 189.58733503173, 251.390187676295 ),
      ( 575, 2.09276274417522, 10000.0000000003, 65186.4834930271, 69964.8560189301, 203.21805575076, 194.311245991355, 202.647306187214, 262.745139934691 ),
      ( 150, 10482.8586601689, 100000.002454152, -24165.9193181459, -24156.3799352642, -108.5641924709, 104.08990305796, 142.004058972788, 1788.73905315899 ),
      ( 175, 10167.5547449637, 100000.000001383, -20609.2097235619, -20599.3745171126, -86.6331495629195, 105.255369685854, 142.790199075472, 1639.19010953765 ),
      ( 200, 9858.10546962021, 100000.000001637, -17015.6663778405, -17005.5224409238, -67.4406606496872, 107.283337805735, 144.947878279448, 1500.99297305388 ),
      ( 225, 9549.28194093779, 100000.00000079, -13350.6325029053, -13340.1605113337, -50.1760864959899, 110.326126788313, 148.522197644956, 1370.31022890544 ),
      ( 250, 9236.4683272025, 100000.000000673, -9578.18026446809, -9567.35361553062, -34.2805289533506, 114.446682647056, 153.540387619166, 1244.74235466379 ),
      ( 275, 8914.97469921509, 100000.000001085, -5662.78829341577, -5651.57121166568, -19.356818188606, 119.567514895757, 159.945912048978, 1122.68494267917 ),
      ( 300, 8579.33730764582, 100000.000001443, -1570.87326362294, -1559.2173517016, -5.11842527715095, 125.518355039355, 167.654630760942, 1002.76750838339 ),
      ( 307.828437907925, 8470.25466504549, 100000.000002631, -248.157804073356, -236.351783598516, -0.765572830039555, 127.520502461265, 170.330538770664, 965.421049946034 ),
      ( 325, 38.4074366650691, 99999.9999999999, 25241.9502364097, 27845.6126696006, 89.9937706518499, 121.476660989854, 131.4253111601, 193.818419550103 ),
      ( 375, 32.7971292422038, 100000, 31729.6147191637, 34778.6620690555, 109.811140434171, 136.899990583887, 146.126162252028, 209.980279640912 ),
      ( 425, 28.7143753764042, 100000.000064048, 38983.5070083508, 42466.0832007001, 129.034891711528, 152.455400298901, 161.345752927644, 224.358738131388 ),
      ( 475, 25.5749075147829, 100000.000020372, 46994.7940225158, 50904.8765892883, 147.791896292265, 167.373616715481, 176.083096414378, 237.57823775094 ),
      ( 525, 23.0725369377187, 100000.000007244, 55725.9848379632, 60060.1419476552, 166.106112072447, 181.37189896854, 189.973899825449, 249.947370786862 ),
      ( 575, 21.0255951805387, 100000.000002776, 65130.5090310235, 69886.6169625287, 183.975815200709, 194.395741662751, 202.929025432628, 261.644881765884 ),
      ( 150, 10482.8664905608, 101325.002449908, -24165.9424830971, -24156.2767106158, -108.564346951727, 104.089978743229, 142.00403822736, 1788.74470930922 ),
      ( 175, 10167.5640171141, 101324.999996173, -20609.2376539516, -20599.2721401053, -86.633309216737, 105.255440751128, 142.790151183886, 1639.19647336351 ),
      ( 200, 9858.11648265012, 101325.000002045, -17015.6999981121, -17005.4216655138, -67.4408288080823, 107.283405410487, 144.947796645524, 1501.00014859976 ),
      ( 225, 9549.29510709976, 101325.000000672, -13350.6730361047, -13340.0623052744, -50.1762667081382, 110.326191456821, 148.522071480315, 1370.31836031101 ),
      ( 250, 9236.48422890968, 101325.000000864, -9578.22937564392, -9567.25929249435, -34.2807254731055, 114.446744297322, 153.540199470377, 1244.75164232162 ),
      ( 275, 8914.99418986844, 101325.000000322, -5662.8483363637, -5651.4826531291, -19.3570366163661, 119.567572658466, 159.945632776246, 1122.69567249466 ),
      ( 300, 8579.3617019594, 101325.00000181, -1570.94773525121, -1559.13741607809, -5.11867362711724, 125.518406732949, 167.654208745455, 1002.78010550563 ),
      ( 308.21362367526, 8464.85560521194, 101325.000002904, -182.6107761567, -170.640696012566, -0.552747715618568, 127.62054585259, 170.464990073424, 963.5974089757 ),
      ( 325, 38.936634974022, 101325, 25238.6104535817, 27840.9154567645, 89.8738928866838, 121.49572935901, 131.469307501825, 193.730540608778 ),
      ( 375, 33.241852623241, 101325, 31727.416965584, 34775.5322781812, 109.695785127783, 136.909171598755, 146.148398747949, 209.92368157307 ),
      ( 425, 29.1005663470638, 101325.000067596, 38981.9164037103, 42463.8074040145, 128.92168606253, 152.460436551925, 161.358803580699, 224.319429711201 ),
      ( 475, 25.9172516590164, 101325.000021489, 46993.5671211458, 50903.1251774777, 147.67986190994, 167.376606979338, 176.091497003702, 237.549690938554 ),
      ( 525, 23.3804691247768, 101325.000007638, 55724.9940431131, 60058.7394212271, 165.994778216717, 181.373785068502, 189.979685375208, 249.926046474206 ),
      ( 575, 21.3056543690735, 101325.000002926, 65129.6812006042, 69885.4609690963, 183.864930986787, 194.396992095278, 202.933223951011, 261.628670839401 ),
      ( 150, 10488.1644871048, 1000000.0023874, -24181.602478938, -24086.256910739, -108.668923682073, 104.141263391592, 141.990235621458, 1792.57157265465 ),
      ( 175, 10173.8341588145, 999999.999998053, -20628.1099794257, -20529.8186190214, -86.7413416227556, 105.303592247547, 142.758104525612, 1643.49999658563 ),
      ( 200, 9865.55889916509, 1000000.00000128, -17038.4031363887, -16937.0404046649, -67.5545549431348, 107.329213386877, 144.893137279829, 1505.84953669706 ),
      ( 225, 9558.18494481609, 1000000.0000004, -13378.0231190018, -13273.4007450078, -50.2980606503761, 110.370018325579, 148.437669867004, 1375.80926516924 ),
      ( 250, 9247.2089272518, 1000000.00000069, -9611.33372184654, -9503.19298361214, -34.413418923604, 114.488548719109, 153.414570731891, 1251.01657064147 ),
      ( 275, 8928.11893534966, 1000000.0000007, -5703.26524626018, -5591.25956989745, -19.5043366115066, 119.606795743099, 159.759722850621, 1129.92273047883 ),
      ( 300, 8595.75181593273, 1000000.00000099, -1620.97790351887, -1504.64136642302, -5.28584755216659, 125.55363917647, 167.374567651108, 1011.24704678672 ),
      ( 325, 8243.40574410531, 1000000.00000013, 2666.35765158942, 2787.66673560669, 8.45215222038897, 132.12708069145, 176.219184767961, 893.581936008425 ),
      ( 350, 7861.23381330652, 1000000.00043259, 7190.52860058438, 7317.73509566915, 21.8760444331482, 139.144031903438, 186.448236189032, 775.05089436842 ),
      ( 375, 7432.62012533543, 999999.999999802, 11992.1063507774, 12126.6484077017, 35.1424263184377, 146.480060510358, 198.706309611891, 652.757926447691 ),
      ( 397.072538428154, 6989.38548615291, 999999.999970672, 16517.2018112844, 16660.2759058456, 46.8858351325779, 153.215582974876, 212.869401031087, 537.400977104924 ),
      ( 400, 383.172541920767, 1000000.00000708, 33666.3665660017, 36276.1569100443, 96.1616013099218, 151.257273569643, 176.115676841094, 175.968942383325 ),
      ( 450, 307.685031810837, 1000000.00000005, 41825.5618783036, 45075.6387316191, 116.886560546214, 163.058398964292, 178.690379129173, 205.39643454358 ),
      ( 500, 263.754340492937, 1000000, 50465.1675660557, 54256.5743657735, 136.223164727747, 176.242921489843, 188.963580088214, 226.086094700274 ),
      ( 550, 233.073979905146, 1000000, 59699.6485295044, 63990.1317503554, 154.768619185582, 189.104335460614, 200.425113381022, 242.985830256587 ),
      ( 600, 209.804535258905, 1000000, 69531.0031277631, 74297.3443260884, 172.698331196939, 201.285749704835, 211.805190807731, 257.700278336683 ),
      ( 150, 10502.9985188824, 3539548.02054614, -24225.3074074289, -23888.3038351459, -108.962324447242, 104.285663352555, 141.954048418586, 1803.28614144718 ),
      ( 173, 10215.9700718906, 3539548.02060088, -20965.0823655213, -20618.6103226616, -88.6832518186979, 105.316789379049, 142.564404361825, 1666.85841452682 ),
      ( 196, 9934.88608756395, 3539548.0209401, -17677.8802760298, -17321.6056303274, -70.7923859634413, 107.070444882729, 144.322292769681, 1540.55050452963 ),
      ( 219, 9655.78939149268, 3539548.02127729, -14337.3797109352, -13970.8070903274, -54.6303935641198, 109.666544108503, 147.250412362102, 1421.28743175118 ),
      ( 242, 9375.33130238883, 3539548.02150904, -10916.4508545246, -10538.9124073652, -39.7325301401441, 113.175452043692, 151.372556945563, 1307.11903319192 ),
      ( 265, 9090.35919939882, 3539548.02163393, -7388.2236130912, -6998.8497782412, -25.761813535362, 117.563354747485, 156.643328417679, 1196.81161868993 ),
      ( 288, 8797.57782733611, 3539548.02167242, -3727.57883002353, -3325.2467232618, -12.4717071042121, 122.715056231084, 162.966895560461, 1089.47721099773 ),
      ( 311, 8493.18431535173, 3539548.02165706, 88.1688036279303, 504.920388220202, 0.319542846139218, 128.475299715425, 170.243316803742, 984.312616963229 ),
      ( 334, 8172.36563958865, 3539548.02165532, 4079.71974987889, 4512.83155345618, 12.74897815722, 134.684975260637, 178.421507387253, 880.438207064521 ),
      ( 357, 7828.46560355499, 3539548.02181402, 8267.51049062761, 8719.64864912021, 24.9261280101878, 141.206474553548, 187.563954973969, 776.785535297783 ),
      ( 380, 7451.38373398641, 3539548.02232698, 12675.2428876285, 13150.2617765608, 36.9500353240154, 147.941402628596, 197.959004453689, 671.963558541432 ),
      ( 403, 7023.99131513752, 3539548.0223269, 17337.2359973864, 17841.1586054197, 48.9317698878111, 154.851057317105, 210.402556578717, 563.984802519009 ),
      ( 426, 6512.2406940773, 3539548.02232695, 22317.3493131201, 22860.8716103758, 61.0408865334568, 162.012278230948, 227.18879641886, 449.470322385581 ),
      ( 449, 5825.16987588341, 3539548.02232692, 27782.4935438201, 28390.123552514, 73.6751721118792, 169.901136057828, 258.050460198037, 320.085909646846 ),
      ( 472, 3967.68068170701, 3539548.02232692, 35514.9484763981, 36407.0434573894, 91.0172452445513, 187.241064512671, 1185.89015779122, 110.600224253068 ),
      ( 495, 1449.01511388995, 3539548.02232691, 45781.0823264995, 48223.8091058116, 115.674185737696, 183.911948835189, 259.256596885926, 154.205047634447 ),
      ( 518, 1195.16288504755, 3539548.0223269, 50788.9016494698, 53750.4628446922, 126.59246834091, 186.751649817686, 229.008728960148, 180.20431330535 ),
      ( 541, 1051.51359571418, 3539548.02233325, 55549.9502814354, 58916.0960324366, 136.35079180006, 191.081142584502, 221.789821361262, 198.720866696469 ),
      ( 564, 952.403145574963, 3539548.02232787, 60280.9345736143, 63997.3733934285, 145.549160343861, 195.871657020644, 220.651138881602, 213.521335389085 ),
      ( 587, 877.44011690268, 3539548.02232708, 65050.5733367387, 69084.5215847644, 154.389685309344, 200.812076940217, 221.983163568816, 226.036503830194 ),
      ( 150, 10539.8583318617, 9999999.99886914, -24332.9820578409, -23384.2027019895, -109.695134798928, 104.64951408319, 141.879420919964, 1829.91068421573 ),
      ( 173, 10258.7360231107, 9999999.99892639, -21092.20025992, -20117.4213030974, -89.4339445348316, 105.659645749364, 142.383475959171, 1696.3456369897 ),
      ( 196, 9984.54919779686, 9999999.99918845, -17827.5149229, -16825.9674517939, -71.5730421289196, 107.397538159023, 144.016716082406, 1573.21472888632 ),
      ( 219, 9713.63946522364, 9999999.99944933, -14513.3721772509, -13483.8919257704, -55.4529747772906, 109.980863180664, 146.791722148809, 1457.54271862872 ),
      ( 242, 9443.06496835517, 9999999.99963428, -11123.6743191083, -10064.6961130761, -40.6100879390177, 113.47814105263, 150.718525422261, 1347.50222437578 ),
      ( 265, 9170.24707027012, 9999999.99974878, -7632.97974607911, -6542.49658645207, -26.7097090203043, 117.853668993522, 155.731434644463, 1242.02140171137 ),
      ( 288, 8892.72950680078, 9999999.99981715, -4018.20924910175, -2893.69511739792, -13.5091501127001, 122.989872903435, 161.702889659646, 1140.4344895728 ),
      ( 311, 8607.98428854348, 9999999.99985833, -259.697101776861, 902.01505575664, -0.83276061658809, 128.727979910738, 168.480637944955, 1042.25291367911 ),
      ( 334, 8313.22518552926, 9999999.99988911, 3658.59265820687, 4861.49523533133, 11.4467483623232, 134.903034495373, 175.922313827907, 947.056893152801 ),
      ( 357, 8005.20024000292, 9999999.99992154, 7749.50342655274, 8998.69141687313, 23.4227366530687, 141.366731151315, 183.920000871296, 854.47616320717 ),
      ( 380, 7679.94045258948, 9999999.99995889, 12023.5204978905, 13325.6139270898, 35.1657794755188, 147.999101567032, 192.415063438852, 764.232153239005 ),
      ( 403, 7332.45446554325, 9999999.99998896, 16489.7628557229, 17853.5626647747, 46.7321630039686, 154.712367888831, 201.404764462781, 676.235090317028 ),
      ( 426, 6956.40583075478, 9999999.9999992, 21156.8711413156, 22594.3950930938, 58.170125039157, 161.449948864295, 210.938378086887, 590.751936948432 ),
      ( 449, 6543.95689528791, 10000000.0000001, 26033.3561724951, 27561.4835975398, 69.5237472753684, 168.181728514731, 221.091024917543, 508.664007654065 ),
      ( 472, 6086.32866939511, 10000000, 31126.5704054361, 32769.5970218403, 80.8335453935664, 174.892833455951, 231.892013145238, 431.76458020622 ),
      ( 495, 5576.21723611762, 10000000.0000013, 36439.106808191, 38232.4372285395, 92.1320755564326, 181.556812971592, 243.192445004605, 362.848704314673 ),
      ( 518, 5013.49607307811, 10000000, 41961.6948666302, 43956.3109696922, 103.432916387149, 188.083235386772, 254.443945149757, 305.275592323442 ),
      ( 541, 4415.27324497161, 9999999.99999787, 47659.8388788873, 49924.7043685569, 114.704924440062, 194.267658531797, 264.027132062697, 262.375721484321 ),
      ( 564, 3828.16764914998, 9999999.99998093, 53449.2346464412, 56061.4504416928, 125.813119943867, 199.870585212356, 268.415199589228, 236.93780811251 ),
      ( 587, 3317.48221967513, 10000000, 59202.4063517863, 62216.7405178272, 136.51044130602, 204.879672737874, 265.902139124077, 228.440155954254 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new(double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 184.24875, 38.3055380051367, 10051.9468086432, 0.0250074468656691 ),
      ( 225.0275, 1553.47504362765, 9547.96194398771, 0.832025450834547 ),
      ( 265.80625, 17308.7825591001, 9033.40564537979, 7.93153576145879 ),
      ( 306.585, 92549.836306949, 8487.58413769861, 37.8825232177886 ),
      ( 347.36375, 317058.808906195, 7882.65000821746, 121.718813332454 ),
      ( 388.1425, 818617.497568869, 7168.45546938609, 313.434486502735 ),
      ( 428.92125, 1757546.20943173, 6216.90915255698, 743.068452499294 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa
      _testDataMeltingLine = new(double temperature, double pressure)[]
     {
      ( 143.47, 0.0763221842318157 ),
      ( 143.470000001192, 0.1 ),
      ( 143.470000004135, 0.158489319246111 ),
      ( 143.4700000088, 0.251188643150958 ),
      ( 143.47000004242, 0.398107170553497 ),
      ( 143.470000073115, 0.630957344480193 ),
      ( 143.470000121765, 1 ),
      ( 143.470000198868, 1.58489319246111 ),
      ( 143.47000032107, 2.51188643150958 ),
      ( 143.470000514746, 3.98107170553497 ),
      ( 143.470000821703, 6.30957344480193 ),
      ( 143.470001308196, 10 ),
      ( 143.470002079236, 15.8489319246111 ),
      ( 143.470003301251, 25.1188643150958 ),
      ( 143.470005238015, 39.8107170553497 ),
      ( 143.470008307579, 63.0957344480193 ),
      ( 143.47001317251, 100 ),
      ( 143.470020882905, 158.489319246111 ),
      ( 143.470033103058, 251.188643150958 ),
      ( 143.470052470692, 398.107170553497 ),
      ( 143.47008316632, 630.957344480193 ),
      ( 143.470131815601, 1000 ),
      ( 143.470208919487, 1584.89319246111 ),
      ( 143.470331120839, 2511.88643150958 ),
      ( 143.470524796751, 3981.07170553497 ),
      ( 143.470831751936, 6309.57344480193 ),
      ( 143.471318241992, 10000 ),
      ( 143.472089273936, 15848.9319246111 ),
      ( 143.473311270099, 25118.8643150958 ),
      ( 143.475247985621, 39810.7170553497 ),
      ( 143.478317473659, 63095.7344480193 ),
      ( 143.483182168228, 100000 ),
      ( 143.490891970277, 158489.319246111 ),
      ( 143.503110632388, 251188.643150958 ),
      ( 143.52247452385, 398107.170553497 ),
      ( 143.553160750978, 630957.344480193 ),
      ( 143.601786425198, 1000000 ),
      ( 143.678831044232, 1584893.19246111 ),
      ( 143.800883646376, 2511886.43150958 ),
      ( 143.994186394929, 3981071.70553497 ),
      ( 144.300206136281, 6309573.44480193 ),
      ( 144.784353981498, 10000000 ),
      ( 145.549532204511, 15848931.9246111 ),
      ( 146.756940784822, 25118864.3150958 ),
      ( 148.657466034982, 39810717.0553497 ),
      ( 151.637737547363, 63095734.4480194 ),
      ( 156.284904314945, 100000000 ),
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
