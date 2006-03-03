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
using Altaxo.Calc.Regression.Nonlinear;

namespace Altaxo.Calc.FitFunctions.Relaxation
{
  /// <summary>
  /// Summary description for KohlrauschDecay.
  /// </summary>
  [FitFunctionClass]
  public class KohlrauschDecay : IFitFunction
  {
    
    public KohlrauschDecay()
    {
      //
      // TODO: Add constructor logic here
      //
    }

    public override string ToString()
    {
      return "KohlrauschDecay";
    }


    [FitFunctionCreator("KohlrauschDecay", "Relaxation", 1, 1, 4)]
    [System.ComponentModel.Description("FitFunctions.Relaxation.Kohlrausch.Decay")]
    public static IFitFunction CreateDefault()
    {
      return new KohlrauschDecay();
    }

    
    #region IFitFunction Members

    public int NumberOfIndependentVariables
    {
      get
      {
        return 1;
      }
    }

    public int NumberOfDependentVariables
    {
      get
      {
        return 1;
      }
    }

    public int NumberOfParameters
    {
      get
      {
        return 4;
      }
    }

    public string IndependentVariableName(int i)
    {
      // TODO:  Add KohlrauschDecay.IndependentVariableName implementation
      return "x";
    }

    public string DependentVariableName(int i)
    {
      return "y";
    }

    public string ParameterName(int i)
    {
      return (new string[]{"offset","amplitude","tau","beta"})[i];
    }

    public double DefaultParameterValue(int i)
    {
      switch (i)
      {
        case 0:
          return 0;
        case 1:
          return 1;
        case 2:
          return 1;
        case 3:
          return 1;
      }

      return 0;
    }

    public IVarianceScaling DefaultVarianceScaling(int i)
    {
      return null;
    }

    public void Evaluate(double[] X, double[] P, double[] Y)
    {
      Y[0] = P[0] + P[1]*Math.Exp(-Math.Pow(X[0]/P[2],P[3]));
    }

    #endregion

    #region IFitFunction Members


   
    #endregion
  }



 

}
