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

using Altaxo.Collections;
using Altaxo.Graph;
using Altaxo.Graph.Gdi;
using Altaxo.Graph.Gdi.Plot;
using Altaxo.Graph.Gdi.Plot.Data;
using Altaxo.Graph.Gdi.Plot.Groups;
using Altaxo.Graph.Gdi.Plot.Styles;
using Altaxo.Graph.Gdi.Shapes;
using Altaxo.Graph.Plot.Data;
using Altaxo.Graph.Plot.Groups;
using Altaxo.Gui.Common;
using Altaxo.Gui.Graph;
using Altaxo.Main;
using Altaxo.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Input;

namespace Altaxo.Gui.Graph.Viewing
{
	using GraphControllerMouseHandlers;

	/// <summary>
	/// GraphController is our default implementation to control a graph view.
	/// </summary>
	[ExpectedTypeOfView(typeof(GraphViewWpf))]
	[UserControllerForObject(typeof(Altaxo.Graph.GraphViewLayout))]
	public class GraphControllerWpf : GraphController
	{
		#region Member variables

		// following default unit is point (1/72 inch)
		/// <summary>For the graph elements all the units are in points. One point is 1/72 inch.</summary>
		protected const double PointsPerInch = 72;

		/// <summary>Inches per point unit.</summary>
		protected const double InchPerPoint = 1 / 72.0;

		private static IList<IHitTestObject> _emptyReadOnlyList;

		/// <summary>Holds the view (the window where the graph is visualized).</summary>
		protected GraphViewWpf _viewWpf;

		/// <summary>
		/// Color for the area of the view, where there is no page.
		/// </summary>
		protected Color _nonPageAreaColor;

		/// <summary>
		/// Brush to fill the page ground. Since the printable area is filled with another brush, in effect
		/// this brush fills only the non printable margins of the page.
		/// </summary>
		protected BrushX _pageGroundBrush;

		/// <summary>
		/// Brush to fill the printable area of the graph.
		/// </summary>
		protected BrushX _graphAreaBrush;

		/// <summary>Screen resolution in dpi (in fact it is the factor that converts physical length on the screen (in inch) to the coordinate system used by Wpf (mouse coordinates, heights, widths, etc.).</summary>
		protected PointD2D _screenResolutionDpi;

		/// <summary>A instance of a mouse handler class that currently handles the mouse events..</summary>
		protected MouseStateHandler _mouseState;

		/// <summary>
		/// This holds a frozen image of the graph during the moving time
		/// </summary>
		protected Bitmap _cachedGraphImage;

		protected bool _isCachedGraphImageDirty;

		#endregion Member variables

		#region Constructors

		/// <summary>
		/// Set the member variables to default values. Intended only for use in constructors and deserialization code.
		/// </summary>
		protected virtual void SetMemberVariablesToDefault()
		{
			_nonPageAreaColor = Color.Gray;

			_pageGroundBrush = new BrushX(NamedColors.LightGray);

			_graphAreaBrush = new BrushX(NamedColors.Snow);

			_screenResolutionDpi = Current.Gui.ScreenResolutionDpi;

			// This holds a frozen image of the graph during the moving time
			_cachedGraphImage = null;
		}

		public GraphControllerWpf()
			: base()
		{
			SetMemberVariablesToDefault();
		}

		/// <summary>
		/// Creates a GraphController which shows the <see cref="GraphDocument"/> <paramref name="graphdoc"/>.
		/// </summary>
		/// <param name="graphdoc">The graph which holds the graphical elements.</param>
		public GraphControllerWpf(GraphDocument graphdoc)
			: base(graphdoc)
		{
			SetMemberVariablesToDefault();
		}

		static GraphControllerWpf()
		{
			_emptyReadOnlyList = new List<IHitTestObject>().AsReadOnly();

			// register here editor methods
			XYPlotLayerController.RegisterEditHandlers();
			XYPlotLayer.PlotItemEditorMethod = new DoubleClickHandler(EhEditPlotItem);
			TextGraphic.PlotItemEditorMethod = new DoubleClickHandler(EhEditPlotItem);
			TextGraphic.TextGraphicsEditorMethod = new DoubleClickHandler(EhEditTextGraphics);
		}

		#endregion Constructors

		#region Shortcuts to implementations by view or controller

