﻿#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2011 Dr. Dirk Lellinger
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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altaxo.Science
{
	public enum PhysicalDimension
	{
		DimensionLess,
		Length,
		Mass,
		Time,
		ElectricCurrent,
		Temperature,
		AmountOfSubstance,
		LuminousIntensity,

		// derived units
		Area,
		Volume,
		Velocity,
		Acceleration,
		WaveNumber,
		SpecificVolume,
		CurrentDensity,
		MagneticFieldStrength,
	}

	public abstract class SIUnit : IUnit,  IEquatable<SIUnit>, IEquatable<IUnit>
	{
		sbyte _metre;
		sbyte _kilogram;
		sbyte _second;
		sbyte _ampere;
		sbyte _kelvin;
		sbyte _mole;
		sbyte _candela;

		static Dictionary<SIUnit, string> _specialNames = new Dictionary<SIUnit, string>();


		public SIUnit(sbyte m, sbyte kg, sbyte s, sbyte A, sbyte K, sbyte mol, sbyte CD)
		{
			_metre = m;
			_kilogram = kg;
			_second = s;
			_ampere = A;
			_kelvin = K;
			_mole = mol;
			_candela = CD;
		}

		void Multiply(SIUnit b)
		{
			this._metre += b._metre;
			this._kilogram += b._kilogram;
			this._second += b._second;
			this._ampere += b._ampere;
			this._kelvin += b._kelvin;
			this._mole += b._mole;
			this._candela += b._candela;
		}

		void DivideBy(SIUnit b)
		{
			this._metre -= b._metre;
			this._kilogram -= b._kilogram;
			this._second -= b._second;
			this._ampere -= b._ampere;
			this._kelvin -= b._kelvin;
			this._mole -= b._mole;
			this._candela -= b._candela;
		}

		void Invert()
		{
			this._metre = (sbyte)-this._metre;
			this._kilogram = (sbyte)-this._kilogram;
			this._second = (sbyte)-this._second;
			this._ampere = (sbyte)-this._ampere;
			this._kelvin = (sbyte)-this._kelvin;
			this._mole = (sbyte)-this._mole;
			this._candela = (sbyte)-this._candela;
		}

		public bool Equals(SIUnit b)
		{
			return null == b ? false :
			this._metre == b._metre &&
			this._kilogram == b._kilogram &&
			this._second == b._second &&
			this._ampere == b._ampere &&
			this._kelvin == b._kelvin &&
			this._mole == b._mole &&
			this._candela == b._candela;
		}

		public bool Equals(IUnit obj)
		{
			SIUnit b = obj as SIUnit;
			return null == b ? false : Equals(b);
		}

		public override bool Equals(object obj)
		{
			SIUnit b = obj as SIUnit;
			return null == b ? false : Equals(b);
		}


		public override int GetHashCode()
		{
			return
				_metre << 24 +
				_kilogram << 20 +
				_second << 16 +
				_ampere << 12 +
				_kelvin << 8 +
				_mole << 4 +
				_candela;
		}

		public abstract string Name
		{
			get; 
		}

		public abstract string ShortCut
		{
			get; 
		}

		public double ToSIUnit(double x)
		{
			return x;
		}

		public double FromSIUnit(double x)
		{
			return x;
		}

		public abstract ISIPrefixList Prefixes
		{
			get;
		}

		SIUnit IUnit.SIUnit
		{
			get { return this; }
		}
	}
}
