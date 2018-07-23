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
	/// Tests and test data for <see cref="Mixture_Butane_Heptane"/>.
	/// </summary>
	/// <remarks>
	/// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
	/// </remarks>
  [TestFixture]
  public class Test_Mixture_Butane_Heptane : MixtureTestBase
    {

    public Test_Mixture_Butane_Heptane()
      {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[]{("106-97-8", 0.5), ("142-82-5", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 100, 8537.81907682867, 1000.00007589271, -0.999859130676977, 131.399189617458, 1 ),
      ( 100, 8537.84441165806, 10000.0074616193, -0.998591310006115, 131.400070849912, 1 ),
      ( 100, 8538.09771879495, 100000.000000667, -0.985913528497932, 131.408882455854, 1 ),
      ( 100, 8540.62668538139, 1000000.00000481, -0.859176996456638, 131.496927546509, 1 ),
      ( 100, 8565.51645001055, 10000000.0000001, 0.404137986296761, 132.370367643386, 1 ),
      ( 100, 8782.45904084614, 100000000.000003, 12.6945324353595, 140.484013548808, 1 ),
      ( 150, 8037.11975765619, 1000.00020997878, -0.999900236486782, 143.663999629049, 1 ),
      ( 150, 8037.15469692595, 9999.99999954913, -0.99900236941447, 143.66469330283, 1 ),
      ( 150, 8037.50400756606, 100000.000000983, -0.990024127715551, 143.671629292608, 1 ),
      ( 150, 8040.98893965596, 1000000.00004816, -0.900284512178394, 143.740914478682, 1 ),
      ( 150, 8075.05085166018, 9999999.99999954, -0.00705128750696694, 144.426402946382, 1 ),
      ( 150, 8357.62293943738, 100000000.000002, 8.59377014801287, 150.647697600242, 1 ),
      ( 200, 7600.03751669661, 99999.9999998861, -0.99208742927464, 151.679183308594, 1 ),
      ( 200, 7604.75459816907, 1000000.00000369, -0.920923372011373, 151.739867461981, 1 ),
      ( 200, 7650.432888348, 10000000.0000007, -0.213955132047063, 152.338881772751, 1 ),
      ( 200, 8007.48686101185, 100000000.000002, 6.50995114226654, 157.657968774897, 1 ),
      ( 250, 7184.72285510788, 99999.9999988992, -0.993304033001197, 162.719906573181, 1 ),
      ( 250, 7191.14654626317, 1000000.00010779, -0.933100142392979, 162.775625120552, 1 ),
      ( 250, 7252.52091233781, 10000000.0000001, -0.336662814812402, 163.325398086797, 1 ),
      ( 250, 7697.57041044802, 100000000.000001, 5.2498509937019, 168.129751408851, 1 ),
      ( 300, 0.401357993984503, 999.999943138669, -0.00112723962600377, 157.660858331934, 2 ),
      ( 300, 6768.71379984484, 100000.000000258, -0.994077079168624, 178.436742585138, 1 ),
      ( 300, 6777.68217327641, 1000000.00778359, -0.940849163545489, 178.488026434367, 1 ),
      ( 300, 6861.59951103316, 10000000.0000079, -0.415725784258146, 178.997572249958, 1 ),
      ( 300, 7413.14434042729, 100000000.000002, 4.40803671037768, 183.461181884342, 1 ),
      ( 350, 0.343847051784338, 999.999992965203, -0.000621521579085647, 179.890463303015, 2 ),
      ( 350, 3.45794568857368, 9999.99999999794, -0.00625002708126721, 180.164364801288, 2 ),
      ( 350, 6332.05251711859, 100000.000003613, -0.994573112865002, 197.206986186229, 1 ),
      ( 350, 6345.20680918238, 999999.99999974, -0.945843633824064, 197.250530566415, 1 ),
      ( 350, 6463.99540593939, 10000000.0001645, -0.468388632979043, 197.70071047578, 1 ),
      ( 350, 7146.88822787845, 100000000.000002, 3.80815331740876, 201.888478853253, 1 ),
      ( 400, 0.300792667226019, 999.999998780277, -0.000377308842743684, 202.274176451991, 2 ),
      ( 400, 3.01821739946793, 9999.98684351856, -0.003785555481275, 202.421353375576, 2 ),
      ( 400, 31.294650819709, 99999.9999999995, -0.0391994554438817, 203.954945197326, 2 ),
      ( 400, 5868.2449547255, 1000000.00290157, -0.948761652132538, 217.127255617884, 1 ),
      ( 400, 6047.00470626462, 10000000.0023889, -0.502763450395165, 217.440120493013, 1 ),
      ( 400, 6894.93637324868, 100000000.000004, 3.36086947312962, 221.336018576926, 1 ),
      ( 500, 0.240583684365411, 999.999999928976, -0.000167692050081811, 243.687630776909, 2 ),
      ( 500, 2.40947915670611, 9999.99926693697, -0.00167909834536124, 243.74010769849, 2 ),
      ( 500, 24.4706960687632, 99999.9999913228, -0.0170147194889999, 244.27410106027, 2 ),
      ( 500, 301.361401330053, 999999.999921108, -0.201811050323191, 250.960580444814, 2 ),
      ( 500, 5089.36513874394, 9999999.99999986, -0.527360812524606, 255.647702149113, 1 ),
      ( 500, 6426.83603504444, 100000000.000007, 2.74279566310018, 258.539859410697, 1 ),
      ( 600, 0.200470121982725, 999.999999992919, -8.64883043606952E-05, 278.990440924812, 2 ),
      ( 600, 2.00626382163056, 9999.99992813018, -0.000865282512250944, 279.013272838842, 2 ),
      ( 600, 20.2210638478572, 99999.9999999711, -0.00869318648633752, 279.243695571617, 2 ),
      ( 600, 220.617838216136, 1000000, -0.0914026477522631, 281.772342637056, 2 ),
      ( 600, 3833.44013118301, 9999999.99995288, -0.477094263112129, 290.264211607079, 1 ),
      ( 600, 6002.34367890094, 100000000.00001, 2.33957524569004, 291.003415069168, 1 ),
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
      ( 150, 9691.57037103355, 100000.000001386, -0.99172669721056, 113.610933304787, 1 ),
      ( 150, 9696.44228782929, 1000000.00052647, -0.917308540623258, 113.665443999851, 1 ),
      ( 150, 9743.96642315982, 10000000.0000005, -0.177118507569371, 114.197292956453, 1 ),
      ( 150, 10133.4855917677, 99999999.9999972, 6.91250903742653, 118.568306009055, 1 ),
      ( 200, 9134.18101441807, 99999.9999988193, -0.993416380549724, 118.572409548284, 1 ),
      ( 200, 9140.93289398316, 1000000.00144113, -0.934212434347307, 118.621248323568, 1 ),
      ( 200, 9206.0116416721, 10000000.0000016, -0.346774970715434, 119.099713000142, 1 ),
      ( 200, 9701.92169968052, 100000000.000007, 5.19835679008882, 123.132581944572, 1 ),
      ( 300, 0.401143195666159, 999.999987329612, -0.000590098593769759, 124.175403447797, 2 ),
      ( 300, 4.03299764824958, 10000.0015145425, -0.00593425474982193, 124.405815279716, 2 ),
      ( 300, 8013.64936255892, 1000000.0047561, -0.949972045821907, 139.474337650712, 1 ),
      ( 300, 8144.25042852831, 9999999.99999967, -0.507742934554207, 139.919251318731, 1 ),
      ( 300, 8936.30878255805, 100000000.000166, 3.48626487046408, 143.764424162586, 1 ),
      ( 350, 0.343750817232074, 999.999998201259, -0.000339461367783744, 141.762301343522, 2 ),
      ( 350, 3.44808183922218, 9999.98055261155, -0.00340494969073384, 141.875951886334, 2 ),
      ( 350, 7379.99051880643, 1000000.00000024, -0.953437050327682, 154.323535043351, 1 ),
      ( 350, 7581.37089030142, 10000000.0008206, -0.546738799478889, 154.693724969105, 1 ),
      ( 350, 8587.48893274145, 100000000.000752, 3.00156704483729, 158.413190269591, 1 ),
      ( 400, 0.30074380288342, 999.999999655339, -0.000212611738548001, 159.406232662685, 2 ),
      ( 400, 3.01321649028583, 9999.99639169176, -0.00212990861234178, 159.468194191909, 2 ),
      ( 400, 30.7347168997479, 100000.000001565, -0.0216930834232984, 160.105023069164, 2 ),
      ( 400, 6965.68437788003, 9999999.99999988, -0.568341249892401, 170.328954726127, 1 ),
      ( 400, 8256.52705613648, 100000000.002764, 2.64172319893117, 173.806225174899, 1 ),
      ( 500, 0.240567378660637, 999.99999999873, -9.76428486739824E-05, 192.064143561663, 2 ),
      ( 500, 2.40779149127566, 9999.99981599226, -0.000977078569943323, 192.086999085914, 2 ),
      ( 500, 24.2933547114841, 99999.9999996531, -0.00983667393566596, 192.318061729141, 2 ),
      ( 500, 269.063867603418, 999999.999930959, -0.105997058909507, 194.918373615818, 2 ),
      ( 500, 5411.03835599658, 10000000.0044392, -0.555457061589684, 201.262935691331, 1 ),
      ( 500, 7642.59383713872, 100000000.019873, 2.14741165294883, 203.272384108667, 1 ),
      ( 600, 0.200463332992391, 999.999999997787, -5.03442624720855E-05, 220.043175019012, 2 ),
      ( 600, 2.00554227514006, 9999.99997767012, -0.000503538126759258, 220.053539513829, 2 ),
      ( 600, 20.1469646382974, 99999.9999999984, -0.00504495631124191, 220.157683801391, 2 ),
      ( 600, 211.319790858134, 1000000.00006018, -0.0514223017207034, 221.248604384156, 2 ),
      ( 600, 3328.38039843205, 9999999.99846139, -0.397745399218183, 228.657711952068, 1 ),
      ( 600, 7089.46610865397, 99999999.9999998, 1.82748006323992, 229.132268713701, 1 ),
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
      ( 100, 13208.6825794454, 1000.00021668307, -0.999908944556426, 80.4793648622393, 1 ),
      ( 100, 13208.7296784098, 9999.9999984917, -0.999089449011002, 80.4806016253598, 1 ),
      ( 100, 13209.2005964609, 100000.000001618, -0.990894814723872, 80.4929637340505, 1 ),
      ( 100, 13213.9026356142, 1000000.00004322, -0.908980547153652, 80.6160346080611, 1 ),
      ( 100, 13260.2263028495, 9999999.99998376, -0.0929851720961672, 81.7937193027979, 1 ),
      ( 100, 13667.1824858333, 100000000.000007, 7.80007411222722, 89.7354497533228, 1 ),
      ( 150, 12403.5411226634, 1000000.0003978, -0.935355977446103, 83.9468766954304, 1 ),
      ( 150, 12472.6061219914, 10000000.0000018, -0.357139330767178, 84.4326379217954, 1 ),
      ( 150, 13030.2813689469, 100000000.000317, 5.15347258566729, 88.0214622756254, 1 ),
      ( 200, 0.602052830775676, 999.997239480873, -0.00114896056335808, 68.2316074908927, 2 ),
      ( 200, 11590.8565925722, 99999.9999975643, -0.994811763162485, 85.6982439691597, 1 ),
      ( 200, 11601.2714429825, 1000000.00302249, -0.94816420782311, 85.74299518521, 1 ),
      ( 200, 11700.9580958552, 9999999.99999941, -0.48605824500106, 86.1770867218169, 1 ),
      ( 200, 12432.8327514046, 100000000.00376, 3.83687914049017, 89.5922403864585, 1 ),
      ( 250, 0.481340382474312, 999.999987110076, -0.000522514539771151, 78.6073036211778, 2 ),
      ( 250, 4.83630053943036, 9999.99688608703, -0.00525438398437324, 78.7742758471876, 2 ),
      ( 250, 10747.928324037, 100000.000000496, -0.995523892068631, 91.5027050797053, 1 ),
      ( 250, 10763.9461176111, 1000000.0007309, -0.955305529220369, 91.5476662942602, 1 ),
      ( 250, 10912.9635839148, 9999999.99999713, -0.559158361138036, 91.9869504534764, 1 ),
      ( 250, 11870.800020838, 100000000.000005, 3.05270810963163, 95.4905965146986, 1 ),
      ( 300, 0.401020499047997, 999.999998572295, -0.00028203823139903, 90.7093244549774, 2 ),
      ( 300, 4.0204430014364, 9999.98466417643, -0.0028278039440414, 90.7832582873512, 2 ),
      ( 300, 41.2908186912551, 100000.007052408, -0.0290640685521525, 91.5675744148444, 2 ),
      ( 300, 9836.67977138619, 1000000.00000072, -0.959243626380716, 100.621319388017, 1 ),
      ( 300, 10076.8794433553, 10000000.001137, -0.602151243119349, 101.035335317879, 1 ),
      ( 300, 11339.9638675221, 100000000.000005, 2.53534985313096, 104.585348366818, 1 ),
      ( 350, 0.343693033628079, 999.999999769732, -0.000169112610666148, 103.643582097431, 2 ),
      ( 350, 3.44217849037573, 9999.99760611637, -0.00169351501445362, 103.681221484585, 2 ),
      ( 350, 34.9642284030629, 99999.9998861038, -0.01718148375117, 104.069007241309, 2 ),
      ( 350, 8692.5865098041, 1000000.00008784, -0.960468048210477, 111.810696326139, 1 ),
      ( 350, 9144.76537274424, 9999999.99999988, -0.62422774473178, 111.905276851078, 1 ),
      ( 350, 10836.6624414088, 100000000.000043, 2.17104009339793, 115.360270759806, 1 ),
      ( 400, 0.300713168811983, 999.9999999973, -0.000108481648697628, 116.54340170515, 2 ),
      ( 400, 3.01007352896871, 9999.9996062609, -0.00108570747233869, 116.564668776885, 2 ),
      ( 400, 30.4008748767815, 99999.9999980453, -0.0109477169552244, 116.780776655408, 2 ),
      ( 400, 341.885615998816, 999999.998137893, -0.120522967427526, 119.370633683969, 2 ),
      ( 400, 8032.63965970163, 10000000.0000093, -0.625676540103798, 123.66629951143, 1 ),
      ( 400, 10358.5296822792, 100000000.000365, 1.90273384520045, 126.643176941153, 1 ),
      ( 500, 0.240556507969556, 999.999999996879, -5.01770180380166E-05, 140.44257741935, 2 ),
      ( 500, 2.40665232270962, 9999.9999684274, -0.000501920065970104, 140.451026414424, 2 ),
      ( 500, 24.1761524390077, 99999.9999999973, -0.00503424531924307, 140.535886361184, 2 ),
      ( 500, 253.712344435475, 1000000.0003757, -0.0519009309877121, 141.423144155487, 2 ),
      ( 500, 4613.06673069728, 10000000, -0.478558513015577, 147.945799526942, 1 ),
      ( 500, 9473.54169296827, 100000000.009605, 1.53911837173792, 148.313865665003, 1 ),
      ( 600, 0.200458679692619, 999.999999999729, -2.48516295864183E-05, 161.096874516088, 2 ),
      ( 600, 2.00503529806398, 9999.99999724808, -0.000248533473042056, 161.101051725045, 2 ),
      ( 600, 20.095347583499, 100000, -0.0024870327051158, 161.142846184167, 2 ),
      ( 600, 205.597293190782, 999999.998457193, -0.0250178158243847, 161.562610135351, 2 ),
      ( 600, 2550.69827408489, 9999999.99999998, -0.214122266030546, 165.007915830372, 1 ),
      ( 600, 8681.76173491965, 99999999.9999997, 1.30890577382277, 167.535296653227, 1 ),
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