		public override object ViewObject
		{
			get
			{
				return _viewWpf;
			}
			set
			{
				if (null != _viewWpf)
				{
					((IGraphView)_viewWpf).Controller = null;
				}

				_view = _viewWpf = value as GraphViewWpf;

				if (null != _viewWpf)
				{
					// A instance of a mouse handler class that currently handles the mouse events..</summary>
					_mouseState = new ObjectPointerMouseHandler(this);
					Initialize(false);
					((IGraphView)_viewWpf).Controller = this;
				}
			}
		}

		#endregion Shortcuts to implementations by view or controller

		#region Functions used by View

		public override GraphToolType CurrentGraphTool
		{
			get
			{
				return null == _mouseState ? GraphToolType.None : _mouseState.GraphToolType;
			}
			set
			{
				GraphToolType oldType = CurrentGraphTool;
				if (oldType != value)
				{
					switch (value)
					{
						case GraphToolType.None:
							_mouseState = null;
							break;

						case GraphToolType.ArrowLineDrawing:
							_mouseState = new GraphControllerMouseHandlers.ArrowLineDrawingMouseHandler(this);
							break;

						case GraphToolType.CurlyBraceDrawing:
							_mouseState = new GraphControllerMouseHandlers.CurlyBraceDrawingMouseHandler(this);
							break;

						case GraphToolType.EllipseDrawing:
							_mouseState = new GraphControllerMouseHandlers.EllipseDrawingMouseHandler(this);
							break;

						case GraphToolType.ObjectPointer:
							_mouseState = new GraphControllerMouseHandlers.ObjectPointerMouseHandler(this);
							break;

						case GraphToolType.ReadPlotItemData:
							_mouseState = new GraphControllerMouseHandlers.ReadPlotItemDataMouseHandler(this);
							break;

						case GraphToolType.ReadXYCoordinates:
							_mouseState = new GraphControllerMouseHandlers.ReadXYCoordinatesMouseHandler(this);
							break;

						case GraphToolType.RectangleDrawing:
							_mouseState = new GraphControllerMouseHandlers.RectangleDrawingMouseHandler(this);
							break;

						case GraphToolType.RegularPolygonDrawing:
							_mouseState = new GraphControllerMouseHandlers.RegularPolygonDrawingMouseHandler(this);
							break;

						case GraphToolType.SingleLineDrawing:
							_mouseState = new GraphControllerMouseHandlers.SingleLineDrawingMouseHandler(this);
							break;

						case GraphToolType.TextDrawing:
							_mouseState = new GraphControllerMouseHandlers.TextToolMouseHandler(this);
							break;

						case GraphToolType.ZoomAxes:
							_mouseState = new GraphControllerMouseHandlers.ZoomAxesMouseHandler(this);
							break;

						case GraphToolType.OpenCardinalSplineDrawing:
							_mouseState = new OpenCardinalSplineMouseHandler(this);
							break;

						case GraphToolType.ClosedCardinalSplineDrawing:
							_mouseState = new ClosedCardinalSplineMouseHandler(this);
							break;

						default:
							throw new NotImplementedException("Type not implemented: " + value.ToString());
					} // end switch

					if (null != _viewWpf)
						_viewWpf.FocusOnGraphPanel();

					EhView_CurrentGraphToolChanged();
				}
			}
		}

		public void SetGraphToolFromInternal(Altaxo.Gui.Graph.Viewing.GraphToolType value)
		{
			CurrentGraphTool = value;
		}

		public void SetPanelCursor(Cursor cursor)
		{
			if (null != _viewWpf)
				_viewWpf.SetPanelCursor(cursor);
		}

		#endregion Functions used by View

		#region Event handlers forwarded by view

		/// <summary>
		/// Called if a key is pressed in the view.
		/// </summary>
		/// <param name="e">Key event arguments.</param>
		/// <returns></returns>
		public bool EhView_ProcessCmdKey(KeyEventArgs e)
		{
			if (this._mouseState != null)
				return this._mouseState.ProcessCmdKey(e);
			else
				return false;
		}

