using System;

using Altaxo.Serialization;
using Altaxo.Main.GUI;
using Altaxo.Graph.Procedures;

namespace Altaxo.Gui.Graph
{

 

  #region interfaces

  public interface IArrangeLayersView
  {
    IArrangeLayersViewEventSink Controller { get; set; }
    void InitializeRowsColumns(int numRows, int numColumns);
    void InitializeSpacing(double horzSpacing, double vertSpacing);
    void InitializeMargins(double top, double left, double bottom, double right);
  }

  public interface IArrangeLayersViewEventSink
  {
    bool EhNumberOfRowsChanged(string val);
    bool EhNumberOfColumnsChanged(string val);
    bool EhHorizontalSpacingChanged(string val);
    bool EhVerticalSpacingChanged(string val);
    bool EhTopMarginChanged(string val);
    bool EhLeftMarginChanged(string val);
    bool EhBottomMarginChanged(string val);
    bool EhRightMarginChanged(string val);
  }

  #endregion



	/// <summary>
	/// Controller for the <see>ArrangeLayersDocument</see>.
	/// </summary>
	[UserControllerForObject(typeof(ArrangeLayersDocument))]
	public class ArrangeLayersController : IArrangeLayersViewEventSink, Main.GUI.IMVCAController
	{
    ArrangeLayersDocument _doc;
    ArrangeLayersDocument _tempDoc;
    IArrangeLayersView _view;

		public ArrangeLayersController(ArrangeLayersDocument doc)
		{
			_doc = doc;
      _tempDoc = new ArrangeLayersDocument();
      _tempDoc.CopyFrom(doc);

      Initialize();
    }

    void Initialize()
    {
      if(_view!=null)
      {
        _view.InitializeRowsColumns(_tempDoc.NumberOfRows,_tempDoc.NumberOfColumns);
        _view.InitializeSpacing(_tempDoc.HorizontalSpacing,_tempDoc.VerticalSpacing);
        _view.InitializeMargins(_tempDoc.TopMargin,_tempDoc.LeftMargin,_tempDoc.BottomMargin,_tempDoc.RightMargin);
      }
    }
    #region IArrangeLayersViewEventSink Members

    public bool EhNumberOfRowsChanged(string val)
    {
      int v;
      if(!GUIConversion.IsInteger(val, out v))
      {
        Current.Gui.ErrorMessageBox("You have to provide an integer value here");
        return true;
      }
      if(v<1)
      {
        Current.Gui.ErrorMessageBox("Please provide a value >0 here");
        return true;
      }
      _tempDoc.NumberOfRows = v;
      return false;
    }

    public bool EhNumberOfColumnsChanged(string val)
    {
      int v;
      if(!GUIConversion.IsInteger(val, out v))
      {
        Current.Gui.ErrorMessageBox("You have to provide an integer value here");
        return true;
      }
      if(v<1)
      {
        Current.Gui.ErrorMessageBox("Please provide a value >0 here");
        return true;
      }

      _tempDoc.NumberOfColumns = v;
      return false;
    }

    public bool EhHorizontalSpacingChanged(string val)
    {
      double v;
      if(!GUIConversion.IsDouble(val, out v))
      {
        Current.Gui.ErrorMessageBox("You have to provide an numeric value here");
        return true;
      }
      if(v<0)
      {
        Current.Gui.ErrorMessageBox("Please provide a value >=0 here");
        return true;
      }

      _tempDoc.HorizontalSpacing = v;
      return false;
    }

    public bool EhVerticalSpacingChanged(string val)
    {
      double v;
      if(!GUIConversion.IsDouble(val, out v))
      {
        Current.Gui.ErrorMessageBox("You have to provide an numeric value here");
        return true;
      }
      if(v<0)
      {
        Current.Gui.ErrorMessageBox("Please provide a value >=0 here");
        return true;
      }

      _tempDoc.VerticalSpacing = v;
      return false;  
    }

    public bool EhTopMarginChanged(string val)
    {
      double v;
      if(!GUIConversion.IsDouble(val, out v))
      {
        Current.Gui.ErrorMessageBox("You have to provide an numeric value here");
        return true;
      }
      _tempDoc.TopMargin = v;
      return false;  
    }

    public bool EhLeftMarginChanged(string val)
    {
      double v;
      if(!GUIConversion.IsDouble(val, out v))
      {
        Current.Gui.ErrorMessageBox("You have to provide an numeric value here");
        return true;
      }
      _tempDoc.LeftMargin = v;
      return false;  
    }

    public bool EhBottomMarginChanged(string val)
    {
      double v;
      if(!GUIConversion.IsDouble(val, out v))
      {
        Current.Gui.ErrorMessageBox("You have to provide an numeric value here");
        return true;
      }
      _tempDoc.BottomMargin = v;
      return false;  
    }

    public bool EhRightMarginChanged(string val)
    {
      double v;
      if(!GUIConversion.IsDouble(val, out v))
      {
        Current.Gui.ErrorMessageBox("You have to provide an numeric value here");
        return true;
      }
      _tempDoc.RightMargin = v;
      return false;  
    }

    #endregion

    #region IMVCController Members

    public object ViewObject
    {
      get { return _view; }
      set
      {
        if(_view!=null)
          _view.Controller = null;

        _view = value as IArrangeLayersView;
        
        Initialize();

        if(_view!=null)
          _view.Controller = this;
      }
    }

    public object ModelObject
    {
      get
      {
        
        return _doc;
      }
    }

    #endregion

    #region IApplyController Members

    public bool Apply()
    {
      _doc.CopyFrom(_tempDoc);
      return true;
    }

    #endregion
  }
}