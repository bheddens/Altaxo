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
using System.Drawing;
using System.Drawing.Drawing2D;
using Altaxo.Serialization;


namespace Altaxo.Graph
{
	/// <summary>
	/// Association of data and style specialized for x-y-plots of column data.
	/// </summary>
	[SerializationSurrogate(0,typeof(DensityImagePlotItem.SerializationSurrogate0))]
	[SerializationVersion(0)]
	public class DensityImagePlotItem : PlotItem, System.Runtime.Serialization.IDeserializationCallback
	{
		protected D2EquidistantMeshDataAssociation m_PlotAssociation;
		protected DensityImagePlotStyle       m_PlotStyle;

		#region Serialization
		/// <summary>Used to serialize the DensityImagePlotItem Version 0.</summary>
		public class SerializationSurrogate0 : System.Runtime.Serialization.ISerializationSurrogate
		{
			/// <summary>
			/// Serializes DensityImagePlotItem Version 0.
			/// </summary>
			/// <param name="obj">The DensityImagePlotItem to serialize.</param>
			/// <param name="info">The serialization info.</param>
			/// <param name="context">The streaming context.</param>
			public void GetObjectData(object obj,System.Runtime.Serialization.SerializationInfo info,System.Runtime.Serialization.StreamingContext context	)
			{
				DensityImagePlotItem s = (DensityImagePlotItem)obj;
				info.AddValue("Data",s.m_PlotAssociation);  
				info.AddValue("Style",s.m_PlotStyle);  
			}
			/// <summary>
			/// Deserializes the DensityImagePlotItem Version 0.
			/// </summary>
			/// <param name="obj">The empty DensityImagePlotItem object to deserialize into.</param>
			/// <param name="info">The serialization info.</param>
			/// <param name="context">The streaming context.</param>
			/// <param name="selector">The deserialization surrogate selector.</param>
			/// <returns>The deserialized DensityImagePlotItem.</returns>
			public object SetObjectData(object obj,System.Runtime.Serialization.SerializationInfo info,System.Runtime.Serialization.StreamingContext context,System.Runtime.Serialization.ISurrogateSelector selector)
			{
				DensityImagePlotItem s = (DensityImagePlotItem)obj;

				s.m_PlotAssociation = (D2EquidistantMeshDataAssociation)info.GetValue("Data",typeof(D2EquidistantMeshDataAssociation));
				s.m_PlotStyle = (DensityImagePlotStyle)info.GetValue("Style",typeof(DensityImagePlotStyle));
		
				return s;
			}
		}


		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(DensityImagePlotItem),0)]
			public new class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				DensityImagePlotItem s = (DensityImagePlotItem)obj;
				info.AddValue("Data",s.m_PlotAssociation);  
				info.AddValue("Style",s.m_PlotStyle);  
			}
			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlSerializationInfo info, object parent)
			{
				DensityImagePlotItem s = null!=o ? (DensityImagePlotItem)o : new DensityImagePlotItem();

				s.m_PlotAssociation = (D2EquidistantMeshDataAssociation)info.GetValue("Data",s);
				s.m_PlotStyle = (DensityImagePlotStyle)info.GetValue("Style",s);
		

				// Restore the event chain

				if(null!=s.m_PlotAssociation)
				{
					s.m_PlotAssociation.Changed += new EventHandler(s.OnDataChangedEventHandler);
				}

				if(null!=s.m_PlotStyle)
				{
					s.m_PlotStyle.Changed += new EventHandler(s.OnStyleChangedEventHandler);
				}

				return s;
			}
		}

		/// <summary>
		/// Finale measures after deserialization of the linear axis.
		/// </summary>
		/// <param name="obj">Not used.</param>
		public virtual void OnDeserialization(object obj)
		{
			// Restore the event chain

			if(null!=m_PlotAssociation)
			{
				m_PlotAssociation.Changed += new EventHandler(OnDataChangedEventHandler);
			}

			if(null!=m_PlotStyle)
			{
				m_PlotStyle.Changed += new EventHandler(OnStyleChangedEventHandler);
			}
		}
		#endregion



		public DensityImagePlotItem(D2EquidistantMeshDataAssociation pa, DensityImagePlotStyle ps)
		{
			this.Data = pa;
			this.Style = ps;
		}

		public DensityImagePlotItem(DensityImagePlotItem from)
		{
			this.Data = from.Data;   // also wires the event
			this.Style = from.Style; // also wires the event
		}

		public override object Clone()
		{
			return new DensityImagePlotItem(this);
		}


		public override object Data
		{
			get { return m_PlotAssociation; }
			set
			{
				if(null==value)
					throw new System.ArgumentNullException();
				else if(!(value is D2EquidistantMeshDataAssociation))
					throw new System.ArgumentException("The provided data object is not of the type " + m_PlotAssociation.GetType().ToString() + ", but of type " + value.GetType().ToString() + "!");
				else
				{
					if(!object.ReferenceEquals(m_PlotAssociation,value))
					{
						if(null!=m_PlotAssociation)
						{
							m_PlotAssociation.Changed -= new EventHandler(OnDataChangedEventHandler);
						}

						m_PlotAssociation = (D2EquidistantMeshDataAssociation)value;
					
						if(null!=m_PlotAssociation )
						{
							m_PlotAssociation.Changed += new EventHandler(OnDataChangedEventHandler);
						}

						OnDataChanged();
					}
				}
			}
		}
		public override object Style
		{
			get { return m_PlotStyle; }
			set
			{
				if(null==value)
					throw new System.ArgumentNullException();
				else if(!(value is DensityImagePlotStyle))
					throw new System.ArgumentException("The provided data object is not of the type " + m_PlotStyle.GetType().ToString() + ", but of type " + value.GetType().ToString() + "!");
				else
				{
					if(!object.ReferenceEquals(m_PlotStyle,value))
					{
						// delete event wiring to old PlotStyle
						if(null!=m_PlotStyle)
						{
							m_PlotStyle.Changed -= new EventHandler(OnStyleChangedEventHandler);
						}
					
						m_PlotStyle = (DensityImagePlotStyle)value;

						// create event wire to new Plotstyle
						if(null!=m_PlotStyle)
						{
							m_PlotStyle.Changed += new EventHandler(OnStyleChangedEventHandler);
						}

						// indicate the style has changed
						OnStyleChanged();
					}
				}
			}
		}


		public override string GetName(int level)
		{
			return m_PlotAssociation.ToString();
		}

		public override string ToString()
		{
			return GetName(int.MaxValue);
		}

		public override void Paint(Graphics g, Graph.Layer layer)
		{
			if(null!=this.m_PlotStyle)
			{
				m_PlotStyle.Paint(g,layer,m_PlotAssociation);
			}
		}

		/// <summary>
		/// Intended to used by derived classes, fires the DataChanged event and the Changed event
		/// </summary>
		public override void OnDataChanged()
		{
			// first inform our PlotStyle of the change, so it can invalidate its cached data
			if(null!=this.m_PlotStyle)
				m_PlotStyle.EhDataChanged(this);

			base.OnDataChanged();
		}


	}
}