﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2015 Dr. Dirk Lellinger
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altaxo.Gui.Graph.Graph3D.Common
{
  using System;
  using System.ComponentModel;
  using System.Windows;
  using System.Windows.Controls;
  using System.Windows.Input;
  using System.Windows.Media;
  using Altaxo.Geometry;
  using Altaxo.Graph;
  using Altaxo.Graph.Graph3D;
  using Altaxo.Graph.Graph3D.Camera;
  using Altaxo.Graph.Graph3D.GraphicsContext.D3D;
  using SharpDX;
  using SharpDX.Direct3D10;
  using SharpDX.DXGI;
  using Device = SharpDX.Direct3D10.Device1;

  //using STG = SharpDX.Toolkit.Graphics;

  public class D3D10BitmapExporter : Altaxo.Main.IProjectItemImageExporter
  {
    /// <summary>
    /// Saves the project item as image to the provided stream.
    /// </summary>
    /// <param name="item">The item to export, for instance an item of type <see cref="Altaxo.Graph.Gdi.GraphDocument"/> or <see cref="Altaxo.Graph.Graph3D.GraphDocument"/>.</param>
    /// <param name="options">The export options.</param>
    /// <param name="toStream">The stream to save the image to.</param>
    public void ExportAsImageToStream(Altaxo.Main.IProjectItem item, Altaxo.Graph.Gdi.GraphExportOptions options, System.IO.Stream toStream)
    {
      if (item == null)
        throw new ArgumentNullException(nameof(item));
      if (!(item is Altaxo.Graph.Graph3D.GraphDocument))
        throw new ArgumentException(string.Format("Expected item of type {0}, but it is of type {1}", typeof(Altaxo.Graph.Graph3D.GraphDocument), item.GetType()));
      var doc = (Altaxo.Graph.Graph3D.GraphDocument)item;

      double sourceDpi = options.SourceDpiResolution;

      var exporter = new D3D10BitmapExporter();

      var scene = new Viewing.D3D10Scene();

      var g = new D3D10GraphicsContext();

      doc.Paint(g);

      var matrix = doc.Camera.LookAtRHMatrix;

      var rect = new RectangleD3D(PointD3D.Empty, doc.RootLayer.Size);
      var bounds = RectangleD3D.NewRectangleIncludingAllPoints(rect.Vertices.Select(x => matrix.Transform(x)));

      int pixelsX = (int)Math.Ceiling(sourceDpi * bounds.SizeX / 72.0);
      pixelsX = (int)(4 * Math.Ceiling((pixelsX + 3) / 4.0));

      int pixelsY = (int)(sourceDpi * bounds.SizeY / 72.0);

      double aspectRatio = pixelsY / (double)pixelsX;

      var sceneCamera = doc.Camera;

      if (sceneCamera is OrthographicCamera)
      {
        var orthoCamera = (OrthographicCamera)sceneCamera;
        orthoCamera = (OrthographicCamera)orthoCamera.WithWidthAtZNear(bounds.SizeX);

        double offsX = -(1 + 2 * bounds.X / bounds.SizeX);
        double offsY = -(1 + 2 * bounds.Y / bounds.SizeY);
        sceneCamera = orthoCamera.WithScreenOffset(new PointD2D(offsX, offsY));
      }
      else if (sceneCamera is PerspectiveCamera)
      {
        var viewProj = sceneCamera.GetViewProjectionMatrix(1); // here we transform the points with AspectRatio=1, in order to get the AspectRatio of the ScreenBounds
        var screenBounds = RectangleD3D.NewRectangleIncludingAllPoints(rect.Vertices.Select(x => viewProj.Transform(x)));
        aspectRatio = screenBounds.SizeY / screenBounds.SizeX; // this is the aspectRatio of our image
        viewProj = sceneCamera.GetViewProjectionMatrix(aspectRatio); // now we get the transform with our aspectRatio determined above
        screenBounds = RectangleD3D.NewRectangleIncludingAllPoints(rect.Vertices.Select(x => viewProj.Transform(x))); // this are our actual screenBounds, of course in relative screen coordinates, thus the ratio of sizeX and sizeY should now be 1

        double scaleFactor = 2 / screenBounds.SizeX; // since SizeX and SizeY should now be the same, we could have used SizeY alternatively
        double offsX = -(1 + scaleFactor * screenBounds.X);
        double offsY = -(1 + scaleFactor * screenBounds.Y);

        pixelsY = (int)(4 * Math.Ceiling((aspectRatio * pixelsX + 3) / 4.0)); // now calculate the size of the image in y direction from the aspectRatio

        var perspCamera = (PerspectiveCamera)sceneCamera;

        sceneCamera = perspCamera.WithWidthAtZNear(perspCamera.WidthAtZNear / scaleFactor);
        sceneCamera = sceneCamera.WithScreenOffset(new PointD2D(offsX, offsY));
      }
      else
      {
        throw new NotImplementedException();
      }

      scene.SetCamera(sceneCamera);
      scene.SetLighting(doc.Lighting);
      scene.SetDrawing(g);

      exporter.Export(pixelsX, pixelsY, scene, options, toStream);
    }

    public void Export(int sizeX, int sizeY, ID3D10Scene scene, Altaxo.Graph.Gdi.GraphExportOptions options, System.IO.Stream toStream)
    {
      var device = new Device(DriverType.Hardware, DeviceCreationFlags.BgraSupport, FeatureLevel.Level_10_0);

      // try to get the highest MSAA level with the highest quality
      int sampleCount = 32;
      int qlevel_sampleCount = 0;

      for (; sampleCount >= 0; sampleCount /= 2)
      {
        if (0 != (qlevel_sampleCount = device.CheckMultisampleQualityLevels(Format.B8G8R8A8_UNorm, sampleCount))) // quality level for sample count
          break;
      }

      var colordesc = new Texture2DDescription
      {
        BindFlags = BindFlags.RenderTarget | BindFlags.ShaderResource,
        Format = Format.B8G8R8A8_UNorm_SRgb,
        Width = sizeX,
        Height = sizeY,
        MipLevels = 1,
        SampleDescription = new SampleDescription(sampleCount, qlevel_sampleCount - 1),
        Usage = ResourceUsage.Default,
        OptionFlags = ResourceOptionFlags.Shared,
        CpuAccessFlags = CpuAccessFlags.None,
        ArraySize = 1
      };

      var depthdesc = new Texture2DDescription
      {
        BindFlags = BindFlags.DepthStencil,
        Format = Format.D32_Float_S8X24_UInt,
        Width = sizeX,
        Height = sizeY,
        MipLevels = 1,
        SampleDescription = new SampleDescription(sampleCount, qlevel_sampleCount - 1),
        Usage = ResourceUsage.Default,
        OptionFlags = ResourceOptionFlags.None,
        CpuAccessFlags = CpuAccessFlags.None,
        ArraySize = 1,
      };

      var renderTarget = new Texture2D(device, colordesc);
      var depthStencil = new Texture2D(device, depthdesc);
      var renderTargetView = new RenderTargetView(device, renderTarget);
      var depthStencilView = new DepthStencilView(device, depthStencil);

      // Rendering

      device.OutputMerger.SetTargets(depthStencilView, renderTargetView);
      device.Rasterizer.SetViewports(new Viewport(0, 0, sizeX, sizeY, 0.0f, 1.0f));
      var clearColor = new Color4(1, 1, 1, 0); // Transparent
      if (options.BackgroundBrush != null)
      {
        var axoColor = options.BackgroundBrush.Color.Color;
        clearColor = new Color4(axoColor.ScR, axoColor.ScG, axoColor.ScB, axoColor.ScA);
      }
      device.ClearRenderTargetView(renderTargetView, clearColor);
      device.ClearDepthStencilView(depthStencilView, DepthStencilClearFlags.Depth | DepthStencilClearFlags.Stencil, 1.0f, 0);

      scene.Attach(device, new PointD2D(sizeX, sizeY));
      scene.Render();

      device.Flush();

      Texture2D renderTarget2 = null;

      if (sampleCount > 1) // if renderTarget is an MSAA render target, we first have to copy it into a non-MSAA render target before we can copy it to a CPU texture and then hope to save it
      {
        // create a non-MSAA render target with the same size
        var renderTarget2Description = new Texture2DDescription
        {
          BindFlags = BindFlags.RenderTarget | BindFlags.ShaderResource,
          Format = Format.B8G8R8A8_UNorm_SRgb,
          Width = sizeX,
          Height = sizeY,
          MipLevels = 1,
          SampleDescription = new SampleDescription(1, 0), // non MSAA
          Usage = ResourceUsage.Default,
          OptionFlags = ResourceOptionFlags.Shared,
          CpuAccessFlags = CpuAccessFlags.None,
          ArraySize = 1
        };

        renderTarget2 = new Texture2D(device, renderTarget2Description); // create non-MSAA render target
        device.ResolveSubresource(renderTarget, 0, renderTarget2, 0, renderTarget.Description.Format); // copy from MSAA render target to the non-MSAA render target

        var h = renderTarget; // exchange renderTarget with renderTarget2
        renderTarget = renderTarget2;
        renderTarget2 = h;
      }

      // renderTarget is now a non-MSAA renderTarget
      Texture2DExtensions.SaveToStream(renderTarget, options.ImageFormat, options.DestinationDpiResolution, toStream);

      scene.Detach();

      Disposer.RemoveAndDispose(ref depthStencilView);
      Disposer.RemoveAndDispose(ref renderTargetView);
      Disposer.RemoveAndDispose(ref renderTarget2);
      Disposer.RemoveAndDispose(ref renderTarget);
      Disposer.RemoveAndDispose(ref depthStencil);
      Disposer.RemoveAndDispose(ref device);
    }
  }
}
