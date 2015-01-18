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

using Altaxo.Collections;
using Altaxo.Graph.Gdi.Plot;
using Altaxo.Graph.Gdi.Plot.Groups;
using Altaxo.Graph.Plot.Groups;
using Altaxo.Main.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altaxo.Gui.Graph
{
	#region Interface

	public interface IPlotGroupCollectionView
	{
		/// <summary>
		/// Sets the simple view object and makes it visible.
		/// </summary>
		/// <param name="viewObject">The object to visualize.</param>
		void SetSimpleView(object viewObject);

		/// <summary>
		/// Sets the advanced view object  and makes it visible.
		/// </summary>
		/// <param name="viewObject">The object to visualize.</param>
		void SetAdvancedView(object viewObject);

		event Action GotoAdvanced;

		event Action GotoSimple;
	}

	#endregion Interface

	/// <summary>
	/// This is the controller for a <see cref="PlotGroupStyleCollection"/> that choose between the simple and the advanced presentation mode.
	/// </summary>
	[ExpectedTypeOfView(typeof(IPlotGroupCollectionView))]
	public class PlotGroupCollectionController : IMVCANController
	{
		private IPlotGroupCollectionView _view;
		private PlotGroupStyleCollection _origdoc;
		private PlotGroupStyleCollection _doc;

		private PlotGroupCollectionControllerAdvanced _controllerAdvanced;
		private PlotGroupCollectionControllerSimple _controllerSimple;

		private void Initialize(bool initData)
		{
			if (initData)
			{
				bool isSerialStepping, isColor, isLineStyle, isSymbolStyle;
				if (PlotGroupCollectionControllerSimple.IsSimplePlotGrouping(_doc, out isSerialStepping, out isColor, out isLineStyle, out isSymbolStyle))
				{
					_controllerSimple = new PlotGroupCollectionControllerSimple();
					_controllerSimple.UseDocumentCopy = UseDocument.Directly;
					_controllerSimple.InitializeDocument(_doc);
					_controllerAdvanced = null;
				}
				else
				{
					_controllerAdvanced = new PlotGroupCollectionControllerAdvanced();
					_controllerAdvanced.UseDocumentCopy = UseDocument.Directly;
					_controllerAdvanced.InitializeDocument(_doc);
					_controllerSimple = null;
				}
			}

			if (null != _view)
			{
				if (_controllerSimple != null)
				{
					if (null == _controllerSimple.ViewObject)
						Current.Gui.FindAndAttachControlTo(_controllerSimple);
					_view.SetSimpleView(_controllerSimple.ViewObject);
				}
				else if (_controllerAdvanced != null)
				{
					if (null == _controllerAdvanced.ViewObject)
						Current.Gui.FindAndAttachControlTo(_controllerAdvanced);
					_view.SetAdvancedView(_controllerAdvanced.ViewObject);
				}
			}
		}

		#region IMVCANController

		public bool InitializeDocument(params object[] args)
		{
			if (args == null || args.Length == 0 || !(args[0] is PlotGroupStyleCollection))
				return false;
			_origdoc = (PlotGroupStyleCollection)args[0];
			_doc = _origdoc.Clone();
			Initialize(true);
			return true;
		}

		public UseDocument UseDocumentCopy
		{
			set { }
		}

		public object ViewObject
		{
			get
			{
				return _view;
			}
			set
			{
				if (_view != null)
				{
					_view.GotoAdvanced -= new Action(EhView_GotoAdvanced);
					_view.GotoSimple -= new Action(EhView_GotoSimple);
				}

				_view = value as IPlotGroupCollectionView;

				if (_view != null)
				{
					Initialize(false);

					_view.GotoAdvanced += new Action(EhView_GotoAdvanced);
					_view.GotoSimple += new Action(EhView_GotoSimple);
				}
			}
		}

		private void EhView_GotoSimple()
		{
			_controllerAdvanced.Apply(false);
			_doc = (PlotGroupStyleCollection)_controllerAdvanced.ModelObject;

			if (PlotGroupCollectionControllerSimple.IsSimplePlotGrouping(_doc))
			{
				_controllerAdvanced = null;
				_controllerSimple = new PlotGroupCollectionControllerSimple();
				_controllerSimple.UseDocumentCopy = UseDocument.Directly;
				_controllerSimple.InitializeDocument(_doc);
				Initialize(false);
			}
			else
			{
				Current.Gui.ErrorMessageBox("Sorry, this collection is too complicate to be represented by a simple view.");
			}
		}

		private void EhView_GotoAdvanced()
		{
			_controllerSimple.Apply(false);
			_doc = (PlotGroupStyleCollection)_controllerSimple.ModelObject;
			_controllerSimple = null;

			_controllerAdvanced = new PlotGroupCollectionControllerAdvanced();
			_controllerAdvanced.UseDocumentCopy = UseDocument.Directly;
			_controllerAdvanced.InitializeDocument(_doc);
			Initialize(false);
		}

		public object ModelObject
		{
			get { return _origdoc; }
		}

		public void Dispose()
		{
		}

		public bool Apply(bool disposeController)
		{
			bool result;
			if (null != _controllerSimple)
				result = _controllerSimple.Apply(disposeController);
			else
				result = _controllerAdvanced.Apply(disposeController);

			if (true == result)
			{
				if (null != _controllerSimple)
				{
					_doc = (PlotGroupStyleCollection)_controllerSimple.ModelObject;
				}
				else
				{
					_doc = (PlotGroupStyleCollection)_controllerAdvanced.ModelObject;
				}
				_origdoc.CopyFrom(_doc);
			}

			return result;
		}

		/// <summary>
		/// Try to revert changes to the model, i.e. restores the original state of the model.
		/// </summary>
		/// <param name="disposeController">If set to <c>true</c>, the controller should release all temporary resources, since the controller is not needed anymore.</param>
		/// <returns>
		///   <c>True</c> if the revert operation was successfull; <c>false</c> if the revert operation was not possible (i.e. because the controller has not stored the original state of the model).
		/// </returns>
		public bool Revert(bool disposeController)
		{
			return false;
		}

		#endregion IMVCANController
	}
}