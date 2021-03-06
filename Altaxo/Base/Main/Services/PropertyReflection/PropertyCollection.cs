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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Altaxo.Main.Services.PropertyReflection
{
  /// <summary>
  ///
  /// </summary>
  /// <remarks>
  /// <para>This class originated from the 'WPG Property Grid' project (<see href="http://wpg.codeplex.com"/>), licensed under Ms-PL.</para>
  /// </remarks>
  public class PropertyCollection : CompositeItem
  {
    #region Initialization

    public PropertyCollection()
    {
    }

    //public PropertyCollection(object instance)
    //    : this(instance, false)
    //{ }

    public PropertyCollection(object instance, bool noCategory, bool automaticlyExpandObjects, string filter)
    {
      var groups = new Dictionary<string, PropertyCategory>();

      bool useCustomTypeConverter = false;

      PropertyDescriptorCollection properties;
      if (instance != null)
      {
        TypeConverter tc = TypeDescriptor.GetConverter(instance);
        if (tc == null || !tc.GetPropertiesSupported())
        {
          if (instance is ICustomTypeDescriptor)
            properties = ((ICustomTypeDescriptor)instance).GetProperties();
          else
            properties = TypeDescriptor.GetProperties(instance.GetType());  //I changed here from instance to instance.GetType, so that only the Direct Properties are shown!
        }
        else
        {
          properties = tc.GetProperties(instance);
          useCustomTypeConverter = true;
        }
      }
      else
        properties = new PropertyDescriptorCollection(new PropertyDescriptor[] { });

      var propertyCollection = new List<Property>();

      foreach (PropertyDescriptor propertyDescriptor in properties)
      {
        if (useCustomTypeConverter)
        {
          var property = new Property(instance, propertyDescriptor);
          propertyCollection.Add(property);
        }
        else
        {
          CollectProperties(instance, propertyDescriptor, propertyCollection, automaticlyExpandObjects, filter);
          if (noCategory)
            propertyCollection.Sort(Property.CompareByName);
          else
            propertyCollection.Sort(Property.CompareByCategoryThenByName);
        }
      }

      if (noCategory)
      {
        foreach (Property property in propertyCollection)
        {
          if (filter == "" || property.Name.ToLower().Contains(filter))
            Items.Add(property);
        }
      }
      else
      {
        foreach (Property property in propertyCollection)
        {
          if (filter == "" || property.Name.ToLower().Contains(filter))
          {
            PropertyCategory propertyCategory;
            var category = property.Category ?? string.Empty; // null category handled here

            if (groups.ContainsKey(category))
            {
              propertyCategory = groups[category];
            }
            else
            {
              propertyCategory = new PropertyCategory(property.Category);
              groups[category] = propertyCategory;
              Items.Add(propertyCategory);
            }
            propertyCategory.Items.Add(property);
          }
        }
      }
    }

    private void CollectProperties(object instance, PropertyDescriptor descriptor, List<Property> propertyCollection, bool automaticlyExpandObjects, string filter)
    {
      if (descriptor.Attributes[typeof(FlatAttribute)] == null)
      {
        var property = new Property(instance, descriptor);
        if (descriptor.IsBrowsable)
        {
          //Add a property with Name: AutomaticlyExpandObjects
          Type propertyType = descriptor.PropertyType;
          if (automaticlyExpandObjects && propertyType.IsClass && !propertyType.IsArray && propertyType != typeof(string))
          {
            propertyCollection.Add(new ExpandableProperty(instance, descriptor, automaticlyExpandObjects, filter));
          }
          else if (descriptor.Converter.GetType() == typeof(ExpandableObjectConverter))
          {
            propertyCollection.Add(new ExpandableProperty(instance, descriptor, automaticlyExpandObjects, filter));
          }
          else
            propertyCollection.Add(property);
        }
      }
      else
      {
        instance = descriptor.GetValue(instance);
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(instance);
        foreach (PropertyDescriptor propertyDescriptor in properties)
        {
          CollectProperties(instance, propertyDescriptor, propertyCollection, automaticlyExpandObjects, filter);
        }
      }
    }

    #endregion Initialization
  }
}
