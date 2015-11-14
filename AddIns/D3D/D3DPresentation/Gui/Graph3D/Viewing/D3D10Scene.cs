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

namespace Altaxo.Gui.Graph3D.Viewing
{
	using Altaxo.Geometry;
	using Altaxo.Graph.Graph3D;
	using Altaxo.Graph.Graph3D.Camera;
	using Altaxo.Graph.Graph3D.GraphicsContext.D3D;
	using Altaxo.Gui.Graph3D.Common;
	using SharpDX;
	using SharpDX.D3DCompiler;
	using SharpDX.Direct3D10;
	using SharpDX.DXGI;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Buffer = SharpDX.Direct3D10.Buffer;
	using Device = SharpDX.Direct3D10.Device;

	public class D3D10Scene : ID3D10Scene
	{
		#region Internal structs

		internal struct RenderLayout
		{
			public InputLayout VertexLayout;
			public VertexShader VertexShader;
			public ShaderBytecode VertexShaderByteCode;
			public PixelShader PixelShader;

			public void Dispose()
			{
				Disposer.RemoveAndDispose(ref VertexLayout);
				Disposer.RemoveAndDispose(ref VertexShader);
				Disposer.RemoveAndDispose(ref VertexShaderByteCode);
				Disposer.RemoveAndDispose(ref PixelShader);
			}
		}

		internal struct VertexAndIndexDeviceBuffer
		{
			public IMaterial3D Material;
			public Buffer VertexBuffer;
			public Buffer IndexBuffer;
			public int VertexCount;
			public int IndexCount;

			public void RemoveAndDispose()
			{
				Disposer.RemoveAndDispose(ref VertexBuffer);
				Disposer.RemoveAndDispose(ref IndexBuffer);
				VertexCount = 0;
				IndexCount = 0;
				Material = null;
			}
		}

		#endregion Internal structs

		private Device _hostDevice;

		private PointD2D _hostSize;

		private D3D10GraphicContext _drawing;

		private SceneSettings _sceneSettings;

		protected Buffer _constantBuffer;

		protected Buffer _constantBufferForColor;

		private int _renderCounter;

		private string[] _layoutNames = new string[6] { "P", "PC", "PT", "PN", "PNC", "PNT" };

		private RenderLayout[] _renderLayouts = new RenderLayout[6];

		/// <summary>
		/// The _this triangle buffers. These buffers are used for current rendering
		/// 0: Position, 1: PositionColor, 2: PositionUV, 3: PositionNormal, 4: PositionNormalColor, 5: PositionNormalUV
		/// </summary>
		private List<VertexAndIndexDeviceBuffer>[] _thisTriangleDeviceBuffers = new List<VertexAndIndexDeviceBuffer>[6];

		private List<VertexAndIndexDeviceBuffer>[] _nextTriangleDeviceBuffers = new List<VertexAndIndexDeviceBuffer>[6];

		public void Attach(SharpDX.ComObject hostDevice, PointD2D hostSize)
		{
			Attach((Device)hostDevice, hostSize);
		}

