﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

// Originated from: Roslyn, Workspaces, Core/Portable/Workspace/Host/Mef/ExportLanguageServiceAttribute.cs

using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Host;

namespace Altaxo.CodeEditing.LanguageService
{
  [MetadataAttribute]
  [AttributeUsage(AttributeTargets.Class)]
  internal class ExportLanguageServiceAttribute : ExportAttribute
  {
    public string Language { get; }

    public ExportLanguageServiceAttribute(Type serviceType, string language)
        : base(serviceType)
    {
      Language = language ?? throw new ArgumentNullException(nameof(language));
    }
  }
}
