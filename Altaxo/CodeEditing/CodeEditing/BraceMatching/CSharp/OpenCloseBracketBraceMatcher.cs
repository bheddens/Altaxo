﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

// Originated from: Roslyn, EditorFeatures, CSharp/BraceMatching/OpenCloseBracketBraceMatcher.cs

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Altaxo.CodeEditing.BraceMatching.CSharp
{
  [ExportBraceMatcher(LanguageNames.CSharp)]
  internal class OpenCloseBracketBraceMatcher : AbstractCSharpBraceMatcher
  {
    public OpenCloseBracketBraceMatcher()
        : base(SyntaxKind.OpenBracketToken, SyntaxKind.CloseBracketToken)
    {
    }
  }
}