		/// <summary>
		/// Called if the host window is about to be closed.
		/// </summary>
		/// <returns>True if the closing should be canceled, false otherwise.</returns>
		public bool HostWindowClosing()
		{
			if (!Current.ApplicationIsClosing)
			{
				if (false == Current.Gui.YesNoMessageBox("Do you really want to close this graph?", "Attention", false))
				{
					return true; // cancel the closing
				}
			}
			return false;
		}

		/// <summary>
		/// Handles the mouse up event onto the graph in the controller class.
		/// </summary>
		/// <param name="position">Mouse position.</param>
		/// <param name="e">MouseEventArgs.</param>
		public virtual void EhView_GraphPanelMouseUp(PointD2D position, MouseButtonEventArgs e)
		{
			_mouseState.OnMouseUp(position, e);
		}

		/// <summary>
		/// Handles the mouse down event onto the graph in the controller class.
		/// </summary>
		/// <param name="position">Mouse position.</param>
		/// <param name="e">MouseEventArgs.</param>
		public virtual void EhView_GraphPanelMouseDown(PointD2D position, MouseButtonEventArgs e)
		{
			_mouseState.OnMouseDown(position, e);
		}

		/// <summary>
		/// Handles the mouse move event onto the graph in the controller class.
		/// </summary>
		/// <param name="position">Mouse position.</param>
		/// <param name="e">MouseEventArgs.</param>
		public virtual void EhView_GraphPanelMouseMove(PointD2D position, MouseEventArgs e)
		{
			_mouseState.OnMouseMove(position, e);
		}

		/// <summary>
		/// Handles the click onto the graph event in the controller class.
		/// </summary>
		/// <param name="position">Mouse position.</param>
		/// <param name="e">EventArgs.</param>
		public virtual void EhView_GraphPanelMouseClick(PointD2D position, MouseButtonEventArgs e)
		{
			_mouseState.OnClick(position, e);
		}

		/// <summary>
		/// Handles the double click onto the graph event in the controller class.
		/// </summary>
		/// <param name="position">Mouse position.</param>
		/// <param name="e"></param>
		public virtual void EhView_GraphPanelMouseDoubleClick(PointD2D position, MouseButtonEventArgs e)
		{
			_mouseState.OnDoubleClick(position, e);
		}

		private DateTime _nextScrollZoomAcceptTime;

		/// <summary>Handles the mouse wheel event.</summary>
		/// <param name="position">Mouse position.</param>
		/// <param name="e">The <see cref="System.Windows.Input.MouseWheelEventArgs"/> instance containing the event data.</param>
		public virtual void EhView_GraphPanelMouseWheel(PointD2D position, MouseWheelEventArgs e)
		{
			if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
			{
				e.Handled = true;

				DateTime now = DateTime.UtcNow;
				if (now < _nextScrollZoomAcceptTime)
					return;

				var oldZoom = ZoomFactor;
				var newZoom = oldZoom;
				var autoZoomFactor = AutoZoomFactor;
				bool isAutoZoomNext = false;
				if (e.Delta > 0)
				{
					newZoom = oldZoom * 1.5;
					isAutoZoomNext = newZoom >= autoZoomFactor && oldZoom < autoZoomFactor;
				}
				else if (e.Delta < 0)
				{
					newZoom = oldZoom / 1.5;
					isAutoZoomNext = newZoom <= autoZoomFactor && oldZoom > autoZoomFactor;
				}
				// Do zoom action here
				if (isAutoZoomNext)
				{
					IsAutoZoomActive = true;
					_nextScrollZoomAcceptTime = now.AddMilliseconds(700);
				}
				else // manual zoom
				{
					var graphCoord = ConvertMouseToRootLayerCoordinates(position);
					ZoomAroundPivotPoint(newZoom, graphCoord);
				}
			}
		}

		#endregion Event handlers forwarded by view

		#region Event handlers set-up by this controller

		/// <summary>
		/// Handles the double click event onto a plot item.
		/// </summary>
		/// <param name="hit">Object containing information about the double clicked object.</param>
		/// <returns>True if the object should be deleted, false otherwise.</returns>
		protected static bool EhEditPlotItem(IHitTestObject hit)
		{
			XYPlotLayer actLayer = hit.ParentLayer as XYPlotLayer;
			IGPlotItem pa = (IGPlotItem)hit.HittedObject;

			// get plot group
			PlotGroupStyleCollection plotGroup = pa.ParentCollection.GroupStyles;

			Current.Gui.ShowDialog(new object[] { pa }, string.Format("#{0}: {1}", pa.Name, pa.ToString()), true);

			return false;
		}

