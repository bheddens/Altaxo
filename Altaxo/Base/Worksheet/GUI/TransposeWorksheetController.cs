using System;

namespace Altaxo.Worksheet.GUI
{
  /// <summary>
  /// Summary description for TransposeWorksheetController.
  /// </summary>
  public class TransposeWorksheetController : Altaxo.Main.GUI.IApplyController
  {
    Altaxo.Data.DataTable _table;
    TransposeWorksheetControl _view;

    public TransposeWorksheetController(Altaxo.Data.DataTable table, TransposeWorksheetControl view)
    {
      _table = table;
      _view = view;
      
    }
    #region IApplyController Members

    bool IsTransposePossible(int numMovedDataColumns, ref int indexDifferentColumn)
    {
      if(numMovedDataColumns>=_table.DataColumnCount)
        return true;

      Altaxo.Data.DataColumn masterColumn = _table[numMovedDataColumns];

      for(int i=0;i<_table.DataColumnCount;i++)
      {
        if(_table[i].GetType()!=masterColumn.GetType())
        {
          indexDifferentColumn = i;
          return false;
        }
      }
      return true;
    }

    public bool Apply()
    {
      
      int datacols = Math.Min(_table.DataColumnCount,_view.DataColumnsMoveToPropertyColumns);
      int propcols = Math.Min(_table.PropertyColumnCount, _view.PropertyColumnsMoveToDataColumns);

      // test if the transpose is possible
      int indexDifferentColumn = 0;
      if(!IsTransposePossible(datacols,ref indexDifferentColumn))
      {
        string message = string.Format("The columns to transpose have not all the same type. The type of column[{0}] ({1}) differs from the type of column[{2}] ({3}). Continue anyway?",
          indexDifferentColumn,
          _table[indexDifferentColumn].GetType(),
          datacols,
          _table[datacols].GetType());

        System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show(Current.MainWindow,message,"Attention",
          System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Exclamation);
      
        if(result==System.Windows.Forms.DialogResult.No)
          return false;
      }

      
      string error = _table.Transpose(datacols,propcols);
      if(error!=null)
      {
        System.Windows.Forms.MessageBox.Show(Current.MainWindow,error,"An error has occured",
          System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
      }


      return true;
    }

    #endregion
  }
}
