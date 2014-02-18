﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2014 Dr. Dirk Lellinger
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

using Altaxo.Graph.Gdi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Altaxo.Com
{
	using UnmanagedApi.Ole32;

	[Guid("072CDB1D-745E-4213-9124-53667725B839"),
	ClassInterface(ClassInterfaceType.None)  // Specify that no additional interface is generated
	]
	public class ProjectFileComObject :
		ReferenceCountedObjectBase,
		IPersistFile,
		IOleItemContainer
	{
		private Altaxo.AltaxoDocument _currentProject;

		/// <summary>
		/// The file moniker for the current project name.
		/// </summary>
		private IMoniker _fileMoniker;

		/// <summary>
		/// The cookie that is received when the _moniker is registered in the running object table.
		/// </summary>
		private int _fileMonikerRotCookie;

		/// <summary>
		/// Moniker that is a combination of the file moniker with a wildcard item, and thus is valid for all items in file.
		/// </summary>
		private IMoniker _fileWithWildCardItemMoniker;

		/// <summary>
		/// The cookie that is received when <see cref="_fileWithWildCardItemMoniker"/> is registered in the running object table.
		/// </summary>
		private int _fileWithWildCardItemMonikerRotCookie;

		public event Action<IMoniker> FileMonikerChanged;

		public ProjectFileComObject(ComManager comManager)
			: base(comManager)
		{
			// 1. Monitor the change of the project instance
			Current.ProjectService.ProjectChanged += EhCurrentProjectInstanceChanged;
			Current.ProjectService.ProjectRenamed += EhCurrentProjectFileNameChanged;

			EhCurrentProjectInstanceChanged(null, null);
		}

		public void Dispose()
		{
#if COMLOGGING
			Debug.ReportInfo("{0}.Dispose", this.GetType().Name);
#endif

			if (null != _currentProject)
			{
				_currentProject.GraphDocumentCollection.CollectionChanged -= EhGraphDocumentRenamed;
				_currentProject = null;
			}
			Current.ProjectService.ProjectChanged -= EhCurrentProjectInstanceChanged;
			Current.ProjectService.ProjectRenamed -= EhCurrentProjectFileNameChanged;
		}

		public IMoniker FileMoniker { get { return _fileMoniker; } }

		private void EhCurrentProjectInstanceChanged(object sender, Altaxo.Main.ProjectEventArgs e)
		{
			if (object.ReferenceEquals(Current.Project, _currentProject))
				return;

#if COMLOGGING
			Debug.ReportInfo("{0}.EhCurrentProjectInstanceChanged", this.GetType().Name);
#endif

			if (null != _currentProject)
			{
				_currentProject.GraphDocumentCollection.CollectionChanged -= EhGraphDocumentRenamed;
			}

			_currentProject = Current.Project;

			if (null != _currentProject)
			{
				_currentProject.GraphDocumentCollection.CollectionChanged += EhGraphDocumentRenamed;
				EhCurrentProjectFileNameChanged(Current.ProjectService.CurrentProjectFileName);
			}
		}

		private void EhGraphDocumentRenamed(Main.NamedObjectCollectionChangeType changeType, object item, string oldName, string newName)
		{
			if (changeType == Main.NamedObjectCollectionChangeType.ItemRenamed)
			{
				foreach (var comObj in _comManager.GraphDocumentLinkedComObjects)
				{
					if (object.ReferenceEquals(comObj.Document, item))
						comObj.EhDocumentRenamed(_fileMoniker);
				}
			}
		}

		private void EhCurrentProjectFileNameChanged(object sender, Altaxo.Main.ProjectRenameEventArgs e)
		{
			EhCurrentProjectFileNameChanged(e.NewName);
		}

		private void EhCurrentProjectFileNameChanged(string fileName)
		{
			// see Brockschmidt, Inside Ole 2nd ed., page 996

			// make sure that if we have a valid file name, then the ComManager should be Active in order that this Com object is made public
			if (!string.IsNullOrEmpty(fileName) && !_comManager.IsActive)
			{
#if COMLOGGING
				Debug.ReportInfo("{0}.EhCurrentProjectFileNameChanged StartLocalServer because we have a valid file name. FileName: {1}", this.GetType().Name, fileName);
#endif
				_comManager.StartLocalServer();
			}

#if COMLOGGING
			Debug.ReportInfo("{0}.EhCurrentProjectFileNameChanged", this.GetType().Name);
#endif

			RunningObjectTableHelper.ROTUnregister(ref _fileWithWildCardItemMonikerRotCookie);
			_fileWithWildCardItemMoniker = null;
			RunningObjectTableHelper.ROTUnregister(ref _fileMonikerRotCookie);
			_fileMoniker = null;

			if (!string.IsNullOrEmpty(fileName))
			{
				Ole32Func.CreateFileMoniker(fileName, out _fileMoniker);
				if (null != _fileMoniker)
				{
					RunningObjectTableHelper.ROTRegisterAsRunning(_fileMoniker, this, ref _fileMonikerRotCookie, typeof(IPersistFile));

					// Notify all other item Com objects of the new _fileMoniker
					if (null != FileMonikerChanged)
						FileMonikerChanged(_fileMoniker);

					// now register also a file moniker with a wild card item, that handles all items that are not open in the moment
					IMoniker wildCardItemMoniker;
					Ole32Func.CreateItemMoniker("!", "\\", out wildCardItemMoniker);
					if (null != wildCardItemMoniker)
					{
						_fileMoniker.ComposeWith(wildCardItemMoniker, false, out _fileWithWildCardItemMoniker);
						RunningObjectTableHelper.ROTRegisterAsRunning(_fileWithWildCardItemMoniker, this, ref _fileWithWildCardItemMonikerRotCookie, typeof(IOleItemContainer));
					}
				}
			}
		}

		#region Interface IPersistFile

		public void GetClassID(out Guid pClassID)
		{
#if COMLOGGING
			Debug.ReportInfo("{0}.GetClassID", this.GetType().Name);
#endif

			pClassID = this.GetType().GUID;
		}

		public void GetCurFile(out string ppszFileName)
		{
			ppszFileName = Current.ProjectService.CurrentProjectFileName;

#if COMLOGGING
			Debug.ReportInfo("{0}.GetCurFile -> {1}", this.GetType().Name, ppszFileName);
#endif
		}

		public int IsDirty()
		{
#if COMLOGGING
			Debug.ReportInfo("{0}.IsDirty -> FALSE", this.GetType().Name);
#endif
			return ComReturnValue.S_FALSE;
		}

		public void Load(string pszFileName, int dwMode)
		{
#if COMLOGGING
			Debug.ReportInfo("{0}.Load filename: {1}", this.GetType().Name, pszFileName);
#endif

			Current.ProjectService.OpenProject(pszFileName, false);
		}

		public void Save(string pszFileName, bool fRemember)
		{
#if COMLOGGING
			Debug.ReportInfo("{0}.Save filename: {1}", this.GetType().Name, pszFileName);
#endif

			Current.ProjectService.SaveProject(pszFileName);
		}

		public void SaveCompleted(string pszFileName)
		{
#if COMLOGGING
			Debug.ReportInfo("{0}.SaveCompleted filename: {1}", this.GetType().Name, pszFileName);
#endif
			throw new NotImplementedException();
		}

		#endregion Interface IPersistFile

		#region Interface IOleItemContainer

		public int ParseDisplayName(IBindCtx pbc, string pszDisplayName, out int pchEaten, out IMoniker ppmkOut)
		{
#if COMLOGGING
			Debug.ReportError("{0}.ParseDisplayName -> not implemented!", this.GetType().Name);
#endif
			throw new NotImplementedException();
		}

		public int EnumObjects(int grfFlags, out IEnumUnknown ppenum)
		{
#if COMLOGGING
			Debug.ReportInfo("{0}.EnumObjects", this.GetType().Name);
#endif
			throw new NotImplementedException();
		}

		public int LockContainer(bool fLock)
		{
#if COMLOGGING
			Debug.ReportWarning("{0}.LockContainer({1}) -> not implemented", this.GetType().Name, fLock);
#endif

			return ComReturnValue.NOERROR;
		}

		public IntPtr GetObject(string pszItem, int dwSpeedNeeded, IBindCtx pbc, ref Guid riid)
		{
			// Brockschmidt, Inside Ole 2nd ed. page 1003

			pszItem = DataObjectHelper.MonikerNameStringToNormalString(pszItem);

#if COMLOGGING
			Debug.ReportInfo("{0}.GetObject {1}, Requesting Interface : {2}", this.GetType().Name, pszItem, riid);
#endif

			Altaxo.Graph.Gdi.GraphDocument doc;
			bool isRunning = _currentProject.GraphDocumentCollection.TryGetValue(pszItem, out doc);

			if (((int)BINDSPEED.BINDSPEED_IMMEDIATE == dwSpeedNeeded || (int)BINDSPEED.BINDSPEED_MODERATE == dwSpeedNeeded) && !isRunning)
				throw Marshal.GetExceptionForHR(ComReturnValue.MK_E_EXCEEDEDDEADLINE);

			if (null == doc) // in this application we can do nothing but to return intptr.Zero
				return IntPtr.Zero;

			if (riid == Marshal.GenerateGuidForType(typeof(System.Runtime.InteropServices.ComTypes.IDataObject)) ||
				riid == Marshal.GenerateGuidForType(typeof(IOleObject)) ||
				riid == InterfaceGuid.IID_IDispatch ||
				riid == InterfaceGuid.IID_IUnknown)
			{
				var documentComObject = _comManager.GetDocumentsComObjectForGraphDocument(doc);
				IntPtr ppvObject = Marshal.GetComInterfaceForObject(documentComObject, typeof(System.Runtime.InteropServices.ComTypes.IDataObject));

				var action = new Action(() => Current.ProjectService.ShowDocumentView(doc));
				Current.Gui.BeginExecute(action);

				return ppvObject;
			}
			else
			{
				throw new COMException("No interface", unchecked((int)0x80004002));
			}
		}

		public object GetObjectStorage(string pszItem, IBindCtx pbc, ref Guid riid)
		{
#if COMLOGGING
			Debug.ReportInfo("{0}.GetObjectStorage -> not implemented!", this.GetType().Name);
#endif
			throw new NotImplementedException();
		}

		public int IsRunning(string pszItem)
		{
			GraphDocument doc;
			bool isRunning = _currentProject.GraphDocumentCollection.TryGetValue(pszItem, out doc);

#if COMLOGGING
			Debug.ReportInfo("{0}.IsRunning item={1}, result={2}", this.GetType().Name, pszItem, isRunning);
#endif

			return isRunning ? ComReturnValue.NOERROR : ComReturnValue.S_FALSE;
		}

		#endregion Interface IOleItemContainer
	}
}