		/// <summary>
		/// Handles the double click event onto a plot item.
		/// </summary>
		/// <param name="hit">Object containing information about the double clicked object.</param>
		/// <returns>True if the object should be deleted, false otherwise.</returns>
		protected static bool EhEditTextGraphics(IHitTestObject hit)
		{
			var layer = hit.ParentLayer;
			TextGraphic tg = (TextGraphic)hit.HittedObject;

			bool shouldDeleted = false;

			object tgoo = tg;
			if (Current.Gui.ShowDialog(ref tgoo, "Edit text", true))
			{
				tg = (TextGraphic)tgoo;
				if (tg == null || tg.Empty)
				{
					if (null != hit.Remove)
						shouldDeleted = hit.Remove(hit);
					else
						shouldDeleted = false;
				}
				else
				{
					if (tg.ParentObject is IChildChangedEventSink)
						((IChildChangedEventSink)tg.ParentObject).EhChildChanged(tg, EventArgs.Empty);
				}
			}

			return shouldDeleted;
		}

		#endregion Event handlers set-up by this controller

		#region Painting

		/// <summary>
		/// Marks the cached graph image as invalid, but causes no further action.
		/// Note: it is save to call this function from non-gui-threads
		/// </summary>
		public void InvalidateCachedGraphImage()
		{
			this._isCachedGraphImageDirty = true;
		}

		/// <summary>
		/// Marks the cached graph image as invalid, and triggers a repainting of the graph area with Gui render priority.
		/// Thus, in the next rendering cycle, the cached graph image is recreated and used to repaint the graph area, followed by the custom mouse handler drawing.
		/// </summary>
		public void InvalidateCachedGraphImageAndRepaintOffline()
		{
			this._isCachedGraphImageDirty = true;
			//RepaintGraphAreaForMouseHandler();

			if (_viewWpf != null)
				_viewWpf.TriggerRenderingOfGraphArea();
		}

		/// <summary>
		/// If the cached graph bitmap is valid, the graph area is repainted immediately using the cached bitmap and then the custom mouse handler drawing.
		/// If the cached graph bitmap is invalid, a repaint (and thus a recreation of the cached graph bitmap) is triggered, but only with Gui render priority.
		/// </summary>
		public void RepaintGraphAreaImmediatlyIfCachedBitmapValidElseOffline()
		{
			if (_viewWpf == null || Doc == null || _viewWpf.ViewportSizeInPoints == PointD2D.Empty)
				return;

			if (this._cachedGraphImage != null && !this._isCachedGraphImageDirty)
			{
				RepaintGraphAreaImmediately();
			}
			else
			{
				_viewWpf.TriggerRenderingOfGraphArea();
			}
		}

		/// <summary>
		/// Causes an repaint of the graph area. If the cached graph bitmap is valid, it is used for repainting, followed by the custom mouse handler drawing. If the cached graph bitmap is not valid,
		/// it is created first and used for painting, followed then by the custom mouse handler drawing.
		/// </summary>
		public void RepaintGraphAreaImmediately()
		{
			using (var grfx = this._viewWpf.BeginPaintingGraph())
			{
				this.DoPaint(grfx, false); // paint the cached graph image and the mouse handler drawings
				_viewWpf.EndPaintingGraph(); // inform the view, that the painting is finished
			}
		}

