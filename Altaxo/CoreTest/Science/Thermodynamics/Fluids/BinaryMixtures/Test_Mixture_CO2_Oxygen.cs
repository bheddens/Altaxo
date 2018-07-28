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
  /// Tests and test data for <see cref="Mixture_CO2_Oxygen"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_CO2_Oxygen : MixtureTestBase
  {

    public Test_Mixture_CO2_Oxygen()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("124-38-9", 0.5), ("7782-44-7", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 250, 0.481103110036078, 999.996600131128, -1.37281860822029E-05, 20.8922677060545, 2 ),
      ( 250, 4.81162557098543, 9999.9999999992, -0.000137275348974703, 20.8934322626076, 2 ),
      ( 250, 48.1757499601553, 99999.9999920525, -0.00137204768207261, 20.905081656146, 2 ),
      ( 250, 487.750261292644, 999999.999999999, -0.0136417270887908, 21.0219063897035, 2 ),
      ( 250, 5457.05377664553, 9999999.99242826, -0.118395154111588, 22.1476926446596, 2 ),
      ( 300, 0.400916250128651, 999.998452484369, -6.22492673903887E-06, 21.0785890551017, 2 ),
      ( 300, 4.00938708561054, 9999.99999999993, -6.22392151669663E-05, 21.0792919092089, 2 ),
      ( 300, 40.1163026584395, 99999.9999992624, -0.000621373649495178, 21.0863171193684, 2 ),
      ( 300, 403.377676068942, 999999.993650919, -0.00610822495454247, 21.1562152106366, 2 ),
      ( 300, 4206.57217030991, 9999999.99999996, -0.0469348005481469, 21.799190206868, 2 ),
      ( 350, 0.343641180985266, 999.999493964118, -2.33950322926461E-06, 21.3895234646486, 2 ),
      ( 350, 3.43648397780205, 9999.99999999999, -2.33867600816775E-05, 21.3900055690741, 2 ),
      ( 350, 34.3720460792295, 99999.9999999631, -0.000233037726456988, 21.3948230582701, 2 ),
      ( 350, 344.413853744689, 999999.99974166, -0.00224582367382067, 21.4426351609943, 2 ),
      ( 350, 3480.35440797006, 9999999.99999999, -0.0126282536898183, 21.8784079948177, 1 ),
      ( 400, 0.300685371991216, 999.999955423298, -1.83092044507193E-07, 21.8035385852079, 2 ),
      ( 400, 3.00685864517853, 9999.99566727413, -1.82476066812534E-06, 21.8038939485135, 2 ),
      ( 400, 30.0690617313423, 100000, -1.76309975768494E-05, 21.8074446399503, 2 ),
      ( 400, 300.719582586378, 999999.999999998, -0.000113949175529639, 21.842654784443, 1 ),
      ( 400, 2989.91885054515, 10000000, 0.00566380182209107, 22.1633614083086, 1 ),
      ( 500, 0.24054780897827, 1000.00042117506, 1.80833906919037E-06, 22.7921006305193, 1 ),
      ( 500, 2.40543902025349, 10000, 1.80866981721703E-05, 22.7923180074472, 1 ),
      ( 500, 24.0504673560603, 100000.000000016, 0.000181198598152442, 22.7944898830216, 1 ),
      ( 500, 240.105183019842, 1000000.000183, 0.00184531481007358, 22.816019305984, 1 ),
      ( 500, 2353.92373073822, 10000000, 0.0219033417657213, 23.0126031044038, 1 ),
      ( 600, 0.200456363953476, 1000.0005291911, 2.51031033611753E-06, 23.7941943995495, 1 ),
      ( 600, 2.0045184488929, 9999.99999999998, 2.51049620608631E-05, 23.7943401730809, 1 ),
      ( 600, 20.04065277411, 100000.000000034, 0.000251236747217148, 23.7957966327296, 1 ),
      ( 600, 199.950775387652, 1000000.00034362, 0.00253113215545379, 23.8102340232108, 1 ),
      ( 600, 1951.45282613548, 10000000, 0.0272186677564861, 23.9422984504269, 1 ),
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
      ( 250, 0.481111147121486, 999.99999999634, -4.06357000620089E-05, 23.7056807729071, 2 ),
      ( 250, 4.8128721214928, 9999.99996302374, -0.000406441954819275, 23.7110430589705, 2 ),
      ( 250, 48.3059075750653, 99999.9999999968, -0.00407295713845175, 23.7649070180099, 2 ),
      ( 250, 501.988189180714, 1000000.00094508, -0.0416276574192893, 24.3289323338565, 2 ),
      ( 300, 0.400918554440019, 999.999999999587, -2.21751082392451E-05, 24.9910868660261, 2 ),
      ( 300, 4.00998589502363, 9999.99999583893, -0.000221760068424115, 24.9936944186514, 2 ),
      ( 300, 40.1801058708625, 99999.9999999999, -0.00221849758916917, 25.0198179278842, 2 ),
      ( 300, 410.042346265581, 999999.996904699, -0.0222725342703965, 25.2857978544437, 2 ),
      ( 300, 5153.40162266574, 9999999.99309776, -0.222048476998386, 28.2345273810319, 2 ),
      ( 350, 0.343641183763086, 999.999999999943, -1.25970995996547E-05, 26.2297860410036, 2 ),
      ( 350, 3.43680146124975, 9999.99999942718, -0.000125963761923769, 26.2312609594505, 2 ),
      ( 350, 34.407000852427, 99999.9942697148, -0.00125891129052199, 26.2460195347076, 2 ),
      ( 350, 347.991432570824, 999999.999980383, -0.0125134623507874, 26.3944771589072, 2 ),
      ( 350, 3872.64653774686, 9999999.99425611, -0.112656289305266, 27.8806926145879, 2 ),
      ( 400, 0.300684392990846, 999.999999999992, -7.13362627733017E-06, 27.4058779916963, 2 ),
      ( 400, 3.00703696194921, 9999.99999991866, -7.13266063342514E-05, 27.406811474409, 2 ),
      ( 400, 30.0896576370059, 99999.9991975964, -0.000712299056861872, 27.4161468152992, 2 ),
      ( 400, 302.809445212298, 999999.99999984, -0.00702487061218588, 27.5095173088048, 2 ),
      ( 400, 3193.51451448868, 9999999.99999958, -0.0584597419031847, 28.4099788454755, 2 ),
      ( 500, 0.240546213899304, 999.990822449792, -1.69336706071128E-06, 29.5480601045855, 2 ),
      ( 500, 2.40549870121165, 9999.99999999928, -1.69266545663147E-05, 29.5485295613823, 2 ),
      ( 500, 24.0586349107807, 99999.9999931403, -0.000168549426627251, 29.5532223419964, 2 ),
      ( 500, 240.934603069238, 999999.999999998, -0.00161373521084565, 29.5999643162961, 2 ),
      ( 500, 2426.7958864988, 10000000.0002363, -0.00879262341404739, 30.042325076206, 1 ),
      ( 600, 0.200454701900262, 1000.00292585119, 6.36364779134888E-07, 31.3973432200913, 1 ),
      ( 600, 2.00453555501011, 10000, 6.3681226576985E-06, 31.3976287560404, 1 ),
      ( 600, 20.0441977592121, 100000.000000304, 6.41303876216208E-05, 31.4004827363255, 1 ),
      ( 600, 200.317404719546, 1000000.00607787, 0.000686047701954854, 31.4288829052767, 1 ),
      ( 600, 1982.30092231114, 10000000.0021235, 0.0112230174458339, 31.6976960090735, 1 ),
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
      ( 250, 0.481129223787986, 999.99999986768, -8.84073548058123E-05, 26.5204793372133, 2 ),
      ( 250, 4.81512664843386, 9999.99864015228, -0.000884662835406838, 26.5420106873952, 2 ),
      ( 250, 48.5410053175853, 99999.9999855031, -0.00890662368945565, 26.7597757013221, 2 ),
      ( 250, 532.406823096323, 999999.997269384, -0.0963927062719138, 29.3467702073609, 2 ),
      ( 250, 24447.7820970489, 10000000.0025507, -0.803218677819126, 41.4607943859434, 1 ),
      ( 300, 0.400925040229068, 999.999999995189, -4.85540657080968E-05, 28.9042085680236, 2 ),
      ( 300, 4.01100382059662, 9999.9998570106, -0.000485684824194033, 28.9136213803808, 2 ),
      ( 300, 40.2868094328597, 99999.9999999249, -0.00487137268620913, 29.0082500315696, 2 ),
      ( 300, 422.131924641388, 999999.999999994, -0.0502836902731284, 30.0113834686208, 2 ),
      ( 300, 18184.9209890104, 9999999.99990064, -0.779539557016754, 41.7901519625784, 1 ),
      ( 350, 0.343643301897156, 999.999999997502, -2.89632342520131E-05, 31.0704137029655, 2 ),
      ( 350, 3.43732916777568, 9999.9999748019, -0.000289666472867296, 31.0752794748042, 2 ),
      ( 350, 34.4632814918281, 99999.9999999989, -0.00290008959573256, 31.1240708511213, 2 ),
      ( 350, 354.025876039376, 1000000.00002021, -0.0293552756090893, 31.6256614310832, 2 ),
      ( 350, 5192.93261239767, 9999999.99981932, -0.338267267210625, 38.2894095994273, 2 ),
      ( 400, 0.300684621256402, 999.999999999524, -1.80953390236191E-05, 33.0084768676547, 2 ),
      ( 400, 3.00733599825761, 9999.99999520527, -0.000180956033930899, 33.0112952530507, 2 ),
      ( 400, 30.1224343559179, 100000, -0.00180982481741231, 33.0395199385424, 2 ),
      ( 400, 306.229461439927, 999999.997125163, -0.0181245825650033, 33.3257743102783, 2 ),
      ( 400, 3668.74383024451, 9999999.99691194, -0.180430157573489, 36.4498380712661, 2 ),
      ( 500, 0.24054511841054, 999.999999999979, -7.37573707215726E-06, 36.3042092730621, 2 ),
      ( 500, 2.4056108533652, 9999.99999978505, -7.37489336729466E-05, 36.3053974238183, 2 ),
      ( 500, 24.0720670024137, 99999.9978818189, -0.000736645537571061, 36.3172826560183, 2 ),
      ( 500, 242.307814902649, 999999.999998853, -0.00728193877455077, 36.4364665912835, 2 ),
      ( 500, 2568.83365863769, 9999999.99989209, -0.0636087182822807, 37.6192442858919, 2 ),
      ( 600, 0.200453333274451, 999.999999999999, -2.67252573922656E-06, 39.0006683997609, 2 ),
      ( 600, 2.00458142711961, 9999.99999999269, -2.67181354085606E-05, 39.0012846749525, 2 ),
      ( 600, 20.0506215687822, 99999.9999298847, -0.00026646976224805, 39.0074469219911, 2 ),
      ( 600, 200.974109218066, 1000000, -0.00259397777832376, 39.0690061165507, 2 ),
      ( 600, 2043.50509682969, 9999999.99983894, -0.0190737123426675, 39.6667090556169, 2 ),
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
