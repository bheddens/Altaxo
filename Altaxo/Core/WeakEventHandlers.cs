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
using System.Linq;
using System.Reflection;
using System.Text;

namespace Altaxo
{
  #region WeakEventHandler (for an EventHandler with no specialized EventArgs)

  /// <summary>
  /// Mediates an <see cref="EventHandler"/> event, holding only a weak reference to the event sink.
  /// Thus there is no reference created from the event source to the event sink, and the event sink can be garbage collected.
  /// </summary>
  /// <remarks>
  /// Typical use:  (Attention: source has to be a local variable, <b>not</b> a member variable!)
  /// <code>
  /// source.Changed += new WeakEventHandler(this.EhHandleChange, x =&gt; source.Changed -= x);
  /// </code>
  /// Sometimes it might be neccessary to use explicitly the event handler method of this instance:
  /// <code>
  /// source.Changed += new WeakEventHandler(this.EhHandleChange, x=&gt; source.Changed -= x.EventSink).EventSink;
  /// </code>
  /// You can even maintain a reference to the WeakActionHandler instance in your event sink instance, in case you have to remove the event handling programmatically:
  /// <code>
  /// _weakEventHandler = new WeakEventHandler(this.EhHandleChange, x =&gt; source.Changed -= x); // weakEventHandler is an instance variable of this class
  /// source.Changed += _weakEventHandler;
  /// .
  /// .
  /// .
  /// source.Changed -= _weakEventHandler;
  /// </code>
  /// </remarks>
  public class WeakEventHandler
  {
    private static WeakReference _weakNullReference = new WeakReference(null);
    private WeakReference _handlerObjectWeakRef;
    private MethodInfo _handlerMethodInfo;
    private Action<WeakEventHandler> _removeAction;

    /// <summary>
    /// Constructs the WeakEventHandler. Attention! Make sure that you don't use member variables in <paramref name="removeHandlerAction"/>! Instead, make a copy to a local variable before and use this variable.
    /// </summary>
    /// <param name="handler">Event handler for the event to wrap (event sink).</param>
    /// <param name="removeHandlerAction">Action that removes the event handling by this instance from the source.</param>
    /// <remarks>
    /// Typcical usage: <code>source.Changed += new WeakEventHandler(this.EhHandleChange, x =&gt; source.Changed -= x);</code>
    /// </remarks>
    public WeakEventHandler(EventHandler handler, Action<WeakEventHandler> removeHandlerAction)
    {
      if (handler.Target == null)
        throw new ArgumentException("Can not set weak events to a static handler method. Please use normal event handling to bind to a static method");

      _handlerObjectWeakRef = new WeakReference(handler.Target);
      _handlerMethodInfo = handler.Method;
      _removeAction = removeHandlerAction;
    }

    /// <summary>
    /// Handles the event from the original source. You must not call this method directly. However, it can be neccessary to use the method reference if the implicit casting fails. See remarks in the description of this class.
    /// </summary>
    /// <param name="sender">Sender of the event.</param>
    /// <param name="e">Event args.</param>
    public void EventSink(object sender, EventArgs e)
    {
      var handlerObj = _handlerObjectWeakRef.Target;
      if (null != handlerObj)
      {
        _handlerMethodInfo.Invoke(handlerObj, new object[] { sender, e });
      }
      else
      {
        Remove();
      }
    }

    /// <summary>Removes the event handler from the event source, using the stored remove action..</summary>
    public void Remove()
    {
      _handlerObjectWeakRef = _weakNullReference;
      var removeAction = System.Threading.Interlocked.Exchange(ref _removeAction, null);
      if (null != removeAction)
      {
        removeAction(this);
      }
    }

    /// <summary>
    /// Converts this instance to an <see cref="EventHandler"/> that can be used to add or remove it from/to an event.
    /// </summary>
    /// <param name="weakHandler">A instance if this class.</param>
    /// <returns>A reference to the event handler routine inside the instance.</returns>
    public static implicit operator EventHandler(WeakEventHandler weakHandler)
    {
      return weakHandler.EventSink;
    }
  }

  #endregion WeakEventHandler (for an EventHandler with no specialized EventArgs)

  #region WeakEventHandler<TEventArgs> (for an EventHandler with a generic EventArgs argument)

