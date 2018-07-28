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
  /// Tests and test data for <see cref="Mixture_Hydrogen_Water"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Hydrogen_Water : MixtureTestBase
  {

    public Test_Mixture_Hydrogen_Water()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("1333-74-0", 0.5), ("7732-18-5", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 300, 0.401104441766687, 999.999999772921, -0.000479167006971327, 25.398897899963, 2 ),
      ( 350, 0.343707565304725, 999.999999730806, -0.000199290106976379, 25.5909467960451, 2 ),
      ( 350, 3.44329724866203, 9999.99983214862, -0.00200580146535447, 25.8801820812649, 2 ),
      ( 400, 0.300715541853166, 999.999999971196, -0.000104276417274604, 25.953854010303, 2 ),
      ( 400, 3.00998875786126, 9999.99969789845, -0.00104549049181069, 26.0551656564984, 2 ),
      ( 400, 30.3946642244152, 100000.000042946, -0.0107336531888761, 27.1512928961955, 2 ),
      ( 500, 0.240557113043752, 999.999999998948, -4.0595734437718E-05, 26.9084387086233, 2 ),
      ( 500, 2.40645099869255, 9999.99998932815, -0.000406209883877546, 26.9310005298845, 2 ),
      ( 500, 24.1534625529301, 99999.9999999997, -0.00408752191392004, 27.1620346410331, 2 ),
      ( 500, 251.51669025169, 999999.99999998, -0.0436127828719411, 30.0456237896671, 2 ),
      ( 500, 46435.3330363697, 9999999.99999913, -0.948197346349182, 57.9424940294526, 1 ),
      ( 500, 49852.7056304274, 99999999.9999989, -0.517483866905014, 57.2407612688676, 1 ),
      ( 500, 63218.2308508953, 1000000000.00004, 2.80503130526429, 54.9998857154499, 1 ),
      ( 600, 0.200460125062775, 999.999999999993, -1.99650024138052E-05, 28.0044304239594, 2 ),
      ( 600, 2.00496160671265, 9999.99999930638, -0.000199693576341908, 28.0126334786517, 2 ),
      ( 600, 20.0858100612205, 99999.9912756574, -0.00200130191217033, 28.0953032114594, 2 ),
      ( 600, 204.643392652762, 999999.999800793, -0.0204612996380355, 28.9869288982745, 2 ),
      ( 600, 2754.59016861927, 10000000.0000008, -0.272283314013408, 46.969941223002, 2 ),
      ( 600, 43860.4631130451, 99999999.9999999, -0.542968521879848, 52.6988636716798, 1 ),
      ( 600, 60538.5121686761, 1000000000.00005, 2.31121654125524, 52.9945333994353, 1 ),
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
      ( 300, 0.400917255495604, 999.999555315194, -1.8535796688168E-05, 22.9074392805862, 2 ),
      ( 350, 0.343640707554732, 999.999999999907, -1.08118962527706E-05, 23.1683346131274, 2 ),
      ( 350, 3.43674152045259, 9999.99999907172, -0.000108125379755143, 23.1702219627465, 2 ),
      ( 400, 0.300684333753741, 999.999999999984, -6.53717153866286E-06, 23.4097175235871, 2 ),
      ( 400, 3.00702025996141, 9999.99999984309, -6.53732458358548E-05, 23.4108763836933, 2 ),
      ( 400, 30.0879108104296, 99999.9999999325, -0.000653883803520054, 23.4224668122168, 2 ),
      ( 500, 0.240546477959892, 1000, -2.37798786243399E-06, 23.9262285988689, 2 ),
      ( 500, 2.40551614663619, 9999.99999999516, -2.37793485176724E-05, 23.9267793715651, 2 ),
      ( 500, 24.0603095443003, 99999.9999517872, -0.000237739834276499, 23.9322858779637, 2 ),
      ( 500, 241.11765329848, 999999.999999964, -0.0023712854993557, 23.9872269231313, 2 ),
      ( 600, 0.200455037321293, 999.99570094969, -6.12503584656021E-07, 24.5124421081643, 2 ),
      ( 600, 2.00456139766282, 9999.99999999995, -6.12443451243795E-06, 24.5127630818504, 2 ),
      ( 600, 20.046717691468, 99999.9999994341, -6.11812321977556E-05, 24.5159720210569, 2 ),
      ( 600, 200.576291050287, 999999.995288915, -0.000605151103835921, 24.5479815433176, 2 ),
      ( 600, 2014.77138405164, 9999999.99986821, -0.00507365911167753, 24.8597957573675, 2 ),
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
      ( 300, 0.400905066473965, 1000.00000000003, 5.8271815948184E-06, 20.5375985086937, 1 ),
      ( 300, 4.00884041989518, 10000.0000003018, 5.82727887018277E-05, 20.5377476907714, 1 ),
      ( 300, 40.067387955794, 100000.00302102, 0.000582825788265116, 20.5392394406407, 1 ),
      ( 300, 398.580245936166, 1000000.00000264, 0.00583861516434102, 20.5541492443862, 1 ),
      ( 350, 0.343633106933703, 1000.00000000002, 5.26607650705041E-06, 20.7767820541921, 1 ),
      ( 350, 3.43616821277193, 10000.0000002009, 5.26611435212197E-05, 20.7769095737071, 1 ),
      ( 350, 34.345403660149, 100000.002006846, 0.00052664960893808, 20.7781846829464, 1 ),
      ( 350, 341.83324588175, 1000000.00000104, 0.00527061267942915, 20.7909268190074, 1 ),
      ( 350, 3262.5097618141, 10000000.0127278, 0.0532839489904837, 20.9171507756213, 1 ),
      ( 350, 22152.8766933078, 100000000, 0.551197712555966, 21.9971762385992, 1 ),
      ( 400, 0.300679120982201, 1000.00000000001, 4.75917063042881E-06, 20.8764727808242, 1 ),
      ( 400, 3.00666242717746, 10000.0000001138, 4.75918000212209E-05, 20.8765840686882, 1 ),
      ( 400, 30.0537517879022, 100000.00113595, 0.000475927561552101, 20.8776968541562, 1 ),
      ( 400, 299.255971879019, 1000000.00000029, 0.00476040652067914, 20.8888151722225, 1 ),
      ( 400, 2869.57304280333, 10000000.0032038, 0.047823308502115, 20.9988620740852, 1 ),
      ( 400, 20275.4812298196, 100000000, 0.48297615507752, 21.9501301426367, 1 ),
      ( 400, 63957.6412754666, 999999999.999998, 3.70124516741299, 25.8719079555977, 1 ),
      ( 500, 0.240543476390456, 1000.00000000001, 3.9338278625852E-06, 20.9463707277986, 1 ),
      ( 500, 2.40534979366863, 10000.0000000326, 3.93381682617072E-05, 20.9464590922339, 1 ),
      ( 500, 24.044985571329, 100000.000325295, 0.00039337041433643, 20.9473426466344, 1 ),
      ( 500, 239.602169918688, 1000000.00000002, 0.00393265073958264, 20.9561691142928, 1 ),
      ( 500, 2314.54747704503, 10000000.0000484, 0.0392720130308136, 21.0434576569202, 1 ),
      ( 500, 17352.674991136, 100000000.000002, 0.386209571119312, 21.8090166247145, 1 ),
      ( 500, 60547.122746679, 999999999.999998, 2.97284677884119, 25.3217584305604, 1 ),
      ( 600, 0.200453023429019, 1000, 3.31543722638268E-06, 21.0212591182726, 1 ),
      ( 600, 2.00447055644587, 10000.0000000136, 3.31542196349992E-05, 21.0213319865213, 1 ),
      ( 600, 20.0387267570379, 100000.000135714, 0.000331526752225806, 21.0220605910544, 1 ),
      ( 600, 199.791639738522, 1000000, 0.00331376013121597, 21.0293388100704, 1 ),
      ( 600, 1940.47261806675, 10000000.0000026, 0.0330148410442645, 21.101312227268, 1 ),
      ( 600, 15178.406871975, 100000000, 0.320650467476979, 21.7396278998559, 1 ),
      ( 600, 57525.1343348525, 999999999.999999, 2.48462813043527, 24.8972592012956, 1 ),
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
