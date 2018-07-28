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
  /// Tests and test data for <see cref="Mixture_CO2_Ethane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_CO2_Ethane : MixtureTestBase
  {

    public Test_Mixture_CO2_Ethane()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("124-38-9", 0.5), ("74-84-0", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 250, 0.481149947337037, 999.999998873585, -0.000126929691406056, 38.6900040312194, 2 ),
      ( 250, 4.8170096219492, 9999.98808305863, -0.0012706770171209, 38.705729256036, 2 ),
      ( 250, 48.7350017234622, 100000.000065365, -0.0128473210110073, 38.8765488100137, 2 ),
      ( 250, 563.554107479957, 999999.998705445, -0.14633063824204, 41.6796146502034, 2 ),
      ( 250, 15621.1592472209, 10000000.0002291, -0.692027417735691, 46.085994762659, 1 ),
      ( 250, 18517.4056115603, 100000000.000629, 1.5980360597916, 48.8624898303142, 1 ),
      ( 300, 0.400936732514135, 999.999999953058, -7.31700944999878E-05, 44.3685797792786, 2 ),
      ( 300, 4.0120108931678, 9999.99858978496, -0.000732035250162589, 44.3766989151971, 2 ),
      ( 300, 40.3877582282287, 99999.9999856322, -0.0073541747398951, 44.4596093555759, 2 ),
      ( 300, 434.525845585212, 999999.999999994, -0.0773681243388598, 45.4659793867668, 2 ),
      ( 300, 12680.2925352102, 9999999.99999994, -0.683834268947425, 50.789552925388, 1 ),
      ( 300, 17358.3417093029, 100000000.012686, 1.30959502176764, 52.5720213525932, 1 ),
      ( 350, 0.343650394737741, 999.999999973307, -4.50572328680977E-05, 50.6364768800049, 2 ),
      ( 350, 3.43789844744551, 9999.99972961158, -0.00045066467448994, 50.6413157928941, 2 ),
      ( 350, 34.5193780346805, 99999.9999997978, -0.00451592591546915, 50.6899871522181, 2 ),
      ( 350, 360.254399417941, 1000000.01279107, -0.0461326464317991, 51.2068798528219, 2 ),
      ( 350, 7229.55536387922, 10000000.0000016, -0.524680435371239, 57.7842600016833, 1 ),
      ( 350, 16259.8353595672, 100000000, 1.113397234368, 57.3878868947589, 1 ),
      ( 400, 0.300689228703176, 999.999999994524, -2.88728384715955E-05, 57.0941274151503, 2 ),
      ( 400, 3.00767393107907, 9999.99994481641, -0.000288748573719582, 57.0973000757585, 2 ),
      ( 400, 30.1551880650617, 99999.9999999954, -0.00288949846917735, 57.1290725110886, 2 ),
      ( 400, 309.689105411803, 1000000.00004485, -0.0290890389850346, 57.4515401957931, 2 ),
      ( 400, 4196.12690449918, 10000000, -0.283433142526627, 60.8541539926124, 2 ),
      ( 400, 15226.8328367266, 99999999.9936046, 0.974675562283389, 62.7672947678489, 1 ),
      ( 500, 0.240547431193955, 999.99999999971, -1.24450825511027E-05, 69.568257144211, 2 ),
      ( 500, 2.40574374668941, 9999.99999708817, -0.000124440134810805, 69.5699018858863, 2 ),
      ( 500, 24.0843884562012, 100000, -0.00124332407753739, 69.5863379575642, 2 ),
      ( 500, 243.544209886603, 999999.999754097, -0.0123171572255981, 69.7495137986779, 2 ),
      ( 500, 2679.02406457913, 10000000, -0.102119160698524, 71.1918287669855, 2 ),
      ( 500, 13380.0773278178, 100000000.001056, 0.797780623153678, 73.7963060159052, 1 ),
      ( 600, 0.200454717990119, 999.999999999987, -5.08854251757969E-06, 80.8173878219402, 2 ),
      ( 600, 2.00463896313578, 9999.99999985792, -5.08737283955842E-05, 80.8183896470629, 2 ),
      ( 600, 20.0555492696077, 99999.9986459682, -0.000507563894489002, 80.8283972513138, 2 ),
      ( 600, 201.451815438753, 999999.999999896, -0.00495462135578654, 80.9273930592091, 2 ),
      ( 600, 2075.55645538296, 10000000.0000003, -0.0342170773149231, 81.7939161438292, 1 ),
      ( 600, 11840.029972457, 100000000.003085, 0.693016811932275, 84.1438578378586, 1 ),
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
      ( 250, 0.481135075909585, 999.999999669456, -9.83049437955887E-05, 32.6140132109909, 2 ),
      ( 250, 4.81561524710732, 9999.99657714813, -0.0009837716907755, 32.6312574095429, 2 ),
      ( 250, 48.5903662492422, 99999.9998730752, -0.00991119188335836, 32.8080357585068, 2 ),
      ( 250, 539.359080013101, 999999.999993691, -0.10803804778497, 35.0627344055321, 2 ),
      ( 300, 0.400928570878325, 999.999999958662, -5.50952275551369E-05, 36.6479956403126, 2 ),
      ( 300, 4.01127552466123, 9999.99957982201, -0.000551123521633896, 36.6561045921392, 2 ),
      ( 300, 40.3135213966886, 99999.999999352, -0.00552849825172009, 36.7378536776276, 2 ),
      ( 300, 425.212090285082, 999999.999999999, -0.0571611419640205, 37.6267650775339, 2 ),
      ( 300, 13018.3827232318, 10000000, -0.692045863030247, 46.2802047965555, 1 ),
      ( 300, 20190.9694039027, 99999999.9999997, 0.985573221412473, 46.5194422633124, 1 ),
      ( 350, 0.343645510986769, 999.999999993257, -3.31268040395947E-05, 40.8680636518032, 2 ),
      ( 350, 3.43748012955903, 9999.9999319633, -0.000331306193974995, 40.8725378662567, 2 ),
      ( 350, 34.477771606757, 99999.9999999915, -0.0033168876713548, 40.9174157228655, 2 ),
      ( 350, 355.567410270761, 1000000.00038448, -0.0335612399265052, 41.3801261115605, 2 ),
      ( 350, 5395.70395793813, 9999999.99976561, -0.363133837971608, 47.0888143460116, 2 ),
      ( 350, 18661.3836019659, 100000000.000001, 0.841418270149429, 48.6773820663749, 1 ),
      ( 400, 0.300686085478486, 999.999999998716, -2.07001859338388E-05, 45.068965388133, 2 ),
      ( 400, 3.00742115522043, 9999.99998708768, -0.000207002272513613, 45.071716443069, 2 ),
      ( 400, 30.1303577693754, 100000, -0.00207005996207024, 45.0992569173019, 2 ),
      ( 400, 307.035405015549, 999999.981345345, -0.0206997094556339, 45.3775571956859, 2 ),
      ( 400, 3735.04568260806, 9999999.99995403, -0.194976750562979, 48.2250320519497, 2 ),
      ( 400, 17244.7734187028, 99999999.999999, 0.743599952978841, 51.4081693590091, 1 ),
      ( 500, 0.240545881030008, 999.999999999947, -8.28138695195647E-06, 52.9596688442483, 2 ),
      ( 500, 2.40563808050805, 9999.99999945457, -8.28016253899549E-05, 52.9609604989513, 2 ),
      ( 500, 24.074293276002, 99999.9946842913, -0.00082678968251061, 52.9738739676195, 2 ),
      ( 500, 242.518727857172, 999999.99999444, -0.00814303661462751, 53.1026508924946, 2 ),
      ( 500, 2575.264276525, 10000000, -0.0659448384805326, 54.3026554217435, 2 ),
      ( 500, 14798.6683942609, 100000000.000073, 0.625442793689905, 57.405895566909, 1 ),
      ( 600, 0.200453814734412, 999.999999999997, -2.80697222820547E-06, 59.9376077967582, 2 ),
      ( 600, 2.00458865617134, 9999.9999999849, -2.80596389548244E-05, 59.9383424033027, 2 ),
      ( 600, 20.0509300780022, 99999.9998584699, -0.000279587859440163, 59.9456841469943, 2 ),
      ( 600, 200.994851375278, 999999.999999999, -0.00269464892873296, 60.0186551993469, 2 ),
      ( 600, 2037.7299310274, 9999999.99999819, -0.016291424287648, 60.6914171024062, 1 ),
      ( 600, 12862.8105673712, 100000000.000325, 0.558393787766567, 63.2511307395892, 1 ),
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
      ( 250, 0.481129277242091, 999.99999986668, -8.85343207745159E-05, 26.5382980871194, 2 ),
      ( 250, 4.81513270010907, 9999.99862979806, -0.000885934387677561, 26.5598712399511, 2 ),
      ( 250, 48.541636866746, 99999.9999852343, -0.00891953400654577, 26.7780674178049, 2 ),
      ( 250, 532.498725599422, 999999.997233241, -0.0965486717295264, 29.3715798163791, 2 ),
      ( 250, 24439.1790884702, 10000000.0025356, -0.803149410557228, 41.4870346459479, 1 ),
      ( 250, 28057.0890277925, 100000000.000284, 0.714670685590408, 43.568638951773, 1 ),
      ( 300, 0.400925061559906, 999.999999995153, -4.86231422648522E-05, 28.9275231746021, 2 ),
      ( 300, 4.01100653084325, 9999.99985593466, -0.000486376066467453, 28.9369530617519, 2 ),
      ( 300, 40.287090590597, 99999.9999999237, -0.00487833334226682, 29.0317545247527, 2 ),
      ( 300, 422.165285705283, 999999.999999996, -0.0503587554485103, 30.036867765981, 2 ),
      ( 300, 18193.5374138751, 9999999.99983552, -0.779643970164495, 41.8053197976518, 1 ),
      ( 300, 25647.7840128705, 99999999.9999989, 0.563119710944969, 41.6085931683017, 1 ),
      ( 350, 0.343643310776699, 999.999999997481, -2.90049483226993E-05, 31.0996907024184, 2 ),
      ( 350, 3.43733054795149, 9999.99997461148, -0.00029008375329327, 31.1045651807883, 2 ),
      ( 350, 34.4634256576129, 99999.999999999, -0.00290427644701307, 31.1534441045522, 2 ),
      ( 350, 354.04168268696, 1000000.00002085, -0.0293986267039477, 31.6559614020256, 2 ),
      ( 350, 5198.34533371067, 9999999.99983915, -0.338956299815216, 38.3385514718141, 2 ),
      ( 350, 23338.7921899618, 100000000.000001, 0.472369866543793, 40.7945110814566, 1 ),
      ( 400, 0.300684624575695, 999.999999999518, -1.81222535172318E-05, 33.043803368998, 2 ),
      ( 400, 3.00733676018719, 9999.99999516842, -0.000181225217987569, 33.0466268037846, 2 ),
      ( 400, 30.1225152279911, 99999.9999999998, -0.00181252057712104, 33.0749021216701, 2 ),
      ( 400, 306.23798866494, 999999.997072601, -0.0181519385631244, 33.3616767210863, 2 ),
      ( 400, 3670.12047269959, 9999999.99677403, -0.180737586818569, 36.4920607065124, 2 ),
      ( 400, 21184.1329921913, 100000000.00447, 0.419360309026752, 40.6386134607646, 1 ),
      ( 500, 0.240545117626902, 999.999999999977, -7.38835508156007E-06, 36.3510327584966, 2 ),
      ( 500, 2.40561111872254, 9999.99999978324, -7.38751078905993E-05, 36.3522230390732, 2 ),
      ( 500, 24.0720970012239, 99999.9978641316, -0.000737906690313169, 36.3641295818764, 2 ),
      ( 500, 242.310874552716, 999999.999998832, -0.00729448954690607, 36.4835277470903, 2 ),
      ( 500, 2569.15053981156, 9999999.99988704, -0.0637242284293899, 37.6684267256016, 2 ),
      ( 500, 17519.441367375, 99999999.9999997, 0.373008050598842, 41.3129837368822, 1 ),
      ( 600, 0.200453331401952, 999.999999999999, -2.67893213859278E-06, 39.0577492005781, 2 ),
      ( 600, 2.00458152370058, 9999.9999999926, -2.67821896735925E-05, 39.058366561009, 2 ),
      ( 600, 20.0506340776758, 99999.9999291548, -0.000267109332861249, 39.0645396589491, 2 ),
      ( 600, 200.975375180048, 999999.999999998, -0.00260027636321467, 39.1262071729343, 2 ),
      ( 600, 2043.61501493878, 9999999.99983242, -0.0191264881274899, 39.7249367251749, 2 ),
      ( 600, 14759.0956864649, 100000000.001391, 0.358164401948816, 42.5015053341309, 1 ),
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
