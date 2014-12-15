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

namespace Altaxo.Graph.Scales.Boundaries
{
	/// <summary>
	/// Provides a abstract class for tracking the numerical
	/// boundaries of a plot association. Every plot association has two of these objects
	/// that help tracking the boundaries of X and Y axis
	/// </summary>
	[Serializable]
	public abstract class NumericalBoundaries : AbstractPhysicalBoundaries, System.Runtime.Serialization.IDeserializationCallback
	{
		protected double _minValue = double.MaxValue;
		protected double _maxValue = double.MinValue;

		[NonSerialized]
		private double _cachedMinValue, _cachedMaxValue; // stores the minValue and MaxValue in the moment if the events where disabled

		#region Serialization

		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.PhysicalBoundaries", 0)]
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.Axes.Boundaries.NumericalBoundaries", 1)]
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(NumericalBoundaries), 2)]
		private class XmlSerializationSurrogate1 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				NumericalBoundaries s = (NumericalBoundaries)obj;
				info.AddValue("NumberOfItems", s._numberOfItems);
				info.AddValue("MinValue", s._minValue);
				info.AddValue("MaxValue", s._maxValue);
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				NumericalBoundaries s = (NumericalBoundaries)o;

				s._numberOfItems = info.GetInt32("NumberOfItems");
				s._minValue = info.GetDouble("MinValue");
				s._maxValue = info.GetDouble("MaxValue");

				return s;
			}
		}

		/// <summary>
		/// Finale measures after deserialization.
		/// </summary>
		/// <param name="obj">Not used.</param>
		public virtual void OnDeserialization(object obj)
		{
		}

		#endregion Serialization

		public NumericalBoundaries()
		{
			_minValue = double.MaxValue;
			_maxValue = double.MinValue;
		}

		public NumericalBoundaries(NumericalBoundaries x)
			: base(x)
		{
			_minValue = x._minValue;
			_maxValue = x._maxValue;
		}

		/// <summary>
		/// Reset the internal data to the initialized state
		/// </summary>
		public override void Reset()
		{
			base.Reset();
			_minValue = Double.MaxValue;
			_maxValue = Double.MinValue;
		}

		public virtual double LowerBound { get { return _minValue; } }

		public virtual double UpperBound { get { return _maxValue; } }

		/// <summary>
		/// merged boundaries of another object into this object
		/// </summary>
		/// <param name="b">another physical boundary object of the same type as this</param>
		public virtual void Add(NumericalBoundaries b)
		{
			if (this.GetType() == b.GetType())
			{
				if (b._numberOfItems > 0)
				{
					BoundariesChangedData data = BoundariesChangedData.NumberOfItemsChanged;

					_numberOfItems += b._numberOfItems;
					if (b._minValue < _minValue)
					{
						_minValue = b._minValue;
						data |= BoundariesChangedData.LowerBoundChanged;
					}
					if (b._maxValue > _maxValue)
					{
						_maxValue = b._maxValue;
						data |= BoundariesChangedData.UpperBoundChanged;
					}

					if (!IsSuspended) // performance tweak, see overrides OnSuspended and OnResume for details (if suspended, we have saved the state of the instance for comparison when we resume).
						EhSelfChanged(new BoundariesChangedEventArgs(data));
				}
			}
			else
			{
				throw new ArgumentException("Argument has not the same type as this, argument type: " + b.GetType().ToString() + ", this type: " + this.GetType().ToString());
			}
		}

		/// <summary>
		/// Manipulates the boundaries by shifting them by a certain amount.
		/// Don't use this function unless you are absoluteley sure what you do.
		/// This function is intended for coordinate transforming styles only.
		/// </summary>
		/// <param name="amount">The amount by which to shift the boundaries.</param>
		public void Shift(double amount)
		{
			_minValue += amount;
			_maxValue += amount;
		}

		#region IPhysicalBoundaries Members

		public override void Add(IPhysicalBoundaries b)
		{
			Add((NumericalBoundaries)b);
		}

		#endregion IPhysicalBoundaries Members

		#region Changed event handling

		/// <summary>
		/// For performance reasons, we save the current state of this instance here if the item is suspended. When the item is resumed, we compare the saved state
		/// with the current state and set our accumulated data accordingly.
		/// </summary>
		protected override void OnSuspended()
		{
			this._savedNumberOfItems = this._numberOfItems;
			this._cachedMinValue = this._minValue;
			this._cachedMaxValue = this._maxValue;

			base.OnSuspended();
		}

		/// <summary>
		/// For performance reasons, we don't call EhSelfChanged during the suspended state. Instead, when we resume here, we compare the saved state of this instance with the current state of the instance
		/// and and set our accumulated data accordingly.
		/// </summary>
		protected override void OnResume()
		{
			BoundariesChangedData data = 0;

			// if anything changed in the meantime, fire the event
			if (this._savedNumberOfItems != this._numberOfItems)
				data |= BoundariesChangedData.NumberOfItemsChanged;

			if (this._cachedMinValue != this._minValue)
				data |= BoundariesChangedData.LowerBoundChanged;

			if (this._cachedMaxValue != this._maxValue)
				data |= BoundariesChangedData.UpperBoundChanged;

			if(0!=data)
				_accumulatedEventData = new BoundariesChangedEventArgs(data);

			base.OnResume();
		}

		#endregion Changed event handling
	}
}