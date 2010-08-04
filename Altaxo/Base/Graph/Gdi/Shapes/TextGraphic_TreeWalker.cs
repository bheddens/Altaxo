﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Drawing2D;

/* the Grammar used here is the following PEG grammar

<<Grammar Name="Altaxo_LabelV1">>

// root element: the first part is the regular parsed text, the second part is the rest which can not be interpreted properly
[1]^^MainSentence:  (EscSeq / WordSpanExt / Space)*  (WordSpanExt / EscChar / Space / '\\')*;

[2]^Sentence:       (EscSeq / WordSpan / Space)+;

[3]^SentenceNC:     (EscSeq / WordSpanNC / Space)+;

[4]^^WordSpanExt:   (Word / EscChar / ',' / ')')+;

[5]^^WordSpan:      (Word / EscChar / ',')+;

[6]^^WordSpanNC:    (Word / EscChar)+;

[7]^EscChar:        '\\\\' / '\\)' / '\\(';

[8]^EscSeq:   	    (EscSeq3 / EscSeq2 / EscSeq1);

[9]^Number:         [0-9]+ ('.' [0-9]+)?([eE][+-][0-9]+)?;

[10]Word:           [#x20-#x28#x2A-#x2B#x2D-#x5B#x5D-#xFFFF]+;

[11]^^Space:        '\t' / '\r\n' / '\n'; 

[12]^PositiveInteger: 	[0-9]+;

[13]^^EscSeq3:      ('\\L('\i PositiveInteger ',' PositiveInteger ',' PositiveInteger ')') /
                    ('\\%(' PositiveInteger ',' PositiveInteger ',' QuotedString ')');

[14]^^EscSeq2:      ( '\\' ( 'P'\i / 'F'\i / 'C'\i / '=' ) '(' SentenceNC ',' Sentence ')' ) /
                    ( '\\' ( 'L'\i                       ) '(' PositiveInteger ',' PositiveInteger ')' ) /
                    ( '\\' ( '%'                         ) '(' PositiveInteger ',' (PositiveInteger / QuotedString) ')' ) 
                    ;

[15]^^EscSeq1:      '\\' ('AB'\i / 'AD'\i / 'ID'\i / '+' / '-' /  '%' / '#' /  'B'\i / 'G'\i / 'I'\i / 'L'\i / 'N'\i / 'S'\i / 'U'\i / 'V'\i ) '(' Sentence ')';

[16]QuotedString:  '"' StringContent '"';

[17]^^StringContent: ( '\\' 
                           ( 'u'([0-9A-Fa-f]{4}/FATAL<"4 hex digits expected">)
                           / ["\\/bfnrt]/FATAL<"illegal escape"> 
                           ) 
                        / [#x20-#x21#x23-#xFFFF]
                        )*	;

<</Grammar>>



*/
namespace Altaxo.Graph.Gdi.Shapes
{
  using Plot;
  using Plot.Data;
  using Graph.Plot.Data;
  using Background;

	public partial class TextGraphic : GraphicBase
	{
		#region Regex expressions
		static Regex _regexIntArgument = new Regex(@"\G\(\n*(?<argone>\d+)\n*\)");
		static Regex _regexIntIntArgument = new Regex(@"\G\(\n*(?<argone>\d+)\n*,\n*(?<argtwo>\d+)\n*\)");
		static Regex _regexIntQstrgArgument = new Regex(@"\G\(\n*(?<argone>\d+)\n*,\n*\""(?<argtwo>([^\\\""]*(\\\"")*(\\\\)*)+)\""\n*\)");
		static Regex _regexIntStrgArgument = new Regex(@"\G\(\n*(?<argone>\d+)\n*,\n*(?<argtwo>\w+)\n*\)");
		static Regex _regexIntIntStrgArgument = new Regex(@"\G\(\n*(?<argone>\d+)\n*,\n*(?<argtwo>\d+)\n*,\n*(?<argthree>\w+)\n*\)");
		// Be aware that double quote characters is in truth only one quote character, this is the syntax of a verbatim literal string
		static Regex _regexIntIntQstrgArgument = new Regex(@"\G\(\n*(?<argone>\d+)\n*,\n*(?<argtwo>\d+)\n*,\n*\""(?<argthree>([^\\\""]*(\\\"")*(\\\\)*)+)\""\n*\)");
		#endregion

