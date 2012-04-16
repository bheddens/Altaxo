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
using System.Drawing;
using System.Drawing.Drawing2D;

using Altaxo.Serialization;
using Altaxo.Graph.Gdi.Axis;
using Altaxo.Graph.Scales;
using Altaxo.Graph.Scales.Ticks;
using Altaxo.Graph.Gdi.Background;

namespace Altaxo.Graph.Gdi.Shapes
{
	/// <summary>Enumerates the kind of span that determines the length of the floating scale.</summary>
	public enum FloatingScaleSpanType
	{
		/// <summary>
		/// The span value is a logical value. This is the ratio corresponding to the length of the underlying scale. Thus, a value of 0.5 means half the length of the underlying scale.
		/// </summary>
		IsLogicalValue,

		/// <summary>
		/// The span value is a physical value, and is given as difference of end and org of the floating scale. Thus, if the span value is for example 3 and the org of the floating scale is 2, then the end of the floating scale will be 2 + 3 = 5.
		/// </summary>
		IsPhysicalEndOrgDifference,

		/// <summary>
		/// The span value is a physical value, and is given as ratio of end to org of the floating scale. Thus, if the span value is for example 3 and the org of the floating scale is 2, then the end of the floating scale will be 2 * 3 =6.
		/// </summary>
		IsPhysicalEndOrgRatio
	}


	[Serializable]
	public class FloatingScale : GraphicBase
	{
		/// <summary>Number of the scale to measure (0: x-axis, 1: y-axis, 2: z-axis).</summary>
		int _scaleNumber;

		/// <summary>If true, the _scaleSpan is interpreted as a physical value. Otherwise, it is a logical span.</summary>
		FloatingScaleSpanType _scaleSpanType;

		/// <summary>The span this scale should show. It is either a physical or a logical value, depending on <see cref="_scaleSpanIsPhysical"/>.</summary>
		double _scaleSpanValue;

		ScaleSegmentType _scaleSegmentType;

		TickSpacing _tickSpacing;

		AxisStyle _axisStyle;

		Margin2D _backgroundPadding;

		IBackgroundStyle _background;

		// Cached members
		/// <summary>Cached path of the isoline.</summary>
		GraphicsPath _cachedPath;


