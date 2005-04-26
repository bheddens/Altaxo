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
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using Altaxo.Serialization;
using Altaxo.Data;

namespace Altaxo.Graph
{

  public interface IFunctionEvaluationScriptText : IScriptText
  {
    /// <summary>
    /// Executes the script. If no instance of the script object exists, a error message will be stored and the return value is false.
    /// If the script object exists, the function "IsRowIncluded" will be called for every row in the source tables data column collection.
    /// If this function returns true, the corresponding row will be copyied to a new data table.
    /// </summary>
    /// <param name="myTable">The data table this script is working on.</param>
    /// <returns>True if executed without exceptions, otherwise false.</returns>
    /// <remarks>If exceptions were thrown during execution, the exception messages are stored
    /// inside the column script and can be recalled by the Errors property.</remarks>
    double EvaluateFunctionValue(double x);
  }
 
  /// <summary>
  /// Holds the text, the module (=executable), and some properties of a property column script. 
  /// </summary>
 
  public class FunctionEvaluationScript : AbstractScript, IFunctionEvaluationScriptText
  {
    #region Serialization

    [Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(Altaxo.Graph.FunctionEvaluationScript),0)]
      public new class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
    {
      public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
      {
        Altaxo.Data.AbstractScript s = (Altaxo.Data.AbstractScript)obj;
    
        info.AddBaseValueEmbedded(s,typeof(Altaxo.Data.AbstractScript));
      }
      public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {
        Altaxo.Graph.FunctionEvaluationScript s = null!=o ? (Altaxo.Graph.FunctionEvaluationScript)o : new Altaxo.Graph.FunctionEvaluationScript();
        
        // deserialize the base class
        info.GetBaseValueEmbedded(s,typeof(Altaxo.Data.AbstractScript),parent);
        
        return s;
      }
    }

  
    #endregion


    /// <summary>
    /// Creates an empty script.
    /// </summary>
    public FunctionEvaluationScript()
    {
    }

    /// <summary>
    /// Creates a column script as a copy from another script.
    /// </summary>
    /// <param name="b">The script to copy from.</param>
    public FunctionEvaluationScript(FunctionEvaluationScript b)
      : base(b)
    {
    }

    /// <summary>
    /// Gives the type of the script object (full name), which is created after successfull compilation.
    /// </summary>
    public override string ScriptObjectType
    {
      get { return "Altaxo.Calc.FunctionEvaluationScript"; }
    }

    /// <summary>
    /// Gets the code header, i.e. the leading script text. It depends on the ScriptStyle.
    /// </summary>
    public override string CodeHeader
    {
      get
      {
        return
          "using System;\r\n" + 
          "using Altaxo;\r\n" + 
          "using Altaxo.Calc;\r\n" + 
          "using Altaxo.Data;\r\n" + 
          "namespace Altaxo.Calc\r\n" + 
          "{\r\n" + 
          "\tpublic class FunctionEvaluationScript : Altaxo.Calc.FunctionEvaluationScriptBase\r\n" +
          "\t{\r\n"+
          "\t\tpublic override double EvaluateFunctionValue(double x)\r\n" +
          "\t\t{\r\n"; 
      }
    }

    public override string CodeStart
    {
      get
      {
        return
          "\t\t\t// ----- add your script below this line -----\r\n";
      }
    }

    public override string CodeUserDefault
    {
      get
      {
        return
          "\t\t\t\r\n" + 
          "\t\t\treturn Sin(x);\r\n" +
          "\t\t\t\r\n"
          ;
      }
    }

    public override string CodeEnd
    {
      get
      {
        return
          "\t\t\t// ----- add your script above this line -----\r\n";
      }
    }

    /// <summary>
    /// Get the ending text of the script, dependent on the ScriptStyle.
    /// </summary>
    public override string CodeTail
    {
      get
      {
        return 
          
          "\t\t} // method\r\n" +
          "\t} // class\r\n" + 
          "} //namespace\r\n";
      }
    }



    /// <summary>
    /// Clones the script.
    /// </summary>
    /// <returns>The cloned object.</returns>
    public override object Clone()
    {
      return new Altaxo.Graph.FunctionEvaluationScript(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public double EvaluateFunctionValue(double x)
    {
      if(null==m_ScriptObject)
      {
        m_Errors = new string[1]{"Script Object is null"};
        return double.NaN;
      }

      try
      {
        return ((Altaxo.Calc.FunctionEvaluationScriptBase)m_ScriptObject).EvaluateFunctionValue(x);
      }
      catch(Exception ex)
      {
        return double.NaN;
      }
    }
  } // end of class PropertyColumnScript
}
