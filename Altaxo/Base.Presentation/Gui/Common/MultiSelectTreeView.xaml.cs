﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Altaxo.Gui.Common
{
	/// <summary>
	/// Interaction logic for MultiSelectTreeView.xaml
	/// </summary>
	public partial class MultiSelectTreeView : System.Windows.Controls.ItemsControl
	{
		/// <summary>
		/// Fired when a mouse double click on any item occurs.
		/// </summary>
		public event EventHandler ItemMouseDoubleClick;


		public MultiSelectTreeView()
		{
			InitializeComponent();

			var ib = new KeyBinding(ApplicationCommands.Copy, Key.C, ModifierKeys.Control);
			this.InputBindings.Add(ib);
		}


		public enum SelectionModalities
		{
			SingleSelectionOnly,
			MultipleSelectionOnly,
			KeyboardModifiersMode
		}

		public class SelectedItemsCollection : ObservableCollection<MultiSelectTreeViewItem> { }


		#region Properties
		private MultiSelectTreeViewItem _lastClickedItem = null;

		public SelectionModalities SelectionMode
		{
			get { return (SelectionModalities)GetValue(SelectionModeProperty); }
			set { SetValue(SelectionModeProperty, value); }
		}
		public static readonly DependencyProperty SelectionModeProperty =
				DependencyProperty.Register("SelectionMode", typeof(SelectionModalities), typeof(MultiSelectTreeView), new UIPropertyMetadata(SelectionModalities.KeyboardModifiersMode));

		private SelectedItemsCollection _selectedItems = new SelectedItemsCollection();
		public SelectedItemsCollection SelectedItems
		{
			get { return _selectedItems; }
		}
		#endregion

		#region Constructors
		static MultiSelectTreeView()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(MultiSelectTreeView), new FrameworkPropertyMetadata(typeof(MultiSelectTreeView)));
		}



		#endregion

		protected override DependencyObject GetContainerForItemOverride()
		{
			return new MultiSelectTreeViewItem();
		}

		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is MultiSelectTreeViewItem;
		}

		protected override void OnItemsSourceChanged(System.Collections.IEnumerable oldValue, System.Collections.IEnumerable newValue)
		{
			_selectedItems.Clear();

			base.OnItemsSourceChanged(oldValue, newValue);
		}

		internal void OnSelectionStateChanged(MultiSelectTreeViewItem viewItem, bool newSelectionState)
		{
			if (true == newSelectionState)
				AddItemToSelection(viewItem);
			else
				RemoveItemFromSelection(viewItem);
		}

		protected override void OnPreviewKeyDown(KeyEventArgs e)
		{
			if (e.Key == Key.C && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
			{

				//e.Handled = true;
			}
			base.OnPreviewKeyDown(e);
		}

		internal void OnViewItemMouseDown(MultiSelectTreeViewItem viewItem)
		{
			MultiSelectTreeViewItem newItem = viewItem;
			if (viewItem == null)
				return;

			switch (this.SelectionMode)
			{
				case SelectionModalities.MultipleSelectionOnly:
					ManageCtrlSelection(newItem);
					break;
				case SelectionModalities.SingleSelectionOnly:
					ManageSingleSelection(newItem);
					break;
				case SelectionModalities.KeyboardModifiersMode:
					if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
					{
						ManageShiftSelection(newItem);
					}
					else if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
					{
						ManageCtrlSelection(newItem);
					}
					else
					{
						ManageSingleSelection(newItem);
					}
					break;
			}
		}

		protected internal void OnViewItemMouseDoubleClick(MultiSelectTreeViewItem viewItem)
		{
			if (null != ItemMouseDoubleClick)
				ItemMouseDoubleClick(this, EventArgs.Empty);
		}

		#region Methods
		public void UnselectAll()
		{
			var selItemsCopy = _selectedItems.ToArray(); // use a copy of the collection since IsSelected=false causes the removal of the item from the collection
			foreach (MultiSelectTreeViewItem item in selItemsCopy)
				item.IsSelected = false;

			_selectedItems.Clear();
			_lastClickedItem = null;
		}

		public void SelectAll()
		{
			foreach (MultiSelectTreeViewItem item in Items)
				item.SelectAllChildren();
		}
		#endregion

		#region Helper Methods
		private void AddItemToSelection(MultiSelectTreeViewItem newItem)
		{
			if (!_selectedItems.Contains(newItem))
				_selectedItems.Add(newItem);
		}

		private void RemoveItemFromSelection(MultiSelectTreeViewItem newItem)
		{
			if (_selectedItems.Contains(newItem))
				_selectedItems.Remove(newItem);
		}


		private void ManageSingleSelection(MultiSelectTreeViewItem viewItem)
		{
			UnselectAll();
			viewItem.IsSelected = true;
			_lastClickedItem = viewItem;
		}

		private void ManageCtrlSelection(MultiSelectTreeViewItem viewItem)
		{
			viewItem.IsSelected = !viewItem.IsSelected;
			_lastClickedItem = viewItem;
		}

		private void ManageShiftSelection(MultiSelectTreeViewItem viewItem)
		{
			if (_lastClickedItem == null)
				_lastClickedItem = Items[0] as MultiSelectTreeViewItem;

			if (_lastClickedItem == null)
				return;

			MultiSelectTreeViewItem.SelectAllNodesInbetween(_lastClickedItem, viewItem, true);
		}
		#endregion

	}
}