		/// <summary>
		/// If for printing, does an unbuffered paint of the graph document into the given graphics context. If not for printing, it depends on
		/// the state of the cached graph image: if not valid or dirty, the paint will be done into the cached graph image to make the cached graph image valid.
		/// Then the cached graph image is drawn into the given graphics context. At the end additional drawing is to be added by the current mouse handler to
		/// show for instance selection rectangles etc.
		/// </summary>
		/// <param name="g"></param>
		/// <param name="bForPrinting"></param>
		private void DoPaint(Graphics g, bool bForPrinting)
		{
			if (bForPrinting)
			{
				DoPaintUnbuffered(g, bForPrinting);
			}
			else // not for printing
			{
				// if neccessary, create a new bitmap for caching the graph image.
				if (_cachedGraphImage == null || _cachedGraphImage.Width != _viewWpf.GraphSize.Width || _cachedGraphImage.Height != _viewWpf.GraphSize.Height)
				{
					if (_cachedGraphImage != null)
					{
						_cachedGraphImage.Dispose();
						_cachedGraphImage = null;
					}

					// create a frozen bitmap of the graph
					// using(Graphics g = m_View.CreateGraphGraphics())
					try
					{
						_cachedGraphImage = new Bitmap(_viewWpf.GraphSize.Width, _viewWpf.GraphSize.Height, g);
					}
					catch (Exception ex)
					{
						throw new InvalidOperationException("Failed to create _cachedGraphImage");
					}

					_isCachedGraphImageDirty = true;
				}

				if (_cachedGraphImage == null)
				{
					DoPaintUnbuffered(g, bForPrinting);
				}
				else if (_isCachedGraphImageDirty)
				{
					using (Graphics gbmp = Graphics.FromImage(_cachedGraphImage))
					{
						DoPaintUnbuffered(gbmp, false);
						_isCachedGraphImageDirty = false;
					}

					g.DrawImageUnscaled(_cachedGraphImage, 0, 0, _viewWpf.GraphSize.Width, _viewWpf.GraphSize.Height);
					ScaleForPaint(g, bForPrinting);
				}
				else
				{
					g.DrawImageUnscaled(_cachedGraphImage, 0, 0, _viewWpf.GraphSize.Width, _viewWpf.GraphSize.Height);
					ScaleForPaint(g, bForPrinting); // to be in the same state as when drawing unbuffered
				}

				// special painting depending on current selected tool
				g.TranslateTransform((float)-PositionOfViewportsUpperLeftCornerInGraphCoordinates.X, (float)-PositionOfViewportsUpperLeftCornerInGraphCoordinates.Y);
				this._mouseState.AfterPaint(g);
			}
		}

		/// <summary>
		/// This functions scales the graphics context to be ready for painting.
		/// </summary>
		/// <param name="g">The graphics context.</param>
		/// <param name="bForPrinting">Indicates if the contexts is to be scaled
		/// for printing purposed (true) or for painting to the screen (false).</param>
		private void ScaleForPaint(Graphics g, bool bForPrinting)
		{
			// g.SmoothingMode = SmoothingMode.AntiAlias;
			// get the dpi settings of the graphics context,
			// for example; 96dpi on screen, 600dpi for the printer
			// used to adjust grid and margin sizing.

			g.PageUnit = GraphicsUnit.Point;

			if (bForPrinting)
			{
				g.PageScale = 1;
			}
			else
			{
				g.PageScale = (float)this.ZoomFactor;
			}
		}

		/// <summary>
		/// Central routine for painting the graph. The painting can either be on the screen (bForPrinting=false), or
		/// on a printer or file (bForPrinting=true).
		/// </summary>
		/// <param name="g">The graphics context painting to.</param>
		/// <param name="bForPrinting">If true, margins and background are not painted, as is usefull for printing.
		/// Also, if true, the scale is temporarely set to 1.</param>
		private void DoPaintUnbuffered(Graphics g, bool bForPrinting)
		{
			try
			{
				ScaleForPaint(g, bForPrinting);

				if (!bForPrinting)
				{
					g.Clear(this._nonPageAreaColor);
					// Fill the page with its own color
					//g.FillRectangle(_pageGroundBrush,_doc.PageBounds);
					//g.FillRectangle(m_PrintableAreaBrush,m_Graph.PrintableBounds);
					g.FillRectangle(_graphAreaBrush, (float)-PositionOfViewportsUpperLeftCornerInGraphCoordinates.X, (float)-PositionOfViewportsUpperLeftCornerInGraphCoordinates.Y, (float)Doc.RootLayer.Size.X, (float)Doc.RootLayer.Size.Y);
					// DrawMargins(g);
				}

				// Paint the graph now
				//g.TranslateTransform(m_Graph.PrintableBounds.X,m_Graph.PrintableBounds.Y); // translate the painting to the printable area
				g.TranslateTransform((float)-PositionOfViewportsUpperLeftCornerInGraphCoordinates.X, (float)-PositionOfViewportsUpperLeftCornerInGraphCoordinates.Y);
				Doc.DoPaint(g, bForPrinting);
			}
			catch (System.Exception ex)
			{
				g.PageUnit = GraphicsUnit.Point;
				g.PageScale = 1;

				g.DrawString(ex.ToString(),
					new System.Drawing.Font(FontFamily.GenericSansSerif, 8),
					System.Drawing.Brushes.Black,
					new RectangleF(0, 0, (float)Doc.RootLayer.Size.X, (float)Doc.RootLayer.Size.Y));
			}
		}

