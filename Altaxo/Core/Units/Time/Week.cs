﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2014 Dr. Dirk Lellinger
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

namespace Altaxo.Units.Time
{
  [UnitDescription("Time", 0, 0, 1, 0, 0, 0, 0)]
  public class Week : UnitBase, IUnit
  {
    public const double OneWeekInSeconds = 7 * 24 * 3600;

    private static readonly Week _instance = new Week();

    public static Week Instance { get { return _instance; } }

    protected Week()
    {
    }

    public string Name
    {
      get { return "Week"; }
    }

    public string ShortCut
    {
      get { return "week"; }
    }

    public double ToSIUnit(double x)
    {
      return x * OneWeekInSeconds;
    }

    public double FromSIUnit(double x)
    {
      return x / OneWeekInSeconds;
    }

    public ISIPrefixList Prefixes
    {
      get { return SIPrefix.ListWithNonePrefixOnly; }
    }

    public SIUnit SIUnit
    {
      get { return Second.Instance; }
    }
  }
}
