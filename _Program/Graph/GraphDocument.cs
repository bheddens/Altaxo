/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002 Dr. Dirk Lellinger
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

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using Altaxo.Serialization;


namespace Altaxo.Graph
{
	/// <summary>
	/// This is the class that holds all elements of a graph, especially one ore more layers.
	/// </summary>
	/// <remarks>The coordinate system of the graph is in units of points (1/72 inch). The origin (0,0) of the graph
	/// is the top left corner of the printable area (and therefore _not_ the page bounds). The value of the page
	/// bounds is stored inside the class only to know what the original page size of the document was.</remarks>
	[SerializationSurrogate(0,typeof(GraphDocument.SerializationSurrogate0))]
	[SerializationVersion(0)]
	public class GraphDocument : Layer.LayerCollection, System.Runtime.Serialization.IDeserializationCallback, System.ICloneable
	{

		/// <summary>
		/// Overall size of the page (usually the size of the sheet of paper that is selected as printing document) in point (1/72 inch)
		/// </summary>
		/// <remarks>The value is only used by hosting classes, since the reference point (0,0) of the GraphDocument
		/// is the top left corner of the printable area. The hosting class has to translate the graphics origin
		/// to that point before calling the painting routine <see cref="DoPaint"/>.</remarks>
		private RectangleF m_PageBounds = new RectangleF(0, 0, 842, 595);

		
		/// <summary>
		/// The printable area of the document, i.e. the page size minus the margins at each sC:\Users\LelliD\C\CALC\Altaxo\Altaxo\Graph\GraphDocument.cside in points (1/72 inch)
		/// </summary>
		private RectangleF m_PrintableBounds = new RectangleF(14, 14, 814 , 567 );

		#region "Serialization"

