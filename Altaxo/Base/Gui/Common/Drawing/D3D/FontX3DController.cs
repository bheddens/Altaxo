﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2016 Dr. Dirk Lellinger
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

using Altaxo.Drawing;
using Altaxo.Drawing.D3D;
using Altaxo.Graph;
using Altaxo.Graph.Gdi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Altaxo.Gui.Common.Drawing.D3D
{
	public interface IFontX3DView
	{
		System.Drawing.FontFamily SelectedFontFamily { get; set; }

		double SelectedFontSize { get; set; }

		double SelectedFontDepth { get; set; }
	}

	[ExpectedTypeOfView(typeof(IFontX3DView))]
	public class FontX3DController : MVCANControllerEditImmutableDocBase<FontX3D, IFontX3DView>
	{
		public override IEnumerable<ControllerAndSetNullMethod> GetSubControllers()
		{
			yield break;
		}

		protected override void Initialize(bool initData)
		{
			base.Initialize(initData);

			if (initData)
			{
			}
			if (null != _view)
			{
				// fill the font name combobox with all fonts
				_view.SelectedFontFamily = GdiFontManager.GdiFontFamily(_doc.Font);
				_view.SelectedFontSize = _doc.Size;
				_view.SelectedFontDepth = _doc.Depth;
			}
		}

		private void ApplyFontFamily()
		{
			FontFamily ff = _view.SelectedFontFamily;
			// make sure that regular style is available
			if (ff.IsStyleAvailable(FontStyle.Regular))
				this._doc = _doc.WithFamily(ff.Name).WithStyle(FontXStyle.Regular);
			else if (ff.IsStyleAvailable(FontStyle.Bold))
				this._doc = _doc.WithFamily(ff.Name).WithStyle(FontXStyle.Bold);
			else if (ff.IsStyleAvailable(FontStyle.Italic))
				this._doc = _doc.WithFamily(ff.Name).WithStyle(FontXStyle.Italic);
		}

		private void ApplyFontSize()
		{
			var newSize = _view.SelectedFontSize;
			this._doc = _doc.WithSize(_view.SelectedFontSize);
		}

		public override bool Apply(bool disposeController)
		{
			ApplyFontFamily();
			ApplyFontSize();

			_originalDoc = _doc; // this is safe because FontX is an immutable class

			return ApplyEnd(true, disposeController);
		}
	}
}