		class TreeWalker
		{
			string _sourceText;
			public TreeWalker(string sourceText)
			{
				_sourceText = sourceText;
			}
     
			public StructuralGlyph VisitTree(PegNode root, StyleContext context)
			{
				var rootGlyph = new VerticalStack();
        rootGlyph.Style = context;
        rootGlyph.LineSpacingFactor = 1.25;
        rootGlyph.FixedLineSpacing = true;

				var line = new GlyphLine();
        line.Style = context;

				rootGlyph.Add(line);

				if(null!=root && null!=root.child_)
					VisitNode(root.child_, context, line);

        return rootGlyph;
			}

			private StructuralGlyph VisitNode(PegNode node, StyleContext context, StructuralGlyph parent)
			{
				StructuralGlyph nextparent = parent;

				switch ((EAltaxo_LabelV1)node.id_)
				{
					case EAltaxo_LabelV1.WordSpan:
					case EAltaxo_LabelV1.WordSpanExt:
					case EAltaxo_LabelV1.WordSpanNC:
						HandleWordSpan(node, context, parent);
						break;
					case EAltaxo_LabelV1.Sentence:
					case EAltaxo_LabelV1.SentenceNC:
						HandleSentence(node, context, parent);
						break;
					case EAltaxo_LabelV1.Space:
						nextparent = HandleSpace(node, context, parent);
						break;
					case EAltaxo_LabelV1.EscSeq1:
						HandleEscSeq1(node, context, parent);
						break;
          case EAltaxo_LabelV1.EscSeq2:
            HandleEscSeq2(node, context, parent);
            break;
          case EAltaxo_LabelV1.EscSeq3:
            HandleEscSeq3(node, context, parent);
            break;
				}

				if (null != node.next_)
					nextparent = VisitNode(node.next_, context, nextparent);

				return nextparent;
			}

			void HandleWordSpan( PegNode node, StyleContext context, StructuralGlyph parent)
			{
				int posBeg = node.match_.posBeg_;
				int posEnd = node.match_.posEnd_;
				var childNode = node.child_;

				string str = string.Empty;
				if (null == childNode) // no escape sequences
				{
					str = _sourceText.Substring(posBeg, posEnd - posBeg);
				}
				else // at least one child node (Esc seq)
				{
					int beg = posBeg;
					int end = childNode.match_.posBeg_;
					while (childNode != null)
					{
						str += _sourceText.Substring(beg, end - beg);
						str += _sourceText.Substring(childNode.match_.posBeg_ + 1, 1);
						beg = childNode.match_.posEnd_;
						childNode = childNode.next_;
						end = null != childNode ? childNode.match_.posBeg_ : posEnd;
					}
					str += _sourceText.Substring(beg, end - beg);
				}
				parent.Add(new TextGlyph(str, context));
			}

			StructuralGlyph HandleSpace(PegNode node, StyleContext context, StructuralGlyph parent)
			{
				if (_sourceText[node.match_.posBeg_] == '\t')
				{
					HandleTab(parent);
					return parent;
				}
				else // newline
				{
					return HandleNewline(parent, context);
				}
			}

			void HandleTab(StructuralGlyph parent)
			{
				parent.Add(new TabGlpyh());
			}

			StructuralGlyph HandleNewline(StructuralGlyph parent, StyleContext context)
			{
				StructuralGlyph newcontext;

				if (parent is GlyphLine) // normal case
				{
					if (parent.Parent is VerticalStack)
					{
						newcontext = new GlyphLine();
            newcontext.Style = context;
						parent.Parent.Add(newcontext);
					}
					else // parent.Parent is not a VerticalStack
					{
						var vertStack = new VerticalStack();
						parent.Parent.Exchange(parent, vertStack);
						vertStack.Add(parent);
						newcontext = new GlyphLine();
            newcontext.Style = context;
						vertStack.Add(newcontext);
					}
				}
				else
				{
					throw new NotImplementedException();
				}
				return newcontext;
			}