		/// <summary>Used to serialize the GraphDocument Version 0.</summary>
		public new class SerializationSurrogate0 : System.Runtime.Serialization.ISerializationSurrogate
		{
			/// <summary>
			/// Serializes GraphDocument Version 0.
			/// </summary>
			/// <param name="obj">The GraphDocument to serialize.</param>
			/// <param name="info">The serialization info.</param>
			/// <param name="context">The streaming context.</param>
			public void GetObjectData(object obj,System.Runtime.Serialization.SerializationInfo info,System.Runtime.Serialization.StreamingContext context	)
			{
				GraphDocument s = (GraphDocument)obj;
				System.Runtime.Serialization.ISurrogateSelector ss= AltaxoStreamingContext.GetSurrogateSelector(context);
				if(null!=ss)
				{
				// get the serialization surrogate of the base type
				System.Runtime.Serialization.ISerializationSurrogate surr =
					ss.GetSurrogate(obj.GetType().BaseType,context, out ss);
					// stream the data of the base class
					surr.GetObjectData(obj,info,context);
				}
				else 
				{
					throw new NotImplementedException(string.Format("Serializing a {0} without surrogate not implemented yet!",obj.GetType()));
				}
			
			
				// now the data of our class
				info.AddValue("PageBounds",s.m_PageBounds);
				info.AddValue("PrintableBounds",s.m_PrintableBounds);
			}

			/// <summary>
			/// Deserializes the GraphDocument Version 0.
			/// </summary>
			/// <param name="obj">The empty GraphDocument object to deserialize into.</param>
			/// <param name="info">The serialization info.</param>
			/// <param name="context">The streaming context.</param>
			/// <param name="selector">The deserialization surrogate selector.</param>
			/// <returns>The deserialized GraphDocument.</returns>
			public object SetObjectData(object obj,System.Runtime.Serialization.SerializationInfo info,System.Runtime.Serialization.StreamingContext context,System.Runtime.Serialization.ISurrogateSelector selector)
			{
				GraphDocument s = (GraphDocument)obj;
				System.Runtime.Serialization.ISurrogateSelector ss = AltaxoStreamingContext.GetSurrogateSelector(context);
				if(null!=ss)
				{
				// get the serialization surrogate of the base type
				System.Runtime.Serialization.ISerializationSurrogate surr =
					ss.GetSurrogate(obj.GetType().BaseType, context, out ss);
				
				// deserialize the base type
				surr.SetObjectData(obj,info,context,selector);
				}
				else 
				{
					throw new NotImplementedException(string.Format("Serializing a {0} without surrogate not implemented yet!",obj.GetType()));
				}
				s.m_PageBounds			= (RectangleF)info.GetValue("PageBounds",typeof(RectangleF));
				s.m_PrintableBounds = (RectangleF)info.GetValue("PrintableBounds",typeof(RectangleF));
				return s;
			}
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


		/// <summary>
		/// Creates a empty GraphDocument with no layers and a standard size of A4 landscape.
		/// </summary>
		public GraphDocument()
		{
		}

		public GraphDocument(GraphDocument from)
			: base(from)
		{
			this.m_PageBounds = from.m_PageBounds;
			this.m_PrintableBounds = from.m_PrintableBounds;
		}

		public override object Clone()
		{
			return new GraphDocument(this);
		}
		
		/// <summary>
		/// The boundaries of the page in points (1/72 inch).
		/// </summary>
		/// <remarks>The value is only used by hosting classes, since the reference point (0,0) of the GraphDocument
		/// is the top left corner of the printable area. The hosting class has to translate the graphics origin
		/// to that point before calling the painting routine <see cref="DoPaint"/>.</remarks>
		public RectangleF PageBounds
		{
			get { return m_PageBounds; }
			set { m_PageBounds=value; }
		}

		/// <summary>
		/// The boundaries of the printable area of the page in points (1/72 inch).
		/// </summary>
		public RectangleF PrintableBounds
		{
			get { return m_PrintableBounds; }
			set
			{
				RectangleF oldBounds = m_PrintableBounds;
				m_PrintableBounds=value;

				if(m_PrintableBounds!=oldBounds)
				{
					// TODO transform the layers to adapt the new settings
				}
			}
		}


		/// <summary>
		/// The size of the printable area in points (1/72 inch).
		/// </summary>
		public virtual SizeF PrintableSize
		{
			get { return new SizeF(m_PrintableBounds.Width,m_PrintableBounds.Height); }
		}


		/// <summary>
		/// The collection of layers of the graph.
		/// </summary>
		public Layer.LayerCollection Layers
		{
			get { return this; } 
		}


		/// <summary>
		/// Paints the graph.
		/// </summary>
		/// <param name="g">The graphic contents to paint to.</param>
		/// <param name="bForPrinting">Indicates if the painting is for printing purposes. Not used for the moment.</param>
		/// <remarks>The reference point (0,0) of the GraphDocument
		/// is the top left corner of the printable area (and not of the page area!). The hosting class has to translate the graphics origin
		/// to the top left corner of the printable area before calling this routine.</remarks>
		public void DoPaint(Graphics g, bool bForPrinting)
		{
			GraphicsState gs = g.Save();

			for(int i=0;i<Layers.Count;i++)
			{
				Layers[i].Paint(g);
			}

			g.Restore(gs);
		} // end of function DoPaint



		/// <summary>
		/// Gets the default layer position in points (1/72 inch).
		/// </summary>
		/// <value>The default position of a (new) layer in points (1/72 inch).</value>
		public PointF DefaultLayerPosition
		{
			get { return new PointF(0.145f*this.PrintableSize.Width, 0.139f*this.PrintableSize.Height); }
		}


		/// <summary>
		/// Gets the default layer size in points (1/72 inch).
		/// </summary>
		/// <value>The default size of a (new) layer in points (1/72 inch).</value>
		public SizeF DefaultLayerSize
		{
		get	{	return new SizeF(0.763f*this.PrintableSize.Width, 0.708f*this.PrintableSize.Height); }
		}


		#region Layer Creation

		/// <summary>
		/// Creates a new layer with bottom x axis and left y axis, which is not linked.
		/// </summary>
		public void CreateNewLayerNormalBottomXLeftY()
		{
			Layer newlayer= new Layer(DefaultLayerPosition,DefaultLayerSize);
			newlayer.TopAxisEnabled=false;
			newlayer.RightAxisEnabled=false;
		
			Layers.Add(newlayer);
		}

		/// <summary>
		/// Creates a new layer with bottom x axis and left y axis, which is linked to the same position with top x axis and right y axis.
		/// </summary>
		public void CreateNewLayerLinkedTopXRightY(int linklayernumber)
		{
			Layer newlayer= new Layer(DefaultLayerPosition,DefaultLayerSize);
			Layers.Add(newlayer); // it is neccessary to add the new layer this early since we must set some properties relative to the linked layer
			// link the new layer to the last old layer
			newlayer.LinkedLayer = (linklayernumber>=0 && linklayernumber<Layers.Count)? Layers[linklayernumber] : null;
			newlayer.SetPosition(0,Layer.PositionType.RelativeThisNearToLinkedLayerNear,0,Layer.PositionType.RelativeThisNearToLinkedLayerNear);
			newlayer.SetSize(1,Layer.SizeType.RelativeToLinkedLayer,1,Layer.SizeType.RelativeToLinkedLayer);

			// set enabling of axis
			newlayer.BottomAxisEnabled=false;
			newlayer.LeftAxisEnabled=false;
		}


		/// <summary>
		/// Creates a new layer with bottom x axis and left y axis, which is linked to the same position with top x axis and right y axis. The x axis is linked straight to the x axis of the linked layer.
		/// </summary>
		public void CreateNewLayerLinkedTopXRightY_XAxisStraight(int linklayernumber)
		{
			Layer newlayer= new Layer(DefaultLayerPosition,DefaultLayerSize);
			Layers.Add(newlayer); // it is neccessary to add the new layer this early since we must set some properties relative to the linked layer
			// link the new layer to the last old layer
			newlayer.LinkedLayer = (linklayernumber>=0 && linklayernumber<Layers.Count)? Layers[linklayernumber] : null;
			newlayer.SetPosition(0,Layer.PositionType.RelativeThisNearToLinkedLayerNear,0,Layer.PositionType.RelativeThisNearToLinkedLayerNear);
			newlayer.SetSize(1,Layer.SizeType.RelativeToLinkedLayer,1,Layer.SizeType.RelativeToLinkedLayer);

			// set enabling of axis
			newlayer.BottomAxisEnabled=false;
			newlayer.LeftAxisEnabled=false;

			newlayer.XAxisLinkType = Layer.AxisLinkType.Straight;
		}



		#endregion


		#region inherited from Layer.Collection

		/// <summary>
		/// Fires the Invalidate event.
		/// </summary>
		/// <param name="sender">The layer which needs to be repainted.</param>
		protected internal override void OnInvalidate(Layer sender)
		{
			base.OnInvalidate(sender);
		}
		
		#endregion

	} // end of class GraphDocument
} // end of namespace