﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2015 Dr. Dirk Lellinger
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

namespace Altaxo.Graph.Graph3D
{
	using Geometry;

	public static class GraphDocumentBuilder
	{
		/// <summary>
		/// Creates the new standard graph with an XYZ plot layer.
		/// </summary>
		/// <param name="folderName">Name of the folder.</param>
		/// <param name="context">The context.</param>
		/// <returns></returns>
		public static GraphDocument CreateNewStandardGraphWithXYZPlotLayer(string folderName, Main.Properties.IReadOnlyPropertyBag context)
		{
			if (null == context)
			{
				if (null != folderName)
					Altaxo.PropertyExtensions.GetPropertyContextOfProjectFolder(folderName);
				else
					context = Altaxo.PropertyExtensions.GetPropertyContextOfProject();
			}

			var graph = new GraphDocument();

			var xyzlayer = new XYZPlotLayer(graph.RootLayer, new CS.G3DCartesicCoordinateSystem());

			graph.RootLayer.Layers.Add(xyzlayer);

			xyzlayer.CreateDefaultAxes(context);

			graph.ViewToRootLayerCenter(new VectorD3D(-1, -2, 1), new VectorD3D(0, 0, 1), 1);

			return graph;
		}
	}
}