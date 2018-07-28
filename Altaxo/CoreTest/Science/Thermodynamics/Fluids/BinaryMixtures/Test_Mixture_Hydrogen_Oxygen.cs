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
  /// Tests and test data for <see cref="Mixture_Hydrogen_Oxygen"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Hydrogen_Oxygen : MixtureTestBase
  {

    public Test_Mixture_Hydrogen_Oxygen()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("1333-74-0", 0.5), ("7782-44-7", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 100, 1.20301594647288, 999.999999937908, -0.000228324175688456, 20.7930472142413, 2 ),
      ( 100, 12.055001872514, 9999.99935084061, -0.00228860870330086, 20.7931008372043, 2 ),
      ( 100, 123.157889340366, 99999.9999242049, -0.0234151662448637, 20.8790197364043, 2 ),
      ( 100, 34141.2114082721, 999999.999999648, -0.964771570215871, 28.6547621602596, 1 ),
      ( 100, 34871.5565295722, 10000000.0000599, -0.655093896415094, 29.2067140860776, 1 ),
      ( 150, 0.80188515024502, 999.998937513607, -7.18776474012005E-05, 20.7948810869975, 2 ),
      ( 150, 8.02404540052486, 9999.99999999941, -0.000719122908622142, 20.8017449574387, 2 ),
      ( 150, 80.7663827883725, 99999.9999993877, -0.00722616892636275, 20.871198364145, 2 ),
      ( 150, 867.959872968488, 1000000.00004117, -0.0761928776494181, 21.6533558700758, 2 ),
      ( 200, 0.601388537638578, 999.993744496658, -2.97696101499435E-05, 20.8107140355036, 2 ),
      ( 200, 6.01549732833165, 9999.99999999414, -0.000297728349158507, 20.8131220151721, 2 ),
      ( 200, 60.3168267939244, 99999.9999414167, -0.00298031843894569, 20.8372705114638, 2 ),
      ( 200, 620.035124322782, 999999.999999994, -0.0301023106052242, 21.085749940575, 2 ),
      ( 200, 8662.12628213383, 9999999.99991268, -0.305747093913317, 24.001050900988, 2 ),
      ( 250, 0.481103073230903, 999.996641336963, -1.36471159745007E-05, 20.8857515870923, 2 ),
      ( 250, 4.81162169115209, 9999.99999999922, -0.000136464543574406, 20.8869096147091, 2 ),
      ( 250, 48.1753585727135, 99999.9999922953, -0.00136393003994963, 20.8984935331733, 2 ),
      ( 250, 487.709656041811, 1000000, -0.013559601333439, 21.0146452104469, 2 ),
      ( 300, 0.400916232189939, 999.998461099967, -6.17561246846431E-06, 21.0702107019849, 2 ),
      ( 300, 4.00938512660364, 9999.99999999994, -6.17460701234067E-05, 21.0709103922534, 2 ),
      ( 300, 40.1161048845108, 99999.9999992768, -0.000616442107112229, 21.0779039311745, 2 ),
      ( 300, 403.357665542725, 999999.993798744, -0.0060589135602575, 21.1474822481612, 2 ),
      ( 300, 4204.49213635868, 9999999.99999997, -0.0464632985850716, 21.7872214104738, 2 ),
      ( 350, 0.34364117133732, 999.999496724818, -2.30749737656046E-06, 21.3792158677602, 2 ),
      ( 350, 3.43648289366658, 10000, -2.30667189381537E-05, 21.3796961091811, 2 ),
      ( 350, 34.3719362669733, 99999.9999999642, -0.000229839078497831, 21.3844949640678, 2 ),
      ( 350, 344.402877159379, 999999.999751065, -0.00221401933911821, 21.4321203928047, 2 ),
      ( 350, 3479.32500236015, 10000000, -0.0123361218194625, 21.8660855041035, 1 ),
      ( 400, 0.300685366719271, 999.999960416089, -1.61421930078107E-07, 21.7913906826468, 2 ),
      ( 400, 3.00685800738606, 9999.99615804091, -1.60807821798328E-06, 21.7917447918171, 2 ),
      ( 400, 30.0689967691306, 99999.9999999998, -1.54660270434426E-05, 21.7952829434917, 2 ),
      ( 400, 300.713129278901, 1000000, -9.24870385045616E-05, 21.8303679118645, 1 ),
      ( 400, 2989.34450945978, 10000000, 0.00585702404194717, 22.1498802624833, 1 ),
      ( 500, 0.240547807450799, 1000.0004272945, 1.819045368719E-06, 22.7767236298008, 1 ),
      ( 500, 2.40543877374839, 9999.99999999997, 1.81937487493699E-05, 22.7769402947243, 1 ),
      ( 500, 24.0504417540079, 100000.000000016, 0.000182267877142025, 22.7791050531536, 1 ),
      ( 500, 240.102650847803, 1000000.00018929, 0.00185588505612745, 22.8005636026651, 1 ),
      ( 500, 2353.7086473882, 10000000, 0.0219967285952426, 22.996474938092, 1 ),
      ( 600, 0.200456363742742, 1000.00054926362, 2.51582186454078E-06, 23.776193119998, 1 ),
      ( 600, 2.00451834759303, 10000, 2.51600696300171E-05, 23.7763384240593, 1 ),
      ( 600, 20.0406418389594, 100000.000000036, 0.000251787104592298, 23.7777901912099, 1 ),
      ( 600, 199.949692905095, 1000000.00037098, 0.00253656421503195, 23.7921808782997, 1 ),
      ( 600, 1951.36280904316, 10000000, 0.0272660584308043, 23.9238015680073, 1 ),
      };

      // TestData for 500 Permille to 500 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_500_500 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 100, 1.20280941556555, 999.999999802027, -6.45779928683469E-05, 17.5286742277515, 2 ),
      ( 100, 12.0350920311092, 9999.99797420456, -0.000645996228047846, 17.5324628061341, 2 ),
      ( 100, 121.057831421796, 99999.9985929107, -0.00648167359377906, 17.5705630907957, 2 ),
      ( 150, 0.801834664972631, 999.999999999073, -1.68421348030386E-05, 18.9336698616616, 2 ),
      ( 150, 8.01956215849799, 9999.99998480221, -0.000168407553691301, 18.9348329506974, 2 ),
      ( 150, 80.3172625639412, 99999.9999999998, -0.00168265853490912, 18.946449866752, 2 ),
      ( 150, 815.395096730055, 999999.999352682, -0.0166470664475596, 19.0611524532757, 2 ),
      ( 150, 9040.56857925796, 10000000, -0.113085473180575, 19.97880355512, 1 ),
      ( 200, 0.601368208688631, 999.999999999998, -3.88849088045968E-06, 19.8878706658249, 2 ),
      ( 200, 6.01389245759398, 9999.99999997593, -3.88691446141057E-05, 19.8884498158699, 2 ),
      ( 200, 60.1598751395046, 99999.9997746783, -0.000387103730087213, 19.8942326495488, 2 ),
      ( 200, 603.599965877037, 999999.999999999, -0.00370128516430266, 19.9511874557178, 2 ),
      ( 200, 6089.20411914505, 10000000, -0.0124064516361296, 20.4304436876129, 1 ),
      ( 250, 0.48109232239694, 1000.0090782467, 7.61794512962928E-07, 20.447395739442, 1 ),
      ( 250, 4.81089026583702, 10000.0000000003, 7.62776775952626E-06, 20.4477522095148, 1 ),
      ( 250, 48.1055524660992, 100000.000004129, 7.72708266970444E-05, 20.4513122746004, 1 ),
      ( 250, 480.671703065807, 1000000, 0.000875843430018806, 20.4864497620894, 1 ),
      ( 250, 4709.84989636706, 10000000.0164499, 0.0214607828980544, 20.7932148180406, 1 ),
      ( 300, 0.400909517519723, 1000, 2.65063009870899E-06, 20.8017815903934, 1 ),
      ( 300, 4.00899951378253, 10000.000000014, 2.65123611698468E-05, 20.8020275587756, 1 ),
      ( 300, 40.0804073993009, 100000.000146267, 0.000265731305178416, 20.8044844772063, 1 ),
      ( 300, 399.823188632577, 1000000.00000001, 0.00271968104651427, 20.8287783485881, 1 ),
      ( 300, 3875.81962151578, 10000000.0107698, 0.034389159843402, 21.0456497004751, 1 ),
      ( 350, 0.3436364587295, 1000, 3.43801406184939E-06, 21.0758956159107, 1 ),
      ( 350, 3.43625824934694, 10000.0000000278, 3.43839750286028E-05, 21.0760781092664, 1 ),
      ( 350, 34.351939253659, 100000.000283692, 0.000344224002455953, 21.0779012220798, 1 ),
      ( 350, 342.445437886027, 1000000.00000002, 0.00348143714413502, 21.0959512262141, 1 ),
      ( 350, 3306.7873916382, 10000000.0048776, 0.0391887940318237, 21.259355143171, 1 ),
      ( 400, 0.300681812098558, 1000, 3.73497270022669E-06, 21.3318475740589, 1 ),
      ( 400, 3.00671704371749, 10000.000000028, 3.735225166077E-05, 21.3319899983019, 1 ),
      ( 400, 30.0570589239235, 100000.000282824, 0.000373775419217589, 21.333412946127, 1 ),
      ( 400, 299.555569866326, 1000000.00000002, 0.00376345954012427, 21.3475136567571, 1 ),
      ( 400, 2889.93085858685, 10000000.0008665, 0.0404502732118761, 21.4763550508095, 1 ),
      ( 500, 0.240545428505252, 1000.00000000001, 3.74803443918691E-06, 21.8594814774605, 1 ),
      ( 500, 2.40537332392351, 10000.0000000229, 3.74815713365519E-05, 21.8595776379233, 1 ),
      ( 500, 24.0456191877613, 100000.000229291, 0.000374938284687486, 21.8605384743553, 1 ),
      ( 500, 239.644854538984, 1000000.00000001, 0.00376178979369364, 21.8700704127721, 1 ),
      ( 500, 2315.28453034354, 10000000.0000925, 0.0389494032248778, 21.9581385089948, 1 ),
      ( 600, 0.200454572568758, 1000, 3.50929030192813E-06, 22.3966170229329, 1 ),
      ( 600, 2.00448255644199, 10000.0000000135, 3.50935809175161E-05, 22.3966881365922, 1 ),
      ( 600, 20.038495428687, 100000.000135364, 0.000351003421150152, 22.3973987501414, 1 ),
      ( 600, 199.752787412121, 1000000, 0.00351686044776828, 22.4044528315685, 1 ),
      ( 600, 1935.09893253138, 10000000.0000087, 0.0358916886438506, 22.4700344376632, 1 ),
      };

      // TestData for 999 Permille to 1 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_999_001 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 100, 1.20272485201403, 999.999999999978, -2.19469669682939E-06, 14.2633657484937, 2 ),
      ( 100, 12.0274856382035, 9999.999999822, -2.19093361383097E-05, 14.2640033218738, 2 ),
      ( 100, 120.298115421126, 99999.9999969908, -0.000215250099780474, 14.2703633359886, 2 ),
      ( 100, 1204.76407006238, 999999.999998682, -0.00169481952136073, 14.3324414457504, 2 ),
      ( 100, 11411.8600724296, 9999999.99999996, 0.0539230281160157, 14.8471700253595, 1 ),
      ( 150, 0.801810211848987, 1000.00000000011, 5.73254883409695E-06, 17.0729688011848, 1 ),
      ( 150, 8.01768835417951, 10000.0000011191, 5.73392793596043E-05, 17.0732963997148, 1 ),
      ( 150, 80.1354201868871, 100000.012463778, 0.000574785098487107, 17.0765706811276, 1 ),
      ( 150, 797.112642899662, 1000000.00030934, 0.00589899734862157, 17.1091467556758, 1 ),
      ( 150, 7437.06221470406, 10000000.0113809, 0.0781337915440351, 17.421186605729, 1 ),
      ( 200, 0.601357070038122, 1000.0000000001, 6.71175407383911E-06, 18.9651769021181, 1 ),
      ( 200, 6.01320743793387, 10000.0000010044, 6.71229222014483E-05, 18.9654061492716, 1 ),
      ( 200, 60.0957400473384, 100000.010290697, 0.00067177102192109, 18.9676983874902, 1 ),
      ( 200, 597.314203931558, 1000000.00006142, 0.00677516496500854, 18.9905965053618, 1 ),
      ( 200, 5595.39958216476, 10000000.0000573, 0.074742022206918, 19.2164039029297, 1 ),
      ( 250, 0.481085804674157, 1000.00000000006, 6.40277663992584E-06, 20.0091023769265, 1 ),
      ( 250, 4.81058082796678, 10000.0000005588, 6.4030027836496E-05, 20.0092823174234, 1 ),
      ( 250, 48.0780931429382, 100000.005624409, 0.000640527789057212, 20.0110816502313, 1 ),
      ( 250, 478.015599760711, 1000000.00001193, 0.00642925712042198, 20.0290668261805, 1 ),
      ( 250, 4507.83926056641, 9999999.99999999, 0.0672272393729043, 20.2073456776629, 1 ),
      ( 300, 0.400905061883769, 1000.00000000003, 5.84240271303034E-06, 20.533387872156, 1 ),
      ( 300, 4.00883982490825, 10000.0000002956, 5.84249877502231E-05, 20.5335369756865, 1 ),
      ( 300, 40.0673272090576, 100000.00295788, 0.000584346561734719, 20.5350279354865, 1 ),
      ( 300, 398.574270670871, 1000000.00000263, 0.00585369808586739, 20.5499293822876, 1 ),
      ( 300, 3782.7137853469, 10000000, 0.0598407040088165, 20.697636981148, 1 ),
      ( 350, 0.343633104419419, 1000.00000000002, 5.27716478196816E-06, 20.7725975255146, 1 ),
      ( 350, 3.43616784476685, 10000.0000001605, 5.27720183351668E-05, 20.7727249966774, 1 ),
      ( 350, 34.3453657566566, 100000.001602325, 0.000527757559921579, 20.7739996184396, 1 ),
      ( 350, 341.829507248875, 1000000.00000066, 0.00528161124338742, 20.7867364883801, 1 ),
      ( 350, 3262.19670650198, 10000000.0112391, 0.0533850308991378, 20.9128720112843, 1 ),
      ( 400, 0.30067911958227, 1000.00000000001, 4.76759801458405E-06, 20.872317239717, 1 ),
      ( 400, 3.00666218516193, 10000.0000000908, 4.76760685694022E-05, 20.8724284941581, 1 ),
      ( 400, 30.0537266033813, 100000.000906236, 0.000476769715825866, 20.8735409421152, 1 ),
      ( 400, 299.253480782893, 1000000.00000019, 0.0047687743054634, 20.8846555600086, 1 ),
      ( 400, 2869.35979386676, 10000000.0016338, 0.0479011859872197, 20.9946356754399, 1 ),
      ( 500, 0.240543475990767, 1000, 3.9391544045007E-06, 20.9422373108171, 1 ),
      ( 500, 2.4053496746292, 10000.000000033, 3.93914312537161E-05, 20.9423256549012, 1 ),
      ( 500, 24.0449728658379, 100000.00032859, 0.000393902800440936, 20.9432090035214, 1 ),
      ( 500, 239.600906099595, 1000000.00000002, 0.0039379499534363, 20.9520331882786, 1 ),
      ( 500, 2314.43531330233, 10000000.0000498, 0.0393223828596911, 21.0392780479821, 1 ),
      ( 600, 0.200453023436642, 1000, 3.31909745608918E-06, 21.0170275016228, 1 ),
      ( 600, 2.00447049064203, 10000.0000000137, 3.31908208338858E-05, 21.0171003550165, 1 ),
      ( 600, 20.0387195028442, 100000.000137079, 0.000331892653787995, 21.0178288093663, 1 ),
      ( 600, 199.790914092019, 1000000, 0.00331740798037102, 21.0251053642765, 1 ),
      ( 600, 1940.40635466566, 10000000.0000027, 0.0330501216114383, 21.097046937039, 1 ),
      };
    }

    [Test]
    public override void CASNumberAttribute_Test()
    {
      base.CASNumberAttribute_Test();
    }

    [Test]
    public override void Constants_Test()
    {
      base.Constants_Test();
    }

    [Test]
    public override void DeltaPhiRDelta_001_999_Test()
    {
      base.DeltaPhiRDelta_001_999_Test();
    }

    [Test]
    public override void DeltaPhiRDelta_500_500_Test()
    {
      base.DeltaPhiRDelta_500_500_Test();
    }

    [Test]
    public override void DeltaPhiRDelta_999_001_Test()
    {
      base.DeltaPhiRDelta_999_001_Test();
    }
  }
}
