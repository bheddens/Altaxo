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
using Altaxo.Data;

namespace Altaxo.Worksheet.GUI
{
  #region Interfaces
  public interface ITableScriptView
  {
    ITableScriptController Controller {get; set; }
    
    string ScriptText { get; set; }

    int ScriptCursorLocation { set; }

    /// <summary>
    /// Sets the working name of the script. Should be set to a unique name
    /// ending in ".cs" to signal that this is a C# script.
    /// </summary>
    string ScriptName { set; }

    System.Windows.Forms.Form Form    { get ; }

    void ClearCompilerErrors();

    void AddCompilerError(string s);
  }

  public interface ITableScriptController
  {
    void EhView_Execute();
    void EhView_Compile();
    void EhView_Update();
    void EhView_Cancel();
  }


  #endregion

  /// <summary>
  /// Summary description for TableScriptController.
  /// </summary>
  public class TableScriptController : ITableScriptController
  {
    protected Altaxo.Data.DataTable m_DataTable;
    public TableScript m_TableScript;

    protected ITableScriptView m_View;

    public TableScriptController(Altaxo.Data.DataTable dataTable, TableScript tableScript)
    {
      this.m_DataTable = dataTable;

      if(null!=tableScript)
      {
        this.m_TableScript = (TableScript)tableScript.Clone();
      }
      else
      {
        this.m_TableScript = new TableScript();
      }

      SetElements(true);

    }


    protected void SetElements(bool bInit)
    {
      if(bInit)
      {
      }

      if(null!=View)
      {
        View.ScriptText= m_TableScript.ScriptText;
        View.ScriptName = m_TableScript.ScriptName;
        View.ScriptCursorLocation = m_TableScript.UserAreaScriptOffset;
      }
    }

    public ITableScriptView View
    {
      get
      {
        return m_View;
      }
      set
      {
        if(null!=m_View)
          m_View.Controller = null;
        
        m_View = value;

        if(null!=m_View)
        {
          m_View.Controller = this;
          SetElements(false); // set only the view elements, dont't initialize the variables
        }
      }
    }

    public object ViewObject
    {
      get { return View; }
      set { View = value as ITableScriptView; }
    }

    public void EhView_Execute()
    {
      m_TableScript.ScriptText = View.ScriptText;

      View.ClearCompilerErrors();

      bool bSucceeded = m_TableScript.Compile();

      if(!bSucceeded)
      {
        foreach(string s in m_TableScript.Errors)
          View.AddCompilerError(s);

        System.Windows.Forms.MessageBox.Show(View.Form, "There were compilation errors","No success");
        return;
      }

      bSucceeded = m_TableScript.ExecuteWithSuspendedNotifications(m_DataTable);
      if(!bSucceeded)
      {
        foreach(string s in m_TableScript.Errors)
          View.AddCompilerError(s);

        System.Windows.Forms.MessageBox.Show(View.Form, "There were execution errors","No success");
        return;
      }

      this.m_DataTable.TableScript = m_TableScript;
      View.Form.DialogResult = System.Windows.Forms.DialogResult.OK;
      View.Form.Close();
    }

    public void EhView_Compile()
    {
      m_TableScript.ScriptText = View.ScriptText;

      View.ClearCompilerErrors();

      bool bSucceeded = m_TableScript.Compile();

      if(!bSucceeded)
      {
        foreach(string s in m_TableScript.Errors)
          View.AddCompilerError(s);

        System.Windows.Forms.MessageBox.Show(View.Form, "There were compilation errors","No success");
        return;
      }

    }

    public void EhView_Update()
    {
      m_TableScript.ScriptText = View.ScriptText;
      this.m_DataTable.TableScript = m_TableScript;
      this.View.Form.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.View.Form.Close();
    }

    public void EhView_Cancel()
    {
      this.View.Form.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.View.Form.Close();
    }
  }
}