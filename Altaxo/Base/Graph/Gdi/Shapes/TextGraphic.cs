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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Altaxo.Serialization;
using System.Text.RegularExpressions;



namespace Altaxo.Graph.Gdi.Shapes
{
  using Plot;
  using Plot.Data;
  using Graph.Plot.Data;
  using Background;


 

  /// <summary>
  /// TextGraphics provides not only simple text on a graph,
  /// but also some formatting of the text, and quite important - the plot symbols
  /// to be used either in the legend or in the axis titles
  /// </summary>
  [Serializable]
  public partial class TextGraphic : GraphicBase
  {
    protected string _text = ""; // the text, which contains the formatting symbols
    protected Font _font;
    protected BrushX _textBrush = new BrushX(Color.Black);
    protected IBackgroundStyle _background = null;
    protected float _lineSpacingFactor=1.25f; // multiplicator for the line space, i.e. 1, 1.5 or 2
    protected XAnchorPositionType _xAnchorType = XAnchorPositionType.Left;
    protected YAnchorPositionType _yAnchorType = YAnchorPositionType.Top;

    #region Cached or temporary variables

		/// <summary>Hashtable where the keys are graphic paths giving the position of a symbol into the list, and the values are the plot items.</summary>
    protected Dictionary<GraphicsPath, IGPlotItem> _cachedSymbolPositions = new Dictionary<GraphicsPath, IGPlotItem>();
		StructuralGlyph _rootNode;
    protected bool _isStructureInSync=false; // true when the text was interpretet and the structure created
    protected bool _isMeasureInSync=false; // true when all items are measured
    protected PointF _cachedTextOffset; // offset of text to left upper corner of outer rectangle
    protected RectangleF _cachedExtendedTextBounds; // the text bounds extended by some margin around it
    #endregion // Cached or temporary variables


    #region Serialization

    #region ForClipboard

