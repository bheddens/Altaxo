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

namespace Altaxo.Science.Thermodynamics.Fluids
{

  /// <summary>
  /// State equations and constants of mixtures of Methane and CO2.
  /// </summary>
  /// <remarks>
  /// <para>References:</para>
  /// <para>The source code was created automatically using the mixture file 'methane-co2.mix' from the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// <para>Further references (extracted from the mixture file):</para>
  /// <para>Info: Kunz and Wagner (2007)</para>
  /// <para>Departure function (MXM): Kunz, O., Klimeck, R., Wagner, W., Jaeschke, M. The GERG-2004 Wide-Range Equation of State for Natural Gases and Other Mixtures. GERG Technical Monograph 15. Fortschr.-Ber. VDI, VDI-Verlag, D�sseldorf, 2007.</para>
  /// </remarks>
  [CASRegistryNumber("74-82-8")]
  [CASRegistryNumber("124-38-9")]
  public class Mixture_Methane_CO2 : BinaryMixtureDefinitionBase
  {

    /// <summary>Gets the (only) instance of this class.</summary>
    public static Mixture_Methane_CO2 Instance { get; } = new Mixture_Methane_CO2();

    #region Constants for the binary mixture of Methane and CO2

    /// <summary>Gets the CAS registry number of component 1 (Methane).</summary>
    public override string CASRegistryNumber1 { get; } = "74-82-8";

    /// <summary>Gets the CAS registry number of component 2 (CO2).</summary>
    public override string CASRegistryNumber2 { get; } = "124-38-9";

    #endregion Constants for the binary mixture of Methane and CO2

    private Mixture_Methane_CO2()
    {
      #region  Mixture parameter

      _beta_T = 1.02262449;
      _gamma_T = 0.975665369;
      _beta_v = 0.999518072;
      _gamma_v = 1.002806594;
      _F = 1;

      _departureCoefficients_Polynomial = new (double ai, double ti, double di)[]
       {
        (   -0.10859387354942,                  2.6,                    1),
        (   0.080228576727389,                 1.95,                    2),
        ( -0.0093303985115717,                    0,                    3),
       };

      _departureCoefficients_Special = new (double n, double t, double d, double eta, double epsilon, double beta, double gamma)[]
      {
        (   0.040989274005848,                 3.95,                    1,                   -1,                  0.5,                   -1,                  0.5),
        (   -0.24338019772494,                 7.95,                    2,                 -0.5,                  0.5,                   -2,                  0.5),
        (    0.23855347281124,                    8,                    3,                    0,                  0.5,                   -3,                  0.5),
      };
      #endregion

    }
  }
}
