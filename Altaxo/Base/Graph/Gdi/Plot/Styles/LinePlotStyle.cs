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

using Altaxo.Serialization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Altaxo.Graph.Gdi.Plot.Styles
{
	using Altaxo.Data;
	using Altaxo.Main;
	using Drawing;
	using Drawing.ColorManagement;
	using Geometry;
	using Graph.Plot.Data;
	using Graph.Plot.Groups;
	using Plot.Data;
	using Plot.Groups;

	namespace XYPlotLineStyles
	{
		[Serializable]
		public enum FillDirection
		{
			Left = 0,
			Bottom = 1,
			Right = 2,
			Top = 3
		}

		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.XYPlotLineStyles.FillDirection", 0)]
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(FillDirection), 1)]
		public class FillDirectionXmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				info.SetNodeContent(obj.ToString());
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				string val = info.GetNodeContent();
				return System.Enum.Parse(typeof(FillDirection), val, true);
			}
		}

		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.XYPlotLineStyles.ConnectionStyle", 0)]
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.Gdi.Plot.Styles.XYPlotLineStyles.ConnectionStyle", 1)]
		public class ConnectionStyleXmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				throw new InvalidOperationException("Serialization of old version");
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				string val = info.GetNodeContent();
				switch (val)
				{
					case "NoLine":
						return LineConnectionStyles.NoConnection.Instance;

					case "Straight":
						return LineConnectionStyles.StraightConnection.Instance;

					case "Segment2":
						return LineConnectionStyles.Segment2Connection.Instance;

					case "Segment3":
						return LineConnectionStyles.Segment3Connection.Instance;

					case "Spline":
						return LineConnectionStyles.SplineConnection.Instance;

					case "Bezier":
						return LineConnectionStyles.BezierConnection.Instance;

					case "StepHorz":
						return LineConnectionStyles.StepHorizontalConnection.Instance;

					case "StepVert":
						return LineConnectionStyles.StepVerticalConnection.Instance;

					case "StepHorzCenter":
						return LineConnectionStyles.StepHorizontalCenteredConnection.Instance;

					case "StepVertCenter":
						return LineConnectionStyles.StepVerticalCenteredConnection.Instance;

					default:
						throw new NotImplementedException();
				}
			}
		}
	}

	/// <summary>
	/// Summary description for XYPlotLineStyle.
	/// </summary>
	public class LinePlotStyle
		:
		Main.SuspendableDocumentNodeWithEventArgs,
		IG2DPlotStyle,
		IRoutedPropertyReceiver
	{
		/// <summary>
		/// Template to make a line draw.
		/// </summary>
		/// <param name="g">Graphics context.</param>
		/// <param name="pdata">The plot data. Don't use the Range property of the pdata, since it is overriden by the next argument.</param>
		/// <param name="overriderange">The plot range to use.</param>
		/// <param name="layer">Graphics layer.</param>
		/// <param name="symbolGap">The size of the symbol gap.</param>
		public delegate void PaintOneRangeTemplate(
			Graphics g,
			Processed2DPlotData pdata,
			PlotRange overriderange,
			IPlotArea layer,
			float symbolGap);

		/// <summary>
		/// Template to get a fill path.
		/// </summary>
		/// <param name="gp">Graphics path to fill with data.</param>
		/// <param name="pdata">The plot data. Don't use the Range property of the pdata, since it is overriden by the next argument.</param>
		/// <param name="overriderange">The plot range to use.</param>
		/// <param name="layer">Graphics layer.</param>
		/// <param name="fillDirection">Designates a bound to fill to.</param>
		public delegate void FillPathOneRangeTemplate(
			GraphicsPath gp,
			Processed2DPlotData pdata,
			PlotRange overriderange,
			IPlotArea layer,
			CSPlaneID fillDirection);

		/// <summary>A value indicating whether the skip frequency value is independent from other values.</summary>
		protected bool _independentSkipFreq;

		/// <summary>A value of 2 skips every other data point, a value of 3 skips 2 out of 3 data points, and so on.</summary>
		protected int _skipFreq = 1;

		protected bool _independentColor;

		protected bool _independentDashStyle;

		protected PenX _linePen;

		protected ILineConnectionStyle _connectionStyle;

		/// <summary>
		/// true if the symbol size is independent, i.e. is not published nor updated by a group style.
		/// </summary>
		protected bool _independentSymbolSize;

		/// <summary>Controls the length of the end bar.</summary>
		protected double _symbolSize;

		protected bool _ignoreMissingDataPoints; // treat missing points as if not present (connect lines over missing points)

		/// <summary>If true, the start and the end point of the line are connected too.</summary>
		protected bool _connectCircular;

		protected bool _useSymbolGap;

		/// <summary>
		/// Offset used to calculate the real gap between symbol center and beginning of the bar, according to the formula:
		/// realGap = _symbolGap * _symbolGapFactor + _symbolGapOffset;
		/// </summary>
		private double _symbolGapOffset;

		/// <summary>
		/// Factor used to calculate the real gap between symbol center and beginning of the bar, according to the formula:
		/// realGap = _symbolGap * _symbolGapFactor + _symbolGapOffset;
		/// </summary>
		private double _symbolGapFactor = 1.25;

		/// <summary>If this function is set, then _symbolSize is ignored and the symbol size is evaluated by this function.</summary>
		[field: NonSerialized]
		protected Func<int, double> _cachedSymbolSizeForIndexFunction;

		protected bool _fillArea;
		protected BrushX _fillBrush; // brush to fill the area under the line
		protected CSPlaneID _fillDirection; // the direction to fill

		/// <summary>Designates if the fill color is independent or dependent.</summary>
		protected ColorLinkage _fillColorLinkage = ColorLinkage.PreserveAlpha;

		#region Serialization

		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.XYPlotLineStyle", 0)]
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.XYPlotLineStyle", 1)] // by accident, it was never different from 0
		private class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public virtual void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				throw new InvalidOperationException("Serialization of old version not allowed");
				/*
				LinePlotStyle s = (LinePlotStyle)obj;
				info.AddValue("Pen", s._linePen);
				info.AddValue("Connection", s._connectionStyle);
				info.AddValue("LineSymbolGap", s._useSymbolGap);
				info.AddValue("IgnoreMissingPoints", s._ignoreMissingDataPoints);
				info.AddValue("FillArea", s._fillArea);
				info.AddValue("FillBrush", s._fillBrush);
				info.AddValue("FillDirection", s._fillDirection);
				*/
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				var s = SDeserialize(o, info, parent);
				return s;
			}

			public virtual object SDeserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				LinePlotStyle s = null != o ? (LinePlotStyle)o : new LinePlotStyle(info);

				s._linePen = (PenX)info.GetValue("Pen", s);
				if (null != s._linePen) s._linePen.ParentObject = s;

				s.Connection = (ILineConnectionStyle)info.GetValue("Connection", s);
				s._useSymbolGap = info.GetBoolean("LineSymbolGap");
				s._ignoreMissingDataPoints = info.GetBoolean("IgnoreMissingPoints");
				bool fillArea = info.GetBoolean("FillArea");
				var fillBrush = (BrushX)info.GetValue("FillBrush", s);
				var fillDir = (XYPlotLineStyles.FillDirection)info.GetValue("FillDirection", s);

				if (!fillArea)
				{
					return s;
				}
				else
				{
					var drop = new DropAreaPlotStyle(s.Connection, s.IgnoreMissingDataPoints, false, GetFillDirection(fillDir), fillBrush);
					return new object[] { s, drop };
				}
			}

			public static CSPlaneID GetFillDirection(XYPlotLineStyles.FillDirection fillDir)
			{
				switch (fillDir)
				{
					case XYPlotLineStyles.FillDirection.Bottom:
						return CSPlaneID.Bottom;

					case XYPlotLineStyles.FillDirection.Top:
						return CSPlaneID.Top;

					case XYPlotLineStyles.FillDirection.Left:
						return CSPlaneID.Left;

					case XYPlotLineStyles.FillDirection.Right:
						return CSPlaneID.Right;
				}
				return null;
			}
		}

		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.XYPlotLineStyle", 2)]
		private class XmlSerializationSurrogate2 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				throw new InvalidOperationException("Try to serialize old version");
				/*
				base.Serialize(obj, info);
				LinePlotStyle s = (LinePlotStyle)obj;
				info.AddValue("IndependentColor", s._independentColor);
				*/
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				LinePlotStyle s = null != o ? (LinePlotStyle)o : new LinePlotStyle(info);

				s._linePen = (PenX)info.GetValue("Pen", s);
				if (null != s._linePen) s._linePen.ParentObject = s;

				s.Connection = (ILineConnectionStyle)info.GetValue("Connection", s);
				s._useSymbolGap = info.GetBoolean("LineSymbolGap");
				s._ignoreMissingDataPoints = info.GetBoolean("IgnoreMissingPoints");
				bool fillArea = info.GetBoolean("FillArea");
				var fillBrush = (BrushX)info.GetValue("FillBrush", s);
				var fillDir = (XYPlotLineStyles.FillDirection)info.GetValue("FillDirection", s);
				s._independentColor = info.GetBoolean("IndependentColor");

				if (!fillArea)
				{
					return s;
				}
				else
				{
					var drop = new DropAreaPlotStyle(s.Connection, s.IgnoreMissingDataPoints, false, XmlSerializationSurrogate0.GetFillDirection(fillDir), fillBrush);
					return new object[] { s, drop };
				}
			}
		}

		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.Gdi.Plot.Styles.LinePlotStyle", 3)]
		private class XmlSerializationSurrogate3 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				throw new InvalidOperationException("Try to serialize old version");
				/*
				base.Serialize(obj, info);
				LinePlotStyle s = (LinePlotStyle)obj;
				info.AddValue("IndependentColor", s._independentColor);
				info.AddValue("IndependentFillColor", s._independentFillColor);
				info.AddValue("ConnectCircular", s._connectCircular);
				*/
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				LinePlotStyle s = null != o ? (LinePlotStyle)o : new LinePlotStyle(info);

				s._linePen = (PenX)info.GetValue("Pen", s);
				if (null != s._linePen) s._linePen.ParentObject = s;

				s.Connection = (ILineConnectionStyle)info.GetValue("Connection", s);
				s._useSymbolGap = info.GetBoolean("LineSymbolGap");
				s._ignoreMissingDataPoints = info.GetBoolean("IgnoreMissingPoints");
				bool fillArea = info.GetBoolean("FillArea");
				var fillBrush = (BrushX)info.GetValue("FillBrush", s);
				var fillDir = (CSPlaneID)info.GetValue("FillDirection", s);
				s._independentColor = info.GetBoolean("IndependentColor");
				s._fillColorLinkage = info.GetBoolean("IndependentFillColor") ? ColorLinkage.Independent : ColorLinkage.PreserveAlpha;
				s._connectCircular = info.GetBoolean("ConnectCircular");

				if (!fillArea)
				{
					return s;
				}
				else
				{
					var drop = new DropAreaPlotStyle(s.Connection, s.IgnoreMissingDataPoints, false, fillDir, fillBrush);
					return new object[] { s, drop };
				}
			}
		}

		/// <summary>
		/// <para>Date: 2012-10-10</para>
		/// Change: instead _independentFillColor being a boolean value, it is now a ColorLinkage enumeration value
		/// </summary>
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.Gdi.Plot.Styles.LinePlotStyle", 4)]
		private class XmlSerializationSurrogate4 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				throw new InvalidOperationException("Serialization of old version not allowed");
				/*
				base.Serialize(obj, info);
				LinePlotStyle s = (LinePlotStyle)obj;
				info.AddValue("IndependentColor", s._independentColor);
				info.AddEnum("FillColorLinkage", s._fillColorLinkage);
				info.AddValue("ConnectCircular", s._connectCircular);
				*/
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				LinePlotStyle s = null != o ? (LinePlotStyle)o : new LinePlotStyle(info);

				s._linePen = (PenX)info.GetValue("Pen", s);
				s.Connection = (ILineConnectionStyle)info.GetValue("Connection", s);
				s._useSymbolGap = info.GetBoolean("LineSymbolGap");
				s._ignoreMissingDataPoints = info.GetBoolean("IgnoreMissingPoints");
				bool fillArea = info.GetBoolean("FillArea");
				var fillBrush = (BrushX)info.GetValue("FillBrush", s);
				var fillDir = (CSPlaneID)info.GetValue("FillDirection", s);
				s._independentColor = info.GetBoolean("IndependentColor");
				s._fillColorLinkage = (ColorLinkage)info.GetEnum("FillColorLinkage", typeof(ColorLinkage));
				s._connectCircular = info.GetBoolean("ConnectCircular");

				if (!fillArea)
				{
					return s;
				}
				else
				{
					var drop = new DropAreaPlotStyle(s.Connection, s.IgnoreMissingDataPoints, false, fillDir, fillBrush);
					return new object[] { s, drop };
				}
			}
		}

		/// <summary>
		/// 2016-11-04 Major changes: Fill style is now in a separate style. Many new properties.
		/// </summary>
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(LinePlotStyle), 5)]
		private class XmlSerializationSurrogate5 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				var s = (LinePlotStyle)obj;

				info.AddValue("IndependentSkipFreq", s._independentSkipFreq);
				info.AddValue("SkipFreq", s._skipFreq);

				info.AddValue("IgnoreMissingPoints", s._ignoreMissingDataPoints);
				info.AddValue("ConnectCircular", s._connectCircular);
				info.AddValue("Connection", s._connectionStyle);

				info.AddValue("Pen", s._linePen);
				info.AddValue("IndependentDashStyle", s._independentDashStyle);
				info.AddValue("IndependentColor", s._independentColor);

				info.AddValue("IndependentSymbolSize", s._independentSymbolSize);
				info.AddValue("SymbolSize", s._symbolSize);

				info.AddValue("UseSymbolGap", s._useSymbolGap);
				info.AddValue("SymbolGapOffset", s._symbolGapOffset);
				info.AddValue("SymbolGapFactor", s._symbolGapFactor);
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				LinePlotStyle s = (LinePlotStyle)o ?? new LinePlotStyle(info);

				s._independentSkipFreq = info.GetBoolean("IndependentSkipFreq");
				s._skipFreq = info.GetInt32("SkipFreq");

				s._ignoreMissingDataPoints = info.GetBoolean("IgnoreMissingPoints");
				s._connectCircular = info.GetBoolean("ConnectCircular");
				s._connectionStyle = (ILineConnectionStyle)info.GetValue("Connection", s);

				s._linePen = (PenX)info.GetValue("Pen", s); if (null != s._linePen) s._linePen.ParentObject = s;

				s._independentDashStyle = info.GetBoolean("IndependentDashStyle");
				s._independentColor = info.GetBoolean("IndependentColor");

				s._independentSymbolSize = info.GetBoolean("IndependentSymbolSize");
				s._symbolSize = info.GetDouble("SymbolSize");

				s._useSymbolGap = info.GetBoolean("UseSymbolGap");
				s._symbolGapOffset = info.GetDouble("SymbolGapOffset");
				s._symbolGapFactor = info.GetDouble("SymbolGapFactor");

				return s;
			}
		}

		#endregion Serialization

		#region Construction and copying

		public void CopyFrom(LinePlotStyle from, Main.EventFiring eventFiring)
		{
			if (object.ReferenceEquals(this, from))
				return;

			using (var suspendToken = SuspendGetToken())
			{
				this._independentSkipFreq = from._independentSkipFreq;
				this._skipFreq = from._skipFreq;

				this._ignoreMissingDataPoints = from._ignoreMissingDataPoints;
				this._connectCircular = from._connectCircular;
				this._connectionStyle = from._connectionStyle;

				this._linePen = null == from._linePen ? null : (PenX)from._linePen.Clone();
				this._independentDashStyle = from._independentDashStyle;
				this._independentColor = from._independentColor;

				this._independentSymbolSize = from._independentSymbolSize;
				this._symbolSize = from._symbolSize;

				this._useSymbolGap = from._useSymbolGap;
				this._symbolGapOffset = from._symbolGapOffset;
				this._symbolGapFactor = from._symbolGapFactor;

				this._fillArea = from._fillArea;
				this._fillBrush = null == from._fillBrush ? null : (BrushX)from._fillBrush.Clone();
				this._fillDirection = from._fillDirection;
				this._fillColorLinkage = from._fillColorLinkage;

				EhSelfChanged();

				suspendToken.Resume(eventFiring);
			}
		}

		/// <inheritdoc/>
		public bool CopyFrom(object obj, bool copyWithDataReferences)
		{
			if (object.ReferenceEquals(this, obj))
				return true;
			var from = obj as LinePlotStyle;
			if (null != from)
			{
				CopyFrom(from, Main.EventFiring.Enabled);
				return true;
			}
			return false;
		}

		/// <inheritdoc/>
		public bool CopyFrom(object obj)
		{
			return CopyFrom(obj, true);
		}

		/// <inheritdoc/>
		public object Clone(bool copyWithDataReferences)
		{
			return new LinePlotStyle(this);
		}

		/// <inheritdoc/>
		public object Clone()
		{
			return new LinePlotStyle(this);
		}

		protected LinePlotStyle(Altaxo.Serialization.Xml.IXmlDeserializationInfo info)
		{
			_connectionStyle = LineConnectionStyles.StraightConnection.Instance;
		}

		internal LinePlotStyle(Altaxo.Serialization.Xml.IXmlDeserializationInfo info, bool oldDeserializationRequiresFullConstruction)
		{
			var penWidth = 1;
			var color = ColorSetManager.Instance.BuiltinDarkPlotColors[0];

			_linePen = new PenX(color, penWidth) { LineJoin = LineJoin.Bevel };
			_useSymbolGap = true;
			_ignoreMissingDataPoints = false;
			_fillArea = false;
			_fillBrush = new BrushX(color);
			_fillDirection = null;
			_connectionStyle = LineConnectionStyles.StraightConnection.Instance;
			_independentColor = false;

			CreateEventChain();
		}

		public LinePlotStyle(Altaxo.Main.Properties.IReadOnlyPropertyBag context)
		{
			var penWidth = GraphDocument.GetDefaultPenWidth(context);
			var color = GraphDocument.GetDefaultPlotColor(context);

			_linePen = new PenX(color, penWidth) { LineJoin = LineJoin.Bevel };
			_useSymbolGap = true;
			_ignoreMissingDataPoints = false;
			_fillArea = false;
			_fillBrush = new BrushX(color);
			_fillDirection = null;
			_connectionStyle = LineConnectionStyles.StraightConnection.Instance;
			_independentColor = false;

			CreateEventChain();
		}

		public LinePlotStyle(LinePlotStyle from)
		{
			CopyFrom(from, Main.EventFiring.Suppressed);
			CreateEventChain();
		}

		protected override IEnumerable<Main.DocumentNodeAndName> GetDocumentNodeChildrenWithName()
		{
			if (null != _linePen)
				yield return new Main.DocumentNodeAndName(_linePen, "Pen");

			if (null != _fillBrush)
				yield return new Main.DocumentNodeAndName(_fillBrush, "FillBrush");
		}

		protected virtual void CreateEventChain()
		{
			if (null != _linePen)
				_linePen.ParentObject = this;

			if (null != _fillBrush)
				_fillBrush.ParentObject = this;
		}

		#endregion Construction and copying

		#region Properties

		/// <summary>Skip frequency. A value of 2 skips every other data point, a value of 3 skips 2 out of 3 data points, and so on.</summary>
		public int SkipFrequency
		{
			get { return _skipFreq; }
			set
			{
				value = Math.Max(1, value);
				if (!(_skipFreq == value))
				{
					_skipFreq = value;
					EhSelfChanged(EventArgs.Empty); // Fire Changed event
				}
			}
		}

		/// <summary>A value indicating whether the skip frequency value is independent from values in other sub plot styles.</summary>
		public bool IndependentSkipFrequency
		{
			get
			{
				return _independentSkipFreq;
			}
			set
			{
				if (!(_independentSkipFreq == value))
				{
					_independentSkipFreq = value;
					EhSelfChanged(EventArgs.Empty);
				}
			}
		}

		public ILineConnectionStyle Connection
		{
			get { return _connectionStyle; }
			set
			{
				if (null == value)
					throw new ArgumentNullException(nameof(value));

				if (!(_connectionStyle.Equals(value)))
				{
					_connectionStyle = value;
					EhSelfChanged();
				}
			}
		}

		/// <summary>
		/// True when the line is not drawn in the circle of diameter SymbolSize around the symbol center.
		/// </summary>
		public bool UseSymbolGap
		{
			get
			{
				return _useSymbolGap;
			}
			set
			{
				if (!(_useSymbolGap == value))
				{
					_useSymbolGap = value;
					EhSelfChanged(EventArgs.Empty);
				}
			}
		}

		public double SymbolGapOffset
		{
			get
			{
				return _symbolGapOffset;
			}
			set
			{
				if (!(_symbolGapOffset == value))
				{
					_symbolGapOffset = value;
					EhSelfChanged();
				}
			}
		}

		public double SymbolGapFactor
		{
			get
			{
				return _symbolGapFactor;
			}
			set
			{
				if (!(_symbolGapFactor == value))
				{
					_symbolGapFactor = value;
					EhSelfChanged();
				}
			}
		}

		public bool ConnectCircular
		{
			get
			{
				return _connectCircular;
			}
			set
			{
				bool oldValue = _connectCircular;
				_connectCircular = value;
				if (value != oldValue)
					EhSelfChanged(EventArgs.Empty);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether to ignore missing data points. If the value is set to true,
		/// the line is plotted even if there is a gap in the data points.
		/// </summary>
		/// <value>
		/// <c>true</c> if missing data points should be ignored; otherwise, if <c>false</c>, no line is plotted between a gap in the data.
		/// </value>
		public bool IgnoreMissingDataPoints
		{
			get
			{
				return _ignoreMissingDataPoints;
			}
			set
			{
				bool oldValue = _ignoreMissingDataPoints;
				_ignoreMissingDataPoints = value;
				if (value != oldValue)
					EhSelfChanged(EventArgs.Empty);
			}
		}

		public bool IndependentLineColor
		{
			get
			{
				return _independentColor;
			}
			set
			{
				bool oldValue = _independentColor;
				_independentColor = value;
				if (value != oldValue)
					EhSelfChanged(EventArgs.Empty);
			}
		}

		public bool IndependentDashStyle
		{
			get
			{
				return _independentDashStyle;
			}
			set
			{
				bool oldValue = _independentDashStyle;
				_independentDashStyle = value;
				if (value != oldValue)
					EhSelfChanged(EventArgs.Empty);
			}
		}

		public PenX LinePen
		{
			get { return _linePen; }
			set
			{
				if (null == value)
					throw new ArgumentNullException(nameof(value));

				if (ChildCopyToMember(ref _linePen, value))
					EhSelfChanged();
			}
		}

		/// <summary>
		/// true if the symbol size is independent, i.e. is not published nor updated by a group style.
		/// </summary>
		public bool IndependentSymbolSize
		{
			get { return _independentSymbolSize; }
			set
			{
				var oldValue = _independentSymbolSize;
				_independentSymbolSize = value;
				if (oldValue != value)
					EhSelfChanged(EventArgs.Empty);
			}
		}

		/// <summary>Controls the length of the end bar.</summary>
		public double SymbolSize
		{
			get { return _symbolSize; }
			set
			{
				var oldValue = _symbolSize;
				_symbolSize = value;
				if (oldValue != value)
					EhSelfChanged(EventArgs.Empty);
			}
		}

		public ColorLinkage FillColorLinkage
		{
			get
			{
				return _fillColorLinkage;
			}
			set
			{
				var oldValue = _fillColorLinkage;
				_fillColorLinkage = value;
				if (value != oldValue)
					EhSelfChanged(EventArgs.Empty);
			}
		}

		public bool FillArea
		{
			get { return this._fillArea; }
			set
			{
				this._fillArea = value;
				// ensure that if value is true, there is a fill brush which is not null
				if (true == value && null == this._fillBrush)
					this._fillBrush = new BrushX(NamedColors.White);

				EhSelfChanged(EventArgs.Empty); // Fire Changed event
			}
		}

		public CSPlaneID FillDirection
		{
			get { return this._fillDirection; }
			set
			{
				CSPlaneID oldvalue = _fillDirection;
				_fillDirection = value;
				if (oldvalue != value)
				{
					EhSelfChanged(EventArgs.Empty); // Fire Changed event
				}
			}
		}

		public BrushX FillBrush
		{
			get { return this._fillBrush; }
			set
			{
				// copy the brush only if not null
				if (null != value)
				{
					this._fillBrush = (BrushX)value.Clone();
					this._fillBrush.ParentObject = this;
					EhSelfChanged(EventArgs.Empty); // Fire Changed event
				}
				else
					throw new ArgumentNullException("FillBrush", "FillBrush must not be set to null, instead set FillArea to false");
			}
		}

		public bool IsVisible
		{
			get
			{
				if (!LineConnectionStyles.NoConnection.Instance.Equals(_connectionStyle))
					return true;
				if (_fillArea)
					return true;

				return false;
			}
		}

		#endregion Properties

		#region Painting

		public virtual void PaintLine(Graphics g, PointF beg, PointF end)
		{
			if (null != _linePen)
			{
				g.DrawLine(_linePen, beg, end);
			}
		}

		/// <summary>
		/// Prepares the scale of this plot style. Since this style does not utilize a scale, this function does nothing.
		/// </summary>
		/// <param name="layer">The parent layer.</param>
		public void PrepareScales(IPlotArea layer)
		{
		}

		public RectangleF PaintSymbol(System.Drawing.Graphics g, System.Drawing.RectangleF bounds)
		{
			if (!LineConnectionStyles.NoConnection.Instance.Equals(_connectionStyle))
			{
				GraphicsState gs = g.Save();
				g.TranslateTransform(bounds.X + 0.5f * bounds.Width, bounds.Y + 0.5f * bounds.Height);
				float halfwidth = bounds.Width / 2;
				float symsize = (float)(_symbolSize);

				if (this.UseSymbolGap == true)
				{
					// plot a line with the length of symbolsize from
					PaintLine(g, new PointF(-halfwidth, 0), new PointF(-symsize, 0));
					PaintLine(g, new PointF(symsize, 0), new PointF(halfwidth, 0));
				}
				else // no gap
				{
					PaintLine(g, new PointF(-halfwidth, 0), new PointF(halfwidth, 0));
				}
				g.Restore(gs);
			}

			return bounds;
		}

		public void Paint(Graphics g, IPlotArea layer, Processed2DPlotData pdata, Processed2DPlotData prevItemData, Processed2DPlotData nextItemData)
		{
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			PlotRangeList rangeList = pdata.RangeList;
			float symbolGap = (float)(_symbolSize);
			int rangelistlen = rangeList.Count;

			Func<int, double> symbolGapFunction = null;

			if (_useSymbolGap)
			{
				if (null != _cachedSymbolSizeForIndexFunction && !_independentSymbolSize)
				{
					symbolGapFunction = (idx) => _symbolGapOffset + _symbolGapFactor * _cachedSymbolSizeForIndexFunction(idx);
				}
				else
				{
					symbolGapFunction = (idx) => _symbolGapOffset + _symbolGapFactor * _symbolSize;
				}
			}

			// ensure that brush and pen are cached
			if (null != _linePen) _linePen.Cached = true;

			if (_fillArea)
			{
				if (null != _fillBrush)
					_fillBrush.SetEnvironment(new RectangleD2D(PointD2D.Empty, layer.Size), BrushX.GetEffectiveMaximumResolution(g, 1));

				_fillDirection = layer.UpdateCSPlaneID(_fillDirection);
			}

			if (this._ignoreMissingDataPoints)
			{
				// in case we ignore the missing points, all ranges can be plotted
				// as one range, i.e. continuously
				// for this, we create the totalRange, which contains all ranges
				PlotRange totalRange = new PlotRange(rangeList[0].LowerBound, rangeList[rangelistlen - 1].UpperBound);
				_connectionStyle.Paint(g, pdata, totalRange, layer, _linePen, symbolGapFunction, _skipFreq, _connectCircular, this);
			}
			else // we not ignore missing points, so plot all ranges separately
			{
				for (int i = 0; i < rangelistlen; i++)
				{
					_connectionStyle.Paint(g, pdata, rangeList[i], layer, _linePen, symbolGapFunction, _skipFreq, _connectCircular, this);
				}
			}
		}

		public void GetFillPath(GraphicsPath gp, IPlotArea layer, Processed2DPlotData pdata, CSPlaneID fillDirection)
		{
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			PlotRangeList rangeList = pdata.RangeList;
			fillDirection = layer.UpdateCSPlaneID(fillDirection);

			int rangelistlen = rangeList.Count;

			if (this._ignoreMissingDataPoints)
			{
				// in case we ignore the missing points, all ranges can be plotted
				// as one range, i.e. continuously
				// for this, we create the totalRange, which contains all ranges
				PlotRange totalRange = new PlotRange(rangeList[0].LowerBound, rangeList[rangelistlen - 1].UpperBound);
				_connectionStyle.FillOneRange(gp, pdata, totalRange, layer, fillDirection, _ignoreMissingDataPoints, _connectCircular);
			}
			else // we not ignore missing points, so plot all ranges separately
			{
				for (int i = 0; i < rangelistlen; i++)
				{
					_connectionStyle.FillOneRange(gp, pdata, rangeList[i], layer, fillDirection, _ignoreMissingDataPoints, _connectCircular);
				}
			}
		}

		#endregion Painting

		#region NoConnection

		public void NoConnection_PaintOneRange(
			Graphics g,
			Processed2DPlotData pdata,
			PlotRange range,
			IPlotArea layer,
			float symbolGap)
		{
		}

		public void NoConnection_FillOneRange(GraphicsPath gp,
		 Processed2DPlotData pdata,
		 PlotRange range,
		 IPlotArea layer,
		 CSPlaneID fillDirection
		 )
		{
		}

		#endregion NoConnection

		#region StraightConnection

		public void StraightConnection_PaintOneRange(
			Graphics g,
			Processed2DPlotData pdata,
			PlotRange range,
			IPlotArea layer,
			float symbolGap)
		{
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			PointF[] linepts = new PointF[range.Length + (_connectCircular ? 1 : 0)];
			Array.Copy(linePoints, range.LowerBound, linepts, 0, range.Length); // Extract
			if (_connectCircular) linepts[linepts.Length - 1] = linepts[0];
			int lastIdx = range.Length - 1 + (_connectCircular ? 1 : 0);
			GraphicsPath gp = new GraphicsPath();
			var layerSize = layer.Size;

			if (_fillArea)
			{
				StraightConnection_FillOneRange(gp, pdata, range, layer, _fillDirection, linepts);
				g.FillPath(this._fillBrush, gp);
				gp.Reset();
			}

			// special efforts are necessary to realize a line/symbol gap
			// I decided to use a path for this
			// and hope that not so many segments are added to the path due
			// to the exclusion criteria that a line only appears between two symbols (rel<0.5)
			// if the symbols do not overlap. So for a big array of points it is very likely
			// that the symbols overlap and no line between the symbols needs to be plotted
			if (this._useSymbolGap && symbolGap > 0)
			{
				float xdiff, ydiff, rel, startx, starty, stopx, stopy;
				for (int i = 0; i < lastIdx; i++)
				{
					xdiff = linepts[i + 1].X - linepts[i].X;
					ydiff = linepts[i + 1].Y - linepts[i].Y;
					rel = (float)(symbolGap / System.Math.Sqrt(xdiff * xdiff + ydiff * ydiff));
					if (rel < 0.5) // a line only appears if the relative gap is smaller 1/2
					{
						startx = linepts[i].X + rel * xdiff;
						starty = linepts[i].Y + rel * ydiff;
						stopx = linepts[i + 1].X - rel * xdiff;
						stopy = linepts[i + 1].Y - rel * ydiff;

						gp.AddLine(startx, starty, stopx, stopy);
						gp.StartFigure();
					}
				} // end for
				g.DrawPath(this._linePen, gp);
				gp.Reset();
			}
			else // no line symbol gap required, so we can use DrawLines to draw the lines
			{
				if (linepts.Length > 1) // we don't want to have a drawing exception if number of points is only one
				{
					g.DrawLines(this._linePen, linepts);
				}
			}
		} // end function PaintOneRange

		public void StraightConnection_FillOneRange(GraphicsPath gp,
			Processed2DPlotData pdata,
			PlotRange range,
			IPlotArea layer,
			CSPlaneID fillDirection
			)
		{
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			PointF[] linepts = new PointF[range.Length + (_connectCircular ? 1 : 0)];
			Array.Copy(linePoints, range.LowerBound, linepts, 0, range.Length); // Extract
			if (_connectCircular) linepts[linepts.Length - 1] = linepts[0];

			StraightConnection_FillOneRange(gp, pdata, range, layer, fillDirection, linepts);
		}

		private void StraightConnection_FillOneRange(GraphicsPath gp,
			Processed2DPlotData pdata,
			PlotRange range,
			IPlotArea layer,
			CSPlaneID fillDirection,
			PointF[] linepts
			)
		{
			Logical3D r0 = layer.GetLogical3D(pdata, range.OriginalFirstPoint);
			layer.CoordinateSystem.GetIsolineFromPlaneToPoint(gp, fillDirection, r0);
			gp.AddLines(linepts);
			Logical3D r1 = layer.GetLogical3D(pdata, _connectCircular ? range.OriginalFirstPoint : range.OriginalLastPoint);
			layer.CoordinateSystem.GetIsolineFromPointToPlane(gp, r1, fillDirection);
			layer.CoordinateSystem.GetIsolineOnPlane(gp, fillDirection, r1, r0);
			gp.CloseFigure();
		}

		#endregion StraightConnection

		#region SplineConnection

		public void SplineConnection_PaintOneRange(
			Graphics g,
			Processed2DPlotData pdata,
			PlotRange range,
			IPlotArea layer,
			float symbolGap)
		{
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			PointF[] linepts = new PointF[range.Length];
			Array.Copy(linePoints, range.LowerBound, linepts, 0, range.Length); // Extract
			int lastIdx = range.Length - 1;
			GraphicsPath gp = new GraphicsPath();
			var layerSize = layer.Size;

			if (_fillArea)
			{
				SplineConnection_FillOneRange(gp, pdata, range, layer, _fillDirection, linepts);
				g.FillPath(this._fillBrush, gp);
				gp.Reset();
			}

			// unfortuately, there is no easy way to support line/symbol gaps
			// thats why I ignore this value and draw a curve through the points
			g.DrawCurve(this._linePen, linepts);
		} // end function PaintOneRange (Spline)

		public void SplineConnection_FillOneRange(GraphicsPath gp,
		 Processed2DPlotData pdata,
		 PlotRange range,
		 IPlotArea layer,
		 CSPlaneID fillDirection
		 )
		{
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			PointF[] linepts = new PointF[range.Length];
			Array.Copy(linePoints, range.LowerBound, linepts, 0, range.Length); // Extract

			SplineConnection_FillOneRange(gp, pdata, range, layer, fillDirection, linepts);
		}

		private void SplineConnection_FillOneRange(GraphicsPath gp,
			Processed2DPlotData pdata,
			PlotRange range,
			IPlotArea layer,
			CSPlaneID fillDirection,
			PointF[] linepts
			)
		{
			Logical3D r0 = layer.GetLogical3D(pdata, range.OriginalFirstPoint);
			layer.CoordinateSystem.GetIsolineFromPlaneToPoint(gp, fillDirection, r0);
			gp.AddCurve(linepts);
			Logical3D r1 = layer.GetLogical3D(pdata, range.OriginalLastPoint);
			layer.CoordinateSystem.GetIsolineFromPointToPlane(gp, r1, fillDirection);
			layer.CoordinateSystem.GetIsolineOnPlane(gp, fillDirection, r1, r0);

			gp.CloseFigure();
		}

		#endregion SplineConnection

		#region BezierConnection

		public void BezierConnection_PaintOneRange(
			Graphics g,
			Processed2DPlotData pdata,
			PlotRange rangeRaw,
			IPlotArea layer,
			float symbolGap)
		{
			// Bezier is only supported with point numbers n=4+3*k
			// so trim the range appropriately
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			PlotRange range = new PlotRange(rangeRaw);
			var layerSize = layer.Size;
			range.UpperBound = range.LowerBound + 3 * ((range.Length + 2) / 3) - 2;
			if (range.Length < 4)
				return; // then to less points are in this range

			PointF[] linepts = new PointF[range.Length];
			Array.Copy(linePoints, range.LowerBound, linepts, 0, range.Length); // Extract
			int lastIdx = range.Length - 1;
			GraphicsPath gp = new GraphicsPath();

			if (_fillArea)
			{
				BezierConnection_FillOneRange(gp, pdata, range, layer, _fillDirection, linepts);
				g.FillPath(this._fillBrush, gp);
				gp.Reset();
			}

			// unfortuately, there is no easy way to support line/symbol gaps
			// thats why I ignore this value and draw a curve through the points
			g.DrawBeziers(this._linePen, linepts);
		} // end function PaintOneRange BezierLineStyle

		public void BezierConnection_FillOneRange(GraphicsPath gp,
		Processed2DPlotData pdata,
		PlotRange rangeRaw,
		IPlotArea layer,
		CSPlaneID fillDirection
		)
		{
			// Bezier is only supported with point numbers n=4+3*k
			// so trim the range appropriately
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			PlotRange range = new PlotRange(rangeRaw);
			var layerSize = layer.Size;
			range.UpperBound = range.LowerBound + 3 * ((range.Length + 2) / 3) - 2;
			if (range.Length < 4)
				return; // then to less points are in this range

			PointF[] linepts = new PointF[range.Length];
			Array.Copy(linePoints, range.LowerBound, linepts, 0, range.Length); // Extract

			BezierConnection_FillOneRange(gp, pdata, range, layer, fillDirection, linepts);
		}

		public void BezierConnection_FillOneRange(GraphicsPath gp,
		 Processed2DPlotData pdata,
		 PlotRange range,
		 IPlotArea layer,
		 CSPlaneID fillDirection,
		 PointF[] linepts
		 )
		{
			Logical3D r0 = layer.GetLogical3D(pdata, range.OriginalFirstPoint);
			layer.CoordinateSystem.GetIsolineFromPlaneToPoint(gp, fillDirection, r0);
			gp.AddBeziers(linepts);
			Logical3D r1 = layer.GetLogical3D(pdata, range.OriginalLastPoint);
			layer.CoordinateSystem.GetIsolineFromPointToPlane(gp, r1, fillDirection);
			layer.CoordinateSystem.GetIsolineOnPlane(gp, fillDirection, r1, r0);

			gp.CloseFigure();
		}

		#endregion BezierConnection

		#region StepHorzConnection

		public void StepHorzConnection_PaintOneRange(
			Graphics g,
			Processed2DPlotData pdata,
			PlotRange range,
			IPlotArea layer,
			float symbolGap)
		{
			if (range.Length < 2)
				return;

			int lastIdx;
			PointF[] linepts = StepHorzConnection_GetSubPoints(pdata, range, layer, out lastIdx);
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;

			GraphicsPath gp = new GraphicsPath();

			if (_fillArea)
			{
				StepHorzConnection_FillOneRange(gp, pdata, range, layer, _fillDirection, linepts);
				g.FillPath(this._fillBrush, gp);
				gp.Reset();
			}

			if (this._useSymbolGap && symbolGap > 0)
			{
				int end = range.UpperBound - 1;
				float symbolGapSquared = symbolGap * symbolGap;
				for (int j = range.LowerBound; j < end; j++)
				{
					float xmiddle = linePoints[j + 1].X;
					float ymiddle = linePoints[j].Y;

					// decide if horz line is necessary
					float xdiff = System.Math.Abs(linePoints[j + 1].X - linePoints[j].X);
					float ydiff = System.Math.Abs(linePoints[j + 1].Y - linePoints[j].Y);

					float xrel1 = symbolGap / xdiff;
					float xrel2 = ydiff > symbolGap ? 1 : (float)(1 - System.Math.Sqrt(symbolGapSquared - ydiff * ydiff) / xdiff);

					float yrel1 = xdiff > symbolGap ? 0 : (float)(System.Math.Sqrt(symbolGapSquared - xdiff * xdiff) / ydiff);
					float yrel2 = 1 - symbolGap / ydiff;

					xdiff = linePoints[j + 1].X - linePoints[j].X;
					ydiff = linePoints[j + 1].Y - linePoints[j].Y;

					if (xrel1 < xrel2)
						gp.AddLine(linePoints[j].X + xrel1 * xdiff, linePoints[j].Y, linePoints[j].X + xrel2 * xdiff, linePoints[j].Y);

					if (yrel1 < yrel2)
						gp.AddLine(linePoints[j + 1].X, linePoints[j].Y + yrel1 * ydiff, linePoints[j + 1].X, linePoints[j].Y + yrel2 * ydiff);

					if (xrel1 < xrel2 || yrel1 < yrel2)
						gp.StartFigure();
				}
				g.DrawPath(this._linePen, gp);
				gp.Reset();
			}
			else
			{
				g.DrawLines(this._linePen, linepts);
			}
		} // end function PaintOneRange StepHorzLineStyle

		private PointF[] StepHorzConnection_GetSubPoints(
	 Processed2DPlotData pdata,
	 PlotRange range,
	 IPlotArea layer,
			out int lastIndex)
		{
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			var layerSize = layer.Size;
			PointF[] linepts = new PointF[range.Length * 2 - 1];
			int end = range.UpperBound - 1;
			int i, j;
			for (i = 0, j = range.LowerBound; j < end; i += 2, j++)
			{
				linepts[i] = linePoints[j];
				linepts[i + 1].X = linePoints[j + 1].X;
				linepts[i + 1].Y = linePoints[j].Y;
			}
			linepts[i] = linePoints[j];
			lastIndex = i;
			return linepts;
		}

		public void StepHorzConnection_FillOneRange(GraphicsPath gp,
		Processed2DPlotData pdata,
		PlotRange range,
		IPlotArea layer,
		CSPlaneID fillDirection
		)
		{
			if (range.Length < 2)
				return;

			int lastIdx;
			PointF[] linepts = StepHorzConnection_GetSubPoints(pdata, range, layer, out lastIdx);
			StepHorzConnection_FillOneRange(gp, pdata, range, layer, fillDirection, linepts);
		}

		private void StepHorzConnection_FillOneRange(GraphicsPath gp,
		Processed2DPlotData pdata,
		PlotRange range,
		IPlotArea layer,
			CSPlaneID fillDirection,
		PointF[] linepts
		)
		{
			Logical3D r0 = layer.GetLogical3D(pdata, range.OriginalFirstPoint);
			layer.CoordinateSystem.GetIsolineFromPlaneToPoint(gp, fillDirection, r0);
			gp.AddLines(linepts);
			Logical3D r1 = layer.GetLogical3D(pdata, range.OriginalLastPoint);
			layer.CoordinateSystem.GetIsolineFromPointToPlane(gp, r1, fillDirection);
			layer.CoordinateSystem.GetIsolineOnPlane(gp, fillDirection, r1, r0);
			gp.CloseFigure();
		}

		#endregion StepHorzConnection

		#region StepVertConnection

		public void StepVertConnection_PaintOneRange(
			Graphics g,
			Processed2DPlotData pdata,
			PlotRange range,
			IPlotArea layer,
			float symbolGap)
		{
			if (range.Length < 2)
				return;

			int lastIdx;
			PointF[] linepts = StepVertConnection_GetSubPoints(pdata, range, layer, out lastIdx);
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;

			GraphicsPath gp = new GraphicsPath();

			if (_fillArea)
			{
				StepVertConnection_FillOneRange(gp, pdata, range, layer, _fillDirection, linepts);
				g.FillPath(this._fillBrush, gp);
				gp.Reset();
			}

			if (this._useSymbolGap && symbolGap > 0)
			{
				int end = range.UpperBound - 1;
				float symbolGapSquared = symbolGap * symbolGap;
				for (int j = range.LowerBound; j < end; j++)
				{
					float xmiddle = linePoints[j + 1].X;
					float ymiddle = linePoints[j].Y;

					// decide if horz line is necessary
					float xdiff = System.Math.Abs(linePoints[j + 1].X - linePoints[j].X);
					float ydiff = System.Math.Abs(linePoints[j + 1].Y - linePoints[j].Y);

					float yrel1 = symbolGap / ydiff;
					float yrel2 = xdiff > symbolGap ? 1 : (float)(1 - System.Math.Sqrt(symbolGapSquared - xdiff * xdiff) / ydiff);

					float xrel1 = ydiff > symbolGap ? 0 : (float)(System.Math.Sqrt(symbolGapSquared - ydiff * ydiff) / xdiff);
					float xrel2 = 1 - symbolGap / xdiff;

					xdiff = linePoints[j + 1].X - linePoints[j].X;
					ydiff = linePoints[j + 1].Y - linePoints[j].Y;

					if (yrel1 < yrel2)
						gp.AddLine(linePoints[j].X, linePoints[j].Y + yrel1 * ydiff, linePoints[j].X, linePoints[j].Y + yrel2 * ydiff);

					if (xrel1 < xrel2)
						gp.AddLine(linePoints[j].X + xrel1 * ydiff, linePoints[j + 1].Y, linePoints[j].X + xrel2 * xdiff, linePoints[j + 1].Y);

					if (xrel1 < xrel2 || yrel1 < yrel2)
						gp.StartFigure();
				}
				g.DrawPath(this._linePen, gp);
				gp.Reset();
			}
			else
			{
				g.DrawLines(this._linePen, linepts);
			}
		} // end function PaintOneRange StepVertLineStyle

		private PointF[] StepVertConnection_GetSubPoints(
	Processed2DPlotData pdata,
	PlotRange range,
	IPlotArea layer,
		 out int lastIdx)
		{
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			var layerSize = layer.Size;
			PointF[] linepts = new PointF[range.Length * 2 - 1];
			int end = range.UpperBound - 1;
			int i, j;
			for (i = 0, j = range.LowerBound; j < end; i += 2, j++)
			{
				linepts[i] = linePoints[j];
				linepts[i + 1].X = linePoints[j].X;
				linepts[i + 1].Y = linePoints[j + 1].Y;
			}
			linepts[i] = linePoints[j];
			lastIdx = i;

			return linepts;
		}

		public void StepVertConnection_FillOneRange(GraphicsPath gp,
		Processed2DPlotData pdata,
		PlotRange range,
		IPlotArea layer,
		CSPlaneID fillDirection
		)
		{
			if (range.Length < 2)
				return;

			int lastIdx;
			PointF[] linepts = StepVertConnection_GetSubPoints(pdata, range, layer, out lastIdx);
			StepVertConnection_FillOneRange(gp, pdata, range, layer, fillDirection, linepts);
		}

		private void StepVertConnection_FillOneRange(GraphicsPath gp,
		Processed2DPlotData pdata,
		PlotRange range,
		IPlotArea layer,
			CSPlaneID fillDirection,
		PointF[] linepts
		)
		{
			Logical3D r0 = layer.GetLogical3D(pdata, range.OriginalFirstPoint);
			layer.CoordinateSystem.GetIsolineFromPlaneToPoint(gp, fillDirection, r0);
			gp.AddLines(linepts);
			Logical3D r1 = layer.GetLogical3D(pdata, range.OriginalLastPoint);
			layer.CoordinateSystem.GetIsolineFromPointToPlane(gp, r1, fillDirection);
			layer.CoordinateSystem.GetIsolineOnPlane(gp, fillDirection, r1, r0);

			gp.CloseFigure();
		}

		#endregion StepVertConnection

		#region StepVertCenterConnection

		public void StepVertCenterConnection_PaintOneRange(
			Graphics g,
			Processed2DPlotData pdata,
			PlotRange range,
			IPlotArea layer,
			float symbolGap)
		{
			if (range.Length < 2)
				return;

			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			int lastIdx;
			PointF[] linepts = StepVertCenterConnection_GetSubPoints(pdata, range, layer, out lastIdx);

			GraphicsPath gp = new GraphicsPath();

			if (_fillArea)
			{
				StepVertCenterConnection_FillOneRange(gp, pdata, range, layer, _fillDirection, linepts);
				g.FillPath(this._fillBrush, gp);
				gp.Reset();
			}

			if (this._useSymbolGap && symbolGap > 0)
			{
				int end = linepts.Length - 1;
				float symbolGapSquared = symbolGap * symbolGap;
				for (int j = 0; j < end; j += 3)
				{
					float ydiff = linepts[j + 1].Y - linepts[j].Y;
					if (System.Math.Abs(ydiff) > symbolGap) // then the two vertical lines are visible, and full visible horz line
					{
						gp.AddLine(linepts[j].X, linepts[j].Y + (ydiff > 0 ? symbolGap : -symbolGap), linepts[j + 1].X, linepts[j + 1].Y);
						gp.AddLine(linepts[j + 1].X, linepts[j + 1].Y, linepts[j + 2].X, linepts[j + 2].Y);
						gp.AddLine(linepts[j + 2].X, linepts[j + 2].Y, linepts[j + 3].X, linepts[j + 3].Y - (ydiff > 0 ? symbolGap : -symbolGap));
						gp.StartFigure();
					}
					else // no vertical lines visible, and horz line can be shortened
					{
						// Calculate, how much of the horz line is invisible on both ends
						float xoffs = (float)(System.Math.Sqrt(symbolGapSquared - ydiff * ydiff));
						if (2 * xoffs < System.Math.Abs(linepts[j + 2].X - linepts[j + 1].X))
						{
							xoffs = (linepts[j + 2].X > linepts[j + 1].X) ? xoffs : -xoffs;
							gp.AddLine(linepts[j + 1].X + xoffs, linepts[j + 1].Y, linepts[j + 2].X - xoffs, linepts[j + 2].Y);
							gp.StartFigure();
						}
					}
				} // for loop
				g.DrawPath(this._linePen, gp);
				gp.Reset();
			}
			else
			{
				g.DrawLines(this._linePen, linepts);
			}
		} // end function PaintOneRange StepVertMiddleLineStyle

		private PointF[] StepVertCenterConnection_GetSubPoints(
Processed2DPlotData pdata,
PlotRange range,
IPlotArea layer,
	out int lastIdx)
		{
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			var layerSize = layer.Size;
			PointF[] linepts = new PointF[range.Length * 3 - 2];
			int end = range.UpperBound - 1;
			int i, j;
			for (i = 0, j = range.LowerBound; j < end; i += 3, j++)
			{
				linepts[i] = linePoints[j];
				linepts[i + 1].X = linePoints[j].X;
				linepts[i + 1].Y = 0.5f * (linePoints[j].Y + linePoints[j + 1].Y);
				linepts[i + 2].X = linePoints[j + 1].X;
				linepts[i + 2].Y = linepts[i + 1].Y;
			}
			linepts[i] = linePoints[j];
			lastIdx = i;

			return linepts;
		}

		public void StepVertCenterConnection_FillOneRange(GraphicsPath gp,
		Processed2DPlotData pdata,
		PlotRange range,
		IPlotArea layer,
		CSPlaneID fillDirection
		)
		{
			if (range.Length < 2)
				return;

			int lastIdx;
			PointF[] linepts = StepVertCenterConnection_GetSubPoints(pdata, range, layer, out lastIdx);
			StepVertCenterConnection_FillOneRange(gp, pdata, range, layer, fillDirection, linepts);
		}

		private void StepVertCenterConnection_FillOneRange(GraphicsPath gp,
		Processed2DPlotData pdata,
		PlotRange range,
		IPlotArea layer,
			CSPlaneID fillDirection,
		PointF[] linepts
		)
		{
			Logical3D r0 = layer.GetLogical3D(pdata, range.OriginalFirstPoint);
			layer.CoordinateSystem.GetIsolineFromPlaneToPoint(gp, fillDirection, r0);
			gp.AddLines(linepts);
			Logical3D r1 = layer.GetLogical3D(pdata, range.OriginalLastPoint);
			layer.CoordinateSystem.GetIsolineFromPointToPlane(gp, r1, fillDirection);
			layer.CoordinateSystem.GetIsolineOnPlane(gp, fillDirection, r1, r0);

			gp.CloseFigure();
		}

		#endregion StepVertCenterConnection

		#region StepHorzCenterConnection

		public void StepHorzCenterConnection_PaintOneRange(
			Graphics g,
			Processed2DPlotData pdata,
			PlotRange range,
			IPlotArea layer,
			float symbolGap)
		{
			if (range.Length < 2)
				return;

			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			int lastIdx;
			PointF[] linepts = StepHorzCenterConnection_GetSubPoints(pdata, range, layer, out lastIdx);

			GraphicsPath gp = new GraphicsPath();

			if (_fillArea)
			{
				StepHorzCenterConnection_FillOneRange(gp, pdata, range, layer, _fillDirection, linepts);
				g.FillPath(this._fillBrush, gp);
				gp.Reset();
			}

			if (this._useSymbolGap && symbolGap > 0)
			{
				int end = linepts.Length - 1;
				float symbolGapSquared = symbolGap * symbolGap;
				for (int j = 0; j < end; j += 3)
				{
					float xdiff = linepts[j + 1].X - linepts[j].X;
					if (System.Math.Abs(xdiff) > symbolGap) // then the two horz lines are visible, and full visible vert line
					{
						gp.AddLine(linepts[j].X + (xdiff > 0 ? symbolGap : -symbolGap), linepts[j].Y, linepts[j + 1].X, linepts[j + 1].Y);
						gp.AddLine(linepts[j + 1].X, linepts[j + 1].Y, linepts[j + 2].X, linepts[j + 2].Y);
						gp.AddLine(linepts[j + 2].X, linepts[j + 2].Y, linepts[j + 3].X - (xdiff > 0 ? symbolGap : -symbolGap), linepts[j + 3].Y);
						gp.StartFigure();
					}
					else // no horizontal lines visible, and vertical line may be shortened
					{
						// Calculate, how much of the horz line is invisible on both ends
						float yoffs = (float)(System.Math.Sqrt(symbolGapSquared - xdiff * xdiff));
						if (2 * yoffs < System.Math.Abs(linepts[j + 2].Y - linepts[j + 1].Y))
						{
							yoffs = (linepts[j + 2].Y > linepts[j + 1].Y) ? yoffs : -yoffs;
							gp.AddLine(linepts[j + 1].X, linepts[j + 1].Y + yoffs, linepts[j + 2].X, linepts[j + 2].Y - yoffs);
							gp.StartFigure();
						}
					}
				} // for loop
				g.DrawPath(this._linePen, gp);
				gp.Reset();
			}
			else
			{
				g.DrawLines(this._linePen, linepts);
			}
		} // end function PaintOneRange StepHorzMiddleLineStyle

		private PointF[] StepHorzCenterConnection_GetSubPoints(
Processed2DPlotData pdata,
PlotRange range,
IPlotArea layer,
 out int lastIdx)
		{
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			var layerSize = layer.Size;
			PointF[] linepts = new PointF[range.Length * 3 - 2];
			int end = range.UpperBound - 1;
			int i, j;
			for (i = 0, j = range.LowerBound; j < end; i += 3, j++)
			{
				linepts[i] = linePoints[j];
				linepts[i + 1].Y = linePoints[j].Y;
				linepts[i + 1].X = 0.5f * (linePoints[j].X + linePoints[j + 1].X);
				linepts[i + 2].Y = linePoints[j + 1].Y;
				linepts[i + 2].X = linepts[i + 1].X;
			}
			linepts[i] = linePoints[j];
			lastIdx = i;

			return linepts;
		}

		public void StepHorzCenterConnection_FillOneRange(GraphicsPath gp,
		Processed2DPlotData pdata,
		PlotRange range,
		IPlotArea layer,
		CSPlaneID fillDirection
		)
		{
			if (range.Length < 2)
				return;

			int lastIdx;
			PointF[] linepts = StepHorzCenterConnection_GetSubPoints(pdata, range, layer, out lastIdx);
			StepHorzCenterConnection_FillOneRange(gp, pdata, range, layer, fillDirection, linepts);
		}

		private void StepHorzCenterConnection_FillOneRange(GraphicsPath gp,
		Processed2DPlotData pdata,
		PlotRange range,
		IPlotArea layer,
			CSPlaneID fillDirection,
		PointF[] linepts
		)
		{
			Logical3D r0 = layer.GetLogical3D(pdata, range.OriginalFirstPoint);
			layer.CoordinateSystem.GetIsolineFromPlaneToPoint(gp, fillDirection, r0);
			gp.AddLines(linepts);
			Logical3D r1 = layer.GetLogical3D(pdata, range.OriginalLastPoint);
			layer.CoordinateSystem.GetIsolineFromPointToPlane(gp, r1, fillDirection);
			layer.CoordinateSystem.GetIsolineOnPlane(gp, fillDirection, r1, r0);

			gp.CloseFigure();
		}

		#endregion StepHorzCenterConnection

		#region Segment2Connection

		public void Segment2Connection_PaintOneRange(
			Graphics g,
			Processed2DPlotData pdata,
			PlotRange range,
			IPlotArea layer,
			float symbolGap)
		{
			int lastIdx;
			PointF[] linepts = Segment2Connection_GetSubPoints(pdata, range, layer, out lastIdx);
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;

			GraphicsPath gp = new GraphicsPath();
			int i;

			if (_fillArea)
			{
				Segment2Connection_FillOneRange(gp, pdata, range, layer, _fillDirection, linepts, lastIdx);
				g.FillPath(this._fillBrush, gp);
				gp.Reset();
			}

			// special efforts are necessary to realize a line/symbol gap
			// I decided to use a path for this
			// and hope that not so many segments are added to the path due
			// to the exclusion criteria that a line only appears between two symbols (rel<0.5)
			// if the symbols do not overlap. So for a big array of points it is very likely
			// that the symbols overlap and no line between the symbols needs to be plotted
			if (this._useSymbolGap && symbolGap > 0)
			{
				float xdiff, ydiff, rel, startx, starty, stopx, stopy;
				for (i = 0; i < lastIdx; i += 2)
				{
					xdiff = linepts[i + 1].X - linepts[i].X;
					ydiff = linepts[i + 1].Y - linepts[i].Y;
					rel = (float)(symbolGap / System.Math.Sqrt(xdiff * xdiff + ydiff * ydiff));
					if (rel < 0.5) // a line only appears if the relative gap is smaller 1/2
					{
						startx = linepts[i].X + rel * xdiff;
						starty = linepts[i].Y + rel * ydiff;
						stopx = linepts[i + 1].X - rel * xdiff;
						stopy = linepts[i + 1].Y - rel * ydiff;

						gp.AddLine(startx, starty, stopx, stopy);
						gp.StartFigure();
					}
				} // end for
				g.DrawPath(this._linePen, gp);
				gp.Reset();
			}
			else // no line symbol gap required, so we can use DrawLines to draw the lines
			{
				for (i = 0; i < lastIdx; i += 2)
				{
					gp.AddLine(linepts[i].X, linepts[i].Y, linepts[i + 1].X, linepts[i + 1].Y);
					gp.StartFigure();
				} // end for
				g.DrawPath(this._linePen, gp);
				gp.Reset();
			}
		} // end function PaintOneRange Segment2LineStyle

		private PointF[] Segment2Connection_GetSubPoints(
Processed2DPlotData pdata,
PlotRange range,
IPlotArea layer,
 out int lastIdx)
		{
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			var layerSize = layer.Size;
			PointF[] linepts = new PointF[range.Length];
			Array.Copy(linePoints, range.LowerBound, linepts, 0, range.Length); // Extract
			lastIdx = range.Length - 1;

			return linepts;
		}

		public void Segment2Connection_FillOneRange(GraphicsPath gp,
		Processed2DPlotData pdata,
		PlotRange range,
		IPlotArea layer,
		CSPlaneID fillDirection
		)
		{
			if (range.Length < 2)
				return;

			int lastIdx;
			PointF[] linepts = Segment2Connection_GetSubPoints(pdata, range, layer, out lastIdx);
			Segment2Connection_FillOneRange(gp, pdata, range, layer, fillDirection, linepts, lastIdx);
		}

		private void Segment2Connection_FillOneRange(GraphicsPath gp,
		Processed2DPlotData pdata,
		PlotRange range,
		IPlotArea layer,
			CSPlaneID fillDirection,
		PointF[] linepts,
			int lastIdx
		)
		{
			int offs = range.LowerBound;
			for (int i = 0; i < lastIdx; i += 2)
			{
				Logical3D r0 = layer.GetLogical3D(pdata, i + range.OriginalFirstPoint);
				layer.CoordinateSystem.GetIsolineFromPlaneToPoint(gp, fillDirection, r0);
				gp.AddLine(linepts[i].X, linepts[i].Y, linepts[i + 1].X, linepts[i + 1].Y);
				Logical3D r1 = layer.GetLogical3D(pdata, i + 1 + range.OriginalFirstPoint);
				layer.CoordinateSystem.GetIsolineFromPointToPlane(gp, r1, fillDirection);
				layer.CoordinateSystem.GetIsolineOnPlane(gp, fillDirection, r1, r0);
				gp.StartFigure();
			}

			gp.CloseFigure();
		}

		#endregion Segment2Connection

		#region Segment3Connection

		public void Segment3Connection_PaintOneRange(
			Graphics g,
			Processed2DPlotData pdata,
			PlotRange range,
			IPlotArea layer,
			float symbolGap)
		{
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			int lastIdx;
			PointF[] linepts = Segment3Connection_GetSubPoints(pdata, range, layer, out lastIdx);
			GraphicsPath gp = new GraphicsPath();
			int i;

			if (_fillArea)
			{
				Segment3Connection_FillOneRange(gp, pdata, range, layer, _fillDirection, linepts);
				g.FillPath(this._fillBrush, gp);
				gp.Reset();
			}

			// special efforts are necessary to realize a line/symbol gap
			// I decided to use a path for this
			// and hope that not so many segments are added to the path due
			// to the exclusion criteria that a line only appears between two symbols (rel<0.5)
			// if the symbols do not overlap. So for a big array of points it is very likely
			// that the symbols overlap and no line between the symbols needs to be plotted
			lastIdx = range.Length - 1;

			if (this._useSymbolGap && symbolGap > 0)
			{
				float xdiff, ydiff, rel, startx, starty, stopx, stopy;
				for (i = 0; i < lastIdx; i++)
				{
					if (2 != (i % 3))
					{
						xdiff = linepts[i + 1].X - linepts[i].X;
						ydiff = linepts[i + 1].Y - linepts[i].Y;
						rel = (float)(symbolGap / System.Math.Sqrt(xdiff * xdiff + ydiff * ydiff));
						if (rel < 0.5) // a line only appears if the relative gap is smaller 1/2
						{
							startx = linepts[i].X + rel * xdiff;
							starty = linepts[i].Y + rel * ydiff;
							stopx = linepts[i + 1].X - rel * xdiff;
							stopy = linepts[i + 1].Y - rel * ydiff;

							gp.AddLine(startx, starty, stopx, stopy);
							gp.StartFigure();
						}
					}
				} // end for
				g.DrawPath(this._linePen, gp);
				gp.Reset();
			}
			else // no line symbol gap required, so we can use DrawLines to draw the lines
			{
				for (i = 0; i < lastIdx; i += 3)
				{
					gp.AddLine(linepts[i].X, linepts[i].Y, linepts[i + 1].X, linepts[i + 1].Y);
					gp.AddLine(linepts[i + 1].X, linepts[i + 1].Y, linepts[i + 2].X, linepts[i + 2].Y);
					gp.StartFigure();
				} // end for
				g.DrawPath(this._linePen, gp);
				gp.Reset();
			}
		} // end function PaintOneRange Segment3LineStyle

		private PointF[] Segment3Connection_GetSubPoints(
Processed2DPlotData pdata,
PlotRange range,
IPlotArea layer,
out int lastIndex)
		{
			PointF[] linePoints = pdata.PlotPointsInAbsoluteLayerCoordinates;
			var layerSize = layer.Size;
			PointF[] linepts = new PointF[range.Length];
			Array.Copy(linePoints, range.LowerBound, linepts, 0, range.Length); // Extract
			lastIndex = 0;

			return linepts;
		}

		public void Segment3Connection_FillOneRange(GraphicsPath gp,
		Processed2DPlotData pdata,
		PlotRange range,
		IPlotArea layer,
		CSPlaneID fillDirection
		)
		{
			if (range.Length < 2)
				return;

			int lastIdx;
			PointF[] linepts = Segment3Connection_GetSubPoints(pdata, range, layer, out lastIdx);
			Segment3Connection_FillOneRange(gp, pdata, range, layer, fillDirection, linepts);
		}

		private void Segment3Connection_FillOneRange(GraphicsPath gp,
		Processed2DPlotData pdata,
		PlotRange range,
		IPlotArea layer,
			CSPlaneID fillDirection,
		PointF[] linepts
		)
		{
			int lastIdx = range.Length - 2;
			int offs = range.LowerBound;
			for (int i = 0; i < lastIdx; i += 3)
			{
				Logical3D r0 = layer.GetLogical3D(pdata, i + range.OriginalFirstPoint);
				layer.CoordinateSystem.GetIsolineFromPlaneToPoint(gp, fillDirection, r0);
				gp.AddLine(linepts[i].X, linepts[i].Y, linepts[i + 1].X, linepts[i + 1].Y);
				gp.AddLine(linepts[i + 1].X, linepts[i + 1].Y, linepts[i + 2].X, linepts[i + 2].Y);

				Logical3D r1 = layer.GetLogical3D(pdata, i + 2 + range.OriginalFirstPoint);
				layer.CoordinateSystem.GetIsolineFromPointToPlane(gp, r1, fillDirection);
				layer.CoordinateSystem.GetIsolineOnPlane(gp, fillDirection, r1, r0);
				gp.StartFigure();
			}
			gp.CloseFigure();
		}

		#endregion Segment3Connection

		public bool IsColorProvider
		{
			get { return !this._independentColor; }
		}

		public NamedColor Color
		{
			get
			{
				return this._linePen.Color;
			}
			set
			{
				this._linePen.Color = value;
			}
		}

		public bool IsColorReceiver
		{
			get { return !this._independentColor; }
		}

		#region IG2DPlotStyle Members

		public void CollectExternalGroupStyles(PlotGroupStyleCollection externalGroups)
		{
		}

		public void CollectLocalGroupStyles(PlotGroupStyleCollection externalGroups, PlotGroupStyleCollection localGroups)
		{
			ColorGroupStyle.AddLocalGroupStyle(externalGroups, localGroups);
			DashPatternGroupStyle.AddLocalGroupStyle(externalGroups, localGroups);
		}

		public void PrepareGroupStyles(PlotGroupStyleCollection externalGroups, PlotGroupStyleCollection localGroups, IPlotArea layer, Processed2DPlotData pdata)
		{
			if (this.IsColorProvider)
				ColorGroupStyle.PrepareStyle(externalGroups, localGroups, delegate () { return this.Color; });
			else if (this._fillColorLinkage == ColorLinkage.Dependent && this._fillBrush != null)
				ColorGroupStyle.PrepareStyle(externalGroups, localGroups, delegate () { return this._fillBrush.Color; });

			if (!_independentDashStyle)
				DashPatternGroupStyle.PrepareStyle(externalGroups, localGroups, delegate { return this.LinePen.DashPattern; });
		}

		public void ApplyGroupStyles(PlotGroupStyleCollection externalGroups, PlotGroupStyleCollection localGroups)
		{
			// SkipFrequency should be the same for all sub plot styles
			if (!_independentSkipFreq)
			{
				_skipFreq = 1;
				SkipFrequencyGroupStyle.ApplyStyle(externalGroups, localGroups, delegate (int c) { this._skipFreq = c; });
			}

			if (this.IsColorReceiver)
				ColorGroupStyle.ApplyStyle(externalGroups, localGroups, delegate (NamedColor c) { this.Color = c; });

			if (!_independentDashStyle)
				DashPatternGroupStyle.ApplyStyle(externalGroups, localGroups, delegate (IDashPattern c) { this._linePen.DashPattern = c; });

			if (!_independentSymbolSize)
			{
				_symbolSize = 0;
				SymbolSizeGroupStyle.ApplyStyle(externalGroups, localGroups, delegate (double size) { this._symbolSize = size; });
			}

			// symbol size
			if (!_independentSymbolSize)
			{
				this._symbolSize = 0;
				SymbolSizeGroupStyle.ApplyStyle(externalGroups, localGroups, delegate (double size) { this._symbolSize = size; });

				// but if there is an symbol size evaluation function, then use this with higher priority.
				_cachedSymbolSizeForIndexFunction = null;
				VariableSymbolSizeGroupStyle.ApplyStyle(externalGroups, localGroups, delegate (Func<int, double> evalFunc) { _cachedSymbolSizeForIndexFunction = evalFunc; });
			}
			else
			{
				_cachedSymbolSizeForIndexFunction = null;
			}

			// Fill Area

			if (this._fillArea && ColorLinkage.Independent != _fillColorLinkage)
			{
				if (null == _fillBrush)
					_fillBrush = new BrushX(NamedColors.Black);

				if (_fillColorLinkage == ColorLinkage.Dependent)
					ColorGroupStyle.ApplyStyle(externalGroups, localGroups, delegate (NamedColor c) { _fillBrush.Color = c; });
				else if (ColorLinkage.PreserveAlpha == _fillColorLinkage)
					ColorGroupStyle.ApplyStyle(externalGroups, localGroups, delegate (NamedColor c) { _fillBrush.Color = c.NewWithAlphaValue(_fillBrush.Color.Color.A); });
			}
		}

		#endregion IG2DPlotStyle Members

		#region IDocumentNode Members

		/// <summary>
		/// Replaces path of items (intended for data items like tables and columns) by other paths. Thus it is possible
		/// to change a plot so that the plot items refer to another table.
		/// </summary>
		/// <param name="Report">Function that reports the found <see cref="DocNodeProxy"/> instances to the visitor.</param>
		public void VisitDocumentReferences(DocNodeProxyReporter Report)
		{
		}

		/// <inheritdoc/>
		public IEnumerable<Tuple<string, IReadableColumn, string, Action<IReadableColumn>>> GetAdditionallyUsedColumns()
		{
			return null; // no additionally used columns
		}

		#endregion IDocumentNode Members

		#region IRoutedPropertyReceiver Members

		public void SetRoutedProperty(IRoutedSetterProperty property)
		{
			switch (property.Name)
			{
				case "StrokeWidth":
					{
						var prop = (RoutedSetterProperty<double>)property;
						this._linePen.Width = (float)prop.Value;
						EhSelfChanged(EventArgs.Empty);
					}
					break;
			}
		}

		public void GetRoutedProperty(IRoutedGetterProperty property)
		{
			switch (property.Name)
			{
				case "StrokeWidth":
					{
						var prop = (RoutedGetterProperty<double>)property;
						prop.Merge(this._linePen.Width);
					}
					break;
			}
		}

		#endregion IRoutedPropertyReceiver Members
	} // end class XYPlotLineStyle
}