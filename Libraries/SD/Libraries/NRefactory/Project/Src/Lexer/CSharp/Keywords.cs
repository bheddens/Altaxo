// this file was autogenerated by a tool.
using System;

namespace ICSharpCode.NRefactory.Parser.CSharp
{
	public static class Keywords
	{
		static readonly string[] keywordList = {
			"abstract",
			"as",
			"base",
			"bool",
			"break",
			"byte",
			"case",
			"catch",
			"char",
			"checked",
			"class",
			"const",
			"continue",
			"decimal",
			"default",
			"delegate",
			"do",
			"double",
			"else",
			"enum",
			"event",
			"explicit",
			"extern",
			"false",
			"finally",
			"fixed",
			"float",
			"for",
			"foreach",
			"goto",
			"if",
			"implicit",
			"in",
			"int",
			"interface",
			"internal",
			"is",
			"lock",
			"long",
			"namespace",
			"new",
			"null",
			"object",
			"operator",
			"out",
			"override",
			"params",
			"private",
			"protected",
			"public",
			"readonly",
			"ref",
			"return",
			"sbyte",
			"sealed",
			"short",
			"sizeof",
			"stackalloc",
			"static",
			"string",
			"struct",
			"switch",
			"this",
			"throw",
			"true",
			"try",
			"typeof",
			"uint",
			"ulong",
			"unchecked",
			"unsafe",
			"ushort",
			"using",
			"virtual",
			"void",
			"volatile",
			"while",
			"partial",
			"where",
			"get",
			"set",
			"add",
			"remove",
			"yield",
			"select",
			"group",
			"by",
			"into",
			"from",
			"ascending",
			"descending",
			"orderby",
			"let",
			"join",
			"on",
			"equals",
			"async",
			"await"
		};
		
		static LookupTable keywords = new LookupTable(true);
		
		static Keywords()
		{
			for (int i = 0; i < keywordList.Length; ++i) {
				keywords[keywordList[i]] = i + Tokens.Abstract;
			}
		}
		
		public static int GetToken(string keyword)
		{
			return keywords[keyword];
		}
		
		public static bool IsNonIdentifierKeyword(string word)
		{
			int token = GetToken(word);
			if (token < 0)
				return false;
			return !Tokens.IdentifierTokens[token];
		}
	}
}
