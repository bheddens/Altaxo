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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Altaxo.Gui.Startup;
using Altaxo.Main.Services;

namespace Altaxo.Gui.Workbench
{
  /// <summary>
  /// Helper class to start-up the workbench window.
  /// </summary>
  public class WorkbenchStartup
  {
    private App _application;

    private AltaxoWorkbench _workbench;

    public void InitializeWorkbench()
    {
      _application = new App();

      var synchronizationContext = SynchronizationContext.Current;
      if (null == synchronizationContext)
      {
        using (var ctrl = new System.Windows.Forms.Control()) // trick: create a windows forms control to make sure we have a synchronization context
        {
          synchronizationContext = SynchronizationContext.Current;
        }
      }

      Current.AddService<IDispatcherMessageLoop, IDispatcherMessageLoopWpf>(new DispatcherMessageLoop(_application.Dispatcher, synchronizationContext));

      _workbench = new AltaxoWorkbench(); // workbench view model

      Altaxo.Current.AddService<IWorkbench, IWorkbenchEx, AltaxoWorkbench>(_workbench);

      _workbench.RestoreWorkbenchStateFromPropertyService();
      _workbench.RestoreWorkbenchDockingLayoutFromPropertyService();
      _workbench.RestoreWorkbenchDockingThemeFromPropertyService();

      //UILanguageService.ValidateLanguage();

      //TaskService.Initialize();
      //Project.CustomToolsService.Initialize();
    }

    public void Run(StartupSettings startupArguments)
    {
      var mainForm = new MainWorkbenchWindow();
      _workbench.Initialize(mainForm);
      mainForm.DataContext = Current.Workbench;
      var propertyService = Current.PropertyService; // save as local variable because if the app is closed, the services will be shutdown by the shutdown service

      Current.IProjectService.ExecuteActionsImmediatelyBeforeRunningApplication(startupArguments.StartupArgs, startupArguments.ParameterList, startupArguments.RequestedFileList);

      string lastArg = startupArguments.StartupArgs.Length > 0 ? startupArguments.StartupArgs[startupArguments.StartupArgs.Length - 1].ToLowerInvariant() : string.Empty;
      if (lastArg == "-exit" || lastArg == "/exit")
        return;


      _application.Run(mainForm);
    }
  }
}
