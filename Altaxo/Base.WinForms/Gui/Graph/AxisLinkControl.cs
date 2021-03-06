#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2007 Dr. Dirk Lellinger
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

using Altaxo.Graph.Scales;

namespace Altaxo.Gui.Graph
{
  /// <summary>
  /// Summary description for LinkAxisControl.
  /// </summary>
  public class AxisLinkControl : System.Windows.Forms.UserControl, IAxisLinkView
  {
    private System.Windows.Forms.Label label26;
    private System.Windows.Forms.Label label25;
    private System.Windows.Forms.Label label24;
    private System.Windows.Forms.TextBox m_edLinkAxisEndB;
    private System.Windows.Forms.TextBox m_edLinkAxisEndA;
    private System.Windows.Forms.TextBox m_edLinkAxisOrgB;
    private System.Windows.Forms.TextBox m_edLinkAxisOrgA;
    private System.Windows.Forms.Label label23;
    private System.Windows.Forms.RadioButton m_rbLinkAxisCustom;
    private System.Windows.Forms.RadioButton m_rbLinkAxisStraight;
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public AxisLinkControl()
    {
      // This call is required by the Windows.Forms Form Designer.
      InitializeComponent();


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
      this.label26 = new System.Windows.Forms.Label();
      this.label25 = new System.Windows.Forms.Label();
      this.label24 = new System.Windows.Forms.Label();
      this.m_edLinkAxisEndB = new System.Windows.Forms.TextBox();
      this.m_edLinkAxisEndA = new System.Windows.Forms.TextBox();
      this.m_edLinkAxisOrgB = new System.Windows.Forms.TextBox();
      this.m_edLinkAxisOrgA = new System.Windows.Forms.TextBox();
      this.label23 = new System.Windows.Forms.Label();
      this.m_rbLinkAxisCustom = new System.Windows.Forms.RadioButton();
      this.m_rbLinkAxisStraight = new System.Windows.Forms.RadioButton();
      this.SuspendLayout();
      // 
      // label26
      // 
      this.label26.Location = new System.Drawing.Point(96, 57);
      this.label26.Name = "label26";
      this.label26.Size = new System.Drawing.Size(16, 13);
      this.label26.TabIndex = 21;
      this.label26.Text = "b";
      this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label25
      // 
      this.label25.Location = new System.Drawing.Point(48, 57);
      this.label25.Name = "label25";
      this.label25.Size = new System.Drawing.Size(16, 13);
      this.label25.TabIndex = 20;
      this.label25.Text = "a";
      this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label24
      // 
      this.label24.Location = new System.Drawing.Point(3, 96);
      this.label24.Name = "label24";
      this.label24.Size = new System.Drawing.Size(29, 16);
      this.label24.TabIndex = 19;
      this.label24.Text = "End";
      this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // m_edLinkAxisEndB
      // 
      this.m_edLinkAxisEndB.Location = new System.Drawing.Point(88, 96);
      this.m_edLinkAxisEndB.Name = "m_edLinkAxisEndB";
      this.m_edLinkAxisEndB.Size = new System.Drawing.Size(40, 20);
      this.m_edLinkAxisEndB.TabIndex = 18;
      this.m_edLinkAxisEndB.Validating += new System.ComponentModel.CancelEventHandler(this.EhEndB_Validating);
      // 
      // m_edLinkAxisEndA
      // 
      this.m_edLinkAxisEndA.Location = new System.Drawing.Point(40, 96);
      this.m_edLinkAxisEndA.Name = "m_edLinkAxisEndA";
      this.m_edLinkAxisEndA.Size = new System.Drawing.Size(40, 20);
      this.m_edLinkAxisEndA.TabIndex = 17;
      this.m_edLinkAxisEndA.Validating += new System.ComponentModel.CancelEventHandler(this.EhEndA_Validating);
      // 
      // m_edLinkAxisOrgB
      // 
      this.m_edLinkAxisOrgB.Location = new System.Drawing.Point(88, 72);
      this.m_edLinkAxisOrgB.Name = "m_edLinkAxisOrgB";
      this.m_edLinkAxisOrgB.Size = new System.Drawing.Size(40, 20);
      this.m_edLinkAxisOrgB.TabIndex = 16;
      this.m_edLinkAxisOrgB.Validating += new System.ComponentModel.CancelEventHandler(this.EhOrgB_Validating);
      // 
      // m_edLinkAxisOrgA
      // 
      this.m_edLinkAxisOrgA.Location = new System.Drawing.Point(40, 72);
      this.m_edLinkAxisOrgA.Name = "m_edLinkAxisOrgA";
      this.m_edLinkAxisOrgA.Size = new System.Drawing.Size(40, 20);
      this.m_edLinkAxisOrgA.TabIndex = 15;
      this.m_edLinkAxisOrgA.Validating += new System.ComponentModel.CancelEventHandler(this.EhOrgA_Validating);
      // 
      // label23
      // 
      this.label23.Location = new System.Drawing.Point(3, 72);
      this.label23.Name = "label23";
      this.label23.Size = new System.Drawing.Size(29, 16);
      this.label23.TabIndex = 14;
      this.label23.Text = "Org";
      this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // m_rbLinkAxisCustom
      // 
      this.m_rbLinkAxisCustom.Location = new System.Drawing.Point(16, 38);
      this.m_rbLinkAxisCustom.Name = "m_rbLinkAxisCustom";
      this.m_rbLinkAxisCustom.Size = new System.Drawing.Size(104, 16);
      this.m_rbLinkAxisCustom.TabIndex = 13;
      this.m_rbLinkAxisCustom.Text = "Custom (a+bx)";
      this.m_rbLinkAxisCustom.CheckedChanged += new System.EventHandler(this.EhLinkCustom_CheckedChanged);
      // 
      // m_rbLinkAxisStraight
      // 
      this.m_rbLinkAxisStraight.Location = new System.Drawing.Point(16, 19);
      this.m_rbLinkAxisStraight.Name = "m_rbLinkAxisStraight";
      this.m_rbLinkAxisStraight.Size = new System.Drawing.Size(104, 16);
      this.m_rbLinkAxisStraight.TabIndex = 12;
      this.m_rbLinkAxisStraight.Text = "Straight (1:1)";
      this.m_rbLinkAxisStraight.CheckedChanged += new System.EventHandler(this.EhLinkStraight_CheckedChanged);
     
      // 
      // AxisLinkControl
      // 
      this.Controls.Add(this.label26);
      this.Controls.Add(this.label25);
      this.Controls.Add(this.label24);
      this.Controls.Add(this.m_edLinkAxisEndB);
      this.Controls.Add(this.m_edLinkAxisEndA);
      this.Controls.Add(this.m_edLinkAxisOrgB);
      this.Controls.Add(this.m_edLinkAxisOrgA);
      this.Controls.Add(this.label23);
      this.Controls.Add(this.m_rbLinkAxisCustom);
      this.Controls.Add(this.m_rbLinkAxisStraight);
      this.Name = "AxisLinkControl";
      this.Size = new System.Drawing.Size(128, 120);
      this.ResumeLayout(false);
      this.PerformLayout();

    }
    #endregion

  