  /// <summary>
  /// Mediates an <see cref="EventHandler"/> event, holding only a weak reference to the event sink.
  /// Thus there is no reference created from the event source to the event sink, and the event sink can be garbage collected.
  /// </summary>
  /// <typeparam name="TEventArgs">The specialized type of <see cref="EventArgs"/>.</typeparam>
  /// <remarks>
  /// Typical use:  (Attention: source has to be a local variable, <b>not</b> a member variable!)
  /// <code>
  /// source.Changed += new WeakEventHandler&lt;MyEventArgs&gt;(this.EhHandleChange, x =&gt; source.Changed -= x);
  /// </code>
  /// Sometimes it might be neccessary to use explicitly the event handler method of this instance:
  /// <code>
  /// source.Changed += new WeakEventHandler&lt;MyEventArgs&gt;(this.EhHandleChange, x=&gt; source.Changed -= x.EventSink).EventSink;
  /// </code>
  /// You can even maintain a reference to the WeakActionHandler instance in your event sink instance, in case you have to remove the event handling programmatically:
  /// <code>
  /// _weakEventHandler = new WeakEventHandler&lt;MyEventArgs&gt;(this.EhHandleChange, x =&gt; source.Changed -= x); // weakEventHandler is an instance variable of this class
  /// source.Changed += _weakEventHandler;
  /// .
  /// .
  /// .
  /// source.Changed -= _weakEventHandler;
  /// </code>
  /// </remarks>
  public class WeakEventHandler<TEventArgs> where TEventArgs : EventArgs
  {
    private static WeakReference _weakNullReference = new WeakReference(null);
    private WeakReference _handlerObjectWeakRef;
    private MethodInfo _handlerMethodInfo;
    private Action<WeakEventHandler<TEventArgs>> _removeAction;

    /// <summary>
    /// Constructs the WeakEventHandler.  Attention! Make sure that you don't use member variables in <paramref name="removeHandlerAction"/>! Instead, make a copy to a local variable before and use this variable.
    /// </summary>
    /// <param name="handler">Event handler for the event to wrap (event sink).</param>
    /// <param name="removeHandlerAction">Action that removes the event handling by this instance from the source.</param>
    /// <remarks>
    /// Typcical usage: <code>source.Changed += new WeakEventHandler&lt;MyEventArgs&gt;(this.EhHandleChange, x =&gt; source.Changed -= x);</code>
    /// </remarks>
    public WeakEventHandler(EventHandler<TEventArgs> handler, Action<WeakEventHandler<TEventArgs>> removeHandlerAction)
    {
      if (handler.Target == null)
        throw new ArgumentException("Can not set weak events to a static handler method. Please use normal event handling to bind to a static method");

      _handlerObjectWeakRef = new WeakReference(handler.Target);
      _handlerMethodInfo = handler.Method;
      _removeAction = removeHandlerAction;
    }

    /// <summary>
    /// Handles the event from the original source. You must not call this method directly. However, it can be neccessary to use the method reference if the implicit casting failes. See remarks in the description of this class.
    /// </summary>
    /// <param name="sender">Sender of the event.</param>
    /// <param name="e">Event args.</param>
    public void EventSink(object sender, TEventArgs e)
    {
      var handlerObj = _handlerObjectWeakRef.Target;
      if (null != handlerObj)
      {
        _handlerMethodInfo.Invoke(handlerObj, new object[] { sender, e });
      }
      else
      {
        Remove();
      }
    }

    /// <summary>Removes the event handler from the event source, using the stored remove action..</summary>
    public void Remove()
    {
      _handlerObjectWeakRef = _weakNullReference;
      var removeAction = System.Threading.Interlocked.Exchange(ref _removeAction, null);
      if (null != removeAction)
      {
        removeAction(this);
      }
    }

    /// <summary>
    /// Converts this instance to an <see cref="EventHandler&lt;TEventArgs&gt;"/> that can be used to add or remove it from/to an event.
    /// </summary>
    /// <param name="weakHandler">A instance if this class.</param>
    /// <returns>A reference to the event handler routine inside the instance.</returns>
    public static implicit operator EventHandler<TEventArgs>(WeakEventHandler<TEventArgs> weakHandler)
    {
      return weakHandler.EventSink;
    }
  }