    protected TextGraphic(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
    {
      SetObjectData(this,info,context,null);
    }
    public override object SetObjectData(object obj,System.Runtime.Serialization.SerializationInfo info,System.Runtime.Serialization.StreamingContext context,System.Runtime.Serialization.ISurrogateSelector selector)
    {
      base.SetObjectData(obj, info, context, selector);

      _text = info.GetString("Text");
      _font = (Font)info.GetValue("Font", typeof(Font));
      _textBrush = (BrushX)info.GetValue("Brush", typeof(BrushX));
      _background = (IBackgroundStyle)info.GetValue("BackgroundStyle", typeof(IBackgroundStyle));
      _lineSpacingFactor = info.GetSingle("LineSpacing");
      _xAnchorType = (XAnchorPositionType)info.GetValue("XAnchor", typeof(XAnchorPositionType));
      _yAnchorType = (YAnchorPositionType)info.GetValue("YAnchor", typeof(YAnchorPositionType));
      return this;
    }
    public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
    {
      base.GetObjectData(info, context);

      info.AddValue("Text", _text);
      info.AddValue("Font", _font);
      info.AddValue("Brush", _textBrush);
      info.AddValue("BackgroundStyle", _background);
      info.AddValue("LineSpacing", _lineSpacingFactor);
      info.AddValue("XAnchor", _xAnchorType);
      info.AddValue("YAnchor", _yAnchorType);
    }

    /// <summary>
    /// Finale measures after deserialization.
    /// </summary>
    /// <param name="obj">Not used.</param>
    public override void OnDeserialization(object obj)
    {
    }

    #endregion


    [Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.TextGraphics", 0)]
      class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
    {
      public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
      {
        throw new ApplicationException("This serializer is not the actual version, and should therefore not be called");
        /*
        TextGraphics s = (TextGraphics)obj;
        info.AddBaseValueEmbedded(s,typeof(TextGraphics).BaseType);

        info.AddValue("Text",s.m_Text);
        info.AddValue("Font",s.m_Font);
        info.AddValue("Brush",s.m_BrushHolder);
        info.AddValue("BackgroundStyle",s.m_BackgroundStyle);
        info.AddValue("LineSpacing",s.m_LineSpacingFactor);
        info.AddValue("ShadowLength",s.m_ShadowLength);
        info.AddValue("XAnchor",s.m_XAnchorType);
        info.AddValue("YAnchor",s.m_YAnchorType);
        */
      }
      public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {
        
        TextGraphic s = null!=o ? (TextGraphic)o : new TextGraphic(); 
        info.GetBaseValueEmbedded(s,typeof(TextGraphic).BaseType,parent);

        // we have changed the meaning of rotation in the meantime, This is not handled in GetBaseValueEmbedded, 
        // since the former versions did not store the version number of embedded bases
        s._rotation = -s._rotation;

        s._text = info.GetString("Text");
        s._font = (Font)info.GetValue("Font",typeof(Font));
        s._textBrush = (BrushX)info.GetValue("Brush",typeof(BrushX));
        s.BackgroundStyleOld = (BackgroundStyle)info.GetValue("BackgroundStyle",typeof(BackgroundStyle));
        s._lineSpacingFactor = info.GetSingle("LineSpacing");
        info.GetSingle("ShadowLength");
        s._xAnchorType = (XAnchorPositionType)info.GetValue("XAnchor",typeof(XAnchorPositionType));
        s._yAnchorType = (YAnchorPositionType)info.GetValue("YAnchor",typeof(YAnchorPositionType));

        return s;
      }
    }


    [Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.TextGraphics", 1)]
    [Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(TextGraphic), 2)]
    class XmlSerializationSurrogate1 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
    {
      public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
      {
        TextGraphic s = (TextGraphic)obj;
        info.AddBaseValueEmbedded(s, typeof(TextGraphic).BaseType);

        info.AddValue("Text", s._text);
        info.AddValue("Font", s._font);
        info.AddValue("Brush", s._textBrush);
        info.AddValue("BackgroundStyle", s._background);
        info.AddValue("LineSpacing", s._lineSpacingFactor);
        info.AddValue("XAnchor", s._xAnchorType);
        info.AddValue("YAnchor", s._yAnchorType);

      }
      public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {

        TextGraphic s = null != o ? (TextGraphic)o : new TextGraphic();
        info.GetBaseValueEmbedded(s, typeof(TextGraphic).BaseType, parent);

        s._text = info.GetString("Text");
        s._font = (Font)info.GetValue("Font", typeof(Font));
        s._textBrush = (BrushX)info.GetValue("Brush", typeof(BrushX));
        s._background = (IBackgroundStyle)info.GetValue("BackgroundStyle", typeof(IBackgroundStyle));
        s._lineSpacingFactor = info.GetSingle("LineSpacing");
        s._xAnchorType = (XAnchorPositionType)info.GetValue("XAnchor", typeof(XAnchorPositionType));
        s._yAnchorType = (YAnchorPositionType)info.GetValue("YAnchor", typeof(YAnchorPositionType));

        return s;
      }
    }

  
    #endregion

    #region Constructors

    public TextGraphic(TextGraphic from)
      :
      base(from) // all is done here, since CopyFrom is overridden
    {
    }

    public TextGraphic()
    {
      _font = new Font(FontFamily.GenericSansSerif,18,GraphicsUnit.World);
    }

    public TextGraphic(PointF graphicPosition, string text, 
      Font textFont, Color textColor)
    {
      this.SetPosition(graphicPosition);
      this.Font = textFont;
      this.Text = text;
      this.Color = textColor;
    }


    public TextGraphic(  float posX, float posY, 
      string text, Font textFont, Color textColor)
      : this(new PointF(posX, posY), text, textFont, textColor)
    {
    }


    public TextGraphic(PointF graphicPosition, 
      string text, Font textFont, 
      Color textColor, float Rotation)
      : this(graphicPosition, text, textFont, textColor)
    {
      this.Rotation = Rotation;
    }

    public TextGraphic(float posX, float posY, 
      string text, 
      Font textFont, 
      Color textColor, float Rotation)
      : this(new PointF(posX, posY), text, textFont, textColor, Rotation)
    {
    }

    #endregion

		#region Copying

		protected override void CopyFrom(GraphicBase bfrom)
    {
      TextGraphic from = bfrom as TextGraphic;
      if (from != null)
      {
        this._text = from._text;
        this._font = from._font == null ? null : (Font)from._font.Clone();
        this._textBrush = from._textBrush == null ? null : (BrushX)from._textBrush.Clone();
        this._background = from._background == null ? null : (IBackgroundStyle)from._background.Clone();
        this._lineSpacingFactor = from._lineSpacingFactor;
        _xAnchorType = from._xAnchorType;
        _yAnchorType = from._yAnchorType;

        // don't clone the cached items
        this._isStructureInSync = false;
        this._isMeasureInSync = false;
      }
      base.CopyFrom(bfrom);
    }

    public void CopyFrom(TextGraphic from)
    {
      CopyFrom((GraphicBase)from);
		}

		public override object Clone()
		{
			return new TextGraphic(this);
		}

		#endregion

		#region Background

		protected void MeasureBackground(Graphics g, double textWidth, double textHeight)
    {
			var fontInfo = FontInfo.Create(g, _font);

			float widthOfOne_n = g.MeasureString("n", _font).Width;
			float widthOfThree_M = g.MeasureString("MMM", _font).Width;


      float distanceXL = 0; // left distance bounds-text
      float distanceXR = 0; // right distance text-bounds
      float distanceYU = 0;   // upper y distance bounding rectangle-string
      float distanceYL = 0; // lower y distance

      
      if (this._background != null)
      {
        // the distance to the sides should be like the character n
        distanceXL = 0.25f * widthOfOne_n; // left distance bounds-text
        distanceXR = distanceXL; // right distance text-bounds
        distanceYU = (float)fontInfo.cyDescent;   // upper y distance bounding rectangle-string
        distanceYL = 0; // lower y distance
      }
      
      SizeF size = new SizeF((float)(textWidth + distanceXL + distanceXR), (float)(textHeight + distanceYU + distanceYL));
      _cachedExtendedTextBounds = new RectangleF(PointF.Empty, size);
      RectangleF textRectangle = new RectangleF(new PointF(-distanceXL, -distanceYU), size);

      if (this._background != null)
      {
        RectangleF backgroundRect = this._background.MeasureItem(g, textRectangle);
        _cachedExtendedTextBounds.Offset(textRectangle.X - backgroundRect.X, textRectangle.Y - backgroundRect.Y);

        size = backgroundRect.Size;
        distanceXL = -backgroundRect.Left;
        distanceXR = (float)(backgroundRect.Right - textWidth);
        distanceYU = -backgroundRect.Top;
        distanceYL =(float)( backgroundRect.Bottom - textHeight);
      }

      float xanchor = 0;
      float yanchor = 0;
      if (_xAnchorType == XAnchorPositionType.Center)
        xanchor = size.Width / 2.0f;
      else if (_xAnchorType == XAnchorPositionType.Right)
        xanchor = size.Width;

      if (_yAnchorType == YAnchorPositionType.Center)
        yanchor = size.Height / 2.0f;
      else if (_yAnchorType == YAnchorPositionType.Bottom)
        yanchor = size.Height;

      this._bounds = new RectangleF(new PointF(-xanchor, -yanchor), size);
      this._cachedTextOffset = new PointF(distanceXL, distanceYU);
      
    }

    public IBackgroundStyle Background
    {
      get
      {
        return _background;
      }
      set
      {
        _background = value;
        _isMeasureInSync = false;
      }
    }

    private BackgroundStyle BackgroundStyleOld
    {
      get 
      {
        if (null == _background)
          return BackgroundStyle.None;
        else if (_background is BlackLine)
          return BackgroundStyle.BlackLine;
        else if (_background is BlackOut)
          return BackgroundStyle.BlackOut;
        else if (_background is DarkMarbel)
          return BackgroundStyle.DarkMarbel;
        else if (_background is RectangleWithShadow)
          return BackgroundStyle.Shadow;
        else if (_background is WhiteOut)
          return BackgroundStyle.WhiteOut;
        else
          return BackgroundStyle.None;
      }
      set
      {
        _isMeasureInSync = false;

        switch (value)
        {
            
          case BackgroundStyle.BlackLine:
            _background = new BlackLine();
            break;
          case BackgroundStyle.BlackOut:
            _background = new BlackOut();
            break;
          case BackgroundStyle.DarkMarbel:
            _background = new DarkMarbel();
            break;
          case BackgroundStyle.WhiteOut:
            _background = new WhiteOut();
            break;
          case BackgroundStyle.Shadow:
            _background = new RectangleWithShadow();
            break;
          case BackgroundStyle.None:
            _background = null;
            break;
        }
      }
		}

		protected virtual void PaintBackground(Graphics g)
		{
			// Assumptions: 
			// 1. the overall size of the structure must be measured before, i.e. bMeasureInSync is true
			// 2. the graphics object was translated and rotated before, so that the paining starts at (0,0)

			if (!this._isMeasureInSync)
				return;

			if (_background != null)
				_background.Draw(g, _cachedExtendedTextBounds);
		}

		#endregion

		#region Properties

		public Font Font
    {
      get
      {
        return _font;
      }
      set
      {
        _font = value;
        this._isStructureInSync=false; // since the font is cached in the structure, it must be renewed
        this._isMeasureInSync=false;
      }
    }

    public bool Empty
    {
      get { return _text==null || _text.Length==0; }
    }

    public string Text
    {
      get
      {
        return _text;
      }
      set
      {
        _text = value;
        this._isStructureInSync=false;
      }
    }

    public System.Drawing.Color Color
    {
      get
      {
        return _textBrush.Color;
      }
      set
      {
        _textBrush = new BrushX(value);
      }
    }

    public BrushX TextFillBrush
    {
      get
      {
        return _textBrush;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();

        _textBrush = value.Clone();
      }
    }

    public XAnchorPositionType XAnchor
    {
      get { return _xAnchorType; }
      set { _xAnchorType=value; }
    }

    public YAnchorPositionType YAnchor
    {
      get { return _yAnchorType; }
      set { _yAnchorType=value; }
		}

		#endregion

		#region Interpreting and Painting

		void InterpretText()
		{
			var parser = new Altaxo_LabelV1();
			parser.SetSource(_text);
			bool bMatches = parser.MainSentence();
			var tree = parser.GetRoot();

			TreeWalker walker = new TreeWalker(_text);
			StyleContext style = new StyleContext(new FontIdentifier(_font.FontFamily.Name, _font.Style, _font.Size), _textBrush);
			style.BaseFontId = new FontIdentifier(_font.FontFamily.Name, _font.Style, _font.Size);

			_rootNode = walker.VisitTree(tree, style);
		}

		void MeasureGlyphs(Graphics g, FontCache cache, object linkedObject)
		{
			MeasureContext mc = new MeasureContext();
			mc.FontCache = cache;
			mc.LinkedObject = linkedObject;
			mc.TabStop = g.MeasureString("MMMM", _font, PointF.Empty, _rootNode.StringFormat).Width;

			if (null != _rootNode)
				_rootNode.Measure(g, mc, 0);
		}

		void DrawGlyphs(Graphics g, DrawContext dc, double x, double y)
		{
			_rootNode.Draw(g, dc, y, y + _rootNode.ExtendAboveBaseline);
		}

		public override void Paint(Graphics g, object obj)
    {
      Paint(g,obj,false);
    }

    public void Paint(Graphics g, object obj, bool bForPreview)
    {
      //_isStructureInSync = false;
      _isMeasureInSync = false;  // Change: interpret text every time in order to update plot items and \ID

      if (!this._isStructureInSync)
      {
       // this.Interpret(g);
        this.InterpretText();

        _isStructureInSync = true;
        _isMeasureInSync = false;
      }

			using (FontCache fontCache = new FontCache())
			{

				if (!this._isMeasureInSync)
				{
					// this.MeasureStructure(g, obj);
					this.MeasureGlyphs(g, fontCache, obj);

					MeasureBackground(g, _rootNode.Width, _rootNode.Height);

					_isMeasureInSync = true;
				}

				_cachedSymbolPositions.Clear();

				System.Drawing.Drawing2D.GraphicsState gs = g.Save();
				g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;


				Matrix transformmatrix = new Matrix();
				transformmatrix.Translate(X, Y);
				transformmatrix.Rotate(-_rotation);
				transformmatrix.Translate(_bounds.X, _bounds.Y);

				if (!bForPreview)
				{
					g.TranslateTransform(X, Y);
					g.RotateTransform(-_rotation);
					g.TranslateTransform(_bounds.X, _bounds.Y);
				}

				// first of all paint the background
				PaintBackground(g);

				DrawContext dc = new DrawContext();
				dc.FontCache = fontCache;
				dc.bForPreview = bForPreview;
				dc.LinkedObject = obj;
				dc.transformMatrix = transformmatrix;
				dc._cachedSymbolPositions = _cachedSymbolPositions;
				DrawGlyphs(g, dc, _cachedTextOffset.X, _cachedTextOffset.Y);
				g.Restore(gs);
			}
		}

		#endregion

		#region Hit testing and handling

		public static DoubleClickHandler  PlotItemEditorMethod;
    public static DoubleClickHandler TextGraphicsEditorMethod;


    public override IHitTestObject HitTest(PointF pt)
    {
      IHitTestObject result;
      foreach(GraphicsPath gp in this._cachedSymbolPositions.Keys)
      {
        if(gp.IsVisible(pt))
        {
          result =  new HitTestObject(gp,_cachedSymbolPositions[gp]);
          result.DoubleClick = PlotItemEditorMethod;
          return result;
        }
      }
      
      result = base.HitTest(pt);
      if(null!=result)
        result.DoubleClick = TextGraphicsEditorMethod;
      return result;

		}

		#endregion

		#region IGrippableObject Members

		public override void ShowGrips(Graphics g)
    {
      GraphicsState gs = g.Save();
      g.TranslateTransform(X, Y);
      if (_rotation != 0)
        g.RotateTransform(-_rotation);

      DrawRotationGrip(g,new PointF(1,1));
      g.DrawRectangle(Pens.Blue, _bounds.X, _bounds.Y, _bounds.Width, _bounds.Height);
      g.Restore(gs);
    }

    public override IGripManipulationHandle GripHitTest(PointF point)
    {
      PointF rel;

      rel = new PointF(1, 1);
      if (IsRotationGripHitted(rel, point))
        return new RotationGripHandle(this, rel);

      return null;
    }

    #endregion


    #region Deprecated classes

    [Serializable]
    private enum BackgroundStyle
    {
      None,
      BlackLine,
      Shadow,
      DarkMarbel,
      WhiteOut,
      BlackOut
    }

    [Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.BackgroundStyle", 0)]
    public class BackgroundStyleXmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
    {
      public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
      {
        throw new NotImplementedException("This class is deprecated and no longer supported to serialize");
        // info.SetNodeContent(obj.ToString());  
      }
      public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {

        string val = info.GetNodeContent();
        return System.Enum.Parse(typeof(BackgroundStyle), val, true);
      }
    }


    #endregion
  }
}




