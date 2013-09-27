#region Copyright

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
using Altaxo.Graph.Gdi.Background;
using Altaxo.Graph.Scales;
using Altaxo.Graph.Scales.Boundaries;
using Altaxo.Graph.Scales.Ticks;
using Altaxo.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;

namespace Altaxo.Graph.Gdi
{
	using Axis;
	using Plot;
	using Shapes;

	/// <summary>
	/// XYPlotLayer represents a rectangular area on the graph, which holds plot curves, axes and graphical elements.
	/// </summary>
	public partial class XYPlotLayer
		:
		HostLayer,
		IPlotArea
	{
		#region Member variables

		protected G2DCoordinateSystem _coordinateSystem;

		private ScaleCollection _scales;

		protected GridPlaneCollection _gridPlanes;

		protected AxisStyleCollection _axisStyles;

		/// <summary>If true, the data are clipped to the frame.</summary>
		protected LayerDataClipping _dataClipping = LayerDataClipping.StrictToCS;

		protected PlotItemCollection _plotItems;

		/// <summary>Number of times this event is disables, or 0 if it is enabled.</summary>
		[NonSerialized]
		private int _plotAssociationXBoundariesChanged_EventSuspendCount;

		/// <summary>Number of times this event is disables, or 0 if it is enabled.</summary>
		[NonSerialized]
		private int _plotAssociationYBoundariesChanged_EventSuspendCount;

		/// <summary>
		/// Partial list of all <see cref="PlaceHolder"/> instances in <see cref="GraphObjects"/>.
		/// </summary>
		[NonSerialized]
		private IObservableList<PlaceHolder> _placeHolders;

		[NonSerialized]
		private IObservableList<PlotItemPlaceHolder> _plotItemPlaceHolders;

		#endregion Member variables

		#region Event definitions

		/// <summary>Fired when a scale instance of this layer has changed.</summary>
		[field: NonSerialized]
		public event Action<int, Scale, Scale> ScaleInstanceChanged;

		#endregion Event definitions

		#region Constructors

		#region Copying

		/// <summary>
		/// The copy constructor.
		/// </summary>
		/// <param name="from"></param>
		public XYPlotLayer(XYPlotLayer from)
		{
			_changeEventSuppressor = new Altaxo.Main.EventSuppressor(EhChangeEventResumed);
			CopyFrom(from, GraphCopyOptions.All);
		}

		protected override void InternalCopyFrom(HostLayer obj, GraphCopyOptions options)
		{
			base.InternalCopyFrom(obj, options.WithClearedFlag(GraphCopyOptions.CopyLayerGraphItems)); // in the base class GraphItems should not be copied, since this is handled in this class

			var from = obj as XYPlotLayer;
			if (null == from)
				return;

			// XYPlotLayer style
			//this.LayerBackground = from._layerBackground == null ? null : (LayerBackground)from._layerBackground.Clone();

			// size, position, rotation and scale
			if (0 != (options & GraphCopyOptions.CopyLayerSizePosition))
			{
				this.Location = (IItemLocation)from._location.Clone();
				this._cachedLayerSize = from._cachedLayerSize;
				this._cachedLayerPosition = from._cachedLayerPosition;
				this._cachedParentLayerSize = from._cachedParentLayerSize;
			}

			if (0 != (options & GraphCopyOptions.CopyLayerScales))
			{
				this.CoordinateSystem = (G2DCoordinateSystem)from.CoordinateSystem.Clone();

				this.Scales = (ScaleCollection)from._scales.Clone();
				this._dataClipping = from._dataClipping;
			}

			// Coordinate Systems size must be updated in any case
			this.CoordinateSystem.UpdateAreaSize(this._cachedLayerSize);

			if (0 != (options & GraphCopyOptions.CopyLayerGrid))
			{
				this.GridPlanes = from._gridPlanes.Clone();
			}

			// Styles

			if (0 != (options & GraphCopyOptions.CopyLayerAxes))
			{
				this.AxisStyles = (AxisStyleCollection)from._axisStyles.Clone();
			}

			var copyLegends = 0 != (options & GraphCopyOptions.CopyLayerLegends);
			var copyGraphItems = 0 != (options & GraphCopyOptions.CopyLayerGraphItems);

			if (0 != (options & GraphCopyOptions.CopyLayerLinks))
			{
			}

			this.GraphObjects.Clear();
			foreach (var go in from.GraphObjects)
			{
				bool copy = true;

				if (go is LegendText)
					copy = copyLegends;
				else if (go is PlaceHolder)
					copy = true; //
				else // dann bleibt nur noch ein normales GraphItem �brig
					copy = copyGraphItems;

				if (copy)
					this.GraphObjects.Add(go);
			}

			if (0 != (options & GraphCopyOptions.CopyLayerPlotItems))
			{
				this.PlotItems = null == from._plotItems ? null : new PlotItemCollection(this, from._plotItems);
			}
			else if (0 != (options & GraphCopyOptions.CopyLayerPlotStyles))
			{
				// TODO apply the styles from from._plotItems to the PlotItems here
				this.PlotItems.CopyFrom(from._plotItems, options);
			}
		}

		public override object Clone()
		{
			return new XYPlotLayer(this);
		}

		#endregion Copying

		/// <summary>
		/// Constructor for deserialization purposes only.
		/// </summary>
		protected XYPlotLayer(Altaxo.Serialization.Xml.IXmlDeserializationInfo info)
			: base(info)
		{
			this._changeEventSuppressor = new Altaxo.Main.EventSuppressor(EhChangeEventResumed);
			this.CoordinateSystem = new CS.G2DCartesicCoordinateSystem();
			this.AxisStyles = new AxisStyleCollection();
			this.Scales = new ScaleCollection();
			this.Location = new ItemLocationDirect();
			this.GridPlanes = new GridPlaneCollection();
			this.GridPlanes.Add(new GridPlane(CSPlaneID.Front));
		}

		public XYPlotLayer(HostLayer parentLayer)
			: this(parentLayer, GetChildLayerDefaultLocation(), new CS.G2DCartesicCoordinateSystem())
		{
		}

		public XYPlotLayer(HostLayer parentLayer, G2DCoordinateSystem coordinateSystem)
			: this(parentLayer, GetChildLayerDefaultLocation(), coordinateSystem)
		{
		}

		/// <summary>
		/// Creates a layer with position <paramref name="position"/> and size <paramref name="size"/>.
		/// </summary>
		/// <param name="position">The position of the layer on the printable area in points (1/72 inch).</param>
		/// <param name="size">The size of the layer in points (1/72 inch).</param>
		public XYPlotLayer(HostLayer parentLayer, IItemLocation location)
			: this(parentLayer, location, new CS.G2DCartesicCoordinateSystem())
		{
		}

		/// <summary>
		/// Creates a layer with position <paramref name="position"/> and size <paramref name="size"/>.
		/// </summary>
		/// <param name="parentLayer">The parent layer of the newly created layer.</param>
		/// <param name="location">The position of the layer on the printable area in points (1/72 inch).</param>
		/// <param name="coordinateSystem">The coordinate system to use for the layer.</param>
		public XYPlotLayer(HostLayer parentLayer, IItemLocation location, G2DCoordinateSystem coordinateSystem)
			: base(parentLayer, location)
		{
			this.CoordinateSystem = coordinateSystem;
			this.AxisStyles = new AxisStyleCollection();
			this.Scales = new ScaleCollection();
			this.GridPlanes = new GridPlaneCollection();
			this.GridPlanes.Add(new GridPlane(CSPlaneID.Front));
			this.PlotItems = new PlotItemCollection(this);
		}

		#endregion Constructors

		private void EnsureAppropriateGridAndAxisStylePlaceHolders()
		{
			var gridIndex = _graphObjects.IndexOfFirst(x => x is GridPlanesPlaceHolder);
			if (gridIndex < 0)
			{
				_graphObjects.Insert(0, new GridPlanesPlaceHolder());
				gridIndex = 0;
			}
			else
			{
				// make sure that no more GridPlanesPlaceHolders are in the collection
				_graphObjects.RemoveWhere((item, i) => (i > gridIndex) && (item is GridPlanesPlaceHolder));
			}

			// we try to place AxisStyleLinePlaceHolders after the GridPlanesPlaceHolder
			// find the first of any placeholders for axis line styles, store as insert position, if not found use insert position after grid place holder
			// from i= to count look for placeholders for axis line styles i, if not found insert it at insert position, store next position as insert position

			var insertIdx = gridIndex + 1;
			insertIdx = InsertMissingAxisStylePlaceHolders<AxisStyleLinePlaceHolder>(insertIdx);
			insertIdx = InsertMissingAxisStylePlaceHolders<AxisStyleMajorLabelPlaceHolder>(insertIdx);
			insertIdx = InsertMissingAxisStylePlaceHolders<AxisStyleMinorLabelPlaceHolder>(insertIdx);
			insertIdx = InsertMissingAxisStylePlaceHolders<AxisStyleTitlePlaceHolder>(insertIdx);

			// remove superfluous place holders
			int maxCount = _axisStyles.Count;
			_graphObjects.RemoveWhere(x => { var s = x as AxisStylePlaceHolderBase; return null != s && s.Index > maxCount; });
		}

		private int InsertMissingAxisStylePlaceHolders<T>(int insertIdx) where T : AxisStylePlaceHolderBase, new()
		{
			for (int i = 0; i < _axisStyles.Count; ++i)
			{
				var idx = _graphObjects.IndexOfFirst(x => x is T && (x as T).Index == i);
				if (idx >= 0)
				{
					insertIdx = idx + 1;
				}
				else
				{
					_graphObjects.Insert(insertIdx, new T { Index = i });
					++insertIdx;
				}
			}
			return insertIdx;
		}

		#region IPlotLayer methods

		public bool Is3D { get { return false; } }

		public Scale ZAxis { get { return null; } }

		public Scale GetScale(int i)
		{
			return _scales.Scale(i);
		}

		public Logical3D GetLogical3D(I3DPhysicalVariantAccessor acc, int idx)
		{
			Logical3D r;
			r.RX = XAxis.PhysicalVariantToNormal(acc.GetXPhysical(idx));
			r.RY = YAxis.PhysicalVariantToNormal(acc.GetYPhysical(idx));
			r.RZ = Is3D ? ZAxis.PhysicalVariantToNormal(acc.GetZPhysical(idx)) : 0;
			return r;
		}

		/// <summary>
		/// Returns a list of the used axis style ids for this layer.
		/// </summary>
		public System.Collections.Generic.IEnumerable<CSLineID> AxisStyleIDs
		{
			get { return AxisStyles.AxisStyleIDs; }
		}

		/// <summary>
		/// Updates the logical value of a plane id in case it uses a physical value.
		/// </summary>
		/// <param name="id">The plane identifier</param>
		public void UpdateCSPlaneID(CSPlaneID id)
		{
			if (id.UsePhysicalValue)
			{
				double l = this.Scales.Scale(id.PerpendicularAxisNumber).PhysicalVariantToNormal(id.PhysicalValue);
				id.LogicalValue = l;
			}
		}

		#endregion IPlotLayer methods

		#region XYPlotLayer properties and methods

		/// <summary>
		/// Replaces path of items (intended for data items like tables and columns) by other paths. Thus it is possible
		/// to change a plot so that the plot items refer to another table.
		/// </summary>
		/// <param name="Report">Function that reports the found <see cref="C:Altaxo.Main.DocNodeProxy"/> instances to the visitor.</param>
		public override void VisitDocumentReferences(Altaxo.Main.DocNodeProxyReporter Report)
		{
			base.VisitDocumentReferences(Report);
			PlotItems.VisitDocumentReferences(Report);
		}

		/// <summary>
		/// Collection of the axis styles for the left, bottom, right, and top axis.
		/// </summary>
		public AxisStyleCollection AxisStyles
		{
			get
			{
				return _axisStyles;
			}
			protected set
			{
				AxisStyleCollection oldvalue = _axisStyles;
				_axisStyles = value;
				value.ParentObject = this;
				value.UpdateCoordinateSystem(this.CoordinateSystem);

				if (!object.ReferenceEquals(oldvalue, value))
				{
					OnChanged();
				}
			}
		}

		public ScaleCollection Scales
		{
			get
			{
				return _scales;
			}
			protected set
			{
				if (object.ReferenceEquals(value, _scales))
					return;

				if (null != _scales)
				{
					_scales.ScaleInstanceChanged -= EhScaleInstanceChanged;
					_scales.ParentObject = null;
				}

				ScaleCollection oldscales = _scales;
				_scales = value;

				if (null != _scales)
				{
					_scales.ParentObject = this;
					_scales.ScaleInstanceChanged += EhScaleInstanceChanged;
				}

				for (int i = 0; i < _scales.Count; i++)
				{
					Scale oldScale = oldscales == null ? null : oldscales[i].Scale;
					Scale newScale = _scales[i].Scale;
					if (!object.ReferenceEquals(oldScale, newScale))
						EhScaleInstanceChanged(i, oldScale, newScale);
				}
				OnChanged();
			}
		}

		public TextGraphic Legend
		{
			get
			{
				return (LegendText)_graphObjects.FirstOrDefault(item => item is LegendText);
			}
			set
			{
				var idx = _graphObjects.IndexOfFirst(item => item is LegendText);
				TextGraphic oldvalue = idx >= 0 ? (TextGraphic)_graphObjects[idx] : null;

				if (value != null)
				{
					if (idx < 0)
						_graphObjects.Add(value);
					else
						_graphObjects[idx] = value;
				}
				else
				{
					if (idx >= 0)
						_graphObjects.RemoveAt(idx);
				}

				if (!object.ReferenceEquals(value, oldvalue))
				{
					OnChanged();
				}
			}
		}

		public override void Remove(GraphicBase go)
		{
			if (_axisStyles.Remove(go))
				return;
			else
				base.Remove(go);
		}

		protected override void OnGraphObjectsCollectionInstanceInitialized()
		{
			base.OnGraphObjectsCollectionInstanceInitialized();

			if (null != _placeHolders)
			{
			}
			_placeHolders = _graphObjects.CreatePartialViewOfType<PlaceHolder>();
			_plotItemPlaceHolders = _graphObjects.CreatePartialViewOfType<PlotItemPlaceHolder>();
			if (null != _placeHolders)
			{
			}
		}

		public PlotItemCollection PlotItems
		{
			get
			{
				return _plotItems;
			}
			protected set
			{
				PlotItemCollection oldvalue = _plotItems;
				_plotItems = value;
				value.ParentObject = this;

				if (!object.ReferenceEquals(value, oldvalue))
				{
					OnChanged();
				}
			}
		}

		/// <summary>
		/// Clears all legends from this layer.
		/// </summary>
		public void ClearLegends()
		{
			for (int i = this.GraphObjects.Count; i >= 0; --i)
			{
				if (GraphObjects[i] is LegendText)
					GraphObjects.RemoveAt(i);
			}
		}

		/// <summary>
		/// Creates a new legend, removing the old one.
		/// </summary>
		/// <remarks>The position of the old legend is <b>only</b> used for the new legend if the old legend's position is
		/// inside the layer. This prevents a "stealth" legend in case it is not visible by accident.
		/// </remarks>
		public void CreateNewLayerLegend()
		{
			// remove the legend if there are no plot curves on the layer
			if (PlotItems.Flattened.Length == 0)
			{
				ClearLegends();
				OnChanged();
				return;
			}

			TextGraphic tgo;

			var existingLegendIndex = GraphObjects.IndexOfFirst(x => x is LegendText);
			var existingLegend = existingLegendIndex >= 0 ? (LegendText)GraphObjects[existingLegendIndex] : null;

			if (existingLegend != null)
				tgo = new TextGraphic(existingLegend);
			else
				tgo = new TextGraphic();

			System.Text.StringBuilder strg = new System.Text.StringBuilder();
			for (int i = 0; i < this.PlotItems.Flattened.Length; i++)
			{
				strg.AppendFormat("{0}\\L({1}) \\%({2})", (i == 0 ? "" : "\r\n"), i, i);
			}
			tgo.Text = strg.ToString();

			// if the position of the old legend is outside, use a new position
			if (null == existingLegend || existingLegend.Position.X < 0 || existingLegend.Position.Y < 0 ||
				existingLegend.Position.X > this.Size.X || existingLegend.Position.Y > this.Size.Y)
				tgo.Position = new PointD2D(0.1 * this.Size.X, 0.1 * this.Size.Y);
			else
				tgo.Position = existingLegend.Position;

			if (existingLegendIndex >= 0)
				GraphObjects[existingLegendIndex] = tgo;
			else
				GraphObjects.Add(tgo);

			OnChanged();
		}

		/// <summary>
		/// This will create the default axes styles that are given by the coordinate system.
		/// </summary>
		public void CreateDefaultAxes()
		{
			foreach (CSAxisInformation info in CoordinateSystem.AxisStyles)
			{
				if (info.IsShownByDefault)
				{
					this.AxisStyles.CreateDefault(info.Identifier);

					if (info.HasTitleByDefault)
					{
						this.SetAxisTitleString(info.Identifier, info.Identifier.ParallelAxisNumber == 0 ? "X axis" : "Y axis");
					}
				}
			}
		}

		#endregion XYPlotLayer properties and methods

		#region Position and Size

		/// <summary>
		/// Recalculates the positions of inner items in case the layer has changed its size.
		/// </summary>
		/// <param name="xscale">The ratio the layer has changed its size in horizontal direction.</param>
		/// <param name="yscale">The ratio the layer has changed its size in vertical direction.</param>
		public override void RescaleInnerItemPositions(double xscale, double yscale)
		{
			foreach (AxisStyle style in this.AxisStyles)
			{
				GraphicBase.ScalePosition(style.Title, xscale, yscale);
			}

			base.RescaleInnerItemPositions(xscale, yscale);
		}

		#endregion Position and Size

		#region Scale related

		/// <summary>
		/// Absorbs the event from the ScaleCollection and distributes it further.
		/// </summary>
		/// <param name="idx">Index of the scale in the linked layer.</param>
		/// <param name="oldScale">Old scale instance.</param>
		/// <param name="newScale">New scale instance.</param>
		private void EhScaleInstanceChanged(int idx, Scale oldScale, Scale newScale)
		{
			if (null != ScaleInstanceChanged)
				ScaleInstanceChanged(idx, oldScale, newScale);

			if (object.ReferenceEquals(_scales.X.Scale, newScale))
				RescaleXAxis();

			if (object.ReferenceEquals(_scales.Y.Scale, newScale))
				RescaleYAxis();
		}

		/// <summary>
		/// Absorbs the event from the linked layer. Used to adjust the LinkedScale here.
		/// </summary>
		/// <param name="idx">Index of the scale in the linked layer.</param>
		/// <param name="oldScale">Old scale instance.</param>
		/// <param name="newScale">New scale instance.</param>
		private void EhLinkedLayerScaleInstanceChanged(int idx, Scale oldScale, Scale newScale)
		{
			_scales.EhLinkedLayerScaleInstanceChanged(idx, oldScale, newScale);
		}

		public TickSpacing XTicks
		{
			get
			{
				return Scales[0].TickSpacing;
			}
		}

		public TickSpacing YTicks
		{
			get
			{
				return Scales[1].TickSpacing;
			}
		}

		/// <summary>Gets or sets the x axis of this layer.</summary>
		/// <value>The x axis of the layer.</value>
		public Scale XAxis
		{
			get
			{
				return _scales.X.Scale;
			}
			set
			{
				_scales.X.Scale = value;
			}
		}

		/// <summary>Indicates if x axis is linked to the linked layer x axis.</summary>
		/// <value>True if x axis is linked to the linked layer x axis.</value>
		public bool IsXAxisLinked
		{
			get
			{
				return this._scales.X.Scale is LinkedScale;
			}
		}

		private bool EhXAxisInterrogateBoundaryChangedEvent()
		{
			// do nothing here, for the future we can decide to change the linked axis boundaries
			return this.IsXAxisLinked;
		}

		public void RescaleXAxis()
		{
			if (null == this.PlotItems)
				return; // can happen during deserialization

			var scaleBounds = _scales.X.Scale.DataBoundsObject;
			if (null != scaleBounds)
			{
				// we have to disable our own Handler since if we change one DataBound of a association,
				//it generates a OnBoundaryChanged, and then all boundaries are merges into the axis boundary,
				//but (alas!) not all boundaries are now of the new type!
				_plotAssociationXBoundariesChanged_EventSuspendCount++;

				scaleBounds.BeginUpdate(); // Suppress events from the y-axis now
				scaleBounds.Reset();
				foreach (IGPlotItem pa in this.PlotItems)
				{
					if (pa is IXBoundsHolder)
					{
						// merge the bounds with x and yAxis
						((IXBoundsHolder)pa).MergeXBoundsInto(scaleBounds); // merge all x-boundaries in the x-axis boundary object
					}
				}

				// take also the axis styles with physical values into account
				foreach (CSLineID id in _axisStyles.AxisStyleIDs)
				{
					if (id.ParallelAxisNumber != 0 && id.UsePhysicalValueOtherFirst)
						scaleBounds.Add(id.PhysicalValueOtherFirst);
				}

				scaleBounds.EndUpdate();
				_plotAssociationXBoundariesChanged_EventSuspendCount = Math.Max(0, _plotAssociationXBoundariesChanged_EventSuspendCount - 1);
				_scales.X.Scale.Rescale();
			}
			// _linkedScales.X.Scale.ProcessDataBounds();
		}

		/// <summary>Gets or sets the y axis of this layer.</summary>
		/// <value>The y axis of the layer.</value>
		public Scale YAxis
		{
			get
			{
				return _scales.Y.Scale;
			}
			set
			{
				_scales.Y.Scale = value;
			}
		}

		/// <summary>Indicates if y axis is linked to the linked layer y axis.</summary>
		/// <value>True if y axis is linked to the linked layer y axis.</value>
		public bool IsYAxisLinked
		{
			get
			{
				return this._scales.Y.Scale is LinkedScale;
			}
		}

		public void RescaleYAxis()
		{
			if (null == this.PlotItems)
				return; // can happen during deserialization

			var scaleBounds = _scales.Y.Scale.DataBoundsObject;

			if (null != scaleBounds)
			{
				// we have to disable our own Handler since if we change one DataBound of a association,
				//it generates a OnBoundaryChanged, and then all boundaries are merges into the axis boundary,
				//but (alas!) not all boundaries are now of the new type!
				_plotAssociationYBoundariesChanged_EventSuspendCount++;

				scaleBounds.BeginUpdate();
				scaleBounds.Reset();
				foreach (IGPlotItem pa in this.PlotItems)
				{
					if (pa is IYBoundsHolder)
					{
						// merge the bounds with x and yAxis
						((IYBoundsHolder)pa).MergeYBoundsInto(scaleBounds); // merge all x-boundaries in the x-axis boundary object
					}
				}
				// take also the axis styles with physical values into account
				foreach (CSLineID id in _axisStyles.AxisStyleIDs)
				{
					if (id.ParallelAxisNumber == 0 && id.UsePhysicalValueOtherFirst)
						scaleBounds.Add(id.PhysicalValueOtherFirst);
					else if (id.ParallelAxisNumber == 2 && id.UsePhysicalValueOtherSecond)
						scaleBounds.Add(id.PhysicalValueOtherSecond);
				}

				scaleBounds.EndUpdate();
				_plotAssociationYBoundariesChanged_EventSuspendCount = Math.Max(0, _plotAssociationYBoundariesChanged_EventSuspendCount - 1);
				_scales.Y.Scale.Rescale();
			}
			// _linkedScales.Y.Scale.ProcessDataBounds();
		}

		private bool EhYAxisInterrogateBoundaryChangedEvent()
		{
			// do nothing here, for the future we can decide to change the linked axis boundaries
			return this.IsYAxisLinked;
		}

		/// <summary>
		/// Ensures that all linked scales have their scalesLinkedTo instances updated (in case the layer instance or the scale instance has changed in the meantime).
		/// Note that here we should not enforce the link properties (like xOrg = SomeCalculation depending on scaleLinkedTo). This is done later, after the plot items are updated
		/// </summary>
		protected void UpdateScaleLinks()
		{
			foreach (var swt in Scales.Where(s => s.Scale is LinkedScale))
			{
				UpdateScaleLink(swt);
			}
		}

		/// <summary>
		/// Updates the scale link of a <see cref="ScaleWithTicks"/> where the Scale is of type <see cref="LinkedScale"/>
		/// </summary>
		/// <param name="swt">The <see cref="ScaleWithTicks"/> instance.</param>
		/// <remarks>
		/// <para>This updates either the scaleLinkedTo and/or the scale number and layer number.</para>
		/// <para>The scaleLinkedTo has precedence: if it still exist in any of the sibling layers, the layer number and scale number will be updated and the scaleLinked to will be preserved</para>
		/// <para>The other case is when the scaleLinkedTo no longer exists in any of the sibling layers: then it is tried to find a layer with the stored layer number and the scale with the stored scale number</para>
		/// <para>If both cases fail, then the scale is transformed from a linked scale to a normal scale.</para>
		/// </remarks>
		protected void UpdateScaleLink(ScaleWithTicks swt)
		{
			LinkedScale ls = (LinkedScale)swt.Scale;
			Scale scaleLinkedTo = ls.ScaleLinkedTo;

			var layerLinkedTo = Main.DocumentPath.GetRootNodeImplementing<XYPlotLayer>(ls);
			int layerLinkedToIndex, scaleLinkedToIndex;

			if (layerLinkedTo != null &&
					object.ReferenceEquals(this.ParentLayer, layerLinkedTo.ParentLayer) &&
					!object.ReferenceEquals(this, layerLinkedTo) &&
					(scaleLinkedToIndex = layerLinkedTo.Scales.IndexOfFirst(x => object.ReferenceEquals(x.Scale, ls))) >= 0
				)
			{
				// then we have the first case: the linked layer still exist
				layerLinkedToIndex = layerLinkedTo.LayerNumber;
				ls.LinkedLayerIndex = layerLinkedToIndex;
				ls.LinkedScaleIndex = scaleLinkedToIndex;
				return; // first case handled
			}

			// we assume the second case and try to find a layer with the stored layer index, and therein a scale with the stored scale index
			layerLinkedToIndex = ls.LinkedLayerIndex;
			scaleLinkedToIndex = ls.LinkedScaleIndex;

			scaleLinkedTo = null;
			layerLinkedTo = null;
			if (layerLinkedToIndex >= 0 && layerLinkedToIndex < ParentLayerList.Count)
				layerLinkedTo = ParentLayerList[layerLinkedToIndex] as XYPlotLayer;

			if (null != layerLinkedTo && scaleLinkedToIndex >= 0 && scaleLinkedToIndex < layerLinkedTo.Scales.Count)
				scaleLinkedTo = layerLinkedTo.Scales[scaleLinkedToIndex].Scale;

			if (scaleLinkedTo != null)
			{
				ls.ScaleLinkedTo = scaleLinkedTo;
				return; // second case successfully handled
			}

			// both cases fail, so we must convert the linked scale to a normal scale
			swt.Scale = ls.WrappedScale; // set the scale to the wrapped scale
			ls.ScaleLinkedTo = null; // free the event wiring
		}

		/*
		/// <summary>
		/// Draws an isoline on the plot area.
		/// </summary>
		/// <param name="g">Graphics context.</param>
		/// <param name="pen">The style of the pen used to draw the line.</param>
		/// <param name="axis">Axis for which the isoline to draw.</param>
		/// <param name="relaxisval">Relative value (0..1) on this axis.</param>
		/// <param name="relaltstart">Relative value for the alternate axis of the start of the line.</param>
		/// <param name="relaltend">Relative value for the alternate axis of the end of the line.</param>
		public void DrawIsoLine(Graphics g, Pen pen, int axis, double relaxisval, double relaltstart, double relaltend)
		{
			double x1, y1, x2, y2;
			if (axis == 0)
			{
				this.CoordinateSystem.LogicalToLayerCoordinates(relaxisval, relaltstart, out x1, out y1);
				this.CoordinateSystem.LogicalToLayerCoordinates(relaxisval, relaltend, out x2, out y2);
			}
			else
			{
				this.CoordinateSystem.LogicalToLayerCoordinates(relaltstart, relaxisval, out x1, out y1);
				this.CoordinateSystem.LogicalToLayerCoordinates(relaltend, relaxisval, out x2, out y2);
			}

			g.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
		}
		*/

		#endregion Scale related

		#region Style properties

		public LayerDataClipping ClipDataToFrame
		{
			get
			{
				return _dataClipping;
			}
			set
			{
				LayerDataClipping oldvalue = _dataClipping;
				_dataClipping = value;

				if (value != oldvalue)
					this.OnChanged();
			}
		}

		public GridPlaneCollection GridPlanes
		{
			get
			{
				return _gridPlanes;
			}
			set
			{
				if (null == value)
					throw new ArgumentNullException();

				GridPlaneCollection oldvalue = _gridPlanes;
				_gridPlanes = value;

				if (null != value)
					value.ParentObject = this;

				if (!object.ReferenceEquals(value, oldvalue))
				{
					if (null != oldvalue)
						oldvalue.Changed -= EhChildChanged;

					if (null != value)
						value.Changed += EhChildChanged;
				}
			}
		}

		private string GetAxisTitleString(CSLineID id)
		{
			return _axisStyles[id] != null && _axisStyles[id].Title != null ? _axisStyles[id].Title.Text : null;
		}

		private void SetAxisTitleString(CSLineID id, string value)
		{
			AxisStyle style = _axisStyles[id];
			string oldtitle = (style == null || style.Title == null) ? null : style.Title.Text;
			string newtitle = (value == null || value == String.Empty) ? null : value;

			if (newtitle != oldtitle)
			{
				if (newtitle == null)
				{
					if (style != null)
						style.Title = null;
				}
				else if (_axisStyles.AxisStyleEnsured(id).Title != null)
				{
					_axisStyles[id].Title.Text = newtitle;
				}
				else
				{
					TextGraphic tg = new TextGraphic();
					CSAxisInformation info = CoordinateSystem.GetAxisStyleInformation(id);

					// find out the position and orientation of the item
					double rx0 = 0, rx1 = 1, ry0 = 0, ry1 = 1;
					if (id.ParallelAxisNumber == 0)
						ry0 = ry1 = id.LogicalValueOtherFirst;
					else
						rx0 = rx1 = id.LogicalValueOtherFirst;

					PointD2D normDirection;
					Logical3D tdirection = CoordinateSystem.GetLogicalDirection(info.Identifier.ParallelAxisNumber, info.PreferedLabelSide);
					var location = CoordinateSystem.GetNormalizedDirection(new Logical3D(rx0, ry0), new Logical3D(rx1, ry1), 0.5, tdirection, out normDirection);
					double angle = Math.Atan2(normDirection.Y, normDirection.X) * 180 / Math.PI;

					double distance = 0;
					AxisStyle axisStyle = _axisStyles[id];
					if (null != axisStyle.AxisLineStyle)
						distance += axisStyle.AxisLineStyle.GetOuterDistance(info.PreferedLabelSide);
					double labelFontSize = 0;
					if (axisStyle.ShowMajorLabels)
						labelFontSize = Math.Max(labelFontSize, axisStyle.MajorLabelStyle.FontSize);
					if (axisStyle.ShowMinorLabels)
						labelFontSize = Math.Max(labelFontSize, axisStyle.MinorLabelStyle.FontSize);
					const double scaleFontWidth = 4;
					const double scaleFontHeight = 1.5;

					if (-45 <= angle && angle <= 45)
					{
						//case EdgeType.Right:
						tg.Rotation = 90;
						tg.XAnchor = XAnchorPositionType.Center;
						tg.YAnchor = YAnchorPositionType.Top;
						distance += scaleFontWidth * labelFontSize;
					}
					else if (-135 <= angle && angle <= -45)
					{
						//case Top:
						tg.Rotation = 0;
						tg.XAnchor = XAnchorPositionType.Center;
						tg.YAnchor = YAnchorPositionType.Bottom;
						distance += scaleFontHeight * labelFontSize;
					}
					else if (45 <= angle && angle <= 135)
					{
						//case EdgeType.Bottom:
						tg.Rotation = 0;
						tg.XAnchor = XAnchorPositionType.Center;
						tg.YAnchor = YAnchorPositionType.Top;
						distance += scaleFontHeight * labelFontSize;
					}
					else
					{
						//case EdgeType.Left:

						tg.Rotation = 90;
						tg.XAnchor = XAnchorPositionType.Center;
						tg.YAnchor = YAnchorPositionType.Bottom;
						distance += scaleFontWidth * labelFontSize;
					}

					tg.Position = new PointD2D(location.X + distance * normDirection.X, location.Y + distance * normDirection.Y);
					tg.Text = newtitle;
					_axisStyles.AxisStyleEnsured(id).Title = tg;
				}
			}
		}

		public string DefaultYAxisTitleString
		{
			get
			{
				return GetAxisTitleString(CSLineID.Y0);
			}
			set
			{
				SetAxisTitleString(CSLineID.Y0, value);
			}
		}

		public string DefaultXAxisTitleString
		{
			get
			{
				return GetAxisTitleString(CSLineID.X0);
			}
			set
			{
				SetAxisTitleString(CSLineID.X0, value);
			}
		}

		#endregion Style properties

		#region Painting and Hit testing

		/// <summary>
		/// This function is called by the graph document before _any_ layer is painted. We have to make sure that all of our cached data becomes valid.
		///
		/// </summary>

		private void EnsureAppropriatePlotItemPlaceHolders()
		{
			using (var token = _graphObjects.GetEventDisableToken())
			{
				int idx = -1;
				int maxIdx = _plotItemPlaceHolders.Count;
				foreach (var ele in Altaxo.Collections.TreeNodeExtensions.TakeFromHereToLeavesWithIndex<IGPlotItem>(
					_plotItems,
					0,
					true, x => x is PlotItemCollection ? ((PlotItemCollection)x).ChildIndexDirection : IndexDirection.Ascending))
				{
					PlotItemPlaceHolder placeHolder;
					++idx;
					if (idx < maxIdx)
						placeHolder = _plotItemPlaceHolders[idx];
					else
						_plotItemPlaceHolders.Add(placeHolder = new PlotItemPlaceHolder());

					placeHolder.PlotItemParent = ele.Item1.ParentCollection;
					placeHolder.PlotItemIndex = ele.Item2;
				}

				// items from 0 including to idx are in use, thus we can delete items from idx-1 up to the end

				for (int i = _plotItemPlaceHolders.Count - 1; i > idx; --i)
					_plotItemPlaceHolders.RemoveAt(i);
			}
		}

		public override void PaintPreprocessing()
		{
			base.PaintPreprocessing();

			UpdateScaleLinks();

			// Before we paint the axis, we have to make sure that all plot items
			// had their data updated, so that the axes are updated before they are drawn!
			_plotItems.PrepareScales(this);

			// after deserialisation the data bounds object of the scale is empty:
			// then we have to rescale the axis
			if (Scales.X.Scale.DataBoundsObject.IsEmpty)
				RescaleXAxis();
			if (Scales.Y.Scale.DataBoundsObject.IsEmpty)
				RescaleYAxis();

			_plotItems.PrepareGroupStyles(null, this);
			_plotItems.ApplyGroupStyles(null);

			_axisStyles.PaintPreprocessing(this);

			EnsureAppropriateGridAndAxisStylePlaceHolders();
			EnsureAppropriatePlotItemPlaceHolders();
		}

		protected override void PaintInternal(Graphics g)
		{
			// paint the background very first
			_gridPlanes.PaintBackground(g, this);

			// then paint the graph items
			base.PaintInternal(g);
		}

		/// <summary>
		/// This function is called when painting is finished. Can be used to release the resources
		/// not neccessary any more.
		/// </summary>
		public override void PaintPostprocessing()
		{
			_plotItems.PaintPostprocessing();

			base.PaintPostprocessing();
		}

		public override IHitTestObject HitTest(HitTestPointData pageC, bool plotItemsOnly)
		{
			IHitTestObject hit;

			HitTestPointData layerHitTestData = pageC.NewFromTranslationRotationScaleShear(Position.X, Position.Y, -Rotation, Scale, Scale, 0);

			var layerC = layerHitTestData.GetHittedPointInWorldCoord();

			List<GraphicBase> specObjects = new List<GraphicBase>();
			foreach (AxisStyle style in _axisStyles)
				specObjects.Add(style.Title);

			if (!plotItemsOnly)
			{
				// do the hit test first for the special objects of the layer
				foreach (GraphicBase go in specObjects)
				{
					if (null != go)
					{
						hit = go.HitTest(layerHitTestData);
						if (null != hit)
						{
							if (null == hit.Remove && (hit.HittedObject is GraphicBase))
								hit.Remove = new DoubleClickHandler(EhTitlesOrLegend_Remove);
							return ForwardTransform(hit);
						}
					}
				}

				if (null != (hit = base.HitTest(pageC, plotItemsOnly)))
					return hit;

				// hit testing the axes - first a small area around the axis line
				// if hitting this, the editor for scaling the axis should be shown
				foreach (AxisStyle style in this._axisStyles)
				{
					if (style.ShowAxisLine && null != (hit = style.AxisLineStyle.HitTest(this, layerC, false)))
					{
						hit.DoubleClick = AxisScaleEditorMethod;
						return ForwardTransform(hit);
					}
				}

				// hit testing the axes - secondly now with the ticks
				// in this case the TitleAndFormat editor for the axis should be shown
				foreach (AxisStyle style in this._axisStyles)
				{
					if (style.ShowAxisLine && null != (hit = style.AxisLineStyle.HitTest(this, layerC, true)))
					{
						hit.DoubleClick = AxisStyleEditorMethod;
						return ForwardTransform(hit);
					}
				}

				// hit testing the major and minor labels
				foreach (AxisStyle style in this._axisStyles)
				{
					if (style.ShowMajorLabels && null != (hit = style.MajorLabelStyle.HitTest(this, layerC)))
					{
						hit.DoubleClick = AxisLabelMajorStyleEditorMethod;
						hit.Remove = EhAxisLabelMajorStyleRemove;
						return ForwardTransform(hit);
					}
					if (style.ShowMinorLabels && null != (hit = style.MinorLabelStyle.HitTest(this, layerC)))
					{
						hit.DoubleClick = AxisLabelMinorStyleEditorMethod;
						hit.Remove = EhAxisLabelMinorStyleRemove;
						return ForwardTransform(hit);
					}
				}
			}

			if (null != (hit = _plotItems.HitTest(this, layerC)))
			{
				if (hit.DoubleClick == null) hit.DoubleClick = PlotItemEditorMethod;
				return ForwardTransform(hit);
			}

			return null;
		}

		#endregion Painting and Hit testing

		#region Editor methods

		public static DoubleClickHandler AxisScaleEditorMethod;
		public static DoubleClickHandler AxisStyleEditorMethod;
		public static DoubleClickHandler AxisLabelMajorStyleEditorMethod;
		public static DoubleClickHandler AxisLabelMinorStyleEditorMethod;
		public static DoubleClickHandler PlotItemEditorMethod;

		private bool EhAxisLabelMajorStyleRemove(IHitTestObject o)
		{
			AxisLabelStyle als = o.HittedObject as AxisLabelStyle;
			AxisStyle axisStyle = als == null ? null : als.ParentObject as AxisStyle;
			if (axisStyle != null)
			{
				axisStyle.ShowMajorLabels = false;
				return true;
			}
			return false;
		}

		private bool EhAxisLabelMinorStyleRemove(IHitTestObject o)
		{
			AxisLabelStyle als = o.HittedObject as AxisLabelStyle;
			AxisStyle axisStyle = als == null ? null : als.ParentObject as AxisStyle;
			if (axisStyle != null)
			{
				axisStyle.ShowMinorLabels = false;
				return true;
			}
			return false;
		}

		#endregion Editor methods

		#region Event firing

		protected override void OnSizeChanged()
		{
			// first update out direct childs
			if (null != CoordinateSystem)
				CoordinateSystem.UpdateAreaSize(this.Size);

			base.OnSizeChanged();
		}

		#endregion Event firing

		#region Handler of child events

		private static bool EhTitlesOrLegend_Remove(IHitTestObject o)
		{
			GraphicBase go = (GraphicBase)o.HittedObject;
			var layer = o.ParentLayer as XYPlotLayer;
			if (null != layer)
			{
				foreach (AxisStyle style in layer._axisStyles)
				{
					if (object.ReferenceEquals(go, style.Title))
					{
						style.Title = null;
						return true;
					}
				}
			}

			return false;
		}

		/// <summary>
		/// This handler is called if a x-boundary from any of the plotassociations of this layer
		/// has changed. We then have to recalculate the boundaries.
		/// </summary>
		/// <param name="sender">The plotassociation that has caused the boundary changed event.</param>
		/// <param name="e">The boundary changed event args.</param>
		/// <remarks>Unfortunately we do not know if the boundary is extended or shrinked, if is is extended
		/// if would be possible to merge only the changed boundary into the x-axis boundary.
		/// But since we don't know about that, we have to completely recalculate the boundary be using the boundaries of
		/// all PlotAssociations of this layer.</remarks>
		public void OnPlotAssociationXBoundariesChanged(object sender, BoundariesChangedEventArgs e)
		{
			if (0 == _plotAssociationXBoundariesChanged_EventSuspendCount)
			{
				// now we have to inform all the PlotAssociations that a new axis was loaded
				_scales.X.Scale.DataBoundsObject.BeginUpdate();
				_scales.X.Scale.DataBoundsObject.Reset();
				foreach (IGPlotItem pa in this.PlotItems)
				{
					if (pa is IXBoundsHolder)
					{
						// merge the bounds with x and yAxis
						((IXBoundsHolder)pa).MergeXBoundsInto(_scales.X.Scale.DataBoundsObject); // merge all x-boundaries in the x-axis boundary object
					}
				}
				_scales.X.Scale.DataBoundsObject.EndUpdate();
			}
		}

		/// <summary>
		/// This handler is called if a y-boundary from any of the plotassociations of this layer
		/// has changed. We then have to recalculate the boundaries.
		/// </summary>
		/// <param name="sender">The plotassociation that has caused the boundary changed event.</param>
		/// <param name="e">The boundary changed event args.</param>
		/// <remarks>Unfortunately we do not know if the boundary is extended or shrinked, if is is extended
		/// if would be possible to merge only the changed boundary into the y-axis boundary.
		/// But since we don't know about that, we have to completely recalculate the boundary be using the boundaries of
		/// all PlotAssociations of this layer.</remarks>
		public void OnPlotAssociationYBoundariesChanged(object sender, BoundariesChangedEventArgs e)
		{
			if (0 == _plotAssociationYBoundariesChanged_EventSuspendCount)
			{
				// now we have to inform all the PlotAssociations that a new axis was loaded
				_scales.Y.Scale.DataBoundsObject.BeginUpdate();
				_scales.Y.Scale.DataBoundsObject.Reset();
				foreach (IGPlotItem pa in this.PlotItems)
				{
					if (pa is IYBoundsHolder)
					{
						// merge the bounds with x and yAxis
						((IYBoundsHolder)pa).MergeYBoundsInto(_scales.Y.Scale.DataBoundsObject); // merge all x-boundaries in the x-axis boundary object
					}
				}
				_scales.Y.Scale.DataBoundsObject.EndUpdate();
			}
		}

		#endregion Handler of child events

		#region IDocumentNode Members

		/// <summary>
		/// retrieves the object with the name <code>name</code>.
		/// </summary>
		/// <param name="name">The objects name.</param>
		/// <returns>The object with the specified name.</returns>
		public override object GetChildObjectNamed(string name)
		{
			if (name == _plotItems.Name)
				return _plotItems;

			return null;
		}

		/// <summary>
		/// Retrieves the name of the provided object.
		/// </summary>
		/// <param name="o">The object for which the name should be found.</param>
		/// <returns>The name of the object. Null if the object is not found. String.Empty if the object is found but has no name.</returns>
		public override string GetNameOfChildObject(object o)
		{
			if (object.ReferenceEquals(_plotItems, o))
				return _plotItems.Name;

			return null;
		}

		#endregion IDocumentNode Members

		#region Inner types

		public bool IsLinear { get { return XAxis is LinearScale && YAxis is LinearScale; } }

		public G2DCoordinateSystem CoordinateSystem
		{
			get
			{
				return _coordinateSystem;
			}
			set
			{
				if (null == value)
					throw new ArgumentNullException();

				G2DCoordinateSystem oldValue = _coordinateSystem;
				_coordinateSystem = value;
				_coordinateSystem.ParentObject = this;

				if (oldValue != value)
				{
					_coordinateSystem.UpdateAreaSize(this.Size);

					if (null != AxisStyles)
						AxisStyles.UpdateCoordinateSystem(value);

					OnChanged();
				}
			}
		}

		#endregion Inner types

		#region Old types no longer in use but needed for deserialization

		/// <summary>
		/// AxisStylesSummary collects all styles that correspond to one axis scale (i.e. either x-axis or y-axis)
		/// in one class. This contains the grid style of the axis, and one or more axis styles
		/// </summary>
		private class ScaleStyle
		{
			private GridStyle _gridStyle;
			private List<AxisStyle> _axisStyles;

			//G2DCoordinateSystem _cachedCoordinateSystem;

			#region Serialization

			[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.XYPlotLayerAxisStylesSummary", 0)]
			private class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
			{
				public virtual void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
				{
					throw new NotSupportedException("Serialization of old versions not supported - probably a programming error");
					/*
					XYPlotLayerAxisStylesSummary s = (XYPlotLayerAxisStylesSummary)obj;
					info.AddValue("Grid", s._gridStyle);

					info.CreateArray("Edges", s._edges.Length);
					for (int i = 0; i < s._edges.Length; ++i)
						info.AddEnum("e", s._edges[i]);
					info.CommitArray();

					info.CreateArray("AxisStyles",s._axisStyles.Length);
					for(int i=0;i<s._axisStyles.Length;++i)
						info.AddValue("e",s._axisStyles[i]);
					info.CommitArray();
					*/
				}

				public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
				{
					ScaleStyle s = SDeserialize(o, info, parent);
					return s;
				}

				protected virtual ScaleStyle SDeserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
				{
					ScaleStyle s = null != o ? (ScaleStyle)o : new ScaleStyle();

					s.GridStyle = (GridStyle)info.GetValue("Grid", s);

					int count = info.OpenArray();
					//s._edges = new EdgeType[count];
					for (int i = 0; i < count; ++i)
						info.GetEnum("e", typeof(EdgeType));
					info.CloseArray(count);

					count = info.OpenArray();
					//s._axisStyles = new XYPlotLayerAxisStyleProperties[count];
					for (int i = 0; i < count; ++i)
						s._axisStyles.Add((AxisStyle)info.GetValue("e", s));
					info.CloseArray(count);

					return s;
				}
			}

			// 2006-09-08 - renaming to G2DScaleStyle
			[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(ScaleStyle), 1)]
			private class XmlSerializationSurrogate1 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
			{
				public virtual void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
				{
					throw new NotImplementedException("Serialization of old versions is not supported");
					/*
					ScaleStyle s = (ScaleStyle)obj;

					info.AddValue("Grid", s._gridStyle);

					info.CreateArray("AxisStyles", s._axisStyles.Count);
					for (int i = 0; i < s._axisStyles.Count; ++i)
						info.AddValue("e", s._axisStyles[i]);
					info.CommitArray();
					*/
				}

				public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
				{
					ScaleStyle s = SDeserialize(o, info, parent);
					return s;
				}

				protected virtual ScaleStyle SDeserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
				{
					ScaleStyle s = null != o ? (ScaleStyle)o : new ScaleStyle();

					s.GridStyle = (GridStyle)info.GetValue("Grid", s);

					int count = info.OpenArray();
					//s._axisStyles = new XYPlotLayerAxisStyleProperties[count];
					for (int i = 0; i < count; ++i)
						s._axisStyles.Add((AxisStyle)info.GetValue("e", s));
					info.CloseArray(count);

					return s;
				}
			}

			#endregion Serialization

			/// <summary>
			/// Default constructor. Defines neither a grid style nor an axis style.
			/// </summary>
			public ScaleStyle()
			{
				_axisStyles = new List<AxisStyle>();
			}

			private void CopyFrom(ScaleStyle from)
			{
				if (object.ReferenceEquals(this, from))
					return;

				this.GridStyle = from._gridStyle == null ? null : (GridStyle)from._gridStyle.Clone();

				this._axisStyles.Clear();
				for (int i = 0; i < _axisStyles.Count; ++i)
				{
					this.AddAxisStyle((AxisStyle)from._axisStyles[i].Clone());
				}
			}

			public void AddAxisStyle(AxisStyle value)
			{
				if (value != null)
				{
					_axisStyles.Add(value);
				}
			}

			public void RemoveAxisStyle(CSLineID id)
			{
				int idx = -1;
				for (int i = 0; i < _axisStyles.Count; i++)
				{
					if (_axisStyles[i].StyleID == id)
					{
						idx = i;
						break;
					}
				}

				if (idx > 0)
					_axisStyles.RemoveAt(idx);
			}

			public AxisStyle AxisStyleEnsured(CSLineID id)
			{
				AxisStyle prop = AxisStyle(id);
				if (prop == null)
				{
					prop = new AxisStyle(id);
					// prop.CachedAxisInformation = _cachedCoordinateSystem.GetAxisStyleInformation(id);
					AddAxisStyle(prop);
				}
				return prop;
			}

			public bool ContainsAxisStyle(CSLineID id)
			{
				return null != AxisStyle(id);
			}

			public AxisStyle AxisStyle(CSLineID id)
			{
				foreach (AxisStyle p in _axisStyles)
					if (p.StyleID == id)
						return p;

				return null;
			}

			public IEnumerable<AxisStyle> AxisStyles
			{
				get
				{
					return _axisStyles;
				}
			}

			public GridStyle GridStyle
			{
				get { return _gridStyle; }
				set
				{
					GridStyle oldvalue = _gridStyle;
					_gridStyle = value;
				}
			}
		}

		/// <summary>
		/// This class holds the (normally two for 2D) AxisStylesSummaries - for every axis scale one summary.
		/// </summary>
		private class G2DScaleStyleCollection
		{
			private ScaleStyle[] _styles;

			#region Serialization

			[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.XYPlotLayerAxisStylesSummaryCollection", 0)]
			// 2006-09-08 renamed to G2DScaleStyleCollection
			[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(G2DScaleStyleCollection), 1)]
			private class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
			{
				public virtual void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
				{
					throw new NotImplementedException("Serialization of old versions is not supported");
					/*
					G2DScaleStyleCollection s = (G2DScaleStyleCollection)obj;

					info.CreateArray("Styles", s._styles.Length);
					for (int i = 0; i < s._styles.Length; ++i)
						info.AddValue("e", s._styles[i]);
					info.CommitArray();
					*/
				}

				public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
				{
					G2DScaleStyleCollection s = SDeserialize(o, info, parent);
					return s;
				}

				protected virtual G2DScaleStyleCollection SDeserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
				{
					G2DScaleStyleCollection s = null != o ? (G2DScaleStyleCollection)o : new G2DScaleStyleCollection();

					int count = info.OpenArray();
					s._styles = new ScaleStyle[count];
					for (int i = 0; i < count; ++i)
						s.SetScaleStyle((ScaleStyle)info.GetValue("e", s), i);
					info.CloseArray(count);

					return s;
				}
			}

			#endregion Serialization

			public G2DScaleStyleCollection()
			{
				_styles = new ScaleStyle[2];

				this._styles[0] = new ScaleStyle();

				this._styles[1] = new ScaleStyle();
			}

			/// <summary>
			/// Return the axis style with the given id. If this style is not present, the return value is null.
			/// </summary>
			/// <param name="id"></param>
			/// <returns></returns>
			public AxisStyle AxisStyle(CSLineID id)
			{
				ScaleStyle scaleStyle = _styles[id.ParallelAxisNumber];
				return scaleStyle.AxisStyle(id);
			}

			/// <summary>
			/// This will return an axis style with the given id. If not present, this axis style will be created, added to the collection, and returned.
			/// </summary>
			/// <param name="id"></param>
			/// <returns></returns>
			public AxisStyle AxisStyleEnsured(CSLineID id)
			{
				ScaleStyle scaleStyle = _styles[id.ParallelAxisNumber];
				return scaleStyle.AxisStyleEnsured(id);
			}

			public void RemoveAxisStyle(CSLineID id)
			{
				ScaleStyle scaleStyle = _styles[id.ParallelAxisNumber];
				scaleStyle.RemoveAxisStyle(id);
			}

			public IEnumerable<AxisStyle> AxisStyles
			{
				get
				{
					for (int i = 0; i < _styles.Length; i++)
					{
						foreach (AxisStyle style in _styles[i].AxisStyles)
							yield return style;
					}
				}
			}

			public IEnumerable<CSLineID> AxisStyleIDs
			{
				get
				{
					for (int i = 0; i < _styles.Length; i++)
					{
						foreach (AxisStyle style in _styles[i].AxisStyles)
							yield return style.StyleID;
					}
				}
			}

			public bool ContainsAxisStyle(CSLineID id)
			{
				ScaleStyle scalestyle = _styles[id.ParallelAxisNumber];
				return scalestyle.ContainsAxisStyle(id);
			}

			public ScaleStyle ScaleStyle(int i)
			{
				return _styles[i];
			}

			public void SetScaleStyle(ScaleStyle value, int i)
			{
				if (i < 0)
					throw new ArgumentOutOfRangeException("Index i is negative");
				if (i >= _styles.Length)
					throw new ArgumentOutOfRangeException("Index i is greater than length of internal array");

				ScaleStyle oldvalue = _styles[i];
				_styles[i] = value;
			}

			public ScaleStyle X
			{
				get
				{
					return _styles[0];
				}
			}

			public ScaleStyle Y
			{
				get
				{
					return _styles[1];
				}
			}
		}

		#endregion Old types no longer in use but needed for deserialization

		#region IGraphicShape placeholder for items in XYPlotLayer

		private abstract class PlaceHolder : IGraphicBase, ILayerItemPlaceHolder
		{
			public event EventHandler Changed;

			public object ParentObject { get; set; }

			public IHitTestObject HitTest(HitTestPointData hitData)
			{
				return null;
			}

			public abstract void Paint(Graphics g, object obj);

			public PointD2D Position
			{
				get
				{
					return new PointD2D(0, 0);
				}
				set
				{
				}
			}

			public string Name
			{
				get { return this.GetType().Name; }
			}

			public virtual bool CopyFrom(object obj)
			{
				if (object.ReferenceEquals(this, obj))
					return true;
				var from = obj as PlaceHolder;
				if (null != from)
				{
					this.ParentObject = from.ParentObject;
					return true;
				}
				return false;
			}

			public abstract object Clone();

			/// <summary>
			/// Determines whether this place holder item is used by the specified layer type.
			/// </summary>
			/// <param name="layer">The layer. The item that implements this function should only use the type of the provided layer, not the specific layer instance.</param>
			/// <returns>
			///   <c>true</c> if this placeholder item can be used for the provided (type of) layer; otherwise, <c>false</c>.
			/// </returns>
			public bool IsUsedForLayer(HostLayer layer)
			{
				return layer is XYPlotLayer;
			}
		}

		private abstract class AxisStylePlaceHolderBase : PlaceHolder
		{
			public int Index { get; set; }

			public override bool CopyFrom(object obj)
			{
				if (!base.CopyFrom(obj))
					return false;

				var from = obj as AxisStylePlaceHolderBase;
				if (null != from)
					this.Index = from.Index;

				return true;
			}
		}

		private class AxisStyleLinePlaceHolder : AxisStylePlaceHolderBase
		{
			public override void Paint(Graphics g, object obj)
			{
				var layer = ParentObject as XYPlotLayer;
				if (null != layer)
				{
					if (Index >= 0 && Index < layer._axisStyles.Count)
						layer._axisStyles.ItemAt(Index).PaintLine(g, layer);
				}
			}

			public override object Clone()
			{
				var r = new AxisStyleLinePlaceHolder();
				r.CopyFrom(this);
				return r;
			}
		}

		private class AxisStyleMajorLabelPlaceHolder : AxisStylePlaceHolderBase
		{
			public override void Paint(Graphics g, object obj)
			{
				var layer = ParentObject as XYPlotLayer;
				if (null != layer)
				{
					if (Index >= 0 && Index < layer._axisStyles.Count)
						layer._axisStyles.ItemAt(Index).PaintMajorLabels(g, layer);
				}
			}

			public override object Clone()
			{
				var r = new AxisStyleMajorLabelPlaceHolder();
				r.CopyFrom(this);
				return r;
			}
		}

		private class AxisStyleMinorLabelPlaceHolder : AxisStylePlaceHolderBase
		{
			public override void Paint(Graphics g, object obj)
			{
				var layer = ParentObject as XYPlotLayer;
				if (null != layer)
				{
					if (Index >= 0 && Index < layer._axisStyles.Count)
						layer._axisStyles.ItemAt(Index).PaintMinorLabels(g, layer);
				}
			}

			public override object Clone()
			{
				var r = new AxisStyleMinorLabelPlaceHolder();
				r.CopyFrom(this);
				return r;
			}
		}

		private class AxisStyleTitlePlaceHolder : AxisStylePlaceHolderBase
		{
			public override void Paint(Graphics g, object obj)
			{
				var layer = ParentObject as XYPlotLayer;
				if (null != layer)
				{
					if (Index >= 0 && Index < layer._axisStyles.Count)
						layer._axisStyles.ItemAt(Index).PaintTitle(g, layer);
				}
			}

			public override object Clone()
			{
				var r = new AxisStyleTitlePlaceHolder();
				r.CopyFrom(this);
				return r;
			}
		}

		private class AxisStylePlaceHolder : PlaceHolder
		{
			public override void Paint(Graphics g, object obj)
			{
				var layer = ParentObject as XYPlotLayer;
				if (null != layer)
				{
					layer._axisStyles.Paint(g, layer);
				}
			}

			public override object Clone()
			{
				var r = new AxisStylePlaceHolder();
				r.CopyFrom(this);
				return r;
			}
		}

		private class GridPlanesPlaceHolder : PlaceHolder
		{
			public override void Paint(Graphics g, object obj)
			{
				var layer = ParentObject as XYPlotLayer;
				if (null != layer)
				{
					layer._gridPlanes.PaintGrid(g, layer);
				}
			}

			public override object Clone()
			{
				var r = new GridPlanesPlaceHolder();
				r.CopyFrom(this);
				return r;
			}
		}

		private class PlotItemPlaceHolder : PlaceHolder
		{
			public PlotItemCollection PlotItemParent { get; set; }

			public int PlotItemIndex { get; set; }

			public override void Paint(Graphics g, object obj)
			{
				var layer = ParentObject as XYPlotLayer;
				if (null != layer)
				{
					if (layer.ClipDataToFrame == LayerDataClipping.StrictToCS)
					{
						g.Clip = layer.CoordinateSystem.GetRegion();
					}

					if (null == PlotItemParent)
						layer._plotItems.Paint(g, layer, null, null);
					else
						PlotItemParent.PaintChild(g, layer, PlotItemIndex);

					if (layer.ClipDataToFrame == LayerDataClipping.StrictToCS)
					{
						g.ResetClip();
					}
				}
			}

			public override object Clone()
			{
				var r = new PlotItemPlaceHolder();
				r.CopyFrom(this);
				return r;
			}
		}

		private class LegendText : TextGraphic
		{
		}

		#endregion IGraphicShape placeholder for items in XYPlotLayer
	}
}