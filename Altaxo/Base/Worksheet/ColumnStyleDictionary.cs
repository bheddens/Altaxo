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
using System.Collections.Generic;

using Altaxo.Data;

namespace Altaxo.Worksheet
{
	public class ColumnStyleDictionary : IDictionary<Data.DataColumn, ColumnStyle>
	{
		/// <summary>Column styles. Key is the column instance, value is the column style.</summary>
		Dictionary<Data.DataColumn, ColumnStyle> _columnStyles;

		/// <summary>Default column styles. Key is the type of the column, value is the default column style for this type of columns.</summary>
		Dictionary<System.Type, ColumnStyle> _defaultColumnStyles;

		#region Serialization
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(ColumnStyleDictionary), 0)]
		class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			protected ColumnStyleDictionary _deserializedInstance;
			protected Dictionary<Main.DocumentPath, ColumnStyle> _unresolvedColumns;

			public virtual void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				ColumnStyleDictionary s = (ColumnStyleDictionary)obj;

				info.CreateArray("DefaultColumnStyles", s._defaultColumnStyles.Count);
				foreach (var style in s._defaultColumnStyles)
				{
					info.CreateElement("e");
					info.AddValue("Type", style.Key.FullName);
					info.AddValue("Style", style.Value);
					info.CommitElement(); // "e"
				}
				info.CommitArray();

				info.CreateArray("ColumnStyles", s._columnStyles.Count);
				foreach (var dictentry in s._columnStyles)
				{
					info.CreateElement("e");
					info.AddValue("Column", Main.DocumentPath.GetAbsolutePath(dictentry.Key));
					info.AddValue("Style", dictentry.Value);
					info.CommitElement(); // "e"
				}
				info.CommitArray();
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				ColumnStyleDictionary s = null != o ? (ColumnStyleDictionary)o : new ColumnStyleDictionary();
				Deserialize(s, info, parent);
				return s;
			}

			protected virtual void Deserialize(ColumnStyleDictionary s, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				XmlSerializationSurrogate0 surr = new XmlSerializationSurrogate0();
				surr._unresolvedColumns = new Dictionary<Main.DocumentPath, ColumnStyle>();
				surr._deserializedInstance = s;
				info.DeserializationFinished += new Altaxo.Serialization.Xml.XmlDeserializationCallbackEventHandler(surr.EhDeserializationFinished);

				int count;

				count = info.OpenArray(); // DefaultColumnStyles
				for (int i = 0; i < count; i++)
				{
					info.OpenElement(); // "e"
					string typeName = info.GetString("Type");
					//Type t = Type.ReflectionOnlyGetType(typeName, false, false);
					Type t = Type.GetType(typeName,false,false);
					var style = (ColumnStyle)info.GetValue("Style", parent);
					s._defaultColumnStyles[t] = style;
					info.CloseElement(); // "e"
				}
				info.CloseArray(count);


				// deserialize the columnstyles
				// this must be deserialized in a new instance of this surrogate, since we can not resolve it immediately
				count = info.OpenArray();
				if (count > 0)
				{
					for (int i = 0; i < count; i++)
					{
						info.OpenElement(); // "e"
						Main.DocumentPath key = (Main.DocumentPath)info.GetValue("Column", s);
						var val = (ColumnStyle)info.GetValue("Style", s);
						surr._unresolvedColumns.Add(key, val);
						info.CloseElement();
					}
				}
				info.CloseArray(count);
			}

			public void EhDeserializationFinished(Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object documentRoot)
			{
				List<Main.DocumentPath> resolvedStyles = new List<Main.DocumentPath>();
				foreach (var entry in this._unresolvedColumns)
				{
					object resolvedobj = Main.DocumentPath.GetObject((Main.DocumentPath)entry.Key, _deserializedInstance, documentRoot);
					if (null != resolvedobj)
					{
						_deserializedInstance._columnStyles.Add((DataColumn)resolvedobj, (ColumnStyle)entry.Value);
						resolvedStyles.Add(entry.Key);
					}
				}

				foreach (var resstyle in resolvedStyles)
					_unresolvedColumns.Remove(resstyle);


				// if all columns have resolved, we can close the event link
				if (_unresolvedColumns.Count == 0)
					info.DeserializationFinished -= new Altaxo.Serialization.Xml.XmlDeserializationCallbackEventHandler(this.EhDeserializationFinished);
			}
		}

		#endregion Serialization

		public ColumnStyleDictionary()
		{
			_defaultColumnStyles = new Dictionary<Type, ColumnStyle>();
			_columnStyles = new Dictionary<Altaxo.Data.DataColumn, ColumnStyle>();
		}

		void AttachKey(DataColumn key)
		{
			key.TunneledEvent += EhKey_TunneledEvent;
		}

		void DetachKey(DataColumn key)
		{
			key.TunneledEvent -= EhKey_TunneledEvent;
		}

		void EhKey_TunneledEvent(object sender, object source, Main.TunnelingEventArgs e)
		{
			if (e is Main.DisposeEventArgs)
			{
				var c = source as DataColumn;
				if (c != null)
					this.Remove(c); // do not use direct remove, as the event handler has to be detached also
			}
		}

		internal Dictionary<System.Type, ColumnStyle> DefaultColumnStyles
		{
			get
			{
				return _defaultColumnStyles;
			}
		}

		#region IDictionary<DataColumn,ColumnStyle> Members

		public void Add(DataColumn key, ColumnStyle value)
		{
			if (null == value)
				throw new ArgumentNullException("value");

			_columnStyles.Add(key, value);
			AttachKey(key);
		}

		public bool ContainsKey(DataColumn key)
		{
			return _columnStyles.ContainsKey(key);
		}

		public ICollection<DataColumn> Keys
		{
			get { return _columnStyles.Keys; }
		}

		public bool Remove(DataColumn key)
		{
			bool result = _columnStyles.Remove(key);
			if (result)
				DetachKey(key);
			return result;
		}

		public bool TryGetValue(DataColumn key, out ColumnStyle value)
		{
			return _columnStyles.TryGetValue(key, out value);
		}

		public ICollection<ColumnStyle> Values
		{
			get { return _columnStyles.Values; }
		}

		public ColumnStyle this[DataColumn key]
		{
			get
			{
				ColumnStyle colstyle;
				// first look at the column styles hash table, column itself is the key
				if (_columnStyles.TryGetValue(key, out colstyle))
					return colstyle;

				if (_defaultColumnStyles.TryGetValue(key.GetType(), out colstyle))
					return colstyle;

				// second look to the defaultcolumnstyles hash table, key is the type of the column style

				System.Type searchstyletype = key.GetColumnStyleType();
				if (null == searchstyletype)
				{
					throw new ApplicationException("Error: Column of type +" + key.GetType() + " returns no associated ColumnStyleType, you have to overload the method GetColumnStyleType.");
				}
				else
				{
					// if not successfull yet, we will create a new defaultColumnStyle
					colstyle = (ColumnStyle)Activator.CreateInstance(searchstyletype);
					_defaultColumnStyles.Add(key.GetType(), colstyle);
					return colstyle;
				}
			}
			set
			{
				if (null == value)
					throw new ArgumentNullException("value");

				bool hadOldValue = _columnStyles.ContainsKey(key);
				_columnStyles[key] = value;
				if (!hadOldValue)
					AttachKey(key);
			}
		}





		#endregion

		#region ICollection<KeyValuePair<DataColumn,ColumnStyle>> Members

		public void Add(KeyValuePair<DataColumn, ColumnStyle> item)
		{
			((ICollection<KeyValuePair<DataColumn, ColumnStyle>>)_columnStyles).Add(item);
			AttachKey(item.Key);
		}

		public void Clear()
		{
			foreach (DataColumn c in _columnStyles.Keys)
				DetachKey(c);

			_columnStyles.Clear();
		}

		public bool Contains(KeyValuePair<DataColumn, ColumnStyle> item)
		{
			return ((ICollection<KeyValuePair<DataColumn, ColumnStyle>>)_columnStyles).Contains(item);
		}

		public void CopyTo(KeyValuePair<DataColumn, ColumnStyle>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<DataColumn, ColumnStyle>>)_columnStyles).CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get { return _columnStyles.Count; }
		}

		public bool IsReadOnly
		{
			get { return ((ICollection<KeyValuePair<DataColumn, ColumnStyle>>)_columnStyles).IsReadOnly; }
		}

		public bool Remove(KeyValuePair<DataColumn, ColumnStyle> item)
		{
			bool result = ((ICollection<KeyValuePair<DataColumn, ColumnStyle>>)_columnStyles).Remove(item);
			if (result)
				DetachKey(item.Key);
			return result;
		}

		#endregion

		#region IEnumerable<KeyValuePair<DataColumn,ColumnStyle>> Members

		public IEnumerator<KeyValuePair<DataColumn, ColumnStyle>> GetEnumerator()
		{
			return ((ICollection<KeyValuePair<DataColumn, ColumnStyle>>)_columnStyles).GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return ((ICollection<KeyValuePair<DataColumn, ColumnStyle>>)_columnStyles).GetEnumerator();
		}

		#endregion
	}

	
}
