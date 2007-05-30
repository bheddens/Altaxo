#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2007 Dr. Dirk Lellinger
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
#endregion

using System;
using Altaxo.Calc;
using Altaxo.Calc.Probability;
using NUnit.Framework;


namespace AltaxoTest.Calc.Probability
{
  [TestFixture]
  public class TestStableDistribution
	{
    /* Mathematica code to create the table following (use the stable packet from the mathematica library web site)
    
     << StableDistribution`SMath`
    
    flarguments = Flatten[ Table[
      {
        {1/2, 7/8, 1, 9/8, 3/2, 2}[[i]],
        {-1, -1/2, 0, 1/2, 1}[[j]],
        {-10, -4, -1/2, 0, 1/2, 4, 10}[[k]]
        }, {i, 1, 6}, {j, 1, 5}, {k, 1, 7}], 2]
    
    For[i = 1, i ? Length[flarguments], i += 1,
  alpha = flarguments[[i]][[1]];
  beta = flarguments[[i]][[2]];
  xx = flarguments[[i]][[3]];
  yy = N[SPDF[xx, {
   alpha, beta}, 0, GaussPoints -> 30, MaxRecursion -> 10, WorkingPrecision ->
     64], 18];
  If[NumericQ[yy],
    Print[alpha, " ", beta, " ", xx, " ", yy];
    strm = OpenAppend["C:\\TEMP\\output.txt", CharacterEncoding -> "
          ASCII", FormatType -> OutputForm];
    Write[strm, 
        "new double[]{", FortranForm[alpha], ",", FortranForm[beta], ",", 
  FortranForm[xx], ",", FortranForm[yy], "},"];
     Close[strm]
    ];
  ]
    */

