using System;
using System.Collections.Generic;
using System.Text;
using Altaxo.Data;
namespace Altaxo.Graph
{
  /// <summary>
  /// This is a class used to identify axis line positions in 2D and 3D coordinate systems. 
  /// </summary>
  public sealed class CSLineID : ICloneable
  {
    /// <summary>
    /// Number of axis: 0==X-Axis, 1==Y-Axis
    /// </summary>
    int _parallelAxisNumber;

    /// <summary>
    /// The logical value of the isoline.
    /// </summary>
    double _logicalValueFirstOther;

    /// <summary>
    /// True when the isoline of this axis is determined by a physical value together with the corresponding axis scale
    /// </summary>
    bool _usePhysicalValueFirstOther;

    /// <summary>
    /// The physical value of this axis.
    /// </summary>
    AltaxoVariant _physicalValueFirstOther;


    /// <summary>
    /// The second logical value of the isoline. Only used in 3D mode.
    /// </summary>
    double _logicalValueSecondOther;

    /// <summary>
    /// True when the isoline of this axis is determined by the second physical value together with the corresponding axis scale
    /// </summary>
    bool _usePhysicalValueSecondOther;

    /// <summary>
    /// The second physical value of this axis.
    /// </summary>
    AltaxoVariant _physicalValueSecondOther;

   
    #region Serialization
    #region Version 0
    [Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(CSLineID), 0)]
    public class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
    {
      public virtual void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
      {
        CSLineID s = (CSLineID)obj;


        info.AddValue("Axis", s._parallelAxisNumber);
        
        info.AddValue("Logical1", s._logicalValueFirstOther);
        info.AddValue("UsePhysical1", s._usePhysicalValueFirstOther);
        if (s._usePhysicalValueFirstOther)
          info.AddValue("Physical1", (object)(s._physicalValueFirstOther));

        bool is3D = s.Is3DIdentifier;
        info.AddValue("Is3DIdentifier", is3D);

        if (is3D)
        {
          info.AddValue("Logical2", s._logicalValueSecondOther);
          info.AddValue("UsePhysical2", s._usePhysicalValueSecondOther);
          if (s._usePhysicalValueSecondOther)
            info.AddValue("Physical2", (object)(s._physicalValueSecondOther));
        }
      }
      protected virtual CSLineID SDeserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {
        CSLineID s = (o == null ? new CSLineID() : (CSLineID)o);

        s._parallelAxisNumber = info.GetInt32("Axis");
        
        s._logicalValueFirstOther = info.GetDouble("Logical1");
        s._usePhysicalValueFirstOther = info.GetBoolean("UsePhysical1");
        if (s._usePhysicalValueFirstOther)
          s._physicalValueFirstOther = (AltaxoVariant)info.GetValue("Physical1", s);

        bool is3D = info.GetBoolean("Is3D");
        if (is3D)
        {
          s._logicalValueSecondOther = info.GetDouble("Logical1");
          s._usePhysicalValueSecondOther = info.GetBoolean("UsePhysical2");
          if (s._usePhysicalValueSecondOther)
            s._physicalValueSecondOther = (AltaxoVariant)info.GetValue("Physical2", s);
        }

        return s;
      }

      public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {

        CSLineID s = SDeserialize(o, info, parent);
        return s;
      }
    }
    #endregion
    #endregion

    public CSLineID(CSLineID from)
    {
      this._parallelAxisNumber = from._parallelAxisNumber;
      this._logicalValueFirstOther = from._logicalValueFirstOther;
      this._usePhysicalValueFirstOther = from._usePhysicalValueFirstOther;
      this._physicalValueFirstOther = from._physicalValueFirstOther;

      this._logicalValueSecondOther = from._logicalValueSecondOther;
      this._usePhysicalValueSecondOther = from._usePhysicalValueSecondOther;
      this._physicalValueSecondOther = from._physicalValueSecondOther;
    }

    object ICloneable.Clone()
    {
      return new CSLineID(this);
    }
    public CSLineID Clone()
    {
      return new CSLineID(this);
    }


    /// <summary>
    /// Only for deserialization purposes.
    /// </summary>
    private CSLineID()
    {
      _logicalValueSecondOther = double.NaN; 
    }

