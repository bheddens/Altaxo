﻿using Altaxo.Calc.Fourier.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altaxo.Calc.Fourier
{
	/// <summary>
	/// Holds serialiazation surrogates for FourierWindow2D classes
	/// </summary>
	internal static class FourierWindows2DSerialization
	{
		private class XmlSerializationSurrogateForEmptyClasses<T> : Altaxo.Serialization.Xml.IXmlSerializationSurrogate where T : new()
		{
			public virtual void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				TypeSafeSerialize((T)obj, info);
			}

			protected virtual void TypeSafeSerialize(T s, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
			}

			protected virtual void TypeSafeDeserialize(T s, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				var s = (o == null ? new T() : (T)o);
				TypeSafeDeserialize(s, info, parent);
				return s;
			}
		}

		/// <summary>2014-07-11 initial version.</summary>
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(HanningWindow2D), 0)]
		private class XmlSerializationSurrogateHanningWindow2D : XmlSerializationSurrogateForEmptyClasses<HanningWindow2D>
		{
		}

		/// <summary>2014-07-11 initial version.</summary>
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(BartlettWindow2D), 0)]
		private class XmlSerializationSurrogateBartlettWindow2D : XmlSerializationSurrogateForEmptyClasses<BartlettWindow2D>
		{
		}

		/// <summary>2014-07-11 initial version.</summary>
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(ParzenWindow2D), 0)]
		private class XmlSerializationSurrogateParzenWindow2D : XmlSerializationSurrogateForEmptyClasses<ParzenWindow2D>
		{
		}

		/// <summary>2014-07-11 initial version.</summary>
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(GaussWindow2D), 0)]
		private class XmlSerializationSurrogateGaussWindow2D : XmlSerializationSurrogateForEmptyClasses<GaussWindow2D>
		{
			protected override void TypeSafeSerialize(GaussWindow2D s, Serialization.Xml.IXmlSerializationInfo info)
			{
				info.AddValue("Sigma", s.Sigma);
			}

			protected override void TypeSafeDeserialize(GaussWindow2D s, Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				s.Sigma = info.GetDouble("Sigma");
			}
		}

		/// <summary>2014-07-11 initial version.</summary>
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(SuperGaussWindow2D), 0)]
		private class XmlSerializationSurrogateSuperGaussWindow2D : XmlSerializationSurrogateForEmptyClasses<SuperGaussWindow2D>
		{
			protected override void TypeSafeSerialize(SuperGaussWindow2D s, Serialization.Xml.IXmlSerializationInfo info)
			{
				info.AddValue("Kappa", s.Kappa);
			}

			protected override void TypeSafeDeserialize(SuperGaussWindow2D s, Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				s.Kappa = info.GetDouble("Kappa");
			}
		}

		/// <summary>2014-07-11 initial version.</summary>
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(EllipticWindow2D), 0)]
		private class XmlSerializationSurrogateEllipticWindow2D : XmlSerializationSurrogateForEmptyClasses<EllipticWindow2D>
		{
		}

		/// <summary>2014-07-11 initial version.</summary>
		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(CosineWindow2D), 0)]
		private class XmlSerializationSurrogateCosineWindow2D : XmlSerializationSurrogateForEmptyClasses<CosineWindow2D>
		{
		}
	}
}