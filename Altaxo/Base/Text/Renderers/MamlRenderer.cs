﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2018 Dr. Dirk Lellinger
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

#endregion Copyright

using Altaxo.Text.Renderers.Maml;
using Altaxo.Text.Renderers.Maml.Extensions;
using Altaxo.Text.Renderers.Maml.Inlines;
using Markdig.Helpers;
using Markdig.Renderers;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altaxo.Text.Renderers
{
	/// <summary>
	/// Renderer for a Markdown <see cref="MarkdownDocument"/> object that renders into one or multiple MAML files (MAML = Microsoft Assisted Markup Language).
	/// </summary>
	/// <seealso cref="TextRendererBase{T}" />
	public partial class MamlRenderer : TextRendererBase<MamlRenderer>
	{
		/// <summary>
		/// The basic full path file name of the Maml files. To this name there will be appended (i) a number, and (ii) the extension ".aml".
		/// </summary>
		public string AmlBaseFileName { get; }

		/// <summary>
		/// The list of .aml files, including full file name, guid, title, heading level, and where it starts in the document.
		/// </summary>
		private List<(string fileName, string guid, string title, int level, int spanStart)> _amlFileList = new List<(string fileName, string guid, string title, int level, int spanStart)>();

		/// <summary>
		/// The index of the .aml file (in <see cref="_amlFileList"/> that is currently written to.
		/// </summary>
		private int _indexOfAmlFile;

		/// <summary>
		/// Gets all .aml file names that are used here.
		/// </summary>
		public IEnumerable<string> AmlFileNames { get { return _amlFileList.Select(x => x.fileName); } }

		/// <summary>
		/// Dictionary that translates image references currently in the provided markdown file to
		/// new image references in the file system.
		/// </summary>
		public IDictionary<string, string> OldToNewImageUris { get; }

		/// <summary>
		/// Gets all image file names that are used, including the equation images.
		/// </summary>
		private HashSet<string> _imageFileNames = new HashSet<string>();

		/// <summary>
		/// Gets all image file names that are used, including the equation images.
		/// </summary>
		public IEnumerable<string> ImageFileNames { get { return _imageFileNames; } }

		/// <summary>
		/// The parsed markdown file.
		/// </summary>
		private MarkdownDocument _markdownDocument;

		/// <summary>
		/// Helper to calculate MD5 hashes.
		/// </summary>
		private System.Security.Cryptography.MD5 _md5Hasher = System.Security.Cryptography.MD5.Create();

		/// <summary>
		/// Full name of either the Sandcastle help file builder project (.shfbproj), or the layout content file (.content).
		/// </summary>
		public string ProjectOrContentFileName { get; }

		/// <summary>
		/// The header level where to split the output into different MAML files.
		/// 0 = render in only one file. 1 = Split at header level 1, 2 = split at header level 2, and so on.
		/// </summary>
		public int SplitLevel { get; }

		/// <summary>
		/// If true, an outline of the content will be included at the top of every Maml file.
		/// </summary>
		public bool AutoOutline { get; }

		public bool EnableHtmlEscape { get; }

		/// <summary>
		/// If true, a link to the previous section is inserted at the beginning of each maml document.
		/// </summary>
		public bool EnableLinkToPreviousSection { get; }

		/// <summary>
		/// Gets or sets the text that is inserted immediately before the link to the next section.
		/// </summary>
		public string LinkToPreviousSectionLabelText { get; }

		/// <summary>
		/// If true, a link to the next section is inserted at the end of each maml document.
		/// </summary>
		public bool EnableLinkToNextSection { get; }

		/// <summary>
		/// Gets or sets the text that is inserted immediately before the link to the next section.
		/// </summary>
		public string LinkToNextSectionLabelText { get; }

		/// <summary>
		/// Gets the full file name of the content layout file (extension: .content), that is a kind of table of contents for the document.
		/// </summary>
		public string ContentLayoutFileName { get; }

		/// <summary>
		/// Set this property to true if the Maml is indended to be used in a Help1 file.
		/// In such a file, the placement of images with align="middle" differs from HTML rendering
		/// (the text baseline is aligned with the middle of the image,
		/// whereas in HTML the middle of the text is aligned with the middle of the image).
		/// </summary>
		public bool IsIntendedForHelp1File { get; }

		/// <summary>
		/// Gets or sets the font family of the body text that later on is rendered out of the Maml file.
		/// We need this here because we have to convert the formulas to images, and need therefore the image size.
		/// </summary>
		public string BodyTextFontFamily { get; }

		/// <summary>
		/// Gets or sets the font size of the body text that later on is rendered out of the Maml file.
		/// We need this here because we have to convert the formulas to images, and need therefore the image size.
		/// </summary>
		public double BodyTextFontSize { get; }

		private List<Maml.MamlElement> _currentElementStack = new List<MamlElement>();

		public MamlRenderer(
			string projectOrContentFileName,
			int splitLevel,
				bool enableHtmlEscape,
				bool autoOutline,
				bool enableLinkToPreviousSection,
				string linkToPreviousSectionLabelText,
				bool enableLinkToNextSection,
				string linkToNextSectionLabelText,
				HashSet<string> imagesFullFileNames,
				Dictionary<string, string> oldToNewImageUris,
				string bodyTextFontFamily,
				double bodyTextFontSize,
				bool isIntendedForHelp1File
			) : base(TextWriter.Null)
		{
			ProjectOrContentFileName = projectOrContentFileName;
			SplitLevel = splitLevel;
			EnableHtmlEscape = enableHtmlEscape;
			AutoOutline = autoOutline;
			EnableLinkToPreviousSection = enableLinkToPreviousSection;
			LinkToPreviousSectionLabelText = linkToPreviousSectionLabelText ?? string.Empty;
			EnableLinkToNextSection = enableLinkToNextSection;
			LinkToNextSectionLabelText = linkToNextSectionLabelText ?? string.Empty;
			_imageFileNames = new HashSet<string>(imagesFullFileNames);
			OldToNewImageUris = oldToNewImageUris;
			BodyTextFontFamily = bodyTextFontFamily;
			BodyTextFontSize = bodyTextFontSize;
			IsIntendedForHelp1File = isIntendedForHelp1File;

			var path = Path.GetDirectoryName(ProjectOrContentFileName);
			AmlBaseFileName = Path.Combine(path, Path.GetFileNameWithoutExtension(ProjectOrContentFileName));
			ContentLayoutFileName = GetContentLayoutFileName(ProjectOrContentFileName);

			// Extension renderers that must be registered before the default renders
			ObjectRenderers.Add(new MathBlockRenderer()); // since MathBlock derives from CodeBlock, it must be registered before CodeBlockRenderer

			// Default block renderers
			ObjectRenderers.Add(new CodeBlockRenderer());
			ObjectRenderers.Add(new ListRenderer());
			ObjectRenderers.Add(new HeadingRenderer());
			//ObjectRenderers.Add(new HtmlBlockRenderer());
			ObjectRenderers.Add(new ParagraphRenderer());
			ObjectRenderers.Add(new QuoteBlockRenderer());
			ObjectRenderers.Add(new ThematicBreakRenderer());

			// Default inline renderers
			ObjectRenderers.Add(new AutolinkInlineRenderer());
			ObjectRenderers.Add(new CodeInlineRenderer());
			ObjectRenderers.Add(new DelimiterInlineRenderer());
			ObjectRenderers.Add(new EmphasisInlineRenderer());
			ObjectRenderers.Add(new LineBreakInlineRenderer());
			//ObjectRenderers.Add(new HtmlInlineRenderer());
			ObjectRenderers.Add(new HtmlEntityInlineRenderer());
			ObjectRenderers.Add(new LinkInlineRenderer());
			ObjectRenderers.Add(new LiteralInlineRenderer());

			// Extension renderers
			ObjectRenderers.Add(new TableRenderer());
			ObjectRenderers.Add(new MathInlineRenderer());
		}

		#region Maml topic file handling

		/// <summary>
		/// For the given markdown document, this evaluates all .aml files that are neccessary to store the content.
		/// </summary>
		/// <param name="markdownDocument">The markdown document.</param>
		/// <exception cref="ArgumentException">First block of the markdown document should be a heading block!</exception>
		private void EvaluateMamlFileNames(MarkdownDocument markdownDocument)
		{
			_amlFileList.Clear();
			_indexOfAmlFile = -1;

			// the header titles, entry 0 is the current title for level1, entry [1] is the current title for level 2 and so on
			List<string> headerTitles = new List<string>();

			if (markdownDocument[0] is HeadingBlock hbStart)
				AddMamlFile(hbStart, headerTitles);
			else
				throw new ArgumentException("The first block of the markdown document should be a heading block! Please add a header on top of your markdown document!");

			for (int i = 1; i < markdownDocument.Count; ++i)
			{
				if (markdownDocument[i] is HeadingBlock hb && hb.Level <= SplitLevel)
					AddMamlFile(hb, headerTitles);
			}
		}

		private void AddMamlFile(HeadingBlock headingBlock, List<string> headerTitles)
		{
			var fileName = string.Format("{0}{1:D6}.aml", AmlBaseFileName, _amlFileList.Count);
			var title = ExtractTextContentFrom(headingBlock);
			var levelM1 = headingBlock.Level - 1;

			for (int i = headerTitles.Count - 1; i >= 0; --i)
				headerTitles.RemoveAt(i);
			headerTitles.Add(title);

			var guid = CreateGuidFromHeaderTitles(headerTitles);
			_amlFileList.Add((fileName, guid, title, headingBlock.Level, headingBlock.Span.Start));
		}

		private string CreateGuidFromHeaderTitles(List<string> headerTitles)
		{
			var stb = new System.Text.StringBuilder();

			for (int i = 0; i < headerTitles.Count; ++i)
			{
				if (i != 0)
					stb.Append(" - ");
				stb.Append(headerTitles[i]);
			}

			byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(stb.ToString());

			byte[] hash = _md5Hasher.ComputeHash(inputBytes);

			// step 2, convert byte array to hex string

			stb.Length = 0;

			for (int i = 0; i < hash.Length; i++)
			{
				stb.Append(hash[i].ToString("X2"));
			}

			return stb.ToString();
		}

		public void TryStartNewMamlFile(HeadingBlock headingBlock)
		{
			if (_indexOfAmlFile < 0 || (_indexOfAmlFile + 1 < _amlFileList.Count && _amlFileList[_indexOfAmlFile + 1].spanStart == headingBlock.Span.Start))
			{
				if (null != this.Writer)
				{
					CloseCurrentMamlFile();
				}

				++_indexOfAmlFile;

				var mamlFile = _amlFileList[_indexOfAmlFile];

				var tw = new System.IO.StreamWriter(mamlFile.fileName, false, Encoding.UTF8, 1024);
				this.Writer = tw;

				Push(MamlElements.topic, new[] { new KeyValuePair<string, string>("id", mamlFile.guid), new KeyValuePair<string, string>("revisionNumber", "1") });
				Push(MamlElements.developerConceptualDocument, new[] { new KeyValuePair<string, string>("xmlns", "http://ddue.schemas.microsoft.com/authoring/2003/5"), new KeyValuePair<string, string>("xmlns:xlink", "http://www.w3.org/1999/xlink") });

				Push(MamlElements.introduction);

				if (AutoOutline)
					WriteLine("<autoOutline />");

				if (EnableLinkToPreviousSection && _indexOfAmlFile > 0)
				{
					Push(MamlElements.para);
					Write(LinkToPreviousSectionLabelText);
					var prevTopic = _amlFileList[_indexOfAmlFile - 1];
					Push(MamlElements.link, new[] { new KeyValuePair<string, string>("xlink:href", prevTopic.guid) });
					Write(prevTopic.title);
					PopTo(MamlElements.link);

					PopTo(MamlElements.para);
				}

				PopTo(MamlElements.introduction);
			}
		}

		public void CloseCurrentMamlFile()
		{
			if (null != this.Writer)
			{
				int numberOfContentElementsOnStack = 0;
				if (EnableLinkToNextSection && (_indexOfAmlFile + 1) < _amlFileList.Count && 0 != (numberOfContentElementsOnStack = NumberOfElementsOnStack(MamlElements.content)))
				{
					// Pop all content elements except one
					for (int i = 1; i < numberOfContentElementsOnStack; ++i)
						PopTo(MamlElements.content);
					PopToBefore(MamlElements.content); // now we are right before the last content element

					// now insert a link to the next section

					Push(MamlElements.markup);
					Write("<hr/>");
					PopTo(MamlElements.markup);

					Push(MamlElements.para);
					Write(LinkToNextSectionLabelText);
					var nextTopic = _amlFileList[_indexOfAmlFile + 1];
					Push(MamlElements.link, new[] { new KeyValuePair<string, string>("xlink:href", nextTopic.guid) });
					Write(nextTopic.title);
					PopTo(MamlElements.link);
					PopTo(MamlElements.para);
				}

				PopAll();

				this.Writer.Close();
				this.Writer.Dispose();
				this.Writer = TextWriter.Null;
			}
		}

		#endregion Maml topic file handling

		#region Maml image topic files handling

		/// <summary>
		/// Writes a file which contains all referenced images in native resolution (without using width and height attributes).
		/// To include this file helps ensure that all referenced images will be included into the help file.
		/// </summary>
		/// <returns>The guid of this .aml file.</returns>
		public (string fullFileName, Guid guid) WriteImageTopicFile()
		{
			var fileName = AmlBaseFileName + "_Images.aml";
			var tw = new System.IO.StreamWriter(fileName, false, Encoding.UTF8, 1024);
			this.Writer = tw;

			var guid = Guid.NewGuid();
			Push(MamlElements.topic, new[] { new KeyValuePair<string, string>("id", guid.ToString()), new KeyValuePair<string, string>("revisionNumber", "1") });
			Push(MamlElements.developerConceptualDocument, new[] { new KeyValuePair<string, string>("xmlns", "http://ddue.schemas.microsoft.com/authoring/2003/5"), new KeyValuePair<string, string>("xmlns:xlink", "http://www.w3.org/1999/xlink") });
			Push(MamlElements.introduction);
			Write("This page contains all images used in this help file in native resolution. The ordering of the images is arbitrary.");
			PopTo(MamlElements.introduction);
			Push(MamlElements.section);
			Push(MamlElements.title);
			Write("Appendix: All images in native resolution");
			EnsureLine();
			PopTo(MamlElements.title);
			Push(MamlElements.content);

			// all links to all images here
			foreach (var entry in OldToNewImageUris)
			{
				var localUrl = System.IO.Path.GetFileNameWithoutExtension(entry.Value);

				Push(MamlElements.para);

				Push(MamlElements.mediaLinkInline);

				Push(MamlElements.image, new[] { new KeyValuePair<string, string>("xlink:href", localUrl) });

				PopTo(MamlElements.para);
			}

			// the same again for the formulas
			foreach (var entry in _imageFileNames)
			{
				var localUrl = System.IO.Path.GetFileNameWithoutExtension(entry);

				Push(MamlElements.para);

				Push(MamlElements.mediaLinkInline);

				Push(MamlElements.image, new[] { new KeyValuePair<string, string>("xlink:href", localUrl) });

				PopTo(MamlElements.para);
			}

			PopAll();

			this.Writer.Close();
			this.Writer.Dispose();
			this.Writer = StreamWriter.Null;

			return (fileName, guid);
		}

		#endregion Maml image topic files handling

		#region Image file creation

		public void StorePngImageFile(Stream imageStream, string contentHash)
		{
			var dir = Path.GetDirectoryName(AmlBaseFileName);
			var fullFileName = Path.Combine(dir, "Images", contentHash + ".png");

			using (var outStream = new FileStream(fullFileName, FileMode.Create, FileAccess.Write, FileShare.Read))
			{
				imageStream.CopyTo(outStream);
				outStream.Close();
			}

			_imageFileNames.Add(fullFileName);
		}

		#endregion Image file creation

		public (string fileGuid, string address) FindFragmentLink(string url)
		{
			if (url.StartsWith("#"))
				url = url.Substring(1);

			// for now, we have to go through the entire FlowDocument in search for a markdig tag that
			// (i) contains HtmlAttributes, and (ii) the HtmlAttibutes has the Id that is our url

			foreach (var mdo in MarkdownUtilities.EnumerateAllMarkdownObjectsRecursively(_markdownDocument))
			{
				var attr = (Markdig.Renderers.Html.HtmlAttributes)mdo.GetData(typeof(Markdig.Renderers.Html.HtmlAttributes));
				if (null != attr && attr.Id == url)
				{
					// markdown element found, now we need to know in which file it is
					var prevFile = _amlFileList.First();
					foreach (var file in _amlFileList.Skip(1))
					{
						if (file.spanStart > mdo.Span.End)
							break;
						prevFile = file;
					}

					return (prevFile.guid, url);
				}
			}

			return (null, null);
		}

		public override object Render(MarkdownObject markdownObject)
		{
			object result = null;

			if (null == markdownObject)
				throw new ArgumentNullException(nameof(markdownObject));

			if (markdownObject is MarkdownDocument markdownDocument)
			{
				_markdownDocument = markdownDocument;

				if (markdownDocument.Count == 0)
					return base.Render(markdownDocument);

				EvaluateMamlFileNames(markdownDocument);

				base.Render(markdownObject);
			}
			else
			{
				result = base.Render(markdownObject);
			}

			// At the end, write the content file

			WriteContentLayoutFile();

			// afterwards: change the shfbproj to include i) all images and ii) all aml files that where created
			if (Path.GetExtension(ProjectOrContentFileName).ToLowerInvariant() == ".shfbproj")
			{
				UpdateShfbproj(ProjectOrContentFileName, GetContentLayoutFileName(ProjectOrContentFileName), this.AmlFileNames, this._imageFileNames);
			}

			return result;
		}

		public void Push(Maml.MamlElement mamlElement)
		{
			Push(mamlElement, null);
		}

		public void Push(Maml.MamlElement mamlElement, IEnumerable<KeyValuePair<string, string>> attributes)
		{
			_currentElementStack.Add(mamlElement);

			if (!mamlElement.IsInlineElement)
				WriteLine();

			Write("<");
			Write(mamlElement.Name);

			if (null != attributes)
			{
				foreach (var att in attributes)
				{
					Write(" ");
					Write(att.Key);
					Write("=\"");
					Write(att.Value);
					Write("\"");
				}
			}

			Write(">");

			if (!mamlElement.IsInlineElement)
				WriteLine();
		}

		public Maml.MamlElement Pop()
		{
			if (_currentElementStack.Count <= 0)
				throw new InvalidOperationException("Pop from an empty stack");

			var ele = _currentElementStack[_currentElementStack.Count - 1];
			_currentElementStack.RemoveAt(_currentElementStack.Count - 1);

			Write("</");
			Write(ele.Name);
			Write(">");

			if (!ele.IsInlineElement)
				WriteLine();

			return ele;
		}

		public void PopAll()
		{
			while (_currentElementStack.Count > 0)
				Pop();
		}

		public void PopTo(Maml.MamlElement mamlElement)
		{
			Maml.MamlElement ele = null;
			while (_currentElementStack.Count > 0)
			{
				ele = Pop();
				if (ele == mamlElement)
					break;
			}

			if (ele != mamlElement)
				throw new InvalidOperationException("Could not pop to Maml element " + mamlElement.Name);
		}

		public void PopToBefore(Maml.MamlElement mamlElement)
		{
			while (_currentElementStack.Count > 0)
			{
				if (_currentElementStack[_currentElementStack.Count - 1] == mamlElement)
					break;

				Pop();
			}

			if (_currentElementStack.Count == 0)
				throw new InvalidOperationException("Could not pop to before element " + mamlElement.Name);
		}

		public bool ElementStackContains(Maml.MamlElement mamlElement)
		{
			return _currentElementStack.Contains(mamlElement);
		}

		public int NumberOfElementsOnStack(Maml.MamlElement mamlElement)
		{
			int result = 0;
			for (int i = _currentElementStack.Count - 1; i >= 0; --i)
				if (_currentElementStack[i] == mamlElement)
					++result;

			return result;
		}

		/// <summary>
		/// Writes the content escaped for Maml.
		/// </summary>
		/// <param name="slice">The slice.</param>
		/// <param name="softEscape">Only escape &lt; and &amp;</param>
		/// <returns>This instance</returns>
		public void WriteEscape(StringSlice slice, bool softEscape = false)
		{
			WriteEscape(ref slice, softEscape);
		}

		/// <summary>
		/// Writes the content escaped for XAML.
		/// </summary>
		/// <param name="slice">The slice.</param>
		/// <param name="softEscape">Only escape &lt; and &amp;</param>
		/// <returns>This instance</returns>
		public void WriteEscape(ref StringSlice slice, bool softEscape = false)
		{
			if (slice.Start > slice.End)
			{
				return;
			}
			WriteEscape(slice.Text, slice.Start, slice.Length, softEscape);
		}

		/// <summary>
		/// Writes the content escaped for Maml.
		/// </summary>
		/// <param name="content">The content.</param>
		public void WriteEscape(string content)
		{
			if (!string.IsNullOrEmpty(content))
				WriteEscape(content, 0, content.Length);
		}

		/// <summary>
		/// Writes the content escaped for Maml.
		/// </summary>
		/// <param name="content">The content.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="length">The length.</param>
		/// <param name="softEscape">Only escape &lt; and &amp;</param>
		public void WriteEscape(string content, int offset, int length, bool softEscape = false)
		{
			if (string.IsNullOrEmpty(content) || length == 0)
				return;

			var end = offset + length;
			var previousOffset = offset;
			for (; offset < end; offset++)
			{
				switch (content[offset])
				{
					case '<':
						Write(content, previousOffset, offset - previousOffset);
						if (EnableHtmlEscape)
						{
							Write("&lt;");
						}
						previousOffset = offset + 1;
						break;

					case '>':
						if (!softEscape)
						{
							Write(content, previousOffset, offset - previousOffset);
							if (EnableHtmlEscape)
							{
								Write("&gt;");
							}
							previousOffset = offset + 1;
						}
						break;

					case '&':
						Write(content, previousOffset, offset - previousOffset);
						if (EnableHtmlEscape)
						{
							Write("&amp;");
						}
						previousOffset = offset + 1;
						break;

					case '"':
						if (!softEscape)
						{
							Write(content, previousOffset, offset - previousOffset);
							if (EnableHtmlEscape)
							{
								Write("&quot;");
							}
							previousOffset = offset + 1;
						}
						break;
				}
			}

			Write(content, previousOffset, end - previousOffset);
		}

		/// <summary>
		/// Writes the lines of a <see cref="LeafBlock"/>
		/// </summary>
		/// <param name="leafBlock">The leaf block.</param>
		/// <param name="writeEndOfLines">if set to <c>true</c> write end of lines.</param>
		/// <param name="escape">if set to <c>true</c> escape the content for XAML</param>
		/// <param name="softEscape">Only escape &lt; and &amp;</param>
		/// <returns>This instance</returns>
		public void WriteLeafRawLines(LeafBlock leafBlock, bool writeEndOfLines, bool escape, bool softEscape = false)
		{
			if (leafBlock == null)
				throw new ArgumentNullException(nameof(leafBlock));

			if (leafBlock.Lines.Lines != null)
			{
				var lines = leafBlock.Lines;
				var slices = lines.Lines;
				for (var i = 0; i < lines.Count; i++)
				{
					if (!writeEndOfLines && i > 0)
					{
						WriteLine();
					}
					if (escape)
					{
						WriteEscape(ref slices[i].Slice, softEscape);
					}
					else
					{
						Write(ref slices[i].Slice);
					}
					if (writeEndOfLines)
					{
						WriteLine();
					}
				}
			}
		}

		public string ExtractTextContentFrom(LeafBlock leafBlock)
		{
			var result = string.Empty;

			if (null == leafBlock.Inline)
				return result;

			foreach (var il in leafBlock.Inline)
			{
				result += il.ToString();
			}

			return result;
		}
	}
}
