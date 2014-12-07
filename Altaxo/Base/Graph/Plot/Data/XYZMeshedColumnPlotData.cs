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
using Altaxo.Data;
using Altaxo.Graph.Scales.Boundaries;
using Altaxo.Main;
using Altaxo.Serialization;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Altaxo.Graph.Plot.Data
{
	/// <summary>
	/// Summary description for XYColumnPlotData.
	/// </summary>
	[Serializable]
	public class XYZMeshedColumnPlotData
		:
		Main.IChangedEventSource,
		Main.IChildChangedEventSink,
		System.ICloneable,
		Main.IDocumentNode,
		System.Runtime.Serialization.IDeserializationCallback
	{
		[NonSerialized]
		protected object _parent;

		protected DataTableMatrixProxy _matrixProxy;

		// cached or temporary data
		[NonSerialized]
		protected IPhysicalBoundaries _xBoundaries;

		[NonSerialized]
		protected IPhysicalBoundaries _yBoundaries;

		[NonSerialized]
		protected IPhysicalBoundaries _vBoundaries;

		[NonSerialized]
		protected bool _isCachedDataValid = false;

		// events
		[field: NonSerialized]
		public event BoundaryChangedHandler XBoundariesChanged;

		[field: NonSerialized]
		public event BoundaryChangedHandler YBoundariesChanged;

		[field: NonSerialized]
		public event BoundaryChangedHandler VBoundariesChanged;

		/// <summary>
		/// Fired if either the data of this XYColumnPlotData changed or if the bounds changed
		/// </summary>
		[field: NonSerialized]
		public event System.EventHandler Changed;

		/// <summary>
		/// Gets or sets the plot range start. Currently, this value is always 0.
		/// </summary>
		public int PlotRangeStart { get { return 0; } set { } }

		/// <summary>
		/// Gets or sets the plot range length. Currently, this value is always <c>int.MaxValue</c>.
		/// </summary>
		public int PlotRangeLength { get { return int.MaxValue; } set { } }

		#region Serialization

		#region Clipboard

		public void OnDeserialization(object sender)
		{
			CreateEventChain();
		}

		#endregion Clipboard

		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.XYZEquidistantMeshColumnPlotData", 0)]
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(XYZMeshedColumnPlotData), 1)]
		private class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				throw new ApplicationException("Calling a deprecated serialization handler for XYZMeshedColumnPlotData");
				/*
				XYZMeshedColumnPlotData s = (XYZMeshedColumnPlotData)obj;

				if(s.m_XColumn is Main.IDocumentNode && !s.Equals(((Main.IDocumentNode)s.m_XColumn).ParentObject))
				{
					info.AddValue("XColumn",Main.DocumentPath.GetAbsolutePath((Main.IDocumentNode)s.m_XColumn));
				}
				else
				{
					info.AddValue("XColumn",s.m_XColumn);
				}

				if(s.m_YColumn is Main.IDocumentNode && !s.Equals(((Main.IDocumentNode)s.m_YColumn).ParentObject))
				{
					info.AddValue("YColumn",Main.DocumentPath.GetAbsolutePath((Main.IDocumentNode)s.m_YColumn));
				}
				else
				{
					info.AddValue("YColumn",s.m_YColumn);
				}

				info.CreateArray("DataColumns",s.m_DataColumns.Length);
				for(int i=0;i<s.m_DataColumns.Length;i++)
				{
					Altaxo.Data.IReadableColumn col = s.m_DataColumns[i];
					if(col is Main.IDocumentNode && !s.Equals(((Main.IDocumentNode)col).ParentObject))
					{
						info.AddValue("e",Main.DocumentPath.GetAbsolutePath((Main.IDocumentNode)col));
					}
					else
					{
						info.AddValue("e",col);
					}
				}
				info.CommitArray();

				info.AddValue("XBoundaries",s.m_xBoundaries);
				info.AddValue("YBoundaries",s.m_yBoundaries);
				info.AddValue("VBoundaries",s.m_vBoundaries);
				*/
			}

			private Main.DocumentPath _xColumnPath = null;
			private Main.DocumentPath _yColumnPath = null;
			private Main.DocumentPath[] _vColumnPaths = null;

			private ReadableColumnProxy _xColumnProxy = null;
			private ReadableColumnProxy _yColumnProxy = null;
			private ReadableColumnProxy[] _vColumnProxies = null;

			private XYZMeshedColumnPlotData _plotAssociation = null;

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				bool bSurrogateUsed = false;

				XYZMeshedColumnPlotData s = null != o ? (XYZMeshedColumnPlotData)o : new XYZMeshedColumnPlotData();

				XmlSerializationSurrogate0 surr = new XmlSerializationSurrogate0();

