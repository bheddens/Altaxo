﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

using Altaxo;
using Altaxo.Collections;

namespace Altaxo.Gui
{
	public static class GuiHelper
	{
		#region Combobox

		public static void Initialize(ComboBox view, SelectableListNodeList data)
		{
			int idx = data.FirstSelectedNodeIndex; // Note: the selected index must be determined _before_ the data are bound to the box (otherwise when a binding is in place, it can happen that the selection is resetted)

			if (view.ItemsSource != data)
			{
				//view.ItemsSource = null; 
				view.ItemsSource = data;
			}

			if (idx >= 0)
				view.SelectedItem = data[idx];
		}

		public static void SynchronizeSelectionFromGui(ComboBox view)
		{
			foreach (ISelectableItem it in view.ItemsSource)
				it.IsSelected = false;

			if (null != view.SelectedItem)
				((ISelectableItem)view.SelectedItem).IsSelected = true;
		}
		#endregion

		#region ListBox

		public static void Initialize(ListBox view, SelectableListNodeList data)
		{
			view.ItemsSource = null;
			view.ItemsSource = data;
			if (view.SelectionMode == SelectionMode.Single)
			{
				view.SelectedIndex = data.FirstSelectedNodeIndex;
			}
			else
			{
				foreach (var n in data)
					if (n.IsSelected)
						view.SelectedItems.Add(n);
			}
		}

		/// <summary>
		/// Sets the items of a list box with <see cref="CheckableSelectableListNode"/> items. We presume here that the ListBox has an appropriate DataTemplate, thus only the ItemsSource
		/// property of the ListBox is set with the data.
		/// </summary>
		/// <param name="view">ListBox to set.</param>
		/// <param name="data">The data to set for the ListBox.</param>
		public static void Initialize(ListBox view, CheckableSelectableListNodeList data)
		{
			view.ItemsSource = data;
		}

		public static void SynchronizeSelectionFromGui(ListBox view)
		{
			foreach (ISelectableItem it in view.ItemsSource)
				it.IsSelected = false;

			if (null != view.SelectedItem)
				((ISelectableItem)view.SelectedItem).IsSelected = true;
		}

		#endregion

		#region ListView


		public static void Initialize(ListView view, SelectableListNodeList data)
		{
			view.ItemsSource = null;
			view.ItemsSource = data;

			if (view.SelectionMode == SelectionMode.Single)
			{
				view.SelectedIndex = data.FirstSelectedNodeIndex;
			}
			else
			{
				foreach (var n in data)
					if (n.IsSelected)
						view.SelectedItems.Add(n);
			}
		}

		public static void Refresh(ListView view)
		{
			var h = view.ItemsSource;
			view.ItemsSource = null;
			view.ItemsSource = h;
		}

		public static void SynchronizeSelectionFromGui(ListView listView)
		{
			if (null != listView.ItemsSource)
			{
				foreach (ISelectableItem it in listView.ItemsSource)
					it.IsSelected = false;
			}

			foreach (ISelectableItem it in listView.SelectedItems)
				it.IsSelected = true;
		}

		public static int[] GetColumnWidths(ListView listView)
		{
			GridView gv = (GridView)listView.View;

			int[] ret = new int[gv.Columns.Count];
			for (int i = 0; i < ret.Length; i++)
				ret[i] = (int)gv.Columns[i].ActualWidth;
			return ret;
		}

		public static void SetColumnWidths(ListView listView, int[] widths)
		{
			GridView gv = (GridView)listView.View;

			int len = Math.Min(widths.Length, gv.Columns.Count);
			for (int i = 0; i < len; i++)
				gv.Columns[i].Width = widths[i];
		}


		#endregion

		#region Mouse

		public static Altaxo.Gui.AltaxoMouseButtons GetMouseState(MouseDevice mouse)
		{
			var result = Altaxo.Gui.AltaxoMouseButtons.None;
			if (MouseButtonState.Pressed == mouse.LeftButton) result |= AltaxoMouseButtons.Left;
			if (MouseButtonState.Pressed == mouse.MiddleButton) result |= AltaxoMouseButtons.Middle;
			if (MouseButtonState.Pressed == mouse.RightButton) result |= AltaxoMouseButtons.Right;
			if (MouseButtonState.Pressed == mouse.XButton1) result |= AltaxoMouseButtons.XButton1;
			if (MouseButtonState.Pressed == mouse.XButton2) result |= AltaxoMouseButtons.XButton2;

			return result;
		}

