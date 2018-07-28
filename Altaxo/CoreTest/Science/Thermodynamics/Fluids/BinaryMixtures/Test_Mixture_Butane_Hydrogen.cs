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
  /// Tests and test data for <see cref="Mixture_Butane_Hydrogen"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Butane_Hydrogen : MixtureTestBase
  {

    public Test_Mixture_Butane_Hydrogen()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("106-97-8", 0.5), ("1333-74-0", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 150, 0.801810328302327, 1000.0000000034, 5.57143396559642E-06, 17.1111732037911, 1 ),
      ( 200, 0.601357101633422, 1000.00000000206, 6.64333768451432E-06, 19.0124950714838, 1 ),
      ( 200, 6.01321145528685, 10000.0000208677, 6.64389127393722E-05, 19.0127258598035, 1 ),
      ( 200, 60.0961489479936, 100000, 0.000664946387981671, 19.0150334939448, 1 ),
      ( 200, 597.353709860489, 1000000.00969795, 0.00670856607122438, 19.038084085238, 1 ),
      ( 250, 0.481085811680918, 1000.00000000172, 6.3723360405588E-06, 20.0667463306002, 1 ),
      ( 250, 4.81058221545475, 10000.0000173421, 6.37257084053613E-05, 20.0669272781311, 1 ),
      ( 250, 48.0782381804035, 100000, 0.000637493237927269, 20.0687366825802, 1 ),
      ( 250, 478.02957785966, 1000000.00795282, 0.00639981212010346, 20.0868227179064, 1 ),
      ( 250, 4508.64718017275, 10000000.0000061, 0.0670359824051699, 20.2661225851302, 1 ),
      ( 300, 0.400905060431664, 1000.00000000093, 5.83014877669552E-06, 20.602951405032, 1 ),
      ( 300, 4.00884025227175, 10000.0000093884, 5.83024994456467E-05, 20.6031012876897, 1 ),
      ( 300, 40.0673754173381, 100000, 0.000583126775791276, 20.6046000429139, 1 ),
      ( 300, 398.578889847942, 1000000.00341792, 0.00584202518201118, 20.6195798553717, 1 ),
      ( 300, 3782.92334723825, 10000000.000092, 0.0597819753887177, 20.7681035171858, 1 ),
      ( 350, 0.343633099888163, 1000.00000000052, 5.27447515407097E-06, 20.8547808577689, 1 ),
      ( 350, 3.43616788252133, 10000.0000051962, 5.27451536318976E-05, 20.8549089865438, 1 ),
      ( 350, 34.3453743247844, 100000, 0.000527492065868322, 20.8561901883935, 1 ),
      ( 350, 341.830294913561, 1000000.00079216, 0.00527927886114191, 20.8689932494056, 1 ),
      ( 350, 3262.16066691373, 10000000.0000044, 0.0533966516662232, 20.9958216830377, 1 ),
      ( 400, 0.300679114016031, 1000.0000000003, 4.77023431729208E-06, 20.9669801716687, 1 ),
      ( 400, 3.0066620581065, 10000.0000029875, 4.77024518765935E-05, 20.9670920067888, 1 ),
      ( 400, 30.0537181398824, 99999.9999999999, 0.000477035574635592, 20.9682102647606, 1 ),
      ( 400, 299.252622750122, 1000000.00021517, 0.00477163928033621, 20.9793832996163, 1 ),
      ( 400, 2869.22074885612, 10000000.0000003, 0.0479519515733741, 21.0899730719694, 1 ),
      ( 500, 0.240543470338751, 1000, 3.94662592339154E-06, 21.0597969900802, 1 ),
      ( 500, 2.40534945671116, 10000.0000000333, 3.94661555073478E-05, 21.0598858168748, 1 ),
      ( 500, 24.0449545019742, 100000.000332121, 0.000394650949534841, 21.0607739945378, 1 ),
      ( 500, 239.599094853418, 1000000.00000002, 0.00394552327039838, 21.0696466598221, 1 ),
      ( 500, 2314.24490558639, 10000000.0000522, 0.039407878051631, 21.1573919733672, 1 ),
      ( 500, 17331.2128782025, 100000000.000002, 0.387926167378748, 21.9266269634693, 1 ),
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
      ( 200, 0.601479548861715, 999.999999999323, -0.00019693472574514, 43.5500653699523, 2 ),
      ( 250, 0.481137630949648, 999.999999148449, -0.000101329900419092, 49.2705990227411, 2 ),
      ( 250, 4.81577215881217, 9999.99999954907, -0.00101403999943471, 49.2824845797769, 2 ),
      ( 300, 0.400930626068223, 999.999999887963, -5.79359592362313E-05, 55.5841386103808, 2 ),
      ( 300, 4.0113988559067, 9999.99885454264, -0.000579567887794033, 55.5900733091569, 2 ),
      ( 300, 40.3252967971789, 99999.9991208869, -0.00581662220362293, 55.6497308728887, 2 ),
      ( 350, 0.343646982286455, 999.999999981618, -3.51230031592556E-05, 62.1678861175781, 2 ),
      ( 350, 3.43755670357275, 9999.99981394283, -0.000351290154687372, 62.1712955109157, 2 ),
      ( 350, 34.4848398259719, 99999.9999999278, -0.00351889668158872, 62.2054295462072, 2 ),
      ( 350, 356.382020030349, 1000000.00000499, -0.0357680997961622, 62.5507862407528, 2 ),
      ( 350, 14484.5326295206, 99999999.9999992, 1.37242665097194, 66.6802006836824, 1 ),
      ( 400, 0.300687141397365, 999.999999999809, -2.19266825822409E-05, 68.6635101462754, 2 ),
      ( 400, 3.00746495725343, 9999.99997254426, -0.000219279028150303, 68.6656793342349, 2 ),
      ( 400, 30.1341687456241, 99999.9999999986, -0.00219398495882591, 68.6873613788362, 2 ),
      ( 400, 307.454558319095, 1000000.00000064, -0.022032556714317, 68.903053274644, 2 ),
      ( 400, 13693.1401789072, 100000000.000982, 1.19584802608542, 72.7931274479723, 1 ),
      ( 500, 0.24054647696195, 999.999999999942, -8.47362758583721E-06, 80.6394126997645, 2 ),
      ( 500, 2.40564820983622, 9999.99999941353, -8.47269474006195E-05, 80.6405088496892, 2 ),
      ( 500, 24.0748189670919, 99999.9942495795, -0.000846324114749175, 80.6514565784675, 2 ),
      ( 500, 242.571430893476, 999999.999994793, -0.00835626943087547, 80.7595136371019, 2 ),
      ( 500, 2562.74309019069, 9999999.99331255, -0.0613790372276486, 81.6538786285086, 1 ),
      ( 500, 12256.4000063096, 100000000.000002, 0.962602709905016, 84.1281373419789, 1 ),
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
      ( 200, 0.602049568427662, 999.999999208843, -0.00114354666346772, 68.1309118362872, 2 ),
      ( 200, 11712.1003082654, 10000000.0000016, -0.486547177008493, 86.0230968194226, 1 ),
      ( 200, 12446.0870206671, 100000000.001691, 3.83172820230796, 89.435999323243, 1 ),
      ( 250, 0.481339308598101, 999.999987052511, -0.000520280120478496, 78.4900405822328, 2 ),
      ( 250, 4.83619065190837, 9999.99694898568, -0.00523177695140438, 78.6559452695875, 2 ),
      ( 250, 10772.8307214427, 1000000.00080136, -0.955342389581533, 91.3893831058434, 1 ),
      ( 250, 10922.442045584, 9999999.99999727, -0.559540920145535, 91.8283068960841, 1 ),
      ( 250, 11883.2035132609, 100000000.017011, 3.04847797869446, 95.3291729160332, 1 ),
      ( 300, 0.40102005024294, 999.999998564477, -0.000280914819338429, 90.5721407322829, 2 ),
      ( 300, 4.02039746896302, 9999.984580839, -0.00281650604033941, 90.6456131724901, 2 ),
      ( 300, 41.2857190693441, 100000.006877571, -0.0289441338137064, 91.4248676587111, 2 ),
      ( 300, 9842.99186126747, 1000000.00000042, -0.959269762342731, 100.452811675784, 1 ),
      ( 300, 10084.3528860549, 10000000.0006777, -0.602446084224022, 100.865840758146, 1 ),
      ( 300, 11351.5518539303, 99999999.999997, 2.53174088377168, 104.412429065458, 1 ),
      ( 350, 0.343692813980124, 999.999999768327, -0.000168469066982273, 103.484392352516, 2 ),
      ( 350, 3.4421562482643, 9999.99759158923, -0.00168705971410177, 103.52180134937, 2 ),
      ( 350, 34.9618581683035, 99999.9998852353, -0.0171148492017801, 103.907164971037, 2 ),
      ( 350, 9149.59980212876, 10000000.0000003, -0.62442629207446, 111.721457138331, 1 ),
      ( 350, 10847.4721405102, 100000000.000021, 2.16788010996927, 115.17176090941, 1 ),
      ( 400, 0.300713048921057, 999.999999997283, -0.000108078433291403, 116.361915889515, 2 ),
      ( 400, 3.0100613704959, 9999.99960374218, -0.00108166801492125, 116.383058260129, 2 ),
      ( 400, 30.3996103763178, 99999.9999980291, -0.0109065718753394, 116.597883422678, 2 ),
      ( 400, 341.685373879746, 999999.998332733, -0.120007552595918, 119.169982151798, 2 ),
      ( 400, 8033.5415920796, 10000000.0000097, -0.625718563998508, 123.469195933215, 1 ),
      ( 400, 10368.599889578, 100000000.000241, 1.89991466088656, 126.43729268227, 1 ),
      ( 500, 0.240556463878464, 999.999999996857, -4.9989169209138E-05, 140.219727946054, 2 ),
      ( 500, 2.40664780747597, 9999.99996822695, -0.000500040289017748, 140.228131197814, 2 ),
      ( 500, 24.1756926404012, 99999.999999997, -0.00501531747281857, 140.312528980358, 2 ),
      ( 500, 253.657882059763, 1000000.00037507, -0.0516973622017116, 141.194653544541, 2 ),
      ( 500, 4600.93886883994, 10000000.0000001, -0.477184015006621, 147.702605328318, 1 ),
      ( 500, 9482.25624822285, 100000000.007299, 1.53678483662867, 148.073388227984, 1 ),
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
