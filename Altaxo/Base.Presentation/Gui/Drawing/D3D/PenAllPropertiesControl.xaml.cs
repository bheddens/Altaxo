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

#endregion Copyright

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Altaxo.Drawing.D3D;
using Altaxo.Graph.Graph3D;
using Altaxo.Gui.Drawing.D3D;

namespace Altaxo.Gui.Drawing.D3D
{
  /// <summary>
  /// Interaction logic for PenAllPropertiesControl.xaml
  /// </summary>
  public partial class PenAllPropertiesControl : UserControl, IPenAllPropertiesView
  {
    private PenControlsGlue _glue;

    public PenAllPropertiesControl()
    {
      InitializeComponent();

      _glue = new PenControlsGlue(true)
      {
        CbBrush = _cbBrush,
        CbLineThickness1 = _cbThickness1,
        CbLineThickness2 = _cbThickness2,
        CbCrossSection = _guiCrossSection,

        CbLineStartCap = _cbLineStartCap,
        CbLineStartCapAbsSize = _cbLineStartCapSize,
        CbLineStartCapRelSize = _edLineStartCapRelSize,

        CbLineEndCap = _cbLineEndCap,
        CbLineEndCapAbsSize = _cbLineEndCapSize,
        CbLineEndCapRelSize = _edLineEndCapRelSize,

        CbDashPattern = _cbDashStyle,

        CbDashStartCap = _cbDashStartCap,
        CbDashStartCapAbsSize = _cbDashStartCapSize,
        CbDashStartCapRelSize = _edDashStartCapRelSize,

        CbDashEndCap = _cbDashEndCap,
        CbDashEndCapAbsSize = _cbDashEndCapSize,
        CbDashEndCapRelSize = _edDashEndCapRelSize,

        CbLineJoin = _cbLineJoin,
        CbMiterLimit = _cbMiterLimit,

        PreviewPanel = _previewPanel
      };
    }

    public PenX3D Pen
    {
      get
      {
        return _glue.Pen;
      }
      set
      {
        _glue.Pen = value;
      }
    }

    public bool ShowPlotColorsOnly
    {
      set { _glue.ShowPlotColorsOnly = value; }
    }
  }
}