#pragma warning disable 618
				s._matrixProxy = DataTableMatrixProxy.CreateEmptyInstance(); // this instance is replaced later in the deserialization callback function and is intended to avoid null reference errors
#pragma warning restore 618

				object deserobj;
				deserobj = info.GetValue("XColumn", s);
				if (deserobj is Main.DocumentPath)
				{
					surr._xColumnPath = (Main.DocumentPath)deserobj;
					bSurrogateUsed = true;
				}
				else
				{
					surr._xColumnProxy = new ReadableColumnProxy((Altaxo.Data.INumericColumn)deserobj);
				}

				deserobj = info.GetValue("YColumn", s);
				if (deserobj is Main.DocumentPath)
				{
					surr._yColumnPath = (Main.DocumentPath)deserobj;
					bSurrogateUsed = true;
				}
				else
				{
					surr._yColumnProxy = new ReadableColumnProxy((Altaxo.Data.INumericColumn)deserobj);
				}

				int count = info.OpenArray();
				surr._vColumnPaths = new Main.DocumentPath[count];
				surr._vColumnProxies = new ReadableColumnProxy[count];
				for (int i = 0; i < count; i++)
				{
					deserobj = info.GetValue("e", s);
					if (deserobj is Main.DocumentPath)
					{
						surr._vColumnPaths[i] = (Main.DocumentPath)deserobj;
						bSurrogateUsed = true;
					}
					else
					{
						surr._vColumnProxies[i] = new ReadableColumnProxy((Altaxo.Data.IReadableColumn)deserobj);
					}
				}
				info.CloseArray(count);

				s._xBoundaries = (IPhysicalBoundaries)info.GetValue("XBoundaries", parent);
				s._yBoundaries = (IPhysicalBoundaries)info.GetValue("YBoundaries", parent);
				s._vBoundaries = (IPhysicalBoundaries)info.GetValue("VBoundaries", parent);

				s._xBoundaries.BoundaryChanged += new BoundaryChangedHandler(s.OnXBoundariesChangedEventHandler);
				s._yBoundaries.BoundaryChanged += new BoundaryChangedHandler(s.OnYBoundariesChangedEventHandler);
				s._vBoundaries.BoundaryChanged += new BoundaryChangedHandler(s.OnVBoundariesChangedEventHandler);

				if (bSurrogateUsed)
				{
					surr._plotAssociation = s;
					info.DeserializationFinished += new Altaxo.Serialization.Xml.XmlDeserializationCallbackEventHandler(surr.EhDeserializationFinished);
				}

				return s;
			}

			public void EhDeserializationFinished(Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object documentRoot, bool isFinallyCall)
			{
				bool bAllResolved = true;

				if (this._xColumnPath != null)
				{
					object xColumn = Main.DocumentPath.GetObject(this._xColumnPath, this._plotAssociation, documentRoot);
					bAllResolved &= (null != xColumn);
					if (xColumn is Altaxo.Data.INumericColumn)
					{
						this._xColumnPath = null;
						this._xColumnProxy = new ReadableColumnProxy((Altaxo.Data.INumericColumn)xColumn);
					}
				}

				if (this._yColumnPath != null)
				{
					object yColumn = Main.DocumentPath.GetObject(this._yColumnPath, this._plotAssociation, documentRoot);
					bAllResolved &= (null != yColumn);
					if (yColumn is Altaxo.Data.INumericColumn)
					{
						this._yColumnPath = null;
						this._yColumnProxy = new ReadableColumnProxy((Altaxo.Data.INumericColumn)yColumn);
					}
				}

				for (int i = 0; i < this._vColumnPaths.Length; i++)
				{
					if (this._vColumnPaths[i] != null)
					{
						object vColumn = Main.DocumentPath.GetObject(this._vColumnPaths[i], this._plotAssociation, documentRoot);
						bAllResolved &= (null != vColumn);
						if (vColumn is Altaxo.Data.IReadableColumn)
						{
							this._vColumnPaths[i] = null;
							this._vColumnProxies[i] = new ReadableColumnProxy((Altaxo.Data.IReadableColumn)vColumn);
						}
					}
				}

				if (bAllResolved || isFinallyCall)
				{
					info.DeserializationFinished -= new Altaxo.Serialization.Xml.XmlDeserializationCallbackEventHandler(this.EhDeserializationFinished);
#pragma warning disable 618
					_plotAssociation._matrixProxy = new DataTableMatrixProxy(_xColumnProxy, _yColumnProxy, _vColumnProxies) { ParentObject = _plotAssociation };
#pragma warning restore 618
				}
			}
		}

		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(XYZMeshedColumnPlotData), 2)]
		private class XmlSerializationSurrogate1 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				throw new InvalidOperationException("Serialization of old versions not supported.");
				/*

				XYZMeshedColumnPlotData s = (XYZMeshedColumnPlotData)obj;

				info.AddValue("XColumn", s._xColumn);
				info.AddValue("YColumn", s._yColumn);

				info.CreateArray("DataColumns", s._dataColumns.Length);
				for (int i = 0; i < s._dataColumns.Length; i++)
				{
					info.AddValue("e", s._dataColumns[i]);
				}
				info.CommitArray();

				info.AddValue("XBoundaries", s._xBoundaries);
				info.AddValue("YBoundaries", s._yBoundaries);
				info.AddValue("VBoundaries", s._vBoundaries);
				*/
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				XYZMeshedColumnPlotData s = null != o ? (XYZMeshedColumnPlotData)o : new XYZMeshedColumnPlotData();

				var _xColumn = (ReadableColumnProxy)info.GetValue("XColumn", parent);
				var _yColumn = (ReadableColumnProxy)info.GetValue("YColumn", parent);

				int count = info.OpenArray();
				var _dataColumns = new ReadableColumnProxy[count];
				for (int i = 0; i < count; i++)
				{
					_dataColumns[i] = (ReadableColumnProxy)info.GetValue("e", parent);
				}
				info.CloseArray(count);

