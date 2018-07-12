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
	/// Tests and test data for <see cref="Hexafluoroethane"/>.
	/// </summary>
	/// <remarks>
	/// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
	/// </remarks>
  [TestFixture]
  public class Test_Hexafluoroethane : FluidTestBase
    {

    public Test_Hexafluoroethane()
      {
      _fluid = Hexafluoroethane.Instance;

    _testDataMolecularWeight = 0.13801182;

    _testDataTriplePointTemperature = 173.1;

    _testDataTriplePointPressure = 26080;

    _testDataTriplePointLiquidMoleDensity = 12304.0140233306;

    _testDataTriplePointVaporMoleDensity = 18.4372956442827;

    _testDataCriticalPointTemperature = 293.03;

    _testDataCriticalPointPressure = 3047675.85540335;

    _testDataCriticalPointMoleDensity = 4444;

    _testDataNormalBoilingPointTemperature = 195.058373378457;

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
      ( 173.1, 0.695259783056318, 1000.00000000005, 29051.8714451437, 30490.1827416839, 201.15505051221, 66.6855436029334, 75.0267307346474, 108.248267285593 ),
      ( 175, 0.687694708180904, 1000.00000000005, 29179.1150173219, 30633.2486439209, 201.977034921306, 67.228514892926, 75.5685974117424, 108.793676758878 ),
      ( 188, 0.640054462796598, 1000.00000000002, 30077.1046365434, 31639.4716820456, 207.521773950956, 70.8840772954944, 79.2180459182078, 112.451780027689 ),
      ( 201, 0.598599092535634, 1000.00000000001, 31021.9160176029, 32692.4832009978, 212.936409506194, 74.4376262081454, 82.7673224413531, 115.990815679962 ),
      ( 214, 0.562194529842809, 1000.00000000001, 32012.2621838171, 33791.0059227141, 218.231097350825, 77.8939449215112, 86.2205697412807, 119.422069598371 ),
      ( 227, 0.529968912041669, 1000, 33046.9185069583, 34933.8216389695, 223.41446280878, 81.2579346019071, 89.5822955067072, 122.755055853073 ),
      ( 240, 0.50124063662265, 1000, 34124.7131826979, 36119.7629191638, 228.493907036085, 84.5329916695737, 92.8556464387583, 125.998001758766 ),
      ( 253, 0.475468983928856, 1000, 35244.5049435223, 37347.6915525349, 233.47577814711, 87.7206249561076, 96.0419682515776, 129.158124351693 ),
      ( 266, 0.452219415604709, 1000, 36405.1601742232, 38616.4761095702, 238.365495854382, 90.8207091607751, 99.1410263201856, 132.241800874065 ),
      ( 279, 0.431138678795942, 1000, 37605.5350962007, 39924.9744069875, 243.167664299405, 93.8319880615392, 102.151489438585, 135.254686620759 ),
      ( 292, 0.411936617909285, 999.999999999999, 38844.4647598272, 41272.0226814204, 247.886182682958, 96.7526084958911, 105.071451927873, 138.201806396754 ),
      ( 305, 0.394372670356317, 999.999999999999, 40120.7584962695, 42656.4311611539, 252.524353248892, 99.5805787142376, 107.898884552338, 141.087631647043 ),
      ( 318, 0.378245693724697, 1000, 41433.2005649089, 44076.9847945526, 257.084983301939, 102.314112809959, 110.63197417965, 143.916148343458 ),
      ( 331, 0.363386201635731, 1000, 42780.5544932605, 45532.447645776, 261.570478100721, 104.951859936907, 113.26934987296, 146.690917566654 ),
      ( 344, 0.349650367141879, 1000, 44161.5697130526, 47021.5695699788, 265.982922618648, 107.493034324826, 115.810210817921, 149.415129489478 ),
      ( 357, 0.336915340760514, 1000, 45574.9893480865, 48543.0940290509, 270.324151397052, 109.937467940239, 118.254377562734, 152.091651111804 ),
      ( 370, 0.325075558383352, 1000, 47019.5582946578, 50095.7661922098, 274.595806689302, 112.285607431002, 120.602287979851, 154.723068086822 ),
      ( 383, 0.314039802980233, 1000, 48494.0309979409, 51678.3407271854, 278.799385741863, 114.538474036067, 122.854956485353, 157.311721065377 ),
      ( 396, 0.303728846313572, 999.999999999999, 49997.1785451798, 53289.5889044105, 282.936278417648, 116.69760130363, 125.013911265157, 159.859737065519 ),
      ( 409, 0.294073541251101, 999.999999999999, 51527.7948641726, 54928.3048037803, 287.007796510213, 118.764961703184, 127.081120531869, 162.369056417002 ),
      ( 422, 0.285013267271272, 999.999999999999, 53084.7019375299, 56593.3105352069, 291.015196095141, 120.742889967885, 129.058915607474, 164.841455834048 ),
      ( 173.1, 6.99328611615767, 10000.0000005546, 29030.9544624674, 30460.8973869318, 181.889260536204, 66.9115792298698, 75.4988174565348, 107.771721586323 ),
      ( 175, 6.91566588272775, 10000.0000004937, 29158.8471279863, 30604.8394836131, 182.716279363921, 67.4433102080987, 76.0190413895138, 108.331479671492 ),
      ( 188, 6.42858846007298, 10000.0000002323, 30060.5480988083, 31616.0995332081, 188.288832831231, 71.0379219007161, 79.5503419657059, 112.07294928268 ),
      ( 201, 6.00683433194583, 10000.0000001164, 31008.1045515434, 32672.8749526404, 193.722857246741, 74.5504555590345, 83.0189943452887, 115.675470734441 ),
      ( 214, 5.63777460977544, 10000.0000000615, 32000.5307981743, 33774.2803167738, 199.031460406509, 77.9784086910811, 86.4155759476329, 119.156224795758 ),
      ( 227, 5.31193076953988, 10000.0000000339, 33036.7970185262, 34919.3516740531, 204.225070315016, 81.322319165582, 89.7364546014157, 122.528588305794 ),
      ( 240, 5.02202040319239, 10000.0000000194, 34115.8612860601, 36107.0917465462, 209.312227910747, 84.5828709781412, 92.9797005889172, 125.803403761721 ),
      ( 253, 4.76234011711077, 10000.0000000115, 35236.6712064108, 37336.4792323185, 214.300023901037, 87.7598352926907, 96.1433925298237, 128.989708478983 ),
      ( 266, 4.52835070904714, 10000.0000000069, 36398.1553779289, 38606.4649021952, 219.194374761619, 90.851944730951, 99.2251358400739, 132.095177554076 ),
      ( 279, 4.31638943747034, 10000.0000000043, 37599.214461783, 39915.9655670458, 224.000224868974, 93.857175424756, 102.222137219296, 135.126411503201 ),
      ( 292, 4.12346519450275, 10000.0000000027, 38838.7158329995, 41263.8605906985, 228.721711445798, 96.773147840487, 105.131480256355, 138.089136685615 ),
      ( 305, 3.94710946580133, 10000.0000000017, 40115.4927241727, 42648.9922601354, 233.36230648212, 99.5975027631899, 107.950423649291, 140.988354179252 ),
      ( 318, 3.78526582741974, 10000.0000000011, 41428.3473340483, 44070.1697200913, 237.924940476066, 102.328193549268, 110.676643914372, 143.828455990861 ),
      ( 331, 3.63620666716561, 10000.0000000007, 42776.0568402919, 45526.1755533725, 242.412109538567, 104.96368158284, 113.308398548731, 146.613318854515 ),
      ( 344, 3.49846951588313, 10000.0000000005, 44157.3811928011, 47015.7739713005, 246.825966638776, 107.503044023065, 115.844612289021, 149.346381471871 ),
      ( 357, 3.37080774624033, 10000.0000000003, 45571.0717150901, 48537.7196976557, 251.168397903347, 109.946011518576, 118.284900255952, 152.030708806431 ),
      ( 370, 3.25215195781152, 10000.0000000002, 47015.8797651222, 50090.7668336618, 255.441085215767, 112.292954958048, 120.629544654719, 154.669045883656 ),
      ( 383, 3.14157941806817, 10000.0000000001, 48490.5649314744, 51673.677203756, 259.64555662472, 114.54483832411, 122.879440585855, 157.263862917234 ),
      ( 396, 3.03828965033741, 10000.0000000001, 49993.9024339875, 53285.2278673245, 263.783226194378, 116.703151460773, 125.036023804204, 159.817393204692 ),
      ( 409, 2.94158476391118, 10000.0000000001, 51524.6895500993, 54924.21762853, 267.855424925737, 118.76983316771, 127.101190202908, 162.331664981059 ),
      ( 422, 2.85085347936642, 10000.0000000001, 53081.7509998119, 56589.4724847556, 271.863424282397, 120.747192013503, 129.077213991148, 164.80852822659 ),
      ( 173.1, 12304.3421327676, 39119.9998011747, 13030.5809571072, 13033.7603225197, 73.3219451105854, 83.1052613359401, 123.215545746787, 653.362911456629 ),
      ( 175, 12247.7297790946, 39119.9999997095, 13265.1758867245, 13268.369948049, 74.6698970926242, 83.4131017478923, 123.743713772525, 645.137020541453 ),
      ( 178.035008626602, 12156.6143757702, 39120.0000003328, 13642.0220653015, 13645.2400665304, 76.8049580874852, 83.9105714127972, 124.609482236554, 632.035297302409 ),
      ( 200, 23.8957595519105, 39120.0000314446, 30887.6006910764, 32524.7112397686, 181.737138972635, 74.6642648797386, 83.6184844047747, 114.34813927397 ),
      ( 250, 18.9585542710781, 39120.0000031442, 34948.1389467689, 37011.5874272695, 201.711019208708, 87.1691177620723, 95.7699196961767, 127.694136853731 ),
      ( 300, 15.7456862124662, 39120.0000004884, 39602.4119359357, 42086.9019399036, 220.186524244238, 98.5813559830209, 107.055467542972, 139.542236496736 ),
      ( 350, 13.4739269530021, 39120.0000000949, 44792.7448646837, 47696.1300571779, 237.459973396884, 108.672686547425, 117.088701409829, 150.38064997075 ),
      ( 400, 11.7788189487315, 39120.0000000202, 50451.608073629, 53772.8239077712, 253.67568663199, 117.365979858681, 125.750773661753, 160.463375034948 ),
      ( 173.1, 12305.8733452659, 99999.9998043567, 13028.5144117646, 13036.6406127256, 73.3100025992863, 83.1089851411218, 123.199586906008, 653.683467456142 ),
      ( 175, 12249.3011708495, 100000.000002295, 13263.0554358945, 13271.2191669194, 74.6577760678649, 83.4168183809494, 123.726958661646, 645.463478132835 ),
      ( 193.813827326136, 11668.7523301536, 100000.000545715, 15643.4481784142, 15652.0180749821, 87.5745089780322, 86.5959320800077, 129.55634242428, 564.807826999105 ),
      ( 200, 62.686296229027, 100000, 30787.2780098966, 32382.5229998805, 173.42597753059, 75.5179016276925, 85.6346597856534, 112.030495406883 ),
      ( 250, 49.033179880789, 100000, 34892.3262938529, 36931.7616362705, 193.683201872509, 87.4567241189208, 96.5327941628955, 126.483576662474 ),
      ( 300, 40.5015177857574, 100000.000021578, 39565.1137944909, 42034.1570671542, 212.258495253719, 98.7062467206457, 107.437432479889, 138.829399973185 ),
      ( 350, 34.5666337887451, 100000.000004103, 44765.0817140971, 47658.0449287177, 229.57744939755, 108.736083716464, 117.313293275745, 149.939806120271 ),
      ( 400, 30.17406771505, 100000.000000861, 50429.7207662629, 53743.8248156478, 245.817542648587, 117.402215354285, 125.897770332015, 160.188766866215 ),
      ( 173.1, 12305.9066511073, 101324.999804191, 13028.4694638116, 13036.7033146506, 73.3097428067258, 83.1090661754303, 123.199240104529, 653.690440246566 ),
      ( 175, 12249.3353500056, 101324.999999834, 13263.0093162664, 13271.2811936462, 74.6575123961039, 83.4168992596282, 123.726594570339, 645.470579173617 ),
      ( 194.058373378457, 11660.9616412522, 101325.000543167, 15675.0745653271, 15683.7638144354, 87.7376150342387, 86.6386592471507, 129.639553487169, 563.772518462772 ),
      ( 200, 63.5542448276357, 101325, 30785.0236174894, 32379.3309729588, 173.305057235268, 75.5376611449427, 85.6825055659892, 111.978175509271 ),
      ( 250, 49.6957433166214, 101325, 34891.0965135365, 36930.0035352997, 193.568803105846, 87.463072633009, 96.5499161134534, 126.456861629615 ),
      ( 300, 41.0437777600851, 101325.000022762, 39564.2968240776, 42033.0023271392, 212.146320236082, 98.708983330635, 107.445884658729, 138.813799571074 ),
      ( 350, 35.0273923753569, 101325.000004326, 44764.4774656811, 47657.213496914, 229.466278038365, 108.737469015433, 117.31823040287, 149.930201208993 ),
      ( 400, 30.575301492765, 101325.000000908, 50429.243407567, 53743.1927409819, 245.706906234626, 117.403006011009, 125.900989650765, 160.182802338529 ),
      ( 175, 12253.9858456583, 281927.980714159, 13256.734987739, 13279.7420308567, 74.6216251760983, 83.4279191208806, 123.677192892097, 646.436882916478 ),
      ( 200, 11474.5463172589, 281927.981158146, 16442.3669873566, 16466.9368460127, 91.633436639023, 87.6941658306687, 131.653134376322, 539.657345816617 ),
      ( 215.504182599774, 10941.8640643372, 281927.980870781, 18529.3391907944, 18555.105182696, 101.686441868048, 90.4955610241812, 137.942279173774, 473.159337584379 ),
      ( 225, 163.857550877561, 281927.980713017, 32533.1649155047, 34253.7324401816, 174.126199863188, 83.116787919471, 95.3166548810131, 114.245955051557 ),
      ( 275, 128.350231240705, 281927.980713018, 37020.5201263732, 39217.0723100953, 194.017258070991, 93.7901351587564, 103.802575329848, 129.995775845207 ),
      ( 325, 106.659925424097, 281927.980713016, 42006.0308418518, 44649.2727116733, 212.144234723858, 104.15510400937, 113.435281621209, 142.819996771318 ),
      ( 375, 91.5946724285496, 281927.980713017, 47469.6471145044, 50547.6425179264, 229.010286466354, 113.383161040207, 122.324590862922, 154.117953044905 ),
      ( 425, 80.3978428809134, 281927.980737089, 53355.9019043003, 56862.5629120426, 244.80807082547, 121.318701593466, 130.074666250271, 164.424244665416 ),
      ( 175, 12272.3160371166, 999999.999999233, 13232.0203466984, 13313.5045585599, 74.4799529216154, 83.4716495011832, 123.485104348418, 650.247960287357 ),
      ( 200, 11501.0783816133, 1000000.00044726, 16406.954699142, 16493.9030675703, 91.4557324562378, 87.7354905103641, 131.276704007978, 544.606901199357 ),
      ( 225, 10629.2156960486, 1000000.00005325, 19805.1200712045, 19899.2003898893, 107.487130550273, 92.2957054713168, 141.773954097391, 438.439194070453 ),
      ( 250, 9548.0028074505, 999999.999854858, 23533.735935473, 23638.4698803641, 123.229938856793, 97.2235142012919, 159.508764871008, 323.687627955208 ),
      ( 250.648970105192, 9514.87322569522, 999999.99996552, 23637.1119278525, 23742.2105430674, 123.644363452125, 97.3614419094951, 160.203315824735, 320.432705279981 ),
      ( 275, 517.401260081255, 1000000.00000028, 36377.6179883713, 38310.353907575, 181.068132309908, 96.5811792534959, 114.324975756739, 116.836147690952 ),
      ( 325, 402.368526565171, 1000000, 41594.245096253, 44079.5289442132, 200.334670950494, 105.293982157879, 117.818696934147, 135.841840888355 ),
      ( 375, 336.078047357378, 1000000, 47166.2032707465, 50141.7025866438, 217.672777253707, 113.972538766478, 124.779004716159, 150.060353344183 ),
      ( 425, 290.752820484885, 1000000, 53115.6550222234, 56555.0025695054, 233.71796497327, 121.665752461611, 131.65414332084, 162.055754457913 ),
      ( 188, 11945.5112464091, 3200059.64808428, 14771.3065491278, 15039.1945936052, 82.9894649588207, 85.7758348122054, 126.530904393425, 607.963143039724 ),
      ( 201, 11547.711136747, 3200059.64810254, 16432.6714360193, 16709.7877935561, 91.5803321698068, 88.0392872247148, 130.561635964503, 555.149953696461 ),
      ( 214, 11127.9413332834, 3200059.64811906, 18148.5091865566, 18436.0789671905, 99.901039399714, 90.3733477863563, 135.122055399821, 502.738269168109 ),
      ( 227, 10678.4467006717, 3200059.64813967, 19926.390106363, 20226.0647442425, 108.019712701544, 92.7687636779605, 140.404428775355, 450.194987751268 ),
      ( 240, 10187.6113935693, 3200059.64816171, 21777.2010473324, 22091.3138971984, 116.008350129205, 95.2296621970091, 146.788790374185, 396.825706635128 ),
      ( 253, 9636.16217465858, 3200059.64817271, 23718.6391187866, 24050.7277231678, 123.957216990811, 97.7840771656719, 155.089980448771, 341.592425705129 ),
      ( 266, 8986.96266105272, 3200059.64817345, 25784.4217037199, 26140.4996990188, 132.009418051091, 100.523305517225, 167.409996176658, 282.624486325857 ),
      ( 279, 8146.33866214527, 3200059.64817352, 28058.6303171352, 28451.4521455529, 140.487090712473, 103.785745384276, 191.719684350249, 215.41500424362 ),
      ( 292, 6578.37566001699, 3200059.6481735, 31009.3820784045, 31495.8334173913, 151.13068332779, 110.435510202595, 351.424820970489, 118.352335239745 ),
      ( 305, 2228.32743755713, 3200059.64817352, 36969.1941863293, 38405.2756141475, 174.42048664274, 110.722740643241, 208.286600205135, 92.6352349430944 ),
      ( 318, 1809.97346179703, 3200059.64817351, 38941.7043136849, 40709.7189921964, 181.826178331092, 109.68427728551, 159.078347472134, 106.300339641684 ),
      ( 331, 1587.26176915888, 3200059.64819205, 40657.983086839, 42674.071239638, 187.882269025829, 110.484890754353, 145.312308438662, 116.085619677541 ),
      ( 344, 1436.55935696992, 3200059.6481762, 42293.2301530945, 44520.8162480582, 193.355487196005, 111.879505779104, 139.555892955994, 123.966169867007 ),
      ( 357, 1323.61408727196, 3200059.64817401, 43898.0762361857, 46315.7444061955, 198.477423082485, 113.523763737579, 136.933089493679, 130.671059820269 ),
      ( 370, 1233.90212980922, 3200059.64817362, 45494.20119211, 48087.648087828, 203.352620029322, 115.278059146254, 135.852537903216, 136.565795543521 ),
      ( 383, 1159.89558879219, 3200059.64817353, 47092.6689903929, 49851.5894303833, 208.038210285445, 117.073224031815, 135.631132943672, 141.863948758042 ),
      ( 396, 1097.19123980957, 3200059.64817352, 48699.6737796468, 51616.2661949571, 212.569224193075, 118.870492538687, 135.924088454831, 146.702627341841 ),
      ( 409, 1042.99410766544, 3200059.6481735, 50318.847629092, 53386.9950180895, 216.968879462621, 120.646438779513, 136.537751055496, 151.175677226302 ),
      ( 422, 995.421508958941, 3200059.64817352, 51952.3453008401, 55167.1237834955, 221.253467344216, 122.386313818968, 137.354934169166, 155.350398710185 ),
      ( 188, 12128.9585848092, 9999999.99997484, 14526.4841131174, 15350.9572061741, 81.6434031057717, 86.1738866632879, 124.674247836964, 644.469694991795 ),
      ( 201, 11765.4308867908, 9999999.99998422, 16143.4876082135, 16993.4352298694, 90.0899063381969, 88.4292204677919, 128.056186543833, 596.125764989194 ),
      ( 214, 11389.9653868013, 9999999.99998908, 17803.5282366906, 18681.4940302985, 98.2266039138919, 90.7474838963917, 131.687041567422, 549.156278522428 ),
      ( 227, 10999.5202956998, 9999999.99999382, 19509.2913587825, 20418.4219145853, 106.104983507195, 93.1118682301247, 135.577727622365, 503.396918596187 ),
      ( 240, 10590.5440024259, 9999999.99999749, 21263.5180706071, 22207.7566288631, 113.768988242847, 95.5110734869637, 139.755462518195, 458.736840204386 ),
      ( 253, 10158.8121616531, 9999999.99999946, 23069.1219623412, 24053.4890163701, 121.257437921998, 97.9378284086388, 144.262477727897, 415.137366657078 ),
      ( 266, 9699.28496821678, 9999999.9999998, 24929.2369441869, 25960.2407792911, 128.605743446857, 100.388508798103, 149.152562798925, 372.665980293804 ),
      ( 279, 9206.08619033628, 9999999.99999999, 26847.1115359562, 27933.3494652183, 135.846872741357, 102.862904367424, 154.478659282848, 331.553761934631 ),
      ( 292, 8672.86868134486, 9999999.99999997, 28825.6424265204, 29978.6634588243, 143.01108397324, 105.362559734181, 160.257426174774, 292.282130906355 ),
      ( 305, 8094.15711456737, 9999999.99999996, 30866.1339145968, 32101.5930066871, 150.123230522769, 107.884493846324, 166.38482080201, 255.689400734746 ),
      ( 318, 7468.70198705643, 10000000.0000084, 32965.6439321419, 34304.5646733014, 157.195511669586, 110.405613689196, 172.470682231518, 223.04013796968 ),
      ( 331, 6805.71560363286, 9999999.99999096, 35112.4873300066, 36581.8405299335, 164.213557937555, 112.859834257358, 177.614800324026, 195.909343661858 ),
      ( 344, 6131.83090042222, 9999999.99999996, 37281.4407466166, 38912.2750214677, 171.119056172218, 115.138248356545, 180.392211315385, 175.694519874467 ),
      ( 357, 5489.76650761449, 10000000, 39434.8889402245, 41256.4600373066, 177.808027170624, 117.155800408752, 179.635070477953, 162.851605570036 ),
      ( 370, 4920.52912612515, 10000000, 41536.7232565326, 43569.0250158913, 184.171061521737, 118.928658029953, 175.757823492183, 156.466882952948 ),
      ( 383, 4442.84144171964, 10000000, 43569.8098335453, 45820.6216464759, 190.15250863732, 120.544937874459, 170.587125288099, 154.708406670977 ),
      ( 396, 4052.09692127946, 10000000, 45537.8809051659, 48005.738953547, 195.76354014409, 122.082836197196, 165.714962173517, 155.756959441599 ),
      ( 409, 3733.12848838724, 9999999.99999013, 47454.6964105857, 50133.4148182423, 201.050492023162, 123.582169416164, 161.793472209797, 158.330491061959 ),
      ( 422, 3470.10363561205, 9999999.99999805, 49334.9802719014, 52216.7385852188, 206.065155405923, 125.056272803044, 158.874303849378, 161.671916165071 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new (double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 188.09125, 68561.244905694, 11848.786033341, 45.3917484028718 ),
      ( 203.0825, 152944.34184336, 11367.3083274319, 96.3946881121006 ),
      ( 218.07375, 301166.302134783, 10849.3445685981, 183.961630147221 ),
      ( 233.065, 538651.430081574, 10279.8108329976, 325.561325247401 ),
      ( 248.05625, 893895.728311108, 9633.76593324297, 548.724340834052 ),
      ( 263.0475, 1399257.62593553, 8862.64326319968, 906.066111252758 ),
      ( 278.03875, 2094789.71127847, 7838.20403191135, 1536.70327833698 ),
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
