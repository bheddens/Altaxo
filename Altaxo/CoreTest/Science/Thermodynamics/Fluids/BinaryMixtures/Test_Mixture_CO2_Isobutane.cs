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
	/// Tests and test data for <see cref="Mixture_CO2_Isobutane"/>.
	/// </summary>
	/// <remarks>
	/// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
	/// </remarks>
  [TestFixture]
  public class Test_Mixture_CO2_Isobutane : MixtureTestBase
    {

    public Test_Mixture_CO2_Isobutane()
      {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[]{("124-38-9", 0.5), ("75-28-5", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 100, 12970.3439925288, 1000.00000962232, -0.999907271372827, 65.67985068804, 1 ),
      ( 100, 12970.3928238011, 10000.0009326318, -0.999072717136934, 65.680772089549, 1 ),
      ( 100, 12970.881059722, 100000.000004523, -0.99072752126648, 65.6899842050605, 1 ),
      ( 100, 12975.7557625129, 1000000.00000477, -0.907310047305468, 65.7819148561503, 1 ),
      ( 100, 13023.7599334695, 10000000.0001328, -0.0765169244778225, 66.6815935848435, 1 ),
      ( 150, 12154.4542475628, 100000.000000827, -0.993403119750942, 72.6197436874513, 1 ),
      ( 150, 12162.0307418898, 1000000.00006944, -0.934072293606143, 72.6916417876678, 1 ),
      ( 150, 12235.6922075399, 10000000.0000022, -0.3446919240286, 73.3787661986241, 1 ),
      ( 200, 0.601934986576016, 999.999999991897, -0.000953413051932078, 63.5160031876676, 2 ),
      ( 200, 11322.220607591, 99999.9999974773, -0.994688664762963, 79.1621679991425, 1 ),
      ( 200, 11333.7546834664, 1000000.00191085, -0.946940699552254, 79.2247654686124, 1 ),
      ( 200, 11443.6612622056, 9999999.99999752, -0.47450288843664, 79.8192690032518, 1 ),
      ( 250, 0.481305268183684, 999.999999997249, -0.000449596286070934, 75.5928150709846, 2 ),
      ( 250, 4.8327243568898, 9999.99997080276, -0.0045182807658138, 75.7137643714632, 2 ),
      ( 250, 10436.0152835764, 100000.000000219, -0.99539010954541, 87.5374505051063, 1 ),
      ( 250, 10454.5042828775, 999999.999998807, -0.953982622046202, 87.5952324489076, 1 ),
      ( 250, 10624.4056560109, 10000000.0000486, -0.547185140799413, 88.1480581508077, 1 ),
      ( 300, 0.401007223186869, 999.999999999563, -0.000248941279778351, 88.773160824532, 2 ),
      ( 300, 4.01910192375948, 9999.99999545872, -0.00249507590931011, 88.8280750773077, 2 ),
      ( 300, 41.1417621239319, 99999.9999999995, -0.0255463664199207, 89.4132345763846, 2 ),
      ( 300, 9460.2995076804, 1000000.00000012, -0.957622124372462, 98.2137604308633, 1 ),
      ( 300, 9747.62904011964, 10000000.0022945, -0.588712912265246, 98.6534352298846, 1 ),
      ( 350, 0.343687203643643, 999.999999999957, -0.000152152425834903, 102.501820163287, 2 ),
      ( 350, 3.4415917479244, 9999.99999954624, -0.00152331836164827, 102.530380130163, 2 ),
      ( 350, 34.9015893526596, 99999.9928957811, -0.0154175853794441, 102.824764038432, 2 ),
      ( 350, 419.266634880856, 999999.999975813, -0.180390514732387, 106.994387952144, 2 ),
      ( 350, 8759.76412706241, 10000000.0000002, -0.607712141768647, 110.624279376422, 1 ),
      ( 400, 0.300710364813828, 999.997935829789, -9.91578745484164E-05, 116.041709301188, 2 ),
      ( 400, 3.0097918373927, 9999.99999996881, -0.000992217414689321, 116.058304083242, 2 ),
      ( 400, 30.3713684326936, 99999.9994797656, -0.00998683119614376, 116.226921771791, 2 ),
      ( 400, 336.920222167458, 999999.999463568, -0.107561591172568, 118.238394790133, 2 ),
      ( 400, 7554.92995566043, 10000000.0000011, -0.602007498790386, 123.406538937283, 1 ),
      ( 500, 0.240555802954578, 999.997970917627, -4.72462940429279E-05, 140.83121528505, 2 ),
      ( 500, 2.406581564006, 9999.99999999903, -0.000472532662009563, 140.838120098258, 2 ),
      ( 500, 24.1688159178101, 99999.9999881866, -0.00473222029333946, 140.907455368108, 2 ),
      ( 500, 252.679622568227, 999999.999999991, -0.0480259740914964, 141.630448746145, 2 ),
      ( 500, 4095.96159578257, 10000000, -0.412727800453515, 147.749001566089, 1 ),
      ( 600, 0.200458567265685, 999.99893962632, -2.42907690316264E-05, 161.928393835179, 2 ),
      ( 600, 2.00502396517664, 9999.99999999984, -0.000242882632557876, 161.931945786591, 2 ),
      ( 600, 20.0941237397804, 99999.9999985151, -0.00242627862643013, 161.967485050581, 2 ),
      ( 600, 205.38092925309, 999999.999999998, -0.0239906952570803, 162.324410898841, 2 ),
      ( 600, 2449.29849899451, 10000000.0000333, -0.181587307345376, 165.309363466557, 1 ),
      };

      // TestData for 500 Permille to 500 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_500_500 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 200, 0.601628913144979, 999.999999998525, -0.000447436447731421, 43.8030620924591, 2 ),
      ( 250, 0.481189466976162, 999.999996662263, -0.000211328447163748, 51.0822681054082, 2 ),
      ( 250, 4.82108479470328, 9999.99999994284, -0.00211716151009608, 51.1365934125983, 2 ),
      ( 250, 49.1698205474184, 99999.9977073512, -0.0215791458144075, 51.7037228645629, 2 ),
      ( 300, 0.400953318524737, 999.99999978588, -0.000116813841123892, 58.8717168384758, 2 ),
      ( 300, 4.01375745047879, 9999.99779025138, -0.00116913720439602, 58.8955170140759, 2 ),
      ( 300, 40.5690949958442, 99999.9987551837, -0.0117933814731614, 59.1378211988727, 2 ),
      ( 350, 0.343658427925558, 999.999999964174, -7.07121208597978E-05, 66.8263091796731, 2 ),
      ( 350, 3.43877390848062, 9999.99963555183, -0.000707414143455945, 66.8386280194911, 2 ),
      ( 350, 34.6092680014864, 99999.9999993628, -0.00710374134552299, 66.9629061730663, 2 ),
      ( 350, 371.232473094271, 999999.999999874, -0.0743424888317667, 68.3308207583738, 2 ),
      ( 350, 9892.13906063121, 10000000.0000066, -0.652618988670473, 76.4523405191282, 1 ),
      ( 350, 14360.7641039484, 100000000.000299, 1.39286798824081, 77.7506038912567, 1 ),
      ( 400, 0.300693466382755, 999.999999992636, -4.52459519972956E-05, 74.5720678242616, 2 ),
      ( 400, 3.00815992341549, 9999.999925608, -0.000452539503841623, 74.5791947194877, 2 ),
      ( 400, 30.204918053418, 99999.9999999857, -0.00453343162693333, 74.6507796402595, 2 ),
      ( 400, 315.236151929183, 1000000.00234434, -0.0461758293087159, 75.3994662619129, 2 ),
      ( 400, 5758.71278603566, 9999999.99996839, -0.477869669155911, 83.4199487988917, 1 ),
      ( 400, 13510.4461231921, 100000000.004374, 1.22553614062583, 83.6000051947434, 1 ),
      ( 500, 0.240548735010797, 999.999999999567, -2.01457484671928E-05, 88.6267953670749, 2 ),
      ( 500, 2.40592354210602, 9999.99999563887, -0.000201441289574506, 88.6298091693153, 2 ),
      ( 500, 24.1029029200794, 99999.9999999998, -0.00201278752823556, 88.6599747751885, 2 ),
      ( 500, 245.44261086802, 999999.998373137, -0.0199587262632068, 88.9641054182212, 2 ),
      ( 500, 2888.09287238658, 10000000, -0.167118580997316, 91.8277794534095, 2 ),
      ( 500, 11985.0732597609, 100000000.000129, 1.00702894144158, 95.1393869823456, 1 ),
      ( 600, 0.200455057950129, 999.99999999997, -9.06505632102469E-06, 100.533751696038, 2 ),
      ( 600, 2.00471408767811, 9999.99999971463, -9.06261605231979E-05, 100.535332392991, 2 ),
      ( 600, 20.063457851023, 99999.9972486479, -0.000903820731370462, 100.551136478792, 2 ),
      ( 600, 202.231541893097, 999999.999998672, -0.0087933912915285, 100.708770391038, 2 ),
      ( 600, 2135.33543454209, 10000000.0002164, -0.0612564303903167, 102.132109188072, 1 ),
      ( 600, 10696.1599944675, 100000000.000428, 0.874067337418118, 105.504961806205, 1 ),
      };

      // TestData for 999 Permille to 1 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_999_001 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 100, 35362.9551006726, 1000.00001305265, -0.999965989360811, -1.39320758477373, 1 ),
      ( 100, 35363.0116953521, 10000.0028637036, -0.999659894056593, -1.38951007362756, 1 ),
      ( 100, 35363.5776315444, 99999.9999855084, -0.996598995966247, -1.35254181580925, 1 ),
      ( 100, 35369.2359309788, 1000000.00000273, -0.965995400513367, -0.983542611579148, 1 ),
      ( 100, 35425.7104040638, 10000000.000906, -0.660496094965491, 2.63879845816906, 1 ),
      ( 100, 35977.6533376505, 99999999.999996, 2.34295483555679, 32.7701775263835, 1 ),
      ( 150, 0.802242044363458, 999.999999689224, -0.000537131803458651, 21.9956543542765, 2 ),
      ( 150, 31657.3687690578, 1000000.00004273, -0.974672211688548, 46.1231938515445, 1 ),
      ( 150, 31810.4936189545, 10000000.0000042, -0.747941310105866, 47.3259072265145, 1 ),
      ( 150, 33092.3363347064, 100000000.000001, 1.42295112239121, 54.8426810095964, 1 ),
      ( 200, 0.601471125497166, 999.999998075307, -0.000187497797927526, 24.097101858103, 2 ),
      ( 200, 6.02489858035425, 9999.99999999996, -0.00187805161220686, 24.1621833959833, 2 ),
      ( 200, 61.3074416802565, 100000.000674675, -0.0191103487222951, 24.8354713244596, 2 ),
      ( 200, 28070.4537508361, 1000000.00025043, -0.978576821149603, 44.0979902435653, 1 ),
      ( 200, 28379.5743509356, 10000000.000001, -0.788101701756362, 44.6426752991787, 1 ),
      ( 200, 30521.4683142107, 99999999.9999988, 0.970279885602395, 47.6913859210856, 1 ),
      ( 250, 0.48112934864765, 999.999999866053, -8.86827200295039E-05, 26.575232227599, 2 ),
      ( 250, 4.81513986230695, 9999.99862329487, -0.00088742050211614, 26.596857194295, 2 ),
      ( 250, 48.5423754702171, 99999.9999850505, -0.00893461393264786, 26.8155792984036, 2 ),
      ( 300, 0.400925093697215, 999.999999995131, -4.87032962568744E-05, 28.9719696199642, 2 ),
      ( 300, 4.01100974963502, 9999.99985526452, -0.000487178165253447, 28.9814209518271, 2 ),
      ( 300, 40.2874176083674, 99999.9999999226, -0.00488641086332301, 29.0764387214316, 2 ),
      ( 300, 422.204036984861, 999999.999999994, -0.0504459166552808, 30.0839567167897, 2 ),
      ( 300, 18199.7694177551, 9999999.99974488, -0.779719424947997, 41.8407098621801, 1 ),
      ( 300, 25631.5892692027, 100000000.019897, 0.564107333276336, 41.6619194478583, 1 ),
      ( 350, 0.343643327382123, 999.999999997471, -2.90532686030206E-05, 31.1516067420118, 2 ),
      ( 350, 3.43733220991663, 9999.99997449197, -0.000290567117399514, 31.1564917674126, 2 ),
      ( 350, 34.4635932879416, 99999.999999999, -0.00290912630354469, 31.2054767097107, 2 ),
      ( 350, 354.059997918458, 1000000.00002133, -0.0294488351119983, 31.7091121483223, 2 ),
      ( 350, 5204.54505641369, 9999999.99985524, -0.339743743788589, 38.4131995855414, 2 ),
      ( 350, 23325.5725889893, 100000000, 0.473204321605727, 40.8538742739687, 1 ),
      ( 400, 0.300684633959674, 999.999999999517, -1.81534616592408E-05, 33.1028093836988, 2 ),
      ( 400, 3.00733769901386, 9999.99999514482, -0.000181537340077156, 33.1056386435898, 2 ),
      ( 400, 30.1226095410122, 99999.9999999999, -0.00181564587330341, 33.1339723930043, 2 ),
      ( 400, 306.247866235518, 999999.997034379, -0.0181836066148918, 33.4213492939626, 2 ),
      ( 400, 3671.68903440002, 9999999.99666434, -0.181087579321866, 36.5590843378214, 2 ),
      ( 400, 21173.5426814412, 100000000.004528, 0.420070226444828, 40.7038857455443, 1 ),
      ( 500, 0.240545121151732, 999.999999999979, -7.40300848079482E-06, 36.4223670414428, 2 ),
      ( 500, 2.40561147122212, 9999.999999782, -7.40216292820693E-05, 36.42355957088, 2 ),
      ( 500, 24.0721322677271, 99999.9978519329, -0.000739370643589663, 36.4354886257306, 2 ),
      ( 500, 242.314417058287, 999999.999998816, -0.00730900236352477, 36.5551140899077, 2 ),
      ( 500, 2569.50489585569, 9999999.9998842, -0.063853348626485, 37.7423190006747, 2 ),
      ( 500, 17512.7004135315, 100000000, 0.373536546129349, 41.3889208986547, 1 ),
      ( 600, 0.200453332911638, 999.999999999997, -2.68631581526092E-06, 39.1389416056765, 2 ),
      ( 600, 2.00458167168428, 9999.99999999258, -2.68560104271165E-05, 39.1395600474869, 2 ),
      ( 600, 20.050648851103, 99999.9999285833, -0.000267845941492672, 39.145743962083, 2 ),
      ( 600, 200.976827543568, 1000000, -0.0026074840945022, 39.2075198694429, 2 ),
      ( 600, 2043.7335655347, 9999999.99982839, -0.0191833855339347, 39.8073015471457, 2 ),
      ( 600, 14754.4924054493, 100000000.00141, 0.358588138139644, 42.5862644667537, 1 ),
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
