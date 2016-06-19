#region Copyright

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
using Altaxo.Drawing.D3D;
using Altaxo.Graph;
using Altaxo.Graph.Graph3D;
using Altaxo.Graph.Graph3D.Plot.Styles;
using Altaxo.Graph.Graph3D.Plot.Styles.LineConnectionStyles;
using Altaxo.Graph.Plot.Groups;
using Altaxo.Gui.Graph;
using Altaxo.Main;
using System;
using System.Collections.Generic;

namespace Altaxo.Gui.Graph3D.Plot.Styles
{
	#region Interfaces

	/// <summary>
	/// This view interface is for showing the options of the XYXYPlotLineStyle
	/// </summary>
	public interface IXYZPlotLineStyleView
	{
		bool ShowPlotColorsOnlyForLinePen { set; }

		bool IndependentLineColor { get; set; }

		PenX3D LinePen { get; set; }

		/// <summary>
		/// Initializes the LineSymbolGap check box.
		/// </summary>
		bool LineSymbolGap { get; set; }

		bool ConnectCircular { get; set; }

		/// <summary>
		/// Initializes the Line connection combobox.
		/// </summary>
		/// <param name="list">List of possible selections.</param>
		void InitializeLineConnect(SelectableListNodeList list);

		/// <summary>
		/// Enables / disables all controls associated with line properties with exception of the Connection style combo box.
		/// </summary>
		/// <value>
		///   <c>true</c> if [enable line controls]; otherwise, <c>false</c>.
		/// </value>
		bool EnableLineControls { set; }

		#region events

		/// <summary>Occurs when the user choice for IndependentColor of the frame pen has changed.</summary>
		event Action IndependentLineColorChanged;

		/// <summary>Occurs when the user checked or unchecked the "use frame" checkbox.</summary>
		event Action UseLineChanged;

		/// <summary>Occurs when the  frame pen has changed by user interaction.</summary>
		event Action LinePenChanged;

		#endregion events
	}

	#endregion Interfaces

	/// <summary>
	/// Summary description for XYPlotLineStyleController.
	/// </summary>
	[UserControllerForObject(typeof(LinePlotStyle))]
	[ExpectedTypeOfView(typeof(IXYZPlotLineStyleView))]
	public class XYZPlotLineStyleController : MVCANControllerEditOriginalDocBase<LinePlotStyle, IXYZPlotLineStyleView>
	{
		/// <summary>Tracks the presence of a color group style in the parent collection.</summary>
		private ColorGroupStylePresenceTracker _colorGroupStyleTracker;

		private SelectableListNodeList _lineConnectChoices;
		private SelectableListNodeList _areaFillDirectionChoices;
		private SelectableListNodeList _fillColorLinkageChoices;

		public override IEnumerable<ControllerAndSetNullMethod> GetSubControllers()
		{
			yield break;
		}

		public override void Dispose(bool isDisposing)
		{
			_colorGroupStyleTracker = null;

			_lineConnectChoices = null;
			_areaFillDirectionChoices = null;
			_fillColorLinkageChoices = null;

			base.Dispose(isDisposing);
		}

		protected override void Initialize(bool initData)
		{
			base.Initialize(initData);

			if (initData)
			{
				_colorGroupStyleTracker = new ColorGroupStylePresenceTracker(_doc, EhColorGroupStyleAddedOrRemoved);
				InitializeLineConnectionChoices();
			}

			if (_view != null)
			{
				// Line properties
				_view.InitializeLineConnect(_lineConnectChoices);
				_view.LineSymbolGap = _doc.LineSymbolGap;
				_view.ConnectCircular = _doc.ConnectCircular;
				_view.IndependentLineColor = _doc.IndependentLineColor;
				_view.ShowPlotColorsOnlyForLinePen = _colorGroupStyleTracker.MustUsePlotColorsOnly(_doc.IndependentLineColor);
				_view.LinePen = _doc.LinePen;
			}
		}

		private void InitializeLineConnectionChoices()
		{
			if (null == _lineConnectChoices)
				_lineConnectChoices = new SelectableListNodeList();
			else
				_lineConnectChoices.Clear();

			var types = Altaxo.Main.Services.ReflectionService.GetNonAbstractSubclassesOf(typeof(ILineConnectionStyle));

			foreach (var t in types)
			{
				_lineConnectChoices.Add(new SelectableListNode(t.Name, t, t == _doc.Connection.GetType()));
			}
		}

		public override bool Apply(bool disposeController)
		{
			// don't trust user input, so all into a try statement
			try
			{
				// Symbol Gap
				_doc.LineSymbolGap = _view.LineSymbolGap;

				// Pen
				_doc.IndependentLineColor = _view.IndependentLineColor;
				_doc.LinePen = _view.LinePen;

				// Line Connect
				_doc.ConnectCircular = _view.ConnectCircular;

				var selNode = _lineConnectChoices.FirstSelectedNode;
				var connectionType = (Type)(selNode.Tag);
				if (connectionType == typeof(NoConnection))
					_doc.Connection = NoConnection.Instance;
				else
					_doc.Connection = (ILineConnectionStyle)Activator.CreateInstance(connectionType);

				return ApplyEnd(true, disposeController);
			}
			catch (Exception ex)
			{
				Current.Gui.ErrorMessageBox("A problem occured. " + ex.Message);
				return false;
			}
		}

		protected override void AttachView()
		{
			base.AttachView();

			_view.IndependentLineColorChanged += EhIndependentLineColorChanged;
		}

		protected override void DetachView()
		{
			_view.IndependentLineColorChanged -= EhIndependentLineColorChanged;
			base.DetachView();
		}

		#region Color management

		/// <summary>
		/// Gets or sets a value indicating whether the line is shown or not. By definition here, the line is not shown only if the connection style is "Noline".
		/// When setting this property, this influences not the connection style in the _view, but only the IsEnabled property of all Gui items associated with the line.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if the line used; otherwise, <c>false</c>.
		/// </value>
		private bool IsLineUsed
		{
			get
			{
				var selNode = _lineConnectChoices.FirstSelectedNode;
				return Altaxo.Graph.Gdi.Plot.Styles.XYPlotLineStyles.ConnectionStyle.NoLine != (Altaxo.Graph.Gdi.Plot.Styles.XYPlotLineStyles.ConnectionStyle)(selNode.Tag);
			}
			set
			{
				if (null != _view)
					_view.EnableLineControls = value;
			}
		}

		private void EhColorGroupStyleAddedOrRemoved()
		{
			if (null != _view)
			{
				_doc.IndependentLineColor = _view.IndependentLineColor;
				if (IsLineUsed)
					_view.ShowPlotColorsOnlyForLinePen = _colorGroupStyleTracker.MustUsePlotColorsOnly(_doc.IndependentLineColor);
			}
		}

		private void EhIndependentLineColorChanged()
		{
			if (null != _view)
			{
				_doc.IndependentLineColor = _view.IndependentLineColor;
				_view.ShowPlotColorsOnlyForLinePen = _colorGroupStyleTracker.MustUsePlotColorsOnly(_doc.IndependentLineColor);
			}
		}

		#endregion Color management
	} // end of class XYPlotLineStyleController
} // end of namespace