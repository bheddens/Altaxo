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
  /// Tests and test data for <see cref="Mixture_Methane_Heptane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Methane_Heptane : MixtureTestBase
  {

    public Test_Mixture_Methane_Heptane()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("74-82-8", 0.5), ("142-82-5", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 200, 7602.6579223629, 100000.000001145, -0.992090156533014, 151.618122703589, 1 ),
      ( 200, 7607.37971707886, 1000000.00000494, -0.920950659763561, 151.678802703985, 1 ),
      ( 200, 7653.10294512558, 10000000.0000002, -0.214229375308073, 152.27779923021, 1 ),
      ( 200, 8010.47578665499, 100000000.00599, 6.5071489420561, 157.598312846803, 1 ),
      ( 250, 7187.06913339542, 99999.9999983074, -0.993306218984938, 162.652194302821, 1 ),
      ( 250, 7193.49926550098, 1000000.00006824, -0.933122023092277, 162.707885948044, 1 ),
      ( 250, 7254.93367030372, 10000000.0000001, -0.336883422489164, 163.257412315047, 1 ),
      ( 250, 7700.3633560928, 100000000.009725, 5.24758412540801, 168.060554084172, 1 ),
      ( 300, 0.401357429001879, 999.999942350555, -0.00112583809767104, 157.597597671176, 2 ),
      ( 300, 6770.7899279901, 100000.000002044, -0.99407889534102, 178.362418033296, 1 ),
      ( 300, 6779.76787881177, 1000000.00755971, -0.940867360797679, 178.413667560766, 1 ),
      ( 300, 6863.77127418342, 10000000.0000076, -0.415910656900704, 178.922902935754, 1 ),
      ( 300, 7415.78394219039, 100000000.014832, 4.4061117296888, 183.384696524825, 1 ),
      ( 350, 0.343846797348136, 999.999992864657, -0.000620786636749609, 179.816504243476, 2 ),
      ( 350, 3.4579198132789, 9999.99999999789, -0.00624259548391871, 180.089999507711, 2 ),
      ( 350, 6333.81865739366, 100000.000003387, -0.99457462613868, 197.124760897914, 1 ),
      ( 350, 6346.98885512674, 999999.99999966, -0.945858839570519, 197.168257796483, 1 ),
      ( 350, 6465.91132147773, 10000000.0001643, -0.468546157283457, 197.618043725162, 1 ),
      ( 350, 7149.39173128943, 100000000, 3.80646962378345, 201.803845522089, 1 ),
      ( 400, 0.300792537888699, 999.999998762375, -0.000376883585120789, 202.189990659749, 2 ),
      ( 400, 3.01820441486175, 9999.9866490103, -0.00378127415571203, 202.336947545633, 2 ),
      ( 400, 31.2931507575247, 99999.9999999997, -0.0391534030934925, 203.868171110438, 2 ),
      ( 400, 5869.63489586866, 1000000.00328903, -0.948773785688921, 217.036949643199, 1 ),
      ( 400, 6048.62994574383, 10000000.0024917, -0.502897057871567, 217.349158056719, 1 ),
      ( 400, 6897.31305705196, 100000000, 3.35936677995324, 221.242962361566, 1 ),
      ( 500, 0.240583641293595, 999.999999927894, -0.000167517619136651, 243.585476671825, 2 ),
      ( 500, 2.40947492342267, 9999.99925576493, -0.00167734892440109, 243.637874942858, 2 ),
      ( 500, 24.4702471948158, 99999.9999910605, -0.0169966924317085, 244.171059232836, 2 ),
      ( 500, 301.257387251783, 999999.999926487, -0.201535466083239, 250.844927757312, 2 ),
      ( 500, 5090.19741745043, 10000000.0167044, -0.52743809338645, 255.541893286388, 1 ),
      ( 500, 6428.97909802182, 99999999.9999999, 2.74154800672539, 258.431082176233, 1 ),
      ( 600, 0.200470104004073, 999.999999992811, -8.64031995840155E-05, 278.873636838708, 2 ),
      ( 600, 2.00626210113704, 9999.99992701875, -0.000864430258874049, 278.896434905332, 2 ),
      ( 600, 20.2208874158346, 99999.9999999703, -0.00868454163109656, 279.126514545775, 2 ),
      ( 600, 220.59338291083, 999999.999999998, -0.0913019234729508, 281.651177821181, 2 ),
      ( 600, 3833.0843887928, 9999999.99994472, -0.477045735463004, 290.145830057037, 1 ),
      ( 600, 6004.27950913857, 99999999.9999992, 2.33849852327117, 290.881293753521, 1 ),
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
      ( 250, 11515.8099350232, 100000000.00013, 3.17761912800454, 98.2301415072669, 1 ),
      ( 300, 0.401009732730708, 999.999997845536, -0.000259762371453981, 92.5725978435001, 2 ),
      ( 300, 4.01952114557628, 10000.0000215587, -0.00260366603190015, 92.6454992265153, 2 ),
      ( 300, 11000.4001555628, 100000000.012816, 2.6444634728595, 106.666814812066, 1 ),
      ( 350, 0.343686949557293, 999.999998625215, -0.000155978304019669, 104.796460725143, 2 ),
      ( 350, 3.44170841350446, 9999.99999979636, -0.00156172294651487, 104.832565097689, 2 ),
      ( 350, 34.9155674222312, 99999.999952475, -0.0158162469569986, 105.201632504559, 2 ),
      ( 350, 10513.963070326, 99999999.9918063, 2.26835218581973, 116.880941897222, 1 ),
      ( 400, 0.300709423883899, 999.999999712327, -0.000100594670431873, 117.320730940233, 2 ),
      ( 400, 3.00982153036745, 9999.99703141725, -0.00100663386555692, 117.340648387532, 2 ),
      ( 400, 30.3758103220723, 99999.994421611, -0.0101361209186546, 117.542457316358, 2 ),
      ( 400, 10053.0280230163, 99999999.9992685, 1.99093142313164, 127.809588925752, 1 ),
      ( 500, 0.240554744870005, 999.999999998863, -4.74136363921126E-05, 140.98964244383, 2 ),
      ( 500, 2.4065745930195, 9999.99983636294, -0.000474200989275529, 140.997284218878, 2 ),
      ( 500, 24.1691009566996, 99999.9999998928, -0.00474850210225878, 141.074128747353, 2 ),
      ( 500, 252.713678569955, 1000000.002146, -0.0481586092630951, 141.885004652182, 2 ),
      ( 500, 9204.7741294624, 100000000.00376, 1.6132454302408, 149.151222634516, 1 ),
      ( 600, 0.200457636005458, 999.999999998091, -2.42109000622713E-05, 161.642129607869, 2 ),
      ( 600, 2.00501318905214, 9999.99998088019, -0.000242074015869162, 161.645780318601, 2 ),
      ( 600, 20.0938498708944, 99999.9999999998, -0.00241723694483304, 161.682382860094, 2 ),
      ( 600, 205.34320250517, 999999.983104625, -0.0238158342648665, 162.05722783811, 2 ),
      ( 600, 2446.30431805876, 10000000, -0.180589343419328, 165.5484734784, 1 ),
      ( 600, 8454.80608106385, 100000000.000001, 1.37087380624243, 168.217656272542, 1 ),
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
      ( 200, 0.601396505301008, 999.99999866252, -6.34474321399681E-05, 25.2932748957619, 2 ),
      ( 250, 0.481102026532411, 999.999999990229, -3.19016382525809E-05, 26.0644602380395, 2 ),
      ( 250, 4.81240214459282, 9999.99990149078, -0.000319042057488736, 26.0669998581603, 2 ),
      ( 250, 48.262770470057, 99999.9999999822, -0.00319299139445493, 26.092489703606, 2 ),
      ( 250, 7047.20674977979, 9999999.9999445, -0.317337073152411, 29.3538224335557, 2 ),
      ( 250, 23232.5743457701, 100000000, 1.07074201691812, 31.4878484295429, 1 ),
      ( 300, 0.400912422187174, 999.999999998937, -1.71027273350373E-05, 27.5933683506791, 2 ),
      ( 300, 4.00974138934909, 9999.99998932869, -0.000171017122665412, 27.594799623878, 2 ),
      ( 300, 40.1591946075989, 100000, -0.00170914927693525, 27.6091216417257, 2 ),
      ( 300, 407.831332666506, 999999.99522932, -0.0169819398061025, 27.7532039004193, 2 ),
      ( 300, 4695.59294626754, 9999999.99999999, -0.146208859926825, 29.1441406018604, 2 ),
      ( 300, 21225.7119786891, 100000000, 0.888773228873769, 31.9718618764567, 1 ),
      ( 350, 0.343636522912431, 999.999999999875, -9.25705652794768E-06, 29.7987077575363, 2 ),
      ( 350, 3.43665150056431, 9999.99999874096, -9.2555811109499E-05, 29.7996096547072, 2 ),
      ( 350, 34.3951179793378, 99999.9878400828, -0.000924078542841089, 29.8086247229888, 2 ),
      ( 350, 346.785167835455, 999999.999978579, -0.00908869893527591, 29.8983582461311, 2 ),
      ( 350, 3697.90310608596, 10000000.0016622, -0.0707345974492285, 30.7182356115049, 2 ),
      ( 350, 19432.0808887564, 100000000, 0.768381594417722, 33.3967798921148, 1 ),
      ( 400, 0.300680601430787, 999.999999999985, -4.74693838509459E-06, 32.4633848852358, 2 ),
      ( 400, 3.00693443917248, 9999.99999986855, -4.7456301550623E-05, 32.4639953045188, 2 ),
      ( 400, 30.0821538766422, 99999.998763352, -0.000473252835370073, 32.4700946070762, 2 ),
      ( 400, 302.068555338015, 999999.99999994, -0.00459955592934222, 32.5305911453443, 2 ),
      ( 400, 3102.16937953361, 9999999.99999814, -0.0307454644410652, 33.0775128003575, 1 ),
      ( 400, 17854.2386378344, 100000000.003264, 0.68407726716048, 35.4580134318417, 1 ),
      ( 500, 0.240543404692683, 999.996630323161, -2.66547398170492E-07, 38.3979584833831, 2 ),
      ( 500, 2.40543978488893, 9999.99999999999, -2.65728578134189E-06, 38.398277823109, 2 ),
      ( 500, 24.0549534112106, 99999.9999999299, -2.5752772000315E-05, 38.4014685739604, 2 ),
      ( 500, 240.585480274703, 1000000.000194, -0.000175160112985676, 38.4331128168636, 1 ),
      ( 500, 2389.3349965804, 10000000.0003523, 0.00673760539731839, 38.7244031202319, 1 ),
      ( 500, 15285.7207777874, 100000000.001668, 0.573647345739532, 40.5291570979615, 1 ),
      ( 600, 0.20045245224996, 1000.0172400616, 1.61644587102312E-06, 44.4123627188298, 1 ),
      ( 600, 2.00449541651974, 10000.0000000024, 1.61691249825982E-05, 44.4125482619111, 1 ),
      ( 600, 20.0420277439602, 100000.000025745, 0.000162185715374809, 44.4144025977404, 1 ),
      ( 600, 200.118321030239, 999999.999999998, 0.00167131981458934, 44.4328374382937, 1 ),
      ( 600, 1962.10670091936, 10000000.0001004, 0.0216201934981165, 44.6075277447963, 1 ),
      ( 600, 13342.1949348143, 100000000.00005, 0.502397347101111, 45.9688817404918, 1 ),
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
