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

using ICSharpCode.SharpDevelop.Gui;
using System;

namespace Altaxo.Gui.Pads
{
	/// <summary>
	/// Controls the Output window pad which shows the Altaxo text output.
	/// </summary>
	public class OutputWindowController :
		ICSharpCode.SharpDevelop.Gui.IPadContent,
		Altaxo.Main.Services.IOutputService
	{
		private System.Windows.Controls.TextBox _view;

		public OutputWindowController()
		{
			_view = new System.Windows.Controls.TextBox();

			_view.TextWrapping = System.Windows.TextWrapping.NoWrap;
			_view.AcceptsReturn = true;
			_view.AcceptsTab = true;
			_view.VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Visible;
			_view.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Visible;
			_view.FontFamily = new System.Windows.Media.FontFamily("Global Monospace");

			Current.SetOutputService(this);
		}

		#region IPadContent Members

		public object Control
		{
			get
			{
				return this._view;
			}
		}

		public object InitiallyFocusedControl
		{
			get
			{
				return null;
			}
		}

		#endregion IPadContent Members

		#region IDisposable Members

		public void Dispose()
		{
			if (_view != null)
			{
				_view = null;
			}
		}

		#endregion IDisposable Members

		#region IOutputService Members

		private void Write_Unsynchronized(string text)
		{
			_view.AppendText(text);

			if (!_view.IsVisible || _view.Parent == null)
			{
				ICSharpCode.SharpDevelop.Gui.IWorkbenchWindow ww = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow;

				WorkbenchSingleton.Workbench.GetPad(this.GetType())?.BringPadToFront();

				ww?.SelectWindow();
			}
		}

		public void Write(string text)
		{
			Current.Gui.Execute(Write_Unsynchronized, text);
		}

		public void WriteLine()
		{
			Write(System.Environment.NewLine);
		}

		public void WriteLine(string text)
		{
			Write(text + System.Environment.NewLine);
		}

		public void WriteLine(string format, params object[] args)
		{
			Write(string.Format(format, args) + System.Environment.NewLine);
		}

		public void WriteLine(System.IFormatProvider provider, string format, params object[] args)
		{
			Write(string.Format(provider, format, args) + System.Environment.NewLine);
		}

		public void Write(string format, params object[] args)
		{
			Write(string.Format(format, args));
		}

		public void Write(System.IFormatProvider provider, string format, params object[] args)
		{
			Write(string.Format(provider, format, args));
		}

		#endregion IOutputService Members
	}
}