    double[][] _pdfTest1 = new double[][]{
new double[]{0.5,-1,-10,0.010449135953590293},
new double[]{0.5,-1,-4,0.032286845174307237},
new double[]{0.5,-1,-0.5,0.155599554757086521},
new double[]{0.5,-1,0,0.24197072451914335},
new double[]{0.5,-1,0.5,0.415107497420594703},
new double[]{0.5,-1,4,0.0e-64},
new double[]{0.5,-1,10,0.0e-65},
new double[]{0.5,-0.5,-10,0.0075881394617841676},
new double[]{0.5,-0.5,-4,0.0245663001715312596},
new double[]{0.5,-0.5,-0.5,0.159240297087939965},
new double[]{0.5,-0.5,0,0.311533168758699187},
new double[]{0.5,-0.5,0.5,0.305577490736439045},
new double[]{0.5,-0.5,4,0.00825895136238823702},
new double[]{0.5,-0.5,10,0.00233372277449640175},
new double[]{0.5,0,-10,0.00487225538372111616},
new double[]{0.5,0,-4,0.0165057384221262866},
new double[]{0.5,0,-0.5,0.170762401725206224},
new double[]{0.5,0,0,0.636619772367581343},
new double[]{0.5,0,0.5,0.170762401725206224},
new double[]{0.5,0,4,0.0165057384221262866},
new double[]{0.5,0,10,0.00487225538372111616},
new double[]{0.5,0.5,-10,0.00233372277449640175},
new double[]{0.5,0.5,-4,0.00825895136238823702},
new double[]{0.5,0.5,-0.5,0.305577490736439045},
new double[]{0.5,0.5,0,0.311533168758699187},
new double[]{0.5,0.5,0.5,0.159240297087939965},
new double[]{0.5,0.5,4,0.0245663001715312596},
new double[]{0.5,0.5,10,0.0075881394617841676},
new double[]{0.5,1,-10,0.0e-65},
new double[]{0.5,1,-4,0.0e-64},
new double[]{0.5,1,-0.5,0.415107497420594703},
new double[]{0.5,1,0,0.24197072451914335},
new double[]{0.5,1,0.5,0.155599554757086521},
new double[]{0.5,1,4,0.032286845174307237},
new double[]{0.5,1,10,0.010449135953590293},
new double[]{0.875,-1,-10,0.00859319050259130464},
new double[]{0.875,-1,-4,0.0387326900318963064},
new double[]{0.875,-1,-0.5,0.200970622845054967},
new double[]{0.875,-1,0,0.257507821327408685},
new double[]{0.875,-1,0.5,0.293063509101005356},
new double[]{0.875,-1,4,1.704436247487977e-8409},
new double[]{0.875,-1,10,0.0e-64},
new double[]{0.875,-0.5,-10,0.00604336008614330531},
new double[]{0.875,-0.5,-4,0.028960271499303109},
new double[]{0.875,-0.5,-0.5,0.21336200882206995},
new double[]{0.875,-0.5,0,0.296170740739014809},
new double[]{0.875,-0.5,0.5,0.309836819666517268},
new double[]{0.875,-0.5,4,0.00933860640361163996},
new double[]{0.875,-0.5,10,0.00174459320858150607},
new double[]{0.875,0,-10,0.00375882644917199933},
new double[]{0.875,0,-4,0.0190875070493639558},
new double[]{0.875,0,-0.5,0.245963617139043073},
new double[]{0.875,0,0,0.34029602763013595},
new double[]{0.875,0,0.5,0.245963617139043073},
new double[]{0.875,0,4,0.0190875070493639558},
new double[]{0.875,0,10,0.00375882644917199933},
new double[]{0.875,0.5,-10,0.00174459320858150607},
new double[]{0.875,0.5,-4,0.00933860640361163996},
new double[]{0.875,0.5,-0.5,0.309836819666517268},
new double[]{0.875,0.5,0,0.296170740739014809},
new double[]{0.875,0.5,0.5,0.21336200882206995},
new double[]{0.875,0.5,4,0.028960271499303109},
new double[]{0.875,0.5,10,0.00604336008614330531},
new double[]{0.875,1,-10,0.0e-64},
new double[]{0.875,1,-4,1.704436247487977e-8409},
new double[]{0.875,1,-0.5,0.293063509101005356},
new double[]{0.875,1,0,0.257507821327408685},
new double[]{0.875,1,0.5,0.200970622845054967},
new double[]{0.875,1,4,0.0387326900318963064},
new double[]{0.875,1,10,0.00859319050259130464},
new double[]{1,-1,-4,0.038364382040947077},
new double[]{1,-1,-0.5,0.212318467675064265},
new double[]{1,-1,0,0.262240126375351657},
new double[]{1,-1,0.5,0.282979296472337068},
new double[]{1,-1,4,2.40268429420551753e-54},
new double[]{1,-1,10,6.14207193080535992e-674917},
new double[]{1,-0.5,-4,0.0285478736642324839},
new double[]{1,-0.5,-0.5,0.225442218599286543},
new double[]{1,-0.5,0,0.292520470566076713},
new double[]{1,-0.5,0.5,0.292609581480539141},
new double[]{1,-0.5,4,0.00910970616999196668},
new double[]{1,-0.5,10,0.00145461336969288015},
new double[]{1,0,-10,0.00315158303152267992},
new double[]{1,0,-4,0.0187241109519876866},
new double[]{1,0,-0.5,0.254647908947032537},
new double[]{1,0,0,0.318309886183790672},
new double[]{1,0,0.5,0.254647908947032537},
new double[]{1,0,4,0.0187241109519876866},
new double[]{1,0,10,0.00315158303152267992},
new double[]{1,0.5,-10,0.00145461336969288015},
new double[]{1,0.5,-4,0.00910970616999196668},
new double[]{1,0.5,-0.5,0.292609581480539141},
new double[]{1,0.5,0,0.292520470566076713},
new double[]{1,0.5,0.5,0.225442218599286543},
new double[]{1,0.5,4,0.0285478736642324839},
new double[]{1,1,-10,6.14207193080535992e-674917},
new double[]{1,1,-4,2.40268429420551753e-54},
new double[]{1,1,-0.5,0.282979296472337068},
new double[]{1,1,0,0.262240126375351657},
new double[]{1,1,0.5,0.212318467675064265},
new double[]{1,1,4,0.038364382040947077},
new double[]{1.125,-1,-10,0.00594795968980815246},
new double[]{1.125,-1,-0.5,0.222394217418834845},
new double[]{1.125,-1,0,0.266587031169983183},
new double[]{1.125,-1,0.5,0.276735064777311314},
new double[]{1.125,-1,4,4.37746558963013643e-16},
new double[]{1.125,-1,10,8.09021799038346448e-1542},
new double[]{1.125,-0.5,-10,0.00413713556384187849},
new double[]{1.125,-0.5,-4,0.0274348398312656861},
new double[]{1.125,-0.5,-0.5,0.235222239213963157},
new double[]{1.125,-0.5,0,0.289563250722015948},
new double[]{1.125,-0.5,0.5,0.281914028906399689},
new double[]{1.125,-0.5,4,0.0086915303222026684},
new double[]{1.125,-0.5,10,0.00117258370220477812},
new double[]{1.125,0,-10,0.00254800947188242432},
new double[]{1.125,0,-4,0.0179324210975094243},
new double[]{1.125,0,-0.5,0.258708942735625721},
new double[]{1.125,0,0,0.304943370229598302},
new double[]{1.125,0,0.5,0.258708942735625721},
new double[]{1.125,0,4,0.0179324210975094243},
new double[]{1.125,0,10,0.00254800947188242432},
new double[]{1.125,0.5,-10,0.00117258370220477812},
new double[]{1.125,0.5,-4,0.0086915303222026684},
new double[]{1.125,0.5,-0.5,0.281914028906399689},
new double[]{1.125,0.5,0,0.289563250722015948},
new double[]{1.125,0.5,0.5,0.235222239213963157},
new double[]{1.125,0.5,4,0.0274348398312656861},
new double[]{1.125,0.5,10,0.00413713556384187849},
new double[]{1.125,1,-10,8.09021799038346448e-1542},
new double[]{1.125,1,-4,4.37746558963013643e-16},
new double[]{1.125,1,-0.5,0.276735064777311314},
new double[]{1.125,1,0,0.266587031169983183},
new double[]{1.125,1,0.5,0.222394217418834845},
new double[]{1.125,1,10,0.00594795968980815246},
new double[]{1.5,-1,-10,0.00241981613066309674},
new double[]{1.5,-1,-4,0.0279973178629260511},
new double[]{1.5,-1,-0.5,0.246515640532722451},
new double[]{1.5,-1,0,0.276859868856746781},
new double[]{1.5,-1,0.5,0.268368758744508534},
new double[]{1.5,-1,4,0.0000567935873875498302},
new double[]{1.5,-1,10,1.34096664947790338e-43},
new double[]{1.5,-0.5,-10,0.00169010120711345954},
new double[]{1.5,-0.5,-4,0.0207819141087301014},
new double[]{1.5,-0.5,-0.5,0.254112686602229452},
new double[]{1.5,-0.5,0,0.28428380098857753},
new double[]{1.5,-0.5,0.5,0.268046496554461533},
new double[]{1.5,-0.5,4,0.00673588721821525944},
new double[]{1.5,-0.5,10,0.000486574121093548287},
new double[]{1.5,0,-10,0.00104777602492944046},
new double[]{1.5,0,-4,0.0136729417918039395},
new double[]{1.5,0,-0.5,0.262296840354090036},
new double[]{1.5,0,0,0.287352751452164445},
new double[]{1.5,0,0.5,0.262296840354090036},
new double[]{1.5,0,4,0.0136729417918039395},
new double[]{1.5,0,10,0.00104777602492944046},
new double[]{1.5,0.5,-10,0.000486574121093548287},
new double[]{1.5,0.5,-4,0.00673588721821525944},
new double[]{1.5,0.5,-0.5,0.268046496554461533},
new double[]{1.5,0.5,0,0.28428380098857753},
new double[]{1.5,0.5,0.5,0.254112686602229452},
new double[]{1.5,0.5,4,0.0207819141087301014},
new double[]{1.5,0.5,10,0.00169010120711345954},
new double[]{1.5,1,-10,1.34096664947790338e-43},
new double[]{1.5,1,-4,0.0000567935873875498302},
new double[]{1.5,1,-0.5,0.268368758744508534},
new double[]{1.5,1,0,0.276859868856746781},
new double[]{1.5,1,0.5,0.246515640532722451},
new double[]{1.5,1,4,0.0279973178629260511},
new double[]{1.5,1,10,0.00241981613066309674},
new double[]{2,-1,-10,3.91771663275433383e-12},
new double[]{2,-1,-4,0.00516674633852301346},
new double[]{2,-1,-0.5,0.265003532344028561},
new double[]{2,-1,0,0.282094791773878143},
new double[]{2,-1,0.5,0.265003532344028561},
new double[]{2,-1,4,0.00516674633852301346},
new double[]{2,-1,10,3.91771663275433383e-12},
new double[]{2,-0.5,-10,3.91771663275433383e-12},
new double[]{2,-0.5,-4,0.00516674633852301346},
new double[]{2,-0.5,-0.5,0.265003532344028561},
new double[]{2,-0.5,0,0.282094791773878143},
new double[]{2,-0.5,0.5,0.265003532344028561},
new double[]{2,-0.5,4,0.00516674633852301346},
new double[]{2,-0.5,10,3.91771663275433383e-12},
new double[]{2,0,-10,3.91771663275433383e-12},
new double[]{2,0,-4,0.00516674633852301346},
new double[]{2,0,-0.5,0.265003532344028561},
new double[]{2,0,0,0.282094791773878143},
new double[]{2,0,0.5,0.265003532344028561},
new double[]{2,0,4,0.00516674633852301346},
new double[]{2,0,10,3.91771663275433383e-12},
new double[]{2,0.5,-10,3.91771663275433383e-12},
new double[]{2,0.5,-4,0.00516674633852301346},
new double[]{2,0.5,-0.5,0.265003532344028561},
new double[]{2,0.5,0,0.282094791773878143},
new double[]{2,0.5,0.5,0.265003532344028561},
new double[]{2,0.5,4,0.00516674633852301346},
new double[]{2,0.5,10,3.91771663275433383e-12},
new double[]{2,1,-10,3.91771663275433383e-12},
new double[]{2,1,-4,0.00516674633852301346},
new double[]{2,1,-0.5,0.265003532344028561},
new double[]{2,1,0,0.282094791773878143},
new double[]{2,1,0.5,0.265003532344028561},
new double[]{2,1,4,0.00516674633852301346},
new double[]{2,1,10,3.91771663275433383e-12}
};


    [Test]
    public void PdfTest()
    {
      for (int i = 0; i < _pdfTest1.Length; i++)
      {
        double alpha = _pdfTest1[i][0];
        double beta = _pdfTest1[i][1];
        double x = _pdfTest1[i][2];
        double expectedy = _pdfTest1[i][3];
        double y = StableDistributionS0.PDF(x, alpha, beta);
        double maxdelta = Math.Abs(expectedy / 1E-7);
        string msg = string.Format("alpha={0}, beta={1}, x={2}, expected={3}, actual={4}", alpha, beta, x, expectedy, y);
        Assert.AreEqual(expectedy, y, maxdelta, msg);
      }
    }


  }
}
