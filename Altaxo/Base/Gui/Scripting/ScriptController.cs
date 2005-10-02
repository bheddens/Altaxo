using System;
using Altaxo.Data;
using Altaxo.Main.GUI;
using System.Text.RegularExpressions;
using Altaxo.Main.Services;
using Altaxo.Scripting;

namespace Altaxo.Gui.Scripting
{
  #region Interfaces

  /// <summary>
  /// Executes the script provided in the argument.
  /// </summary>
  public delegate bool ScriptExecutionHandler(IScriptText script);

  public interface IScriptView
  {
    IScriptViewEventSink Controller {get; set; }
    void AddPureScriptView(object scriptView);

    void ClearCompilerErrors();
    void AddCompilerError(string s);
  }

  public interface IScriptViewEventSink
  {
     void EhView_GotoCompilerError(string message);
  }

  public interface IScriptController : Main.GUI.IMVCAController
  {
    void SetText(string text);
    void Compile();
    void Update();
    void Cancel();
   
  }



  #endregion

	/// <summary>
	/// Summary description for ScriptController.
	/// </summary>
  [UserControllerForObject(typeof(IScriptText),200)]
  public class ScriptController : IScriptViewEventSink, IScriptController
  {
    IScriptView _view;
    IScriptText _doc;
    IScriptText _tempDoc;
    IScriptText _compiledDoc;
    protected ScriptExecutionHandler _scriptExecutionHandler;

    IPureScriptController _pureScriptController;
    private Regex _compilerErrorRegex = new Regex(@".*\((?<line>\d+),(?<column>\d+)\) : (?<msg>.+)",RegexOptions.Compiled);


    public ScriptController(IScriptText doc)
    : this(doc,null)
    {
    }
    public ScriptController(IScriptText doc, ScriptExecutionHandler exec)
    {
      _doc = doc;
      _tempDoc = _doc.CloneForModification();
      _compiledDoc=null;

      _pureScriptController = (IPureScriptController)Current.Gui.GetControllerAndControl(new object[]{_tempDoc},typeof(IPureScriptText),typeof(IPureScriptController));
      _scriptExecutionHandler = exec;
    }

    public void SetText(string text)
    {
      _pureScriptController.SetText(text);
    }

    public void Initialize()
    {
      if(_view!=null)
      {
        _view.ClearCompilerErrors();
        _view.AddPureScriptView(_pureScriptController.ViewObject);
        _pureScriptController.SetScriptCursorLocation( _tempDoc.UserAreaScriptOffset);
      }
    }
    #region IScriptViewEventSink Members

    public void EhView_GotoCompilerError(string message)
    {
      try
      {
        Match match = _compilerErrorRegex.Match(message);
        string sline = match.Result("${line}");
        string scol = match.Result("${column}");
        int line = int.Parse(sline);
        int col  = int.Parse(scol);

        
        _pureScriptController.SetScriptCursorLocation(line-1,col-1);

      }
      catch(Exception)
      {
      }
    }

    #endregion

    #region IScriptController Members

    public void Compile()
    {
      _compiledDoc = null;

      if(_pureScriptController.Apply())
      {
        _tempDoc.ScriptText = _pureScriptController.Model.ScriptText;

        if(null!=_view)
          _view.ClearCompilerErrors();

        IScriptText compiledDoc = _tempDoc.CloneForModification();
        bool result = compiledDoc.Compile();

        string[] errors = compiledDoc.Errors;
        if(result==false)
        {
          _compiledDoc = null;

          foreach(string s in errors)
          {
            System.Text.RegularExpressions.Match match = _compilerErrorRegex.Match(s);
            if(match.Success)
            {
              string news = match.Result("(${line},${column}) : ${msg}");
          
              _view.AddCompilerError(news);
            }
            else
            {
              _view.AddCompilerError(s);
            }
          }
  

          Current.Gui.ErrorMessageBox("There were compilation errors");
          return;
        }
        else
        {
          _compiledDoc = compiledDoc;
          
          _view.AddCompilerError(DateTime.Now.ToLongTimeString() + " : Compilation successful.");
        }
      }

    }

    public void Update()
    {
      if(_pureScriptController.Apply())
      {
        _tempDoc.ScriptText = this._pureScriptController.Model.ScriptText;

        if(null!=_compiledDoc && _tempDoc.ScriptText==_compiledDoc.ScriptText)
        {
          _doc = _compiledDoc;
        }
        else if(_doc.IsReadOnly && _doc.ScriptText != _pureScriptController.Model.ScriptText)
          _doc = _doc.CloneForModification();
        _doc.ScriptText = _pureScriptController.Model.ScriptText;
      }
      _tempDoc = (IScriptText)_doc.Clone();
    }

  

    public void Cancel()
    {
      
    }

    #endregion

    #region IMVCController Members

    public object ModelObject
    {
      get
      {
        return _doc;
      }
    }

    public object ViewObject
    {
      get
      {
        return _view;
      }
      set
      {
        if(_view!=null)
          _view.Controller = null;

        _view = value as IScriptView;
        
        Initialize();

        if(_view!=null)
          _view.Controller = this;
      }
    }

    #endregion

    #region IApplyController Members

    public bool Apply()
    {
      bool applyresult = false;

      if(_pureScriptController.Apply())
      {
        _tempDoc.ScriptText = this._pureScriptController.Model.ScriptText;
        if(null!=_compiledDoc && _tempDoc.ScriptText==_compiledDoc.ScriptText)
        {
          _doc = _compiledDoc;
          applyresult = true;
        }
        else
        {
          Compile();
          if(null!=_compiledDoc)
          {
            _doc = _compiledDoc;
            applyresult = true;
          }
        }
        
        if(applyresult == true && _scriptExecutionHandler!=null)
        {
          applyresult = _scriptExecutionHandler(_doc);
          if(applyresult==false)
          {
            foreach(string s in _doc.Errors)
              _view.AddCompilerError(s);

            Current.Gui.ErrorMessageBox("There were execution errors");
          }
        }
      }
      return applyresult;
    }

    #endregion
  }
}