﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2016 Dr. Dirk Lellinger
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

namespace Altaxo.Gui.Graph.Graph3D.Common
{
  using System;
  using SharpDX;
  using SharpDX.D3DCompiler;
  using SharpDX.Direct3D10;
  using SharpDX.DXGI;
  using Buffer = SharpDX.Direct3D10.Buffer;
  using Device = SharpDX.Direct3D10.Device;

  public class D3D10GammaCorrector : IDisposable
  {
    private InputLayout _vertexLayout;
    private Buffer _vertices;
    private Effect _effect;
    private Device _cachedDevice;
    private bool _isDisposed = false;

    public D3D10GammaCorrector(Device device, string gammaCorrectorResourcePath)
    {
      if (device == null)
        throw new ArgumentNullException(nameof(device));

      _cachedDevice = device;

      ShaderBytecode shaderBytes = null;
      using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(gammaCorrectorResourcePath))
      {
        if (null == stream)
          throw new InvalidOperationException(string.Format("Compiled shader resource not found: {0}", gammaCorrectorResourcePath));

        using (shaderBytes = ShaderBytecode.FromStream(stream))
        {
          _effect = new Effect(device, shaderBytes);
        }
      }

      EffectTechnique technique = _effect.GetTechniqueByIndex(0);
      EffectPass pass = technique.GetPassByIndex(0);

      _vertexLayout = new InputLayout(device, pass.Description.Signature, new[] {
                                new InputElement("POSITION", 0, Format.R32G32B32A32_Float, 0, 0),
                                new InputElement("TEXCOORD", 0, Format.R32G32_Float, 16, 0) });

      _vertices = Buffer.Create(device, BindFlags.VertexBuffer, new[]
                                       {
                                      // 3D coordinates              UV Texture coordinates
                                       -1.0f, 1.0f, 0.5f, 1.0f,      0.0f, 0.0f,
                                       1.0f, -1.0f, 0.5f, 1.0f,      1.0f, 1.0f,
                                       -1.0f, -1.0f, 0.5f, 1.0f,     0.0f, 1.0f,
                                       -1.0f, 1.0f, 0.5f, 1.0f,      0.0f, 0.0f,
                                       1.0f,  1.0f, 0.5f, 1.0f,      1.0f, 0.0f,
                                       1.0f, -1.0f, 0.5f, 1.0f,      1.0f, 1.0f,
            });
    }

    #region IDisposable Support

    protected virtual void Dispose(bool disposing)
    {
      if (!_isDisposed)
      {
        if (disposing)
        {
          Disposer.RemoveAndDispose(ref _vertexLayout);
          Disposer.RemoveAndDispose(ref _vertices);
          Disposer.RemoveAndDispose(ref _effect);
          _cachedDevice = null;
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        _isDisposed = true;
      }
    }

    public void Dispose()
    {
      Dispose(true);
      // uncomment the following line if the finalizer is overridden.
      // GC.SuppressFinalize(this);
    }

    #endregion IDisposable Support

    public void Render(Device device, ShaderResourceView textureView)
    {
      if (_isDisposed)
        throw new ObjectDisposedException(GetType().Name);

      if (device == null)
        return;

      if (!object.ReferenceEquals(device, _cachedDevice))
        throw new InvalidOperationException(string.Format("Argument {0} and member {1} do not match!", nameof(device), nameof(_cachedDevice)));

      device.InputAssembler.InputLayout = _vertexLayout;
      device.InputAssembler.PrimitiveTopology = SharpDX.Direct3D.PrimitiveTopology.TriangleList;
      device.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(_vertices, 24, 0));

      EffectTechnique technique = _effect.GetTechniqueByIndex(0);
      EffectPass pass = technique.GetPassByIndex(0);
      var shaderResourceObj = _effect.GetVariableByName("ShaderTexture");
      EffectShaderResourceVariable shaderResource = shaderResourceObj.AsShaderResource();
      shaderResource.SetResource(textureView);

      for (int i = 0; i < technique.Description.PassCount; ++i)
      {
        pass.Apply();
        device.Draw(6, 0);
      }
    }
  }
}
