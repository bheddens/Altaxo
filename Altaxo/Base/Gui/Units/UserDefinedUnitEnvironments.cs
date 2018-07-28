﻿using Altaxo.Main.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altaxo.Gui.Units
{
  /// <summary>
  /// Collection of unit environments defined by the user.
  /// Key is a quantity that is not neccessarily a unit quantity (for instance: unit quanity is 'Length' but quantities can be 'CapSize', 'LineThickness' etc).
  /// Value is the user defined unit environment for that quantity.
  /// </summary>
  public class UserDefinedUnitEnvironments : IDictionary<string, UserDefinedUnitEnvironment>
  {
    private IDictionary<string, UserDefinedUnitEnvironment> _dictionary;

    /// <summary>
    /// The property key used to store the default instance of this class in the property service.
    /// </summary>
    public static readonly PropertyKey<UserDefinedUnitEnvironments> PropertyKeyDefaultInstance =
     new PropertyKey<UserDefinedUnitEnvironments>(
     "DC4BAAC5-440E-46CA-9A63-1747FAFFB32C",
     "Units\\UserDefinedUnitEnvironments",
     PropertyLevel.Application,
     () => new UserDefinedUnitEnvironments());

    #region Serialization

    /// <summary>
    /// 2017-09-26 Initial version
    /// </summary>
    [Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(UserDefinedUnitEnvironments), 0)]
    private class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
    {
      public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
      {
        var s = (UserDefinedUnitEnvironments)obj;

        info.CreateArray("Environments", s.Count);
        foreach (var env in s.Values)
          info.AddValue("e", env);
        info.CommitArray();
      }

      public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {
        var s = (UserDefinedUnitEnvironments)o ?? new UserDefinedUnitEnvironments(info);

        var count = info.OpenArray("Environments");
        for (int i = 0; i < count; ++i)
        {
          var env = (UserDefinedUnitEnvironment)info.GetValue("e", null);
          s.Add(env.Name, env);
        }
        info.CloseArray(count);

        return s;
      }
    }

    #endregion Serialization

    protected UserDefinedUnitEnvironments(Altaxo.Serialization.Xml.IXmlDeserializationInfo info)
    {
      _dictionary = new Dictionary<string, UserDefinedUnitEnvironment>();
    }

    public UserDefinedUnitEnvironments()
    {
      _dictionary = new Dictionary<string, UserDefinedUnitEnvironment>();
    }

    private void OnContentsChanged()
    {
    }

    public UserDefinedUnitEnvironment this[string key] { get => _dictionary[key]; set => _dictionary[key] = value; }

    public ICollection<string> Keys => _dictionary.Keys;

    public ICollection<UserDefinedUnitEnvironment> Values => _dictionary.Values;

    public int Count => _dictionary.Count;

    public bool IsReadOnly => _dictionary.IsReadOnly;

    public void Add(string key, UserDefinedUnitEnvironment value)
    {
      _dictionary.Add(key, value);
      OnContentsChanged();
    }

    public void Add(KeyValuePair<string, UserDefinedUnitEnvironment> item)
    {
      _dictionary.Add(item);
      OnContentsChanged();
    }

    public void Clear()
    {
      _dictionary.Clear();
      OnContentsChanged();
    }

    public bool Contains(KeyValuePair<string, UserDefinedUnitEnvironment> item)
    {
      return _dictionary.Contains(item);
    }

    public bool ContainsKey(string key)
    {
      return _dictionary.ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<string, UserDefinedUnitEnvironment>[] array, int arrayIndex)
    {
      _dictionary.CopyTo(array, arrayIndex);
    }

    public IEnumerator<KeyValuePair<string, UserDefinedUnitEnvironment>> GetEnumerator()
    {
      return _dictionary.GetEnumerator();
    }

    public bool Remove(string key)
    {
      var success = _dictionary.Remove(key);
      if (success)
        OnContentsChanged();
      return success;
    }

    public bool Remove(KeyValuePair<string, UserDefinedUnitEnvironment> item)
    {
      var success = _dictionary.Remove(item);
      if (success)
        OnContentsChanged();
      return success;
    }

    public bool TryGetValue(string key, out UserDefinedUnitEnvironment value)
    {
      return _dictionary.TryGetValue(key, out value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return _dictionary.GetEnumerator();
    }
  }
}