			void HandleSentence(PegNode node, StyleContext context, StructuralGlyph parent)
			{
				var line = new GlyphLine();
				parent.Add(line);
				if (node.child_ != null)
					VisitNode(node.child_, context, line);
			}

			void HandleEscSeq1(PegNode node, StyleContext context, StructuralGlyph parent)
			{
				int posBeg = node.match_.posBeg_;
				var childNode = node.child_;

				if (childNode == null)
					throw new ArgumentNullException("childNode");

				string escHeader = _sourceText.Substring(posBeg, childNode.match_.posBeg_ - posBeg);

				switch (escHeader.ToLowerInvariant())
				{
					case @"\id(":
						{
							string s = GetText(childNode);
							if (s == "$DI")
								parent.Add(new DocumentIdentifier(context));
						}
						break;
					case  @"\g(":
						{
							var newContext = context.Clone();
							newContext.SetFont("Symbol", context.FontId.Size, context.FontId.Style);
							VisitNode(childNode, newContext, parent);
						}
						break;
					case @"\i(":
						{
							var newContext = context.Clone();
							newContext.StyleFont(FontStyle.Italic);
							VisitNode(childNode, newContext, parent);
						}
						break;
					case @"\b(":
						{
							var newContext = context.Clone();
							newContext.StyleFont(FontStyle.Bold);
							VisitNode(childNode, newContext, parent);
						}
						break;
					case @"\u(":
						{
							var newContext = context.Clone();
							newContext.StyleFont(FontStyle.Underline);
							VisitNode(childNode, newContext, parent);
						}
						break;
					case @"\s(":
						{
							var newContext = context.Clone();
							newContext.StyleFont(FontStyle.Strikeout);
							VisitNode(childNode, newContext, parent);
						}
						break;
          case @"\n(":
            {
              var newContext = context.Clone();
              newContext.StyleFont(FontStyle.Regular);
              VisitNode(childNode, newContext, parent);
            }
            break;
					case @"\+(":
						{
              var newParent = new Superscript();
              newParent.Style = context;
              parent.Add(newParent);
              
              var newContext = context.Clone();
              newContext.ScaleFont(0.65);
							VisitNode(childNode, newContext, newParent);
						}
						break;
					case @"\-(":
						{
              var newParent = new Subscript();
              newParent.Style = context;
              parent.Add(newParent);
              
              var newContext = context.Clone();
              newContext.ScaleFont(0.65);
							VisitNode(childNode, newContext, newParent);
						}
						break;
          case @"\l(":
            {
              string s = GetText(childNode);
              int plotNumber;
              if (int.TryParse(s, out plotNumber))
              {
                parent.Add(new PlotSymbol(context, plotNumber));
              }
            }
            break;
          case @"\%(":
            {
              string s = GetText(childNode);
              int plotNumber;
              if (int.TryParse(s, out plotNumber))
              {
                parent.Add(new PlotName(context, plotNumber));
              }
            }
            break;
					case @"\ad(":
						{
							var newParent = new DotOverGlyph();
							newParent.Style = context;
							parent.Add(newParent);
							VisitNode(childNode, context, newParent);
						}
						break;
					case @"\ab(":
						{
							var newParent = new BarOverGlyph();
							newParent.Style = context;
							parent.Add(newParent);
							VisitNode(childNode, context, newParent);
						}
						break;
				}
			}

