#region Copyright

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

namespace Altaxo.Main
{
	/// <summary>
	/// DocumentPath holds a path to a document. This path reflects the internal organization of the class instances in Altaxo. Do not mix this
	/// concept with the concept of the folder in which a project item virtually exists  (see <see cref="ProjectFolder"/>).
	/// </summary>
	[Serializable]
	public class DocumentPath : System.Collections.Specialized.StringCollection, System.ICloneable
	{
		protected bool _IsAbsolutePath;

		#region Serialization

		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(DocumentPath), 0)]
		private class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				DocumentPath s = (DocumentPath)obj;

				info.AddValue("IsAbsolute", s._IsAbsolutePath);

				info.CreateArray("Path", s.Count);
				for (int i = 0; i < s.Count; i++)
					info.AddValue("e", s[i]);
				info.CommitArray();
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				DocumentPath s = null != o ? (DocumentPath)o : new DocumentPath();

				s._IsAbsolutePath = info.GetBoolean("IsAbsolute");

				int count = info.OpenArray();
				for (int i = 0; i < count; i++)
					s.Add(info.GetString());
				info.CloseArray(count);

				return s;
			}
		}

		#endregion Serialization

		public DocumentPath(bool isAbsolutePath)
		{
			_IsAbsolutePath = isAbsolutePath;
		}

		public DocumentPath()
			: this(false)
		{
		}

		public DocumentPath(DocumentPath from)
		{
			this._IsAbsolutePath = from._IsAbsolutePath;
			foreach (string s in from)
				Add(s);
		}

		/// <summary>Get a absolute <see cref="DocumentPath"/> from a collection node and the name of an item in this collection.</summary>
		/// <param name="collectionNode">The collection node (for instance the DataTableCollection in the current project).</param>
		/// <param name="nameOfItemInTheCollection">The name of item in the collection (in the above example the name of the data table).</param>
		/// <returns>An absolute document path designating the named item in the collection.</returns>
		public static DocumentPath FromDocumentCollectionNodeAndName(IDocumentNode collectionNode, string nameOfItemInTheCollection)
		{
			DocumentPath result = DocumentPath.GetAbsolutePath(collectionNode);
			result.Add(nameOfItemInTheCollection);
			return result;
		}

		public bool IsAbsolutePath
		{
			get { return _IsAbsolutePath; }
			set { _IsAbsolutePath = value; }
		}

		public override string ToString()
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(128);
			if (this.IsAbsolutePath)
				stringBuilder.Append("/");

			if (this.Count > 0)
				stringBuilder.Append(this[0]);

			for (int i = 1; i < this.Count; i++)
			{
				stringBuilder.Append("/");
				stringBuilder.Append(this[i]);
			}
			return stringBuilder.ToString();
		}

		public override bool Equals(object obj)
		{
			var o = obj as DocumentPath;
			if (null == o)
				return false;
			if (this.IsAbsolutePath != o.IsAbsolutePath)
				return false;
			if (this.Count != o.Count)
				return false;

			for (int i = this.Count - 1; i >= 0; --i)
			{
				if (!(this[i] == o[i]))
					return false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public bool StartsWith(DocumentPath another)
		{
			if (this.Count < another.Count)
				return false;

			for (int i = 0; i < another.Count; ++i)
				if (this[i] != another[i])
					return false;

			return true;
		}

		public DocumentPath SubPath(int count)
		{
			var result = new DocumentPath(this._IsAbsolutePath);
			for (int i = 0; i < count; ++i)
				result.Add(this[i]);
			return result;
		}

		/// <summary>Replaces the last part of the <see cref="DocumentPath"/>, which is often the name of the object.</summary>
		/// <param name="lastPart">The new last part of the <see cref="DocumentPath"/>.</param>
		public void ReplaceLastPart(string lastPart)
		{
			if (this.Count == 0)
				throw new InvalidOperationException("DocumentPath is empty, thus replacement of last part is not possible");
			if (string.IsNullOrEmpty(lastPart))
				throw new ArgumentOutOfRangeException("lastPart is null or empty");

			this[this.Count - 1] = lastPart;
		}

		/// <summary>
		/// Replaces parts of the part by another part.
		/// </summary>
		/// <param name="partToReplace">Part of the path that should be replaced. This part has to match the beginning of this part. The last item of the part
		/// is allowed to be given only partially.</param>
		/// <param name="newPart">The new part to replace that piece of the path, that match the <c>partToReplace</c>.</param>
		/// <returns>True if the part could be replaced. Returns false if the path does not fulfill the presumtions given above.</returns>
		/// <remarks>
		/// As stated above, the last item of the partToReplace can be given only partially. As an example, the path (here separated by space)
		/// <para>Tables Preexperiment1/WDaten Time</para>
		/// <para>should be replaced by </para>
		/// <para>Tables Preexperiment2\WDaten Time</para>
		/// <para>To make this replacement, the partToReplace should be given by</para>
		/// <para>Tables Preexperiment1/</para>
		/// <para>and the newPart should be given by</para>
		/// <para>Tables Preexperiment2\</para>
		/// <para>Note that Preexperiment1\ and Preexperiment2\ are only partially defined items of the path.</para>
		/// </remarks>
		public bool ReplacePathParts(DocumentPath partToReplace, DocumentPath newPart)
		{
			// Test if the start of my path is identical to that of partToReplace
			if (this.Count < partToReplace.Count)
				return false;

			for (int i = 0; i < partToReplace.Count - 1; i++)
				if (0 != string.Compare(this[i], partToReplace[i]))
					return false;

			if (!this[partToReplace.Count - 1].StartsWith(partToReplace[partToReplace.Count - 1]))
				return false;

			// ok, the beginning of my path and partToReplace is identical,
			// thus we replace the beginning of my path with that of newPart

			string s = this[partToReplace.Count - 1].Substring(partToReplace[partToReplace.Count - 1].Length);
			this[partToReplace.Count - 1] = newPart[newPart.Count - 1] + s;

			int j, k;
			for (j = partToReplace.Count - 2, k = newPart.Count - 2; j >= 0 && k >= 0; --j, --k)
				this[j] = newPart[k];

			if (k > 0)
			{
				for (; k >= 0; --k)
					this.Insert(0, newPart[k]);
			}
			else if (j > 0)
			{
				for (; j >= 0; --j)
					this.RemoveAt(0);
			}

			return true;
		}

		#region static navigation methods

		/// <summary>
		/// Get the root node of the node <code>node</code>. The root node is defined as last node in the hierarchie that
		/// either has not implemented the <see cref="IDocumentNode"/> interface or has no parent.
		/// </summary>
		/// <param name="node">The node from where the search begins.</param>
		/// <returns>The root node, i.e. the last node in the hierarchie that
		/// either has not implemented the <see cref="IDocumentNode"/> interface or has no parent</returns>
		public static object GetRootNode(IDocumentNode node)
		{
			if (null == node)
				return null;

			object root = node.ParentObject;
			while (root != null && root is IDocumentNode)
				root = ((IDocumentNode)root).ParentObject;

			return root;
		}

		/// <summary>
		/// Get the first parent node of the node <code>node</code> that implements the given type <code>type.</code>.
		/// </summary>
		/// <param name="node">The node from where the search begins.</param>
		/// <param name="type">The type to search for.</param>
		/// <returns>The first parental node that implements the type <code>type.</code>
		/// </returns>
		public static object GetRootNodeImplementing(IDocumentNode node, System.Type type)
		{
			if (null == node)
				return null;

			object root = node.ParentObject;
			while (root != null && root is IDocumentNode && !type.IsInstanceOfType(root))
				root = ((IDocumentNode)root).ParentObject;

			return type.IsInstanceOfType(root) ? root : null;
		}

		/// <summary>
		/// Get the first parent node of the node <code>node</code> that implements the given type <code>type.</code>.
		/// </summary>
		/// <typeparam name="T">The type to search for.</typeparam>
		/// <param name="node">The node from where the search begins.</param>
		/// <returns>The first parental node that implements the type <code>T</code>.</returns>
		public static T GetRootNodeImplementing<T>(IDocumentNode node)
		{
			if (null == node)
				return default(T);

			object root = node.ParentObject;
			while (root != null && root is IDocumentNode && !(root is T))
				root = ((IDocumentNode)root).ParentObject;

			return (root is T) ? (T)root : default(T);
		}

		/// <summary>
		/// Get the absolute path of the node <code>node</code> starting from the root.
		/// </summary>
		/// <param name="node">The node for which the path is retrieved.</param>
		/// <returns>The absolute path of the node. The first element is a "/" to mark this as absolute path.</returns>
		public static DocumentPath GetAbsolutePath(IDocumentNode node)
		{
			DocumentPath path = GetPath(node, int.MaxValue);
			path.IsAbsolutePath = true;
			return path;
		}

		/// <summary>
		/// Get the absolute path of the node <code>node</code> starting either from the root, or from the object in the depth
		/// <code>maxDepth</code>, whatever is reached first.
		/// </summary>
		/// <param name="node">The node for which the path is to be retrieved.</param>
		/// <param name="maxDepth">The maximal hierarchie depth (the maximal number of path elements returned).</param>
		/// <returns>The path from the root or from the node in the depth <code>maxDepth</code>, whatever is reached first. The path is <b>not</b> prepended
		/// by a "/".
		/// </returns>
		public static DocumentPath GetPath(IDocumentNode node, int maxDepth)
		{
			DocumentPath path = new DocumentPath();

			int depth = 0;
			object root = node;
			while (root != null && root is IDocumentNode)
			{
				if (depth >= maxDepth)
					break;

				string name = ((IDocumentNode)root).Name;
				path.Insert(0, name);
				root = ((IDocumentNode)root).ParentObject;
				++depth;
			}

			return path;
		}

		public static string GetPathString(IDocumentNode node, int maxDepth)
		{
			return GetPath(node, maxDepth).ToString();
		}

		/// <summary>
		/// Retrieves the relative path from the node <code>startnode</code> to the node <code>endnode</code>.
		/// </summary>
		/// <param name="startnode">The node where the path begins.</param>
		/// <param name="endnode">The node where the path ends.</param>
		/// <returns>If the two nodes share a common root, the function returns the relative path from <code>startnode</code> to <code>endnode</code>.
		/// If the nodes have no common root, then the function returns the absolute path of the endnode.</returns>
		public static DocumentPath GetRelativePathFromTo(IDocumentNode startnode, IDocumentNode endnode)
		{
			return GetRelativePathFromTo(startnode, endnode, null);
		}

		/// <summary>
		/// Retrieves the relative path from the node <code>startnode</code> to the node <code>endnode</code>.
		/// </summary>
		/// <param name="startnode">The node where the path begins.</param>
		/// <param name="endnode">The node where the path ends.</param>
		/// <param name="stoppernode">A object which is used as stopper. If the relative path would step down below this node in the hierarchie,
		/// not the relative path, but the absolute path of the endnode is returned. This is usefull for instance for serialization purposes.You can set the stopper node
		/// to the root object of serialization, so that path in the inner of the serialization tree are relative paths, whereas paths to objects not includes in the
		/// serialization tree are returned as absolute paths. The stoppernode can be null.</param>
		/// <returns>If the two nodes share a common root, the function returns the relative path from <code>startnode</code> to <code>endnode</code>.
		/// If the nodes have no common root, then the function returns the absolute path of the endnode.
		/// <para>If either startnode or endnode is null, then null is returned.</para></returns>
		public static DocumentPath GetRelativePathFromTo(IDocumentNode startnode, IDocumentNode endnode, object stoppernode)
		{
			System.Collections.Hashtable hash = new System.Collections.Hashtable();

			if (startnode == null || endnode == null)
				return null;

			// store the complete hierarchie of objects as keys in the hash, (values are the hierarchie depth)
			int endnodedepth = 0;
			object root = endnode;
			while (root != null && root is IDocumentNode)
			{
				hash.Add(root, endnodedepth);
				root = ((IDocumentNode)root).ParentObject;
				++endnodedepth;
			}

			// the whole endnode hierarchie is now in the hash, now look to find the first node starting from startnode, which has the same root
			// i.e. which is contained in the hash table

			int startnodedepth = 0;
			root = startnode;
			while (root != null && root is IDocumentNode)
			{
				if (hash.ContainsKey(root))
				{
					endnodedepth = (int)hash[root]; // the depth of the endnode to this root
					break;
				}

				if (root.Equals(stoppernode)) // stop also if the stopper node is reached
				{
					break;
				}

				root = ((IDocumentNode)root).ParentObject;
				++startnodedepth;
			}

			if (null == root || !hash.ContainsKey(root))
			{
				return GetAbsolutePath(endnode); // no common root -> return AbsolutePath
			}
			else
			{
				DocumentPath path;
				path = GetPath(endnode, endnodedepth); // path of endnode depth
				for (int i = 0; i < startnodedepth; i++)
					path.Insert(0, ".."); // insert "root dir entries"

				return path;
			}
		}

		/// <summary>
		/// Resolves the path by first using startnode as starting point. If that failed, try using documentRoot as starting point.
		/// </summary>
		/// <param name="path">The path to resolve.</param>
		/// <param name="startnode">The node object which is considered as the starting point of the path.</param>
		/// <param name="documentRoot">An alternative node which is used as starting point of the path if the first try failed.</param>
		/// <returns>The resolved object. If the resolving process failed, the return value is null.</returns>
		public static object GetObject(DocumentPath path, object startnode, object documentRoot)
		{
			object retval = GetObject(path, startnode);

			if (null == retval && null != documentRoot)
				retval = GetObject(path, documentRoot);

			return retval;
		}

		public static object GetObject(DocumentPath path, object startnode)
		{
			object node = startnode;

			if (path.IsAbsolutePath && node is IDocumentNode)
				node = GetRootNode((IDocumentNode)node);

			for (int i = 0; i < path.Count; i++)
			{
				if (path[i] == "..")
				{
					if (node is Main.IDocumentNode)
						node = ((Main.IDocumentNode)node).ParentObject;
					else
						return null;
				}
				else
				{
					if (node is Main.INamedObjectCollection)
						node = ((Main.INamedObjectCollection)node).GetChildObjectNamed(path[i]);
					else
						return null;
				}
			} // end for
			return node;
		}

		#endregion static navigation methods

		#region ICloneable Members

		object System.ICloneable.Clone()
		{
			return new DocumentPath(this);
		}

		public DocumentPath Clone()
		{
			return new DocumentPath(this);
		}

		#endregion ICloneable Members
	}
}