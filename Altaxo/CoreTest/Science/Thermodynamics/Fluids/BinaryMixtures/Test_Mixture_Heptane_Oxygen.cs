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
  /// Tests and test data for <see cref="Mixture_Heptane_Oxygen"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Heptane_Oxygen : MixtureTestBase
  {

    public Test_Mixture_Heptane_Oxygen()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("142-82-5", 0.5), ("7782-44-7", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 200, 0.60138871275403, 999.999999960817, -3.00655431195753E-05, 20.9110878575236, 2 ),
      ( 250, 0.481103145371922, 999.996575290425, -1.38016320238225E-05, 21.0028975245323, 2 ),
      ( 250, 4.81162910542856, 9999.99999999918, -0.000138009810808573, 21.0040683105166, 2 ),
      ( 250, 48.1761042611255, 99999.9999918905, -0.00137939188014139, 21.0157801274877, 2 ),
      ( 300, 0.400916265747, 999.998444799836, -6.26388302374175E-06, 21.2073418532197, 2 ),
      ( 300, 4.0093886473638, 9999.99999999995, -6.26287149612412E-05, 21.2080480768381, 2 ),
      ( 300, 40.116458750296, 99999.9999992504, -0.000625262199728556, 21.2151069908949, 2 ),
      ( 300, 403.393182968306, 999999.993540011, -0.00614643129940252, 21.2853426845808, 2 ),
      ( 300, 4207.80512785156, 9999999.99999997, -0.0472140646513183, 21.9314173421734, 2 ),
      ( 350, 0.343641188249243, 999.999491305231, -2.36022697604613E-06, 21.5383776894133, 2 ),
      ( 350, 3.43648468977738, 10000, -2.35939365238007E-05, 21.5388619687238, 2 ),
      ( 350, 34.3721170959806, 99999.9999999623, -0.000235103360101126, 21.5437011960636, 2 ),
      ( 350, 344.420768008762, 999999.99973567, -0.00226585363854334, 21.5917294826978, 2 ),
      ( 350, 3480.79988859742, 10000000, -0.0127546197548195, 22.0294338982981, 1 ),
      ( 400, 0.300685375145348, 999.99995306269, -1.93376190466211E-07, 21.9728596841689, 2 ),
      ( 400, 3.0068589542625, 9999.99543556302, -1.92755336356145E-06, 21.9732166092911, 2 ),
      ( 400, 30.0690924942121, 99999.9999999999, -1.86540523131398E-05, 21.9767829061889, 2 ),
      ( 400, 300.722511532113, 1000000, -0.000123687761339033, 22.0121477709852, 1 ),
      ( 400, 2990.05229132845, 10000000, 0.00561892081253781, 22.33422679342, 1 ),
      ( 500, 0.240547808983234, 1000.00041969463, 1.80831882527759E-06, 22.9995641397078, 1 ),
      ( 500, 2.40543902067242, 10000, 1.80865240087772E-05, 22.9997824694682, 1 ),
      ( 500, 24.050467330012, 100000.000000015, 0.00018119968141658, 23.0019638634203, 1 ),
      ( 500, 240.105112728014, 1000000.00018193, 0.00184560810469256, 23.0235874656951, 1 ),
      ( 500, 2353.85286970143, 10000000, 0.0219341054261128, 23.2210064019898, 1 ),
      ( 600, 0.200456363098812, 1000.00052268973, 2.51449031479731E-06, 24.0342797655548, 1 ),
      ( 600, 2.00451836507271, 10000, 2.51467787392467E-05, 24.0344261912742, 1 ),
      ( 600, 20.0406443623429, 100000.000000033, 0.00025165658803336, 24.0358891656515, 1 ),
      ( 600, 199.949904763906, 1000000.00033586, 0.00253549738584985, 24.0503909873422, 1 ),
      ( 600, 1951.33952349315, 10000000, 0.0272783122150245, 24.1830283223422, 1 ),
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
      ( 300, 0.400961510909303, 999.999999977398, -0.000129306380317785, 89.3706966045338, 2 ),
      ( 300, 4.01429227707185, 9999.99056195925, -0.00129428340686009, 89.3980143214073, 2 ),
      ( 350, 0.343663479410691, 999.999999997076, -7.74726772505245E-05, 100.658925533903, 2 ),
      ( 350, 3.43903400952024, 9999.99997035552, -0.000775060873478389, 100.672909847752, 2 ),
      ( 350, 34.633282298901, 99999.999998004, -0.00778432737377943, 100.813980106686, 2 ),
      ( 400, 0.300696962683437, 999.99999999975, -4.89351889242038E-05, 112.067976557356, 2 ),
      ( 400, 3.0082947914618, 9999.99999746847, -0.000489417213349333, 112.075863054167, 2 ),
      ( 400, 30.216306315631, 100000, -0.00490071523925857, 112.15515163846, 2 ),
      ( 500, 0.240550818134831, 999.999798617426, -2.08675956786477E-05, 133.28112250396, 2 ),
      ( 500, 2.40595993519608, 9999.99999999994, -0.000208628174833521, 133.284314169011, 2 ),
      ( 500, 24.1047536833048, 99999.9999994096, -0.00208149157050334, 133.316301029041, 2 ),
      ( 500, 245.536845642762, 999999.999989316, -0.0203270804959544, 133.642425881632, 2 ),
      ( 600, 0.200456537246475, 999.980898760991, -8.5065824672768E-06, 151.441366179401, 2 ),
      ( 600, 2.00471875761986, 9999.9999999845, -8.50181507087302E-05, 151.443014663376, 2 ),
      ( 600, 20.0624411422305, 99999.9998521169, -0.000845258096911238, 151.459514715262, 2 ),
      ( 600, 202.064591230783, 999999.999999996, -0.00796655759319856, 151.625746903601, 2 ),
      ( 600, 2077.82035985698, 10000000.000004, -0.0352638953463787, 153.151988881763, 1 ),
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
      ( 300, 0.401356611978313, 999.999999967185, -0.00112378437629297, 157.591037968659, 2 ),
      ( 350, 0.34384643687713, 999.999993053956, -0.000619718505341812, 179.808160237083, 2 ),
      ( 350, 3.45788228446419, 9999.99999999801, -0.00623178979608948, 180.08099971735, 2 ),
      ( 400, 0.30079235595139, 999.999998795239, -0.000376258514454059, 202.17944943654, 2 ),
      ( 400, 3.01818540687382, 9999.98700825526, -0.00377497992532669, 202.32607511311, 2 ),
      ( 400, 31.2909416766397, 99999.9999999995, -0.0390855495067669, 203.85371290486, 2 ),
      ( 400, 6048.22810348318, 10000000.0024028, -0.502864020357416, 217.330085519916, 1 ),
      ( 500, 0.240583581047799, 999.99999992982, -0.000167246803076736, 243.570045988132, 2 ),
      ( 500, 2.40946841678023, 9999.99927571649, -0.00167463259831868, 243.622332513832, 2 ),
      ( 500, 24.4695503090012, 99999.9999915733, -0.0169686766786908, 244.154362835583, 2 ),
      ( 500, 301.093561931902, 999999.999928477, -0.201101004366886, 250.809669931184, 2 ),
      ( 500, 5088.58728282141, 9999999.99999998, -0.527288556049654, 255.521803926633, 1 ),
      ( 600, 0.200470079241139, 999.999999993004, -8.62592414989415E-05, 278.853227877352, 2 ),
      ( 600, 2.0062592471973, 9999.99992898398, -0.000862988542261535, 278.875978397606, 2 ),
      ( 600, 20.2205893240487, 99999.9999999719, -0.00866990739732715, 279.105574710504, 2 ),
      ( 600, 220.551597526442, 1000000, -0.0911297442761492, 281.624452894031, 2 ),
      ( 600, 3829.87498787828, 9999999.99995978, -0.476607493774408, 290.124009137148, 1 ),
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