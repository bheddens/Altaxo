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
#endregion

using System;
using System.Drawing;
using System.Runtime.Serialization;
namespace Altaxo.Graph.Gdi.Background
{
	/// <summary>
	/// Backs the item with a color filled rectangle.
	/// </summary>
	[Serializable]
	public class RectangleWithShadow : IBackgroundStyle, IDeserializationCallback
	{
		protected BrushX _brush = new BrushX(NamedColors.White);
		protected double _shadowLength = 5;

		[NonSerialized]
		protected BrushX _cachedShadowBrush;


		#region Serialization

		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.BackgroundStyles.RectangleWithShadow", 0)]
		class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				throw new ApplicationException("Programming error - this should not be called");
				/*
				RectangleWithShadow s = (RectangleWithShadow)obj;
				info.AddValue("Color", s._color);
				info.AddValue("ShadowLength", s._shadowLength);
				*/
			}
			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				RectangleWithShadow s = null != o ? (RectangleWithShadow)o : new RectangleWithShadow();
				s.Brush = new BrushX((NamedColor)info.GetValue("Color", parent));
				s._shadowLength = info.GetDouble();

				return s;
			}
		}

		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.BackgroundStyles.RectangleWithShadow", 1)]
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(RectangleWithShadow), 2)]
		class XmlSerializationSurrogate1 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				RectangleWithShadow s = (RectangleWithShadow)obj;
				info.AddValue("Brush", s._brush);
				info.AddValue("ShadowLength", s._shadowLength);

			}
			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				RectangleWithShadow s = null != o ? (RectangleWithShadow)o : new RectangleWithShadow();
				s.Brush = (BrushX)info.GetValue("Brush", parent);
				s._shadowLength = info.GetDouble();

				return s;
			}
		}


		#endregion

		#region IDeserializationCallback Members

		public void OnDeserialization(object sender)
		{
			SetCachedBrushes();
		}

		#endregion


		public RectangleWithShadow()
		{
		}

		public RectangleWithShadow(NamedColor c)
		{
			this.Brush = new BrushX(c);
		}

		public RectangleWithShadow(RectangleWithShadow from)
		{
			CopyFrom(from);
		}

		public void CopyFrom(RectangleWithShadow from)
		{
			if (object.ReferenceEquals(this, from))
				return;

			this.Brush = from._brush;
		}

		public object Clone()
		{
			return new RectangleWithShadow(this);
		}

		private void ResetCachedBrushes()
		{
			this._cachedShadowBrush = null;
		}

		private void SetCachedBrushes()
		{
			switch (_brush.BrushType)
			{
				default:
				case BrushType.SolidBrush:
					this._cachedShadowBrush = new BrushX(NamedColor.FromArgb(_brush.Color.Color.A, 0, 0, 0));
					break;
				case BrushType.HatchBrush:
					this._cachedShadowBrush = new BrushX(NamedColor.FromArgb(_brush.Color.Color.A, 0, 0, 0));
					break;
				case BrushType.TextureBrush:
					this._cachedShadowBrush = new BrushX(NamedColors.Black);
					break;
				case BrushType.LinearGradientBrush:
				case BrushType.PathGradientBrush:
					this._cachedShadowBrush = (BrushX)_brush.Clone();
					this._cachedShadowBrush.Color = NamedColor.FromArgb(_brush.Color.Color.A, 0, 0, 0);
					this._cachedShadowBrush.BackColor = NamedColor.FromArgb(_brush.BackColor.Color.A, 0, 0, 0);
					break;
			}

		}

		#region IBackgroundStyle Members

		public RectangleD MeasureItem(System.Drawing.Graphics g, RectangleD innerArea)
		{
			innerArea.Inflate(_shadowLength / 2, _shadowLength / 2);
			innerArea.Width += _shadowLength;
			innerArea.Height += _shadowLength;
			return innerArea;
		}

		public void Draw(System.Drawing.Graphics g, RectangleD innerArea)
		{
			if (null == _cachedShadowBrush)
				SetCachedBrushes();

			innerArea.Inflate(_shadowLength / 2, _shadowLength / 2);

			// please note: m_Bounds is already extended to the shadow

			// first the shadow
			_cachedShadowBrush.SetEnvironment(innerArea, BrushX.GetEffectiveMaximumResolution(g, 1));

			// shortCuts to floats
			RectangleF iArea = (RectangleF)innerArea; float shadowLength = (float)_shadowLength;
			g.TranslateTransform(shadowLength, shadowLength);
			g.FillRectangle(_cachedShadowBrush, iArea);
			g.TranslateTransform(-shadowLength, -shadowLength);

			_brush.SetEnvironment(innerArea, BrushX.GetEffectiveMaximumResolution(g, 1));
			g.FillRectangle(_brush, iArea);
			g.DrawRectangle(Pens.Black, iArea.Left, iArea.Top, iArea.Width, iArea.Height);
		}

		public bool SupportsBrush
		{
			get
			{
				return true;
			}
		}

		public BrushX Brush
		{
			get
			{
				return _brush;
			}
			set
			{
				_brush = value == null ? null : value.Clone();
				ResetCachedBrushes();
			}
		}
		#endregion

	}
}