#pragma warning disable 618
				s._matrixProxy = new DataTableMatrixProxy(_xColumn, _yColumn, _dataColumns);
#pragma warning restore 618

				s._xBoundaries = (IPhysicalBoundaries)info.GetValue("XBoundaries", parent);
				s._yBoundaries = (IPhysicalBoundaries)info.GetValue("YBoundaries", parent);
				s._vBoundaries = (IPhysicalBoundaries)info.GetValue("VBoundaries", parent);

				s._matrixProxy.ParentObject = s;
				s._xBoundaries.BoundaryChanged += new BoundaryChangedHandler(s.OnXBoundariesChangedEventHandler);
				s._yBoundaries.BoundaryChanged += new BoundaryChangedHandler(s.OnYBoundariesChangedEventHandler);
				s._vBoundaries.BoundaryChanged += new BoundaryChangedHandler(s.OnVBoundariesChangedEventHandler);

				s._isCachedDataValid = false;

				return s;
			}
		}

		/// <summary>2014-07-08 using _matrixProxy instead of single proxies for columns</summary>
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(XYZMeshedColumnPlotData), 3)]
		private class XmlSerializationSurrogate3 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				XYZMeshedColumnPlotData s = (XYZMeshedColumnPlotData)obj;

				info.AddValue("MatrixProxy", s._matrixProxy);

				info.AddValue("XBoundaries", s._xBoundaries);
				info.AddValue("YBoundaries", s._yBoundaries);
				info.AddValue("VBoundaries", s._vBoundaries);
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				XYZMeshedColumnPlotData s = null != o ? (XYZMeshedColumnPlotData)o : new XYZMeshedColumnPlotData();

				s._matrixProxy = (DataTableMatrixProxy)info.GetValue("MatrixProxy");

				s._xBoundaries = (IPhysicalBoundaries)info.GetValue("XBoundaries", parent);
				s._yBoundaries = (IPhysicalBoundaries)info.GetValue("YBoundaries", parent);
				s._vBoundaries = (IPhysicalBoundaries)info.GetValue("VBoundaries", parent);

				s._matrixProxy.ParentObject = s;
				s._xBoundaries.BoundaryChanged += new BoundaryChangedHandler(s.OnXBoundariesChangedEventHandler);
				s._yBoundaries.BoundaryChanged += new BoundaryChangedHandler(s.OnYBoundariesChangedEventHandler);
				s._vBoundaries.BoundaryChanged += new BoundaryChangedHandler(s.OnVBoundariesChangedEventHandler);

				s._isCachedDataValid = false;

				return s;
			}
		}

		/// <summary>
		/// Finale measures after deserialization.
		/// </summary>
		public void CreateEventChain()
		{
			// restore the event chain

			_xBoundaries.BoundaryChanged += new BoundaryChangedHandler(this.OnXBoundariesChangedEventHandler);
			_yBoundaries.BoundaryChanged += new BoundaryChangedHandler(this.OnYBoundariesChangedEventHandler);
			_vBoundaries.BoundaryChanged += new BoundaryChangedHandler(this.OnVBoundariesChangedEventHandler);

			// do not calculate cached data here, since it is done the first time this data is really needed
			this._isCachedDataValid = false;
		}

		#endregion Serialization

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		protected XYZMeshedColumnPlotData()
		{
		}

		public XYZMeshedColumnPlotData(DataTable table, IAscendingIntegerCollection selectedDataRows, IAscendingIntegerCollection selectedDataColumns, IAscendingIntegerCollection selectedPropertyColumns)
		{
			_matrixProxy = new DataTableMatrixProxy(table, selectedDataRows, selectedDataColumns, selectedPropertyColumns) { ParentObject = this };
			this.SetXBoundsFromTemplate(new FiniteNumericalBoundaries());
			this.SetYBoundsFromTemplate(new FiniteNumericalBoundaries());
			this.SetVBoundsFromTemplate(new FiniteNumericalBoundaries());
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="from">The object to copy from.</param>
		/// <remarks>Only clones the references to the data columns, not the columns itself.</remarks>
		public XYZMeshedColumnPlotData(XYZMeshedColumnPlotData from)
		{
			CopyHelper.Copy(ref _matrixProxy, from._matrixProxy);
			_matrixProxy.ParentObject = this;

			this.SetXBoundsFromTemplate(new FiniteNumericalBoundaries());
			this.SetYBoundsFromTemplate(new FiniteNumericalBoundaries());
			this.SetVBoundsFromTemplate(new FiniteNumericalBoundaries());
		}

		/// <summary>
		/// Creates a cloned copy of this object.
		/// </summary>
		/// <returns>The cloned copy of this object.</returns>
		/// <remarks>The data columns refered by this object are <b>not</b> cloned, only the reference is cloned here.</remarks>
		public object Clone()
		{
			return new XYZMeshedColumnPlotData(this);
		}

		public DataTableMatrixProxy DataTableMatrix
		{
			get
			{
				return this._matrixProxy;
			}
		}

		public void MergeXBoundsInto(IPhysicalBoundaries pb)
		{
			if (!this._isCachedDataValid)
				this.CalculateCachedData();
			pb.Add(_xBoundaries);
		}

		public void MergeYBoundsInto(IPhysicalBoundaries pb)
		{
			if (!this._isCachedDataValid)
				this.CalculateCachedData();
			pb.Add(_yBoundaries);
		}

		public void MergeVBoundsInto(IPhysicalBoundaries pb)
		{
			if (!this._isCachedDataValid)
				this.CalculateCachedData();
			pb.Add(_vBoundaries);
		}

		public void SetXBoundsFromTemplate(IPhysicalBoundaries val)
		{
			if (null == _xBoundaries || val.GetType() != _xBoundaries.GetType())
			{
				if (null != _xBoundaries)
				{
					_xBoundaries.BoundaryChanged -= new BoundaryChangedHandler(this.OnXBoundariesChangedEventHandler);
				}
				_xBoundaries = (IPhysicalBoundaries)val.Clone();
				_xBoundaries.BoundaryChanged += new BoundaryChangedHandler(this.OnXBoundariesChangedEventHandler);
				this._isCachedDataValid = false;

				OnChanged();
			}
		}

		public void SetYBoundsFromTemplate(IPhysicalBoundaries val)
		{
			if (null == _yBoundaries || val.GetType() != _yBoundaries.GetType())
			{
				if (null != _yBoundaries)
				{
					_yBoundaries.BoundaryChanged -= new BoundaryChangedHandler(this.OnYBoundariesChangedEventHandler);
				}
				_yBoundaries = (IPhysicalBoundaries)val.Clone();
				_yBoundaries.BoundaryChanged += new BoundaryChangedHandler(this.OnYBoundariesChangedEventHandler);
				this._isCachedDataValid = false;

				OnChanged();
			}
		}

		public void SetVBoundsFromTemplate(IPhysicalBoundaries val)
		{
			if (null == _vBoundaries || val.GetType() != _vBoundaries.GetType())
			{
				if (null != _vBoundaries)
				{
					_vBoundaries.BoundaryChanged -= new BoundaryChangedHandler(this.OnVBoundariesChangedEventHandler);
				}
				_vBoundaries = (IPhysicalBoundaries)val.Clone();
				_vBoundaries.BoundaryChanged += new BoundaryChangedHandler(this.OnVBoundariesChangedEventHandler);
				this._isCachedDataValid = false;

				OnChanged();
			}
		}

		protected virtual void OnXBoundariesChangedEventHandler(object sender, BoundariesChangedEventArgs e)
		{
			if (null != this.XBoundariesChanged)
				XBoundariesChanged(this, e);

			OnChanged();
		}

		protected virtual void OnYBoundariesChangedEventHandler(object sender, BoundariesChangedEventArgs e)
		{
			if (null != this.YBoundariesChanged)
				YBoundariesChanged(this, e);

			OnChanged();
		}

		protected virtual void OnVBoundariesChangedEventHandler(object sender, BoundariesChangedEventArgs e)
		{
			if (null != this.VBoundariesChanged)
				VBoundariesChanged(this, e);

			OnChanged();
		}

		public int RowCount
		{
			get
			{
				return _matrixProxy.RowCount;
			}
		}

		public int ColumnCount
		{
			get
			{
				return _matrixProxy.ColumnCount;
			}
		}

		public Altaxo.Data.IReadableColumn GetDataColumn(int i)
		{
			return _matrixProxy.GetDataColumnProxy(i).Document;
		}

		public Altaxo.Data.IReadableColumn XColumn
		{
			get
			{
				return _matrixProxy.RowHeaderColumn;
			}
		}

		public Altaxo.Data.IReadableColumn YColumn
		{
			get
			{
				return _matrixProxy.ColumnHeaderColumn;
			}
		}

		public override string ToString()
		{
			var colCount = _matrixProxy.ColumnCount;

			if (colCount > 0)
				return String.Format("PictureData {0}-{1}", _matrixProxy.GetDataColumnProxy(0).GetName(2), _matrixProxy.GetDataColumnProxy(colCount - 1).GetName(2));
			else
				return "Empty (no data)";
		}

		public void CalculateCachedData(IPhysicalBoundaries xBounds, IPhysicalBoundaries yBounds)
		{
			if (_xBoundaries == null || (xBounds != null && _xBoundaries.GetType() != xBounds.GetType()))
				this.SetXBoundsFromTemplate(xBounds);

			if (_yBoundaries == null || (yBounds != null && _yBoundaries.GetType() != yBounds.GetType()))
				this.SetYBoundsFromTemplate(yBounds);

			CalculateCachedData();
		}

		public void CalculateCachedData()
		{
			if (0 == RowCount || 0 == ColumnCount)
				return;

			using (var suspendTokenX = this._xBoundaries.SuspendGetToken())
			{
				using (var suspendTokenY = this._yBoundaries.SuspendGetToken())
				{
					using (var suspendTokenV = this._vBoundaries.SuspendGetToken())
					{
						this._xBoundaries.Reset();
						this._yBoundaries.Reset();
						this._vBoundaries.Reset();

						_matrixProxy.ForEachMatrixElementDo((col, idx) => this._vBoundaries.Add(col, idx));
						_matrixProxy.ForEachRowHeaderElementDo((col, idx) => this._xBoundaries.Add(col, idx));
						_matrixProxy.ForEachColumnHeaderElementDo((col, idx) => this._yBoundaries.Add(col, idx));

						// now the cached data are valid
						_isCachedDataValid = true;

						// now when the cached data are valid, we can reenable the events
						suspendTokenV.Resume();
					}
					suspendTokenY.Resume();
				}
				suspendTokenX.Resume();
			}
		}

		public void EhChildChanged(object child, EventArgs e)
		{
			if (object.ReferenceEquals(child, _matrixProxy))
			{
				_isCachedDataValid = false;
				OnChanged();
			}
		}

		protected virtual void OnChanged()
		{
			if (_parent is Main.IChildChangedEventSink)
				((Main.IChildChangedEventSink)_parent).EhChildChanged(this, EventArgs.Empty);

			if (null != Changed)
				Changed(this, EventArgs.Empty);
		}

		public virtual object ParentObject
		{
			get { return _parent; }
			set { _parent = value; }
		}

		public virtual string Name
		{
			get
			{
				Main.INamedObjectCollection noc = ParentObject as Main.INamedObjectCollection;
				return null == noc ? null : noc.GetNameOfChildObject(this);
			}
		}

		/// <summary>
		/// Replaces path of items (intended for data items like tables and columns) by other paths. Thus it is possible
		/// to change a plot so that the plot items refer to another table.
		/// </summary>
		/// <param name="Report">Function that reports the found <see cref="DocNodeProxy"/> instances to the visitor.</param>
		public void VisitDocumentReferences(DocNodeProxyReporter Report)
		{
			_matrixProxy.VisitDocumentReferences(Report);
		}
	}
} // end name space