    private void EhLinkStraight_CheckedChanged(object sender, System.EventArgs e)
    {
      if(null!=LinkType_Changed && this.m_rbLinkAxisStraight.Checked==true)
        LinkType_Changed(true);
    }

    private void EhLinkCustom_CheckedChanged(object sender, System.EventArgs e)
    {
      if(null!=LinkType_Changed && this.m_rbLinkAxisCustom.Checked==true)
        LinkType_Changed(false);
    }

    private void EhOrgA_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if(null!=OrgA_Validating)
      {
				var ev = new ValidationEventArgs<string>(((TextBox)sender).Text, System.Globalization.CultureInfo.CurrentUICulture);
				OrgA_Validating(ev);
				e.Cancel = ev.HasErrors;
      }
    }

    private void EhOrgB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if(null!=OrgB_Validating)
      {
				var ev = new ValidationEventArgs<string>(((TextBox)sender).Text, System.Globalization.CultureInfo.CurrentUICulture);
				OrgB_Validating(ev);
				e.Cancel = ev.HasErrors;
      }
    
    }

    private void EhEndA_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
       if(null!=EndA_Validating)
      {
				var ev = new ValidationEventArgs<string>(((TextBox)sender).Text, System.Globalization.CultureInfo.CurrentUICulture);
				EndA_Validating(ev);
				e.Cancel = ev.HasErrors;
      }
    }

    private void EhEndB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
			if (null != EndB_Validating)
			{
				var ev = new ValidationEventArgs<string>(((TextBox)sender).Text, System.Globalization.CultureInfo.CurrentUICulture);
				EndB_Validating(ev);
				e.Cancel = ev.HasErrors;
			}
    }
    #region ILinkAxisView Members
  
    void EnableCustom(bool bEnab)
    {
      this.m_edLinkAxisOrgA.Enabled = bEnab;
      this.m_edLinkAxisOrgB.Enabled = bEnab;
      this.m_edLinkAxisEndA.Enabled = bEnab;
      this.m_edLinkAxisEndB.Enabled = bEnab;
    }

    public void LinkType_Initialize(bool isStraight)
    {
       if(isStraight)
			 {
          this.m_rbLinkAxisStraight.Checked = true;
          EnableCustom(false);
			 }
			 else
			 {
          this.m_rbLinkAxisCustom.Checked = true;
          EnableCustom(true);
			 }
      
    }

    public void OrgA_Initialize(string text)
    {
      this.m_edLinkAxisOrgA.Text = text;
    }

    public void OrgB_Initialize(string text)
    {
      this.m_edLinkAxisOrgB.Text = text;
    }

    public void EndA_Initialize(string text)
    {
      this.m_edLinkAxisEndA.Text = text;
    }

    public void EndB_Initialize(string text)
    {
      this.m_edLinkAxisEndB.Text = text;
    }

    public void Enable_OrgAndEnd_Boxes(bool bEnable)
    {
      EnableCustom(bEnable);
    }


    #endregion

  


		public event Action<ValidationEventArgs<string>> OrgA_Validating;

		public event Action<ValidationEventArgs<string>> OrgB_Validating;

		public event Action<ValidationEventArgs<string>> EndA_Validating;

		public event Action<ValidationEventArgs<string>> EndB_Validating;

		public event Action<bool> LinkType_Changed;
	}
}