		public static Altaxo.Gui.AltaxoMouseButtons GetMouseState(MouseButtonEventArgs mouse)
		{
			var result = Altaxo.Gui.AltaxoMouseButtons.None;
			if (MouseButtonState.Pressed == mouse.LeftButton) result |= AltaxoMouseButtons.Left;
			if (MouseButtonState.Pressed == mouse.MiddleButton) result |= AltaxoMouseButtons.Middle;
			if (MouseButtonState.Pressed == mouse.RightButton) result |= AltaxoMouseButtons.Right;
			if (MouseButtonState.Pressed == mouse.XButton1) result |= AltaxoMouseButtons.XButton1;
			if (MouseButtonState.Pressed == mouse.XButton2) result |= AltaxoMouseButtons.XButton2;

			return result;
		}

		#endregion

		#region Brush and Pen

		public static System.Windows.Media.Brush ToWpf(this Altaxo.Graph.Gdi.BrushX brushx)
		{
			System.Drawing.Color s = brushx.Color;
			System.Windows.Media.Color c = System.Windows.Media.Color.FromArgb(s.A, s.R, s.G, s.B);
			var result = new System.Windows.Media.SolidColorBrush(c);
			return result;
		}

		public static System.Windows.Media.Pen ToWpf(this Altaxo.Graph.Gdi.PenX penx)
		{
			System.Drawing.Color s = penx.Color;
			System.Windows.Media.Color c = System.Windows.Media.Color.FromArgb(s.A, s.R, s.G, s.B);
			var result = new System.Windows.Media.Pen(new System.Windows.Media.SolidColorBrush(c), penx.Width);
			return result;
		}


		public static System.Windows.Media.Color ToWpf(this System.Drawing.Color c)
		{
			return Color.FromArgb(c.A, c.R, c.G, c.B);
		}

		public static System.Drawing.Color ToSysDraw(this System.Windows.Media.Color c)
		{
			return System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);
		}
		#endregion

		#region Graphics primitives

		#region Point

		public static Point ToWpf(this Altaxo.Graph.PointD2D pt)
		{
			return new Point(pt.X, pt.Y);
		}

		public static Point ToWpf(this System.Drawing.PointF pt)
		{
			return new Point(pt.X, pt.Y);
		}

		public static Point ToWpf(this System.Drawing.Point pt)
		{
			return new Point(pt.X, pt.Y);
		}

		public static Altaxo.Graph.PointD2D ToAltaxo(this Point pt)
		{
			return new Altaxo.Graph.PointD2D(pt.X, pt.Y);
		}

		public static System.Drawing.PointF ToSysDraw(this Point pt)
		{
			return new System.Drawing.PointF((float)pt.X, (float)pt.Y);
		}

		public static System.Drawing.Point ToSysDrawInt(this Point pt)
		{
			return new System.Drawing.Point((int)pt.X, (int)pt.Y);
		}

		#endregion

		#region Rectangle

		public static Rect ToWpf(this Altaxo.Graph.RectangleD rect)
		{
			return new Rect(rect.X, rect.Y, rect.Width, rect.Height);
		}

		public static Rect ToWpf(this System.Drawing.RectangleF rect)
		{
			return new Rect(rect.X, rect.Y, rect.Width, rect.Height);
		}

		public static Rect ToWpf(this System.Drawing.Rectangle rect)
		{
			return new Rect(rect.X, rect.Y, rect.Width, rect.Height);
		}

		public static Altaxo.Graph.RectangleD ToAltaxo(this Rect rect)
		{
			return new Altaxo.Graph.RectangleD(rect.X, rect.Y, rect.Width, rect.Height);
		}

		public static System.Drawing.RectangleF ToSysDraw(this Rect rect)
		{
			return new System.Drawing.RectangleF((float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height);
		}

		public static System.Drawing.Rectangle ToSysDrawInt(this Rect rect)
		{
			return new System.Drawing.Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
		}

		#endregion

		#endregion

		#region Panel Helpers


		public static void InitializeChoicePanel<TChoiceGuiElement>(Panel panel, SelectableListNodeList choices) where TChoiceGuiElement: ToggleButton, new()
		{
			panel.Tag = choices;
			panel.Children.Clear();
			foreach (var choice in choices)
			{
				var rb = new TChoiceGuiElement();
				rb.Content = choice.Text;
				rb.Tag = choice;
				rb.SetBinding(ToggleButton.IsCheckedProperty,new System.Windows.Data.Binding("Selected") { Source=choice, Mode= System.Windows.Data.BindingMode.TwoWay });
				panel.Children.Add(rb);
			}
		}


		#endregion

	}
}
