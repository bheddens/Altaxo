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
  /// Tests and test data for <see cref="Mixture_Ethane_CO"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Mixture_Ethane_CO : MixtureTestBase
  {

    public Test_Mixture_Ethane_CO()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("74-84-0", 0.5), ("630-08-0", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new(double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 100, 1.20298272093331, 999.999999834884, -0.00021656805646171, 20.7978286976853, 2 ),
      ( 100, 12.0533696929736, 9999.99788265333, -0.0021693314843636, 20.8266949647022, 2 ),
      ( 100, 25259.092765731, 1000000.00000003, -0.952384584654595, 29.0842605191764, 1 ),
      ( 100, 26473.2195579407, 10000000.0000237, -0.545683444103288, 29.5617606905146, 1 ),
      ( 100, 31449.2759146351, 100000000.000001, 2.82432395762649, 33.0597960310729, 1 ),
      ( 150, 0.801868289876215, 999.999999997883, -6.67121287454917E-05, 20.7997807618814, 2 ),
      ( 150, 8.02350223477239, 9999.9999785824, -0.000667324473469662, 20.8048785805104, 2 ),
      ( 150, 80.7218102429076, 99999.9999999982, -0.00669373844377568, 20.8562114025198, 2 ),
      ( 150, 861.401342122401, 1000000.00034988, -0.0691739653685943, 21.4103413857346, 2 ),
      ( 150, 16445.1399211252, 10000000.0000001, -0.5124305421662, 25.6138500189156, 1 ),
      ( 150, 27918.3798053609, 100000000.000001, 1.87199615853713, 28.6307847557436, 1 ),
      ( 200, 0.601376864402575, 999.999999999925, -2.62194171259833E-05, 20.805233052874, 2 ),
      ( 200, 6.01518793868986, 9999.99999925997, -0.000262165070920081, 20.8070296881388, 2 ),
      ( 200, 60.2940032219086, 99999.9925326137, -0.00261872717533964, 20.8250486926895, 2 ),
      ( 200, 617.337571049692, 999999.9999183, -0.0258796404850617, 21.0102170207652, 2 ),
      ( 200, 7439.33356564345, 9999999.99999999, -0.191646548248703, 22.853857490246, 1 ),
      ( 200, 24873.8809700026, 100000000, 1.41764080714605, 26.4578116602547, 1 ),
      ( 250, 0.481093975944508, 999.999999999996, -1.05979775040817E-05, 20.8170519201695, 2 ),
      ( 250, 4.81139849233166, 9999.99999996764, -0.000105939908890384, 20.8179937605378, 2 ),
      ( 250, 48.1597160723245, 99999.9996848476, -0.0010554119534306, 20.8274255845982, 2 ),
      ( 250, 486.024273545275, 999999.999999976, -0.010154629084468, 20.9229682951925, 2 ),
      ( 250, 5111.97276955341, 9999999.99999897, -0.0588978091066731, 21.8788550841366, 1 ),
      ( 250, 22312.9582980042, 100000000.000001, 1.15609634049925, 25.1867756650849, 1 ),
      ( 300, 0.400908773253053, 999.999984651404, -3.43091823282703E-06, 20.8495745667752, 2 ),
      ( 300, 4.00921141169995, 9999.99848850057, -3.4279559486228E-05, 20.8501914508886, 2 ),
      ( 300, 40.1043687519223, 100000, -0.000339837667689336, 20.8563646743117, 2 ),
      ( 300, 402.156618922575, 999999.999999999, -0.00310630509305872, 20.9184874604452, 2 ),
      ( 300, 4027.33686012361, 10000000.0170703, -0.00453472925693145, 21.5365741533207, 1 ),
      ( 300, 20191.187313065, 99999999.9999994, 0.98555632985659, 24.3864428170399, 1 ),
      ( 350, 0.343634844371602, 1000.00002200892, 1.93997849321723E-07, 20.9245270236998, 1 ),
      ( 350, 3.43634238745771, 10000.0022472306, 1.96030172782781E-06, 20.9249839498932, 1 ),
      ( 350, 34.3627479257023, 100000, 2.16313183202353E-05, 20.9295546915133, 1 ),
      ( 350, 343.492271463732, 1000000.00000539, 0.000415266719190897, 20.975388342615, 1 ),
      ( 350, 3365.38478127265, 10000000.0088653, 0.0210865464652876, 21.4282577882148, 1 ),
      ( 350, 18433.1091824165, 100000000.013274, 0.864226533884186, 23.8826613258528, 1 ),
      ( 400, 0.300679894934385, 1000.00033893658, 2.13043262706931E-06, 21.0597009575916, 1 ),
      ( 400, 3.00674138509291, 10000, 2.13181506066286E-05, 21.0600641380037, 1 ),
      ( 400, 30.061604772668, 100000.000000015, 0.000214561397058334, 21.0636963036695, 1 ),
      ( 400, 299.996403107774, 1000000.00027363, 0.0022805114000615, 21.1000429831569, 1 ),
      ( 400, 2908.13644989086, 10000000.005218, 0.0339286120632221, 21.4571442535182, 1 ),
      ( 400, 16963.5421422083, 100000000.008252, 0.772510397994769, 23.5945257605681, 1 ),
      ( 500, 0.24054351561855, 1000.00078715355, 3.76207681947529E-06, 21.5246291509598, 1 ),
      ( 500, 2.40535387955673, 10000, 3.76273324740344E-05, 21.524886589046, 1 ),
      ( 500, 24.0453804235037, 100000.000000141, 0.000376930720375054, 21.527460656325, 1 ),
      ( 500, 239.62586111947, 1000000.00166219, 0.00383338232136958, 21.553166434079, 1 ),
      ( 500, 2305.2402365526, 10000000.0000037, 0.0434679858807945, 21.8040381661921, 1 ),
      ( 500, 14656.363553778, 100000000.003235, 0.641228656627987, 23.4843399535339, 1 ),
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
      ( 150, 0.802015834983159, 999.999998087859, -0.000250667678092345, 25.6050689138996, 2 ),
      ( 150, 8.03835216335382, 9999.99998751187, -0.00251347633642343, 25.6429141191244, 2 ),
      ( 200, 0.601426041109052, 999.99999980018, -0.00010798411256314, 27.3995187083441, 2 ),
      ( 200, 6.02011652916723, 9999.99794266542, -0.00108063710685747, 27.4109960211673, 2 ),
      ( 200, 60.798045109287, 99999.9943324685, -0.0108874452944595, 27.5291745987214, 2 ),
      ( 250, 0.481115258734944, 999.999999978891, -5.48338741908584E-05, 29.7503040971652, 2 ),
      ( 250, 4.81352885118847, 9999.99978619233, -0.000548470363370101, 29.7553156777654, 2 ),
      ( 250, 48.3748501083732, 99999.9999998465, -0.00549794726026065, 29.8057555451019, 2 ),
      ( 250, 509.837567096443, 999999.999999999, -0.0563879392779836, 30.3454857447611, 2 ),
      ( 300, 0.400919482509491, 999.999999999147, -3.01425652952383E-05, 32.6048522032301, 2 ),
      ( 300, 4.01028279632393, 9999.99999143116, -0.000301429775940593, 32.6075703317298, 2 ),
      ( 300, 40.2119666567228, 100000, -0.00301469661400253, 32.6347980824228, 2 ),
      ( 300, 413.379675925574, 999999.983368549, -0.030171483206903, 32.9116359247191, 2 ),
      ( 300, 5408.91748161297, 10000000.0001944, -0.258802895164814, 35.5813288598633, 1 ),
      ( 300, 17626.2289217948, 99999999.9999992, 1.27449331077329, 38.4373156857247, 1 ),
      ( 350, 0.343640782928451, 999.999999999822, -1.70834089922934E-05, 35.7753042888568, 2 ),
      ( 350, 3.43693619360516, 9999.99999821902, -0.000170811981334902, 35.7770041266015, 2 ),
      ( 350, 34.4222120031576, 99999.9823468121, -0.00170589721329941, 35.7940069860428, 2 ),
      ( 350, 349.515424712792, 999999.999818115, -0.016824757717523, 35.9643529919804, 2 ),
      ( 350, 3942.83232898101, 10000000.0007173, -0.128456693822037, 37.5148067466418, 1 ),
      ( 350, 16320.0353913999, 100000000.000001, 1.10560151452549, 40.5922152107969, 1 ),
      ( 400, 0.300683424964163, 999.999999999964, -9.56699992576845E-06, 39.0708500632715, 2 ),
      ( 400, 3.00709309783506, 9999.99999964909, -9.56453847959503E-05, 39.0720223161746, 2 ),
      ( 400, 30.0967667585971, 99999.9966123991, -0.000953987026796156, 39.0837414014803, 2 ),
      ( 400, 303.499373312119, 999999.999997995, -0.00928774565657977, 39.2005186873227, 2 ),
      ( 400, 3205.3023688178, 10000000.0085544, -0.0619276632218627, 40.2546505567941, 1 ),
      ( 400, 15156.5098666273, 100000000.000001, 0.983837644496235, 43.1500492001661, 1 ),
      ( 500, 0.240544944612971, 999.981320077463, -2.06208576545415E-06, 45.5389916813775, 2 ),
      ( 500, 2.40549394840279, 9999.99999999641, -2.0603583705179E-05, 45.5396654237303, 2 ),
      ( 500, 24.0593584653722, 99999.9999687961, -0.000204269756778309, 45.546398610887, 2 ),
      ( 500, 240.994095872533, 1000000, -0.00186584326916803, 45.6132904423844, 2 ),
      ( 500, 2407.6000573451, 10000000.0022813, -0.00089536080603912, 46.2233786725548, 1 ),
      ( 500, 13220.4730270355, 100000000.003215, 0.819484357128028, 48.6323296487179, 1 ),
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
      ( 100, 21328.4353185402, 1000000.00005, -0.943609450229198, 46.3521944722684, 1 ),
      ( 100, 21443.3328046791, 10000000.0000052, -0.43911601603185, 46.7016843768282, 1 ),
      ( 100, 22385.6612504094, 100000000.000003, 4.37273471553797, 49.5325991589143, 1 ),
      ( 150, 0.802284214902974, 999.99999959217, -0.00058510358100778, 30.4175910164771, 2 ),
      ( 150, 21018.2548829866, 100000000.000005, 2.8148495200936, 46.579772174393, 1 ),
      ( 200, 0.601508924896136, 999.999987341898, -0.0002457623427118, 33.9955869576994, 2 ),
      ( 200, 6.02848279045506, 9999.9999999971, -0.00246692649483311, 34.0345994457022, 2 ),
      ( 200, 61.713274476767, 100000.002698755, -0.0255563307753128, 34.5387238477531, 2 ),
      ( 250, 0.48114990443864, 999.99999957359, -0.000126835974977403, 38.6842755253207, 2 ),
      ( 250, 4.81700510876893, 9999.99555299228, -0.00126973766725884, 38.6999663034055, 2 ),
      ( 250, 48.7345220496013, 99999.999674305, -0.0128376003106037, 38.8703922337619, 2 ),
      ( 250, 563.461297767005, 999999.999999999, -0.146190023648435, 41.665132674432, 2 ),
      ( 250, 15612.2209485005, 9999999.99999928, -0.691851096068926, 46.0692213243188, 1 ),
      ( 250, 18511.3783236337, 99999999.9968649, 1.59888198975696, 48.8459869250418, 1 ),
      ( 300, 0.400936713768976, 999.999999953201, -7.31187745009335E-05, 44.3604930084886, 2 ),
      ( 300, 4.01200884822025, 9999.99859414392, -0.000731521350036984, 44.3685972698615, 2 ),
      ( 300, 40.387546424692, 99999.9999857432, -0.00734896449227805, 44.451352325936, 2 ),
      ( 300, 434.497253986317, 999999.999999994, -0.0773074073779132, 45.4555378186483, 2 ),
      ( 300, 12668.9304110495, 10000000, -0.683550714416937, 50.775141181533, 1 ),
      ( 300, 17352.7166142961, 100000000.01274, 1.31034371575948, 52.5558867927552, 1 ),
      ( 350, 0.343650385349804, 999.999999973391, -4.50253456796389E-05, 50.6262910856488, 2 ),
      ( 350, 3.43789736561722, 9999.9997304475, -0.000450345570754703, 50.6311223612524, 2 ),
      ( 350, 34.5192667279091, 99999.9999997992, -0.004512711444817, 50.6797161224357, 2 ),
      ( 350, 360.241274945838, 1000000.01266171, -0.04609789034121, 51.1957029194722, 2 ),
      ( 350, 7217.62399028579, 10000000.0000021, -0.523894687732581, 57.7589585997618, 1 ),
      ( 350, 16254.6419733327, 99999999.9999988, 1.11407247810302, 57.3716147404409, 1 ),
      ( 400, 0.300689223577087, 999.999999994539, -2.88512209559298E-05, 57.0821309953261, 2 ),
      ( 400, 3.00767329415936, 9999.99994499333, -0.000288532300921003, 57.0852992881558, 2 ),
      ( 400, 30.1551224994011, 99999.9999999954, -0.0028873259152514, 57.1170277560579, 2 ),
      ( 400, 309.681843806515, 1000000.00004418, -0.0290662680459888, 57.4390254772314, 2 ),
      ( 400, 4193.95278890001, 9999999.99999999, -0.283061676035888, 60.8339623665814, 2 ),
      ( 400, 15222.0966073746, 99999999.9938631, 0.975289975270133, 62.750629290656, 1 ),
      ( 500, 0.240547429449107, 999.999999999712, -1.2433258699296E-05, 69.5534156583002, 2 ),
      ( 500, 2.40574347313196, 9999.99999709924, -0.000124321869034843, 69.5550586628192, 2 ),
      ( 500, 24.0843599813746, 100000, -0.00124213868750857, 69.5714773404095, 2 ),
      ( 500, 243.541219252832, 999999.999756707, -0.0123050241787315, 69.7344770448716, 2 ),
      ( 500, 2678.58451046616, 10000000, -0.10197181488657, 71.1749427953807, 2 ),
      ( 500, 13376.2734534303, 100000000.000945, 0.798291874782191, 73.7785973808984, 1 ),
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