  #endregion WeakEventHandler<TEventArgs> (for an EventHandler with a generic EventArgs argument)

  #region WeakPropertyChangedEventHandler

  /// <summary>
  /// Mediates an <see cref="EventHandler"/> event, holding only a weak reference to the event sink.
  /// Thus there is no reference created from the event source to the event sink, and the event sink can be garbage collected.
  /// </summary>
  /// <remarks>
  /// Typical use:  (Attention: source has to be a local variable, <b>not</b> a member variable!)
  /// <code>
  /// source.Changed += new WeakEventHandler(this.EhHandleChange, x =&gt; source.Changed -= x);
  /// </code>
  /// Sometimes it might be neccessary to use explicitly the event handler method of this instance:
  /// <code>
  /// source.Changed += new WeakEventHandler(this.EhHandleChange, x=&gt; source.Changed -= x.EventSink).EventSink;
  /// </code>
  /// You can even maintain a reference to the WeakActionHandler instance in your event sink instance, in case you have to remove the event handling programmatically:
  /// <code>
  /// _weakEventHandler = new WeakEventHandler(this.EhHandleChange, x =&gt; source.Changed -= x); // weakEventHandler is an instance variable of this class
  /// source.Changed += _weakEventHandler;
  /// .
  /// .
  /// .
  /// source.Changed -= _weakEventHandler;
  /// </code>
  /// </remarks>
  public class WeakPropertyChangedEventHandler
  {
    private static WeakReference _weakNullReference = new WeakReference(null);
    private WeakReference _handlerObjectWeakRef;
    private MethodInfo _handlerMethodInfo;
    private Action<WeakPropertyChangedEventHandler> _removeAction;

    /// <summary>
    /// Constructs the WeakEventHandler.  Attention! Make sure that you don't use member variables in <paramref name="removeHandlerAction"/>! Instead, make a copy to a local variable before and use this variable.
    /// </summary>
    /// <param name="handler">Event handler for the event to wrap (event sink).</param>
    /// <param name="removeHandlerAction">Action that removes the event handling by this instance from the source.</param>
    /// <remarks>
    /// Typcical usage: <code>source.Changed += new WeakEventHandler(this.EhHandleChange, x =&gt; source.Changed -= x);</code>
    /// </remarks>
    public WeakPropertyChangedEventHandler(System.ComponentModel.PropertyChangedEventHandler handler, Action<WeakPropertyChangedEventHandler> removeHandlerAction)
    {
      if (handler.Target == null)
        throw new ArgumentException("Can not set weak events to a static handler method. Please use normal event handling to bind to a static method");

      _handlerObjectWeakRef = new WeakReference(handler.Target);
      _handlerMethodInfo = handler.Method;
      _removeAction = removeHandlerAction;
    }

    /// <summary>
    /// Handles the event from the original source. You must not call this method directly. However, it can be neccessary to use the method reference if the implicit casting fails. See remarks in the description of this class.
    /// </summary>
    /// <param name="sender">Sender of the event.</param>
    /// <param name="e">Event args.</param>
    public void EventSink(object sender, EventArgs e)
    {
      var handlerObj = _handlerObjectWeakRef.Target;
      if (null != handlerObj)
      {
        _handlerMethodInfo.Invoke(handlerObj, new object[] { sender, e });
      }
      else
      {
        Remove();
      }
    }

    /// <summary>Removes the event handler from the event source, using the stored remove action..</summary>
    public void Remove()
    {
      _handlerObjectWeakRef = _weakNullReference;
      var removeAction = System.Threading.Interlocked.Exchange(ref _removeAction, null);
      if (null != removeAction)
      {
        removeAction(this);
      }
    }

    /// <summary>
    /// Converts this instance to an <see cref="EventHandler"/> that can be used to add or remove it from/to an event.
    /// </summary>
    /// <param name="weakHandler">A instance if this class.</param>
    /// <returns>A reference to the event handler routine inside the instance.</returns>
    public static implicit operator System.ComponentModel.PropertyChangedEventHandler(WeakPropertyChangedEventHandler weakHandler)
    {
      return weakHandler.EventSink;
    }
  }

  #endregion WeakPropertyChangedEventHandler

  #region WeakActionHandler (for an Action with no arguments)

