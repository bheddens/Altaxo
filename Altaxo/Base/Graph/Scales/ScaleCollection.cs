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

using Altaxo.Graph.Scales;
using Altaxo.Graph.Scales.Boundaries;
using Altaxo.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace Altaxo.Graph.Scales
{
	[Serializable]
	public class ScaleCollection
	:
		Main.SuspendableDocumentNodeWithSetOfEventArgs,
	IEnumerable<ScaleWithTicks>
	{
		private ScaleWithTicks[] _scales = new ScaleWithTicks[2];

		/// <summary>
		/// Fired when one of the scale instances in this collection has changed.
		/// </summary>
		[field: NonSerialized]
		public event Action<object, ScaleInstanceChangedEventArgs> ScaleInstanceChanged;

		#region Serialization

		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(ScaleCollection), 0)]
		private class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public virtual void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				ScaleCollection s = (ScaleCollection)obj;

				info.CreateArray("Members", s._scales.Length);
				for (int i = 0; i < s._scales.Length; ++i)
					info.AddValue("e", s._scales[i]);
				info.CommitArray();
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				ScaleCollection s = SDeserialize(o, info, parent);
				return s;
			}

			protected virtual ScaleCollection SDeserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				ScaleCollection s = null != o ? (ScaleCollection)o : new ScaleCollection();

				int count = info.OpenArray("Members");
				s._scales = new ScaleWithTicks[count];
				for (int i = 0; i < count; ++i)
					s.SetScaleWithTicks(i, (ScaleWithTicks)info.GetValue("e", s));
				info.CloseArray(count);

				return s;
			}
		}

		#endregion Serialization

		public ScaleCollection()
		{
			_scales = new ScaleWithTicks[2];
			this.InternalSetScaleWithTicks(0, new ScaleWithTicks(new LinearScale()));
			this.InternalSetScaleWithTicks(1, new ScaleWithTicks(new LinearScale()));
		}

		public ScaleCollection(ScaleCollection from)
		{
			CopyFrom(from);
		}

		public void CopyFrom(ScaleCollection from)
		{
			if (object.ReferenceEquals(this, from))
				return;

			using (var suspendToken = this.SuspendGetToken())
			{
				int len = Math.Min(this._scales.Length, from._scales.Length);
				for (int i = 0; i < len; i++)
				{
					this.InternalSetScaleWithTicks(i, (ScaleWithTicks)from._scales[i].Clone());
				}

				suspendToken.Resume();
			}
		}

		protected override System.Collections.Generic.IEnumerable<Main.DocumentNodeAndName> GetDocumentNodeChildrenWithName()
		{
			for (int i = _scales.Length - 1; i >= 0; --i)
			{
				if (null != _scales[i])
					yield return new Main.DocumentNodeAndName(_scales[i], "Scale" + i.ToString(System.Globalization.CultureInfo.InvariantCulture));
			}
		}

		public ScaleCollection Clone()
		{
			return new ScaleCollection(this);
		}

		public int Count
		{
			get
			{
				return _scales.Length;
			}
		}

		public string GetName(int idx)
		{
			switch (idx)
			{
				case 0:
					return "X";

				case 1:
					return "Y";

				case 2:
					return "Z";

				default:
					return "Scale" + idx.ToString();
			}
		}

		public ScaleWithTicks X
		{
			get
			{
				return _scales[0];
			}
		}

		public ScaleWithTicks Y
		{
			get
			{
				return _scales[1];
			}
		}

		public ScaleWithTicks this[int i]
		{
			get
			{
				return _scales[i];
			}
			set
			{
				InternalSetScaleWithTicks(i, value);
			}
		}

		public Scale Scale(int i)
		{
			return _scales[i].Scale;
		}

		public void SetScale(int i, Scale ax)
		{
			SetScaleWithTicks(i, new ScaleWithTicks(ax));
		}

		public void SetScaleWithTicks(int i, Scale scale, Ticks.TickSpacing ticks)
		{
			_scales[i].SetTo(scale, ticks);
		}

		public void SetScaleWithTicks(int i, ScaleWithTicks scaleWithTicks)
		{
			InternalSetScaleWithTicks(i, scaleWithTicks);
		}

		public int IndexOf(Scale ax)
		{
			for (int i = 0; i < _scales.Length; i++)
			{
				if (_scales[i].Scale == ax)
					return i;
			}

			return -1;
		}

		protected void InternalSetScaleWithTicks(int i, ScaleWithTicks newvalue)
		{
			ScaleWithTicks oldvalue = _scales[i];
			_scales[i] = newvalue;

			if (!object.ReferenceEquals(oldvalue, newvalue))
			{
				if (null != oldvalue)
				{
					oldvalue.ParentObject = null;
				}
				if (null != newvalue)
				{
					newvalue.ParentObject = this;
				}
			}
		}

		public void EhLinkedLayerScaleInstanceChanged(int idx, Scale oldScale, Scale newScale)
		{
			if (X.Scale is LinkedScale)
				((LinkedScale)X.Scale).EhLinkedLayerScaleInstanceChanged(idx, oldScale, newScale);

			if (Y.Scale is LinkedScale)
				((LinkedScale)Y.Scale).EhLinkedLayerScaleInstanceChanged(idx, oldScale, newScale);
		}

		#region IDocumentNode Members

		public override string Name
		{
			get { return "Scales"; }
			set
			{
				throw new InvalidOperationException("Name cannot be set");
			}
		}

		#endregion IDocumentNode Members

		public IEnumerator<ScaleWithTicks> GetEnumerator()
		{
			for (int i = 0; i < _scales.Length; ++i)
				yield return _scales[i];
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			for (int i = 0; i < _scales.Length; ++i)
				yield return _scales[i];
		}

		#region Changed event handling

		protected override bool HandleHighPriorityChildChangeCases(object sender, ref EventArgs e)
		{
			var es = e as ScaleInstanceChangedEventArgs;
			if (null != es)
			{
				es.ScaleIndex = IndexOf(es.NewScale);
			}

			return base.HandleHighPriorityChildChangeCases(sender, ref e);
		}

		protected override void OnChanged(EventArgs e)
		{
			var es = e as ScaleInstanceChangedEventArgs;
			if (null != es && null != ScaleInstanceChanged)
			{
				ScaleInstanceChanged(this, es);
			}

			base.OnChanged(e);
		}

		#endregion Changed event handling
	}
}