		#region Serialization


		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(FloatingScale), 0)]
		class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				FloatingScale s = (FloatingScale)obj;
				info.AddBaseValueEmbedded(s, typeof(FloatingScale).BaseType);

				info.AddValue("ScaleNumber",s._scaleNumber);
				info.AddEnum("ScaleSpanType", s._scaleSpanType);
				info.AddValue("ScaleSpanValue",s._scaleSpanValue);
				info.AddEnum("ScaleType",s._scaleSegmentType);
				info.AddValue("TickSpacing", s._tickSpacing);
				info.AddValue("AxisStyle",s._axisStyle);

				info.AddValue("Background", s._background);
				if (null != s._background)
					info.AddValue("BackgroundPadding", s._backgroundPadding);

			}
			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{

				FloatingScale s = null != o ? (FloatingScale)o : new FloatingScale(info);
				info.GetBaseValueEmbedded(s, typeof(FloatingScale).BaseType, parent);

				s._scaleNumber = info.GetInt32("ScaleNumber");
				s._scaleSpanType = (FloatingScaleSpanType)info.GetEnum("ScaleSpanType", typeof(FloatingScaleSpanType));
				s._scaleSpanValue = info.GetDouble("ScaleSpanValue");
				s._scaleSegmentType = (ScaleSegmentType)info.GetEnum("ScaleType",typeof(ScaleSegmentType));
				s._tickSpacing = (TickSpacing)info.GetValue("TickSpacing");
				s._axisStyle = (AxisStyle)info.GetValue("AxisStyle");
				s._background = (IBackgroundStyle)info.GetValue("Background");
				if (null != s._background)
					s._backgroundPadding = (Margin2D)info.GetValue("BackgroundPadding");

				return s;
			}
		}


		#endregion


		#region Constructors

		/// <summary>Constructor only for deserialization purposes.</summary>
		/// <param name="info">Not used here.</param>
		private FloatingScale(Altaxo.Serialization.Xml.IXmlDeserializationInfo info)
		{
		}

		public FloatingScale()
		{
			_scaleSpanValue = 0.25;
			_tickSpacing = new SpanTickSpacing();
			_axisStyle = new AxisStyle(new CSLineID(0, 0)) { ShowAxisLine = true, ShowMinorLabels = true };
		}

		public FloatingScale(FloatingScale from)
			: base(from) // all is done here, since CopyFrom is virtual!
		{
		}

		public override bool CopyFrom(object obj)
		{
			bool isCopied = base.CopyFrom(obj);
			if (isCopied && !object.ReferenceEquals(this, obj))
			{
				var from = obj as FloatingScale;
				if (null != from)
				{
					_cachedPath = null;

					_scaleSpanValue = from._scaleSpanValue;
					_scaleSpanType = from._scaleSpanType;
					_scaleNumber = from._scaleNumber;
					_scaleSegmentType = from._scaleSegmentType;

					CopyHelper.Copy(ref _tickSpacing, from._tickSpacing);
					CopyHelper.Copy(ref _axisStyle, from._axisStyle);

					_backgroundPadding = from._backgroundPadding;
					CopyHelper.Copy(ref _background, from._background);
				}
			}
			return isCopied;
		}

		public override object Clone()
		{
			return new FloatingScale(this);
		}


		#endregion

		public AxisStyle AxisStyle
		{
			get
			{
				return _axisStyle;
			}
		}

		public ScaleSegmentType ScaleType
		{
			get
			{
				return _scaleSegmentType;
			}
			set
			{
				var oldValue = _scaleSegmentType;
				_scaleSegmentType = value;
				if (oldValue != value)
				{
					OnChanged();
				}
			}
		}

		public TickSpacing TickSpacing
		{
			get
			{
				return _tickSpacing;
			}
			set
			{
				if (null == value)
					throw new ArgumentNullException();

				_tickSpacing = (TickSpacing)value.Clone();

				OnChanged();
			}
		}

		public int ScaleNumber
		{
			get
			{
				return _scaleNumber;
			}
			set
			{
				_scaleNumber = value;
			}
		}

			public double ScaleSpanValue
			{
				get
				{
					return _scaleSpanValue;
				}
				set
				{
					_scaleSpanValue = value;
				}
			}

			public FloatingScaleSpanType ScaleSpanType
			{
				get
				{
					return _scaleSpanType;
				}
				set
				{
					_scaleSpanType = value;
				}
			}

			public Margin2D BackgroundPadding
			{
				get
				{
					return _backgroundPadding;
				}
				set
				{
					var oldValue = _backgroundPadding;
					_backgroundPadding = value;
					if (!value.Equals(oldValue))
						OnChanged();
				}
			}

			public IBackgroundStyle Background
			{
				get
				{
					return _background;
				}
				set
				{
					var oldValue = _background;
					_background = value;
					if (!object.ReferenceEquals(value, oldValue))
						OnChanged();
				}
			}




		public override bool AllowNegativeSize
		{
			get
			{
				return true;
			}
		}

		public override bool AutoSize
		{
			get
			{
				return true;
			}
		}

		public override void SetPosition(PointD2D value)
		{
			var oldPosition = this._position;
			base.SetPosition(value);

			if (_axisStyle.Title != null)
			{
				var oldTitlePos = _axisStyle.Title.Position;
				_axisStyle.Title.SilentSetPosition(oldTitlePos + (_position - oldPosition));
			}
		}

		public override void SilentSetPosition(PointD2D newPosition)
		{
			var oldPosition = this._position;
			base.SilentSetPosition(newPosition);
			if (_axisStyle.Title != null)
			{
				var oldTitlePos = _axisStyle.Title.Position;
				_axisStyle.Title.SilentSetPosition(oldTitlePos + (_position - oldPosition));
			}
		}

	

		public GraphicsPath GetSelectionPath()
		{

			return _cachedPath;
		}

		public override GraphicsPath GetObjectOutlineForArrangements()
		{
			return _cachedPath;
		}

		protected GraphicsPath GetPath(double minWidth)
		{
			GraphicsPath gp = (GraphicsPath)_cachedPath.Clone();

			return gp;
		}

		public override IHitTestObject HitTest(HitTestPointData htd)
		{
			if (_axisStyle.Title != null)
			{
				var titleResult = _axisStyle.Title.HitTest(htd);
				if (null != titleResult)
				{
					titleResult.Remove = EhTitleRemove; 
					return titleResult;
				}
			}

			var pt = htd.GetHittedPointInWorldCoord();
			HitTestObjectBase result = null;
			GraphicsPath gp = GetSelectionPath();
			if (gp.IsVisible((PointF)pt))
			{
				result = new MyHitTestObject(this);
			}

			if (result != null)
				result.DoubleClick = EhHitDoubleClick;

			return result;
		}

		static new bool EhHitDoubleClick(IHitTestObject o)
		{
			object hitted = o.HittedObject;
			Current.Gui.ShowDialog(ref hitted, "Floating scale properties", true);
			((FloatingScale)hitted).OnChanged();
			return true;
		}


		static new bool EhTitleRemove(IHitTestObject o)
		{
			object hitted = o.HittedObject;
			var axStyle = ((TextGraphic)hitted).ParentObject as AxisStyle;
			axStyle.Title = null;
			return true;
		}




		public override void Paint(Graphics g, object obj)
		{
			var layer = (XYPlotLayer)obj;
			
			Logical3D rBegin;
			layer.CoordinateSystem.LayerToLogicalCoordinates(X, Y, out rBegin);

			Logical3D rEnd = rBegin;
			switch (_scaleSpanType)
			{
				case FloatingScaleSpanType.IsLogicalValue:
					rEnd[_scaleNumber] = rBegin[_scaleNumber] + _scaleSpanValue;
					break;
				case FloatingScaleSpanType.IsPhysicalEndOrgDifference:
					{
						var physValue = layer.Scales[_scaleNumber].Scale.NormalToPhysicalVariant(rBegin[this._scaleNumber]);
						physValue += _scaleSpanValue; // to be replaced by the scale span
						var logValue = layer.Scales[_scaleNumber].Scale.PhysicalVariantToNormal(physValue);
						rEnd[_scaleNumber] = logValue;
					}
					break;
				case FloatingScaleSpanType.IsPhysicalEndOrgRatio:
						{
						var physValue = layer.Scales[_scaleNumber].Scale.NormalToPhysicalVariant(rBegin[this._scaleNumber]);
						physValue *= _scaleSpanValue; // to be replaced by the scale span
						var logValue = layer.Scales[_scaleNumber].Scale.PhysicalVariantToNormal(physValue);
						rEnd[_scaleNumber] = logValue;
					}
					break;
			}
			


			// axis style
			var csLineId = new CSLineID(_scaleNumber, rBegin);
			if (_axisStyle.StyleID != csLineId)
			{
				var axStyle = new AxisStyle(new CSLineID(_scaleNumber, rBegin));
				axStyle.CopyWithoutIdFrom(_axisStyle);
				_axisStyle = axStyle;
			}

			ScaleWithTicks scaleWithTicks = null;
			var privScale = new ScaleSegment(layer.Scales[_scaleNumber].Scale, rBegin[_scaleNumber], rEnd[_scaleNumber], _scaleSegmentType);
			_tickSpacing.FinalProcessScaleBoundaries(privScale.OrgAsVariant, privScale.EndAsVariant, privScale);
			scaleWithTicks = new ScaleWithTicks(privScale, _tickSpacing);
			var privLayer = new LayerSegment(layer, scaleWithTicks , rBegin, rEnd, _scaleNumber);

			if (_background == null)
			{
				_axisStyle.Paint(g, privLayer, privLayer.GetAxisStyleInformation);
			}
			else
			{
				// if we have a background, we paint in a dummy bitmap in order to measure all items
				// the real painting is done later on after painting the background.
				using (var bmp = new Bitmap(4, 4))
				{
					using (Graphics gg = Graphics.FromImage(bmp))
					{
						_axisStyle.Paint(gg, privLayer, privLayer.GetAxisStyleInformation);
					}
				}
			}
			

			_cachedPath = _axisStyle.AxisLineStyle.GetObjectPath(privLayer, true);

			// calculate size information
			RectangleD bounds1 = _cachedPath.GetBounds();

			if (_axisStyle.ShowMinorLabels)
			{
				var path = _axisStyle.MinorLabelStyle.GetSelectionPath();
				if (path.PointCount > 0)
				{
					_cachedPath.AddPath(path, false);
					RectangleD bounds2 = path.GetBounds();
					bounds1.ExpandToInclude(bounds2);
				}
			}
			if (_axisStyle.ShowMajorLabels)
			{
				var path = _axisStyle.MajorLabelStyle.GetSelectionPath();
				if (path.PointCount > 0)
				{
					_cachedPath.AddPath(path, false);
					RectangleD bounds2 = path.GetBounds();
					bounds1.ExpandToInclude(bounds2);
				}
			}

			this._bounds = new RectangleD(bounds1.Location - this._position, bounds1.Size);

			if (_background != null)
			{
				bounds1.Expand(_backgroundPadding);
				_background.Draw(g, bounds1);
				_axisStyle.Paint(g, privLayer, privLayer.GetAxisStyleInformation);
			}


		}


		


		#region Inner classes

		class LayerSegment : IPlotArea
		{
			IPlotArea _underlyingArea;
			Logical3D _org;
			Logical3D _end;
			int _scaleNumber;

			ScaleCollection _scaleCollection = new ScaleCollection();


			public LayerSegment(IPlotArea underlyingArea, ScaleWithTicks scaleWithTicks, Logical3D org, Logical3D end, int scaleNumber)
			{
				_underlyingArea = underlyingArea;
				_org = org;
				_end = end;
				_scaleNumber = scaleNumber;

				for (int i = 0; i < _underlyingArea.Scales.Count;++i )
				{
					if (i == _scaleNumber)
						_scaleCollection.SetScaleWithTicks(i, scaleWithTicks);
					else
						_scaleCollection.SetScaleWithTicks(i, _underlyingArea.Scales[i]);
				}
			}

			public CSAxisInformation GetAxisStyleInformation(CSLineID lineId)
			{
				var result = new CSAxisInformation( new CSLineID(lineId.ParallelAxisNumber, _org) );
				result.CopyFrom(_underlyingArea.CoordinateSystem.GetAxisStyleInformation(lineId));
				result.LogicalValueAxisOrg = _org[_scaleNumber];
				result.LogicalValueAxisEnd = _end[_scaleNumber];

				return result;
			}

			public bool Is3D
			{
				get { return _underlyingArea.Is3D; }
			}

			public Scale XAxis
			{
				get { return _scaleCollection[0].Scale; }
			}

			public Scale YAxis
			{
				get { return _scaleCollection[1].Scale; }
			}

			public ScaleCollection Scales
			{
				get { return _scaleCollection; }
			}

			public G2DCoordinateSystem CoordinateSystem
			{
				get { return _underlyingArea.CoordinateSystem; }
			}

			public PointD2D Size
			{
				get { throw new NotImplementedException(); }
			}

			public Logical3D GetLogical3D(I3DPhysicalVariantAccessor acc, int idx)
			{
				throw new NotImplementedException();
			}

			public System.Collections.Generic.IEnumerable<CSLineID> AxisStyleIDs
			{
				get { throw new NotImplementedException(); }
			}

			public void UpdateCSPlaneID(CSPlaneID id)
			{
				throw new NotImplementedException();
			}
		}



		/// <summary>
		/// Enumerates the type of scale segment
		/// </summary>
		public enum ScaleSegmentType {
			/// <summary>Scale segment corresponds to the segment of the parent scale.</summary>
			Normal,
			/// <summary>Measures differences from org, thus the physical value of org is evaluated to zero (0).</summary>
			DifferenceToOrg,
			/// <summary>Measures ratios to org, thus the physical value of org is evaluated to one (1).</summary>
			RatioToOrg
		}

		class ScaleSegment : Scale
		{
			double _relOrg;
			double _relEnd;
			Scale _underlyingScale;
			ScaleSegmentType _segmentScaling;

			public ScaleSegment(Scale underlyingScale, double relOrg, double relEnd, ScaleSegmentType scaling)
			{
				if (null == underlyingScale)
					throw new ArgumentNullException("underlyingScale");

				_underlyingScale = underlyingScale;
				_relOrg = relOrg;
				_relEnd = relEnd;
				_segmentScaling = scaling;
			}

			public override object Clone()
			{
				return new ScaleSegment(_underlyingScale, _relOrg, _relEnd, _segmentScaling);
			}

			public override double PhysicalVariantToNormal(Altaxo.Data.AltaxoVariant x)
			{
				switch (_segmentScaling)
				{
					case ScaleSegmentType.DifferenceToOrg:
						x += _underlyingScale.NormalToPhysicalVariant(_relOrg);
						break;
					case ScaleSegmentType.RatioToOrg:
						x *= _underlyingScale.NormalToPhysicalVariant(_relOrg);
						break;
				}

				double r = _underlyingScale.PhysicalVariantToNormal(x);
				return (r - _relOrg) / (_relEnd - _relOrg);
			}

			public override Altaxo.Data.AltaxoVariant NormalToPhysicalVariant(double x)
			{
				double r = _relOrg * (1 - x) + _relEnd * x;
				var y = _underlyingScale.NormalToPhysicalVariant(r);
				switch (_segmentScaling)
				{
					case ScaleSegmentType.DifferenceToOrg:
						y -= _underlyingScale.NormalToPhysicalVariant(_relOrg);
						break;
					case ScaleSegmentType.RatioToOrg:
						y /= _underlyingScale.NormalToPhysicalVariant(_relOrg);
						break;
				}
				return y;
			}

			public override object RescalingObject
			{
				get { return _underlyingScale.RescalingObject; }
			}

			public override Altaxo.Graph.Scales.Boundaries.IPhysicalBoundaries DataBoundsObject
			{
				get { return _underlyingScale.DataBoundsObject; }
			}

			public override Altaxo.Data.AltaxoVariant OrgAsVariant
			{
				get 
				{
					return NormalToPhysicalVariant(0);
				}
			}

			public override Altaxo.Data.AltaxoVariant EndAsVariant
			{
				get
				{
					return NormalToPhysicalVariant(1);
				}
			}

			public override bool IsOrgExtendable
			{
				get { return false; }
			}

			public override bool IsEndExtendable
			{
				get { return false; }
			}

			public override string SetScaleOrgEnd(Altaxo.Data.AltaxoVariant org, Altaxo.Data.AltaxoVariant end)
			{
				
				_relOrg = _underlyingScale.PhysicalVariantToNormal(org);
				_relEnd = _underlyingScale.PhysicalVariantToNormal(end);
				return null;
			}

			public override void Rescale()
			{
			}
		}


		#endregion



		#region HitTestObject

		/// <summary>Creates a new hit test object. Here, a special hit test object is constructed, which suppresses the resize, rotate, scale and shear grips.</summary>
		/// <returns>A newly created hit test object.</returns>
		protected override IHitTestObject GetNewHitTestObject()
		{
			return new MyHitTestObject(this);
		}

		class MyHitTestObject : GraphicBaseHitTestObject
		{
			public MyHitTestObject(FloatingScale obj)
				: base(obj)
			{
			}

			public override IGripManipulationHandle[] GetGrips(double pageScale, int gripLevel)
			{
						return ((FloatingScale)_hitobject).GetGrips(this, pageScale, GripKind.Move);
			}

		}

		#endregion
		

	} // End Class
} // end Namespace