  /// <summary>
  /// Mediates an action event with no argument, holding only a weak reference to the event sink.
  /// Thus there is no reference created from the event source to the event sink, and the event sink can be garbage collected.
  /// </summary>
  /// <remarks>
  /// Typical use:  (Attention: source has to be a local variable, <b>not</b> a member variable!)
  /// <code>
  /// source.ActionEvent += new WeakActionHandler(this.EhActionHandling, x =&gt; source.ActionEvent -= x);
  /// </code>
  /// Sometimes it might be neccessary to use explicitly the event handler method of this instance:
  /// <code>
  /// source.ActionEvent += new WeakActionHandler(this.EhActionHandling, x=&gt; source.ActionEvent -= x.EventSink).EventSink;
  /// </code>
  /// You can even maintain a reference to the WeakActionHandler instance in your event sink instance, in case you have to remove the event handling programmatically:
  /// <code>
  /// _weakActionHandler = new WeakActionHandler(this.EhActionHandling, x =&gt; source.ActionEvent -= x); // _weakActionHandler is an instance variable of this class
  /// source.ActionEvent += _weakActionHandler;
  /// .
  /// .
  /// .
  /// source.ActionEvent -= _weakActionHandler;
  /// </code>
  /// </remarks>
  public class WeakActionHandler
  {
    private static WeakReference _weakNullReference = new WeakReference(null);
    private WeakReference _handlerObjectWeakRef;
    private MethodInfo _handlerMethodInfo;
    private Action<WeakActionHandler> _removeAction;

    /// <summary>
    /// Constructs the WeakActionHandler.  Attention! Make sure that you don't use member variables in <paramref name="removeHandlerAction"/>! Instead, make a copy to a local variable before and use this variable.
    /// </summary>
    /// <param name="handler">Event handler for the action event (event sink).</param>
    /// <param name="removeHandlerAction">Action that should remove the event handling by this instance.</param>
    /// 	/// <remarks>
    /// Typical usage: <code>source.ActionEvent += new WeakActionHandler(this.EhActionHandling, x =&gt; source.ActionEvent -= x);</code>
    /// </remarks>
    public WeakActionHandler(Action handler, Action<WeakActionHandler> removeHandlerAction)
    {
      if (handler.Target == null)
        throw new ArgumentException("Can not set weak events to a static handler method. Please use normal event handling to bind to a static method");

      _handlerObjectWeakRef = new WeakReference(handler.Target);
      _handlerMethodInfo = handler.Method;
      _removeAction = removeHandlerAction;
    }

    /// <summary>
    /// Handles the event from the original source. You must not call this method directly. However, it can be neccessary to use the method reference if the implicit casting fails. See remarks in the description of this class.
    /// </summary>
    public void EventSink()
    {
      var handlerObj = _handlerObjectWeakRef.Target;
      if (null != handlerObj)
      {
        _handlerMethodInfo.Invoke(handlerObj, null);
      }
      else
      {
        Remove();
      }
    }

    /// <summary>Removes the event handler from the event source, using the stored remove action..</summary>
    public void Remove()
    {
      _handlerObjectWeakRef = _weakNullReference;
      var removeAction = System.Threading.Interlocked.Exchange(ref _removeAction, null);
      if (null != removeAction)
      {
        removeAction(this);
      }
    }

    /// <summary>
    /// Converts this instance to an action that can be used to add or remove it from/to an event.
    /// </summary>
    /// <param name="weakHandler">The WeakActionHandler instance.</param>
    /// <returns>A reference to the event handler routine inside the WeakActionHandler instance.</returns>
    public static implicit operator Action(WeakActionHandler weakHandler)
    {
      return weakHandler.EventSink;
    }
  }

  #endregion WeakActionHandler (for an Action with no arguments)

  #region WeakActionHandler<T1> (for an Action with one generic argument)

