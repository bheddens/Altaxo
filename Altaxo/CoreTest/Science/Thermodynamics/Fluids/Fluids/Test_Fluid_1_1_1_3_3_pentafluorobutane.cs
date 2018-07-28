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
  /// Tests and test data for <see cref="Fluid_1_1_1_3_3_pentafluorobutane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Fluid_1_1_1_3_3_pentafluorobutane : FluidTestBase
  {

    public Test_Fluid_1_1_1_3_3_pentafluorobutane()
    {
      _fluid = Fluid_1_1_1_3_3_pentafluorobutane.Instance;

      _testDataMolecularWeight = 0.14807452;

      _testDataTriplePointTemperature = 239;

      _testDataTriplePointPressure = 2478;

      _testDataTriplePointLiquidMoleDensity = 9298.15710146644;

      _testDataTriplePointVaporMoleDensity = 1.251172716373;

      _testDataCriticalPointTemperature = 460;

      _testDataCriticalPointPressure = 3266210.95694421;

      _testDataCriticalPointMoleDensity = 3200;

      _testDataNormalBoilingPointTemperature = 313.343035787324;

      _testDataNormalSublimationPointTemperature = null;

      _testDataIsMeltingCurveImplemented = false;

      _testDataIsSublimationCurveImplemented = false;

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. Internal energy (J/mol)
      // 4. Enthalpy (J/mol)
      // 5. Entropy (J/mol K)
      // 6. Isochoric heat capacity (J/(mol K))
      // 7. Isobaric heat capacity (J/(mol K))
      // 8. Speed of sound (m/s)
      _testDataEquationOfState = new(double temperature, double moleDensity, double pressure, double internalEnergy, double enthalpy, double entropy, double isochoricHeatCapacity, double isobaricHeatCapacity, double speedOfSound)[]
      {
      ( 239, 0.503871578571146, 1000.00000000042, 53752.9326575732, 55737.5653348839, 266.724315950718, 118.587777416762, 126.980340589605, 119.721269577293 ),
      ( 250, 0.481587322612516, 1000.00000000022, 55079.3004548122, 57155.767074771, 272.525059893774, 122.464111898197, 130.838027013012, 122.337496699736 ),
      ( 263, 0.45768947233928, 1000.00000000012, 56700.0074643591, 58884.8949490746, 279.266821802312, 126.780536429741, 135.13908835186, 125.359607783654 ),
      ( 276, 0.436066886670096, 1000.00000000006, 58375.1585904103, 60668.3847687067, 285.885088990779, 130.861229382888, 139.209476435264, 128.310905056915 ),
      ( 289, 0.416404719740931, 1000.00000000004, 60102.0277071532, 62503.5374705925, 292.381665807814, 134.752778112338, 143.094108036755, 131.195767065101 ),
      ( 302, 0.398445099346036, 1000.00000000002, 61878.4342217344, 64388.1902750559, 298.759935675073, 138.493906500314, 146.830491784058, 134.018035262023 ),
      ( 315, 0.381974446728265, 1000.00000000001, 63702.6425527959, 66320.6187251953, 305.024276934037, 142.115446963284, 150.448598879355, 136.781160201052 ),
      ( 328, 0.366814085654964, 1000.00000000001, 65573.2656195202, 68299.4422825958, 311.179607850221, 145.641071897001, 153.971541493085, 139.488314404018 ),
      ( 341, 0.352813176290634, 1000.00000000001, 67489.1814512045, 70323.5427143344, 317.231058303085, 149.088555551953, 157.41677861112, 142.142464084761 ),
      ( 354, 0.339843342367238, 1000, 69449.4664976133, 72391.9987627279, 323.183749824615, 152.471070677441, 160.79733994728, 144.746404386775 ),
      ( 367, 0.327794546562237, 1000, 71453.3436724448, 74504.0350597408, 329.042654902336, 155.79820786656, 164.12277062989, 147.302771192679 ),
      ( 380, 0.316571885579746, 1000, 73500.1411196064, 76658.9813247897, 334.812508367857, 159.076685614869, 167.399782744376, 149.814042531857 ),
      ( 393, 0.306093062892109, 1000, 75589.2584717215, 78856.2387506979, 340.497752324848, 162.310861345962, 170.632731413244, 152.282538172233 ),
      ( 406, 0.296286365282392, 1000, 77720.1389311874, 81095.2520554343, 346.10250423947, 165.503154765853, 173.82402375395, 154.710421363111 ),
      ( 419, 0.287089020879261, 1000, 79892.2465766812, 83375.4867122229, 351.630542623669, 168.654440485071, 176.974510074187, 157.099703656859 ),
      ( 432, 0.278445852699642, 999.999999999999, 82105.0486562955, 85696.4111790431, 357.085306663268, 171.76441966704, 180.083859863458, 159.452252288795 ),
      ( 445, 0.27030816594998, 1000, 84358.0025495844, 88057.4838304609, 362.469906632501, 174.831959003342, 183.150906149463, 161.769799168772 ),
      ( 458, 0.26263282319245, 1000, 86650.546879191, 90458.1440707546, 367.787142077132, 177.855383426483, 186.173942380065, 164.053950605883 ),
      ( 471, 0.255381472065104, 1000, 88982.096105765, 92897.8069516367, 373.039525003987, 180.832715493166, 189.150964184852, 166.30619712006 ),
      ( 484, 0.248519897667825, 999.999999999999, 91352.037896569, 95375.8605738849, 378.229305748685, 183.761861702151, 192.079856533499, 168.527922931479 ),
      ( 497, 0.242017477240463, 999.999999999999, 93759.7325999576, 97891.6655967074, 383.35849971594, 186.640751019632, 194.958532078918, 170.720414903235 ),
      ( 239, 9298.16928210195, 3716.99999951353, 23023.1631404587, 23023.5628965706, 122.314355266558, 140.622391458241, 189.2220034331, 961.274163889448 ),
      ( 244.048290417854, 9231.61963749213, 3717.00000067677, 23981.0114077769, 23981.414045683, 126.280322678716, 141.530111191584, 190.260793567412, 940.390345523627 ),
      ( 250, 1.79514968069258, 3717.00000004448, 55059.0461870146, 57129.6256155837, 261.527725626067, 122.788045165115, 131.327096486758, 122.055537182482 ),
      ( 300, 1.49293059977908, 3717.00000000477, 61592.7056354768, 64082.4395859731, 286.839014759349, 137.996041655381, 146.395686652484, 133.433362782865 ),
      ( 350, 1.27862323443089, 3717.00000000084, 68835.7376625891, 71742.7707118167, 310.429330746363, 151.472592953098, 159.83322828265, 143.854898530547 ),
      ( 400, 1.11835776156127, 3717.00000000021, 76727.786201647, 80051.4095784912, 332.599950912577, 164.057804271307, 172.397723459663, 153.529396434258 ),
      ( 450, 0.993890736220542, 3717.00000000006, 85232.4581355754, 88972.3058517687, 353.60075180422, 176.007116031818, 184.33764409923, 162.604303777649 ),
      ( 500, 0.894387313647027, 3717.00000000002, 94318.4287223088, 98474.346346904, 373.613105090311, 187.298914408171, 195.625526611487, 171.18651400463 ),
      ( 239, 9298.23106869881, 9999.99999842276, 23022.9347724506, 23024.0102458309, 122.313399731371, 140.622656829574, 189.221130886064, 961.304391934725 ),
      ( 250, 9152.76395183981, 9999.99999859778, 25116.9157986486, 25118.0083647905, 130.878863010386, 142.655108273991, 191.539930228508, 916.023055895928 ),
      ( 260.521355785315, 9011.86874930193, 9999.99852990961, 27144.6453279258, 27145.7549755259, 138.823474510464, 144.766512586065, 193.942585678384, 873.459177751698 ),
      ( 275, 4.40441220499325, 10000.0000007321, 58201.3412529211, 60471.7917773736, 266.078510329261, 131.073017004697, 139.744597585527, 127.403097720757 ),
      ( 325, 3.71442061662666, 10000.0000001039, 65113.1536323566, 67805.3635440025, 290.548702446721, 144.972002117233, 153.455191607319, 138.469509914478 ),
      ( 375, 3.21429795784199, 10000.0000000212, 72692.3685533741, 75803.4678139837, 313.417441609791, 157.925846148383, 166.332781093569, 148.594234869068 ),
      ( 425, 2.83400688600463, 10000.000000006, 80898.3877699381, 84426.960706507, 334.988419949745, 170.140817680482, 178.508428003572, 158.005398491142 ),
      ( 475, 2.53460201456597, 10000.000000002, 89699.3490892062, 93644.7416764974, 355.481537836586, 181.749182244562, 190.100686562172, 166.855845119977 ),
      ( 239, 9299.01706320521, 89964.8306353626, 23020.0297426264, 23029.7044028645, 122.30124289405, 140.62603393334, 189.210040223938, 961.688925825631 ),
      ( 250, 9153.62765167762, 89964.8306424476, 25113.7425134007, 25123.5708387452, 130.86616780864, 142.658206397706, 191.527014531539, 916.435804599144 ),
      ( 275, 8815.62674346538, 89964.8292451374, 29974.2997087021, 29984.5048627839, 149.393503702713, 147.870217649703, 197.505106051854, 816.481877232569 ),
      ( 300, 8462.65685732871, 89964.8306356739, 34995.7961858129, 35006.4269879537, 166.867729812249, 153.541476718634, 204.402122735167, 719.84316309137 ),
      ( 309.075991480039, 8329.34828459289, 89964.8306363285, 36863.1190600334, 36873.9200047847, 173.000197573148, 155.656649873121, 207.14468422165, 685.316213745332 ),
      ( 325, 34.4936652532835, 89964.8306356865, 64882.0369497267, 67490.1920986529, 271.564843007439, 146.361712273037, 156.476393982245, 134.692097144098 ),
      ( 375, 29.4451697939321, 89964.8306356864, 72550.0674784789, 75605.4015541624, 294.770712474732, 158.915839257968, 168.136642375305, 146.230554644825 ),
      ( 425, 25.7956258036601, 89964.8306772054, 80806.9302993198, 84294.5305367383, 316.507227971821, 170.566317309901, 179.380431057125, 156.347001873062 ),
      ( 475, 22.9887909580495, 89964.8306494588, 89628.6108157327, 93542.0323964339, 337.066947734401, 181.841891949742, 190.497563839505, 165.631076551174 ),
      ( 239, 9299.11565245484, 99999.9999991509, 23019.6653661811, 23030.4190769356, 122.299717853311, 140.626457699884, 189.208650286193, 961.737158792988 ),
      ( 250, 9153.73598114195, 100000.000001334, 25113.3445095441, 25124.2690107758, 130.864575302014, 142.658595264125, 191.525396093876, 916.487573530946 ),
      ( 275, 8815.762516504, 99999.9986151954, 29973.810696984, 29985.1540150949, 149.391724874877, 147.870524086479, 197.502740580661, 816.542605216584 ),
      ( 300, 8462.83095009953, 100000.000000758, 34995.1863392742, 35007.0027161569, 166.865696220828, 153.541665317073, 204.398502847346, 719.915171164352 ),
      ( 311.977386093984, 8286.21633943997, 100000.000000161, 37464.6994233129, 37476.7676575833, 174.937686701486, 156.337340825869, 208.047074052402, 674.396850874095 ),
      ( 325, 38.5054308833773, 100000, 64851.0123902138, 67448.0486447326, 270.588279711776, 146.559863084065, 156.921613728546, 134.185376514115 ),
      ( 375, 32.8064394467308, 100000, 72531.6040083842, 75579.7860630804, 293.841779023675, 159.048017159798, 168.381196077662, 145.925720585617 ),
      ( 425, 28.7157392092686, 100000.000063881, 80795.2609437832, 84277.6717337379, 315.600386049839, 170.622115092646, 179.495113482817, 156.136451919849 ),
      ( 475, 25.57942110868, 100000.000021087, 89619.6628114667, 93529.0554281414, 336.168805867496, 181.854072390358, 190.54895443682, 165.47658136359 ),
      ( 239, 9299.12866893409, 101325.000000231, 23019.6172586625, 23030.5134408327, 122.299516503224, 140.626513651463, 189.208466796209, 961.743526863518 ),
      ( 250, 9153.75028348697, 101325.000000073, 25113.2919626285, 25124.3611962062, 130.864365045623, 142.658646609482, 191.525182442615, 916.494408394142 ),
      ( 275, 8815.78044173217, 101324.998617539, 29973.7461358395, 29985.2397295476, 149.391490022652, 147.870564552851, 197.502428327588, 816.550622746549 ),
      ( 300, 8462.85393370082, 101324.999999851, 34995.1058272518, 35007.0787386117, 166.865427739741, 153.541690231733, 204.398025037088, 719.924677653647 ),
      ( 312.343035787324, 8280.7563572281, 101325.000000603, 37540.6942929037, 37552.930493998, 175.18116066638, 156.423265740191, 208.161835109131, 673.022522771 ),
      ( 325, 39.0378516426315, 101325, 64846.8794036206, 67442.4371952627, 270.465859723367, 146.58645464766, 156.981657671783, 134.117873761027 ),
      ( 375, 33.2514552455757, 101325, 72529.155645775, 75576.3906991486, 293.725746157202, 159.065607065521, 168.413809013633, 145.885328229561 ),
      ( 425, 29.1019555850272, 101325.000067405, 80793.7168935882, 84275.4416791053, 315.487293164635, 170.629523353133, 179.510346380441, 156.108610325281 ),
      ( 475, 25.9218776051525, 101325.000022236, 89618.480159204, 93527.3405267144, 336.056867575785, 181.855689927515, 190.555766883936, 165.456169184632 ),
      ( 250, 9163.39727636218, 999999.99855377, 25077.8535529608, 25186.9833842226, 130.722358532149, 142.693530098094, 191.382403243107, 921.10454323371 ),
      ( 275, 8827.85045569271, 999999.999098422, 29930.2676592036, 30043.5455181928, 149.233076636415, 147.898314719366, 197.294517289522, 821.949845216056 ),
      ( 300, 8478.29182301625, 999999.999999776, 34940.9994645952, 35058.9477519241, 166.684679495357, 153.559265140399, 204.081499077065, 726.312051158924 ),
      ( 325, 8107.25571436432, 1000000.00000123, 40132.060513275, 40255.4068138277, 183.318102600827, 159.416228591886, 211.814277100521, 632.912585289585 ),
      ( 350, 7703.05787378497, 1000000.00000743, 45531.133599807, 45660.9521752861, 199.33770414012, 165.42143528321, 220.923913950308, 540.072057338167 ),
      ( 375, 7245.19467767877, 999999.999999841, 51184.4457500957, 51322.4682663271, 214.957265952597, 171.661502435631, 232.600855055989, 445.345224212884 ),
      ( 395.74165657818, 6794.15480896613, 999999.999996289, 56135.1998676051, 56282.3852097284, 227.827501381373, 177.224023542938, 246.703322528396, 361.774169377961 ),
      ( 400, 384.092821183586, 1000000.00000801, 74812.6012352417, 77416.1385701144, 281.089562996822, 179.555555568917, 208.512705837807, 122.093819036473 ),
      ( 450, 307.030730884556, 1000000.00000003, 84111.9451218163, 87368.9480840899, 304.548816392118, 180.203679783995, 195.519166616354, 143.257912549259 ),
      ( 500, 263.776098162808, 1000000, 93447.6111116056, 97238.705175719, 325.341700414659, 188.00536733903, 200.527840061852, 157.5804494623 ),
      ( 250, 9188.96007753995, 3429521.50479106, 24983.9991262639, 25357.2210660538, 130.3442598022, 142.788354940196, 191.016623273214, 933.321067250953 ),
      ( 263, 9018.88801490949, 3429521.50479054, 27478.6858958526, 27858.9458014109, 140.099042941001, 145.404346912391, 193.903666037796, 882.269629721097 ),
      ( 276, 8846.25795008136, 3429521.50479011, 30012.0090101365, 30399.6894874799, 149.527888377959, 148.195546050898, 197.015553038633, 832.379399248791 ),
      ( 289, 8670.43827363719, 3429521.50479084, 32586.6980342994, 32982.2399200215, 158.67068796481, 151.100168210742, 200.333146769594, 783.566790615954 ),
      ( 302, 8490.65192218689, 3429521.50479084, 35205.2901923735, 35609.207528312, 167.561462361258, 154.073555772285, 203.848825991849, 735.704307288086 ),
      ( 315, 8305.95805501663, 3429521.50479185, 37870.2976216496, 38283.1965891227, 176.229906364001, 157.088650314636, 207.569860040982, 688.639125348715 ),
      ( 328, 8115.21722043071, 3429521.50479103, 40584.4185886754, 41007.0223726083, 184.702764474944, 160.133178913534, 211.52205625786, 642.210478773348 ),
      ( 341, 7917.0281468243, 3429521.50479181, 43350.7939778763, 43783.976914856, 193.005084404803, 163.204846174616, 215.753676707041, 596.254947110545 ),
      ( 354, 7709.62103942989, 3429521.5047919, 46173.3178271038, 46618.1544133967, 201.161407417028, 166.306835695014, 220.341132307882, 550.596739390695 ),
      ( 367, 7490.68365057999, 3429521.50479165, 49057.0437779544, 49514.8820294104, 209.197035824038, 169.445998379865, 225.400392548827, 505.02667955307 ),
      ( 380, 7257.07348587404, 3429521.50479167, 52008.7968001197, 52481.3731783895, 217.139674415726, 172.635044605053, 231.111438734351, 459.274399388632 ),
      ( 393, 7004.31307132499, 3429521.50479159, 55038.2273937129, 55527.8573502652, 225.022026530265, 175.899299588802, 237.770799607174, 412.971575238528 ),
      ( 406, 6725.62038402895, 3429521.50479148, 58159.8417964335, 58669.7607792139, 232.886593157232, 179.290057165789, 245.911025350567, 365.589298985281 ),
      ( 419, 6409.79843010945, 3429521.5046813, 61397.4069920489, 61932.4505729159, 240.795916644236, 182.913484136429, 256.611310339669, 316.29970831643 ),
      ( 432, 6035.72322884022, 3429521.50474133, 64795.3218170373, 65363.5257214765, 248.858948066747, 187.010280055755, 272.511371657764, 263.603320531082 ),
      ( 445, 5552.71814529779, 3429521.50479141, 68458.3820087184, 69076.0113237766, 257.323726996925, 192.263903800895, 302.781686813367, 204.020087430578 ),
      ( 458, 4729.79002627707, 3429521.50479129, 72849.5665902516, 73574.6561789518, 267.280044150486, 202.370293426274, 438.817551333113, 123.497620934389 ),
      ( 471, 1710.21206580337, 3429521.50479142, 83158.5463111232, 85163.8657527098, 292.270906916089, 208.694979520083, 384.355310075337, 94.5252662471567 ),
      ( 484, 1405.96445899572, 3429521.50479142, 86793.7387873924, 89233.0049316029, 300.799550422715, 199.351366441677, 273.279265681213, 110.479852220432 ),
      ( 497, 1252.47008623341, 3429521.50479142, 89828.8472297521, 92567.0535489985, 307.598858508387, 195.70273036755, 244.260904656714, 121.016213234636 ),
      ( 250, 9254.64977054742, 10000000.0000031, 24743.262164231, 25823.8000827838, 129.360711432683, 143.047368793628, 190.155356051861, 964.728060328945 ),
      ( 263, 9091.8109871082, 9999999.99999893, 27213.4493483897, 28313.340229775, 139.06801493811, 145.647375426908, 192.8843239232, 916.042010549657 ),
      ( 276, 8927.4701447762, 10000000.0000005, 29719.4512337245, 30839.5893958053, 148.443105450654, 148.420338628706, 195.797423196, 868.683473683865 ),
      ( 289, 8761.23007240203, 9999999.99999919, 32263.3519099974, 33404.7441480006, 157.524360507423, 151.30266282528, 198.865638583691, 822.634029929677 ),
      ( 302, 8592.61715361934, 9999999.9999996, 34846.8886448014, 36010.6784216783, 166.343995012084, 154.247937985505, 202.068588788835, 777.835277615977 ),
      ( 315, 8421.08742356548, 9999999.99999983, 37471.5688296274, 38659.063923434, 174.929491249082, 157.226352771062, 205.395680622307, 734.209855263328 ),
      ( 328, 8246.02782736398, 9999999.99999978, 40138.7954036803, 41351.5005035607, 183.304770683892, 160.221241787117, 208.846400088717, 691.681262634051 ),
      ( 341, 8066.74964198095, 9999999.99999998, 42849.9856062923, 44089.6422764285, 191.491125322884, 163.224169599559, 212.429350167259, 650.184482791655 ),
      ( 354, 7882.47353771825, 10000000.0000002, 45606.6673778996, 46875.3046847233, 199.50791996148, 166.230451925586, 216.160425981095, 609.667130256348 ),
      ( 367, 7692.30795689347, 9999999.99978834, 48410.5481504971, 49710.5481057546, 207.373102578042, 169.236608096247, 220.061232548842, 570.0865159546 ),
      ( 380, 7495.22315630612, 9999999.99984353, 51263.5650619537, 52597.7481531442, 215.103590062281, 172.239946093191, 224.158734086566, 531.409028171119 ),
      ( 393, 7290.0224652972, 9999999.99990657, 54167.9335449386, 55539.6714301796, 222.715602988743, 175.239331378159, 228.486432103657, 493.615254502335 ),
      ( 406, 7075.31124601276, 9999999.99995975, 57126.2097304431, 58539.5751149829, 230.225005458033, 178.23589473918, 233.08677770321, 456.710453481599 ),
      ( 419, 6849.46403607779, 9999999.99998945, 60141.3751379914, 61601.3433847501, 237.647680644062, 181.232826750548, 238.014354839107, 420.737805578715 ),
      ( 432, 6610.59231369916, 9999999.99999881, 63216.9444292431, 64729.6681800749, 244.999953168677, 184.233893997394, 243.3394636907, 385.791592852873 ),
      ( 445, 6356.51996789213, 9999999.99999987, 66357.0890935649, 67930.2769464327, 252.299056021903, 187.240452195084, 249.151648618922, 352.027858296579 ),
      ( 458, 6084.78238723842, 10000000, 69566.7547111699, 71210.1988581574, 259.563615615132, 190.246417453537, 255.561628632305, 319.670085197131 ),
      ( 471, 5792.68342281414, 9999999.99999997, 72851.702250104, 74578.017891766, 266.814041121197, 193.230054565748, 262.695566497192, 289.007701523017 ),
      ( 484, 5477.49284608304, 10000000.0001233, 76218.2462406753, 78043.8990130517, 274.072387347879, 196.141042699803, 270.659646246253, 260.390410542117 ),
      ( 497, 5137.01545314234, 10000000.000001, 79671.9660218503, 81618.6216414832, 281.360217278823, 198.88246341644, 279.403688212652, 234.241346014789 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new(double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 266.625, 13187.9407187988, 8929.25608737932, 6.01237334110617 ),
      ( 294.25, 48357.0151218572, 8544.85094062139, 20.3129033500452 ),
      ( 321.875, 136385.49701937, 8136.27082293912, 54.0147795371053 ),
      ( 349.5, 318152.567857396, 7690.32735216328, 121.944336267274 ),
      ( 377.125, 645346.213899268, 7185.44866984834, 246.997293541549 ),
      ( 404.75, 1181115.10908553, 6579.93200832427, 471.685269197817 ),
      ( 432.375, 2008598.34501341, 5766.46267888741, 907.405888809195 ),
      };
    }

    [Test]
    public override void CASNumberAttribute_Test()
    {
      base.CASNumberAttribute_Test();
    }

    [Test]
    public override void ConstantsAndCharacteristicPoints_Test()
    {
      base.ConstantsAndCharacteristicPoints_Test();
    }

    [Test]
    public override void EquationOfState_Test()
    {
      base.EquationOfState_Test();
    }

    [Test]
    public override void SaturatedVaporPressure_TestMonotony()
    {
      base.SaturatedVaporPressure_TestMonotony();
    }

    [Test]
    public override void SaturatedVaporPressure_TestInverseIteration()
    {
      base.SaturatedVaporPressure_TestInverseIteration();
    }

    [Test]
    public override void SaturatedVaporProperties_TestData()
    {
      base.SaturatedVaporProperties_TestData();
    }

    [Test]
    public override void MeltingPressure_TestImplemented()
    {
      base.MeltingPressure_TestImplemented();
    }

    [Test]
    public override void SublimationPressure_TestImplemented()
    {
      base.SublimationPressure_TestImplemented();
    }
  }
}
