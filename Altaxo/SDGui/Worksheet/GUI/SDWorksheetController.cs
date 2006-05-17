#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2005 Dr. Dirk Lellinger
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
using System.Windows.Forms;
using System.Collections.Generic;
using Altaxo;
using Altaxo.Main;
using Altaxo.Main.GUI;
using Altaxo.Worksheet;
using Altaxo.Worksheet.GUI;

using ICSharpCode.Core;

namespace Altaxo.Worksheet.GUI
{
  /// <summary>
  /// Summary description for SDWorksheetController.
  /// </summary>
  public class SDWorksheetController : Altaxo.Worksheet.GUI.WorksheetController,
    ICSharpCode.SharpDevelop.Gui.IViewContent,  
    ICSharpCode.SharpDevelop.Gui.IEditable,
    ICSharpCode.SharpDevelop.Gui.IClipboardHandler
  {
    protected ICSharpCode.SharpDevelop.Gui.IWorkbenchWindow workbenchWindow;
    public event EventHandler WorkbenchWindowChanged;
    protected virtual void OnWorkbenchWindowChanged(EventArgs e)
    {
      if (WorkbenchWindowChanged != null)
      {
        WorkbenchWindowChanged(this, e);
      }
    }

    #region Serialization
    [Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(SDWorksheetController),0)]
      public new class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
    {
      public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
      {
        info.AddBaseValueEmbedded(obj,typeof(SDWorksheetController).BaseType);
      }
      public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {
        SDWorksheetController s = null!=o ? (SDWorksheetController)o : new SDWorksheetController(null,true);
        info.GetBaseValueEmbedded(s,typeof(SDWorksheetController).BaseType,parent);
        return s;
      }
    }
    #endregion

    #region Constructors


    public SDWorksheetController(Altaxo.Worksheet.WorksheetLayout layout)
      : this(layout,false)
    {
    }
  
    /// <summary>
    /// Creates a WorksheetController which shows the table data into the 
    /// View <paramref name="view"/>.
    /// </summary>
    /// <param name="layout">The worksheet layout.</param>
    /// <param name="bDeserializationConstructor">If true, no layout has to be provided, since this is used as deserialization constructor.</param>
    protected SDWorksheetController(Altaxo.Worksheet.WorksheetLayout layout, bool bDeserializationConstructor)
      :
      base(layout, bDeserializationConstructor)
    {
    }

    #endregion // Constructors

    #region Context menu handlers
    protected override void OnRightClickDataColumnHeader(ClickedCellInfo clickedCell)
    {
      if(!(this.SelectedDataColumns.Contains(clickedCell.Column)))
      {
        this.ClearAllSelections();
        this.SelectedDataColumns.Add(clickedCell.Column);
        this.m_View.TableAreaInvalidate();
      }
      ContextMenuStrip mnu = MenuService.CreateContextMenu(this, "/Altaxo/Views/Worksheet/DataColumnHeader/ContextMenu");
      mnu.Show(this.Control,clickedCell.MousePositionFirstDown);
    }

    #endregion

    #region ICSharpCode.SharpDevelop.Gui

    public void Dispose()
    {
      workbenchWindow = null;
    }

    /// <summary>
    /// This is the Windows.Forms control for the view.
    /// </summary>
    public System.Windows.Forms.Control Control 
    {
      get { return this.View as System.Windows.Forms.Control; }
    }

    /// <summary>
    /// The workbench window in which this view is displayed.
    /// </summary>
    public ICSharpCode.SharpDevelop.Gui.IWorkbenchWindow  WorkbenchWindow 
    {
      get
      {
        return this.workbenchWindow;
      }
      set 
      { 
        this.workbenchWindow = value;
        OnWorkbenchWindowChanged(EventArgs.Empty);
      }
    }
    
    /// <summary>
    /// A generic name for the file, when it does have no file name
    /// (e.g. newly created files)
    /// </summary>
    public string UntitledName 
    {
      get { return "UntitledTable"; }
      set {}
    }
    
    
    /// <summary>
    /// Returns the file name (if any) assigned to this view.
    /// </summary>
    public string FileName 
    {
      get 
      { 
        return this.Doc.Name; 
      }
      set 
      {
      }
    }
    
       
   

    /// <summary>
    /// The text on the tab page when more than one view content
    /// is attached to a single window.
    /// </summary>
    public string TabPageText 
    {
      get { return TitleName; }
    }

    /// <summary>
    /// If this property returns true the view is untitled.
    /// </summary>
    public bool IsUntitled 
    {
      get { return string.IsNullOrEmpty(this.Doc.Name); }
    }
    
    /// <summary>
    /// If this property returns true the content has changed since
    /// the last load/save operation.
    /// </summary>
    public bool IsDirty 
    {
      get { return false; }
      set {}
    }
    
    /// <summary>
    /// If this property returns true the content could not be altered.
    /// </summary>
    public bool IsReadOnly 
    {
      get { return false; }
    }
    
