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
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using Altaxo.Serialization;
using System.Drawing;
using Altaxo.Graph.Gdi;
using Altaxo.Data;
using Altaxo.Graph;
using Altaxo.Graph.Gdi.Background;
using Altaxo.Graph.Gdi.Axis;


namespace Altaxo.Gui.Graph
{
	#region Interfaces

	public interface IAxisLabelStyleView
	{
		// events
		event Action LabelStyleChanged;

		/// <summary>
		/// Initializes the font family combo box.
		/// </summary>
		/// <param name="font">The actual font of the choice.</param>
		Font LabelFont { get; set; }

		/// <summary>
		/// Initializes the content of the Color combo box.
		/// </summary>
		BrushX LabelBrush { get; set; }


		/// <summary>
		/// Initializes the background.
		/// </summary>
		IBackgroundStyle Background { get; set; }


		/// <summary>
		/// Initializes the font size combo box.
		/// </summary>
		/// <param name="val">Value for the font size.</param>
		double FontSize { get; set; }

		/// <summary>
		/// Initializes the horizontal aligment combo box.
		/// </summary>
		/// <param name="names">The possible choices.</param>
		/// <param name="name">The actual name of the choice.</param>
		void HorizontalAlignment_Initialize(Collections.SelectableListNodeList items);
		/// <summary>
		/// Initializes the vertical alignement combo box.
		/// </summary>
		/// <param name="names">The possible choices.</param>
		/// <param name="name">The actual name of the choice.</param>
		void VerticalAlignment_Initialize(Collections.SelectableListNodeList items);

		/// <summary>
		/// Sets the automatic alignment check box.
		/// </summary>
		/// <param name="value"></param>
		bool AutomaticAlignment { get; set; }

		/// <summary>
		/// Initializes the content of the Rotation edit box.
		/// </summary>
		double Rotation { get; set; }


		/// <summary>
		/// Initializes the content of the XOffset edit box.
		/// </summary>
		double XOffset { get; set; }

		/// <summary>
		/// Initializes the content of the YOffset edit box.
		/// </summary>
		double YOffset { get; set; }

		/// <summary>
		/// Initializes the label style combo box.
		/// </summary>
		/// <param name="names">The possible choices.</param>
		/// <param name="name">The actual name of the choice.</param>
		void LabelStyle_Initialize(Collections.SelectableListNodeList items);

		string SuppressedLabelsByValue { get; set; }

		string SuppressedLabelsByNumber { get; set; }

		/// <summary>Sets the possible choices for the label side.</summary>
		/// <value>The label sides.</value>
		Collections.SelectableListNodeList LabelSides { set; }


		/// <summary>Gets or sets the prefix text that appears before the label.</summary>
		/// <value>The prefix text.</value>
		string PrefixText { get; set; }

		/// <summary>Gets or sets the postfix text that appears after the label.</summary>
		/// <value>The postfix text.</value>
		string PostfixText { get; set; }
	}



	#endregion

	/// <summary>
	/// Summary description.
	/// </summary>
	[UserControllerForObject(typeof(AxisLabelStyle))]
	[ExpectedTypeOfView(typeof(IAxisLabelStyleView))]
	public class AxisLabelStyleController : MVCANControllerBase<AxisLabelStyle, IAxisLabelStyleView>
	{
		Collections.SelectableListNodeList _labelSides;
		Collections.SelectableListNodeList _horizontalAlignmentChoices;
		Collections.SelectableListNodeList _verticalAlignmentChoices;
		Collections.SelectableListNodeList _labelStyles;


		protected override void AttachView()
		{
			_view.LabelStyleChanged += EhView_LabelStyleChanged;
		}

		protected override void DetachView()
		{
			_view.LabelStyleChanged -= EhView_LabelStyleChanged;
		}

