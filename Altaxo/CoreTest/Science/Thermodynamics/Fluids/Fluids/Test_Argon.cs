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
	/// Tests and test data for argon.
	/// </summary>
	/// <remarks>
	/// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
	/// </remarks>
  [TestFixture]
  public class Test_Argon : FluidTestBase
    {

    public Test_Argon()
      {
      _fluid = Argon.Instance;
      // TestData contains:
      // 0. Temperature (Kelvin)
      // 1. Pressure (Pa)
      // 2. Saturated liquid density (mol/m³
      // 3. Saturated vapor density (mol/m³)
      _testDataSaturatedProperties = new (double temperature, double pressure, double saturatedLiquidMoleDensity, double saturatedVaporMoleDensity)[]
      {
          (92.16595, 164543.997674992, 34168.4285308532, 225.586090539311),
          (100.5261, 337495.917867641, 32796.056733217, 438.684632494481),
          (108.88625, 618053.309615954, 31316.9080888287, 776.466606051093),
          (117.2464, 1038350.13159251, 29688.1383164124, 1287.58581269149),
          (125.60655, 1631991.36687962, 27839.5149319007, 2048.51893401718),
          (133.9667, 2435096.93151719, 25630.7962648054, 3205.344455595),
          (142.32685, 3490114.48441105, 22679.0099346873, 5142.71615130714),
      };
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
        (83.8058, 1.43564691505905, 1000.00000000001, 1044.29684842175, 1740.84694685516, 166.750683983347, 12.4783571811801, 20.8043696488057, 170.470018932537),
        (100, 1.20298118656557, 1000.00000000001, 1246.41260514314, 2077.68080049616, 170.425338845117, 12.4748968663569, 20.7961305485936, 186.229333472195),
        (130, 0.925263371161703, 1000, 1620.69240777676, 2701.46576503661, 175.880665945952, 12.4728844925259, 20.7906129263211, 212.347571050462),
        (160, 0.751740977150696, 1000, 1994.9053193032, 3325.15075010341, 180.197391330863, 12.4722916690159, 20.7886667547981, 235.584179872923),
        (190, 0.633030280441782, 1000, 2369.09262590885, 3948.79588955386, 183.769846087542, 12.4720580243469, 20.7877768725866, 256.724801189325),
        (220, 0.546700910652159, 1000, 2743.26767384842, 4572.42138571456, 186.817369081008, 12.4719475709497, 20.7873006504672, 276.251676370024),
        (250, 0.481093077614282, 999.999999999999, 3117.43597073666, 5196.03582288783, 189.474660666134, 12.471888446428, 20.7870175668758, 294.486248711699),
        (280, 0.429545281440515, 1000, 3491.60017604553, 5819.64344227911, 191.830415248238, 12.471853794981, 20.7868361794796, 311.65555502372),
        (310, 0.387975122494654, 999.999999999999, 3865.76172274363, 6443.24657169494, 193.946148910585, 12.4718320273218, 20.7867132314001, 327.92702525527),
        (340, 0.353741237949877, 1000, 4239.92144806184, 7066.84659197648, 195.866282449303, 12.4718175790671, 20.7866261733507, 343.428337489708),
        (370, 0.325059019264663, 1000.00002730041, 4614.0798726278, 7690.44437271942, 197.623942244293, 12.4718075488571, 20.7865623396299, 358.259499005755),
        (400, 0.300679252355505, 1000.00000509881, 4988.23733662968, 8314.04048821021, 199.244492933862, 12.4718003208706, 20.7865141818126, 372.500579529422),
        (430, 0.279701400822301, 999.99998902648, 5362.39407148337, 8937.63533265173, 200.747786140619, 12.4717949453361, 20.7864769791575, 386.216869069503),
        (460, 0.261459848401883, 999.999977274284, 5736.55023996732, 9561.2291854596, 202.149651853758, 12.4717908382001, 20.7864476588468, 399.46243712487),
        (490, 0.24545199434241, 999.999968627988, 6110.70595984978, 10184.8222501129, 203.462916096249, 12.4717876262443, 20.7864241521324, 412.282660192189),
        (520, 0.231291227151229, 999.999962252291, 6484.86131840905, 10808.4146782537, 204.698115990212, 12.4717850629439, 20.7864050255182, 424.716061157932),
        (550, 0.218675289703903, 999.999957560259, 6859.01638168508, 11432.0065851704, 205.864013948917, 12.4717829806833, 20.7863892606309, 436.795676588213),
        (580, 0.207364462597011, 999.999954131772, 7233.17120056115, 12055.5980600523, 206.967975123786, 12.4717812625569, 20.7863761180945, 448.550092083151),
        (610, 0.197166185493914, 999.999951661202, 7607.32581487208, 12679.1891729633, 208.016249551281, 12.47177982516, 20.7863650507142, 460.004239181216),
        (640, 0.187924003888815, 999.999949923025, 7981.48025624656, 13302.7799796958, 209.014186491639, 12.4717786077706, 20.7863556465842, 471.180017688224),
        (670, 0.179509485500271, 999.999948748713, 8355.63455011581, 13926.3705252195, 209.966399621609, 12.4717775653663, 20.7863475908977, 482.096788017289),
        (700, 0.171816215370204, 999.999948010925, 8729.78871716031, 14549.9608461778, 210.876896012934, 12.4717766640093, 20.7863406397554, 492.771765261808),
        (83.8058, 14.4039598807033, 10000.0000001002, 1039.93957619263, 1734.19310667469, 147.553758975152, 12.5384969135335, 20.9696566184241, 170.170643123286),
        (100, 12.0537219835299, 10000.0000000216, 1243.38023914116, 2072.9995064252, 151.250128105437, 12.5032681925352, 20.8855099485621, 186.047000750222),
        (130, 9.26135156136919, 10000.0000000023, 1618.80804797524, 2698.56405699169, 156.721300433682, 12.4829812983612, 20.8297720739766, 212.261392378542),
        (160, 7.52128716474314, 10000.0000000004, 1993.56192352835, 3323.12158279472, 161.044127470516, 12.4770354821552, 20.8102246051496, 235.539973136589),
        (190, 6.33223807845477, 10000.0000000001, 2368.05884190218, 3947.27931278509, 164.619538147728, 12.4746960447443, 20.8013049047116, 256.702682847247),
        (220, 5.46804461542819, 10000, 2742.43292625794, 4571.24024282314, 167.668707986997, 12.4735908609414, 20.7965360172322, 276.242511046981),
        (250, 4.8115067165956, 10000, 3116.73941399258, 5195.09045640275, 170.327007703591, 12.472999460701, 20.7937026531293, 294.485227632474),
        (280, 4.29577716059036, 10000, 3491.00495072582, 5818.87244155854, 172.683422717955, 12.4726529133236, 20.7918877029874, 311.659904997785),
        (310, 3.87993070320688, 10000, 3865.24388523919, 6442.60950461345, 174.799611738454, 12.4724352355657, 20.7906577263858, 327.93503862783),
        (340, 3.53750532574313, 10000, 4239.46459794797, 7066.31546576943, 176.720072037336, 12.4722907592505, 20.7897869051067, 343.438909521352),
        (370, 3.25063001625599, 9999.99999999999, 4613.67229891607, 7689.99902634776, 178.477974178575, 12.4721904640164, 20.789148447271, 358.271887007806),
        (400, 3.00679938982585, 9999.99999999999, 4987.87039187844, 8313.66593175953, 180.098708865933, 12.4721181899873, 20.7886668083527, 372.514268681274),
        (430, 2.79700021352751, 10000, 5362.06119202021, 8937.32012537161, 181.602145157258, 12.4720644392019, 20.788294751855, 386.231493530762),
        (460, 2.61457179473743, 9999.99999999999, 5736.24632767798, 9560.9644020211, 183.004124227584, 12.4720233712993, 20.7880015351012, 399.477731571912),
        (490, 2.45448536115086, 9999.99999999998, 6110.42697685108, 10184.6007968616, 184.317479720302, 12.471991254337, 20.7877664630417, 412.298428935239),
        (520, 2.31287306472088, 10000, 6484.60401251, 10808.2308265076, 185.552754092217, 12.4719656232803, 20.7875751966476, 424.732157842261),
        (550, 2.1867112230957, 9999.99999999999, 6858.77809516776, 11431.8556439458, 186.718713580209, 12.4719448021388, 20.7874175499478, 436.811990493261),
        (580, 2.07360191634532, 10000, 7232.94973372708, 12055.476141122, 187.822726133328, 12.4719276219817, 20.7872861279376, 448.566538659887),
        (610, 1.97161905936904, 10000, 7607.11932657973, 12679.0930186986, 188.871043872519, 12.4719132488545, 20.7871754579728, 460.020753383976),
        (640, 1.87919778328499, 10000, 7981.28719003999, 13302.7068346073, 189.869017636428, 12.4719010756041, 20.7870814206078, 471.196549191802),
        (670, 1.79505354538945, 9999.99999999999, 8355.45357843752, 13926.318038545, 190.821262314388, 12.4718906520565, 20.7870008675654, 482.113297731957),
        (700, 1.71812204567078, 9999.99999999998, 8729.61869858764, 14549.9269969401, 191.731785921864, 12.4718816388707, 20.7869313597468, 492.788222758226),
        (86.17815867486, 35104.0361671278, 100000.000000842, -4747.69916691563, -4744.85049163724, 54.3506998033609, 21.5830907082062, 44.5918027397187, 846.173218973525),
        (87.17815867486, 142.79264607145, 99999.9999999997, 1040.33475562956, 1740.65093262625, 128.747705869352, 13.0994562673038, 22.5868261206514, 170.77122530487),
        (100, 123.039575709206, 100000, 1212.18833049204, 2024.93495631219, 131.791187528272, 12.8065375700563, 21.8523786481513, 184.164268396659),
        (150, 80.7425485848085, 100000.00000687, 1853.70675444552, 3092.21113360608, 140.456066915684, 12.5387122519609, 21.0781899136555, 227.493431850221),
        (200, 60.3099367340688, 100000.000000482, 2483.25411941836, 4141.35567640429, 146.493548228084, 12.4965782640909, 20.9184100524596, 263.207658974377),
        (250, 48.1726888250049, 100000.000000047, 3109.7674501086, 5185.63247735076, 151.154257700677, 12.4841092168458, 20.8607501784858, 294.475850123429),
        (300, 40.1149172962465, 100000.000000004, 3735.083001309, 6227.92124553396, 154.954966183842, 12.4790877057349, 20.8337724469849, 322.671382733084),
        (350, 34.3713448172303, 100000, 4359.80857025332, 7269.20884340965, 158.165299009264, 12.4766461089451, 20.8190647615959, 348.566395089221),
        (400, 30.0686605165921, 100000, 4984.20137571029, 8309.92318313231, 160.944672856154, 12.4752950269064, 20.8101920548083, 372.651504024904),
        (450, 26.7244561093276, 99999.9999999999, 5608.38841227434, 9350.27934509288, 163.395405630179, 12.4744729631932, 20.8044394574827, 395.262900806259),
        (500, 24.0502690525124, 100000, 6232.43944429821, 10390.3970863377, 165.587156096424, 12.4739351165292, 20.8005032352305, 416.643380110537),
        (550, 21.8629298479009, 99999.9999999999, 6856.39593132732, 11430.3483107977, 167.569516983266, 12.4735625511014, 20.7976948505834, 436.975273754357),
        (600, 20.0405029726333, 99999.9999999996, 7480.28404554074, 12470.1787670733, 169.379059885591, 12.4732923916483, 20.7956231390851, 456.399732211997),
        (650, 18.498657080478, 99999.9999999997, 8104.12111842032, 13509.9189320104, 171.043533084865, 12.4730890606791, 20.7940526435407, 475.028723263161),
        (700, 17.1771993700067, 99999.9999999998, 8727.91908165278, 14549.5898817607, 172.584491757644, 12.4729312657622, 20.7928348125622, 492.952863788519),
        (86.3026188954517, 35084.9386490088, 101325.000000146, -4742.16492009106, -4739.27692872206, 54.414890244655, 21.5644201779594, 44.5952088392402, 845.31337393317),
        (87.3026188954517, 144.526125190851, 101325, 1041.39247203133, 1742.47679063599, 128.662911975177, 13.1045183094936, 22.6036598010298, 170.865020149242),
        (100, 124.708805156785, 101325, 1211.71669676993, 2024.20944636058, 131.676967370273, 12.8112870796795, 21.8676922050052, 184.135698558147),
        (150, 81.8200160930455, 101325.000007245, 1853.48494312101, 3091.87384654066, 140.345140614313, 12.5396093480053, 21.0821318316883, 227.485247883094),
        (200, 61.1113896980553, 101325.000000508, 2483.11239661966, 4141.15029268361, 146.383395557526, 12.4969077536444, 20.9201731582056, 263.205166460104),
        (250, 48.8118368863646, 101325.000000049, 3109.66472045669, 5185.49317649158, 151.044403124369, 12.4842727714506, 20.8617399407347, 294.475723420219),
        (300, 40.6467664802284, 101325.000000005, 3735.00322789471, 6227.82144627112, 154.84525663727, 12.4791846734618, 20.8344025886263, 322.672422415639),
        (350, 34.8268722074018, 101325, 4359.74389061538, 7269.13521914432, 158.055670546065, 12.4767107401634, 20.8194994052585, 348.568064142613),
        (400, 30.4670799160004, 101325, 4984.14736553409, 8309.86811984855, 160.835094136884, 12.4753417718051, 20.8105089397146, 372.653529103627),
        (450, 27.0785202793514, 101325, 5608.34233930619, 9350.23809116767, 163.285859529062, 12.4745088261627, 20.8046800609927, 395.265130436117),
        (500, 24.3688804071966, 101325, 6232.39950407835, 10390.3664810954, 165.477632482496, 12.4739638595286, 20.8006916712096, 416.645725198934),
        (550, 22.1525512000706, 101325, 6856.36087011439, 11430.3261477424, 167.460009489993, 12.473586361637, 20.7978460792286, 436.977679604057),
        (600, 20.3059754709586, 101325, 7480.25295697207, 12470.1634463703, 169.269564316861, 12.4733126250974, 20.7957469264524, 456.402164192165),
        (650, 18.7437014651616, 101325, 8104.09332604546, 13509.9092577775, 170.934046566404, 12.4731066016036, 20.7941556316569, 475.031158977614),
        (700, 17.4047372593746, 101324.999999999, 8727.89406724033, 14549.5849373753, 172.475012256946, 12.4729467169486, 20.7929216736082, 492.955288566816),
        (86.4891945430573, 35056.2869889339, 103336.500000965, -4733.86822738893, -4730.92049650021, 54.5109489572127, 21.5365857847659, 44.6007029016445, 844.023436500315),
        (87.4891945430573, 147.154365088454, 103336.5, 1042.97099171891, 1745.20296382443, 128.5362851464, 13.1121538779443, 22.6291089149805, 171.005097625551),
        (100, 127.244929117324, 103336.5, 1210.99997991876, 2023.10699838172, 131.506265064708, 12.8185142513436, 21.8910046913224, 184.092276549969),
        (150, 83.4561198218323, 103336.500007843, 1853.1481344041, 3091.36170374393, 140.179447070865, 12.5409717512109, 21.0881198880495, 227.472821728355),
        (200, 62.3282037729542, 103336.50000055, 2482.89722870334, 4140.83847753153, 146.218876973678, 12.4974079918752, 20.922850372054, 263.201383100751),
        (250, 49.7821790085576, 103336.500000053, 3109.50876039934, 5185.2816987894, 150.880337155456, 12.4845210655174, 20.8632426603122, 294.475531702121),
        (300, 41.454190046919, 103336.500000005, 3734.88212148265, 6227.66994059204, 154.681410855262, 12.4793318785328, 20.8353592548924, 322.674001256883),
        (350, 35.5184196829598, 103336.5, 4359.64569947792, 7269.02345114565, 157.89194786116, 12.4768088554928, 20.8201592524349, 348.570598309188),
        (400, 31.0719261338788, 103336.5, 4984.06537230114, 8309.78452967673, 160.671446969322, 12.4754127344547, 20.8109900060317, 372.656603661372),
        (450, 27.6160280179641, 103336.5, 5608.27239581704, 9350.17546503395, 163.122261879243, 12.4745632693329, 20.8050453205601, 395.268515457977),
        (500, 24.8525657708983, 103336.5, 6232.33887083918, 10390.3200206569, 165.314068970333, 12.4740074941033, 20.8009777339405, 416.649285451807),
        (550, 22.5922260727918, 103336.5, 6856.30764375306, 11430.2925032818, 167.296470450392, 12.4736225083747, 20.7980756572083, 436.981332064752),
        (600, 20.70898956648, 103336.5, 7480.20576150646, 12470.1401891746, 169.106043379719, 12.4733433415391, 20.7959348459136, 456.405856296405),
        (650, 19.1157034398251, 103336.5, 8104.05113453965, 13509.8945723862, 170.770539368313, 12.4731332305689, 20.7943119759924, 475.034856731937),
        (700, 17.7501625339099, 103336.5, 8727.85609295897, 14549.5774322755, 172.311515712387, 12.4729701735071, 20.7930535356858, 492.958969704454),
        (100, 32911.6437225618, 578806.4728382, -4130.93462333508, -4113.3479455709, 60.9932821393508, 19.8898180285324, 46.0058618431032, 748.686516771926),
        (106.912002935844, 31682.7677892398, 578806.472839176, -3808.2986376931, -3790.02982744617, 64.1190031654581, 19.2232760556475, 47.6708373093602, 694.18180422008),
        (107.912002935844, 31495.998932415, 578806.472839423, -3760.5835815236, -3742.20643863375, 64.5642373447564, 19.1354607286864, 47.9792665861243, 685.942097597323),
        (125, 600.145242285685, 578806.472838721, 1418.55131760976, 2382.99530892478, 121.039516857231, 13.354968135936, 24.3252295039648, 201.491890519271),
        (175, 408.279967607541, 578806.47283872, 2105.23207624512, 3522.90259344056, 128.731806222297, 12.7020635602693, 21.9428297824829, 244.355212883259),
        (225, 312.920632164663, 578806.47283872, 2753.29893576234, 4602.98992237055, 134.163643784772, 12.5706648653312, 21.3616494938845, 278.92191229701),
        (275, 254.466160884673, 578806.472854074, 3389.93809417012, 5664.52922582317, 138.424812341093, 12.5257303369893, 21.129584754685, 309.118744668787),
        (325, 214.676451657585, 578806.472839867, 4021.63563956899, 6717.81618648375, 141.944198256913, 12.5058474435814, 21.0136668793578, 336.391310547859),
        (375, 185.755637920353, 578806.472838743, 4650.75007103993, 7766.70649270677, 144.946252466621, 12.4955132643566, 20.9475278659758, 361.498128514655),
        (425, 163.752984774538, 578806.472838716, 5278.34535345289, 8812.97694282906, 147.565396142501, 12.4895025641878, 20.9062718800795, 384.905949506769),
        (475, 146.437286000636, 578806.47283865, 5904.97168415848, 9857.56114171054, 149.889115194405, 12.4857015668961, 20.8788312898766, 406.929736808991),
        (525, 132.448336198474, 578806.472838539, 6530.94211648714, 10900.9968068775, 151.977744164556, 12.4831375615779, 20.8596727751102, 427.795346574735),
        (575, 120.907918569126, 578806.472838439, 7156.44788779649, 11943.6155083152, 153.874731279495, 12.4813172358617, 20.845779184639, 447.671922672861),
        (625, 111.222945313083, 578806.47283837, 7781.61242780449, 12985.6327961654, 155.61243885175, 12.4799705020554, 20.8353913821947, 466.690353299248),
        (675, 102.97809144969, 578806.472838328, 8406.51897674789, 14027.1948378955, 157.215636761981, 12.4789400063889, 20.8274274641128, 484.954558929636),
        (100, 32954.8981605602, 999999.999999861, -4137.51660626857, -4107.17210345361, 60.9271476917307, 19.9090462638419, 45.8702994412689, 751.592591524268),
        (115.598448074656, 30033.8868173349, 1000000.00006918, -3392.90274109376, -3359.60701729514, 67.8656420491024, 18.550276532709, 50.806805940743, 623.344908812286),
        (116.598448074656, 1240.25499638862, 1000000.0000009, 1143.46699639404, 1949.7528028715, 113.403086912533, 15.1586868561892, 31.9858234397874, 184.629066763799),
        (125, 1108.18935176444, 1000000.00000008, 1299.06262375512, 2201.43548847169, 115.488854872353, 14.239777104724, 28.3546459479574, 195.687670095644),
        (175, 719.524900968486, 999999.999999999, 2046.99351263744, 3436.79947856578, 123.849712393786, 12.8787454525782, 22.8883357476549, 242.882728783357),
        (225, 545.142148012117, 1000000, 2714.58952687022, 4548.97346442951, 129.445435085279, 12.6431167194804, 21.799601769538, 278.63716626337),
        (275, 441.292655889442, 999999.999999999, 3361.12932802818, 5627.19921759944, 133.77418207213, 12.5648225655257, 21.3841812980243, 309.343321116881),
        (325, 371.480681747802, 1000000.00000893, 3998.85458665898, 6690.78460924851, 137.328179176844, 12.5304803032943, 21.1803180475171, 336.872638798067),
        (375, 321.064845237275, 1000000.00000013, 4632.03561295593, 7746.67122265996, 140.350340538548, 12.512683066353, 21.0649943111972, 362.119319277959),
        (425, 282.85044222032, 999999.999999947, 5262.56327315967, 8798.00055991144, 142.982187441455, 12.5023400773899, 20.9933948601105, 385.605866368906),
        (475, 252.844376650896, 999999.999999292, 5891.40558738231, 9846.40752669773, 145.314430917131, 12.4957993273243, 20.9459035269365, 407.673783020486),
        (525, 228.638403404511, 999999.999998282, 6519.1100261553, 10892.8284615008, 147.409047028696, 12.4913856428434, 20.9128027620586, 428.562856769085),
        (575, 208.688583759148, 999999.999997385, 7146.00972806037, 11937.8386915053, 149.310392321613, 12.4882506901514, 20.8888247147554, 448.450076216448),
        (625, 191.957288415267, 999999.999996752, 7772.31914388752, 12981.8113608927, 151.051365107382, 12.485930266178, 20.8709099364211, 467.470986411886),
        (675, 177.720386772694, 999999.999996388, 8398.1826305479, 14024.9991041998, 152.657068173914, 12.4841539467944, 20.8571818776125, 485.732387697231),
        (100, 33352.5343394444, 5106149.99999343, -4197.69085715875, -4044.59454525556, 60.3145182280547, 20.101193706812, 44.7242619343821, 777.982294992087),
        (130, 27683.3610622489, 5106149.9999996, -2778.06261450898, -2593.61427427609, 72.949800235507, 17.8347627141457, 54.9519519399387, 542.591528994909),
        (160, 6347.31057397456, 5106150, 804.155232537836, 1608.61405655322, 101.239996457419, 17.7384476246917, 74.8700058740739, 205.621612170214),
        (190, 3968.67964711839, 5106150.00000107, 1676.6244646506, 2963.23624842322, 109.084337784123, 14.2382487556005, 33.5646888147148, 247.366763657373),
        (220, 3122.75745445772, 5106150.00000001, 2228.62512308675, 3863.76652438611, 113.495517429964, 13.4384973922139, 27.5631128504116, 274.454593225574),
        (250, 2624.13827765801, 5106150.00000001, 2704.40690079773, 4650.24567136631, 116.850035857633, 13.0941628881063, 25.1584857982312, 296.779616921867),
        (280, 2281.52120947898, 5106150.00000001, 3146.17309748288, 5384.21935310636, 119.624062704412, 12.9110803435223, 23.889368179203, 316.445977694363),
        (310, 2026.76145543339, 5106150.00000001, 3569.13284897759, 6088.49692426692, 122.01416703496, 12.8014180116366, 23.1199264460029, 334.338623124979),
        (340, 1827.81166205176, 5106149.99999999, 3980.40528868892, 6773.99179763384, 124.125241984377, 12.7303316055788, 22.6119450185645, 350.930122047741),
        (370, 1667.10943010892, 5106149.999999, 4383.84607924182, 7446.72240144305, 126.021598201949, 12.6815287030362, 22.2564328096317, 366.508739523546),
        (400, 1534.03404259585, 5106149.99999999, 4781.75171444762, 8110.32843322727, 127.746254529592, 12.646509983671, 21.996748993223, 381.266134083414),
        (430, 1421.70253809582, 5106149.99999998, 5175.58576127338, 8767.15985161649, 129.329755972136, 12.6204769136962, 21.8007161148205, 395.337715883344),
        (460, 1325.41873835335, 5106150, 5566.3297327503, 9418.81035056901, 130.794751643858, 12.6005518300871, 21.6488036190797, 408.823590637313),
        (490, 1241.8482004686, 5106149.99999998, 5954.66871449749, 10066.4031423231, 132.158598330064, 12.5849241629714, 21.5285327764151, 421.800412665222),
        (520, 1168.54676988522, 5106149.99999999, 6341.09659738052, 10710.7548186784, 133.434946190517, 12.5724089993733, 21.4315958511887, 434.32854974227),
        (550, 1103.67558212534, 5106150, 6725.97908524291, 11352.4744818042, 134.634757430546, 12.5622048204276, 21.352272024375, 446.4566451478),
        (580, 1045.82074951489, 5106150, 7109.5931349483, 11992.0263840194, 135.766989208187, 12.5537539002724, 21.2865088683921, 458.224647696912),
        (610, 993.874906572635, 5106150, 7492.15257331589, 12629.770965965, 136.839067679185, 12.5466585104919, 21.2313658530241, 469.66589602701),
        (640, 946.956892167902, 5106150, 7873.82526420185, 13265.992576391, 137.857226737585, 12.5406288402954, 21.1846645033734, 480.808595428207),
        (670, 904.355801108298, 5106150, 8254.74492599971, 13900.9186927211, 138.826756073538, 12.5354496383396, 21.1447614155268, 491.676891158011),
        (700, 865.491092743789, 5106150, 8635.01945863124, 14534.7335548358, 139.752186674469, 12.5309582744146, 21.1103969036684, 502.291665849044),
        (100, 33779.2869305082, 9999999.99999804, -4261.48786917859, -3965.44846430393, 59.6481404618862, 20.330843762395, 43.6704845869132, 805.911156852952),
        (130, 28762.9470045915, 9999999.99999979, -2938.92516865709, -2591.25564792254, 71.6353315303391, 17.9337983380953, 49.261241437736, 603.328406474535),
        (160, 20866.415564268, 9999999.99999988, -1284.37807949153, -805.139085654754, 83.8999594791108, 17.4026338512451, 78.6963244378625, 357.761143834515),
        (190, 9893.02671980343, 10000000, 746.815927525357, 1757.62892573372, 98.644149816305, 15.9913712762897, 61.0055870716264, 260.683213004124),
        (220, 6781.2913147547, 10000000, 1661.89608090027, 3136.54147450577, 105.423691037087, 14.3205131546329, 36.9799797716289, 283.741183747649),
        (250, 5419.6005446418, 10000000, 2282.94385278678, 4128.09829131578, 109.657930429672, 13.6375185083265, 30.1774524622439, 306.159334230495),
        (280, 4596.01375999231, 9999999.99999999, 2806.73662810942, 4982.53516184069, 112.888916828687, 13.2906404959397, 27.1196188985411, 326.147161191656),
        (310, 4024.75341206053, 9999999.99999921, 3283.79235981144, 5768.41662773139, 115.556684172594, 13.0874134305928, 25.4171648612256, 344.293289292032),
        (340, 3597.39706786285, 10000000, 3733.99638985306, 6513.78405614501, 117.852510473382, 12.9568058758598, 24.3486584993253, 361.049408726839),
        (370, 3261.93028117647, 10000000, 4167.06665704205, 7232.73610365982, 119.879364534101, 12.8672839632062, 23.6246344661666, 376.718940494458),
        (400, 2989.634321685, 9999999.99999999, 4588.41690089191, 7933.30758784517, 121.700214004515, 12.8029208607773, 23.1071222193314, 391.511034301515),
        (430, 2763.08785229188, 9999999.99999999, 5001.34143268633, 8620.48079219144, 123.356942214965, 12.7548947221038, 22.7223126290988, 405.575474894251),
        (460, 2570.98341660516, 10000000, 5407.97699506164, 9297.53922849076, 124.87911019109, 12.7179710291126, 22.4273103404108, 419.023339089743),
        (490, 2405.59784081815, 10000000, 5809.77834646808, 9966.74915443945, 126.288518813054, 12.6888735409997, 22.1955801310543, 431.939489738247),
        (520, 2261.44158839454, 9999999.99999998, 6207.77447162494, 10629.7325939655, 127.601798209158, 12.6654620197433, 22.0098860835563, 444.390417555354),
        (550, 2134.48581931228, 9999999.99999998, 6602.71604980123, 11287.6850992662, 128.831978023549, 12.6462881652776, 21.8585841525838, 456.429346416317),
        (580, 2021.69495409101, 10000000, 6995.1649266836, 11941.5095667414, 129.98949084097, 12.6303423929369, 21.7335494734753, 468.099668623452),
        (610, 1920.73097340151, 9999999.99999998, 7385.55078637177, 12591.9019820785, 131.082841155412, 12.6169028193045, 21.6289569113767, 479.437324786917),
        (640, 1829.75921968493, 10000000, 7774.20835903411, 13239.4083112562, 132.119067242452, 12.6054417479403, 21.5405325425609, 490.472495365584),
        (670, 1747.31675855052, 9999999.99999999, 8161.40260351481, 13884.4633771638, 133.104069542816, 12.5955658697063, 21.4650774579197, 501.230830456575),
        (700, 1672.22069550389, 9999999.99999999, 8547.34620236098, 14527.4181072758, 134.042850034375, 12.5869769426961, 21.4001553832914, 511.734361985334),
        (130, 35739.237011889, 100000000.0002, -3904.79903638127, -1106.75385240226, 62.0397644249499, 20.8496636529038, 36.757826064614, 1014.37688038985),
        (160, 33346.6464013718, 100000000.00001, -3021.92769173986, -23.1253895120588, 69.5443029376177, 19.1525483033805, 35.5271897245947, 936.957658657205),
        (190, 31088.3269986052, 100000000.000001, -2190.10149661336, 1026.53991366542, 75.5597455875721, 17.9290211968941, 34.469152992582, 873.001093628846),
        (220, 28977.9844023466, 100000000, -1405.09178861777, 2045.80385034538, 80.5424185407892, 17.0252092765846, 33.4901766685067, 821.354908258805),
        (250, 27028.1360743715, 100000000.000001, -663.58322817427, 3036.26494947429, 84.7641729266537, 16.3437635987739, 32.543663272889, 780.709007947482),
        (280, 25246.2022411392, 99999999.9998581, 37.5809309553921, 3998.57272864075, 88.4004049423512, 15.8191251902009, 31.6129428778999, 749.597777202321),
        (310, 23632.4568220303, 99999999.9999825, 701.808862443922, 4933.27750546549, 91.5724137351201, 15.4065265729377, 30.7061128807385, 726.462375652068),
        (340, 22180.1372226918, 99999999.999998, 1332.81677878694, 5841.35516139402, 94.3691008944193, 15.0751988390514, 29.8407123039897, 709.763266292386),
        (370, 20877.4292634097, 99999999.9999997, 1934.42228447427, 6724.28404083822, 96.8581885215586, 14.8041260330464, 29.0314727672537, 698.126373377468),
        (400, 19709.9303962425, 99999999.9999998, 2510.30815895465, 7583.89279317862, 99.09244646247, 14.5788936349789, 28.2869824847573, 690.419850172827),
        (430, 18662.5818245427, 99999999.9999998, 3063.869072743, 8422.18449448664, 101.11360169494, 14.3893487365036, 27.610510623073, 685.7505713144),
        (460, 17720.8816212922, 100000000, 3598.13734026283, 9241.19743947633, 102.955008666806, 14.2280795699024, 27.0013479729001, 683.426587287042),
        (490, 16871.5349262268, 100000000, 4115.76133526497, 10042.9043271305, 104.643555412534, 14.0895148603626, 26.4560268913576, 682.916129182954),
        (520, 16102.7254805506, 99999999.9999999, 4619.0177732073, 10829.1466188355, 106.201072134935, 13.9693869380702, 25.9694396302092, 683.812184765733),
        (550, 15404.1533146, 100000000, 5109.84410582, 11601.5998003846, 107.645402056908, 13.8643864077301, 25.5357606333467, 685.803603632425),
        (580, 14766.9433881949, 99999999.9999999, 5589.88013928923, 12361.7622662257, 108.991229462519, 13.771921844183, 25.1490938516192, 688.652144061419),
        (610, 14183.4951684744, 99999999.9999997, 6060.51122726043, 13110.9595696598, 110.250724609178, 13.6899448589019, 24.803858181065, 692.174662279973),
        (640, 13647.315302904, 100000000.000001, 6522.90861069291, 13850.3571073743, 111.434047212737, 13.6168205721201, 24.4949767455493, 696.229563105481),
        (670, 13152.8559422765, 99999999.9999999, 6978.06491820972, 14580.9764409137, 112.549740077307, 13.5512312522256, 24.2179408004719, 700.706630943767),
        (700, 12695.3690046664, 99999999.9999998, 7426.82434344706, 15303.7123616877, 113.605037534771, 13.492104457487, 23.9688028428945, 705.519451210506),
      };

      // TestData contains:
		   // 0. Temperature (Kelvin)
		   // 1. Pressure (Pa
		   _testDataSublimationLine = new (double temperature, double pressure)[]
      {
      ( 83, 61834.6496950285 ),
      ( 81, 46850.5896274609 ),
      ( 79, 35002.2609704682 ),
      ( 77, 25757.2520363947 ),
      ( 75, 18646.5778867842 ),
      ( 73, 13262.0621569055 ),
      ( 71, 9253.06518970908 ),
      ( 69, 6322.63106059413 ),
      ( 67, 4223.14664103175 ),
      ( 65, 2751.62438127874 ),
      ( 63, 1744.73561911554 ),
      ( 61, 1073.73154144172 ),
      ( 59, 639.393135886154 ),
      ( 57, 367.148527198847 ),
      ( 55, 202.485396670838 ),
      ( 53, 106.767754344084 ),
      ( 51, 53.5409690203203 ),
      };

      // TestData contains:
		   // 0. Temperature (Kelvin)
		   // 1. Pressure (Pa
		   _testDataMeltingLine = new (double temperature, double pressure)[]
      {
      ( 83.8136063146419, 100000 ),
      ( 83.8282820749271, 158489.319246111 ),
      ( 83.8515381998658, 251188.643150958 ),
      ( 83.8883882309593, 398107.170553497 ),
      ( 83.9467704125988, 630957.344480193 ),
      ( 84.0392468321704, 1000000 ),
      ( 84.1856791025845, 1584893.19246111 ),
      ( 84.4174262094386, 2511886.43150958 ),
      ( 84.7838920539136, 3981071.70553497 ),
      ( 85.3626449960819, 6309573.44480193 ),
      ( 86.2748382300382, 10000000 ),
      ( 87.7082050313997, 15848931.9246111 ),
      ( 89.9502616845893, 25118864.3150958 ),
      ( 93.4340877972741, 39810717.0553497 ),
      ( 98.7977193537506, 63095734.4480193 ),
      ( 106.956186714574, 100000000 ),
      ( 119.18529206156, 158489319.246111 ),
      ( 137.223131289863, 251188643.150958 ),
      };
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
    public override void SaturatedData_Test()
    {
      base.SaturatedData_Test();
    }

    [Test]
    public override void SublimationLineData_Test()
    {
      base.SublimationLineData_Test();
    }

    [Test]
    public override void MeltingLineData_Test()
    {
      base.MeltingLineData_Test();
    }

    [Test]
    public override void EquationOfState_Test()
    {
      base.EquationOfState_Test();
    }

    [Test]
    public void ConstantsAndCharacteristicPoints_Test()
    {

    Assert.AreEqual(0.039948,_fluid.MolecularWeight, "MolecularWeight");
    Assert.IsTrue(IsInToleranceLevel(83.8058, _fluid.TriplePointTemperature, 1E-4, 0.01),"TriplePointTemperature");
    Assert.IsTrue(IsInToleranceLevel(68891, _fluid.TriplePointPressure, 1E-4, 0),"TriplePointPressure");
    Assert.IsTrue(IsInToleranceLevel(35465.2741564102, _fluid.TriplePointSaturatedLiquidMoleDensity, 1E-4, 0),"TriplePointSaturatedLiquidMoleDensity");
    Assert.IsTrue(IsInToleranceLevel(101.496365183612, _fluid.TriplePointSaturatedVaporMoleDensity, 1E-4, 0),"TriplePointSaturatedVaporMoleDensity");
    Assert.IsTrue(IsInToleranceLevel(150.687, _fluid.CriticalPointTemperature, 1E-4, 0.01),"CriticalPointTemperature");
    Assert.IsTrue(IsInToleranceLevel(4863000.54178695, _fluid.CriticalPointPressure, 1E-2, 0),"CriticalPointPressure");
    Assert.IsTrue(IsInToleranceLevel(13407.42965, _fluid.CriticalPointMoleDensity, 1E-2, 0),"CriticalPointLiquidMoleDensity");
    Assert.IsTrue(IsInToleranceLevel(87.3021362362265, _fluid.NormalBoilingPointTemperature.Value, 1E-4, 0.01),"NormalBoilingPointTemperature");
    Assert.IsTrue(_fluid.NormalSublimationPointTemperature is null,"NormalSublimationPointTemperature");
    }
  }
}
