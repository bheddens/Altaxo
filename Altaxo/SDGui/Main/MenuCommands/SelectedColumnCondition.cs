#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2004 Dr. Dirk Lellinger
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
using System.Collections;
using System.Xml;


using ICSharpCode.Core.AddIns.Conditions;
using ICSharpCode.Core.Services;

using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.SharpDevelop.Services;
using ICSharpCode.SharpDevelop.Internal.Project;

namespace Altaxo.Worksheet.Commands
{
  [ConditionAttribute()]
  public class SelectedDataCondition : AbstractCondition
  {
    [ICSharpCode.Core.AddIns.XmlMemberAttribute("selecteddatacolumns", IsRequired = true)]
    string selectedData;
    
    public string SelectedData 
    {
      get 
      {
        return selectedData;
      }
      set 
      {
        selectedData = value;
      }
    }
    
    public override bool IsValid(object owner)
    {
      if(Current.Workbench.ActiveViewContent==null)
        return false;
      if(!(Current.Workbench.ActiveViewContent is Altaxo.Worksheet.GUI.WorksheetController))
        return false;

      Altaxo.Worksheet.GUI.WorksheetController ctrl 
        = Current.Workbench.ActiveViewContent as Altaxo.Worksheet.GUI.WorksheetController; 

      return ctrl.SelectedColumns.Count>=1;
    }
  }
}