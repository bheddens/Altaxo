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
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Altaxo.Graph.Gdi.LabelFormatting;

namespace Altaxo.Gui.Graph.LabelFormatting
{
	public interface INumericLabelFormattingScientificView
	{
		bool ShowExponentAlways { get; set; }
	}

	[UserControllerForObject(typeof(NumericLabelFormattingScientific))]
	[ExpectedTypeOfView(typeof(INumericLabelFormattingScientificView))]
	public class NumericLabelFormattingScientificController : MVCANControllerBase<NumericLabelFormattingScientific, INumericLabelFormattingScientificView>
	{
		protected override void Initialize(bool initData)
		{
			if (null != _view)
			{
				_view.ShowExponentAlways = _doc.ShowExponentAlways;
			}
		}

		public override bool Apply()
		{
			_doc.ShowExponentAlways = _view.ShowExponentAlways;
			if(_useDocumentCopy)
				CopyHelper.Copy(ref _originalDoc, _doc);
			return true;
		}
	}
}