		public void Attach(Device hostDevice, PointD2D hostSize)
		{
			if (hostDevice == null)
				throw new ArgumentNullException(nameof(hostDevice));

			_hostDevice = hostDevice;
			_hostSize = hostSize;

			Device device = _hostDevice;

			int i;

			for (i = 0; i < _layoutNames.Length; ++i)
			{
				var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Altaxo.CompiledShaders.VS." + _layoutNames[i] + "_DULL.cso");
				_renderLayouts[i].VertexShaderByteCode = ShaderBytecode.FromStream(stream);
				_renderLayouts[i].VertexShader = new VertexShader(device, _renderLayouts[i].VertexShaderByteCode);

				stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Altaxo.CompiledShaders.PS." + _layoutNames[i] + "_DULL.cso");
				ShaderBytecode pixelShaderByteCode = ShaderBytecode.FromStream(stream);
				_renderLayouts[i].PixelShader = new PixelShader(device, pixelShaderByteCode);
			}

			i = 0;
			_renderLayouts[i].VertexLayout = new InputLayout(device, ShaderSignature.GetInputSignature(_renderLayouts[i].VertexShaderByteCode), new[] {
								new InputElement("POSITION", 0, Format.R32G32B32A32_Float, 0, 0)
						});

			i = 1;
			_renderLayouts[i].VertexLayout = new InputLayout(device, ShaderSignature.GetInputSignature(_renderLayouts[i].VertexShaderByteCode), new[] {
								new InputElement("POSITION", 0, Format.R32G32B32A32_Float, 0, 0),
								new InputElement("COLOR", 0, Format.R32G32B32A32_Float, 16, 0)
						});

			i = 2;
			_renderLayouts[i].VertexLayout = new InputLayout(device, ShaderSignature.GetInputSignature(_renderLayouts[i].VertexShaderByteCode), new[] {
								new InputElement("POSITION", 0, Format.R32G32B32A32_Float, 0, 0),
								new InputElement("TEXCOORD", 0, Format.R32G32_Float, 16, 0)
						});

			i = 3;
			_renderLayouts[i].VertexLayout = new InputLayout(device, ShaderSignature.GetInputSignature(_renderLayouts[i].VertexShaderByteCode), new[] {
								new InputElement("POSITION", 0, Format.R32G32B32A32_Float, 0, 0),
								new InputElement("NORMAL", 0, Format.R32G32B32A32_Float, 16, 0)
						});

			i = 4;
			_renderLayouts[i].VertexLayout = new InputLayout(device, ShaderSignature.GetInputSignature(_renderLayouts[i].VertexShaderByteCode), new[] {
								new InputElement("POSITION", 0, Format.R32G32B32A32_Float, 0, 0),
								new InputElement("NORMAL", 0, Format.R32G32B32A32_Float, 16, 0),
								new InputElement("COLOR", 0, Format.R32G32B32A32_Float, 32, 0)
						});

			i = 5;
			_renderLayouts[i].VertexLayout = new InputLayout(device, ShaderSignature.GetInputSignature(_renderLayouts[i].VertexShaderByteCode), new[] {
								new InputElement("POSITION", 0, Format.R32G32B32A32_Float, 0, 0),
								new InputElement("NORMAL", 0, Format.R32G32B32A32_Float, 16, 0),
								new InputElement("TEXCOORD", 0, Format.R32G32_Float, 32, 0)
						});

			// Create Constant Buffers
			_constantBuffer = new Buffer(device, Utilities.SizeOf<Matrix>(), ResourceUsage.Default, BindFlags.ConstantBuffer, CpuAccessFlags.None, ResourceOptionFlags.None);
			_constantBufferForColor = new Buffer(device, Utilities.SizeOf<Vector4>(), ResourceUsage.Default, BindFlags.ConstantBuffer, CpuAccessFlags.None, ResourceOptionFlags.None);

			if (_drawing != null)
			{
				BringDrawingIntoBuffers(_drawing);
			}
		}

		public void SetHostSize(PointD2D hostSize)
		{
			_hostSize = hostSize;
		}

		public void SetDrawing(D3D10GraphicContext drawing)
		{
			var olddrawing = _drawing;
			_drawing = drawing;

			if (olddrawing != null)
				olddrawing.Dispose();

			BringDrawingIntoBuffers(drawing);
		}

		public void SetSceneSettings(SceneSettings sceneSettings)
		{
			_sceneSettings = sceneSettings;
		}

		private void UseNextTriangleDeviceBuffers()
		{
			for (int i = 0; i < _nextTriangleDeviceBuffers.Length; ++i)
			{
				if (null != _nextTriangleDeviceBuffers[i])
				{
					var oldBuffers = _thisTriangleDeviceBuffers[i];
					_thisTriangleDeviceBuffers[i] = System.Threading.Interlocked.Exchange(ref _nextTriangleDeviceBuffers[i], null);

					if (null != oldBuffers)
					{
						foreach (var entry in oldBuffers)
							entry.RemoveAndDispose();
					}
				}
			}
		}