    /// <summary>
    /// Initialized a 2D identifier from the parallel axis and the physical value of the perpendicular axis.
    /// </summary>
    /// <param name="parallelAxisNumber">Number of parallel axis (0->X, 1->Y, 2->Z).</param>
    /// <param name="logicalValueOther">The logical value of the axis perpendicular to the parallel axis.</param>
    public CSLineID(int parallelAxisNumber, double logicalValueOther)
    {
      // test arguments
      if (parallelAxisNumber < 0 || parallelAxisNumber>1)
        throw new ArgumentOutOfRangeException("AxisNumber must be either 0 or 1, but you provide: " + parallelAxisNumber.ToString());
      if (double.IsNaN(logicalValueOther))
        throw new ArgumentOutOfRangeException("LogicalValue is NaN, but it must be a valid number.");

      _parallelAxisNumber = parallelAxisNumber;
      _logicalValueFirstOther = logicalValueOther;
      _logicalValueSecondOther = double.NaN;      
    }

    public CSLineID(int parallelAxisNumber, double logicalValueOtherFirst, double logicalValueOtherSecond)
    {
      // test arguments
      if (parallelAxisNumber < 0 || parallelAxisNumber > 2)
        throw new ArgumentOutOfRangeException("AxisNumber must be either 0,1, or 2, but you provide: " + parallelAxisNumber.ToString());
      if (double.IsNaN(logicalValueOtherFirst))
        throw new ArgumentOutOfRangeException("LogicalValueFirst is NaN, but it must be a valid number.");
      if (double.IsNaN(logicalValueOtherSecond))
        throw new ArgumentOutOfRangeException("LogicalValueSecond is NaN, but it must be a valid number.");

      _parallelAxisNumber = parallelAxisNumber;
      _logicalValueFirstOther = logicalValueOtherFirst;
      _logicalValueSecondOther = logicalValueOtherSecond;
    }

  

    /// <summary>
    /// Initialized a 2D identifier from the parallel axis and the physical value of the perpendicular axis.
    /// </summary>
    /// <param name="parallelAxisNumber">Number of parallel axis (0->X, 1->Y, 2->Z).</param>
    /// <param name="physicalValueOther">Physical value of the axis perendicular to the parallel axis.</param>
    /// <returns>A freshly created 2D line identifier.</returns>
    public static CSLineID FromPhysicalValue(int parallelAxisNumber, double physicalValueOther)
    {
      if (parallelAxisNumber < 0 || parallelAxisNumber > 1)
        throw new ArgumentOutOfRangeException("AxisNumber must be either 0 or 1, but you provide: " + parallelAxisNumber.ToString());

      if (double.IsNaN(physicalValueOther))
        throw new ArgumentException("Physical value is NaN, but it must be a valid number.");

      CSLineID id = new CSLineID();
      id._parallelAxisNumber = parallelAxisNumber;
      id._physicalValueFirstOther = physicalValueOther;
      id._logicalValueFirstOther = double.NaN;
      id._usePhysicalValueFirstOther = true;
      
      id._logicalValueSecondOther = double.NaN;
      return id;
    }

    /// <summary>
    /// Initialized a 2D identifier from the parallel axis and the physical value of the perpendicular axis.
    /// </summary>
    /// <param name="parallelAxisNumber">Number of parallel axis (0->X, 1->Y, 2->Z).</param>
    /// <param name="physicalValueOther">Physical value of the axis perendicular to the parallel axis.</param>
    /// <returns>A freshly created 2D line identifier.</returns>
    public static CSLineID FromPhysicalVariant(int parallelAxisNumber, AltaxoVariant physicalValueOther)
    {
      if (parallelAxisNumber < 0 || parallelAxisNumber > 1)
        throw new ArgumentOutOfRangeException("AxisNumber must be either 0 or 1, but you provide: " + parallelAxisNumber.ToString());

      if (!physicalValueOther.Equals(physicalValueOther))
        throw new ArgumentException("You can not set physical values that return false when compared to itself, value is: " + physicalValueOther.ToString());

      
      CSLineID id = new CSLineID();
      id._parallelAxisNumber = parallelAxisNumber;
      id._physicalValueFirstOther = physicalValueOther;
      id._logicalValueFirstOther = double.NaN;
      id._usePhysicalValueFirstOther = true;

      id._logicalValueSecondOther = double.NaN;
      return id;
    }

    /// <summary>
    /// Returns true when this is an identifier for 3D coordinate sytems.
    /// </summary>
    public bool Is3DIdentifier
    {
      get
      {
        return _usePhysicalValueSecondOther || !double.IsNaN(_logicalValueSecondOther);
      }
    }