  /// <summary>
  /// Mediates an action event with one argument, holding only a weak reference to the event sink.
  /// Thus there is no reference created from the event source to the event sink, and the event sink can be garbage collected.
  /// </summary>
  /// <typeparam name="T1">Action parameter.</typeparam>
  /// <remarks>
  /// Typical use:  (Attention: source has to be a local variable, <b>not</b> a member variable!)
  /// <code>
  /// source.ActionEvent += new WeakActionHandler&lt;MyArg&gt;(this.EhActionHandling, x =&gt; source.ActionEvent -= x);
  /// </code>
  /// Sometimes it might be neccessary to use explicitly the event handler method of this instance:
  /// <code>
  /// source.ActionEvent += new WeakActionHandler&lt;MyArg&gt;(this.EhActionHandling, x=&gt; source.ActionEvent -= x.EventSink).EventSink;
  /// </code>
  /// You can even maintain a reference to the WeakActionHandler instance in your event sink instance, in case you have to remove the event handling programmatically:
  /// <code>
  /// _weakActionHandler = new WeakActionHandler&lt;MyArg&gt;(this.EhActionHandling, x =&gt; source.ActionEvent -= x); // weakActionHandler is an instance variable of this class
  /// source.ActionEvent += _weakActionHandler;
  /// .
  /// .
  /// .
  /// source.ActionEvent -= _weakActionHandler;
  /// </code>
  /// </remarks>
  public class WeakActionHandler<T1>
  {
    private static WeakReference _weakNullReference = new WeakReference(null);
    private WeakReference _handlerObjectWeakRef;
    private MethodInfo _handlerMethodInfo;
    private Action<WeakActionHandler<T1>> _removeAction;

    /// <summary>
    /// Constructs the WeakActionHandler.  Attention! Make sure that you don't use member variables in <paramref name="removeHandlerAction"/>! Instead, make a copy to a local variable before and use this variable.
    /// </summary>
    /// <param name="handler">Event handler for the action event (event sink).</param>
    /// <param name="removeHandlerAction">Action that should remove the event handling by this instance.</param>
    /// 	/// <remarks>
    /// Typcical usage: <code>source.ActionEvent += new WeakActionHandler&lt;int&gt;(this.EhActionHandling, x =&gt; source.ActionEvent -= x);</code>
    /// </remarks>
    public WeakActionHandler(Action<T1> handler, Action<WeakActionHandler<T1>> removeHandlerAction)
    {
      if (handler.Target == null)
        throw new ArgumentException("Can not set weak events to a static handler method. Please use normal event handling to bind to a static method");

      _handlerObjectWeakRef = new WeakReference(handler.Target);
      _handlerMethodInfo = handler.Method;
      _removeAction = removeHandlerAction;
    }

    /// <summary>
    /// Handles the event from the original source. You must not call this method directly. However, it can be neccessary to use the method reference if the implicit casting fails. See remarks in the description of this class.
    /// </summary>
    /// <param name="t1">First action argument.</param>
    public void EventSink(T1 t1)
    {
      var handlerObj = _handlerObjectWeakRef.Target;
      if (null != handlerObj)
      {
        _handlerMethodInfo.Invoke(handlerObj, new object[] { t1 });
      }
      else
      {
        Remove();
      }
    }

    /// <summary>Removes the event handler from the event source, using the stored remove action..</summary>
    public void Remove()
    {
      _handlerObjectWeakRef = _weakNullReference;
      var removeAction = System.Threading.Interlocked.Exchange(ref _removeAction, null);
      if (null != removeAction)
      {
        removeAction(this);
      }
    }

    /// <summary>
    /// Converts this instance to an action that can be used to add or remove it from/to an event.
    /// </summary>
    /// <param name="weakHandler">The WeakActionHandler instance.</param>
    /// <returns>A reference to the event handler routine inside the WeakActionHandler instance.</returns>
    public static implicit operator Action<T1>(WeakActionHandler<T1> weakHandler)
    {
      return weakHandler.EventSink;
    }
  }

  #endregion WeakActionHandler<T1> (for an Action with one generic argument)

  #region WeakActionHandler<T1,T2> (for an Action with two generic arguments)

