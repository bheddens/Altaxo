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
  /// State equations and constants of mixtures of Propane and Decane.
  /// </summary>
  /// <remarks>
  /// <para>References:</para>
  /// <para>The source code was created automatically using the mixture file 'propane-decane.mix' from the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// <para>Further references (extracted from the mixture file):</para>
  /// <para>Info: Kunz and Wagner (2012)</para>
  /// <para>Departure function (MXM): Kunz, O., Klimeck, R., Wagner, W., Jaeschke, M. The GERG-2004 Wide-Range Equation of State for Natural Gases and Other Mixtures. GERG Technical Monograph 15. Fortschr.-Ber. VDI, VDI-Verlag, D�sseldorf, 2007.</para>
  /// </remarks>
  [CASRegistryNumber("74-98-6")]
  [CASRegistryNumber("124-18-5")]
  public class Mixture_Propane_Decane : BinaryMixtureDefinitionBase
  {

    /// <summary>Gets the (only) instance of this class.</summary>
    public static Mixture_Propane_Decane Instance { get; } = new Mixture_Propane_Decane();

    #region Constants for the binary mixture of Propane and Decane

    /// <summary>Gets the CAS registry number of component 1 (Propane).</summary>
    public override string CASRegistryNumber1 { get; } = "74-98-6";

    /// <summary>Gets the CAS registry number of component 2 (Decane).</summary>
    public override string CASRegistryNumber2 { get; } = "124-18-5";

    #endregion Constants for the binary mixture of Propane and Decane

    private Mixture_Propane_Decane()
    {
      #region  Mixture parameter

      _beta_T = 0.985331233;
      _gamma_T = 1.140905252;
      _beta_v = 0.984104227;
      _gamma_v = 1.053040574;
      _F = 0;
      #endregion

    }
  }
}
