// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

// Originated from: Roslyn, EditorFeatures, Implementation\ReferenceHighlighting\IDocumentHighlightsService.cs

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Host;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis;

namespace Altaxo.CodeEditing.ReferenceHighlighting
{
	public enum HighlightSpanKind
	{
		None,
		Definition,
		Reference,
		WrittenReference,
	}

	public struct HighlightSpan
	{
		public TextSpan TextSpan { get; }
		public HighlightSpanKind Kind { get; }

		public HighlightSpan(TextSpan textSpan, HighlightSpanKind kind) : this()
		{
			this.TextSpan = textSpan;
			this.Kind = kind;
		}
	}

	public struct DocumentHighlights
	{
		public Document Document { get; }
		public ImmutableArray<HighlightSpan> HighlightSpans { get; }

		public DocumentHighlights(Document document, ImmutableArray<HighlightSpan> highlightSpans)
		{
			this.Document = document;
			this.HighlightSpans = highlightSpans;
		}
	}

	public interface IDocumentHighlightsService : ILanguageService
	{
		Task<ImmutableArray<DocumentHighlights>> GetDocumentHighlightsAsync(
				Document document, int position, IImmutableSet<Document> documentsToSearch, CancellationToken cancellationToken);
	}
}