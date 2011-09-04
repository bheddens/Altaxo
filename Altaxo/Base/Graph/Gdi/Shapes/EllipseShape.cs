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
using System.Drawing.Drawing2D;
using Altaxo.Serialization;

namespace Altaxo.Graph.Gdi.Shapes
{
	[Serializable]
	public class EllipseShape : ClosedPathShapeBase
	{

		#region Serialization

		#region Clipboard serialization

		protected EllipseShape(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			SetObjectData(this, info, context, null);
		}

		/// <summary>
		/// Serializes EllipseGraphic Version 0.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			EllipseShape s = this;
			base.GetObjectData(info, context);
		}


		/// <summary>
		/// Deserializes the EllipseGraphic Version 0.
		/// </summary>
		/// <param name="obj">The empty EllipseGraphic object to deserialize into.</param>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		/// <param name="selector">The deserialization surrogate selector.</param>
		/// <returns>The deserialized EllipseGraphic.</returns>
		public override object SetObjectData(object obj, System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context, System.Runtime.Serialization.ISurrogateSelector selector)
		{
			EllipseShape s = (EllipseShape)base.SetObjectData(obj, info, context, selector);
			return s;
		}
		/// <summary>
		/// Finale measures after deserialization.
		/// </summary>
		/// <param name="obj">Not used.</param>
		public override void OnDeserialization(object obj)
		{
			base.OnDeserialization(obj);
		}
		#endregion

		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.EllipseGraphic", 0)]
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(EllipseShape), 1)]
		class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				EllipseShape s = (EllipseShape)obj;
				info.AddBaseValueEmbedded(s, typeof(EllipseShape).BaseType);

			}
			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{

				EllipseShape s = null != o ? (EllipseShape)o : new EllipseShape();
				info.GetBaseValueEmbedded(s, typeof(EllipseShape).BaseType, parent);

				return s;
			}
		}

		#endregion


		#region Constructors

		public EllipseShape()
		{
		}

		public EllipseShape(PointF graphicPosition)
			:
			this()
		{
			this.SetPosition(graphicPosition);
		}
		public EllipseShape(float posX, float posY)
			:
			this(new PointF(posX, posY))
		{
		}

		public EllipseShape(PointF graphicPosition, SizeF graphicSize)
			:
			this(graphicPosition)
		{

			this.SetSize(graphicSize.Width, graphicSize.Height);
		}

		public EllipseShape(float posX, float posY, SizeF graphicSize)
			:
			this(new PointF(posX, posY), graphicSize)
		{
		}

		public EllipseShape(float posX, float posY, float width, float height)
			:
			this(new PointF(posX, posY), new SizeF(width, height))
		{
		}

		public EllipseShape(PointF graphicPosition, float Rotation)
			:
			this()
		{
			this.SetPosition(graphicPosition);
			this.Rotation = Rotation;
		}

		public EllipseShape(float posX, float posY, float Rotation)
			:
			this(new PointF(posX, posY), Rotation)
		{
		}

		public EllipseShape(PointF graphicPosition, SizeF graphicSize, float Rotation)
			:
			this(graphicPosition, Rotation)
		{
			this.SetSize(graphicSize.Width, graphicSize.Height);
		}

		public EllipseShape(float posX, float posY, SizeF graphicSize, float Rotation)
			:
			this(new PointF(posX, posY), graphicSize, Rotation)
		{
		}

		public EllipseShape(float posX, float posY, float width, float height, float Rotation)
			:
			this(new PointF(posX, posY), new SizeF(width, height), Rotation)
		{
		}

		public EllipseShape(EllipseShape from)
			:
			base(from)
		{
		}

		#endregion

		public override object Clone()
		{
			return new EllipseShape(this);
		}



		/// <summary>
		/// Get the object outline for arrangements in object world coordinates.
		/// </summary>
		/// <returns>Object outline for arrangements in object world coordinates</returns>
		public override GraphicsPath GetObjectOutlineForArrangements()
		{
			GraphicsPath gp = new GraphicsPath();
			gp.AddEllipse(new RectangleF((float)(_bounds.X), (float)(_bounds.Y), (float)Width, (float)Height));
			return gp;
		}


		public override void Paint(Graphics g, object obj)
		{
			GraphicsState gs = g.Save();
			TransformGraphics(g);

			var boundsF = (RectangleF)_bounds;
			if (Brush.IsVisible)
			{
				Brush.SetEnvironment(boundsF, BrushX.GetEffectiveMaximumResolution(g, Math.Max(_scaleX, _scaleY)));
				g.FillEllipse(Brush, boundsF);
			}

			Pen.SetEnvironment(boundsF, BrushX.GetEffectiveMaximumResolution(g, Math.Max(_scaleX, _scaleY)));
			g.DrawEllipse(Pen, boundsF);
			g.Restore(gs);
		}
	} // end class


} // end Namespace
