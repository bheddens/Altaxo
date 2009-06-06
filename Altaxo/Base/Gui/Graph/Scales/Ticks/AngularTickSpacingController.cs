﻿#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2007 Dr. Dirk Lellinger
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
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Altaxo.Collections;
using Altaxo.Graph.Scales;
using Altaxo.Graph.Scales.Ticks;

namespace Altaxo.Gui.Graph.Scales.Ticks
{
	#region Interfaces

	public interface IAngularTickSpacingView
	{
		bool UsePositiveNegativeValues { get; set; }
		SelectableListNodeList MajorTicks { set; }
		SelectableListNodeList MinorTicks { set; }
		event EventHandler MajorTicksChanged;
	}

	#endregion

	[UserControllerForObject(typeof(AngularTickSpacing))]
	[ExpectedTypeOfView(typeof(IAngularTickSpacingView))]
	public class AngularScaleController : IMVCANController
	{
		IAngularTickSpacingView _view;
		AngularTickSpacing _doc;

		SelectableListNodeList _majorTickList;
		SelectableListNodeList _minorTickList;
		int _tempMajorDivider;


		void Initialize(bool initDoc)
		{
			if (initDoc)
			{
				_tempMajorDivider = _doc.MajorTickDivider;
				BuildMajorTickList();
				BuildMinorTickList();
			}

			if (_view != null)
			{
				_view.UsePositiveNegativeValues = _doc.UseSignedValues;
				_view.MajorTicks = _majorTickList;
				_view.MinorTicks = _minorTickList;
			}
		}

		

		void BuildMajorTickList()
		{
			int[] possibleDividers = _doc.GetPossibleDividers();
			int selected = _tempMajorDivider;
			_majorTickList = new SelectableListNodeList();
			foreach (int div in possibleDividers)
			{
				_majorTickList.Add(new SelectableListNode((360.0 / div).ToString() + "°", div, div == selected));
			}
		}

		void BuildMinorTickList()
		{
			int[] possibleDividers = _doc.GetPossibleDividers();
			int selected = _doc.MinorTickDivider;
			if (selected < _tempMajorDivider)
				selected = _tempMajorDivider;
			_minorTickList = new SelectableListNodeList();
			foreach (int div in possibleDividers)
			{
				if (div >= _tempMajorDivider && 0 == (div % _tempMajorDivider))
					_minorTickList.Add(new SelectableListNode((360.0 / div).ToString() + "°", div, div == selected));
			}
		}

		void EhMajorTicksChanged(object sender, EventArgs e)
		{
			_tempMajorDivider = (int)_majorTickList.FirstSelectedNode.Item;
			BuildMinorTickList();
			_view.MinorTicks = _minorTickList;
		}


		#region IMVCANController Members

		public bool InitializeDocument(params object[] args)
		{
			if (args == null || args.Length == 0)
				return false;
			AngularTickSpacing doc = args[0] as AngularTickSpacing;
			if (doc == null)
				return false;
			_doc = doc;
			Initialize(true);
			return true;
		}

		public UseDocument UseDocumentCopy
		{
			set { }
		}

		#endregion

		#region IMVCController Members

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
					_view.MajorTicksChanged -= EhMajorTicksChanged;
				}
				_view = value as IAngularTickSpacingView;
				if (_view != null)
				{
					Initialize(false);
					_view.MajorTicksChanged += EhMajorTicksChanged;
				}
			}
		}

		public object ModelObject
		{
			get { return _doc; }
		}

		#endregion

		#region IApplyController Members

		public bool Apply()
		{
			_doc.UseSignedValues = _view.UsePositiveNegativeValues;
			_doc.MajorTickDivider = _tempMajorDivider;
			_doc.MinorTickDivider = (int)_minorTickList.FirstSelectedNode.Item;
			return true;
		}

		#endregion
	}
}