// Copyright Eli Arbel (no explicit copyright notice in original file)

// Originated from: RoslynPad, RoslynPad.Roslyn, Diagnostics/DiagnosticsUpdatedArgs.cs

using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Altaxo.CodeEditing.Diagnostics
{
  public class DiagnosticsUpdatedArgs : UpdatedEventArgs
  {
    public DiagnosticsUpdatedKind Kind { get; }
    public Solution Solution { get; }
    public ImmutableArray<DiagnosticData> Diagnostics { get; }

    internal DiagnosticsUpdatedArgs(Microsoft.CodeAnalysis.Diagnostics.DiagnosticsUpdatedArgs inner) : base(inner)
    {
      Solution = inner.Solution;
      Diagnostics = inner.Diagnostics.Select(x => new DiagnosticData(x)).ToImmutableArray();
      Kind = (DiagnosticsUpdatedKind)inner.Kind;
    }
  }
}