		#endregion Painting

		#region Editing selected objects

		public override IList<IHitTestObject> SelectedObjects
		{
			get
			{
				if (_mouseState is ObjectPointerMouseHandler)
					return ((ObjectPointerMouseHandler)_mouseState).SelectedObjects;
				else
					return _emptyReadOnlyList;
			}
		}

		/// <summary>
		/// Returns the number of selected objects into this graph.
		/// </summary>
		public int NumberOfSelectedObjects
		{
			get
			{
				if (_mouseState is ObjectPointerMouseHandler)
					return ((ObjectPointerMouseHandler)_mouseState).NumberOfSelectedObjects;
				else
					return 0;
			}
		}

		#endregion Editing selected objects

		#region Scaling and Positioning

		/// <summary>
		/// Factor for conversion of graph units (in points = 1/72 inch) to mouse coordinates.
		/// The resolution used for this is <see cref="_screenResolutionDpi"/>.
		/// </summary>
		public PointD2D FactorForGraphToMouseCoordinateConversion
		{
			get
			{
				return _screenResolutionDpi * (ZoomFactor * InchPerPoint);
			}
		}

		/// <summary>
		/// Converts from mouse coordinates to graph coordinates.
		/// </summary>
		/// <param name="mouseCoord">Mouse coordinates as returned by MouseEvents.</param>
		/// <returns>Position of the provided point in graph coordinates in points (1/72 inch).</returns>
		public PointD2D ConvertMouseToRootLayerCoordinates(PointD2D mouseCoord)
		{
			var offset = PositionOfViewportsUpperLeftCornerInGraphCoordinates;
			var factor = FactorForGraphToMouseCoordinateConversion;
			return new PointD2D(offset.X + mouseCoord.X / factor.X, offset.Y + mouseCoord.Y / factor.Y);
		}

		/// <summary>
		/// Converts graph coordinates to wpf coordinates.
		/// </summary>
		/// <param name="graphCoord">Graph coordinates.</param>
		/// <returns>Pixel coordinates as returned by MouseEvents</returns>
		public PointD2D ConvertGraphToMouseCoordinates(PointD2D graphCoord)
		{
			var offset = PositionOfViewportsUpperLeftCornerInGraphCoordinates;
			var factor = FactorForGraphToMouseCoordinateConversion;
			return new PointD2D((graphCoord.X - offset.X) * factor.X, (graphCoord.Y - offset.Y) * factor.Y);
		}

		#endregion Scaling and Positioning

		#region Finding objects at position

		/// <summary>
		/// Looks for a graph object at pixel position <paramref name="pixelPos"/> and returns true if one is found.
		/// </summary>
		/// <param name="pixelPos">The pixel coordinates (graph panel coordinates)</param>
		/// <param name="plotItemsOnly">If true, only the plot items where hit tested.</param>
		/// <param name="foundObject">Found object if there is one found, else null</param>
		/// <param name="foundInLayerNumber">The layer the found object belongs to, otherwise 0</param>
		/// <returns>True if a object was found at the pixel coordinates <paramref name="pixelPos"/>, else false.</returns>
		public bool FindGraphObjectAtPixelPosition(PointD2D pixelPos, bool plotItemsOnly, out IHitTestObject foundObject, out int[] foundInLayerNumber)
		{
			var mousePT = ConvertMouseToRootLayerCoordinates(pixelPos);
			var hitData = new HitTestPointData(mousePT, this.ZoomFactor);

			foundObject = RootLayer.HitTest(hitData, plotItemsOnly);
			if (null != foundObject)
			{
				foundInLayerNumber = foundObject.ParentLayer.IndexOf().ToArray();
				return true;
			}

			foundObject = null;
			foundInLayerNumber = null;
			return false;
		}

		#endregion Finding objects at position
	}
}