﻿#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2007 Dr. Dirk Lellinger
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
//    along with ctrl program; if not, write to the Free Software
//    Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
//
/////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Altaxo.Graph.Gdi
{
	/// <summary>
	/// Enumerates the area which is to be exported.
	/// </summary>
	public enum GraphExportArea
	{
		/// <summary>Area is the whole page size.</summary>
		Page,
		/// <summary>The printable area of the page.</summary>
		PrintableArea,
		/// <summary>The bounding box of all graph items.</summary>
		BoundingBox
	}

	public class GraphExportOptions
	{
		public ImageFormat _imageFormat;
		public PixelFormat _pixelFormat;
		public BrushX _backgroundBrush;
		public double _sourceDpiResolution;
		public double _destinationDpiResolution;

		public ImageFormat ImageFormat { get { return _imageFormat; } }
		public PixelFormat PixelFormat { get { return _pixelFormat; } }
		public GraphExportArea ExportArea { get; set; }
		public BrushX BackgroundBrush
		{
			get
			{
				return _backgroundBrush;
			}
			set
			{
				_backgroundBrush = value;
			}
		}

		public double SourceDpiResolution 
		{
			get
			{
				return _sourceDpiResolution;
			}
			set
			{
				if(!(value>0))
					throw new ArgumentException("SourceDpiResolution has to be >0");

				_sourceDpiResolution = value;
			}
		}

		public double DestinationDpiResolution
		{
			get
			{
				return _destinationDpiResolution;
			}
			set
			{
				if(!(value>0))
					throw new ArgumentException("DestinationDpiResolution has to be >0");

				_destinationDpiResolution = value;
			}
		}


		public GraphExportOptions()
		{
			this._imageFormat = System.Drawing.Imaging.ImageFormat.Emf;
			this._pixelFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
			this.ExportArea = GraphExportArea.PrintableArea;
			this.SourceDpiResolution = 300;
			this.DestinationDpiResolution = 300;
			this.BackgroundBrush = null;
		}

		public bool TrySetImageAndPixelFormat(ImageFormat imgfmt, PixelFormat pixfmt)
		{
			if (!IsVectorFormat(imgfmt) && !CanCreateAndSaveBitmap(imgfmt, pixfmt))
				return false;

			_imageFormat = imgfmt;
			_pixelFormat = pixfmt;

			return true;
		}

		public Brush GetDefaultBrush()
		{
			if (IsVectorFormat(_imageFormat) || HasPixelFormatAlphaChannel(_pixelFormat))
				return null;
			else 
				return new SolidBrush(Color.White);
		}

		public Brush GetBrushOrDefaultBrush()
		{
			if (null != _backgroundBrush)
				return _backgroundBrush;
			else
				return GetDefaultBrush();
		}

		public void CopyFrom(object fr)
		{
			var from = fr as GraphExportOptions;
			if (null == from)
				throw new ArgumentException("Argument either null or has wrong type");

			this._imageFormat = from.ImageFormat;
			this._pixelFormat = from.PixelFormat;
			this.SourceDpiResolution = from.SourceDpiResolution;
			this.DestinationDpiResolution = from.DestinationDpiResolution;
			this.ExportArea = from.ExportArea;
		}

		static GraphExportOptions _currentSetting = new GraphExportOptions();
		public static GraphExportOptions CurrentSetting
		{
			get
			{
				return _currentSetting;
			}
		}

		public static bool IsVectorFormat(ImageFormat fmt)
		{
			return ImageFormat.Emf==fmt || ImageFormat.Wmf==fmt;
		}

		public static bool CanCreateBitmap(PixelFormat fmt)
		{
			try
			{
				var bmp = new Bitmap(4, 4, fmt);
				bmp.Dispose();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool CanCreateAndSaveBitmap(ImageFormat imgfmt, PixelFormat pixfmt)
		{
			try
			{
				using (var bmp = new Bitmap(8, 8, pixfmt))
				{

					using (var str = new System.IO.MemoryStream())
					{
						bmp.Save(str, imgfmt);
						str.Close();
					}
				}
				
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool HasPixelFormatAlphaChannel(PixelFormat fmt)
		{
			return
				PixelFormat.Alpha == fmt ||
				PixelFormat.Canonical == fmt ||
				PixelFormat.Format16bppArgb1555 == fmt ||
				PixelFormat.Format32bppArgb == fmt ||
				PixelFormat.Format32bppPArgb == fmt ||
				PixelFormat.Format64bppArgb == fmt ||
				PixelFormat.Format64bppPArgb == fmt ||
				PixelFormat.PAlpha == fmt;
		}

	}

	/// <summary>
	/// Routines to export graphs as bitmap
	/// </summary>
	public static class GraphExport
	{


		#region Stream und file

		public static void Render(this GraphDocument doc, System.IO.Stream stream, GraphExportOptions options)
		{
			if (options.ImageFormat == ImageFormat.Wmf || options.ImageFormat == ImageFormat.Emf)
				doc.RenderAsMetafile(stream, options);
			else
				doc.RenderAsBitmap(stream, options);
		}

		public static void Render(this GraphDocument doc, string filename, GraphExportOptions options)
		{
			using (System.IO.Stream str = new System.IO.FileStream(filename, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.Read))
			{
				Render(doc, str, options);
				str.Close();
			}
		}

		#endregion

		#region Bitmap

		#region main work

		/// <summary>
		/// Saves the graph as an bitmap file and returns the bitmap.
		/// </summary>
		/// <param name="doc">The graph document to export.</param>
		/// <param name="dpiResolution">Resolution of the bitmap in dpi. Determines the pixel size of the bitmap.</param>
		/// <param name="backbrush">Brush used to fill the background of the image. Can be <c>null</c>.</param>
		/// <param name="pixelformat">Specify the pixelformat here.</param>
		/// <returns>The saved bitmap. You should call Dispose when you no longer need the bitmap.</returns>
		public static Bitmap RenderAsBitmap(this GraphDocument doc, Brush backbrush, PixelFormat pixelformat, GraphExportArea areaToExport, double sourceDpiResolution, double destinationDpiResolution)
		{
			double scale = sourceDpiResolution / 72.0;
			// Code to write the stream goes here.
			int width, height;
			if (areaToExport == GraphExportArea.Page)
			{
				// round the pixels to multiples of 4, many programs rely on this
				width = (int)(4 * Math.Ceiling(0.25 * doc.PageBounds.Width * scale));
				height = (int)(4 * Math.Ceiling(0.25 * doc.PageBounds.Height * scale));
			}
			else if (areaToExport == GraphExportArea.PrintableArea) // usePrintableBounds
			{
				// round the pixels to multiples of 4, many programs rely on this
				width = (int)(4 * Math.Ceiling(0.25 * doc.PrintableBounds.Width * scale));
				height = (int)(4 * Math.Ceiling(0.25 * doc.PrintableBounds.Height * scale));
			}
			else if (areaToExport == GraphExportArea.BoundingBox)
			{
				// round the pixels to multiples of 4, many programs rely on this
				width = (int)(4 * Math.Ceiling(0.25 * doc.PrintableBounds.Width * scale));
				height = (int)(4 * Math.Ceiling(0.25 * doc.PrintableBounds.Height * scale));
			}
			else
			{
				throw new ArgumentException("areaToExport unkown: " + areaToExport.ToString());
			}

			System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(width, height, pixelformat);

			bitmap.SetResolution((float)sourceDpiResolution, (float)sourceDpiResolution);

			Graphics grfx = Graphics.FromImage(bitmap);
			if (null != backbrush)
				grfx.FillRectangle(backbrush, new Rectangle(0, 0, width, height));

			grfx.PageUnit = GraphicsUnit.Point;

			switch (areaToExport)
			{
				default:
				case GraphExportArea.Page:
					grfx.TranslateTransform(doc.PrintableBounds.X, doc.PrintableBounds.Y);
					break;
				case GraphExportArea.PrintableArea:
					break;
			}
			grfx.PageScale = 1; // (float)scale;


			doc.DoPaint(grfx, true);

			grfx.Dispose();

			bitmap.SetResolution((float)destinationDpiResolution, (float)destinationDpiResolution);

			return bitmap;
		}


		#endregion

		#region stream

		/// <summary>
		/// Saves the graph as an bitmap file into the stream <paramref name="stream"/>.
		/// </summary>
		/// <param name="doc">The graph document to export.</param>
		/// <param name="stream">The stream to save the metafile into.</param>
		/// <param name="dpiResolution">Resolution of the bitmap in dpi. Determines the pixel size of the bitmap.</param>
		/// <param name="imageFormat">The format of the destination image.</param>
		/// <param name="backbrush">Brush used to fill the background of the image. Can be <c>null</c>.</param>
		/// <param name="pixelformat">Specify the pixelformat here.</param>
		public static void RenderAsBitmap(this GraphDocument doc, System.IO.Stream stream, System.Drawing.Imaging.ImageFormat imageFormat, Brush backbrush, PixelFormat pixelformat, GraphExportArea usePageBounds, double sourceDpiResolution, double destinationDpiResolution)
		{
			System.Drawing.Bitmap bitmap = RenderAsBitmap(doc, backbrush, pixelformat, usePageBounds, sourceDpiResolution, destinationDpiResolution);

			bitmap.Save(stream, imageFormat);

			bitmap.Dispose();
		}

		/// <summary>
		/// Saves the graph as an bitmap file into the stream using the default pixelformat 32bppArgb and no background brush.<paramref name="stream"/>.
		/// </summary>
		/// <param name="doc">The graph document to export.</param>
		/// <param name="stream">The stream to save the metafile into.</param>
		/// <param name="dpiResolution">Resolution of the bitmap in dpi. Determines the pixel size of the bitmap.</param>
		/// <param name="imageFormat">The format of the destination image.</param>
		public static void RenderAsBitmap(this GraphDocument doc, System.IO.Stream stream, System.Drawing.Imaging.ImageFormat imageFormat, GraphExportArea usePageBounds, double dpiResolution)
		{
			RenderAsBitmap(doc, stream, imageFormat, null, PixelFormat.Format32bppArgb, usePageBounds, dpiResolution, dpiResolution);
		}


		/// <summary>
		/// Saves the graph as an bitmap file into the stream using the default pixelformat 32bppArgb.<paramref name="stream"/>.
		/// </summary>
		/// <param name="doc">The graph document to export.</param>
		/// <param name="stream">The stream to save the metafile into.</param>
		/// <param name="dpiResolution">Resolution of the bitmap in dpi. Determines the pixel size of the bitmap.</param>
		/// <param name="imageFormat">The format of the destination image.</param>
		/// <param name="backbrush">Brush used to fill the background of the image. Can be <c>null</c>.</param>
		public static void RenderAsBitmap(this GraphDocument doc, System.IO.Stream stream, System.Drawing.Imaging.ImageFormat imageFormat, Brush backbrush, GraphExportArea usePageBounds, double dpiResolution)
		{
			RenderAsBitmap(doc, stream, imageFormat, backbrush, PixelFormat.Format32bppArgb, usePageBounds, dpiResolution, dpiResolution);
		}

		public static void RenderAsBitmap(this GraphDocument doc, System.IO.Stream stream, GraphExportOptions options)
		{
			RenderAsBitmap(doc, stream, options.ImageFormat, options.GetBrushOrDefaultBrush(), options.PixelFormat, options.ExportArea, options.SourceDpiResolution, options.DestinationDpiResolution);
		}
	

		#endregion


		#region file name

		/// <summary>
		/// Saves the graph as an bitmap file into the file <paramref name="filename"/>.
		/// </summary>
		/// <param name="doc">The graph document to export.</param>
		/// <param name="filename">The filename of the file to save the bitmap into.</param>
		/// <param name="dpiResolution">Resolution of the bitmap in dpi. Determines the pixel size of the bitmap.</param>
		/// <param name="imageFormat">The format of the destination image.</param>
		/// <param name="backbrush">Brush used to fill the background of the image. Can be <c>null</c>.</param>
		/// <param name="pixelformat">Specify the pixelformat here.</param>
		public static void RenderAsBitmap(this GraphDocument doc, string filename, System.Drawing.Imaging.ImageFormat imageFormat, Brush backbrush, PixelFormat pixelformat, GraphExportArea usePageBounds, double sourceDpiResolution, double destinationDpiResolution)
		{
			using (System.IO.Stream str = new System.IO.FileStream(filename, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.Read))
			{
				RenderAsBitmap(doc, str, imageFormat, backbrush, pixelformat, usePageBounds, sourceDpiResolution, destinationDpiResolution);
				str.Close();
			}
		}

		/// <summary>
		/// Saves the graph as an bitmap file into the file <paramref name="filename"/> using the default
		/// pixel format 32bppArgb and no background brush.
		/// </summary>
		/// <param name="doc">The graph document to export.</param>
		/// <param name="filename">The filename of the file to save the bitmap into.</param>
		/// <param name="dpiResolution">Resolution of the bitmap in dpi. Determines the pixel size of the bitmap.</param>
		/// <param name="imageFormat">The format of the destination image.</param>
		public static void RenderAsBitmap(this GraphDocument doc, string filename, System.Drawing.Imaging.ImageFormat imageFormat, GraphExportArea usePageBounds, double dpiResolution)
		{
			RenderAsBitmap(doc, filename, imageFormat, null, usePageBounds, dpiResolution);
		}

		/// <summary>
		/// Saves the graph as an bitmap file into the file <paramref name="filename"/> using the default
		/// pixel format 32bppArgb.
		/// </summary>
		/// <param name="doc">The graph document to export.</param>
		/// <param name="filename">The filename of the file to save the bitmap into.</param>
		/// <param name="dpiResolution">Resolution of the bitmap in dpi. Determines the pixel size of the bitmap.</param>
		/// <param name="imageFormat">The format of the destination image.</param>
		/// <param name="backbrush">Brush used to fill the background of the image. Can be <c>null</c>.</param>
		public static void RenderAsBitmap(this GraphDocument doc, string filename, System.Drawing.Imaging.ImageFormat imageFormat, Brush backbrush, GraphExportArea usePageBounds, double dpiResolution)
		{
			RenderAsBitmap(doc, filename, imageFormat, backbrush, PixelFormat.Format32bppArgb, usePageBounds, dpiResolution, dpiResolution);
		}

		public static void RenderAsBitmap(this GraphDocument doc, string filename, GraphExportOptions options)
		{
			RenderAsBitmap(doc, filename, options.ImageFormat, options.BackgroundBrush, options.PixelFormat, options.ExportArea, options.SourceDpiResolution, options.DestinationDpiResolution);
		}

	
		#endregion

		#region Bitmap

		public static Bitmap RenderAsBitmap(this GraphDocument doc, GraphExportOptions options)
		{
			return RenderAsBitmap(doc, options.BackgroundBrush, options.PixelFormat, options.ExportArea, options.SourceDpiResolution, options.DestinationDpiResolution);
		}
		#endregion


		#endregion

		#region Metafile

		#region Main work

		/// <summary>
		/// Saves the graph as an enhanced windows metafile into the stream <paramref name="stream"/>.
		/// </summary>
		/// <param name="grfx">The graphics context used to create the metafile.</param>
		/// <param name="doc">The graph document used.</param>
		/// <param name="stream">The stream to save the metafile into.</param>
		/// <param name="dpiResolution">Resolution of the bitmap in dpi. Determines the pixel size of the bitmap.</param>
		/// <param name="backbrush">Brush used to fill the background of the image. Can be <c>null</c>.</param>
		/// <param name="pixelformat">The pixel format to use.</param>
		/// <returns>The metafile that was created using the stream.</returns>
		public static Metafile RenderAsMetafile(GraphDocument doc, Graphics grfx, System.IO.Stream stream, Brush backbrush, PixelFormat pixelformat, GraphExportArea area, double scale)
		{
			bool usePageBoundaries = false;

			grfx.PageUnit = GraphicsUnit.Point;
			IntPtr ipHdc = grfx.GetHdc();

			RectangleF metaFileBounds;
			switch (area)
			{
				case GraphExportArea.Page:
					metaFileBounds = new RectangleF(0, 0, (float)(doc.PageBounds.Width * scale), (float)(doc.PageBounds.Height * scale));
					break;
				default:
				case GraphExportArea.PrintableArea:
					metaFileBounds = new RectangleF(0, 0, (float)(doc.PrintableSize.Width * scale), (float)(doc.PrintableSize.Height * scale));
					break;
			}

			System.Drawing.Imaging.Metafile mf = new System.Drawing.Imaging.Metafile(stream, ipHdc, metaFileBounds, MetafileFrameUnit.Point);
			using (Graphics grfx2 = Graphics.FromImage(mf))
			{

				if (Environment.OSVersion.Version.Major < 6 || !mf.GetMetafileHeader().IsDisplay())
				{
					grfx2.PageUnit = GraphicsUnit.Point;
					grfx2.PageScale = (float)scale; // that would not work properly (a bug?) in Windows Vista, instead we have to use the following:
				}
				else
				{
					grfx2.PageScale = (float)(scale * Math.Min(72.0f / grfx2.DpiX, 72.0f / grfx2.DpiY)); // this works in Vista with display mode
				}

				switch (area)
				{
					case GraphExportArea.Page:
						grfx2.TranslateTransform(doc.PrintableBounds.X, doc.PrintableBounds.Y);
						break;
				}

				doc.DoPaint(grfx2, true);

				grfx2.Dispose();
			}

			grfx.ReleaseHdc(ipHdc);



			return mf;
		}

		/// <summary>
		/// Saves the graph as an enhanced windows metafile into the stream <paramref name="stream"/>.
		/// </summary>
		/// <param name="doc">The graph document used.</param>
		/// <param name="stream">The stream to save the metafile into.</param>
		/// <param name="backbrush">Brush used to fill the background of the image. Can be <c>null</c>.</param>
		/// <param name="pixelformat">The pixel format to use.</param>
		/// <param name="dpiResolution">Resolution of the bitmap in dpi. Determines the pixel size of the bitmap.</param>
		/// <returns>The metafile that was created using the stream.</returns>
		public static Metafile RenderAsMetafile(this GraphDocument doc, System.IO.Stream stream, Brush backbrush, PixelFormat pixelformat, GraphExportArea area, double sourceDpiResolution, double destinationDpiResolution)
		{
			Metafile mf = null;

			// it is preferable to use a graphics context from a printer to create the metafile, in this case
			// the metafile will become device independent (metaFile.GetMetaFileHeader().IsDisplay() will return false)
			// Only when no printer is installed, we use a graphics context from a bitmap, but this will lead
			// to wrong positioning / wrong boundaries depending on the current screen
			if (Current.PrintingService != null &&
				Current.PrintingService.PrintDocument != null &&
				Current.PrintingService.PrintDocument.PrinterSettings != null
				)
			{
				Graphics grfx = Current.PrintingService.PrintDocument.PrinterSettings.CreateMeasurementGraphics();
				mf = RenderAsMetafile(doc, grfx, stream, backbrush, pixelformat, area, sourceDpiResolution / destinationDpiResolution);
				grfx.Dispose();
			}
			else
			{
				// Create a bitmap just to get a graphics context from it
				System.Drawing.Bitmap helperbitmap = new System.Drawing.Bitmap(4, 4, pixelformat);
				helperbitmap.SetResolution((float)sourceDpiResolution, (float)sourceDpiResolution);
				Graphics grfx = Graphics.FromImage(helperbitmap);
				grfx.PageUnit = GraphicsUnit.Point;
				mf = RenderAsMetafile(doc, grfx, stream, backbrush, pixelformat, area, sourceDpiResolution / destinationDpiResolution);
				grfx.Dispose();
				helperbitmap.Dispose();
			}

			return mf;
		}


		

		#endregion

		#region with stream

		public static Metafile RenderAsMetafile(this GraphDocument doc, System.IO.Stream stream, GraphExportOptions options)
		{
			return RenderAsMetafile(doc, stream, options.BackgroundBrush, options.PixelFormat, options.ExportArea, options.SourceDpiResolution, options.DestinationDpiResolution);
		}

		/// <summary>
		/// Saves the graph as an bitmap file into the stream using the default pixelformat 32bppArgb.<paramref name="stream"/>.
		/// </summary>
		/// <param name="doc">The graph document to export.</param>
		/// <param name="stream">The stream to save the metafile into.</param>
		/// <param name="backbrush">Brush used to fill the background of the image. Can be <c>null</c>.</param>
		/// <param name="dpiResolution">Resolution of the bitmap in dpi. Determines the pixel size of the bitmap.</param>
		public static Metafile RenderAsMetafile(this GraphDocument doc, System.IO.Stream stream, Brush backbrush, double sourceDpiResolution, double destinationDpiResolution)
		{
			return RenderAsMetafile(doc, stream, backbrush, PixelFormat.Format32bppArgb, GraphExportArea.PrintableArea, sourceDpiResolution, destinationDpiResolution);
		}

		/// <summary>
		/// Saves the graph as an bitmap file into the stream using the default pixelformat 32bppArgb and no background brush.<paramref name="stream"/>.
		/// </summary>
		/// <param name="doc">The graph document to export.</param>
		/// <param name="stream">The stream to save the metafile into.</param>
		/// <param name="dpiResolution">Resolution of the bitmap in dpi. Determines the pixel size of the bitmap.</param>
		public static Metafile RenderAsMetafile(this GraphDocument doc, System.IO.Stream stream, double dpiResolution)
		{
			return RenderAsMetafile(doc, stream, null, PixelFormat.Format32bppArgb, GraphExportArea.PrintableArea, dpiResolution, dpiResolution);
		}



		#endregion

		#region with filename

		public static Metafile RenderAsMetafile(this GraphDocument doc, string filename, GraphExportOptions options)
		{
			Metafile mf;
			using (System.IO.Stream str = new System.IO.FileStream(filename, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.Read))
			{
				mf = RenderAsMetafile(doc, str, options.BackgroundBrush, options.PixelFormat, options.ExportArea, options.SourceDpiResolution, options.DestinationDpiResolution);
				str.Close();
			}
			return mf;
		}

		/// <summary>
		/// Saves the graph as an bitmap file into the file <paramref name="filename"/>.
		/// </summary>
		/// <param name="doc">The graph document to export.</param>
		/// <param name="filename">The filename of the file to save the bitmap into.</param>
		/// <param name="backbrush">Brush used to fill the background of the image. Can be <c>null</c>.</param>
		/// <param name="pixelformat">Specify the pixelformat here.</param>
		/// <param name="dpiResolution">Resolution of the bitmap in dpi. Determines the pixel size of the bitmap.</param>
		public static Metafile RenderAsMetafile(this GraphDocument doc, string filename, Brush backbrush, PixelFormat pixelformat, double dpiResolution)
		{
			Metafile mf;
			using (System.IO.Stream str = new System.IO.FileStream(filename, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.Read))
			{
				mf = RenderAsMetafile(doc, str, backbrush, pixelformat, GraphExportArea.PrintableArea, dpiResolution, dpiResolution);
				str.Close();
			}
			return mf;
		}


	

		/// <summary>
		/// Saves the graph as an bitmap file into the file <paramref name="filename"/> using the default
		/// pixel format 32bppArgb and no background brush.
		/// </summary>
		/// <param name="doc">The graph document to export.</param>
		/// <param name="filename">The filename of the file to save the bitmap into.</param>
		/// <param name="dpiResolution">Resolution of the bitmap in dpi. Determines the pixel size of the bitmap.</param>
		public static Metafile RenderAsMetafile(this GraphDocument doc, string filename, double dpiResolution)
		{
			return RenderAsMetafile(doc, filename, null, dpiResolution);
		}

		/// <summary>
		/// Saves the graph as an bitmap file into the file <paramref name="filename"/> using the default
		/// pixel format 32bppArgb.
		/// </summary>
		/// <param name="doc">The graph document to export.</param>
		/// <param name="filename">The filename of the file to save the bitmap into.</param>
		/// <param name="backbrush">Brush used to fill the background of the image. Can be <c>null</c>.</param>
		/// <param name="dpiResolution">Resolution of the bitmap in dpi. Determines the pixel size of the bitmap.</param>
		public static Metafile RenderAsMetafile(this GraphDocument doc, string filename, Brush backbrush, double dpiResolution)
		{
			return RenderAsMetafile(doc, filename, backbrush, PixelFormat.Format32bppArgb, dpiResolution);
		}

		#endregion

		#region default rendering

		public static Metafile RenderAsMetafile(this GraphDocument doc)
		{
			System.IO.MemoryStream stream = new System.IO.MemoryStream();
			Metafile mf = RenderAsMetafile(doc, stream, 300);
			stream.Flush();
			stream.Close();
			return mf;
		}


		#endregion









		#endregion


	}
}