		protected override void Initialize(bool bInit)
		{
			if (bInit)
			{
				// Label sides
				_labelSides = new Collections.SelectableListNodeList();
				_labelSides.Add(new Collections.SelectableListNode("Automatic", null, null == _doc.LabelSide));
				var list = new List<Collections.SelectableListNode>();
				if (_doc.CachedAxisInformation != null)
				{
					list.Add(new Collections.SelectableListNode(_doc.CachedAxisInformation.NameOfFirstDownSide, CSAxisSide.FirstDown, _doc.LabelSide == CSAxisSide.FirstDown));
					list.Add(new Collections.SelectableListNode(_doc.CachedAxisInformation.NameOfFirstUpSide, CSAxisSide.FirstUp, _doc.LabelSide == CSAxisSide.FirstUp));
				}
				list.Sort((x, y) => string.Compare(x.Text, y.Text));
				_labelSides.AddRange(list);

				// horizontal and vertical alignment
				_horizontalAlignmentChoices = new Collections.SelectableListNodeList(_doc.HorizontalAlignment);
				_verticalAlignmentChoices = new Collections.SelectableListNodeList(_doc.VerticalAlignment);

				// label formatting type
				var labelTypes = Altaxo.Main.Services.ReflectionService.GetNonAbstractSubclassesOf(typeof(Altaxo.Graph.Gdi.LabelFormatting.ILabelFormatting));
				_labelStyles = new Collections.SelectableListNodeList();
				for (int i = 0; i < labelTypes.Length; ++i)
				{
					_labelStyles.Add(new Collections.SelectableListNode(labelTypes[i].Name, labelTypes[i], labelTypes[i] == _doc.LabelFormat.GetType()));
				}
			}

			if (null != _view)
			{
				_view.LabelFont = _doc.Font;
				_view.LabelBrush = _doc.Brush.Clone();
				_view.HorizontalAlignment_Initialize(_horizontalAlignmentChoices);
				_view.VerticalAlignment_Initialize(_verticalAlignmentChoices);
				_view.AutomaticAlignment = _doc.AutomaticAlignment;
				_view.Rotation = (float)_doc.Rotation;
				_view.XOffset = _doc.XOffset;
				_view.YOffset = _doc.YOffset;
				_view.Background = _doc.BackgroundStyle;
				_view.SuppressedLabelsByValue = Serialization.GUIConversion.ToString(_doc.SuppressedLabels.ByValues);
				_view.SuppressedLabelsByNumber = Serialization.GUIConversion.ToString(_doc.SuppressedLabels.ByNumbers);
				_view.PrefixText = _doc.PrefixText;
				_view.PostfixText = _doc.PostfixText;
				_view.LabelSides = _labelSides;
				_view.LabelStyle_Initialize(_labelStyles);
			}
		}


		public override bool Apply()
		{
			_doc.Font = _view.LabelFont;
			_doc.Brush = _view.LabelBrush.Clone();
			_doc.HorizontalAlignment = (StringAlignment)_horizontalAlignmentChoices.FirstSelectedNode.Tag;
			_doc.VerticalAlignment = (StringAlignment)_verticalAlignmentChoices.FirstSelectedNode.Tag;
			_doc.AutomaticAlignment = _view.AutomaticAlignment;
			_doc.Rotation = _view.Rotation;
			_doc.XOffset = _view.XOffset;
			_doc.YOffset = _view.YOffset;
			_doc.BackgroundStyle = _view.Background;

			AltaxoVariant[] varVals;
			if (Serialization.GUIConversion.TryParseMultipleAltaxoVariant(_view.SuppressedLabelsByValue, out varVals))
			{
				_doc.SuppressedLabels.ByValues.Clear();
				foreach (AltaxoVariant v in varVals)
					_doc.SuppressedLabels.ByValues.Add(v);
			}
			else
				return false;

			int[] intVals;
			if (Serialization.GUIConversion.TryParseMultipleInt32(_view.SuppressedLabelsByNumber, out intVals))
			{
				_doc.SuppressedLabels.ByNumbers.Clear();
				foreach (int v in intVals)
					_doc.SuppressedLabels.ByNumbers.Add(v);
			}
			else
				return false;

			_doc.PrefixText = _view.PrefixText;
			_doc.PostfixText = _view.PostfixText;

			var labelSideNode = _labelSides.FirstSelectedNode;
			if (null != labelSideNode)
				_doc.LabelSide = (CSAxisSide?)labelSideNode.Tag;

			_originalDoc.CopyFrom(_doc);

			return true;
		}


		public void EhView_LabelStyleChanged()
		{
			var type = (System.Type)_labelStyles.FirstSelectedNode.Tag;
			if (_doc.LabelFormat.GetType() != type)
				_doc.LabelFormat = (Altaxo.Graph.Gdi.LabelFormatting.ILabelFormatting)Activator.CreateInstance(type);
		}
	}
}
