#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2004 Dr. Dirk Lellinger
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
//    along with ctrl program; if not, write to the Free Software
//    Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
//
/////////////////////////////////////////////////////////////////////////////
#endregion

using Altaxo.Data;

namespace Altaxo.Worksheet.Commands
{
  /// <summary>
  /// PlotCommands contains methods for creating different plot types.
  /// </summary>
  public class PlotCommands
  {
    public static void PlotLine(GUI.WorksheetController dg, bool bLine, bool bScatter)
    {
      Altaxo.Graph.XYLineScatterPlotStyle templatePlotStyle = new Altaxo.Graph.XYLineScatterPlotStyle();
      Altaxo.Graph.PlotGroupStyle templatePlotGroupStyle = Altaxo.Graph.PlotGroupStyle.All;
      if(!bLine)
      {
        templatePlotStyle.XYPlotLineStyle.Connection = Altaxo.Graph.XYPlotLineStyles.ConnectionStyle.NoLine;
        templatePlotGroupStyle &= (Altaxo.Graph.PlotGroupStyle.All ^ Altaxo.Graph.PlotGroupStyle.Line);
      }
      if(!bScatter)
      {
        templatePlotStyle.LineSymbolGap = false;
        templatePlotStyle.XYPlotScatterStyle.Shape = Altaxo.Graph.XYPlotScatterStyles.Shape.NoSymbol;
        templatePlotGroupStyle &= (Altaxo.Graph.PlotGroupStyle.All ^ Altaxo.Graph.PlotGroupStyle.Symbol);
      }


      // first, create a plot association for every selected column in
      // the data grid

      int len = dg.SelectedDataColumns.Count;

      Graph.XYColumnPlotData[] pa = new Graph.XYColumnPlotData[len];

      int nNumberOfPlotData=0;
      for(int i=0;i<len;i++)
      {
        Altaxo.Data.DataColumn ycol = dg.DataTable[dg.SelectedDataColumns[i]];

        Altaxo.Data.DataColumn xcol = dg.DataTable.DataColumns.FindXColumnOf(ycol);
      
        if(null!=xcol)
          pa[i] = new Graph.XYColumnPlotData(xcol,ycol);
        else
          pa[i] = new Graph.XYColumnPlotData( new Altaxo.Data.IndexerColumn(), ycol);

        nNumberOfPlotData++;

        // if the next column is a label column, add it also
        if((i+1)<len && ColumnKind.Label==dg.DataTable.DataColumns.GetColumnKind(dg.SelectedDataColumns[i+1]))
        {
          pa[i].LabelColumn = dg.DataTable.DataColumns[dg.SelectedDataColumns[i+1]];
          i++;
        }


      }
      
      // now create a new Graph with this plot associations

      Altaxo.Graph.GUI.IGraphController gc = Current.ProjectService.CreateNewGraph();


      Altaxo.Graph.PlotGroup newPlotGroup = new Altaxo.Graph.PlotGroup(templatePlotGroupStyle);

      for(int i=0;i<nNumberOfPlotData;i++)
      {
        Altaxo.Graph.PlotItem pi = new Altaxo.Graph.XYColumnPlotItem(pa[i],(Altaxo.Graph.XYLineScatterPlotStyle)templatePlotStyle.Clone());
        newPlotGroup.Add(pi);
      }
      gc.Doc.Layers[0].PlotItems.Add(newPlotGroup);
    }





    /// <summary>
    /// Plots a density image of the selected columns.
    /// </summary>
    /// <param name="dg"></param>
    /// <param name="bLine"></param>
    /// <param name="bScatter"></param>
    public static void PlotDensityImage(GUI.WorksheetController dg, bool bLine, bool bScatter)
    {
      Altaxo.Graph.DensityImagePlotStyle plotStyle = new Altaxo.Graph.DensityImagePlotStyle();

      // if nothing is selected, assume that the whole table should be plotted
      int len = dg.SelectedDataColumns.Count;

      Graph.XYZEquidistantMeshColumnPlotData assoc = new Graph.XYZEquidistantMeshColumnPlotData(dg.Doc.DataColumns,len==0 ? null : dg.SelectedDataColumns);

      
      // now create a new Graph with this plot associations

      Altaxo.Graph.GUI.IGraphController gc = Current.ProjectService.CreateNewGraph();

      Altaxo.Graph.PlotItem pi = new Altaxo.Graph.DensityImagePlotItem(assoc,plotStyle);
      gc.Doc.Layers[0].PlotItems.Add(pi);

    }




  }
}
