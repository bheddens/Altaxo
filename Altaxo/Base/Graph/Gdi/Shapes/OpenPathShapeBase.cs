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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Altaxo.Graph.Gdi.Shapes
{
  /// <summary>
  /// Base class for all open (not closed) shapes, like line, curly brace etc.
  /// </summary>
  [Serializable]
  public abstract class OpenPathShapeBase : GraphicBase, IRoutedPropertyReceiver
  {
    /// <summary>If not null, this pens draw the outline of the shape.</summary>
    protected PenX _outlinePen;

    /// <summary>Pen to draw the shape.</summary>
    protected PenX _linePen;

    #region Serialization

    [Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(OpenPathShapeBase), 0)]
    private class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
    {
      public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
      {
        var s = (OpenPathShapeBase)obj;
        info.AddBaseValueEmbedded(s, typeof(OpenPathShapeBase).BaseType);

        info.AddValue("LinePen", s._linePen);
        info.AddValue("OutlinePen", s._outlinePen);
      }

      public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {
        var s = (OpenPathShapeBase)o;
        info.GetBaseValueEmbedded(s, typeof(OpenPathShapeBase).BaseType, parent);

        s.Pen = (PenX)info.GetValue("LinePen", s);
        s.OutlinePen = (PenX)info.GetValue("OutlinePen", s);
        return s;
      }
    }

    #endregion Serialization

    protected OpenPathShapeBase(ItemLocationDirect location, Altaxo.Serialization.Xml.IXmlDeserializationInfo info)
      : base(location)
    {
    }

    protected OpenPathShapeBase(ItemLocationDirect location, Altaxo.Main.Properties.IReadOnlyPropertyBag context)
      : base(location)
    {
      if (null == context)
        context = PropertyExtensions.GetPropertyContextOfProject();

      var penWidth = GraphDocument.GetDefaultPenWidth(context);
      var foreColor = context.GetValue(GraphDocument.PropertyKeyDefaultForeColor);
      Pen = new PenX(foreColor, penWidth);
    }

    public OpenPathShapeBase(OpenPathShapeBase from)
      :
      base(from) // all is done here, since CopyFrom is virtual!
    {
    }

    public override bool CopyFrom(object obj)
    {
      var isCopied = base.CopyFrom(obj);
      if (isCopied && !object.ReferenceEquals(this, obj))
      {
        var from = obj as OpenPathShapeBase;
        if (from != null)
        {
          ChildCopyToMember(ref _outlinePen, from._outlinePen);
          ChildCopyToMember(ref _linePen, from._linePen);
        }
      }
      return isCopied;
    }

    private IEnumerable<Main.DocumentNodeAndName> GetMyDocumentNodeChildrenWithName()
    {
      if (null != _linePen)
        yield return new Main.DocumentNodeAndName(_linePen, () => _linePen = null, "LinePen");

      if (null != _outlinePen)
        yield return new Main.DocumentNodeAndName(_outlinePen, () => _outlinePen = null, "OutlinePen");
    }

    protected override IEnumerable<Main.DocumentNodeAndName> GetDocumentNodeChildrenWithName()
    {
      return base.GetDocumentNodeChildrenWithName().Concat(GetMyDocumentNodeChildrenWithName());
    }

    public virtual PenX Pen
    {
      get
      {
        return _linePen;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException("The line pen must not be null");
        if (object.ReferenceEquals(_linePen, value))
          return;

        ChildCopyToMember(ref _linePen, value); // we always clone to have full control

        EhSelfChanged(EventArgs.Empty);
      }
    }

    public virtual PenX OutlinePen
    {
      get
      {
        return _outlinePen;
      }
      set
      {
        if (ChildCopyToMember(ref _outlinePen, value))
          EhSelfChanged(EventArgs.Empty);
      }
    }

    public override IHitTestObject HitTest(HitTestPointData htd)
    {
      IHitTestObject result = base.HitTest(htd);
      if (result != null)
        result.DoubleClick = EhHitDoubleClick;
      return result;
    }

    public override IHitTestObject HitTest(HitTestRectangularData rect)
    {
      IHitTestObject result = base.HitTest(rect);
      if (result != null)
        result.DoubleClick = EhHitDoubleClick;
      return result;
    }

    private static bool EhHitDoubleClick(IHitTestObject o)
    {
      object hitted = o.HittedObject;
      Current.Gui.ShowDialog(ref hitted, "Shape properties", true);
      ((OpenPathShapeBase)hitted).EhSelfChanged(EventArgs.Empty);
      return true;
    }

    #region IRoutedPropertyReceiver Members

    public IEnumerable<(string PropertyName, object PropertyValue, Action<object> PropertySetter)> GetRoutedProperties(string propertyName)
    {
      switch (propertyName)
      {
        case "StrokeWidth":
          if (null != _linePen)
            yield return (propertyName, _linePen.Width, (w) => _linePen.Width = (double)w);

          if (null != _outlinePen)
            yield return (propertyName, _outlinePen.Width, (w) => _outlinePen.Width = (double)w);
          break;
      }

      yield break;
    }

    #endregion IRoutedPropertyReceiver Members
  } //  End Class
} // end Namespace
