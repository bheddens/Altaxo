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
  /// Tests and test data for <see cref="Mixture_SO2_CO"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_SO2_CO : MixtureTestBase
  {

    public Test_Mixture_SO2_CO()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("7446-09-5", 0.5), ("630-08-0", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 200, 0.601376892013314, 999.999999999928, -2.62641377949692E-05, 20.7992963619265, 2 ),
      ( 200, 6.01519063836205, 9999.99999927448, -0.000262612571957823, 20.8010968598368, 2 ),
      ( 200, 60.2942756014444, 99999.9926771009, -0.00262323166350632, 20.819154644649, 2 ),
      ( 200, 617.368010510767, 999999.999920807, -0.0259276685368234, 21.0047268082323, 2 ),
      ( 200, 7445.79419266042, 10000000, -0.192347945957817, 22.8531801550315, 1 ),
      ( 250, 0.481093990001208, 999.986415294931, -1.06258603650707E-05, 20.8081922527696, 2 ),
      ( 250, 4.81139984721241, 9999.9999999713, -0.000106220286526352, 20.8091356203942, 2 ),
      ( 250, 48.1598518093401, 99999.999693147, -0.0010582262577271, 20.818582741041, 2 ),
      ( 250, 486.038594783498, 999999.999999977, -0.0101837939258672, 20.9142822035389, 2 ),
      ( 250, 5113.89155432568, 9999999.99999917, -0.0592509192196946, 21.871949141458, 1 ),
      ( 300, 0.400908781612359, 999.999943957484, -3.45057822334803E-06, 20.8368328162278, 2 ),
      ( 300, 4.00921220490766, 9999.99442513749, -3.44761943023994E-05, 20.8374504780222, 2 ),
      ( 300, 40.1044478812513, 99999.9999999997, -0.000341808887994156, 20.8436314972889, 2 ),
      ( 300, 402.164754035545, 999999.999999371, -0.00312646937984673, 20.9058338058965, 2 ),
      ( 300, 4028.25546985148, 10000000.0153689, -0.00476173554586801, 21.5248207298662, 1 ),
      ( 350, 0.343634849971756, 1000.00002172355, 1.79187933339435E-07, 20.9073052533399, 1 ),
      ( 350, 3.43634290055414, 10000.0022245566, 1.81217742073764E-06, 20.9077626317918, 1 ),
      ( 350, 34.3627989510245, 100000, 2.01475768592945E-05, 20.9123379043521, 1 ),
      ( 350, 343.497447929183, 1000000.00000581, 0.000400191771969799, 20.9582176812998, 1 ),
      ( 350, 3365.92552078133, 10000000.0081596, 0.0209225090402751, 21.4116082231657, 1 ),
      ( 400, 0.300679898885615, 1000.00034659095, 2.11871665397368E-06, 21.0377440579369, 1 ),
      ( 400, 3.00674174097998, 10000, 2.12009757689576E-05, 21.0381075254714, 1 ),
      ( 400, 30.0616400703646, 100000.000000016, 0.00021338815873292, 21.0417425672188, 1 ),
      ( 400, 299.999957568222, 1000000.00028475, 0.00226863737040059, 21.0781184830108, 1 ),
      ( 400, 2908.49346281105, 10000000.004856, 0.0338017002092141, 21.4355488486903, 1 ),
      ( 500, 0.240543517888837, 1000.00079191082, 3.75399106353742E-06, 21.4932672928177, 1 ),
      ( 500, 2.40535407692144, 10000, 3.75464678777154E-05, 21.4935248707456, 1 ),
      ( 500, 24.0453999055592, 100000.000000143, 0.000376121386472329, 21.49610033841, 1 ),
      ( 500, 239.627809098473, 1000000.00167931, 0.00382522316859084, 21.5218203132996, 1 ),
      ( 500, 2305.4297475708, 10000000.0000037, 0.0433822119306153, 21.7728499663483, 1 ),
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
      ( 200, 0.601463746690378, 999.999999999881, -0.000170071796001149, 24.4359684072176, 2 ),
      ( 250, 0.48112847349111, 999.999999999984, -8.17032386928204E-05, 25.3218387942245, 2 ),
      ( 250, 4.81482777729549, 9999.99999982931, -0.00081750378434674, 25.3399630494819, 2 ),
      ( 250, 48.5077892399934, 99999.9999928777, -0.00822286208138909, 25.5232207083281, 2 ),
      ( 300, 0.400925840566856, 999.990658860084, -4.54047801290501E-05, 26.2343810907093, 2 ),
      ( 300, 4.01089796783678, 9999.99999997989, -0.000454163476522116, 26.2411576483566, 2 ),
      ( 300, 40.2741254588124, 99999.9997741836, -0.00455284406119699, 26.3092803644642, 2 ),
      ( 350, 0.343644410727217, 999.997105107615, -2.70446581089296E-05, 27.1645649038487, 2 ),
      ( 350, 3.43728085163034, 9999.99999999884, -0.000270470212744144, 27.1678371853157, 2 ),
      ( 350, 34.4567858211357, 99999.9999876423, -0.00270698857404624, 27.2006306644088, 2 ),
      ( 350, 353.279493552815, 999999.999999998, -0.0272995652850159, 27.5357945137233, 2 ),
      ( 400, 0.30068571594219, 999.999650159993, -1.65907617383034E-05, 28.0924698452749, 2 ),
      ( 400, 3.00730620265404, 9999.99999999987, -0.000165905719828186, 28.0944500977736, 2 ),
      ( 400, 30.1180342721423, 99999.9999981614, -0.0016588578831258, 28.1142667166932, 2 ),
      ( 400, 305.745256965154, 1000000, -0.0165645402975359, 28.3137817125246, 2 ),
      ( 400, 3560.26860067936, 9999999.99998604, -0.155454935961669, 30.3341957223154, 2 ),
      ( 500, 0.240546044882422, 999.999382063493, -6.08205060821564E-06, 29.8580915144778, 2 ),
      ( 500, 2.40559210597998, 10000, -6.08113472866846E-05, 29.8591401431124, 2 ),
      ( 500, 24.0690727560541, 99999.9999999101, -0.000607192864104846, 29.8696252578752, 2 ),
      ( 500, 241.991404492743, 999999.999087961, -0.00597881820230269, 29.9743306454501, 2 ),
      ( 500, 2529.04659666586, 10000000, -0.0488724795129583, 30.9792360548676, 2 ),
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
      ( 200, 0.601835131957177, 999.999999998925, -0.000786461204771269, 28.0927810057996, 2 ),
      ( 200, 25463.8470102008, 10000000.0000019, -0.763837014990982, 56.1268497772281, 1 ),
      ( 250, 0.481245591803491, 999.999999999466, -0.000324454346835353, 29.848595736677, 2 ),
      ( 250, 4.82660355927444, 9999.99999451559, -0.00325468276934885, 30.0024934796684, 2 ),
      ( 250, 23363.1936303284, 1000000.00091006, -0.97940823255635, 53.097845973844, 1 ),
      ( 250, 23551.4300401212, 10000000.0000024, -0.795728136780204, 53.1117649038432, 1 ),
      ( 300, 0.400971976874359, 999.999999999849, -0.000159867094492773, 31.6388581478156, 2 ),
      ( 300, 4.01550739302705, 9999.99999847963, -0.00160095497258817, 31.7143592682121, 2 ),
      ( 300, 40.7528348683384, 99999.982430985, -0.0162454289937097, 32.4853448047907, 2 ),
      ( 300, 21268.7214843427, 1000000.01528077, -0.981150353533918, 51.8692067710536, 1 ),
      ( 300, 21566.4837490243, 10000000.0000239, -0.814106054879039, 51.6263018095054, 1 ),
      ( 350, 0.343666524811795, 999.999999999957, -9.0796401303022E-05, 33.4250166362532, 2 ),
      ( 350, 3.43947837150469, 9999.9999995772, -0.000908614587895702, 33.459941767558, 2 ),
      ( 350, 34.6809425649017, 99999.9954080595, -0.00915230119056263, 33.8135986445081, 2 ),
      ( 350, 381.62130049776, 999999.999022347, -0.0995384148604421, 37.8889630671347, 2 ),
      ( 350, 19311.1779810123, 10000000.0033008, -0.822053671932321, 50.8221158670472, 1 ),
      ( 400, 0.300697977217603, 999.995089919879, -5.67717377205134E-05, 35.1486063004746, 2 ),
      ( 400, 3.00851771319399, 9999.99999990173, -0.000567938594992027, 35.1649874215637, 2 ),
      ( 400, 30.2405047130634, 99999.9987542026, -0.00570142967838343, 35.3300810502214, 2 ),
      ( 400, 319.684976340491, 999999.99998445, -0.0594462416427653, 37.1244013931011, 2 ),
      ( 400, 16288.6720322538, 9999999.99999945, -0.815404898943466, 51.186495548465, 1 ),
      ( 500, 0.240550926703566, 999.992577319781, -2.57819329540068E-05, 38.223227078091, 2 ),
      ( 500, 2.40606765461353, 9999.99999999284, -0.000257850902769426, 38.2279595142811, 2 ),
      ( 500, 24.1167293327734, 99999.9999276485, -0.00258147996850721, 38.2753993424427, 2 ),
      ( 500, 246.995459302741, 999999.999999992, -0.026116814176605, 38.7617900622888, 2 ),
      ( 500, 3405.87994348746, 10000000.0000036, -0.293736923256895, 45.2769729910773, 2 ),
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
