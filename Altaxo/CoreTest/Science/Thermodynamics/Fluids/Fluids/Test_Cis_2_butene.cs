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
	/// Tests and test data for <see cref="Cis_2_butene"/>.
	/// </summary>
	/// <remarks>
	/// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
	/// </remarks>
  [TestFixture]
  public class Test_Cis_2_butene : FluidTestBase
    {

    public Test_Cis_2_butene()
      {
      _fluid = Cis_2_butene.Instance;

    _testDataMolecularWeight = 0.05610632;

    _testDataTriplePointTemperature = 134.3;

    _testDataTriplePointPressure = 0.2636;

    _testDataTriplePointLiquidMoleDensity = 14084.011372882;

    _testDataTriplePointVaporMoleDensity = 0.00023611178083132;

    _testDataCriticalPointTemperature = 435.75;

    _testDataCriticalPointPressure = 4236033.00244;

    _testDataCriticalPointMoleDensity = 4244;

    _testDataNormalBoilingPointTemperature = 276.873516911187;

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
      _testDataEquationOfState = new (double temperature, double moleDensity, double pressure, double internalEnergy, double enthalpy, double entropy, double isochoricHeatCapacity, double isobaricHeatCapacity, double speedOfSound)[]
      {
      ( 150, 0.000317038290258487, 0.395400017609595, 14073.0335432204, 15320.2015660079, 149.095036585169, 47.6107598047212, 55.9253774027829, 161.587593617279 ),
      ( 200, 0.000237778317299642, 0.395400004554488, 16612.4102390476, 18275.3036813299, 166.052087872997, 54.2592097050521, 62.5737145816268, 184.878083119185 ),
      ( 250, 0.000190222585957985, 0.395400001787819, 19531.3871959112, 21610.0047259828, 180.899034039296, 62.8003054073885, 71.1147884793362, 204.823807455186 ),
      ( 300, 0.000158518803503041, 0.395400000901174, 22917.0303138078, 25411.3716295596, 194.73272467626, 72.8117737785271, 81.1262506741802, 222.562463734055 ),
      ( 350, 0.000135873253607499, 0.395400000528118, 26825.3337683639, 29735.3987740222, 208.042402623433, 83.5930049656544, 91.9074795940599, 238.800866386903 ),
      ( 400, 0.000118889094012658, 0.3954000003394, 31278.8861864466, 34604.6748437082, 221.030163627369, 94.5338579395305, 102.848331560207, 253.948912210779 ),
      ( 450, 0.00010567919320188, 0.395400000231113, 36274.095838593, 40015.6081292459, 233.76414792836, 105.203523759689, 113.51799686179, 268.247019826392 ),
      ( 500, 9.51112730496408E-05, 0.39540000016329, 41790.4908327401, 45947.7267468985, 246.254978704544, 115.352968143559, 123.667440946741, 281.844613172453 ),
      ( 134.3, 14084.0182708171, 1000.00000241588, -16204.7633105292, -16204.692308065, -81.9199152940023, 79.0590715946276, 114.211778470542, 1931.77891557078 ),
      ( 150, 13789.1270408496, 1000.00000023788, -14427.2172429454, -14427.1447220384, -69.4005683337395, 76.8502322568553, 112.36619348903, 1836.42443599162 ),
      ( 175, 13326.5648341454, 1000.00067535748, -11638.8127928039, -11638.7377546611, -52.204481313429, 75.1229806150226, 111.010052197481, 1683.94400995513 ),
      ( 200, 0.602239595987214, 1000.00000000062, 16604.0864267755, 18264.5551283749, 100.861478026366, 54.3857605670805, 62.7838568772535, 184.702761209528 ),
      ( 250, 0.481364259167689, 1000.00000000004, 19527.8863473177, 21605.3151986601, 115.736047402548, 62.8378733233384, 71.1804055134913, 204.73983327384 ),
      ( 300, 0.401023006503289, 1000, 22915.1732915385, 25408.7958114021, 129.577552341896, 72.8256987825925, 81.1525646155386, 222.513124377538 ),
      ( 350, 0.343692970195339, 1000, 26824.1707313917, 29733.7443529635, 142.890097610843, 83.599033001829, 91.920156187232, 238.768396741844 ),
      ( 400, 0.300713191980345, 1000, 31278.0666599141, 34603.4944318536, 155.87913282187, 94.5367903769564, 102.855362638692, 253.926095722747 ),
      ( 450, 0.267291355899459, 1000, 36273.4688993311, 40014.7047377851, 168.613772761741, 105.205089221505, 113.522349176983, 268.230345396138 ),
      ( 500, 0.240557001438148, 1000, 41789.9831803719, 45947.0020741126, 181.10498143949, 115.353871284602, 123.670374929048, 281.832139708869 ),
      ( 134.3, 14084.0186620433, 1056.70161829606, -16204.764037139, -16204.6890087225, -81.919920704366, 79.0590730368289, 114.211777282855, 1931.77915579574 ),
      ( 150, 13789.1274790047, 1056.70160716627, -14427.2180772622, -14427.1414443057, -69.4005738958674, 76.8502338670522, 112.366191900885, 1836.42469268094 ),
      ( 175, 13326.5653607901, 1056.70228506081, -11638.8138204062, -11638.7345274859, -52.2044871854594, 75.122982343432, 111.010049677578, 1683.94429872941 ),
      ( 200, 0.636440353564777, 1056.70161324985, 16603.613510004, 18263.9444543433, 100.400549544613, 54.3929520720413, 62.7958192011959, 184.692796883381 ),
      ( 250, 0.508674908885674, 1056.70161324911, 19527.6876448409, 21605.0490298638, 115.276689592552, 62.8400056510966, 71.1841324091321, 204.735066351626 ),
      ( 300, 0.423768588886497, 1056.70161324907, 22915.0679219953, 25408.6496573139, 129.11863822699, 72.8264889070112, 81.1540582293428, 222.51032462494 ),
      ( 350, 0.363184395858973, 1056.70161324907, 26824.104747741, 29733.6504917145, 142.43134622849, 83.5993749975165, 91.9208755393437, 238.766554563146 ),
      ( 400, 0.317766071389354, 1056.70161324907, 31278.0201679434, 34603.4274671837, 155.420453741844, 94.5369567357624, 102.855761574975, 253.924801332037 ),
      ( 450, 0.28244839093681, 1056.70161324907, 36273.4333341986, 40014.6534903633, 168.155130880718, 105.205178027786, 113.522596103781, 268.229399496175 ),
      ( 500, 0.254197724279849, 1056.70161324907, 41789.9543828306, 45946.9609659648, 180.646360998105, 115.353922517262, 123.670541378907, 281.831432143499 ),
      ( 134.3, 14084.0803670861, 9999.99999843423, -16204.8786388824, -16204.1686173731, -81.9207740436296, 79.0593005181386, 114.211589973535, 1931.81704431335 ),
      ( 150, 13789.1965855819, 10000.0000068254, -14427.3496663574, -14426.6244609442, -69.401451169897, 76.8504878451777, 112.365941435897, 1836.4651778864 ),
      ( 175, 13326.6484236074, 10000.0006727999, -11638.9758937736, -11638.2255175084, -52.2054133337625, 75.1232549673034, 111.009652267911, 1683.98984416022 ),
      ( 200, 12867.6078416544, 10000.001496264, -8862.78039590814, -8862.00325056618, -37.3774036257477, 75.0724597940196, 111.351985872852, 1533.62540560201 ),
      ( 225, 12405.7691336259, 10000.0000034008, -6059.06318722644, -6058.25711064258, -24.1701643993903, 76.3129444437576, 113.180448645053, 1386.61846258708 ),
      ( 227.429069665752, 12360.4929074409, 9999.9999982117, -5783.8412000817, -5783.03217085665, -22.9535005806274, 76.491237373336, 113.4309696275, 1372.52600993753 ),
      ( 250, 4.83871240072746, 10000.000000389, 19496.1796971164, 21562.845200709, 96.4643064326394, 63.1783578266192, 71.778905440903, 203.978294043358 ),
      ( 300, 4.02069314952316, 10000.0000000489, 22898.4053830819, 25385.5387275488, 110.376847971359, 72.9514471673422, 81.3909810390242, 222.067344291905 ),
      ( 350, 3.44217143788492, 10000.0000000097, 26813.6819303882, 29718.8248555629, 123.715340116969, 83.6533993708369, 92.0347207457098, 238.475497936347 ),
      ( 400, 3.01007553004773, 10000.0000000026, 31270.6803071127, 34592.8560798395, 136.715883878253, 94.5632215418666, 102.918825761926, 253.720444446606 ),
      ( 450, 2.67469390335989, 10000.0000000008, 36267.8202981886, 40006.5658748092, 149.456439554738, 105.219194418962, 113.561604579434, 268.080127616878 ),
      ( 500, 2.40670154356859, 10000.0000000003, 41785.4103263163, 45940.4747657451, 161.95105590022, 115.362007053139, 123.69682509431, 281.719803925631 ),
      ( 134.3, 14084.7011794936, 99999.9999936099, -16206.0315623435, -16198.9316602071, -81.9293600121692, 79.0615907685361, 114.209707142466, 1932.19820826284 ),
      ( 150, 13789.8918419761, 100000.000005066, -14428.6734489656, -14421.4217604715, -69.4102777278292, 76.8530446917147, 112.363423814521, 1836.87245434278 ),
      ( 175, 13327.484034768, 100000.000670644, -11640.6062535763, -11633.1029618515, -52.2147311539735, 75.1259995251404, 111.005657802677, 1684.44800025521 ),
      ( 200, 12868.6190530509, 100000.001494005, -8864.77691459924, -8857.00607290428, -37.3873878983549, 75.0752133205002, 111.345812261833, 1534.14627252727 ),
      ( 225, 12407.0058701392, 99999.9999981023, -6061.51176487312, -6053.45180253855, -24.1810489305071, 76.3155646535292, 113.171057664179, 1387.21652685739 ),
      ( 250, 11935.6095077337, 100000.000002169, -3195.76833202416, -3187.3900418382, -12.1051747579245, 78.5666140362785, 116.326692786037, 1243.80380047762 ),
      ( 275, 11445.8731518148, 99999.999999718, -235.370910711995, -226.634137320105, -0.820907844103006, 81.612969290047, 120.744831907584, 1103.26736016342 ),
      ( 275.529120717147, 11435.2331645585, 99999.9999990469, -171.462073031417, -162.71717045182, -0.588705858612667, 81.6847548535326, 120.852183149508, 1100.3152168986 ),
      ( 300, 41.3159739737423, 100000, 22725.4661346674, 25145.8374918464, 90.6520760951901, 74.2583542763497, 83.9527615516393, 217.443716060824 ),
      ( 350, 34.9629401294974, 100000, 26707.010397448, 29567.1817568822, 104.264721672661, 84.2071092994498, 93.2259855081674, 235.489501322167 ),
      ( 400, 30.4008751877299, 100000.000027348, 31196.0397384779, 34485.4187254259, 117.384117121719, 94.8304803090729, 103.569682751555, 251.641594802937 ),
      ( 450, 26.9271623185326, 100000.000008383, 36210.9422914176, 39924.6644737049, 130.185115245268, 105.361296283422, 113.961132657363, 266.569105255308 ),
      ( 500, 24.181046272196, 100000.0000029, 41739.4650375634, 45874.9353922057, 142.714330929603, 115.443790487884, 123.964721321578, 280.593449623252 ),
      ( 134.3, 14084.7103171918, 101325.000003225, -16206.0485310507, -16198.8545598776, -81.9294863959662, 79.0616244998861, 114.209679452039, 1932.20381816724 ),
      ( 150, 13789.9020751035, 101325.000001755, -14428.692931858, -14421.3451639442, -69.4104076498912, 76.8530823472451, 112.36338678903, 1836.87844842325 ),
      ( 175, 13327.4963329739, 101325.000676223, -11640.6302472743, -11633.0275439499, -52.2148683006454, 75.1260399451678, 111.005599060815, 1684.45474280738 ),
      ( 200, 12868.6339345062, 101325.001494044, -8864.80629493268, -8856.93249869217, -37.3875348452513, 75.0752538762816, 111.345721483635, 1534.15393743051 ),
      ( 225, 12407.0240686022, 101325.000002585, -6061.54779422212, -6053.38104936515, -24.1812091138385, 76.3156032543867, 113.170919602196, 1387.22532691115 ),
      ( 250, 11935.6321092523, 101324.999998408, -3195.81286295333, -3187.32357649821, -12.1053529455227, 78.5666482381626, 116.326482441841, 1243.81402579283 ),
      ( 275, 11445.9018560853, 101324.999999763, -235.426782290909, -226.574268852146, -0.821111093682381, 81.6129953413349, 120.744504453383, 1103.27943777846 ),
      ( 275.873516911187, 11428.3295706894, 101325.000000779, -129.890603973996, -121.024478843981, -0.437902120121933, 81.7316547120213, 120.922041510856, 1098.40622854887 ),
      ( 300, 41.8808940484419, 101325, 22722.8412397431, 25142.2021990101, 90.5337828485132, 74.2784509000702, 83.9933384167885, 217.373210614119 ),
      ( 350, 35.4345172794441, 101325, 26705.4147662406, 29564.914705267, 104.150690130562, 84.215410147789, 93.2441870382194, 235.444739285586 ),
      ( 400, 30.8082449106535, 101325.000028853, 31194.9301004157, 34483.8224187773, 117.271889216431, 94.8344563332275, 103.57949284923, 251.610680705298 ),
      ( 450, 27.2866662197432, 101325.000008841, 36210.0995376121, 39923.4516632568, 130.073795122202, 105.363402783896, 113.967111198218, 266.546738458301 ),
      ( 500, 24.503158351708, 101325.000003058, 41738.7856584396, 45873.9668684975, 142.603527398674, 115.44500032598, 123.968712006982, 280.576826411644 ),
      ( 150, 13796.8254051772, 999999.999491194, -14441.8663132387, -14369.3858715339, -69.498363672494, 76.8787083907397, 112.338536448642, 1840.93105285301 ),
      ( 175, 13335.8119665843, 1000000.00065525, -11656.8451998953, -11581.8591395668, -52.3076722478736, 75.1535471703024, 110.96619185495, 1689.01109273629 ),
      ( 200, 12878.6885654645, 1000000.00145326, -8884.6479753195, -8807.00031761195, -37.4869100767712, 75.1028773978555, 111.284885883954, 1539.32997827025 ),
      ( 225, 12419.3071657962, 1000000.00000243, -6085.85754181643, -6005.33775221363, -24.289447221412, 76.3419517222078, 113.078559437442, 1393.162279207 ),
      ( 250, 11950.8652240672, 1000000.00000225, -3225.82078015747, -3142.14483023642, -12.2256193593849, 78.5901118928652, 116.18615040649, 1250.70340013152 ),
      ( 275, 11465.2078706344, 1000000.00000221, -273.007853012413, -185.78745445658, -0.958063315733181, 81.6311276063336, 120.526954144341, 1111.40124313453 ),
      ( 300, 10951.466440231, 1000000.00038489, 2803.51122535226, 2894.82319766597, 9.76032188835739, 85.2979870837116, 126.149839991885, 973.996379551824 ),
      ( 325, 10393.233926372, 999999.999999889, 6038.53708185861, 6134.75352489108, 20.1297962708582, 89.4697020628841, 133.356946889414, 836.329195025711 ),
      ( 350, 9761.52915132402, 999999.999999941, 9480.87450275565, 9583.31746886248, 30.3480042696861, 94.0871690895779, 143.102047850879, 694.581066455645 ),
      ( 355.426559368769, 9609.71397509761, 999999.999985305, 10262.947690459, 10367.0090602955, 32.5698895121595, 95.1513390658936, 145.779387837498, 662.624783782722 ),
      ( 375, 379.174760554924, 1000000.00000026, 27844.8249016714, 30482.1312417262, 88.8585808258903, 94.2489047582591, 111.786075386645, 214.230377640226 ),
      ( 425, 312.937229868558, 1000000, 32928.1380184454, 36123.6670400963, 102.976073184607, 102.281085106898, 115.226247562064, 239.957975297702 ),
      ( 475, 270.602126229811, 1000000, 38372.7000091371, 42068.1624725427, 116.191802014688, 111.611129695351, 122.832892218123, 260.102687922658 ),
      ( 525, 239.902555495591, 999999.999999999, 44251.6831134143, 48420.0422121083, 128.899103519595, 120.930109665205, 131.280605587341, 277.413242809195 ),
      ( 150, 13823.0744078707, 4447834.65256867, -14491.6645699048, -14169.8957273645, -69.8328455010297, 76.9785472471918, 112.24789929989, 1856.24694334959 ),
      ( 169, 13475.9735459706, 4447834.65255596, -12380.7372091347, -12050.6805614734, -56.5290076687817, 75.5031195165975, 111.003324665073, 1742.04536320139 ),
      ( 188, 13132.6092410048, 4447834.65099626, -10284.1465802562, -9945.46029412899, -44.7236664262849, 75.0540232308209, 110.755678866593, 1629.09150590821 ),
      ( 207, 12790.5344597015, 4447834.65115947, -8184.0688281951, -7836.32459083167, -34.0367465601083, 75.4406585378481, 111.398994678911, 1518.19725837258 ),
      ( 226, 12447.221810084, 4447834.65136324, -6064.57862523147, -5707.24309130856, -24.1972589082971, 76.5178136974261, 112.841062472552, 1409.73244438318 ),
      ( 245, 12099.9970228545, 4447834.65156631, -3911.38229157941, -3543.79256051045, -15.0068192622848, 78.1678251778833, 115.005657617649, 1303.79567010131 ),
      ( 264, 11745.9088217323, 4447834.6517479, -1711.48033418394, -1332.80936719001, -6.31653983815571, 80.2932195914699, 117.837235804978, 1200.28005991015 ),
      ( 283, 11381.5305127201, 4447834.65193243, 547.260791493492, 938.054863254007, 1.98838317778555, 82.8125042594716, 121.306685792291, 1098.90559580449 ),
      ( 302, 11002.6559689706, 4447834.65212742, 2876.66614327294, 3280.91714091124, 9.9995402147346, 85.657677202833, 125.420905150977, 999.233218870899 ),
      ( 321, 10603.8050167244, 4447834.65233501, 5289.04779158938, 5708.50426455544, 17.7936806727997, 88.7733254589638, 130.241507657983, 900.658008940303 ),
      ( 340, 10177.3514054804, 4447834.6524958, 7798.48552120846, 8235.5181513386, 25.4402566007515, 92.1175944980789, 135.924174626396, 802.367782812111 ),
      ( 359, 9711.82407062665, 4447834.65256205, 10423.1800488505, 10881.1614352735, 33.0102235148291, 95.6662399290674, 142.809849837772, 703.231116569918 ),
      ( 378, 9188.12680162517, 4447834.65256193, 13190.4999255061, 13674.5849570465, 40.5904723100863, 99.4242793948409, 151.671359216534, 601.509004108781 ),
      ( 397, 8569.27733152134, 4447834.65255484, 16150.3487308806, 16669.3930423763, 48.3179950092248, 103.46424570303, 164.568286342672, 494.011593573582 ),
      ( 416, 7760.85976672683, 4447834.65256199, 19425.6429794447, 19998.7540504154, 56.5053639748028, 108.106317732297, 189.539919604341, 372.817087562477 ),
      ( 435, 6184.82427241262, 4447834.65256198, 23740.4604734238, 24459.6134285694, 66.9683336643559, 116.415350618632, 369.98038115895, 197.264114969987 ),
      ( 454, 2123.89816650408, 4447834.652562, 32125.9282977566, 34220.1128131485, 89.0681117035963, 117.952146254657, 210.940157186795, 170.013844065918 ),
      ( 473, 1730.47538554788, 4447834.652562, 35120.2338994234, 37690.5302987297, 96.5625198991436, 117.75962496233, 165.989600062163, 196.061325561981 ),
      ( 492, 1518.46302907919, 4447834.65258668, 37779.2318212808, 40708.4007028465, 102.819530653847, 119.502117287329, 153.767298715384, 214.640989655597 ),
      ( 511, 1374.44442243682, 4447834.65256629, 40344.2133120712, 43580.3097157952, 108.547384270273, 121.929289519906, 149.276409362984, 229.596529827634 ),
      ( 150, 13864.3478319898, 9999999.99999319, -14569.478255921, -13848.2037956164, -70.361951877507, 77.1438536180578, 112.116553212616, 1880.17835405735 ),
      ( 169, 13523.1097996388, 9999999.9991242, -12471.455379554, -11731.9804993462, -57.0768289783589, 75.6785489774108, 110.816957248606, 1768.0478139536 ),
      ( 188, 13186.5554975536, 9999999.99917122, -10389.3106667364, -9630.96251425438, -45.2949834529606, 75.2334222092397, 110.496491124868, 1657.48471017124 ),
      ( 207, 12852.4745213097, 9999999.99928507, -8305.67049996473, -7527.61021416491, -34.6372964398198, 75.6197253736458, 111.045335866768, 1549.32058157531 ),
      ( 226, 12518.6605810894, 9999999.99942819, -6205.17028467205, -5406.36278169253, -24.8339383920058, 76.6928750144336, 112.364636656216, 1443.97520940215 ),
      ( 245, 12182.8819173624, 9999999.99956045, -4074.25022162063, -3253.42637489935, -15.688081480202, 78.335045708103, 114.367750105157, 1341.62685599035 ),
      ( 264, 11842.8113171462, 9999999.99967889, -1900.90960511296, -1056.51550544503, -7.05302143250938, 80.4479092201411, 116.982913549188, 1242.28351263528 ),
      ( 283, 11495.9278326313, 9999999.99977387, 325.575529094662, 1195.44876989466, 1.18288896163963, 82.9482953061751, 120.155197028334, 1145.82713515012 ),
      ( 302, 11139.3863584797, 9999999.99985313, 2614.96337433024, 3512.67889276548, 9.10653132366658, 85.7653121813266, 123.848803999043, 1052.0490034361 ),
      ( 321, 10769.8404017119, 9999999.99992017, 4976.39958266204, 5904.91844895189, 16.7873522289317, 88.8386101680624, 128.051048168433, 960.680548570043 ),
      ( 340, 10383.1909883825, 9999999.99996957, 7418.84688552737, 8381.94195053757, 24.2828911713354, 92.1175655277621, 132.779388906738, 871.421887690084 ),
      ( 359, 9974.21552088508, 9999999.99999255, 9951.64749589909, 10954.2326093903, 31.6433120400265, 95.5611772607602, 138.093577087969, 783.971372682713 ),
      ( 378, 9535.9978542273, 9999999.99999937, 12585.3091611314, 13633.9671152191, 38.9155967383106, 99.1385891357505, 144.116666549939, 698.062437305994 ),
      ( 397, 9059.02613477493, 10000000.0000001, 15332.664303359, 16436.535718589, 46.1480890185005, 102.830365867554, 151.071874728119, 613.521437605995 ),
      ( 416, 8529.75001431977, 9999999.99999999, 18210.6318290581, 19382.9991297659, 53.3962769998876, 106.630858082367, 159.346360605679, 530.382550456078 ),
      ( 435, 7928.41397786141, 10000000.0000046, 21242.7749208609, 22504.0612295637, 60.7308438827716, 110.551268656535, 169.583816432141, 449.172207846209 ),
      ( 454, 7227.06634825306, 10000000, 24461.6237678298, 25845.3110785762, 68.2468701816699, 114.61489598468, 182.670400170548, 371.722307628342 ),
      ( 473, 6396.28000234384, 10000000, 27901.2004326606, 29464.6091634128, 76.0543493636825, 118.788980533456, 198.580823343354, 303.276674535576 ),
      ( 492, 5455.20956872656, 10000000.0000007, 31539.5987501079, 33372.7088944603, 84.1534251378503, 122.720202161651, 211.125364524082, 254.468962197793 ),
      ( 511, 4557.23027220774, 9999999.99999892, 35187.4703471255, 37381.7856225646, 92.1489561830656, 125.791472886277, 207.856206544343, 233.149515206889 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new (double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 171.98125, 89.0163154939846, 13382.1050546775, 0.0622682023709392 ),
      ( 209.6625, 2888.66818694032, 12689.7170459958, 1.66278435294158 ),
      ( 247.34375, 28027.7463675292, 11985.1988715603, 13.864495039255 ),
      ( 285.025, 136897.754722524, 11242.771171721, 60.8067795793445 ),
      ( 322.70625, 440885.795775802, 10426.1397762693, 184.538622068143 ),
      ( 360.3875, 1089462.80041936, 9470.79548896936, 456.195450760225 ),
      ( 398.06875, 2264744.54297563, 8215.77652248215, 1046.45963449357 ),
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
