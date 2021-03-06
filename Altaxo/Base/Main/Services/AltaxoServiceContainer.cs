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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altaxo.Main.Services
{
  /// <summary>
  /// A thread-safe service container class.
  /// </summary>
  public sealed class AltaxoServiceContainer : IServiceProvider, IServiceContainer, IDisposable
  {
    private readonly ConcurrentStack<IServiceProvider> _fallbackServiceProviders = new ConcurrentStack<IServiceProvider>();
    private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();
    private readonly List<Type> servicesToDispose = new List<Type>();
    private readonly Dictionary<Type, object> _taskCompletionSources = new Dictionary<Type, object>(); // object = TaskCompletionSource<T> for various T

    public AltaxoServiceContainer()
    {
      _services.Add(typeof(AltaxoServiceContainer), this);
      _services.Add(typeof(IServiceContainer), this);
    }

    public void AddFallbackProvider(IServiceProvider provider)
    {
      _fallbackServiceProviders.Push(provider);
    }

    public object GetService(Type serviceType)
    {
      object instance;
      lock (_services)
      {
        if (_services.TryGetValue(serviceType, out instance))
        {
          var callback = instance as ServiceCreatorCallback;
          if (callback != null)
          {
            instance = callback(this, serviceType);
            if (instance != null)
            {
              _services[serviceType] = instance;
              OnServiceInitialized(serviceType, instance);
            }
            else
            {
              _services.Remove(serviceType);
            }
          }
        }
      }
      if (instance != null)
        return instance;
      foreach (var fallbackProvider in _fallbackServiceProviders)
      {
        instance = fallbackProvider.GetService(serviceType);
        if (instance != null)
          return instance;
      }
      return null;
    }

    public void Dispose()
    {
      Type[] disposableTypes;
      lock (_services)
      {
        disposableTypes = servicesToDispose.ToArray();
        //services.Clear();
        servicesToDispose.Clear();
      }
      // dispose services in reverse order of their creation
      for (int i = disposableTypes.Length - 1; i >= 0; i--)
      {
        IDisposable disposable = null;
        lock (_services)
        {
          if (_services.TryGetValue(disposableTypes[i], out object serviceInstance))
          {
            disposable = serviceInstance as IDisposable;
            if (disposable != null)
              _services.Remove(disposableTypes[i]);
          }
        }
        disposable?.Dispose();
      }
    }

    private void OnServiceInitialized(Type serviceType, object serviceInstance)
    {
      if (serviceInstance is IDisposable disposableService)
        servicesToDispose.Add(serviceType);

      if (_taskCompletionSources.TryGetValue(serviceType, out dynamic taskCompletionSource))
      {
        _taskCompletionSources.Remove(serviceType);
        taskCompletionSource.SetResult((dynamic)serviceInstance);
      }
    }

    public void AddService(Type serviceType, object serviceInstance)
    {
      lock (_services)
      {
        _services.Add(serviceType, serviceInstance);
        OnServiceInitialized(serviceType, serviceInstance);
      }
    }

    public void AddService(Type serviceType, object serviceInstance, bool promote)
    {
      AddService(serviceType, serviceInstance);
    }

    public void AddService(Type serviceType, ServiceCreatorCallback callback)
    {
      lock (_services)
      {
        _services.Add(serviceType, callback);
      }
    }

    public void AddService(Type serviceType, ServiceCreatorCallback callback, bool promote)
    {
      AddService(serviceType, callback);
    }

    public void RemoveService(Type serviceType)
    {
      lock (_services)
      {
        if (_services.TryGetValue(serviceType, out object instance))
        {
          _services.Remove(serviceType);
          var disposableInstance = instance as IDisposable;
          if (disposableInstance != null)
            servicesToDispose.Remove(serviceType);
        }
      }
    }

    public void RemoveService(Type serviceType, bool promote)
    {
      RemoveService(serviceType);
    }

    public Task<T> GetFutureService<T>()
    {
      Type serviceType = typeof(T);
      lock (_services)
      {
        if (_services.ContainsKey(serviceType))
        {
          return Task.FromResult((T)GetService(serviceType));
        }
        else
        {
          if (_taskCompletionSources.TryGetValue(serviceType, out object taskCompletionSource))
          {
            return ((TaskCompletionSource<T>)taskCompletionSource).Task;
          }
          else
          {
            var tcs = new TaskCompletionSource<T>();
            _taskCompletionSources.Add(serviceType, tcs);
            return tcs.Task;
          }
        }
      }
    }
  }
}
