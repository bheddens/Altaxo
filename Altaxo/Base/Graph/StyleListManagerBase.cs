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

using Altaxo.Main;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altaxo.Graph
{
	#region Value class for StyleListManagerBase

	/// <summary>
	/// Entry for the StyleListManagerBase that bundles the list and its definition level.
	/// </summary>
	/// <typeparam name="TList">The type of the list.</typeparam>
	/// <typeparam name="T"></typeparam>
	/// <seealso cref="Altaxo.Main.IImmutable" />
	public class StyleListManagerBaseEntryValue<TList, T> : Main.IImmutable where TList : IStyleList<T> where T : Main.IImmutable
	{
		/// <summary>
		/// Gets the list of items.
		/// </summary>
		/// <value>
		/// The list of items.
		/// </value>
		public TList List { get; private set; }

		/// <summary>
		/// Gets the definition level of the list.
		/// </summary>
		/// <value>
		/// The definition level of the list.
		/// </value>
		public Main.ItemDefinitionLevel Level { get; private set; }

		public StyleListManagerBaseEntryValue(TList list, Main.ItemDefinitionLevel level)
		{
			if (null == list)
				throw new ArgumentNullException(nameof(list));

			List = list;

			Level = level;
		}
	}

	#endregion Value class for StyleListManagerBase

	/// <summary>
	/// Implements a basic manager for style lists.
	/// </summary>
	/// <typeparam name="TList">Type of the list of style items.</typeparam>
	/// <typeparam name="T">Type of the style item in the lists.</typeparam>
	/// <typeparam name="TListManagerEntry">Type of the entries used by the list manager (amended for instance with the list level or other information).</typeparam>
	/// <seealso cref="Altaxo.Graph.IStyleListManager{TList, T}" />
	public abstract class StyleListManagerBase<TList, T, TListManagerEntry> : IStyleListManager<TList, T> where TList : IStyleList<T> where T : Main.IImmutable where TListManagerEntry : StyleListManagerBaseEntryValue<TList, T>
	{
		/// <summary>
		/// Dictionary of all existing lists. Key is the list name. Value is a tuple, whose boolean entry designates whether this is
		/// a buildin or user list (false) or a project list (true).
		/// </summary>
		protected Dictionary<string, TListManagerEntry> _allLists = new Dictionary<string, TListManagerEntry>();

		private Func<TList, ItemDefinitionLevel, TListManagerEntry> EntryValueCreator;

		public TList BuiltinDefault { get; private set; }

		protected StyleListManagerBase(Func<TList, ItemDefinitionLevel, TListManagerEntry> valueCreator, TList builtinDefaultList)
		{
			if (null == valueCreator)
				throw new ArgumentNullException(nameof(valueCreator));

			EntryValueCreator = valueCreator;
			BuiltinDefault = builtinDefaultList;
			_allLists.Add(BuiltinDefault.Name, EntryValueCreator(BuiltinDefault, Main.ItemDefinitionLevel.Builtin));
		}

		#region ListAdded event

		/// <summary>
		/// Fired when a list is added to the manager.
		/// </summary>
		private WeakDelegate<Action> _listAdded = new WeakDelegate<Action>();

		/// <summary>
		/// Occurs when a list is added to the manager. The event is hold weak, thus you can safely add your handler without running in memory leaks.
		/// </summary>
		public event Action ListAdded
		{
			add
			{
				_listAdded.Combine(value);
			}
			remove
			{
				_listAdded.Remove(value);
			}
		}

		protected virtual void OnListAdded()
		{
			_listAdded.Target?.Invoke();
		}

		#endregion ListAdded event

		public IEnumerable<string> GetAllListNames()
		{
			return _allLists.Keys;
		}

		public TList GetList(string name)
		{
			return _allLists[name].List;
		}

		IEnumerable<StyleListManagerBaseEntryValue<TList, T>> IStyleListManager<TList, T>.GetEntryValues()
		{
			return _allLists.Values;
		}

		public IEnumerable<TListManagerEntry> GetEntryValues()
		{
			return _allLists.Values;
		}

		StyleListManagerBaseEntryValue<TList, T> IStyleListManager<TList, T>.GetEntryValue(string name)
		{
			return _allLists[name];
		}

		public TListManagerEntry GetEntryValue(string name)
		{
			return _allLists[name];
		}

		public bool TryGetList(string name, out TListManagerEntry value)
		{
			return _allLists.TryGetValue(name, out value);
		}

		/// <summary>
		/// Called when the current project is closed. Removes all those list which are project lists.
		/// </summary>
		protected virtual void EhProjectClosed(object sender, Main.ProjectEventArgs e)
		{
			var namesToRemove = new List<string>(_allLists.Where(entry => entry.Value.Level == Main.ItemDefinitionLevel.Project).Select(entry => entry.Key));
			foreach (var name in namesToRemove)
				_allLists.Remove(name);
		}

		/// <summary>
		/// Try to register the provided list.
		/// </summary>
		/// <param name="instance">The new list which is tried to register.</param>
		/// <param name="level">The level on which this list is defined.</param>
		/// <param name="storedList">On return, this is the list which is either registered, or is an already registed list with exactly the same elements.</param>
		/// <returns>True if the list was new and thus was added to the collection; false if the list has already existed.</returns>
		public bool TryRegisterList(TList instance, Main.ItemDefinitionLevel level, out TList storedList)
		{
			string nameOfExistingGroup;
			if (TryGetListByMembers(instance, instance.Name, out nameOfExistingGroup)) // if a group with such a list already exist
			{
				if (nameOfExistingGroup != instance.Name) // if it has the same list, but a different name, do nothing at all
				{
					storedList = _allLists[nameOfExistingGroup].List;
					return false;
				}
				else // if it has the same list, and the same name, even better, nothing is left to be done
				{
					storedList = _allLists[nameOfExistingGroup].List;
					return false;
				}
			}
			else // a group with such members don't exist currently
			{
				if (_allLists.ContainsKey(instance.Name)) // but name is already in use
				{
					storedList = (TList)instance.WithName(GetUnusedName(instance.Name));
					_allLists.Add(storedList.Name, EntryValueCreator(storedList, level));
					OnListAdded();
					return true;
				}
				else // name is not in use
				{
					storedList = instance;
					_allLists.Add(instance.Name, EntryValueCreator(instance, level));
					OnListAdded();
					return true;
				}
			}
		}

		/// <summary>
		/// Try to register the provided list.
		/// </summary>
		/// <param name="listName">Name of the list to register.</param>
		/// <param name="listItems">Items of the list to register.</param>
		/// <param name="listLevel">The definitionlevel of the list to register.</param>
		/// <param name="ListCreator">Function used to create a new list from listName and listItems. Can be null: in this case the standard list creator will be used.</param>
		/// <param name="storedList">On return, this is the list which is either registered, or is an already registed list with exactly the same elements.</param>
		/// <returns>True if the list was new and thus was added to the collection; false if the list has already existed.</returns>
		public bool TryRegisterList(string listName, IEnumerable<T> listItems, Main.ItemDefinitionLevel listLevel, Func<string, IEnumerable<T>, TList> ListCreator, out TList storedList)
		{
			if (string.IsNullOrEmpty(listName))
				throw new ArgumentNullException(nameof(listName));

			string nameOfExistingGroup;
			if (TryGetListByMembers(listItems, listName, out nameOfExistingGroup)) // if a group with such a list already exist
			{
				storedList = _allLists[nameOfExistingGroup].List;
				return false;
			}
			else // a group with such members don't exist currently
			{
				if (_allLists.ContainsKey(listName)) // but name is already in use
					listName = GetUnusedName(listName);

				storedList = (ListCreator ?? CreateNewList)(listName, listItems);
				_allLists.Add(storedList.Name, EntryValueCreator(storedList, listLevel));
				OnListAdded();
				return true;
			}
		}

		protected virtual string GetUnusedName(string usedName)
		{
			if (string.IsNullOrEmpty(usedName))
				throw new ArgumentNullException(nameof(usedName));
			if (!_allLists.ContainsKey(usedName))
				return usedName;

			int i;
			for (i = usedName.Length - 1; i >= 0; --i)
			{
				if (!char.IsDigit(usedName[i]))
					break;
			}

			int numberOfDigits = usedName.Length - (i + 1);

			if (0 == numberOfDigits)
			{
				return GetUnusedName(usedName + "0");
			}
			else
			{
				int number = int.Parse(usedName.Substring(i + 1), System.Globalization.NumberStyles.Any);
				string formatString = "N" + numberOfDigits.ToString(System.Globalization.CultureInfo.InvariantCulture);
				return GetUnusedName(usedName.Substring(0, i + 1) + (number + 1).ToString(formatString, System.Globalization.CultureInfo.InvariantCulture));
			}
		}

		/// <inheritdoc />
		public bool TryGetListByMembers(IEnumerable<T> symbols, string nameHint, out string nameOfExistingList)
		{
			// fast lookup: first test if a list with the hinted name exists and has the same items
			TListManagerEntry existingEntry;
			if (!string.IsNullOrEmpty(nameHint) && _allLists.TryGetValue(nameHint, out existingEntry) && existingEntry.List.IsStructuralEquivalentTo(symbols))
			{
				nameOfExistingList = existingEntry.List.Name;
				return true;
			}

			// now look in all lists whether a list with the same items exists.
			foreach (var entry in _allLists)
			{
				if (entry.Value.List.IsStructuralEquivalentTo(symbols))
				{
					nameOfExistingList = entry.Key;
					return true;
				}
			}

			// obviously, no such list was found
			nameOfExistingList = null;
			return false;
		}

		public bool ContainsList(string name)
		{
			return _allLists.ContainsKey(name);
		}

		public abstract TList CreateNewList(string name, IEnumerable<T> symbols);
	}
}