      void HandleEscSeq2(PegNode node, StyleContext context, StructuralGlyph parent)
      {
        int posBeg = node.match_.posBeg_;
        var childNode = node.child_;

        if (childNode == null)
          throw new ArgumentNullException("childNode");

        string escHeader = _sourceText.Substring(posBeg, childNode.match_.posBeg_ - posBeg);

        switch (escHeader.ToLowerInvariant())
        {
          case @"\=(":
            {
              var newParent = new SubSuperScript();
              newParent.Style = context;
              parent.Add(newParent);

              var newContext = context.Clone();
              newContext.ScaleFont(0.65);
              VisitNode(childNode, newContext, newParent);
            }
            break;
					case @"\p(":
						{
							double val;
							string s1 = GetText(childNode).Trim();
							var newContext = context.Clone();
							string numberString;
							Altaxo.Serialization.LengthUnit lengthUnit;

							if (s1.EndsWith("%"))
							{
								numberString = s1.Substring(0, s1.Length - 1);
								if (double.TryParse(numberString, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out val))
								{
									newContext.BaseFontId = new FontIdentifier(context.BaseFontId.FamilyName, context.BaseFontId.Style, context.BaseFontId.Size * val / 100);
									newContext.ScaleFont(val / 100);
								}
							}
							else if (Altaxo.Serialization.LengthUnit.TryParse(s1, out lengthUnit, out numberString) &&
								double.TryParse(numberString, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out val)
								)
							{
								double newSize = val * (double)(lengthUnit.UnitInMeter / Altaxo.Serialization.LengthUnit.Point.UnitInMeter);
								newContext.BaseFontId = new FontIdentifier(context.BaseFontId.FamilyName, context.BaseFontId.Style, newSize);
								newContext.FontId = new FontIdentifier(context.FontId.FamilyName, context.FontId.Style, newSize);
							}
							else if (double.TryParse(s1, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out val)
								)
							{
								double newSize = val;
								newContext.BaseFontId = new FontIdentifier(context.BaseFontId.FamilyName, context.BaseFontId.Style, newSize);
								newContext.FontId = new FontIdentifier(context.FontId.FamilyName, context.FontId.Style, newSize);
							}
							VisitNode(childNode.next_, newContext, parent);
						}
						break;
					case @"\c(":
						{
							string s1 = GetText(childNode).Trim();
							var newContext = context.Clone();
								var conv = new ColorConverter();

								try
								{
									object result = conv.ConvertFromInvariantString(s1);
									newContext.brush = new SolidBrush((Color)result);
								}
								catch (Exception)
								{
								}
								
							

							VisitNode(childNode.next_, newContext, parent);
						}
						break;
          case @"\l(":
            {
              string s1 = GetText(childNode);
              string s2 = GetText(childNode.next_);
              int plotNumber, plotLayer;
              if (int.TryParse(s1, out plotLayer) && int.TryParse(s2, out plotNumber))
              {
                parent.Add(new PlotSymbol(context, plotNumber, plotLayer));
              }
            }
            break;
          case @"\%(":
            {
              string s1 = GetText(childNode);
              string s2 = GetText(childNode.next_);
              int plotNumber, plotLayer;
              if (int.TryParse(s1, out plotLayer) && int.TryParse(s2, out plotNumber))
              {
                parent.Add(new PlotName(context, plotNumber, plotLayer));
              }
              else if (int.TryParse(s1, out plotNumber))
              {
                var label = new PlotName(context, plotNumber);
                label.SetPropertyColumnName(s2);
                parent.Add(label);
              }

            }
            break;
        }
      }

      void HandleEscSeq3(PegNode node, StyleContext context, StructuralGlyph parent)
      {
        int posBeg = node.match_.posBeg_;
        var childNode = node.child_;

        if (childNode == null)
          throw new ArgumentNullException("childNode");

        string escHeader = _sourceText.Substring(posBeg, childNode.match_.posBeg_ - posBeg);

        switch (escHeader.ToLowerInvariant())
        {
					case @"\%(":
						{
							string s1 = GetText(childNode);
							string s2 = GetText(childNode.next_);
							string s3 = GetText(childNode.next_.next_);
							int plotNumber, plotLayer;
							if (int.TryParse(s1, out plotLayer) && int.TryParse(s2, out plotNumber))
							{
								var label = new PlotName(context, plotNumber, plotLayer);
								label.SetPropertyColumnName(s3);
								parent.Add(label);
							}
						}
						break;
        }
      }

			private string GetText(PegNode node)
			{
				return _sourceText.Substring(node.match_.posBeg_, node.match_.Length);
			}
    } // end class TreeWalker
  
	}
}