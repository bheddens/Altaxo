#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2005 Dr. Dirk Lellinger
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Altaxo.Graph.G2D;
using Altaxo.Graph.G2D.Shapes;
using Altaxo.Serialization;
namespace Altaxo.Graph.GUI.GraphControllerMouseHandlers
{
 

  /// <summary>
  /// This class handles the mouse events in case the text tool is selected.
  /// </summary>
  public class TextToolMouseHandler : MouseStateHandler
  {
    GraphController _grac;

    public TextToolMouseHandler(GraphController grac)
    {
      _grac = grac;
      if(_grac.View!=null)
        _grac.View.SetPanelCursor(Cursors.Arrow);
    }
    /// <summary>
    /// Handles the click event by opening the text tool dialog.
    /// </summary>
    /// <param name="e">EventArgs.</param>
    /// <returns>The mouse state handler for handling the next mouse events.</returns>
    public override void OnClick(System.EventArgs e)
    {
      base.OnClick(e);

      // get the page coordinates (in Point (1/72") units)
      PointF printAreaCoord = _grac.PixelToPrintableAreaCoordinates(m_LastMouseDown);
      // with knowledge of the current active layer, calculate the layer coordinates from them
      PointF layerCoord = _grac.Layers[_grac.CurrentLayerNumber].GraphToLayerCoordinates(printAreaCoord);

      TextGraphics tgo = new TextGraphics();
      tgo.Position = layerCoord;

      // deselect the text tool
      _grac.CurrentGraphToolType = typeof(GraphControllerMouseHandlers.ObjectPointerMouseHandler);

      TextControlDialog dlg = new TextControlDialog(_grac.Layers[_grac.CurrentLayerNumber],tgo);
      if(DialogResult.OK==dlg.ShowDialog(_grac.View.Window))
      {
        // add the resulting textgraphobject to the layer
        if(!dlg.SimpleTextGraphics.Empty)
        {
          _grac.Layers[_grac.CurrentLayerNumber].GraphObjects.Add(dlg.SimpleTextGraphics);
          _grac.RefreshGraph();
        }
      }
      _grac.CurrentGraphToolType = typeof(ObjectPointerMouseHandler);
    }
  }
}
