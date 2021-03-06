﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2018 Dr. Dirk Lellinger
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Altaxo.Gui.Behaviors
{
  public class Event1TriggersCommand
  {
    #region IsHandled property

    public static readonly DependencyProperty IsHandledProperty = DependencyProperty.RegisterAttached(
        "IsHandled",
        typeof(bool),
        typeof(Event1TriggersCommand),
        new FrameworkPropertyMetadata(true));

    public static bool GetIsHandled(FrameworkElement frameworkElement)
    {
      return (bool)frameworkElement.GetValue(IsHandledProperty);
    }

    public static void SetIsHandled(FrameworkElement frameworkElement, bool observe)
    {
      frameworkElement.SetValue(IsHandledProperty, observe);
    }

    #endregion IsHandled property

    #region RoutedEvent property (used to attach behaviour)

    public static readonly DependencyProperty RoutedEventProperty = DependencyProperty.RegisterAttached(
        "RoutedEvent",
        typeof(RoutedEvent),
        typeof(Event1TriggersCommand),
        new FrameworkPropertyMetadata(OnRoutedEventChanged));

    private static void OnRoutedEventChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      var oldEvent = e.OldValue as RoutedEvent;
      var newEvent = e.NewValue as RoutedEvent;
      if (d is FrameworkElement fe)
      {
        if (null != oldEvent)
          fe.RemoveHandler(oldEvent, new RoutedEventHandler(EhEventHandler));

        if (null != newEvent)
          fe.AddHandler(newEvent, new RoutedEventHandler(EhEventHandler));
      }
    }

    public static RoutedEvent GetRoutedEvent(FrameworkElement frameworkElement)
    {
      return (RoutedEvent)frameworkElement.GetValue(RoutedEventProperty);
    }

    public static void SetRoutedEvent(FrameworkElement frameworkElement, RoutedEvent value)
    {
      frameworkElement.SetValue(RoutedEventProperty, value);
    }

    #endregion RoutedEvent property (used to attach behaviour)

    #region Command

    public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
    "Command",
    typeof(ICommand),
    typeof(Event1TriggersCommand)
    );

    public static ICommand GetCommand(FrameworkElement frameworkElement)
    {
      return (ICommand)frameworkElement.GetValue(CommandProperty);
    }

    public static void SetCommand(FrameworkElement frameworkElement, ICommand value)
    {
      frameworkElement.SetValue(CommandProperty, value);
    }

    #endregion Command

    #region Command parameter

    public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached(
    "CommandParameter",
    typeof(object),
    typeof(Event1TriggersCommand)
    );

    public static object GetCommandParameter(FrameworkElement frameworkElement)
    {
      return frameworkElement.GetValue(CommandParameterProperty);
    }

    public static void SetCommandParameter(FrameworkElement frameworkElement, object value)
    {
      frameworkElement.SetValue(CommandParameterProperty, value);
    }

    #endregion Command parameter

    #region Event handlers

    private static void EhEventHandler(object sender, RoutedEventArgs e)
    {
      var command = GetCommand((FrameworkElement)sender);
      var commandParameter = GetCommandParameter((FrameworkElement)sender);

      if (null != command)
      {
        if (command.CanExecute(commandParameter))
          command.Execute(commandParameter);

        e.Handled = true;
      }
    }

    #endregion Event handlers
  }
}
