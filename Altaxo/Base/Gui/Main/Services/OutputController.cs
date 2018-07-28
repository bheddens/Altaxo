﻿using Altaxo.Main.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altaxo.Gui.Main.Services
{
  public interface IOutputView
  {
    void SetText(string text);

    bool IsEnabled { get; set; }

    event Action EnabledChanged;
  }

  [ExpectedTypeOfView(typeof(IOutputView))]
  public class OutputController : IMVCController, ITextOutputService
  {
    private IOutputView _view;
    private bool _isLoggingEnabled = false; // always start with false, only the user can enable this service
    private StringBuilder _logText = new StringBuilder();

    public void InternalWrite(string text)
    {
      if (_isLoggingEnabled)
      {
        _logText.Append(text);

        if (null != _view)
          _view.SetText(_logText.ToString());
      }
    }

    public void Write(string text)
    {
      InternalWrite(text);
    }

    public void WriteLine()
    {
      InternalWrite(System.Environment.NewLine);
    }

    public void WriteLine(string text)
    {
      InternalWrite(text + System.Environment.NewLine);
    }

    public void WriteLine(string format, params object[] args)
    {
      InternalWrite(string.Format(format, args) + System.Environment.NewLine);
    }

    public void WriteLine(System.IFormatProvider provider, string format, params object[] args)
    {
      InternalWrite(string.Format(provider, format, args) + System.Environment.NewLine);
    }

    public void Write(string format, params object[] args)
    {
      InternalWrite(string.Format(format, args));
    }

    public void Write(System.IFormatProvider provider, string format, params object[] args)
    {
      InternalWrite(string.Format(provider, format, args));
    }

    private void Initialize(bool initData)
    {
      if (_view != null)
      {
        _view.SetText(_logText.ToString());
      }
    }

    private void EhEnabledChanged()
    {
      _isLoggingEnabled = _view.IsEnabled;
    }

    public object ViewObject
    {
      get
      {
        return _view;
      }
      set
      {
        if (null != _view)
        {
          _view.EnabledChanged -= EhEnabledChanged;
        }

        _view = (IOutputView)value;

        if (null != _view)
        {
          Initialize(false);
          _view.EnabledChanged += EhEnabledChanged;
        }
      }
    }

    #region IMVCController Members

    public object ModelObject
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    #endregion IMVCController Members

    #region IXmlSerializable Members

    public void Load(System.Xml.XmlTextReader tr, string localName)
    {
      tr.ReadStartElement(localName);

      tr.ReadElementContentAsBoolean("IsEnabled", string.Empty);

      tr.ReadEndElement();
    }

    public void Save(System.Xml.XmlTextWriter tw, string localName)
    {
      tw.WriteStartElement(localName);
      tw.WriteAttributeString("Version", "1");

      tw.WriteElementString("IsEnabled", System.Xml.XmlConvert.ToString(_isLoggingEnabled));

      tw.WriteEndElement(); // localName
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    #endregion IXmlSerializable Members
  }
}