    /// <summary>
    /// If this property returns true the content can't be written.
    /// </summary>
    public bool IsViewOnly 
    {
      get { return true; }
    }

    /// <summary>
    /// Is called when the window is switched to.
    /// -> Inside the tab (Called before Selected())
    /// -> Inside the workbench.
    /// </summary>
    public void SwitchedTo()
    {
    }

    /// <summary>
    /// Is called when the view content is selected inside the window
    /// tab. NOT when the windows is selected.
    /// </summary>
    public void Selected()
    {
    }
    
    /// <summary>
    /// Is called when the view content is deselected inside the window
    /// tab before the other window is selected. NOT when the windows is deselected.
    /// </summary>
    public void Deselected()
    {
    }

    public void Deselecting()
    {
    }

    /// <summary>
    /// Reinitializes the content. (Re-initializes all add-in tree stuff)
    /// and redraws the content. Call this not directly unless you know
    /// what you do.
    /// </summary>
    public void RedrawContent()
    {
    }
    
    /// <summary>
    /// Saves this content to the last load/save location.
    /// </summary>
    public void Save()
    {
    }

    
    /// <summary>
    /// Saves the content to the location <code>fileName</code>
    /// </summary>
    public void Save(string fileName)
    {
    }
    
    /// <summary>
    /// Loads the content from the location <code>fileName</code>
    /// </summary>
    public void Load(string fileName)
    {
    }

    protected virtual void OnBeforeSave(EventArgs e)
    {
      if (BeforeSave != null) 
      {
        BeforeSave(this, e);
      }
    }
    
    /// <summary>
    /// If this property is true, content will be created in the tab page
    /// </summary>
    public bool CreateAsSubViewContent 
    {
      get { return false; }
    }
  
   
    
    /// <summary>
    /// Is called when the content is changed after a save/load operation
    /// and this signals that changes could be saved.
    /// </summary>
    public event EventHandler DirtyChanged;

    public event EventHandler BeforeSave;

    public event EventHandler     Saving;

    public event ICSharpCode.SharpDevelop.Gui.SaveEventHandler Saved;

    #endregion
  
    #region ICSharpCode.SharpDevelop.Gui.IEditable
    
    public ICSharpCode.SharpDevelop.Gui.IClipboardHandler ClipboardHandler 
    {
      get { return this; }
    }
    
    public string Text 
    {
      get { return null; }
      set {}
    }
    
    public bool EnableUndo 
    {
      get { return false; }
    }
    
    public bool EnableRedo 
    {
      get{ return false; }
    }


    public void Undo()
    {
    }
    public void Redo()
    {
    }
    #endregion

    #region ICSharpCode.SharpDevelop.Gui.IClipboardHandler
    
    public bool EnableCut 
    {
      get { return this.m_CellEdit_IsArmed; }
    }
    public bool EnableCopy 
    {
      get { return true; }
    }
    public bool EnablePaste 
    {
      get { return true; }
    }
    public bool EnableDelete 
    {
      get { return true; }
    }
    public bool EnableSelectAll 
    {
      get { return true; }
    }
    
    public void Cut()
    {
      if(this.m_CellEdit_IsArmed)
      {
        this.m_CellEditControl.Cut();
      }
      else if(this.AreColumnsOrRowsSelected)
      {
        // Copy the selected Columns to the clipboard
        Commands.EditCommands.CopyToClipboard(this);
      }
    }

    public void Copy()
    {
      if(this.m_CellEdit_IsArmed)
      {
        this.m_CellEditControl.Copy();
      }
      else if(this.AreColumnsOrRowsSelected)
      {
        // Copy the selected Columns to the clipboard
        Commands.EditCommands.CopyToClipboard(this);
      }
    
    }
    public void Paste()
    {
      if(this.m_CellEdit_IsArmed)
      {
        this.m_CellEditControl.Paste();
      }
      else
      {
        Commands.EditCommands.PasteFromClipboard(this);
      }
    }
    public void Delete()
    {
      if(this.m_CellEdit_IsArmed)
      {
        this.m_CellEditControl.Clear();
      }
      else if(this.AreColumnsOrRowsSelected)
      {
        this.RemoveSelected();
      }
      else
      {
        // nothing is selected, we assume that the user wants to delete the worksheet itself
        Current.ProjectService.DeleteTable(this.DataTable,false);
      }
    }
    public void SelectAll()
    {
      if(this.DataTable.DataColumns.ColumnCount>0)
      {
        this.SelectedDataColumns.Select(0,false,false);
        this.SelectedDataColumns.Select(this.DataTable.DataColumns.ColumnCount-1,true,false);
        if(View!=null)
          View.TableAreaInvalidate();
      }
    }
    #endregion



    #region IViewContent Members


    public System.Collections.Generic.List<ICSharpCode.SharpDevelop.Gui.ISecondaryViewContent> SecondaryViewContents
    {
      get 
      {
        return new List<ICSharpCode.SharpDevelop.Gui.ISecondaryViewContent>(); // is empty
      }
    }

    #endregion

   
   
  }
}
