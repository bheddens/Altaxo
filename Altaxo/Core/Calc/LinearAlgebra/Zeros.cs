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

namespace Altaxo.Calc.LinearAlgebra
{
  /// <summary>
  /// Designates the mode for enumeration and mapping of matrix elements.
  /// </summary>
  public enum Zeros
  {
    /// <summary>
    /// Allow skipping zero entries, without enforcing it. When enumerating or mapping sparse or banded matrices, this can speed up operations.
    /// </summary>
    AllowSkip,

    /// <summary>
    /// Force applying the operation to all fields even if they are zero.
    /// </summary>
    Include,

    /// <summary>
    /// Force applying the operations to all fields in the diagonal even if they are zero, additionally to all non-zero fields.
    /// </summary>
    AllowSkipButIncludeDiagonal
  }
}
