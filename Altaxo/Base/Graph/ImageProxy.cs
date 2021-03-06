﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2011 Dr. Dirk Lellinger
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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using Altaxo.Drawing;
using Altaxo.Geometry;

namespace Altaxo.Graph
{
  #region ImageProxy

  /// <summary>
  /// Holds an image, either from a resource or from a file stream or from the clipboard.
  /// </summary>
  [Serializable]
  public abstract class ImageProxy : ICloneable, Main.ICopyFrom
  {
    protected const double InchesPerPoint = 1 / 72.0;
    protected const double PointsPerInch = 72.0;

    public override string ToString()
    {
      return Name;
    }

    public static ImageProxy FromFile(string fullpath)
    {
      return MemoryStreamImageProxy.FromFile(fullpath);
    }

    public static ImageProxy FromResource(string fullpath)
    {
      return ResourceImageProxy.FromResource(fullpath);
    }

    public static ImageProxy FromImage(System.Drawing.Image image)
    {
      return MemoryStreamImageProxy.FromImage(image);
    }

    public static ImageProxy FromImage(System.Drawing.Image image, string name)
    {
      return MemoryStreamImageProxy.FromImage(image, name);
    }

    public static ImageProxy FromStream(Stream istr, string name)
    {
      return MemoryStreamImageProxy.FromStream(istr, name);
    }

    public static implicit operator System.Drawing.Image(ImageProxy ip)
    {
      return ip.GetImage();
    }

    public abstract System.Drawing.Image GetImage();

    public abstract string ContentHash { get; }

    public virtual Stream GetContentStream()
    {
      return ImageToStream(GetImage(), ImageFormat.Png);
    }

    public abstract bool IsValid { get; }

    public abstract string Name { get; }

    public bool HasSameContentAs(ImageProxy from)
    {
      return ContentHash == from.ContentHash;
    }

    /// <summary>Returns the original size of the image in points (1/72 inch).</summary>
    public abstract PointD2D Size { get; }

    public static MemoryStream ImageToStream(Image image, ImageFormat format)
    {
      var str = new MemoryStream();
      image.Save(str, format);
      str.Flush();
      return str;
    }

    public abstract object Clone();

    public virtual bool CopyFrom(object obj)
    {
      return obj is ImageProxy;
    }
  }

  #endregion ImageProxy

  #region ResourceImageProxy

  /// <summary>
  /// Holds an image, either from a resource or from a file stream or from the clipboard.
  /// </summary>
  [Serializable]
  public class ResourceImageProxy : ImageProxy
  {
    /// <summary>
    /// Either the name of a resource, or the original file name.
    /// </summary>
    private string _url;

    private string _name;

    // Cached objects
    [NonSerialized]
    private WeakReference _image;

    [NonSerialized]
    private PointD2D _imageSizePt;

    #region Serialization

    [Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(ResourceImageProxy), 0)]
    private class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
    {
      public virtual void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
      {
        var s = (ResourceImageProxy)obj;
        info.AddValue("Url", s._url);
        info.AddValue("Name", s._name);
      }

      public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {
        ResourceImageProxy s = SDeserialize(o, info, parent);
        return s;
      }

      public virtual ResourceImageProxy SDeserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {
        ResourceImageProxy s = null != o ? (ResourceImageProxy)o : new ResourceImageProxy();
        s._url = info.GetString("Url");
        s._name = info.GetString("Name");
        return s;
      }
    }

    #endregion Serialization

    public override string ToString()
    {
      return _name;
    }

    private ResourceImageProxy()
    {
    }

    private void CopyFrom(ResourceImageProxy obj)
    {
      bool isCopied = base.CopyFrom(obj);
      if (isCopied && !object.ReferenceEquals(this, obj))
      {
        var from = obj as ResourceImageProxy;
        if (null != from)
        {
          _url = from._url;
          _name = from._name;
          _imageSizePt = from._imageSizePt;
          _image = (from._image != null && from._image.IsAlive) ? new WeakReference(from._image.Target) : null;
        }
      }
    }

