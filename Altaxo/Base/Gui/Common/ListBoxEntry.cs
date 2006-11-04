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

namespace Altaxo.Gui.Common
{
  public class ListBoxEntry
  {
    protected string m_DisplayText;
    protected object m_Tag;

    public ListBoxEntry(string text, object tag)
    {
      this.DisplayText = text;
      this.Tag         = tag;
    }

    public string DisplayText
    {
      get { return m_DisplayText; }
      set { m_DisplayText = value; }
    }

    public object Tag
    {
      get { return m_Tag; }
      set { m_Tag = value; }
    }

    public override string ToString()
    {
      return m_DisplayText;
    }

      
  }
}