		private void BringDrawingIntoBuffers(D3D10GraphicContext drawing)
		{
			Device device = _hostDevice;
			if (device == null)
				return;

			var buffersOfType =
				new IEnumerable<KeyValuePair<IMaterial3D, IndexedTriangleBuffer>>[]
				{
				drawing.PositionIndexedTriangleBuffersAsIndexedTriangleBuffers,
				drawing.PositionColorIndexedTriangleBuffersAsIndexedTriangleBuffers,
				drawing.PositionUVIndexedTriangleBuffersAsIndexedTriangleBuffers,
				drawing.PositionNormalIndexedTriangleBuffersAsIndexedTriangleBuffers,
				drawing.PositionNormalColorIndexedTriangleBuffersAsIndexedTriangleBuffers,
				drawing.PositionNormalUVIndexedTriangleBuffersAsIndexedTriangleBuffers
				};

			for (int i = 0; i < buffersOfType.Length; ++i)
			{
				var newDeviceBuffers = new List<VertexAndIndexDeviceBuffer>();
				foreach (var entry in buffersOfType[i])
				{
					var buf = entry.Value;
					if (buf.TriangleCount == 0)
						continue;

					var vertexBuffer = Buffer.Create<float>(device, buf.VertexStream, new BufferDescription()
					{
						BindFlags = BindFlags.VertexBuffer,
						CpuAccessFlags = CpuAccessFlags.None,
						OptionFlags = ResourceOptionFlags.None,
						SizeInBytes = buf.VertexStreamLength,
						Usage = ResourceUsage.Default
					});

					var indexBuffer = Buffer.Create<int>(device, buf.IndexStream, new BufferDescription()
					{
						BindFlags = BindFlags.IndexBuffer,
						CpuAccessFlags = CpuAccessFlags.None,
						OptionFlags = ResourceOptionFlags.None,
						SizeInBytes = buf.IndexStreamLength,
						Usage = ResourceUsage.Default
					});
					var indexCount = buf.TriangleCount * 3;

					newDeviceBuffers.Add(new VertexAndIndexDeviceBuffer { Material = entry.Key, VertexBuffer = vertexBuffer, VertexCount = buf.VertexCount, IndexBuffer = indexBuffer, IndexCount = indexCount });
				}

				System.Threading.Interlocked.Exchange(ref _nextTriangleDeviceBuffers[i], newDeviceBuffers);
			}

			device.Flush();
		}

		void IScene.Detach()
		{
			if (null != _nextTriangleDeviceBuffers)
				foreach (var bufType in _nextTriangleDeviceBuffers)
					if (null != bufType)
						foreach (var ele in bufType)
							ele.RemoveAndDispose();

			if (null != _thisTriangleDeviceBuffers)
				foreach (var bufType in _thisTriangleDeviceBuffers)
					if (null != bufType)
						foreach (var ele in bufType)
							ele.RemoveAndDispose();

			foreach (var entry in _renderLayouts)
				entry.Dispose();
		}

		void IScene.Update(TimeSpan sceneTime)
		{
			// use sceneTime.TotalSeconds to update the scene here in dependence on the scene time
		}

		void IScene.Render()
		{
			Device device = _hostDevice;
			if (device == null)
				return;

			UseNextTriangleDeviceBuffers();

			float time = _renderCounter / 100f;
			++_renderCounter;

			Matrix view, proj, viewProj;

			Matrix worldViewProjTr; // world-view matrix, transposed

			MatrixD3D viewProjD3D;

			if (null != _sceneSettings)
			{
				var cam = _sceneSettings.Camera;
				var eye = cam.EyePosition;
				var target = cam.TargetPosition;
				var up = cam.UpVector;
				view = Matrix.LookAtRH(new Vector3((float)eye.X, (float)eye.Y, (float)eye.Z), new Vector3((float)target.X, (float)target.Y, (float)target.Z), new Vector3((float)up.X, (float)up.Y, (float)up.Z));
				if (cam is PerspectiveCamera)
				{
					var angle = (cam as PerspectiveCamera).Angle;
					proj = Matrix.PerspectiveFovRH((float)angle, (float)(_hostSize.X / _hostSize.Y), 0.1f, float.MaxValue);
					viewProj = Matrix.Multiply(view, proj);

					// Update WorldViewProj Matrix
					worldViewProjTr = viewProj;
					worldViewProjTr.Transpose();
				}
				else if (cam is OrthographicCamera)
				{
					viewProjD3D = (cam as OrthographicCamera).GetLookAtRHTimesOrthoRHMatrix(_hostSize.Y / _hostSize.X);

					worldViewProjTr = new Matrix(
						(float)viewProjD3D.M11, (float)viewProjD3D.M21, (float)viewProjD3D.M31, (float)viewProjD3D.M41,
						(float)viewProjD3D.M12, (float)viewProjD3D.M22, (float)viewProjD3D.M32, (float)viewProjD3D.M42,
						(float)viewProjD3D.M13, (float)viewProjD3D.M23, (float)viewProjD3D.M33, (float)viewProjD3D.M43,
						0, 0, 0, 1
						);
				}
				else
				{
					throw new NotImplementedException();
				}
			}
			else
			{
				view = Matrix.LookAtRH(new Vector3(0, 0, -1500), new Vector3(0, 0, 0), Vector3.UnitY);
				proj = Matrix.PerspectiveFovRH((float)Math.PI / 4.0f, (float)(_hostSize.X / _hostSize.Y), 0.1f, float.MaxValue);
				viewProj = Matrix.Multiply(view, proj);

				// Update WorldViewProj Matrix
				worldViewProjTr = viewProj;
				worldViewProjTr.Transpose();
			}

			foreach (var entry in _thisTriangleDeviceBuffers[1]) // Position-Color
			{
				DrawPositionColorIndexedTriangleBuffer(device, entry, worldViewProjTr);
			}

			foreach (var entry in _thisTriangleDeviceBuffers[3]) // Position-Normal
			{
				DrawPositionNormalIndexedTriangleBuffer(device, entry, worldViewProjTr);
			}

			foreach (var entry in _thisTriangleDeviceBuffers[4]) // Position-Normal-Color
			{
				DrawPositionNormalColorIndexedTriangleBuffer(device, entry, worldViewProjTr);
			}
		}

