﻿// Copyright (c) 2010-2013 SharpDX - Alexandre Mutel
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// -----------------------------------------------------------------------------
// Original code from SlimMath project. http://code.google.com/p/slimmath/
// Greetings to SlimDX Group. Original code published with the following license:
// -----------------------------------------------------------------------------
/*
* Copyright (c) 2007-2011 SlimDX Group
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/

namespace Altaxo.Gui.Graph3D.Viewing
{
	using Altaxo.Gui.Graph3D.Common;
	using SharpDX;
	using SharpDX.D3DCompiler;
	using SharpDX.Direct3D10;
	using SharpDX.DXGI;
	using System;
	using Buffer = SharpDX.Direct3D10.Buffer;
	using Device = SharpDX.Direct3D10.Device;

	public class Scene : IScene
	{
		private ISceneHost Host;
		private InputLayout VertexLayout;
		private DataStream VertexStream;
		private Buffer _nonindexedTriangleVerticesPositionColor;
		private int _nonindexedTriangleVerticesPositionColor_Count;

		private Effect SimpleEffect;
		private Color4 OverlayColor = new Color4(1.0f);

		private Buffer IndexedVertices;
		private Buffer IndexedVerticesIndexes;
		private int IndexedVerticesIndexes_Count;

		private D3D10GraphicContext _drawing;

		void IScene.Attach(ISceneHost host)
		{
			this.Host = host;

			Device device = host.Device;
			if (device == null)
				throw new Exception("Scene host device is null");

			var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Altaxo.CompiledShaders.Simple.cso");
			ShaderBytecode shaderBytes = ShaderBytecode.FromStream(stream);

			// ShaderBytecode shaderBytes = ShaderBytecode.CompileFromFile("Simple.fx", "fx_4_0", ShaderFlags.None, EffectFlags.None, null, null);

			this.SimpleEffect = new Effect(device, shaderBytes);

			EffectTechnique technique = this.SimpleEffect.GetTechniqueByIndex(0); ;
			EffectPass pass = technique.GetPassByIndex(0);

			this.VertexLayout = new InputLayout(device, pass.Description.Signature, new[] {
								new InputElement("POSITION", 0, Format.R32G32B32A32_Float, 0, 0),
								new InputElement("COLOR", 0, Format.R32G32B32A32_Float, 16, 0)
						});

			if (_drawing != null)
			{
				BringDrawingIntoBuffers(_drawing);
			}
			else
			{
				this.VertexStream = new DataStream(3 * 32, true, true);
				this.VertexStream.WriteRange(new[] {
								new Vector4(0.0f, 0.5f, 0.5f, 1.0f), new Vector4(1.0f, 0.0f, 0.0f, 1f),
								new Vector4(0.5f, -0.5f, 0.5f, 1.0f), new Vector4(1.0f, 0.0f, 0.0f, 1f),
								new Vector4(-0.5f, -0.5f, 0.5f, 1.0f), new Vector4(1.0f, 0.0f, 0.0f, 1f)
						});
				this.VertexStream.Position = 0;

				this._nonindexedTriangleVerticesPositionColor = new Buffer(device, this.VertexStream, new BufferDescription()
				{
					BindFlags = BindFlags.VertexBuffer,
					CpuAccessFlags = CpuAccessFlags.None,
					OptionFlags = ResourceOptionFlags.None,
					SizeInBytes = 3 * 32,
					Usage = ResourceUsage.Default
				}
				);
				device.Flush();
			}
		}

		public void SetDrawing(D3D10GraphicContext drawing)
		{
			var olddrawing = _drawing;
			_drawing = drawing;

			if (olddrawing != null)
				olddrawing.Dispose();

			BringDrawingIntoBuffers(drawing);
		}

		private void BringDrawingIntoBuffers(D3D10GraphicContext drawing)
		{
			Device device = this.Host?.Device;
			if (device == null)
				return;
			{
				Disposer.RemoveAndDispose(ref this._nonindexedTriangleVerticesPositionColor);
				var buf = drawing.BuffersNonindexedTrianglesPositionColor;
				if (null != buf && 0 != buf.VertexCount)
				{
					buf.VertexStream.Position = 0;
					this._nonindexedTriangleVerticesPositionColor = new Buffer(device, buf.VertexStream, new BufferDescription()
					{
						BindFlags = BindFlags.VertexBuffer,
						CpuAccessFlags = CpuAccessFlags.None,
						OptionFlags = ResourceOptionFlags.None,
						SizeInBytes = (int)buf.VertexStreamLength,
						Usage = ResourceUsage.Default
					});
					this._nonindexedTriangleVerticesPositionColor_Count = buf.VertexCount;
				}
			}

			// IndexedTriangles Position Color

			{
				Disposer.RemoveAndDispose(ref this.IndexedVertices);
				Disposer.RemoveAndDispose(ref this.IndexedVerticesIndexes);
				var buf = drawing.BuffersIndexTrianglesPositionColor;
				if (null != buf && buf.TriangleCount > 0)
				{
					buf.VertexStream.Position = 0;
					this.IndexedVertices = new Buffer(device, buf.VertexStream, new BufferDescription()
					{
						BindFlags = BindFlags.VertexBuffer,
						CpuAccessFlags = CpuAccessFlags.None,
						OptionFlags = ResourceOptionFlags.None,
						SizeInBytes = buf.VertexStreamLength,
						Usage = ResourceUsage.Default
					});

					buf.IndexStream.Position = 0;
					this.IndexedVerticesIndexes = new Buffer(device, buf.IndexStream, new BufferDescription()
					{
						BindFlags = BindFlags.IndexBuffer,
						CpuAccessFlags = CpuAccessFlags.None,
						OptionFlags = ResourceOptionFlags.None,
						SizeInBytes = buf.IndexStreamLength,
						Usage = ResourceUsage.Default
					});
					this.IndexedVerticesIndexes_Count = buf.TriangleCount * 3;
				}
			}

			device.Flush();
		}

		void IScene.Detach()
		{
			Disposer.RemoveAndDispose(ref this._nonindexedTriangleVerticesPositionColor);
			Disposer.RemoveAndDispose(ref this.VertexLayout);
			Disposer.RemoveAndDispose(ref this.SimpleEffect);
			Disposer.RemoveAndDispose(ref this.VertexStream);
		}

		void IScene.Update(TimeSpan sceneTime)
		{
			float t = (float)(0.5 * (1 + Math.Sin(sceneTime.TotalSeconds)));
			this.OverlayColor = new Color4(t, t, t, t);
		}

		void IScene.Render()
		{
			Device device = this.Host.Device;
			if (device == null)
				return;

			// device.ClearRenderTargetView(RenderTargetView, new Color4(0x0000FFFF));

			if (null != _nonindexedTriangleVerticesPositionColor)
			{
				device.InputAssembler.InputLayout = this.VertexLayout;
				device.InputAssembler.PrimitiveTopology = SharpDX.Direct3D.PrimitiveTopology.TriangleList;
				device.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(this._nonindexedTriangleVerticesPositionColor, 32, 0));

				EffectTechnique technique = this.SimpleEffect.GetTechniqueByIndex(0);
				EffectPass pass = technique.GetPassByIndex(0);

				EffectVectorVariable overlayColor = this.SimpleEffect.GetVariableBySemantic("OverlayColor").AsVector();

				overlayColor.Set(this.OverlayColor);

				for (int i = 0; i < technique.Description.PassCount; ++i)
				{
					pass.Apply();
					device.Draw(_nonindexedTriangleVerticesPositionColor_Count, 0);
				}
			}

			if (null != this.IndexedVerticesIndexes && null != IndexedVertices)
			{
				// Indexed vertices position color

				device.InputAssembler.InputLayout = this.VertexLayout;
				device.InputAssembler.PrimitiveTopology = SharpDX.Direct3D.PrimitiveTopology.TriangleList;
				device.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(this.IndexedVertices, 32, 0));
				device.InputAssembler.SetIndexBuffer(this.IndexedVerticesIndexes, Format.R32_UInt, 0);

				EffectTechnique technique = this.SimpleEffect.GetTechniqueByIndex(0);
				EffectPass pass = technique.GetPassByIndex(0);

				EffectVectorVariable overlayColor = this.SimpleEffect.GetVariableBySemantic("OverlayColor").AsVector();

				overlayColor.Set(this.OverlayColor);

				for (int i = 0; i < technique.Description.PassCount; ++i)
				{
					pass.Apply();
					device.DrawIndexed(IndexedVerticesIndexes_Count, 0, 0);
				}
			}
		}
	}
}