    public static new ImageProxy FromResource(string fullpath)
    {
      if (string.IsNullOrEmpty(fullpath))
        throw new ArgumentException("Path is null or empty");

      var img = new ResourceImageProxy
      {
        _url = fullpath,
        _name = System.IO.Path.GetFileName(fullpath)
      };
      return img;
    }

    public static ImageProxy FromResource(string name, string fullpath)
    {
      if (string.IsNullOrEmpty(name))
        throw new ArgumentException("Name is null or empty");
      if (string.IsNullOrEmpty(fullpath))
        throw new ArgumentException("Path is null or empty");

      var img = new ResourceImageProxy
      {
        _url = fullpath,
        _name = name
      };
      return img;
    }

    public override string Name { get { return _name; } }

    public override PointD2D Size
    {
      get
      {
        if (_imageSizePt.IsEmpty)
          GetImage();
        return _imageSizePt;
      }
    }

    public override bool IsValid
    {
      get
      {
        if (_image != null)
          return true;

        try
        {
          GetImage();
        }
        catch (Exception)
        {
        }

        return _image != null;
      }
    }

    public override System.Drawing.Image GetImage()
    {
      if (_image != null && _image.IsAlive)
        return (System.Drawing.Image)_image.Target;

      System.Drawing.Image image = null;
      if (_url != null)
      {
        image = Current.ResourceService.GetBitmap(_url);
      }

      if (null != image)
      {
        _imageSizePt = new PointD2D(image.Width * 72.0 / image.HorizontalResolution, image.Height * 72.0 / image.VerticalResolution);
        _image = new WeakReference(image);
      }
      else
      {
        _imageSizePt = PointD2D.Empty;
        _image = null;
      }

      return image;
    }

    public override string ContentHash
    {
      get
      {
        return _url + "." + _name;
      }
    }

    #region ICloneable Members

    public override object Clone()
    {
      var result = new ResourceImageProxy();
      result.CopyFrom(this);
      return result;
    }

