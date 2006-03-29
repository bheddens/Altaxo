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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Altaxo.Main.GUI;

namespace Altaxo.Gui.Graph
{
  /// <summary>
  /// Summary description for XYGridStyleControl.
  /// </summary>
  [UserControlForController(typeof(IXYGridStyleViewEventSink))]
  public class XYGridStyleControl : System.Windows.Forms.UserControl, IXYGridStyleView
  {
    private System.Windows.Forms.CheckBox _cbEnable;
    private System.Windows.Forms.CheckBox _cbShowMinor;
    private System.Windows.Forms.CheckBox _cbShowZeroOnly;
    private Altaxo.Gui.Common.Drawing.ColorTypeThicknessPenControl _majorStyle;
    private Altaxo.Gui.Common.Drawing.ColorTypeThicknessPenControl _minorStyle;
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public XYGridStyleControl()
    {
      // This call is required by the Windows.Forms Form Designer.
      InitializeComponent();

      // TODO: Add any initialization after the InitializeComponent call

    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing )
    {
      if( disposing )
      {
        if(components != null)
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

    #region Component Designer generated code
    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this._majorStyle = new Altaxo.Gui.Common.Drawing.ColorTypeThicknessPenControl();
      this._minorStyle = new Altaxo.Gui.Common.Drawing.ColorTypeThicknessPenControl();
      this._cbEnable = new System.Windows.Forms.CheckBox();
      this._cbShowMinor = new System.Windows.Forms.CheckBox();
      this._cbShowZeroOnly = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // _majorStyle
      // 
      this._majorStyle.Controller = null;
      this._majorStyle.Location = new System.Drawing.Point(0, 64);
      this._majorStyle.Name = "_majorStyle";
      this._majorStyle.Size = new System.Drawing.Size(184, 96);
      this._majorStyle.TabIndex = 0;
      // 
      // _minorStyle
      // 
      this._minorStyle.Controller = null;
      this._minorStyle.Location = new System.Drawing.Point(200, 64);
      this._minorStyle.Name = "_minorStyle";
      this._minorStyle.Size = new System.Drawing.Size(184, 96);
      this._minorStyle.TabIndex = 1;
      // 
      // _cbEnable
      // 
      this._cbEnable.Location = new System.Drawing.Point(0, 0);
      this._cbEnable.Name = "_cbEnable";
      this._cbEnable.TabIndex = 2;
      this._cbEnable.Text = "Enable";
      this._cbEnable.CheckedChanged += new System.EventHandler(this._cbEnable_CheckedChanged);
      // 
      // _cbShowMinor
      // 
      this._cbShowMinor.Location = new System.Drawing.Point(264, 40);
      this._cbShowMinor.Name = "_cbShowMinor";
      this._cbShowMinor.Size = new System.Drawing.Size(112, 24);
      this._cbShowMinor.TabIndex = 3;
      this._cbShowMinor.Text = "Show minor grid";
      this._cbShowMinor.CheckedChanged += new System.EventHandler(this._cbShowMinor_CheckedChanged);
      // 
      // _cbShowZeroOnly
      // 
      this._cbShowZeroOnly.Location = new System.Drawing.Point(64, 40);
      this._cbShowZeroOnly.Name = "_cbShowZeroOnly";
      this._cbShowZeroOnly.TabIndex = 4;
      this._cbShowZeroOnly.Text = "At zero only";
      this._cbShowZeroOnly.CheckedChanged += new System.EventHandler(this._cbShowZeroOnly_CheckedChanged);
      // 
      // XYGridStyleControl
      // 
      this.Controls.Add(this._cbShowZeroOnly);
      this.Controls.Add(this._cbShowMinor);
      this.Controls.Add(this._cbEnable);
      this.Controls.Add(this._minorStyle);
      this.Controls.Add(this._majorStyle);
      this.Name = "XYGridStyleControl";
      this.Size = new System.Drawing.Size(392, 168);
      this.ResumeLayout(false);

    }
    #endregion

    #region IXYGridStyleView Members

    IXYGridStyleViewEventSink _controller;
    public IXYGridStyleViewEventSink Controller
    {
      get
      {
        
        return _controller;
      }
      set
      {
        _controller = value;
      }
    }

    public void InitializeMajorGridStyle(Altaxo.Gui.Common.Drawing.IColorTypeThicknessPenController controller)
    {
      controller.ViewObject = this._majorStyle;
    }

    public void InitializeMinorGridStyle(Altaxo.Gui.Common.Drawing.IColorTypeThicknessPenController controller)
    {
      controller.ViewObject = this._minorStyle;
    }

    public void InitializeShowGrid(bool value)
    {
      this._cbEnable.Checked = value;
    }

    public void InitializeShowMinorGrid(bool value)
    {
      this._cbShowMinor.Checked = value;
    }

    public void InitializeShowZeroOnly(bool value)
    {
      this._cbShowZeroOnly.Checked = value;
    }

    public void InitializeElementEnabling(bool majorstyle, bool minorstyle, bool showminor, bool showzeroonly)
    {
      this._majorStyle.Enabled = majorstyle;
      this._minorStyle.Enabled = minorstyle;
      this._cbShowMinor.Enabled = showminor;
      this._cbShowZeroOnly.Enabled = showzeroonly;
    }

    #endregion

    private void _cbEnable_CheckedChanged(object sender, System.EventArgs e)
    {
      if(_controller!=null)
        _controller.EhView_ShowGridChanged(this._cbEnable.Checked);
    
    }

    private void _cbShowZeroOnly_CheckedChanged(object sender, System.EventArgs e)
    {
      if(_controller!=null)
        _controller.EhView_ShowZeroOnly(this._cbShowZeroOnly.Checked);
    
    }

    private void _cbShowMinor_CheckedChanged(object sender, System.EventArgs e)
    {
      if(_controller!=null)
        _controller.EhView_ShowMinorGridChanged(this._cbShowMinor.Checked);
    
    }
  }
}