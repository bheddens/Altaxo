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

using Altaxo.Data;
using Altaxo.Gui.Worksheet.Viewing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altaxo.Worksheet.Commands
{
	public static class DataSourceCommands
	{
		/// <summary>
		/// Shows the data source editor dialog. After sucessful execution of the dialog, the modified data source is stored back in the <see cref="DataTable"/>, and the data source is requeried.
		/// </summary>
		/// <param name="ctrl">The controller that controls the data table.</param>
		public static void ShowDataSourceEditor(WorksheetController ctrl)
		{
			var table = ctrl.DataTable;
			if (null == table || null == table.DataSource)
				return;

			var dataSource = (Data.IAltaxoTableDataSource)table.DataSource.Clone();

			if (!Current.Gui.ShowDialog(ref dataSource, "Edit data source", false))
				return;

			table.DataSource = dataSource;

			RequeryTableDataSource(ctrl);
		}

		/// <summary>
		/// Requeries the table data source.
		/// </summary>
		/// <param name="ctrl">The controller that controls the data table.</param>
		public static void RequeryTableDataSource(WorksheetController ctrl)
		{
			var table = ctrl.DataTable;
			if (null == table || null == table.DataSource)
				return;

			try
			{
				table.DataSource.FillData(table);
			}
			catch (Exception ex)
			{
				table.Notes.WriteLine("Error during requerying the table data source: {0}", ex.Message);
			}

			if (table.DataSource.ImportOptions.ExecuteTableScriptAfterImport && null != table.TableScript)
			{
				try
				{
					table.TableScript.Execute(table, new Altaxo.Main.Services.DummyBackgroundMonitor(), false);
				}
				catch (Exception ex)
				{
					table.Notes.WriteLine("Error during execution of the table script (after requerying the table data source: {0}", ex.Message);
				}
			}
		}
	}
}