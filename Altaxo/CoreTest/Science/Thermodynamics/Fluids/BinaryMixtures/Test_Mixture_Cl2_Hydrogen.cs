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
  /// Tests and test data for <see cref="Mixture_Cl2_Hydrogen"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Cl2_Hydrogen : MixtureTestBase
  {

    public Test_Mixture_Cl2_Hydrogen()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("7782-50-5", 0.5), ("1333-74-0", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 200, 0.601357094244966, 1000.00000000075, 6.65681477342976E-06, 18.967743893195, 1 ),
      ( 200, 6.01321065257588, 10000.000007532, 6.6573603537772E-05, 18.9679737622342, 1 ),
      ( 200, 60.0960686124076, 100000, 0.000666285254408825, 18.9702722113913, 1 ),
      ( 200, 597.346266010738, 1000000.00581246, 0.00672111237490611, 18.9932317322618, 1 ),
      ( 200, 5597.65073397107, 10000000.0000002, 0.0743097880655733, 19.2196215726228, 1 ),
      ( 250, 0.481085811335144, 1000.00000000043, 6.37424548298265E-06, 20.0128708358057, 1 ),
      ( 250, 4.81058212955648, 10000.0000043469, 6.3744756337951E-05, 20.0130511442449, 1 ),
      ( 250, 48.0782293091417, 100000, 0.000637679064241352, 20.0148541587633, 1 ),
      ( 250, 478.028922336776, 1000000.00094848, 0.00640119335329286, 20.0328764022351, 1 ),
      ( 250, 4508.80127343226, 10000000.0000812, 0.0669995165438719, 20.2115557188317, 1 ),
      ( 300, 0.400905062150385, 1000.00000000024, 5.82705235193935E-06, 20.5379720627783, 1 ),
      ( 300, 4.0088403812843, 10000.0000023659, 5.82715062810548E-05, 20.538121443075, 1 ),
      ( 300, 40.0673879917571, 100000, 0.000582813952412348, 20.5396151743828, 1 ),
      ( 300, 398.580246127923, 1000000.00019371, 0.00583860370403524, 20.5545447252165, 1 ),
      ( 300, 3783.15174956618, 10000000.0000023, 0.0597179938424324, 20.7025700197959, 1 ),
      ( 350, 0.343633102148073, 1000.00000000013, 5.26908930014524E-06, 20.7776266709527, 1 ),
      ( 350, 3.43616807173556, 10000.0000013141, 5.26912759885487E-05, 20.7777543790525, 1 ),
      ( 350, 34.345392925971, 100000.013157084, 0.00052695144894218, 20.7790313739234, 1 ),
      ( 350, 341.832199293791, 1000000.00004739, 0.00527367954623103, 20.7917923276841, 1 ),
      ( 350, 3262.39322097459, 10000000.0000002, 0.0533215633611431, 20.9182010109826, 1 ),
      ( 400, 0.300679116303519, 1000.00000000001, 4.76381724274791E-06, 20.8775029858455, 1 ),
      ( 400, 3.0066622546569, 10000.0000000906, 4.76382678679678E-05, 20.877614455961, 1 ),
      ( 400, 30.0537374959772, 100000.000903652, 0.000476392413463623, 20.8787290636117, 1 ),
      ( 400, 299.254578290537, 1000000.00000018, 0.00476507458942973, 20.8898655706075, 1 ),
      ( 400, 2869.43610999265, 10000000.0016378, 0.047873300398775, 21.000091057892, 1 ),
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
      ( 200, 0.601409165507258, 999.999999824058, -7.93317415800569E-05, 21.1724476683863, 2 ),
      ( 200, 6.01839180503866, 9999.9999995835, -0.000793776557780792, 21.1830301133106, 2 ),
      ( 250, 0.481109015346104, 999.999999983784, -4.12621856430348E-05, 22.332038388438, 2 ),
      ( 250, 4.81287798420682, 9999.99983576801, -0.000412714973174113, 22.3362813736756, 2 ),
      ( 250, 48.3087464982219, 99999.9996045127, -0.0041365205592074, 22.3789625327728, 2 ),
      ( 300, 0.400917155879711, 999.999999997819, -2.37441386734698E-05, 23.0940236334868, 2 ),
      ( 300, 4.01002858475803, 9999.99997802907, -0.000237459724825162, 23.0957234539852, 2 ),
      ( 300, 40.186263628151, 99999.9999999992, -0.00237643350499368, 23.1127577884688, 2 ),
      ( 300, 410.744997725098, 1000000.00002161, -0.0239500452412853, 23.2868255887151, 2 ),
      ( 350, 0.343640043609966, 999.999999999648, -1.4336673924247E-05, 23.5905252196564, 2 ),
      ( 350, 3.43684389738208, 9999.99999644698, -0.000143366370277586, 23.5913315327339, 2 ),
      ( 350, 34.4128467737513, 100000, -0.00143362386099848, 23.5993943379116, 2 ),
      ( 350, 348.630673521191, 999999.98830551, -0.0143290791302105, 23.6799756523643, 2 ),
      ( 400, 0.300683365687176, 999.99999999994, -8.77451865597128E-06, 23.9247470545382, 2 ),
      ( 400, 3.00707111420322, 9999.99999939116, -8.7740142964661E-05, 23.9252185010394, 2 ),
      ( 400, 30.094462403498, 99999.9939487937, -0.000876894493309441, 23.9299285318176, 2 ),
      ( 400, 303.324393441222, 999999.999987687, -0.00871563963525466, 23.9765787200397, 2 ),
      ( 400, 3262.48126629028, 10000000.0094038, -0.078367957473382, 24.3894085524577, 2 ),
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
      ( 200, 0.601630967530085, 999.999999992853, -0.000447376498939741, 23.3763992101485, 2 ),
      ( 200, 6.040763009202, 9999.9999999968, -0.00449361931723466, 23.3906623770485, 2 ),
      ( 250, 0.481195076990748, 999.999999998427, -0.000219510582018904, 24.6550826821066, 2 ),
      ( 250, 4.8215003350017, 9999.99998376273, -0.00219969686692283, 24.6984335445951, 2 ),
      ( 250, 49.2151835409183, 99999.9999999944, -0.0224775872686792, 25.1459074911932, 2 ),
      ( 250, 21873.736416063, 10000000.012106, -0.780060689676382, 35.165524983803, 1 ),
      ( 300, 0.40095624587871, 999.999999999638, -0.000120639670198274, 25.6527644818591, 2 ),
      ( 300, 4.01392632721331, 9999.99999631825, -0.00120769050563057, 25.6802892786616, 2 ),
      ( 300, 40.5863247008839, 99999.9999999998, -0.0122094627711532, 25.9600386061823, 2 ),
      ( 300, 19928.6413727388, 10000000.0012217, -0.798828295818767, 34.418745216029, 1 ),
      ( 350, 0.343660395005567, 999.999999999907, -7.29612077419197E-05, 26.4051174347137, 2 ),
      ( 350, 3.43886370562577, 9999.99999905432, -0.000730036011667219, 26.4218918966098, 2 ),
      ( 350, 34.6177429027513, 99999.989658348, -0.00734336612812785, 26.5912871319913, 2 ),
      ( 350, 372.898316075334, 999999.995503658, -0.0784744621878158, 28.4759268799675, 2 ),
      ( 350, 17691.9464135517, 10000000.0001629, -0.805767373978589, 34.0111084631532, 1 ),
      ( 400, 0.300695168023997, 999.992096902916, -4.74298416237795E-05, 26.9730349786305, 2 ),
      ( 400, 3.00823632601838, 9999.99999978722, -0.000474452799839876, 26.9833010381161, 2 ),
      ( 400, 30.2118911349279, 99999.9972897, -0.00475973288155265, 27.0866770484453, 2 ),
      ( 400, 316.264674759759, 999999.999931768, -0.0492744527456548, 28.1983007306513, 2 ),
      ( 400, 14630.5048816336, 10000000.0001402, -0.794483574952937, 35.3187337752883, 1 ),
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
