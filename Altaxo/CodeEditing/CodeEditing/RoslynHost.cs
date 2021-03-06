﻿// Copyright Eli Arbel (no explicit copyright notice in original file), Apache License Version 2.0, January 2004

// Originated from: RoslynPad, RoslynPad.Roslyn, RoslynHost.cs

// Strongly revised for the Altaxo project, Copyright Dr. D. Lellinger, 2017

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Altaxo.CodeEditing.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Host;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.Text;

namespace Altaxo.CodeEditing
{
  public class RoslynHost
  {
    public static RoslynHost Instance { get; private set; }

    /// <summary>
    /// In order to have access to DocumentationProviderService, which is located inside a sealed internal class, you have i) to name the assembly "RoslynETAHost" and ii) sign the assembly with the roslyn private key.
    /// </summary>
    private readonly Microsoft.CodeAnalysis.Host.IDocumentationProviderService _documentationProviderService;

    /// <summary>
    /// Path to the framework assemblies. Used by the documentation service to get the xml documentation of the framework assemblies.
    /// </summary>
    private readonly string _referenceAssembliesPath = GetReferenceAssembliesPath();

    private readonly CompositionHost _compositionContext;

    private IDiagnosticService _diagnosticsService;

    public MefHostServices MefHost { get; }

    public static void InitializeInstance(IEnumerable<Assembly> additionalAssembliesToIncludeInComposition = null)
    {
      Instance = new RoslynHost(additionalAssembliesToIncludeInComposition);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RoslynHost"/> class.
    /// </summary>
    /// <param name="additionalAssembliesToIncludeInComposition">Additional assemblies to include in the composition of the Roslyn assemblies.
    /// By default the following assemblies are included: Microsoft.CodeAnalysis, Microsoft.CodeAnalysis.CSharp,
    /// Microsoft.CodeAnalysis.Features and Microsoft.CodeAnalysis.CSharp.Features.
    /// </param>
    public RoslynHost(IEnumerable<Assembly> additionalAssembliesToIncludeInComposition = null)
    {
      var assemblies = new[]
      {
                Assembly.Load("Microsoft.CodeAnalysis"),
                Assembly.Load("Microsoft.CodeAnalysis.CSharp"),
                Assembly.Load("Microsoft.CodeAnalysis.Features"),
                Assembly.Load("Microsoft.CodeAnalysis.CSharp.Features"),
                typeof(RoslynHost).Assembly,
      };
      if (additionalAssembliesToIncludeInComposition != null)
      {
        assemblies = assemblies.Concat(additionalAssembliesToIncludeInComposition).ToArray();
      }

      // the following code is usefull if the composition fails
      // here every assembly is inspected seperately to make it easy to find the rogue assembly
      /*
			 foreach (var ass in assemblies)
			{
				ass.GetTypes();
			}
			*/

      var partTypes = MefHostServices.DefaultAssemblies.Concat(assemblies)
              .Distinct()
              .SelectMany(x => x.GetTypes())
              .ToArray();

      _compositionContext = new ContainerConfiguration()
          .WithParts(partTypes)
          .CreateContainer();

      MefHost = MefHostServices.Create(_compositionContext);

      _documentationProviderService = new Altaxo.CodeEditing.Documentation.DocumentationProviderServiceFactory.DocumentationProviderService();

      _diagnosticsService = GetService<IDiagnosticService>(); // instantiate diagnostics service to get it working
    }

    private static string GetReferenceAssembliesPath()
    {
      var programFiles =
          Environment.GetFolderPath(Environment.Is64BitOperatingSystem
              ? Environment.SpecialFolder.ProgramFilesX86
              : Environment.SpecialFolder.ProgramFiles);
      var path = Path.Combine(programFiles, @"Reference Assemblies\Microsoft\Framework\.NETFramework");
      if (Directory.Exists(path))
      {
        var directory = Directory.EnumerateDirectories(path)
            .Select(x => new { path = x, version = GetFxVersionFromPath(x) })
            .OrderByDescending(x => x.version)
            .FirstOrDefault(x => File.Exists(Path.Combine(x.path, "System.dll")) &&
                                 File.Exists(Path.Combine(x.path, "System.xml")));
        return directory?.path;
      }
      return null;
    }

    private static Version GetFxVersionFromPath(string path)
    {
      var name = Path.GetFileName(path);
      if (name?.StartsWith("v", StringComparison.OrdinalIgnoreCase) == true)
      {
        if (Version.TryParse(name.Substring(1), out var version))
        {
          return version;
        }
      }

      return new Version(0, 0, 0);
    }

    public IEnumerable<string> TryGetFacadeAssemblies()
    {
      var facadesPath = Path.Combine(_referenceAssembliesPath, "Facades");
      if (Directory.Exists(facadesPath))
      {
        return Directory.EnumerateFiles(facadesPath, "*.dll");
      }

      return Array.Empty<string>();
    }

    /// <summary>
    /// Creates a metadata reference from an assembly location, and sets the corresponding documentation provider.
    /// </summary>
    /// <param name="assemblyLocation">The assembly location.</param>
    /// <returns>A metadata reference.</returns>
    public MetadataReference CreateMetadataReference(string assemblyLocation)
    {
      return MetadataReference.CreateFromFile(assemblyLocation, documentation: GetDocumentationProvider(assemblyLocation));
    }

    public DocumentationProvider GetDocumentationProvider(string location)
    {
      if (File.Exists(Path.ChangeExtension(location, "xml")))
      {
        return _documentationProviderService.GetDocumentationProvider(location);
      }
      if (_referenceAssembliesPath != null)
      {
        var referenceLocation = Path.Combine(_referenceAssembliesPath, Path.GetFileName(location));
        if (File.Exists(Path.ChangeExtension(referenceLocation, "xml")))
        {
          return _documentationProviderService.GetDocumentationProvider(referenceLocation);
        }
      }
      return null;
    }

    public TService GetService<TService>()
    {
      return _compositionContext.GetExport<TService>();
    }
  }
}
