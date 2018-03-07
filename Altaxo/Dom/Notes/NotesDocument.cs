﻿using Altaxo.Main;
using Altaxo.Main.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altaxo.Notes
{
	/// <summary>
	/// Stores notes as markdown annotated text.
	/// </summary>
	/// <seealso cref="Altaxo.Main.SuspendableDocumentLeafNodeWithSingleAccumulatedData{T}" />
	/// <seealso cref="Altaxo.Main.IProjectItem" />
	/// <seealso cref="System.ICloneable" />
	/// <seealso cref="Altaxo.Main.IChangedEventSource" />
	/// <seealso cref="Altaxo.Main.INameOwner" />
	/// <seealso cref="Altaxo.Main.Properties.IPropertyBagOwner" />
	public class NotesDocument :
		Main.SuspendableDocumentNodeWithSingleAccumulatedData<EventArgs>,
		IProjectItem,
		Main.ICopyFrom,
		IChangedEventSource,
		Main.INameOwner,
		Main.Properties.IPropertyBagOwner
	{
		/// <summary>
		/// The markdown source text.
		/// </summary>
		private string _sourceText;

		/// <summary>
		/// Local images for this markdown, stored in a dictionary. The key is a Guid which is created when the image is pasted into the markdown document.
		/// The value is a memory stream image proxy.
		/// </summary>
		private Dictionary<string, Altaxo.Graph.MemoryStreamImageProxy> _images;

		/// <summary>
		/// The name of the style used to visualize the markdown. If this string is null or empty, the current global
		/// defined style of the current Altaxo instance will be used.
		/// </summary>
		private string _styleName;

		/// <summary>
		/// The name of the document.
		/// </summary>
		protected string _name;

		/// <summary>
		/// The date/time of creation of this document.
		/// </summary>
		protected DateTime _creationTime;

		/// <summary>
		/// The date/time when this document was changed.
		/// </summary>
		protected DateTime _lastChangeTime;

		/// <summary>
		/// Notes concerning this document.
		/// </summary>
		protected Main.TextBackedConsole _notes;

		/// <summary>
		/// The graph properties, key is a string, value is a property (arbitrary object) you want to store here.
		/// </summary>
		/// <remarks>The properties are saved on disc (with exception of those that starts with "tmp/".
		/// If the property you want to store is only temporary, the properties name should therefore
		/// start with "tmp/".</remarks>
		protected Main.Properties.PropertyBag _documentProperties;

		#region "Serialization"

		[Altaxo.Serialization.Xml.XmlSerializationSurrogateFor(typeof(NotesDocument), 0)]
		private class XmlSerializationSurrogate0 : Altaxo.Serialization.Xml.IXmlSerializationSurrogate
		{
			public void Serialize(object obj, Altaxo.Serialization.Xml.IXmlSerializationInfo info)
			{
				var s = (NotesDocument)obj;

				info.AddValue("Name", s._name);
				info.AddValue("CreationTime", s._creationTime.ToLocalTime());
				info.AddValue("LastChangeTime", s._lastChangeTime.ToLocalTime());
				info.AddValue("Notes", s._notes.Text);
				info.AddValue("Properties", s._documentProperties);
				info.AddValue("StyleName", s._styleName);
				info.AddValue("SourceText", s._sourceText);

				info.CreateArray("Images", s._images.Count);
				{
					foreach (var entry in s._images)
					{
						info.CreateElement("e");
						{
							info.AddValue("Name", entry.Key);
							info.AddValue("Image", entry.Value);
						}
						info.CommitElement();
					}
				}
				info.CommitArray();
			}

			public void Deserialize(NotesDocument s, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				s._name = info.GetString("Name");
				s._creationTime = info.GetDateTime("CreationTime").ToUniversalTime();
				s._lastChangeTime = info.GetDateTime("LastChangeTime").ToUniversalTime();
				s._notes.Text = info.GetString("Notes");
				s.PropertyBag = (Main.Properties.PropertyBag)info.GetValue("Properties", s);
				s._styleName = info.GetString("StyleName");
				s._sourceText = info.GetString("SourceText");

				int count = info.OpenArray("Images");
				{
					for (int i = 0; i < count; ++i)
					{
						info.OpenElement();
						{
							string key = info.GetString("Name");
							var value = (Altaxo.Graph.MemoryStreamImageProxy)info.GetValue("Image", s);
							s._images.Add(key, value);
						}
						info.CloseElement();
					}
				}
				info.CloseArray(count);
			}

			public object Deserialize(object o, Altaxo.Serialization.Xml.IXmlDeserializationInfo info, object parent)
			{
				var s = (NotesDocument)o ?? new NotesDocument();
				Deserialize(s, info, parent);
				return s;
			}
		}

		#endregion "Serialization"

		/// <summary>
		/// Initializes a new instance of the <see cref="NotesDocument"/> class.
		/// </summary>
		public NotesDocument()
		{
			_creationTime = _lastChangeTime = DateTime.UtcNow;
			_notes = new TextBackedConsole() { ParentObject = this };
			_images = new Dictionary<string, Graph.MemoryStreamImageProxy>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NotesDocument"/> class by copying the content from another instance.
		/// </summary>
		/// <param name="from">Notes to copy from</param>
		public NotesDocument(NotesDocument from)
		{
			using (var suppressToken = SuspendGetToken())
			{
				_creationTime = _lastChangeTime = DateTime.UtcNow;
				CopyFrom(from);

				suppressToken.ResumeSilently();
			}
		}

		/// <inheritdoc/>
		public virtual bool CopyFrom(object obj)
		{
			if (object.ReferenceEquals(this, obj))
				return true;

			if (obj is NotesDocument from)
			{
				using (var suspendToken = SuspendGetToken())
				{
					ChildCopyToMember(ref _notes, from._notes);

					// Clone also the properties
					if (from._documentProperties != null && from._documentProperties.Count > 0)
					{
						PropertyBagNotNull.CopyFrom(from._documentProperties);
					}
					else
					{
						this._documentProperties = null;
					}

					_styleName = from._styleName;
					_sourceText = from._sourceText;
					_images.Clear();
					foreach (var entry in from._images)
					{
						_images.Add(entry.Key, (Altaxo.Graph.MemoryStreamImageProxy)entry.Value.Clone());
					}

					EhSelfChanged(EventArgs.Empty);
				}

				return true;
			}
			return false;
		}

		/// <inheritdoc/>
		public object Clone()
		{
			return new NotesDocument(this);
		}

		/// <inheritdoc/>
		public void VisitDocumentReferences(DocNodeProxyReporter ProxyProcessing)
		{
		}

		/// <inheritdoc/>
		protected override IEnumerable<DocumentNodeAndName> GetDocumentNodeChildrenWithName()
		{
			yield break;
		}

		/// <summary>
		/// The date/time of creation of this graph.
		/// </summary>
		public DateTime CreationTimeUtc
		{
			get
			{
				return _creationTime;
			}
		}

		/// <summary>
		/// The date/time when this graph was changed.
		/// </summary>
		public DateTime LastChangeTimeUtc
		{
			get
			{
				return _lastChangeTime;
			}
		}

		/// <summary>
		/// Notes concerning this graph.
		/// </summary>
		public Main.ITextBackedConsole Notes
		{
			get
			{
				return _notes;
			}
		}

		#region IPropertyBagOwner

		/// <inheritdoc/>
		public Main.Properties.PropertyBag PropertyBag
		{
			get { return _documentProperties; }
			protected set
			{
				_documentProperties = value;
				if (null != _documentProperties)
					_documentProperties.ParentObject = this;
			}
		}

		/// <inheritdoc/>
		public Main.Properties.PropertyBag PropertyBagNotNull
		{
			get
			{
				if (null == _documentProperties)
					PropertyBag = new Main.Properties.PropertyBag();
				return _documentProperties;
			}
		}

		#endregion IPropertyBagOwner

		#region Parent and Name

		/// <summary>
		/// Get / sets the parent object of this table.
		/// </summary>
		public override Main.IDocumentNode ParentObject
		{
			get
			{
				return _parent;
			}
			set
			{
				if (object.ReferenceEquals(_parent, value))
					return;

				var oldParent = _parent;
				base.ParentObject = value;

				(_parent as Main.IParentOfINameOwnerChildNodes)?.EhChild_ParentChanged(this, oldParent);
			}
		}

		/// <inheritdoc/>
		public override string Name
		{
			get { return _name; }
			set
			{
				if (null == value)
					throw new ArgumentNullException("New name is null");
				if (_name == value)
					return; // nothing changed

				var canBeRenamed = true;
				var parentAs = _parent as Main.IParentOfINameOwnerChildNodes;
				if (null != parentAs)
				{
					canBeRenamed = parentAs.EhChild_CanBeRenamed(this, value);
				}

				if (canBeRenamed)
				{
					var oldName = _name;
					_name = value;

					if (null != parentAs)
						parentAs.EhChild_HasBeenRenamed(this, oldName);

					OnNameChanged(oldName);
				}
				else
				{
					throw new ApplicationException(string.Format("Renaming of graph {0} into {1} not possible, because name exists already", _name, value));
				}
			}
		}

		/// <summary>
		/// Fires both a Changed and a TunnelingEvent when the name has changed.
		/// The event arg of the Changed event is an instance of <see cref="T:Altaxo.Main.NamedObjectCollectionChangedEventArgs"/>.
		/// The event arg of the Tunneling event is an instance of <see cref="T:Altaxo.Main.DocumentPathChangedEventArgs"/>.
		/// </summary>
		/// <param name="oldName">The name of the table before it has changed the name.</param>
		protected virtual void OnNameChanged(string oldName)
		{
			EhSelfTunnelingEventHappened(Main.DocumentPathChangedEventArgs.Empty);
			EhSelfChanged(Main.NamedObjectCollectionChangedEventArgs.FromItemRenamed(this, oldName));
		}

		#endregion Parent and Name

		#region SourceText and Style

		/// <summary>
		/// The name of the style used to visualize the markdown. If this string is null or empty, the current global
		/// defined style of the current Altaxo instance will be used.
		/// </summary>
		/// <value>
		/// The name of the style.
		/// </value>
		public string StyleName
		{
			get
			{
				return _styleName;
			}
			set
			{
				if (!(_styleName == value))
				{
					_styleName = value;
					EhSelfChanged(EventArgs.Empty);
				}
			}
		}

		/// <summary>
		/// Gets or sets the source text of the markdown document.
		/// </summary>
		/// <value>
		/// The source text.
		/// </value>
		public string SourceText
		{
			get
			{
				return _sourceText;
			}
			set
			{
				if (!(_sourceText == value))
				{
					_sourceText = value;
					EhSelfChanged(EventArgs.Empty);
				}
			}
		}

		/// <summary>
		/// Local images for this markdown, stored in a dictionary. The key is a Guid which is created when the image is pasted into the markdown document.
		/// The value is a memory stream image proxy.
		/// </summary>
		public IDictionary<string, Altaxo.Graph.MemoryStreamImageProxy> Images
		{
			get
			{
				return _images;
			}
		}

		#endregion SourceText and Style
	}
}
