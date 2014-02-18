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
using Altaxo.Serialization.Ascii;
using Altaxo.Settings;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Altaxo.Gui.Settings
{
	public class AsciiAnalysisSettingsOptionPanel : OptionPanelBase<Altaxo.Gui.Common.ConditionalDocumentControllerWithDisabledView<AsciiDocumentAnalysisOptions>>
	{
		public override void Initialize(object optionPanelOwner)
		{
			AsciiDocumentAnalysisOptions userDoc = null;
			AsciiDocumentAnalysisOptions sysDoc = null;

			Current.PropertyService.UserSettings.TryGetValue(AsciiDocumentAnalysisOptions.PropertyKeyAsciiDocumentAnalysisOptions, out userDoc);
			sysDoc = Current.PropertyService.GetValue<AsciiDocumentAnalysisOptions>(AsciiDocumentAnalysisOptions.PropertyKeyAsciiDocumentAnalysisOptions, Altaxo.Main.Services.RuntimePropertyKind.ApplicationAndBuiltin);
			if (null == sysDoc)
				throw new ApplicationException("AsciiDocumentAnalysisOptions not properly registered with builtin settings!");

			_controller = new Altaxo.Gui.Common.ConditionalDocumentControllerWithDisabledView<AsciiDocumentAnalysisOptions>(() => sysDoc.Clone(), () => sysDoc);
			_controller.EnablingText = "Override system settings";
			_controller.InitializeDocument(new object[] { userDoc, sysDoc });
		}

		protected override void ProcessControllerResult()
		{
			if (null != _controller.ModelObject)
			{
				var userDoc = (AsciiDocumentAnalysisOptions)_controller.ModelObject;
				Current.PropertyService.UserSettings.SetValue(AsciiDocumentAnalysisOptions.PropertyKeyAsciiDocumentAnalysisOptions, userDoc);
			}
			else
			{
				Current.PropertyService.UserSettings.RemoveValue(AsciiDocumentAnalysisOptions.PropertyKeyAsciiDocumentAnalysisOptions);
			}
		}
	}
}