    #endregion ICloneable Members
  }

  #endregion ResourceImageProxy

  #region MemoryStreamImageProxy

  /// <summary>
  /// Holds an image, either from a resource or from a file stream or from the clipboard.
  /// </summary>
  [Serializable]
  public class MemoryStreamImageProxy : ImageProxy
  {
    /// <summary>
    /// Either the name of a resource, or the original file name.
    /// </summary>
    private string _url;

    private string _name;
    private MemoryStream _stream;
    private string _hash;

    /// <summary>Image size in points (1/72 inch).</summary>
    private PointD2D _imageSizePt;

    /// <summary>
    /// The media file extension, such as '.png', '.emf' or 'jpg'
    /// </summary>
    private string _extension;

    // Cached objects
    [NonSerialized]
    private WeakReference _image;

    // Static helpers
    private static System.Security.Cryptography.MD5 _md5 = System.Security.Cryptography.MD5CryptoServiceProvider.Create();

    #region Serialization

    [Altaxo.Serialization.Xml.XmlSerializationSurrogateFor("AltaxoBase", "Altaxo.Graph.MemoryStreamImageProxy", 0)]
    private class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
    {
      public virtual void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
      {
        throw new InvalidOperationException("Serialization of old version");
        /*
				MemoryStreamImageProxy s = (MemoryStreamImageProxy)obj;
				info.AddValue("Url", s._url);
				info.AddValue("Name", s._name);
				info.AddValue("Hash", s._hash);
				info.AddValue("Stream", s._stream);
				*/
      }

      public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {
        MemoryStreamImageProxy s = SDeserialize(o, info, parent);
        return s;
      }

      public virtual MemoryStreamImageProxy SDeserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {
        MemoryStreamImageProxy s = null != o ? (MemoryStreamImageProxy)o : new MemoryStreamImageProxy();
        s._url = info.GetString("Url");
        s._name = info.GetString("Name");
        s._hash = info.GetString("Hash");
        s._stream = info.GetMemoryStream("Stream");
        s._extension = ".png";

        return s;
      }
    }

    /// <summary>
    /// Extended 2018-03-27 with _extension;
    /// </summary>
    [Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(MemoryStreamImageProxy), 1)]
    private class XmlSerializationSurrogate1 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
    {
      public virtual void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
      {
        var s = (MemoryStreamImageProxy)obj;
        info.AddValue("Url", s._url);
        info.AddValue("Name", s._name);
        info.AddValue("Hash", s._hash);
        info.AddValue("Extension", s._extension);
        info.AddValue("Stream", s._stream);
      }

      public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {
        MemoryStreamImageProxy s = SDeserialize(o, info, parent);
        return s;
      }

      public virtual MemoryStreamImageProxy SDeserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
      {
        MemoryStreamImageProxy s = null != o ? (MemoryStreamImageProxy)o : new MemoryStreamImageProxy();
        s._url = info.GetString("Url");
        s._name = info.GetString("Name");
        s._hash = info.GetString("Hash");
        s._extension = info.GetString("Extension");
        s._stream = info.GetMemoryStream("Stream");

        return s;
      }
    }

    #endregion Serialization

    public override string ToString()
    {
      return _name;
    }

    private MemoryStreamImageProxy()
    {
    }

    public override bool CopyFrom(object obj)
    {
      bool isCopied = base.CopyFrom(obj);
      if (isCopied && !object.ReferenceEquals(this, obj))
      {
        var from = obj as MemoryStreamImageProxy;
        if (null != from)
        {
          _url = from._url;
          _name = from._name;
          _stream = from._stream;
          _hash = from._hash;
          _imageSizePt = from._imageSizePt;
          _extension = from._extension;
          _image = (null != from._image && from._image.IsAlive) ? new WeakReference(from._image.Target) : null;
        }
      }
      return isCopied;
    }

    public static new MemoryStreamImageProxy FromFile(string fullpath)
    {
      var img = new MemoryStreamImageProxy
      {
        _url = fullpath,
        _name = System.IO.Path.GetFileName(fullpath),
        _extension = System.IO.Path.GetExtension(fullpath)
      };
      img.LoadStreamBuffer(fullpath);
      return img;
    }

    public static new MemoryStreamImageProxy FromImage(System.Drawing.Image image)
    {
      return FromImage(image, null);
    }

    public static new MemoryStreamImageProxy FromImage(System.Drawing.Image image, string name)
    {
      var img = new MemoryStreamImageProxy();
      MemoryStream str1, str2;
      string fmt1, fmt2;
      if (image is Metafile)
      {
        var mf = (Metafile)image;

        fmt1 = ".emf";
        str1 = ImageToStream(image, ImageFormat.Emf);
        fmt2 = ".png";
        str2 = ImageToStream(image, ImageFormat.Png);
      }
      else
      {
        fmt1 = ".jpg";
        str1 = ImageToStream(image, ImageFormat.Jpeg);
        fmt2 = ".png";
        str2 = ImageToStream(image, ImageFormat.Png);
      }

      if (str2.Length < str1.Length)
      {
        img._stream = str2;
        img._extension = fmt2;
        str1.Dispose();
      }
      else
      {
        img._stream = str1;
        img._extension = fmt1;
        str2.Dispose();
      }

      img.ComputeStreamHash();

      if (string.IsNullOrEmpty(name))
      {
        img._name = img._hash + img._extension;
        img._url = "image://" + img._name;
      }
      else
      {
        img._name = name;
        img._url = "image://" + name;
      }

      return img;
    }

    /// <summary>
    /// Creates a <see cref="MemoryStreamImageProxy"/> from a stream. A file name must be provided in order
    /// to deduce the kind of stream (.png for .png stream, .jpg for jpg stream and so on).
    /// </summary>
    /// <param name="istr">The image stream to copy from.</param>
    /// <param name="name">The name. The kind of image is deduced from the extension of this name.</param>
    /// <returns>A memory stream image proxy holding the image.</returns>
    /// <exception cref="ArgumentNullException">
    /// istr
    /// or
    /// name - Name must be provided in order to deduce the file extension
    /// </exception>
    public static new MemoryStreamImageProxy FromStream(Stream istr, string name)
    {
      if (istr == null)
        throw new ArgumentNullException(nameof(istr));
      if (string.IsNullOrEmpty(name))
        throw new ArgumentNullException(nameof(name), "Name must be provided in order to deduce the file extension");

      var img = new MemoryStreamImageProxy
      {
        _url = name,
        _name = name,
        _extension = System.IO.Path.GetExtension(name)
      };
      img.CopyFromStream(istr);
      return img;
    }

    private void ComputeStreamHash()
    {
      byte[] hash = _md5.ComputeHash(_stream);
      SetHash(hash);
    }

    private void SetHash(byte[] hash)
    {
      var stb = new StringBuilder();
      for (int i = 0; i < hash.Length; i++)
        stb.Append(hash[i].ToString("X2"));

      _hash = stb.ToString();
    }

    /// <summary>
    /// Computes the hash of the content of the given stream. The stream must be seekable, since it is positioned to
    /// the beginning before calculating the hash. Afterwards, the stream position is undefined.
    /// </summary>
    /// <param name="stream">The stream to compute the hash for.</param>
    /// <returns>String with the MD5 hash of the stream.</returns>
    public static string ComputeStreamHash(Stream stream)
    {
      stream.Seek(0, SeekOrigin.Begin);
      byte[] hash = _md5.ComputeHash(stream);
      var stb = new StringBuilder();
      for (int i = 0; i < hash.Length; i++)
        stb.Append(hash[i].ToString("X2"));
      return stb.ToString();
    }

    private void CopyFromStream(Stream istr)
    {
      if (null == _stream)
        _stream = new MemoryStream();
      _stream.SetLength(0);

      byte[] buffer = new byte[4096];
      int readed;
      while (0 != (readed = istr.Read(buffer, 0, buffer.Length)))
        _stream.Write(buffer, 0, readed);

      _stream.Flush();
      _stream.Seek(0, SeekOrigin.Begin);

      ComputeStreamHash();
      _stream.Seek(0, SeekOrigin.Begin);
    }

    private void LoadStreamBuffer(string fullpath)
    {
      // Copy the file into the stream
      using (var istr = new FileStream(fullpath, FileMode.Open, FileAccess.Read, FileShare.Read))
      {
        CopyFromStream(istr);
        istr.Close();
      }
    }

    public override string Name { get { return _name; } }

    public override bool IsValid
    {
      get
      {
        if (_image != null)
          return true;

        try
        {
          GetImage();
        }
        catch (Exception)
        {
        }

        return _image != null;
      }
    }

    /// <summary>Returns the original size of the image in points (1/72 inch).</summary>
    public override PointD2D Size
    {
      get
      {
        if (_imageSizePt.IsEmpty)
          GetImage();

        return _imageSizePt;
      }
    }

    public override System.Drawing.Image GetImage()
    {
      if (_image != null && _image.IsAlive)
        return (System.Drawing.Image)_image.Target;

      System.Drawing.Image image = null;
      if (_stream != null)
      {
        _stream.Seek(0, SeekOrigin.Begin);
        image = Image.FromStream(_stream);
      }
      else if (_url != null)
      {
        LoadStreamBuffer(_url);
        if (_stream != null)
        {
          _stream.Seek(0, SeekOrigin.Begin);
          image = Image.FromStream(_stream);
        }
      }

      if (image != null)
      {
        _imageSizePt = new PointD2D(image.Width * 72.0 / image.HorizontalResolution, image.Height * 72.0 / image.VerticalResolution);
        _image = new WeakReference(image);
      }
      else
      {
        _imageSizePt = PointD2D.Empty;
        _image = null;
      }

      return image;
    }

    public override Stream GetContentStream()
    {
      if (null != _stream)
      {
        if (_stream.CanSeek)
          _stream.Seek(0, SeekOrigin.Begin);
        return _stream;
      }
      else
        return base.GetContentStream();
    }

    public override string ContentHash
    {
      get { return _hash; }
    }

    /// <summary>
    /// Gets the extension that designates the type of memory stream, such as '.png' or '.jpg'.
    /// </summary>
    public string Extension
    {
      get
      {
        return _extension;
      }
    }

    #region ICloneable Members

    public override object Clone()
    {
      var result = new MemoryStreamImageProxy();
      result.CopyFrom(this);
      return result;
    }

    #endregion ICloneable Members
  }

  #endregion MemoryStreamImageProxy

  #region HatchImageProxy

  /// <summary>
  /// Class that creates images 'on the fly', by using an algorithmus.
  /// </summary>
  internal abstract class SyntheticImageProxy : ImageProxy
  {
    public override Image GetImage()
    {
      throw new NotImplementedException();
    }

    public override string ContentHash
    {
      get { throw new NotImplementedException(); }
    }

    public override bool IsValid
    {
      get { return true; }
    }

    public override string Name
    {
      get { throw new NotImplementedException(); }
    }

    public override object Clone()
    {
      throw new NotImplementedException();
    }
  }

  public interface ISyntheticRepeatableTexture : Main.ICopyFrom, ICloneable
  {
    /// <summary>
    /// Gets an image of the texture. The image dimensions (pixels in x and y direction) are calculated using the provided <paramref name=" maxEffectiveResolutionDpi">maximum effective resolution.</paramref>.
    /// </summary>
    /// <param name="maxEffectiveResolutionDpi">Effective resolution used for later drawing of this image. The higher the resolution, the more pixels are allocated for the bitmap.</param>
    /// <returns>The image of the texture.</returns>
    Image GetImage(double maxEffectiveResolutionDpi);

    /// <summary>
    /// Physical size of both sides of the texture in points (1 point = 1/72 inch).
    /// </summary>
    PointD2D Size { get; }
  }

  public interface IHatchBrushTexture : ISyntheticRepeatableTexture
  {
    /// <summary>
    /// Gets an image of the texture. The image dimensions (pixels in x and y direction) are calculated using the provided <paramref name=" maxEffectiveResolutionDpi">maximum effective resolution.</paramref>.
    /// </summary>
    /// <param name="maxEffectiveResolutionDpi">Effective resolution used for later drawing of this image. The higher the resolution, the more pixels are allocated for the bitmap.</param>
    /// <param name="foreColor">Foreground color of the hatch brush.</param>
    /// <param name="backColor">Background color of the hatch brush.</param>
    /// <returns>The image of the texture.</returns>
    Image GetImage(double maxEffectiveResolutionDpi, NamedColor foreColor, NamedColor backColor);
  }

  public abstract class SyntheticRepeatableTexture : ImageProxy, ISyntheticRepeatableTexture
  {
    public override Image GetImage()
    {
      return GetImage(300);
    }

    public override bool IsValid
    {
      get { return true; }
    }

    #region ISyntheticRepeatableTexture Members

    public abstract Image GetImage(double maxEffectiveResolutionDpi);

    public override bool CopyFrom(object obj)
    {
      bool isCopied = base.CopyFrom(obj);
      return isCopied && (obj is SyntheticRepeatableTexture);
    }

    #endregion ISyntheticRepeatableTexture Members
  }

  #endregion HatchImageProxy
}