  /// <summary>
  /// Mediates an action event with two arguments, holding only a weak reference to the event sink.
  /// Thus there is no reference created from the event source to the event sink, and the event sink can be garbage collected.
  /// </summary>
  /// <typeparam name="T1">First action parameter.</typeparam>
  /// <typeparam name="T2">Second action parameter.</typeparam>
  /// <remarks>
  /// Typical use:  (Attention: source has to be a local variable, <b>not</b> a member variable!)
  /// <code>
  /// source.ActionEvent += new WeakActionHandler&lt;MyArg1,MyArg2&gt;(this.EhActionHandling, x =&gt; source.ActionEvent -= x);
  /// </code>
  /// Sometimes it might be neccessary to use explicitly the event handler method of this instance:
  /// <code>
  /// source.ActionEvent += new WeakActionHandler&lt;MyArg1,MyArg2&gt;(this.EhActionHandling, x=&gt; source.ActionEvent -= x.EventSink).EventSink;
  /// </code>
  /// You can even maintain a reference to the WeakActionHandler instance in your event sink instance, in case you have to remove the event handling programmatically:
  /// <code>
  /// _weakActionHandler = new WeakActionHandler&lt;MyArg1,MyArg2&gt;(this.EhActionHandling, x =&gt; source.ActionEvent -= x); // _weakActionHandler is an instance variable of this class
  /// source.ActionEvent += _weakActionHandler;
  /// .
  /// .
  /// .
  /// source.ActionEvent -= _weakActionHandler;
  /// </code>
  /// </remarks>
  public class WeakActionHandler<T1, T2>
  {
    private static WeakReference _weakNullReference = new WeakReference(null);
    private WeakReference _handlerObjectWeakRef;
    private MethodInfo _handlerMethodInfo;
    private Action<WeakActionHandler<T1, T2>> _removeAction;

    /// <summary>
    /// Constructs the WeakActionHandler.  Attention! Make sure that you don't use member variables in <paramref name="removeHandlerAction"/>! Instead, make a copy to a local variable before and use this variable.
    /// </summary>
    /// <param name="handler">Event handler for the action event (event sink).</param>
    /// <param name="removeHandlerAction">Action that should remove the event handling by this instance.</param>
    /// 	/// <remarks>
    /// Typcical usage: <code>source.ActionEvent += new WeakActionHandler&lt;int,double&gt;(this.EhActionHandling, x =&gt; source.ActionEvent -= x);</code>
    /// </remarks>
    public WeakActionHandler(Action<T1, T2> handler, Action<WeakActionHandler<T1, T2>> removeHandlerAction)
    {
      if (handler.Target == null)
        throw new ArgumentException("Can not set weak events to a static handler method. Please use normal event handling to bind to a static method");

      _handlerObjectWeakRef = new WeakReference(handler.Target);
      _handlerMethodInfo = handler.Method;
      _removeAction = removeHandlerAction;
    }

    /// <summary>
    /// Handles the event from the original source. You must not call this method directly. However, it can be neccessary to use the method reference if the implicit casting fails. See remarks in the description of this class.
    /// </summary>
    /// <param name="t1">First action argument.</param>
    /// <param name="t2">Second action argument.</param>
    public void EventSink(T1 t1, T2 t2)
    {
      var handlerObj = _handlerObjectWeakRef.Target;
      if (null != handlerObj)
      {
        _handlerMethodInfo.Invoke(handlerObj, new object[] { t1, t2 });
      }
      else
      {
        Remove();
      }
    }

    /// <summary>Removes the event handler from the event source, using the stored remove action..</summary>
    public void Remove()
    {
      _handlerObjectWeakRef = _weakNullReference;
      var removeAction = System.Threading.Interlocked.Exchange(ref _removeAction, null);
      if (null != removeAction)
      {
        removeAction(this);
      }
    }

    /// <summary>
    /// Converts this instance to an action that can be used to add or remove it from/to an event.
    /// </summary>
    /// <param name="weakHandler">The WeakActionHandler instance.</param>
    /// <returns>A reference to the event handler routine inside the WeakActionHandler instance.</returns>
    public static implicit operator Action<T1, T2>(WeakActionHandler<T1, T2> weakHandler)
    {
      return weakHandler.EventSink;
    }
  }

  #endregion WeakActionHandler<T1,T2> (for an Action with two generic arguments)

  #region WeakActionHandler<T1,T2,T3> (for an Action with three generic arguments)

