﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

// Originated from: Roslyn, Features, CSharp/Portable/DocumentHighlighting/CSharpDocumentHighlightsService.cs

using System.Composition;
using Altaxo.CodeEditing.LanguageService;
using Microsoft.CodeAnalysis;

namespace Altaxo.CodeEditing.ReferenceHighlighting.CSharp
{
  [ExportLanguageService(typeof(IDocumentHighlightsService), LanguageNames.CSharp), Shared]
  public class CSharpDocumentHighlightsService : AbstractDocumentHighlightsService
  {
  }
}