		private void DrawPositionColorIndexedTriangleBuffer(Device device, VertexAndIndexDeviceBuffer deviceBuffers, Matrix worldViewProj)
		{
			int layoutNumber = 1;
			device.InputAssembler.InputLayout = _renderLayouts[layoutNumber].VertexLayout;
			device.InputAssembler.PrimitiveTopology = SharpDX.Direct3D.PrimitiveTopology.TriangleList;

			device.VertexShader.SetConstantBuffer(0, _constantBuffer);

			device.VertexShader.Set(_renderLayouts[layoutNumber].VertexShader);
			device.PixelShader.Set(_renderLayouts[layoutNumber].PixelShader);

			device.UpdateSubresource(ref worldViewProj, _constantBuffer);

			device.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(deviceBuffers.VertexBuffer, 32, 0));
			device.InputAssembler.SetIndexBuffer(deviceBuffers.IndexBuffer, Format.R32_UInt, 0);
			device.DrawIndexed(deviceBuffers.IndexCount, 0, 0);
		}

		private void DrawPositionNormalColorIndexedTriangleBuffer(Device device, VertexAndIndexDeviceBuffer deviceBuffers, Matrix worldViewProj)
		{
			int layoutNumber = 4;
			device.InputAssembler.InputLayout = _renderLayouts[layoutNumber].VertexLayout;
			device.InputAssembler.PrimitiveTopology = SharpDX.Direct3D.PrimitiveTopology.TriangleList;
			device.VertexShader.SetConstantBuffer(0, _constantBuffer);

			device.VertexShader.Set(_renderLayouts[layoutNumber].VertexShader);
			device.PixelShader.Set(_renderLayouts[layoutNumber].PixelShader);

			device.UpdateSubresource(ref worldViewProj, _constantBuffer);

			device.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(deviceBuffers.VertexBuffer, 48, 0));
			device.InputAssembler.SetIndexBuffer(deviceBuffers.IndexBuffer, Format.R32_UInt, 0);
			device.DrawIndexed(deviceBuffers.IndexCount, 0, 0);
		}

		private void DrawPositionNormalIndexedTriangleBuffer(Device device, VertexAndIndexDeviceBuffer deviceBuffers, Matrix worldViewProj)
		{
			int layoutNumber = 3;
			device.InputAssembler.InputLayout = _renderLayouts[layoutNumber].VertexLayout;
			device.InputAssembler.PrimitiveTopology = SharpDX.Direct3D.PrimitiveTopology.TriangleList;
			device.VertexShader.SetConstantBuffer(0, _constantBuffer);
			device.VertexShader.SetConstantBuffer(1, _constantBufferForColor);

			device.VertexShader.Set(_renderLayouts[layoutNumber].VertexShader);
			device.PixelShader.Set(_renderLayouts[layoutNumber].PixelShader);

			device.UpdateSubresource(ref worldViewProj, _constantBuffer);

			var color = deviceBuffers.Material.Color.Color;
			Vector4 colorVec = new Vector4(color.ScR, color.ScG, color.ScB, color.ScA);
			device.UpdateSubresource(ref colorVec, _constantBufferForColor);

			device.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(deviceBuffers.VertexBuffer, 32, 0));
			device.InputAssembler.SetIndexBuffer(deviceBuffers.IndexBuffer, Format.R32_UInt, 0);
			device.DrawIndexed(deviceBuffers.IndexCount, 0, 0);
		}
	}
}