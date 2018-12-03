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
  /// Tests and test data for <see cref="Mixture_CO2_H2S"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_CO2_H2S : MixtureTestBase
  {

    public Test_Mixture_CO2_H2S()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("124-38-9", 0.5), ("7783-06-4", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 250, 0.481152022157391, 999.999999985949, -0.000131241337143454, 25.338491783408, 2 ),
      ( 250, 4.81721809106188, 9999.99985589591, -0.00131389935485489, 25.3716044032653, 2 ),
      ( 250, 48.757001278817, 99999.9999997731, -0.0132927323164534, 25.7080347299476, 2 ),
      ( 250, 28535.2319416855, 100000000.000057, 0.685946958854371, 40.5842355060001, 1 ),
      ( 300, 0.400936833980921, 999.999999998389, -7.34231502297044E-05, 25.81994232525, 2 ),
      ( 300, 4.01202147748323, 9999.99998364844, -0.000734671571265537, 25.8345968794236, 2 ),
      ( 300, 40.3892705803742, 99999.9999999987, -0.0073913437698472, 25.9822670162312, 2 ),
      ( 300, 435.357914188108, 999999.999999983, -0.0791314849916686, 27.6275495568049, 2 ),
      ( 300, 26723.0458812185, 100000000.000852, 0.5002309157445, 38.1207784951035, 1 ),
      ( 350, 0.343650430620265, 999.999999999984, -4.51616439324792E-05, 26.4696324079291, 2 ),
      ( 350, 3.43790224302209, 9999.99999784808, -0.000451768227570298, 26.4771070050953, 2 ),
      ( 350, 34.5199691814622, 100000, -0.00453297335812384, 26.5521982079995, 2 ),
      ( 350, 360.575662597484, 999999.990315068, -0.046982515410507, 27.3423149497988, 2 ),
      ( 350, 18966.0472074622, 9999999.99999993, -0.818815746346526, 35.8615641210555, 1 ),
      ( 350, 24914.8398344589, 100000000.010321, 0.379237888407259, 36.6233979492065, 1 ),
      ( 400, 0.300689411021434, 999.999999999946, -2.94791551155777E-05, 27.2270549210492, 2 ),
      ( 400, 3.00769227729821, 9999.99999945483, -0.000294846580012279, 27.231300465165, 2 ),
      ( 400, 30.1571386244404, 99999.9943188257, -0.00295399126413453, 27.2738847960934, 2 ),
      ( 400, 310.01709950939, 999999.9998762, -0.0301162502692244, 27.7131794510364, 2 ),
      ( 400, 5041.64253418536, 10000000, -0.403605977788289, 34.6416011688254, 2 ),
      ( 400, 23118.5499654099, 100000000.000001, 0.300602967753284, 35.7484789305762, 1 ),
      ( 500, 0.240547773867344, 999.997902650977, -1.3869590130574E-05, 28.9110970975085, 2 ),
      ( 500, 2.40577805697659, 9999.99999999971, -0.000138699977936575, 28.9128380156291, 2 ),
      ( 500, 24.0878627406074, 99999.9999969778, -0.00138737856578697, 28.9302734010645, 2 ),
      ( 500, 243.938054715984, 1000000, -0.0139117988729515, 29.1072230357158, 2 ),
      ( 500, 2803.17123705097, 10000000, -0.141884611321921, 31.0852866401531, 2 ),
      ( 500, 19678.7817696867, 100000000.000096, 0.222354312257358, 35.1317442254949, 1 ),
      ( 600, 0.200455071954982, 999.998369429125, -6.85432882692708E-06, 30.7060941782233, 2 ),
      ( 600, 2.00467437801651, 9999.99999999995, -6.85389808833836E-05, 30.7069947496165, 2 ),
      ( 600, 20.0591092384178, 99999.9999992613, -0.000684947745024972, 30.7160079393105, 2 ),
      ( 600, 201.827151868345, 999999.993208308, -0.00680509964388465, 30.806866378194, 2 ),
      ( 600, 2139.74907023698, 9999999.99999939, -0.0631906294247692, 31.7628928689604, 2 ),
      ( 600, 16680.4567226086, 99999999.9999994, 0.20172787412927, 35.397826862751, 1 ),
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
      ( 250, 0.481136536135233, 999.999999959997, -0.00010133959613385, 25.9313945557841, 2 ),
      ( 250, 4.81576206036645, 9999.99959048392, -0.00101422798183802, 25.9558922323182, 2 ),
      ( 250, 48.6058879026839, 99999.9999986474, -0.0102273637626175, 26.2040352499813, 2 ),
      ( 300, 0.40092904430038, 999.999999990537, -5.62759750679632E-05, 27.3642952700253, 2 ),
      ( 300, 4.01132312966601, 9999.9999039994, -0.000562984655286213, 27.3749865600161, 2 ),
      ( 300, 40.3185507636012, 99999.999999967, -0.00565254938626938, 27.4825622990944, 2 ),
      ( 300, 426.059217418727, 999999.999999842, -0.0590357742842235, 28.6391329724657, 2 ),
      ( 300, 20328.6964426148, 10000000.0006776, -0.802787904879388, 38.4861021895222, 1 ),
      ( 300, 25741.9039151528, 99999999.9997419, 0.557408041569756, 39.7064597178029, 1 ),
      ( 350, 0.343645839632066, 999.999999998425, -3.40831211898237E-05, 28.7724849594199, 2 ),
      ( 350, 3.43751310912204, 9999.99998409949, -0.000340897035233321, 28.7779784019336, 2 ),
      ( 350, 34.4811860864237, 99999.9999999995, -0.00341558364393986, 28.8331038013983, 2 ),
      ( 350, 356.04205135162, 1000000.00001144, -0.0348496032853284, 29.4044493780488, 2 ),
      ( 350, 6644.27670750782, 9999999.99987072, -0.48281183604636, 39.4786481668894, 2 ),
      ( 350, 23667.309357425, 100000000.002326, 0.451935756305738, 38.5408770141317, 1 ),
      ( 400, 0.30068639481897, 999.999999999682, -2.17289457503903E-05, 30.1204330746101, 2 ),
      ( 400, 3.00745214876581, 9999.9999967937, -0.000217305721646651, 30.123599639671, 2 ),
      ( 400, 30.1335170965796, 100000, -0.00217468721777913, 30.1553309738912, 2 ),
      ( 400, 307.41637393555, 999999.997876046, -0.0219133178049984, 30.4792313512979, 2 ),
      ( 400, 3934.14697409534, 9999999.99988364, -0.235717772615603, 34.3106659811353, 2 ),
      ( 400, 21678.1873467718, 100000000.000001, 0.38701569651942, 38.0118950509065, 1 ),
      ( 500, 0.240546164685979, 999.999999999983, -9.46059354133036E-06, 32.6106931717824, 2 ),
      ( 500, 2.40566646616971, 9999.99999982496, -9.46001484569435E-05, 32.6120300973887, 2 ),
      ( 500, 24.0771519767809, 99999.9982521511, -0.000945422396822848, 32.6254098862024, 2 ),
      ( 500, 242.825446472578, 999999.999998635, -0.00939587481143958, 32.7602169690117, 2 ),
      ( 500, 2634.43462767062, 9999999.99980089, -0.0869240540252793, 34.1562811256424, 2 ),
      ( 500, 18133.6574816811, 100000000.000001, 0.326505087122279, 38.0275501773798, 1 ),
      ( 600, 0.200454061171983, 999.999999999998, -4.01225864249525E-06, 34.8568253152501, 2 ),
      ( 600, 2.00461282453842, 9999.99999999044, -4.01156772239195E-05, 34.8575296191821, 2 ),
      ( 600, 20.0533547774748, 99999.9999060802, -0.000400466464699437, 34.8645746760839, 2 ),
      ( 600, 201.245323111429, 999999.999999998, -0.00393590411584663, 34.935209746891, 2 ),
      ( 600, 2071.96115537017, 9999999.99999994, -0.0325434417812417, 35.6428181463238, 2 ),
      ( 600, 15318.4442976002, 100000000.000687, 0.308574401682796, 38.7642451001678, 1 ),
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
      ( 250, 0.481129288292876, 999.999999866885, -8.85572871732E-05, 26.524933280235, 2 ),
      ( 250, 4.81513380885258, 9999.99863192291, -0.000886164446078273, 26.5465250961403, 2 ),
      ( 250, 48.5417515614474, 99999.9999852786, -0.00892187573648015, 26.7649064167928, 2 ),
      ( 300, 0.400925066196503, 999.999999995161, -4.86347064500212E-05, 28.9089559212385, 2 ),
      ( 300, 4.01100699548317, 9999.99985616588, -0.000486491851347803, 28.9183926817324, 2 ),
      ( 300, 40.2871380514756, 99999.9999999238, -0.00487950566053676, 29.0132630016708, 2 ),
      ( 300, 422.171226324548, 999999.999999996, -0.0503721184081833, 30.0190971656124, 2 ),
      ( 300, 18210.8879715253, 9999999.99978554, -0.779853915995842, 41.7852445485377, 1 ),
      ( 300, 25657.1177226951, 100000000.019933, 0.562551069562483, 41.5966710926327, 1 ),
      ( 350, 0.343643313291468, 999.999999997486, -2.90122660723665E-05, 31.075499592565, 2 ),
      ( 350, 3.4373307997635, 9999.99997465098, -0.000290156990051289, 31.0803770339022, 2 ),
      ( 350, 34.4634511769952, 99999.9999999989, -0.0029050147731519, 31.12928571685, 2 ),
      ( 350, 354.044605890942, 1000000.0000208, -0.0294066405692951, 31.6321147379656, 2 ),
      ( 350, 5200.0628546227, 9999999.99981797, -0.339174634940441, 38.3221218933146, 2 ),
      ( 350, 23347.2199935021, 100000000.000001, 0.471838375258014, 40.7755748132553, 1 ),
      ( 400, 0.300684626186878, 999.999999999519, -1.81276118014532E-05, 33.0139063000651, 2 ),
      ( 400, 3.00733692144169, 9999.9999951753, -0.000181278828632361, 33.0167311407585, 2 ),
      ( 400, 30.1225314903476, 100000, -0.00181305947208689, 33.0450205880585, 2 ),
      ( 400, 306.239759127094, 999999.997077009, -0.0181576149157232, 33.3319436556545, 2 ),
      ( 400, 3670.55022225364, 9999999.99676366, -0.180833506404064, 36.464649153408, 2 ),
      ( 400, 21191.5404208993, 100000000.004391, 0.418864176602742, 40.6128436749616, 1 ),
      ( 500, 0.240545118495057, 999.999999999977, -7.39196417050719E-06, 36.3103347455416, 2 ),
      ( 500, 2.40561120556839, 9999.99999978343, -7.39112065885401E-05, 36.3115253974597, 2 ),
      ( 500, 24.0721057161943, 99999.9978658081, -0.000738268459230689, 36.3234356758269, 2 ),
      ( 500, 242.311776960959, 999999.999998833, -0.00729818654264712, 36.4428734009335, 2 ),
      ( 500, 2569.27694357477, 9999999.99988895, -0.0637702914983214, 37.6283658844076, 2 ),
      ( 500, 17524.8294214684, 99999999.9999996, 0.372585915725547, 41.2748315809448, 1 ),
      ( 600, 0.200453331972378, 999.999999999998, -2.68172201347003E-06, 39.0075875393806, 2 ),
      ( 600, 2.0045815796327, 9999.99999999263, -2.68100910646591E-05, 39.0082050026448, 2 ),
      ( 600, 20.0506396788933, 99999.9999290886, -0.000267388611799161, 39.0143791381102, 2 ),
      ( 600, 200.975943369764, 1000000, -0.0026030961646965, 39.076057935732, 2 ),
      ( 600, 2043.68051151962, 9999999.99982978, -0.0191579235015104, 39.6749784346987, 2 ),
      ( 600, 14762.9034361445, 100000000.001388, 0.357814094836872, 42.4529055563751, 1 ),
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