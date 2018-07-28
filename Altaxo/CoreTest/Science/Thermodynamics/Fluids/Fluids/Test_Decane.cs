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
  /// Tests and test data for <see cref="Decane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  [TestFixture]
  public class Test_Decane : FluidTestBase
  {

    public Test_Decane()
    {
      _fluid = Decane.Instance;

      _testDataMolecularWeight = 0.14228168;

      _testDataTriplePointTemperature = 243.5;

      _testDataTriplePointPressure = 1.404;

      _testDataTriplePointLiquidMoleDensity = 5406.41690617915;

      _testDataTriplePointVaporMoleDensity = 0.000693577057215176;

      _testDataCriticalPointTemperature = 617.7;

      _testDataCriticalPointPressure = 2101369.98171625;

      _testDataCriticalPointMoleDensity = 1640;

      _testDataNormalBoilingPointTemperature = 447.270171672062;

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
      ( 243.5, 5406.41690910387, 2.10600032647572, -69252.4518943572, -69252.45150482, -203.071274623616, 223.933407107918, 286.345849478611, 1468.52465227086 ),
      ( 246.14034193961, 5391.68030841574, 2.10599946451576, -68495.0132487009, -68495.0128580992, -199.977397668677, 225.186806637915, 287.400796055885, 1456.18781302975 ),
      ( 250, 0.00101318734352892, 2.10600057743384, -14150.038159857, -12071.4486562627, 28.3172033411706, 195.729472177967, 204.044702869284, 123.40746906396 ),
      ( 300, 0.000844316399248167, 2.10600026506122, -3623.55099276084, -1129.22508965564, 68.1337106087913, 225.876066199849, 234.19087408047, 134.818849165489 ),
      ( 350, 0.000723697574242622, 2.10600013972764, 8468.09184421446, 11378.1473904579, 106.630672299675, 257.893790405526, 266.208433202254, 145.300091837575 ),
      ( 400, 0.000633234483058218, 2.10600008140243, 22161.3183493027, 25487.1007217842, 144.263199551862, 289.668805993399, 297.983374311683, 155.066203412425 ),
      ( 450, 0.000562874682697228, 2.10600005107758, 37409.8353588417, 41151.3432216325, 181.127814518896, 319.955462828221, 328.269993696272, 164.255304682604 ),
      ( 500, 0.000506587003668367, 2.10600003389768, 54121.2503125922, 58278.4829668992, 217.192241413956, 348.118575159942, 356.433085530372, 172.962878525434 ),
      ( 550, 0.00046053352350544, 2.10600002347913, 72182.4046939265, 76755.3617448028, 252.393390831155, 373.932346601626, 382.246844959411, 181.258918841556 ),
      ( 600, 0.00042215566164005, 2.10600001680408, 91475.6234154625, 96464.3046251907, 286.676617678435, 397.418486596768, 405.732977506096, 189.197075342488 ),
      ( 650, 0.000389682106994178, 2.10600001233093, 111887.951992252, 117292.357210073, 320.007915017763, 418.728130886071, 427.042616952959, 196.819867969686 ),
      ( 243.5, 5406.42106766659, 999.999999424679, -69252.4983446336, -69252.3133793882, -203.071465384797, 223.933487351192, 286.345793818689, 1468.52996910348 ),
      ( 250, 5370.19949511736, 999.999999824386, -67382.753942428, -67382.5677296066, -195.493689712743, 227.045030574602, 288.983097374175, 1438.35843872488 ),
      ( 275, 5232.29751623255, 1000.00001254362, -60020.7212808717, -60020.5301602389, -167.435139752697, 239.738522750268, 300.256202784023, 1328.02879126071 ),
      ( 300, 5095.57198741643, 1000.00000316867, -52358.1703985905, -52357.9741497678, -140.773965564358, 253.319631386986, 312.946658966076, 1225.31849127656 ),
      ( 324.400547757409, 4962.02632385582, 1000.00000055261, -44560.8001490465, -44560.5986184751, -115.792488654935, 267.124720429388, 326.299045501296, 1130.88580733121 ),
      ( 350, 0.344177914840187, 1000.00000000079, 8453.90683623943, 11359.3808858022, 55.3483350971366, 257.988609449101, 266.384658719693, 145.092494005591 ),
      ( 400, 0.300956980318091, 1000.00000000016, 22152.182160488, 25474.9161902594, 92.9985571232657, 289.719866473447, 298.080228313048, 154.935529007672 ),
      ( 450, 0.267425671874371, 1000.00000000004, 37403.5556371642, 41142.912419896, 129.872059640886, 319.985064544, 328.327547848877, 164.167640233252 ),
      ( 500, 0.240636428006978, 1000.00000000001, 54116.7032495496, 58272.3500411942, 165.941348050874, 348.136768632289, 356.469485479212, 172.901196649378 ),
      ( 550, 0.218734672043744, 1000, 72178.9692337815, 76750.7181506611, 201.145345574623, 373.944073040486, 382.271072592628, 181.213927736647 ),
      ( 600, 0.200491685043445, 999.999999999999, 91472.9349290838, 96460.6729481608, 235.430338014143, 397.426350125024, 405.749807058832, 189.163353737252 ),
      ( 650, 0.185059910986514, 999.999999999999, 111885.785437103, 117289.44090559, 268.762783049474, 418.733584336722, 427.054739124925, 196.794073786283 ),
      ( 243.5, 5406.42405833983, 1717.65056168688, -69252.5317497994, -69252.2140443173, -203.071602572908, 223.933545059253, 286.345753791358, 1468.53379276056 ),
      ( 250, 5370.20259816873, 1717.65056373768, -67382.7885210168, -67382.4686726438, -195.493828027682, 227.045087480794, 288.983051791646, 1438.36235154586 ),
      ( 275, 5232.3010980358, 1717.65057458001, -60020.7608102611, -60020.4325320251, -167.435283496577, 239.738576799637, 300.256133336296, 1328.0330767752 ),
      ( 300, 5095.5761375852, 1717.65056531054, -52358.215696288, -52357.8786096625, -140.774116557407, 253.319682715114, 312.946560292927, 1225.32320688339 ),
      ( 325, 4958.7392547251, 1717.6505641254, -44365.15061296, -44364.8042243971, -115.189933751625, 267.468486260203, 326.636182131307, 1128.63233429565 ),
      ( 334.422434516863, 4906.88371614073, 1717.65056383859, -41262.3126620688, -41261.9626129005, -105.77887161452, 272.89117419247, 331.98564671484, 1093.47193024571 ),
      ( 350, 0.591850383669279, 1717.65056235353, 8443.67747936343, 11345.8477064142, 50.8213128624034, 258.05698992161, 266.512179423316, 144.94263044034 ),
      ( 400, 0.517280749515291, 1717.65056234797, 22145.6012495064, 25466.1395915141, 88.4843228643656, 289.756646071141, 298.150132983431, 154.841345950831 ),
      ( 450, 0.459534148019797, 1717.65056234694, 37399.0349483212, 41136.8432695277, 125.364235864332, 320.00637437358, 328.369032855544, 164.10450977209 ),
      ( 500, 0.413442832119426, 1717.6505623467, 54113.43097265, 58267.9365751333, 161.437027204188, 348.149861470623, 356.495703027517, 172.856799137749 ),
      ( 550, 0.375781176291848, 1717.65056234664, 72176.4974193393, 76747.3771512518, 196.643075684471, 373.952510217185, 382.288515000338, 181.181554053835 ),
      ( 600, 0.344421506629726, 1717.65056234662, 91471.0008148035, 96458.0603604003, 230.92933907774, 397.432007213326, 405.761919788975, 189.139094239501 ),
      ( 650, 0.317899985550328, 1717.65056234661, 111884.226940561, 117287.343141944, 264.262610076332, 418.737507261676, 427.063462102772, 196.775520150778 ),
      ( 243.5, 5406.45857225458, 9999.99999929465, -69252.9172609073, -69251.0676212836, -203.073185809154, 223.934211057272, 286.345291920384, 1468.57791986653 ),
      ( 250, 5370.23840893029, 10000.0000000241, -67383.1875734031, -67381.3254586814, -195.495424266328, 227.045744224671, 288.98252581685, 1438.40750758613 ),
      ( 275, 5232.34243355796, 10000.0000123857, -60021.2169943215, -60019.3058044215, -167.436942379873, 239.739200574231, 300.255331976189, 1328.08253358084 ),
      ( 300, 5095.62403189385, 10000.0000029292, -52358.738444943, -52356.7759767663, -140.775859088946, 253.320275086235, 312.945421706571, 1225.3776267199 ),
      ( 325, 4958.79505888617, 10000.0000015535, -44365.7517961858, -44363.7351772526, -115.191783587077, 267.469045159794, 326.63461570613, 1128.69257665562 ),
      ( 350, 4820.62242244264, 10000.0000000752, -36021.5142230528, -36019.4398021329, -90.4632060586684, 281.915035776494, 340.999388382523, 1036.69779531405 ),
      ( 373.257584741925, 4689.74732750951, 10000.0000009864, -27931.3012276452, -27929.1689166053, -68.0884819303007, 295.428098166474, 354.762210455609, 954.305395576739 ),
      ( 375, 3.24634559593673, 10000.0000036515, 15001.6726743072, 18082.0594378631, 54.8522329401242, 274.604281051958, 283.548741126897, 148.602345283982 ),
      ( 425, 2.85063854629766, 10000.0000007897, 29520.3600229251, 33028.3459840977, 92.2267877496611, 305.438608551565, 314.117069199859, 158.651417604883 ),
      ( 475, 2.54396059984265, 10000.0000002096, 45536.0417181532, 49466.9202077132, 128.764716819121, 334.556056901372, 343.098442807583, 167.927318557087 ),
      ( 525, 2.29819527836393, 10000.0000000649, 62950.9718045436, 67302.2121426509, 164.442665916393, 361.467948455506, 369.934273362499, 176.63103437117 ),
      ( 575, 2.09637678974665, 10000.0000000225, 81651.8563026349, 86421.9911605157, 199.212945206555, 386.054851268425, 394.475665356456, 184.879871750177 ),
      ( 625, 1.92747829425947, 10000.0000000086, 101524.49373166, 106712.619600465, 233.037321092393, 408.398658503826, 416.790706010628, 192.750336448239 ),
      ( 675, 1.78395190207607, 10000.0000000035, 122461.232817888, 128066.765112994, 265.896067581314, 428.675979017204, 437.048997223039, 200.296559446769 ),
      ( 243.5, 5406.83347323426, 99999.9999988424, -69257.1045937562, -69238.6094800277, -203.090385144465, 223.941447372588, 286.340282650781, 1469.05725744211 ),
      ( 250, 5370.62739017168, 100000.000000085, -67387.5219214569, -67368.9021229241, -195.512764625292, 227.052880000108, 288.97682094564, 1438.89801430357 ),
      ( 275, 5232.79139287701, 100000.000012125, -60026.1715542031, -60007.0612949736, -167.454962240295, 239.745978218173, 300.246639503021, 1328.61971976507 ),
      ( 300, 5096.14418205276, 100000.000004656, -52364.415498017, -52344.7928192952, -140.794786270815, 253.326711740299, 312.933072123953, 1225.96866877285 ),
      ( 325, 4959.4010453745, 100000.00000063, -44372.2800008424, -44352.1162756091, -115.211874539803, 267.475118574934, 326.617628445181, 1129.3467844823 ),
      ( 350, 4821.3337995317, 100000.000001458, -36029.0591774596, -36008.3180290223, -90.484767879854, 281.920675227186, 340.976311828347, 1037.42741393907 ),
      ( 375, 4680.66310699691, 100000.000001216, -27321.0353911699, -27299.6708969273, -66.4572547339292, 296.444163003272, 355.773432725305, 949.052778843912 ),
      ( 400, 4535.93580855416, 100000.00000178, -18239.3041095444, -18217.2579421773, -43.0158711645094, 310.875504537888, 370.860279945438, 863.153886021728 ),
      ( 425, 4385.35383362227, 100000.000006764, -8777.52261095912, -8754.71943388363, -20.074050864687, 325.090857003395, 386.183578560804, 778.670949115726 ),
      ( 445.753195614754, 4254.19660681635, 99999.9999998168, -629.798661725256, -606.292460850668, -1.35714436708385, 336.668869958817, 399.128651364687, 708.795835005618 ),
      ( 450, 28.4700043976233, 100000, 36738.9424828877, 40251.4112062276, 90.0898223722674, 323.131521785774, 334.982335517523, 154.681249504623 ),
      ( 500, 25.0480688751119, 100000, 53646.5826682282, 57638.9064077785, 126.705348520403, 350.019559395663, 360.446890507604, 166.449557258846 ),
      ( 550, 22.4766967351055, 99999.9999999999, 71828.429048258, 76277.4813791466, 162.215794729228, 375.140902719044, 384.838235045546, 176.60116243104 ),
      ( 600, 20.4381554938685, 100000, 91200.8391536932, 96093.6485870102, 196.686134283027, 398.222360274565, 407.500059803373, 185.750694746091 ),
      ( 650, 18.7664065986237, 100000.000056987, 111667.686415802, 116996.357066278, 230.137216014234, 419.282733720505, 428.300130581054, 194.207512320313 ),
      ( 243.5, 5406.83899064317, 101325.000000061, -69257.1662157642, -69238.426060902, -203.090638290282, 223.941553897105, 286.340209034978, 1469.06431204849 ),
      ( 250, 5370.63311471069, 101325.000000824, -67387.5857060672, -67368.7192153134, -195.513019843646, 227.052985044729, 288.976737102441, 1438.90523318392 ),
      ( 275, 5232.79799965272, 101325.000011713, -60026.2444613948, -60006.8810156783, -167.455227445675, 239.746077992057, 300.24651174216, 1328.62762512324 ),
      ( 300, 5096.15183582158, 101325.000003449, -52364.4990305774, -52344.616381224, -140.79506481157, 253.326806497539, 312.932890622712, 1225.97736598712 ),
      ( 325, 4959.40996126132, 101325.000001053, -44372.3760484524, -44351.9451905898, -115.212170183188, 267.475207991025, 326.617378822927, 1129.35641020912 ),
      ( 350, 4821.34426464566, 101325.000000272, -36029.1701713021, -36008.1542482652, -90.4850851346, 281.920758266335, 340.975972808676, 1037.43814783277 ),
      ( 375, 4680.67551525759, 101325.000000906, -27321.1645466763, -27299.5170302718, -66.4575993006438, 296.444237627036, 355.772971978563, 949.064862010414 ),
      ( 400, 4535.95071955901, 101325.000001469, -18239.455826548, -18217.1176208959, -43.0162506393994, 310.875567139966, 370.859646334337, 863.167651203903 ),
      ( 425, 4385.37207840031, 101325.000006749, -8777.70317430408, -8754.59795125908, -20.074475944318, 325.090901303566, 386.182686635994, 778.686872826233 ),
      ( 446.270171672062, 4250.86359327891, 101324.999999778, -423.605380308835, -399.769047343462, -0.894798090483835, 336.954455633181, 399.453477201408, 707.069528423607 ),
      ( 450, 28.8738939088371, 101325, 36729.4045704583, 40238.6299045927, 89.9587232890328, 323.177079689519, 335.087354770444, 154.54198061218 ),
      ( 500, 25.3944128653833, 101325, 53640.0137135939, 57630.0646171973, 126.582592978285, 350.045920978909, 360.505749898701, 166.358346584867 ),
      ( 550, 22.783127084096, 101325, 71823.6003859938, 76270.9705659517, 162.097499122828, 375.157397576282, 384.874984119961, 176.537314079939 ),
      ( 600, 20.7144194122358, 101325, 91197.1230326302, 96088.6431850197, 196.570466082329, 398.233234280749, 407.524628742403, 185.704088478608 ),
      ( 650, 19.0186728899424, 101325.000060115, 111664.724217237, 116992.383021112, 230.023202751683, 419.290194297682, 428.317394085103, 194.172516687355 ),
      ( 250, 5374.50161621738, 1000000.00000138, -67430.670435491, -67244.6066715536, -195.68565361692, 227.124165095136, 288.92083085223, 1443.7850189688 ),
      ( 275, 5237.25975785391, 1000000.00001142, -60075.4615571357, -59884.5220112192, -167.634524248911, 239.813694652201, 300.161255613985, 1333.96807559895 ),
      ( 300, 5101.31649309329, 1000000.00000273, -52420.8479212104, -52224.8200916577, -140.983258495078, 253.391043398098, 312.811843445316, 1231.84815787199 ),
      ( 325, 4965.42022413345, 999999.999999984, -44437.1092526828, -44235.7164289416, -115.411761983316, 267.535864873578, 326.451147173271, 1135.84758181995 ),
      ( 350, 4828.38982663261, 1000000.00000023, -36103.892403292, -35896.7840222569, -90.6990522523765, 281.977167891146, 340.75073620943, 1044.66752613003 ),
      ( 375, 4689.01529971686, 1000000.00000004, -27407.9869336617, -27194.7225410161, -66.6896820042377, 296.495081822292, 355.467886607096, 957.189643233309 ),
      ( 400, 4545.95007203263, 1000000.0000008, -18341.2472782496, -18121.2712591215, -43.2713944031832, 310.918522180994, 370.44206887657, 872.403098840843 ),
      ( 425, 4397.56863927547, 1000000.0000034, -8898.52410036766, -8671.12571684449, -20.3595760857231, 325.12195288978, 385.598798564433, 789.338059807258 ),
      ( 450, 4241.74531201243, 1000000.00000011, 924.638628755577, 1160.3906427127, 2.11439619291669, 339.022541157453, 400.966912787398, 706.990781211383 ),
      ( 475, 4075.46138690373, 1000000.00080811, 11135.0316350313, 11380.4026264046, 24.2132654647933, 352.579248376694, 416.725331604665, 624.218292315876 ),
      ( 500, 3894.01094432697, 999999.999999885, 21746.724341542, 22003.5289613278, 46.0054356144336, 365.797330109637, 433.327083771313, 539.553977875957 ),
      ( 525, 3689.1191616061, 999999.999999834, 32791.4289291185, 33062.4963455379, 67.5845199557063, 378.748575100457, 451.872750185961, 450.802476683741 ),
      ( 550, 3443.28108029566, 999999.999999893, 44347.8548213904, 44638.2754918731, 89.1204920680351, 391.650023176511, 475.598327281429, 353.84810210777 ),
      ( 564.166448339472, 3269.59615869482, 999999.999861417, 51201.8033018487, 51507.6514712632, 101.45105451851, 399.173091837022, 495.628725915626, 291.668648115958 ),
      ( 575, 295.561825520381, 1000000, 77414.661837942, 80798.0487088255, 153.21064553087, 399.727520893232, 447.027898240326, 128.871471502039 ),
      ( 625, 236.130205462853, 1000000.0000007, 98598.2292440673, 102833.18088035, 189.959912709561, 416.349868884686, 440.808895037191, 157.804393571358 ),
      ( 675, 204.275804403403, 1000000.00000002, 120227.729878833, 125123.072246572, 224.263535264594, 433.896342177246, 451.70513876291, 175.958490467584 ),
      ( 250, 5379.65114269893, 2206438.48080331, -67487.9618062226, -67077.816534294, -195.915960433723, 227.219513825247, 288.848725299175, 1450.28525035644 ),
      ( 272, 5259.4639376921, 2206438.48080123, -61037.5210808801, -60618.0033302232, -171.156843397146, 238.328442681215, 298.623372465472, 1353.73176416075 ),
      ( 294, 5140.50915758977, 2206438.48080162, -54359.3493996039, -53930.1237308695, -147.5183452989, 250.15662688029, 309.526953603747, 1263.36473422345 ),
      ( 316, 5021.94614797675, 2206438.48080225, -47432.1210048126, -46992.7617572645, -124.768118023531, 262.479721761828, 321.258176588349, 1178.0843142968 ),
      ( 338, 4902.99999042718, 2206438.48080115, -40240.5236620228, -39790.5056148866, -102.739205004028, 275.102169345984, 333.571791983549, 1096.97941574221 ),
      ( 360, 4782.91286175114, 2206438.4808014, -32774.0820869249, -32312.7651981214, -81.3101246792439, 287.859182709042, 346.273942756344, 1019.27167925114 ),
      ( 382, 4660.89771827433, 2206438.48080231, -25026.0808373537, -24552.6873809491, -60.3911358755812, 300.615902158834, 359.218247981006, 944.27655118672 ),
      ( 404, 4536.08701241561, 2206438.48080236, -16992.5563517249, -16506.137446011, -39.9145237742365, 313.265667865739, 372.303830858077, 871.372530258488 ),
      ( 426, 4407.46757132099, 2206438.48080153, -8671.30918745201, -8170.69552550277, -19.8275018731716, 325.728062818082, 385.476091707247, 799.973953214018 ),
      ( 448, 4273.78808014184, 2206438.4808021, -60.865261113037, 455.407057361133, -0.0867665567884641, 337.947077641717, 398.731772245666, 729.503942806336 ),
      ( 470, 4133.41503215399, 2206438.48080189, 8840.73413317587, 9374.53934354984, 19.3460498359455, 349.88983307081, 412.131820572472, 659.363874298271 ),
      ( 492, 3984.08915043041, 2206438.48080203, 18037.5459394158, 18591.3584665687, 38.5087896700947, 361.546633172174, 425.830183965795, 588.894006086899 ),
      ( 514, 3822.47647242937, 2206438.48080203, 27538.2449874749, 28115.4724725141, 57.4441493699714, 372.933960455153, 440.138916125894, 517.315477910178 ),
      ( 536, 3643.25089975032, 2206438.48080211, 37360.778786079, 37966.4023188841, 76.2082992390521, 384.104413394785, 455.688140188333, 443.6317831191 ),
      ( 558, 3436.93740396125, 2206438.48080195, 47542.7120095437, 48184.6900910353, 94.8889716259569, 395.175808438632, 473.886261906305, 366.426971837117 ),
      ( 580, 3183.61274500539, 2206438.48080201, 58170.5721791028, 58863.6333826878, 113.656162913041, 406.42881291937, 498.673979464218, 283.304625280323 ),
      ( 602, 2824.76041916506, 2206438.48080204, 69509.8607139721, 70290.9671277522, 132.988415733699, 418.800209769092, 548.737032854031, 188.176119816398 ),
      ( 624, 1128.57619194113, 2206438.4808051, 88750.1152156753, 90705.1790355226, 166.131134000295, 440.265053970393, 1153.41544029367, 72.6255281423925 ),
      ( 646, 708.371944330795, 2206438.48080206, 102252.484581667, 105367.286767808, 189.264200217275, 436.86605202671, 543.565639880201, 114.829093305873 ),
      ( 668, 594.372273238752, 2206438.48080206, 113046.493149367, 116758.709516357, 206.608145301541, 440.86907107563, 501.486525716024, 135.669288374206 ),
      ( 272, 5295.65034873098, 9999999.99600133, -61435.1323983033, -59546.7902047146, -172.647548633041, 238.912057118762, 298.04386281439, 1397.49418193882 ),
      ( 294, 5181.32656625501, 9999999.99737932, -54803.9710087649, -52873.9633419045, -149.062159101535, 250.71594313088, 308.732689786507, 1310.54569013428 ),
      ( 316, 5068.09498879621, 9999999.99841013, -47929.8973406508, -45956.7693664284, -126.377975851604, 263.015168689742, 320.211820436499, 1229.09196127075 ),
      ( 338, 4955.34376637386, 9999999.99906118, -40798.7734398957, -38780.7499746178, -104.429213984618, 275.612304818233, 332.223418489779, 1152.30878823752 ),
      ( 360, 4842.52845074213, 9999999.99943687, -33401.6267812176, -31336.5898689607, -83.0962621604949, 288.340398632793, 344.55670729934, 1079.52564003467 ),
      ( 382, 4729.14654857226, 9999999.99964721, -25733.6964513868, -23619.1500111488, -62.2920997632102, 301.061861118028, 357.041836525993, 1010.19404463666 ),
      ( 404, 4614.71790980172, 9999999.99976309, -17793.6082024998, -15626.6285094349, -41.9528484723196, 313.666364258355, 369.544421061799, 943.866858532382 ),
      ( 426, 4498.7691256292, 9999999.99982954, -9582.66572682525, -7359.83549913915, -22.0311076140978, 326.068308062412, 381.960590180484, 880.185137480076 ),
      ( 448, 4380.82113692252, 9999999.99986915, -1104.25119856929, 1178.42588121079, -2.49121275898107, 338.20404251962, 394.212244071285, 818.871323416423 ),
      ( 470, 4260.38023456109, 9999999.99989624, 7636.66551530033, 9983.87385101979, 16.6941395920512, 350.028957414086, 406.242237261938, 759.728444543878 ),
      ( 492, 4136.93385985254, 9999999.99992046, 16633.90381521, 19051.1529999182, 35.5462669635346, 361.514537052452, 418.009202857766, 702.645550881865 ),
      ( 514, 4009.95438646204, 9999999.99994672, 25880.3244373036, 28374.1183900996, 54.0821154132958, 372.64544126742, 429.481674035615, 647.609689008932 ),
      ( 536, 3878.91662826795, 9999999.99997262, 35367.9398021362, 37945.9792286855, 72.315267852799, 383.416604776763, 440.63114612619, 594.723915981509 ),
      ( 558, 3743.33798333851, 9999999.99999134, 45087.8646325369, 47759.2771644806, 90.2564469783858, 393.830252240955, 451.424035098858, 544.228132994513 ),
      ( 580, 3602.85222324678, 9999999.99999883, 55030.1056182109, 57805.6843487166, 107.913603872359, 403.892638382029, 461.813710634954, 496.513314442586 ),
      ( 602, 3457.32386890681, 9999999.99999988, 65183.2498453632, 68075.6603857625, 125.291750647225, 413.610333095407, 471.736639881071, 452.109300890609 ),
      ( 624, 3306.99037996665, 9999999.99999997, 75534.2423344535, 78558.1398518394, 142.392871633425, 422.986168479127, 481.120594475726, 411.616698498511 ),
      ( 646, 3152.57813699073, 9999999.99999999, 86068.6029014467, 89240.6099272727, 159.21646253588, 432.015725552268, 489.912531317413, 375.562541952745 ),
      ( 668, 2995.29907062663, 10000000.0000777, 96771.4127337046, 100109.977519486, 175.761180286208, 440.686155356067, 498.11915325549, 344.211194161389 ),
      ( 338, 5351.48749539831, 99999999.9999909, -44860.0960277193, -26173.7027424916, -118.604124779742, 281.019300778731, 328.452568315879, 1592.37469297491 ),
      ( 360, 5273.28742864864, 99999999.9999999, -37786.6222697512, -18823.1196439088, -97.5390690274955, 293.564140905637, 339.814633705631, 1539.20852289826 ),
      ( 382, 5197.30451748284, 100000000, -30461.7896850006, -11221.0467838261, -77.0456636759621, 306.109160233112, 351.288640338787, 1490.19190708076 ),
      ( 404, 5123.35086204496, 99999999.9999996, -22885.1283526832, -3366.65251671733, -57.0576962965101, 318.537817894585, 362.731904601376, 1444.88930288371 ),
      ( 426, 5051.277892377, 100000000.001942, -15058.8633434519, 4738.10727122257, -37.5262271956366, 330.758600390773, 374.032908362951, 1402.93360709637 ),
      ( 448, 4980.96785434787, 100000000.000264, -6987.2951130429, 13089.1243549073, -18.4146507180126, 342.702019181964, 385.106784705989, 1364.01283124384 ),
      ( 470, 4912.3272475487, 100000000.000032, 1323.72845764667, 21680.6784246777, 0.304851119917664, 354.317549796166, 395.891187829274, 1327.85950811021 ),
      ( 492, 4845.28167209648, 100000000.000003, 9867.25526479641, 30505.8902849013, 18.6538617528155, 365.570623023407, 406.342508715531, 1294.24220414783 ),
      ( 514, 4779.77171706454, 99999999.9999995, 18635.5944356641, 39557.0956954384, 36.6495662359429, 376.439775733598, 416.432448786243, 1262.95870163499 ),
      ( 536, 4715.74963788559, 100000000, 27620.6117206143, 48826.1479934937, 54.3060664635808, 386.914047299685, 426.144975414417, 1233.83052578476 ),
      ( 558, 4653.17664687057, 99999999.9994064, 36813.9631032132, 58304.658081806, 71.6353169945019, 396.990676786089, 435.473673435842, 1206.69856472176 ),
      ( 580, 4592.02069256036, 99999999.9999525, 46207.2751423752, 67984.1804951679, 88.6477849111587, 406.673125195064, 444.419489650138, 1181.41958084768 ),
      ( 602, 4532.25463840817, 99999999.9999973, 55792.2803836791, 77856.354002261, 105.352909735908, 415.969421545291, 452.988850870413, 1157.86344934524 ),
      ( 624, 4473.85477496786, 100000000, 65560.9156567916, 87913.004633734, 121.759419375788, 424.890813317013, 461.192123923467, 1135.91098833564 ),
      ( 646, 4416.79961528069, 99999999.9999998, 75505.3903300914, 98146.2182395198, 137.87554325276, 433.450690597961, 469.042378888111, 1115.45226767357 ),
      ( 668, 4361.0689337033, 99999999.999999, 85618.2307251123, 108548.388794199, 153.709152764446, 441.663747854874, 476.554414162275, 1096.38530187518 ),
      };

      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new(double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
      ( 290.275, 103.500005865651, 5148.69811387057, 0.0428993298028441 ),
      ( 337.05, 1868.33035447421, 4892.38125013356, 0.668997940037119 ),
      ( 383.825, 14426.1141925121, 4629.26636024498, 4.59336295669421 ),
      ( 430.6, 64999.7532309396, 4350.086018518, 19.0435926364476 ),
      ( 477.375, 205665.787860551, 4041.1825617473, 57.8559892968384 ),
      ( 524.15, 513072.422375448, 3676.17628310861, 146.949905088307 ),
      ( 570.925, 1089991.80839335, 3182.09118459573, 353.749312243028 ),
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
