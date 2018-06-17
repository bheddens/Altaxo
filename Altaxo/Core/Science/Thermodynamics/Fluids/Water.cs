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
	/// State equations and constants of pure water.
	/// Reference:
	/// W. Wagner and A.Pruß
	/// The IAPWS Formulation 1995 for the Thermodynamic Properties	of Ordinary Water Substance for General and Scientific Use,
	/// J. Phys. Chem. Ref. Data, Vol. 31, No. 2, 2002
	/// </summary>
	public class Water : HelmholtzEquationOfStateOfPureFluidsByWagnerEtAl
	{
		/// <summary>
		/// Gets the (only) instance of this class.
		/// </summary>
		public static Water Instance { get; } = new Water();

		#region Constants for water

		/// <summary>
		/// The Universal Gas Constant R at the time the model was developed.
		/// </summary>
		public override double WorkingUniversalGasConstant => 8.314371357587;

		/// <summary>
		/// Gets the molecular weight in kg/m³.
		/// </summary>
		public override double MolecularWeight { get; } = 18.015268E-3; // kg/mol

		/// <summary>Gets the triple point temperature.</summary>
		public override double TriplePointTemperature { get; } = 273.16;

		/// <summary>Gets the triple point pressure.</summary>
		public override double TriplePointPressure { get; } = 611.657;

		/// <summary>Gets the saturated liquid density in kg/m³ at the triple point.</summary>
		public override double TriplePointSaturatedLiquidMassDensity { get; } = 999.793;

		/// <summary>Gets the saturated vapor density in kg/m³ at the triple point.</summary>
		public override double TriplePointSaturatedVaporMassDensity { get; } = 0.00485458;

		/// <summary>Gets the temperature at the critical point in K.</summary>
		public override double CriticalPointTemperature { get; } = 647.096;

		/// <summary>Gets the pressure at the critical point.</summary>
		public override double CriticalPointPressure { get; } = 22.064E6;

		/// <summary>Gets the mole density at the critical point in mol/m³.</summary>
		public override double CriticalPointMoleDensity { get; } = 17.8737279956E3;

		#endregion Constants for water

		private Water()
		{
			#region Ideal part of dimensionless Helmholtz energy and derivatives

			_alpha0_n_const = -8.32044648376782;
			_alpha0_n_tau = 6.68321052759772;
			_alpha0_n_lntau = 3.00632;

			// Page 429 Table 6.1 (n_i there is ai0 here)

			_alpha0_Exp = new(double ni, double thetai)[]
					{
(0.12436000e-01,    833.00),
(0.97315000e+00,   2289.0 ),
(0.12795000e+01,   5009.00),
(0.96956000e+00,   5982.0),
(0.24873000e+00,  17800.0),
					};

			RecaleAlpha0ExpThetaWithCriticalTemperature();

			#endregion Ideal part of dimensionless Helmholtz energy and derivatives

			#region Parameter from Table 6.2, page 430

			#region Index 1..7 of Table 6.2, page 430

			_pr1 = new(double ni, double ti, int di)[]
			{
( 0.12533547935523e-1,   -0.5 ,    1),
( 0.78957634722828e+1,    0.875,   1),
(-0.87803203303561e+1,    1.0,     1),
( 0.31802509345418,       0.5,     2),
(-0.26145533859358,       0.75,    2),
(-0.78199751687981e-2,    0.375,   3),
( 0.88089493102134e-2,    1.0,     4),
 			};

			#endregion Index 1..7 of Table 6.2, page 430

			#region Index 8..34 of Table 6.2, page 430

			_pr2 = new(double ni, double ti, int di, int li)[]
{
(-0.66856572307965    ,   4,     1,   1),
( 0.20433810950965    ,   6,     1,   1),
(-0.66212605039687e-4 ,  12,     1,   1),
(-0.19232721156002    ,   1,     2,   1),
(-0.25709043003438    ,   5,     2,   1),
( 0.16074868486251    ,   4,     3,   1),
(-0.40092828925807e-1 ,   2,     4,   1),
( 0.39343422603254e-6 ,  13,     4,   1),
(-0.75941377088144e-5 ,   9,     5,   1),
( 0.56250979351888e-3 ,   3,     7,   1),
(-0.15608652257135e-4 ,   4,     9,   1),
( 0.11537996422951e-8 ,  11,    10,   1),
( 0.36582165144204e-6 ,   4,    11,   1),
(-0.13251180074668e-11,  13,    13,   1),
(-0.62639586912454e-9 ,   1,    15,   1),
(-0.10793600908932    ,   7,     1,   2),
( 0.17611491008752e-1 ,   1,     2,   2),
( 0.22132295167546    ,   9,     2,   2),
(-0.40247669763528    ,  10,     2,   2),
( 0.58083399985759    ,  10,     3,   2),
( 0.49969146990806e-2 ,   3,     4,   2),
(-0.31358700712549e-1 ,   7,     4,   2),
(-0.74315929710341    ,  10,     4,   2),
( 0.47807329915480    ,  10,     5,   2),
( 0.20527940895948e-1 ,   6,     6,   2),
(-0.13636435110343    ,  10,     6,   2),
( 0.14180634400617e-1 ,  10,     7,   2),
( 0.83326504880713e-2 ,   1,     9,   2),
(-0.29052336009585e-1 ,   2,     9,   2),
( 0.38615085574206e-1 ,   3,     9,   2),
(-0.20393486513704e-1 ,   4,     9,   2),
(-0.16554050063734e-2 ,   8,     9,   2),
( 0.19955571979541e-2 ,   6,    10,   2),
( 0.15870308324157e-3 ,   9,    10,   2),
(-0.16388568342530e-4 ,   8,    12,   2),
( 0.43613615723811e-1 ,  16,     3,   3),
( 0.34994005463765e-1 ,  22,     4,   3),
(-0.76788197844621e-1 ,  23,     4,   3),
( 0.22446277332006e-1 ,  23,     5,   3),
(-0.62689710414685e-4 ,  10,    14,   4),
(-0.55711118565645e-9 ,  50,     3,   6),
(-0.19905718354408    ,  44,     6,   6),
( 0.31777497330738    ,  46,     6,   6),
(-0.11841182425981    ,  50,     6,   6),
};

			#endregion Index 8..34 of Table 6.2, page 430

			#region Index 52..54 of Table 6.2, page 430

			_pr3 = new(double ni, double ti, int di, int aux1, int aux2, double alpha, double beta, double gamma, double epsilon)[]
	{
(-0.31306260323435d+2,    0.0,     3,   2, 2,    -20,  -150,  1.21,  1),
( 0.31546140237781d+2,    1.0,     3,   2, 2,    -20,  -150,  1.21,  1),
(-0.25213154341695d+4,    4.0,     3,   2, 2,    -20,  -250,  1.25,  1),
};

			#endregion Index 52..54 of Table 6.2, page 430

			#region Index 55..56 of Table 6.2, page 340

			_pr4 = new(double ni, double ti, int di, int aux1, int aux2, double b, double beta, double A, double C, double D, double B, double a)[]
					{
(-0.14874640856724,       0.0,     1,   2, 2,    0.85,   0.3,   0.32,  28,  700, 0.2,  3.5),
( 0.31806110878444,       0.0,     1,   2, 2,    0.95,   0.3,   0.32,  32,  800, 0.2,  3.5),
					};

			#endregion Index 55..56 of Table 6.2, page 340

			#endregion Parameter from Table 6.2, page 430
		}

		#region Thermodynamic properties by empirical power laws

		/// <summary>
		/// Get the melting pressure at a given temperature.
		/// </summary>
		/// <param name="temperature_Kelvin">The temperature in Kelvin.</param>
		/// <returns>The melting pressure in Pa.</returns>
		public double MeltingPressureAtTemperature(double temperature_Kelvin)
		{
			double Tr;
			double? pr1 = null, pr3 = null, pr5 = null, pr6 = null, pr7 = null;
			if (251.165 <= temperature_Kelvin && temperature_Kelvin <= 273.16) // Ice I
			{
				Tr = temperature_Kelvin / TriplePointTemperature;
				pr1 = 1 - 0.626E6 * (1 - Pow(Tr, -3)) + 0.197135E6 * (1 - Math.Pow(Tr, 21.2));
				pr1 *= TriplePointPressure;
			}

			if (251.165 <= temperature_Kelvin && temperature_Kelvin <= 256.164) // Ice III
			{
				Tr = temperature_Kelvin / 251.165;
				pr3 = 1 - 0.2952521 * (1 - Pow(Tr, 60));
				pr3 *= 209.9E6;
			}

			if (256.164 <= temperature_Kelvin && temperature_Kelvin <= 273.31) // Ice V
			{
				Tr = temperature_Kelvin / 256.164;
				pr5 = 1 - 1.18721 * (1 - Pow(Tr, 8));
				pr5 *= 350.1E6;
			}

			if (273.31 <= temperature_Kelvin && temperature_Kelvin <= 355) // Ice VI
			{
				Tr = temperature_Kelvin / 273.31;
				pr6 = 1 - 1.07476 * (1 - Math.Pow(Tr, 4.6));
				pr6 *= 632.4E6;
			}

			if (355 <= temperature_Kelvin && temperature_Kelvin <= 715) // Ice VII
			{
				Tr = temperature_Kelvin / 355;
				pr5 = 1.73683 * (1 - 1 / Tr) - 0.0544606 * (1 - Pow(Tr, 5)) + 0.806106E-7 * (1 - Pow(Tr, 22));
				pr5 *= 2216E6;
			}

			return pr1 ?? pr3 ?? pr5 ?? pr6 ?? pr7 ?? double.NaN;
		}

		/// <summary>
		/// Get the sublimation pressure at a given temperature.
		/// </summary>
		/// <param name="temperature_Kelvin">The temperature in Kelvin.</param>
		/// <returns>The sublimation pressure in Pa.</returns>
		public double SublimationPressureAtTemperature(double temperature_Kelvin)
		{
			var Tr = temperature_Kelvin / TriplePointTemperature;
			var ln_pr = -13.928169 * (1 - Math.Pow(Tr, -1.5)) + 34.7078238 * (1 - Math.Pow(Tr, -1.25));
			return Math.Exp(ln_pr) * TriplePointPressure;
		}

		/// <summary>
		/// Gets the vapor pressure and its derivative with respect to temperature (in Pa and Pa/K).
		/// </summary>
		/// <param name="temperature_Kelvin">The temperature in Kelvin.</param>
		/// <returns>Vapor pressure and its derivative with respect to temperature (in Pa and Pa/K)</returns>
		public override (double pressure, double pressureWrtTemperature) VaporPressureAndDerivativeWithRespectToTemperatureAtTemperature(double temperature_Kelvin)
		{
			if (!(TriplePointTemperature <= temperature_Kelvin && temperature_Kelvin <= CriticalPointTemperature))
				return (double.NaN, double.NaN);

			var Tr = 1 - temperature_Kelvin / CriticalPointTemperature;

			const double
				a1 = -7.85951783,
				a15 = 1.84408259,
				a3 = -11.7866497,
				a35 = 22.6807411,
				a4 = -15.9618719,
				a75 = 1.80122502;

			var ln_pr = (((a4 * Tr + a3) * Tr + 0) * Tr + a1) * Tr + Math.Sqrt(Tr) * (a15 * Tr + a35 * Pow(Tr, 3) + a75 * Pow(Tr, 7));
			ln_pr *= CriticalPointTemperature / temperature_Kelvin;
			double pressure = Math.Exp(ln_pr) * CriticalPointPressure;

			var deriv = (((4 * a4 * Tr + 3 * a3) * Tr + 0) * Tr + a1) + Math.Sqrt(Tr) * (7.5 * a75 * Pow(Tr, 6) + 3.5 * a35 * Pow(Tr, 2) + 1.5 * a15);

			return (pressure, (-pressure / temperature_Kelvin) * (ln_pr + deriv));
		}

		/// <summary>
		/// Get the saturated liquid density at a given temperature.
		/// </summary>
		/// <param name="temperature_Kelvin">The temperature in Kelvin.</param>
		/// <returns>The saturated liquid density in kg/m³.</returns>
		public double SaturatedLiquidDensityAtTemperature(double temperature_Kelvin)
		{
			const double a1 = 1.99274064, a2 = 1.09965342, a3 = 0.510839303, a4 = -1.75493479, a5 = -45.5170352, a6 = -6.74694450E5;
			const double t1 = 1 / 3.0, t2 = 2 / 3.0, t3 = 5 / 3.0, t4 = 16 / 3.0, t5 = 43 / 3.0, t6 = 110 / 3.0;

			if (!(temperature_Kelvin <= CriticalPointTemperature))
				return double.NaN;

			var Tr = 1 - temperature_Kelvin / CriticalPointTemperature;

			var ln_rhoR = a1 * Math.Pow(Tr, t1) + a2 * Math.Pow(Tr, t2) + a3 * Math.Pow(Tr, t3) + a4 * Math.Pow(Tr, t4) + a5 * Math.Pow(Tr, t5) + a6 * Math.Pow(Tr, t6);
			return Math.Exp(ln_rhoR) * CriticalPointMassDensity;
		}

		/// <summary>
		/// Get the saturated vapor density at a given temperature.
		/// </summary>
		/// <param name="temperature_Kelvin">The temperature in Kelvin.</param>
		/// <returns>The saturated liquid density in kg/m³.</returns>
		public double SaturatedVaporDensityAtTemperature(double temperature_Kelvin)
		{
			const double a1 = -2.03150240, a2 = -2.68302940, a3 = -5.38626492, a4 = -17.299, a5 = -44.7586581, a6 = -63.9201063;
			const double t1 = 2 / 6.0,
										t2 = 4 / 6.0,
										t3 = 8 / 6.0,
										t4 = 18 / 6.0,
										t5 = 37 / 6.0,
										t6 = 71 / 6.0;

			if (!(temperature_Kelvin <= CriticalPointTemperature))
				return double.NaN;

			var Tr = 1 - temperature_Kelvin / CriticalPointTemperature;
			var ln_rhoR = a1 * Math.Pow(Tr, t1) + a2 * Math.Pow(Tr, t2) + a3 * Math.Pow(Tr, t3) + a4 * Math.Pow(Tr, t4) + a5 * Math.Pow(Tr, t5) + a6 * Math.Pow(Tr, t6);
			return Math.Exp(ln_rhoR) * CriticalPointMassDensity;
		}

		#endregion Thermodynamic properties by empirical power laws
	}
}
