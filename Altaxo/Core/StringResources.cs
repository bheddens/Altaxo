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
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altaxo
{
	/// <summary>
	/// String resource manager for the AltaxoCore DLL and other DLLs that reference AltaxoCore.
	/// </summary>
	public class StringResources
	{
		System.Resources.ResourceManager _enResourceMgr;
		Dictionary<string, System.Resources.ResourceManager> _resourceManagersByLanguage;
		System.Reflection.Assembly _assemblyContainingTheResources;
		string _resourcePath;
		string _resourceName;


		static StringResources _AltaxoCoreResources = new StringResources("Altaxo.Resources", "StringResources", System.Reflection.Assembly.GetExecutingAssembly());


		/// <summary>
		/// Gets the altaxo core string resources.
		/// </summary>
		public static StringResources AltaxoCore { get { return _AltaxoCoreResources; }}


		/// <summary>
		/// Initializes a new instance of the <see cref="StringResources"/> class.
		/// </summary>
		/// <param name="path">The path to the resource. This is usually the default namespace, a dot, and the folders (separated by dots) where the resource file(s) reside. See remarks for how to name the neutral resource files and the resource files for other cultures.</param>
		/// <param name="resourceName">Name of the neutral (english) resource file (without the '.resource' extension.</param>
		/// <param name="assemblyContainingTheResources">The assembly containing the resources.</param>
		/// <remarks>
		/// The naming conventions will be explained using AltaxoCore as example.
		/// <para>The default namespace of the AltaxoCore DLL is 'Altaxo'.</para>
		/// <para>The resource files reside in the source folder 'Resources'.</para>
		/// <para>The neutral resource file is named 'StringResources.resources'.</para>
		/// <para>The resource file for the german culture must be named 'de.StringResources.resources' (two-letter_culture_name + dot + neutral_resource_file_name).</para>
		/// <para>This will lead to the following arguments for creating the instance:</para>
		/// <para>The <paramref name="path"/> argument is 'Altaxo.Resources' (default_namespace + dot + foldername).</para>
		/// <para>The <paramref name="resourceName"/> argument is 'StringResources'.</para>
		/// <para>The <paramref name="assemblyContainingTheResources"/> argument must refer to AltaxoCore.</para>
		/// </remarks>
		public StringResources(string path, string resourceName, System.Reflection.Assembly assemblyContainingTheResources)
		{
			_resourcePath = path;
			_resourceName = resourceName;
			_assemblyContainingTheResources = assemblyContainingTheResources;
			_enResourceMgr = new System.Resources.ResourceManager(path + "." + resourceName, assemblyContainingTheResources);
			_resourceManagersByLanguage = new Dictionary<string, System.Resources.ResourceManager>();
			_resourceManagersByLanguage.Add("en", _enResourceMgr);
		}


		/// <summary>
		/// Gets a resource string for a given resource key.
		/// </summary>
		/// <param name="resourceKey">The resource key.</param>
		/// <returns>The resource string corresponding to the given resource key.</returns>
		public string GetString(StringResourceKey resourceKey)
		{
			System.Resources.ResourceManager mgr;

			string cu = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

			if (!_resourceManagersByLanguage.TryGetValue(cu, out mgr))
			{
				string resName = string.Format("{0}.{1}.{2}", _resourcePath, cu, _resourceName);
				mgr = null;
				try
				{
					mgr = new System.Resources.ResourceManager(resName, _assemblyContainingTheResources);
				}
				catch (Exception)
				{
				}
				_resourceManagersByLanguage.Add(cu, mgr); // add the manager even if it is null -> this then indicates that no such resource localization exists.
			}

			mgr = _resourceManagersByLanguage[cu];
			if (null != mgr)
				return mgr.GetString(resourceKey.Key);
			else
				return _enResourceMgr.GetString(resourceKey.Key);
		}
	}
}
