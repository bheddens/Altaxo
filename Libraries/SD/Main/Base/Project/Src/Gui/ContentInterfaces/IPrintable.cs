﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision: 4547 $</version>
// </file>

using System;
using System.Drawing.Printing;

namespace ICSharpCode.SharpDevelop.Gui
{
	/// <summary>
	/// This interface is meant for Windows-Forms AddIns to preserve the printing functionality as in SharpDevelop 3.0.
	/// It works only for controls inside a <see cref="SDWindowsFormsHost"/>.
	/// WPF AddIns should handle the routed commands 'Print' and 'PrintPreview' instead.
	/// 
	/// If a IViewContent object is from the type IPrintable it signals
	/// that it's contents could be printed to a printer, fax etc.
	/// </summary>
	public interface IPrintable
	{
		/// <summary>
		/// Returns the PrintDocument for this object, see the .NET reference
		/// for more information about printing.
		/// </summary>
		PrintDocument PrintDocument {
			get;
		}
	}
}
