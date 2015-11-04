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

namespace Altaxo.Graph3D
{
	public class SceneSettings : Main.SuspendableDocumentLeafNodeWithEventArgs, Main.ICopyFrom
	{
		private Camera.CameraBase _camera;

		public SceneSettings()
		{
			//_camera = new Camera.PerspectiveCamera();

			_camera = new Camera.OrthographicCamera() { Scale = 1000 };
		}

		public SceneSettings(SceneSettings from)
		{
			CopyFrom(from);
		}

		public virtual bool CopyFrom(object obj)
		{
			if (object.ReferenceEquals(this, obj))
				return true;

			var from = obj as SceneSettings;

			if (null != from)
			{
				this._camera = (Camera.CameraBase)from._camera.Clone();
				EhSelfChanged();
				return true;
			}

			return false;
		}

		public object Clone()
		{
			return new SceneSettings(this);
		}

		public Camera.CameraBase Camera
		{
			get
			{
				return _camera;
			}
			set
			{
				if (null == value)
					throw new ArgumentNullException(nameof(value));

				_camera = value;

				EhSelfChanged();
			}
		}
	}
}