    /// <summary>
    /// Returns true when this is an identifier for 2D coordinate systems, i.e. when the 3rd dimension is not initialized.
    /// </summary>
    public bool Is2DIdentifier
    {
      get
      {
        return !Is3DIdentifier;
      }
    }


    /// <summary>
    /// Number of axis: 0==X-Axis, 1==Y-Axis, 2=Z-Axis of the coordinate system.
    /// </summary>
    public int ParallelAxisNumber { get { return _parallelAxisNumber; } }

    /// <summary>
    /// Number of axis: 0==X-Axis, 1==Y-Axis, 2==Z-Axis
    /// </summary>
    public int AxisNumberOther 
    {
      get 
      {
        if (Is3DIdentifier)
          throw new NotSupportedException("This function is only supported for 2D mode.");

        return 0==_parallelAxisNumber ? 1 : 0; 
      } 
    }

    /// <summary>
    /// The logical value of the isoline. It can be set only in the constructor, or if the UsePhysicalValue property is true.
    /// </summary>
    public double LogicalValueOtherFirst
    { 
      get 
      { 
        return _logicalValueFirstOther;
      }
      set
      {
        if (_usePhysicalValueFirstOther)
          _logicalValueFirstOther = value;
        else
          throw new NotSupportedException("You must not set the logical value of this identifier unless the property UsePhysicalValue is true");
      }
    }

    /// <summary>
    /// True when the isoline of this axis is determined by a physical value together with the corresponding axis scale
    /// </summary>
    public bool UsePhysicalValueOtherFirst
    { 
      get
      {
        return _usePhysicalValueFirstOther;
      } 
    }

    /// <summary>
    /// The physical value of this axis.
    /// </summary>
    public AltaxoVariant PhysicalValueOtherFirst { get { return _physicalValueFirstOther; } }


    public override bool Equals(object obj)
    {
      if (!(obj is CSLineID))
        return false;
      CSLineID from = (CSLineID)obj;

      if (this.Is3DIdentifier != from.Is3DIdentifier)
        return false;

      bool result = true;
      result &= this._parallelAxisNumber == from._parallelAxisNumber;
      result &= this._usePhysicalValueFirstOther == from._usePhysicalValueFirstOther;
      if (result == false)
        return false;

      if (_usePhysicalValueFirstOther)
        result &= (this._physicalValueFirstOther == from._physicalValueFirstOther);
      else
        result &= (this._logicalValueFirstOther == from._logicalValueFirstOther);
      if (result == false)
        return false;

      if (this.Is3DIdentifier)
      {
        if (this._usePhysicalValueSecondOther != from._usePhysicalValueSecondOther)
          return false;
        if (_usePhysicalValueSecondOther)
          result &= (this._physicalValueSecondOther == from._physicalValueSecondOther);
        else
          result &= (this._logicalValueSecondOther == from._logicalValueSecondOther);
      }

      return result;
    }

    public override int GetHashCode()
    {
      int result = _parallelAxisNumber.GetHashCode();
      result += _usePhysicalValueFirstOther.GetHashCode();
      if (_usePhysicalValueFirstOther)
        result += _physicalValueFirstOther.GetHashCode();
      else
        result += _logicalValueFirstOther.GetHashCode();

      if (Is3DIdentifier)
      {
        result += _usePhysicalValueSecondOther.GetHashCode();
        if (_usePhysicalValueSecondOther)
          result += _physicalValueSecondOther.GetHashCode();
        else
          result += _logicalValueSecondOther.GetHashCode();
      }

      return result;
    }

    public static bool operator ==(CSLineID a, CSLineID b)
    {
      // If both are null, or both are same instance, return true.
      if (System.Object.ReferenceEquals(a, b))
      {
        return true;
      }

      // If one is null, but not both, return false.
      if (((object)a == null) || ((object)b == null))
      {
        return false;
      }

      // Return true if the fields match:
      return a.Equals(b);
    }
     
    public static bool operator !=(CSLineID x, CSLineID y)
    {
        return !(x==y);
    }

    public static CSLineID X0
    {
      get { return new CSLineID(0, 0); }
    }
    public static CSLineID X1
    {
      get { return new CSLineID(0, 1); }
    }
    public static CSLineID Y0
    {
      get { return new CSLineID(1, 0); }
    }
    public static CSLineID Y1
    {
      get { return new CSLineID(1, 1); }
    }
   
  }

}