  /// <summary>
  /// Mediates an action event with two arguments, holding only a weak reference to the event sink.
  /// Thus there is no reference created from the event source to the event sink, and the event sink can be garbage collected.
  /// </summary>
  /// <typeparam name="T1">First action parameter.</typeparam>
  /// <typeparam name="T2">Second action parameter.</typeparam>
  /// <typeparam name="T3">Third action parameter.</typeparam>
  /// <remarks>
  /// Typical use (Attention: source has to be a local variable, <b>not</b> a member variable!)
  /// <code>
  /// source.ActionEvent += new WeakActionHandler&lt;MyArg1,MyArg2&gt;(this.EhActionHandling, x =&gt; source.ActionEvent -= x);
  /// </code>
  /// Sometimes it might be neccessary to use explicitly the event handler method of this instance:
  /// <code>
  /// source.ActionEvent += new WeakActionHandler&lt;MyArg1,MyArg2&gt;(this.EhActionHandling, x=&gt; source.ActionEvent -= x.EventSink).EventSink;
  /// </code>
  /// You can even maintain a reference to the WeakActionHandler instance in your event sink instance, in case you have to remove the event handling programmatically:
  /// <code>
  /// _weakActionHandler = new WeakActionHandler&lt;MyArg1,MyArg2&gt;(this.EhActionHandling, x =&gt; source.ActionEvent -= x); // _weakActionHandler is an instance variable of this class
  /// source.ActionEvent += _weakActionHandler;
  /// .
  /// .
  /// .
  /// source.ActionEvent -= _weakActionHandler;
  /// </code>
  /// </remarks>
  public class WeakActionHandler<T1, T2, T3>
  {
    private static WeakReference _weakNullReference = new WeakReference(null);
    private WeakReference _handlerObjectWeakRef;
    private MethodInfo _handlerMethodInfo;
    private Action<WeakActionHandler<T1, T2, T3>> _removeAction;

    /// <summary>
    /// Constructs the WeakActionHandler.  Attention! Make sure that you don't use member variables in <paramref name="removeHandlerAction"/>! Instead, make a copy to a local variable before and use this variable.
    /// </summary>
    /// <param name="handler">Event handler for the action event (event sink).</param>
    /// <param name="removeHandlerAction">Action that should remove the event handling by this instance.</param>
    /// 	/// <remarks>
    /// Typcical usage: <code>source.ActionEvent += new WeakActionHandler&lt;int,double&gt;(this.EhActionHandling, x =&gt; source.ActionEvent -= x);</code>
    /// </remarks>
    public WeakActionHandler(Action<T1, T2, T3> handler, Action<WeakActionHandler<T1, T2, T3>> removeHandlerAction)
    {
      if (handler.Target == null)
        throw new ArgumentException("Can not set weak events to a static handler method. Please use normal event handling to bind to a static method");

      _handlerObjectWeakRef = new WeakReference(handler.Target);
      _handlerMethodInfo = handler.Method;
      _removeAction = removeHandlerAction;
    }

    /// <summary>
    /// Handles the event from the original source. You must not call this method directly. However, it can be neccessary to use the method reference if the implicit casting fails. See remarks in the description of this class.
    /// </summary>
    /// <param name="t1">First action argument.</param>
    /// <param name="t2">Second action argument.</param>
    /// <param name="t3">Third action argument.</param>
    public void EventSink(T1 t1, T2 t2, T3 t3)
    {
      var handlerObj = _handlerObjectWeakRef.Target;
      if (null != handlerObj)
      {
        _handlerMethodInfo.Invoke(handlerObj, new object[] { t1, t2, t3 });
      }
      else
      {
        Remove();
      }
    }

    /// <summary>Removes the event handler from the event source, using the stored remove action..</summary>
    public void Remove()
    {
      _handlerObjectWeakRef = _weakNullReference;
      var removeAction = System.Threading.Interlocked.Exchange(ref _removeAction, null);
      if (null != removeAction)
      {
        removeAction(this);
      }
    }

    /// <summary>
    /// Converts this instance to an action that can be used to add or remove it from/to an event.
    /// </summary>
    /// <param name="weakHandler">The WeakActionHandler instance.</param>
    /// <returns>A reference to the event handler routine inside the WeakActionHandler instance.</returns>
    public static implicit operator Action<T1, T2, T3>(WeakActionHandler<T1, T2, T3> weakHandler)
    {
      return weakHandler.EventSink;
    }
  }

  #endregion WeakActionHandler<T1,T2,T3> (for an Action with three generic arguments)
}
