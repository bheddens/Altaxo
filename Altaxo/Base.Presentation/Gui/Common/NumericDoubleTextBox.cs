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
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Altaxo.Gui.Common
{
	public class NumericDoubleTextBox : TextBox
	{
		public event DependencyPropertyChangedEventHandler SelectedValueChanged;

		private NumericDoubleConverter _converter;

		/// <summary>
		/// Static initialization.
		/// </summary>
		static NumericDoubleTextBox()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericDoubleTextBox), new FrameworkPropertyMetadata(typeof(NumericDoubleTextBox)));
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		public NumericDoubleTextBox()
		{
			var binding = new Binding();
			binding.Source = this;
			binding.Path = new PropertyPath("SelectedValue");
			binding.Mode = BindingMode.TwoWay;
			binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			_converter = new NumericDoubleConverter();
			binding.Converter = _converter;
			binding.ValidationRules.Add(_converter);
			this.SetBinding(TextBox.TextProperty, binding);
		}

		public bool AllowNaNValues { get { return _converter.AllowNaNValues; } set { _converter.AllowNaNValues = value; } }

		public bool AllowInfiniteValues { get { return _converter.AllowInfiniteValues; } set { _converter.AllowInfiniteValues = value; } }

		public bool DisallowNegativeValues { get { return _converter.DisallowNegativeValues; } set { _converter.DisallowNegativeValues = value; } }

		public bool DisallowZeroValues { get { return _converter.DisallowZeroValues; } set { _converter.DisallowZeroValues = value; } }

		#region Change selection behaviour

		// The next three overrides change the selection behaviour of the text box as described in
		// 'How to SelectAll in TextBox when TextBox gets focus by mouse click?'
		// (http://social.msdn.microsoft.com/Forums/en-US/wpf/thread/564b5731-af8a-49bf-b297-6d179615819f/)

		protected override void OnGotKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventArgs e)
		{
			SelectAll();
			base.OnGotKeyboardFocus(e);
		}

		protected override void OnMouseDoubleClick(System.Windows.Input.MouseButtonEventArgs e)
		{
			SelectAll();
			base.OnMouseDoubleClick(e);
		}

		protected override void OnPreviewMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
		{
			if (!IsKeyboardFocusWithin)
			{
				e.Handled = true;
				Focus();
			}
			else
			{
				base.OnPreviewMouseLeftButtonDown(e);
			}
		}

		#endregion Change selection behaviour

		#region Dependency property

		/// <summary>
		/// Gets/sets the quantity. The quantity consist of a numeric value together with a unit.
		/// </summary>
		public double SelectedValue
		{
			get { return (double)GetValue(SelectedValueProperty); }
			set { SetValue(SelectedValueProperty, value); }
		}

		public static readonly DependencyProperty SelectedValueProperty =
				DependencyProperty.Register("SelectedValue", typeof(double), typeof(NumericDoubleTextBox),
				new FrameworkPropertyMetadata(EhSelectedValueChanged));

		private static void EhSelectedValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			((NumericDoubleTextBox)obj).OnSelectedValueChanged(obj, args);
		}

		/// <summary>
		/// Triggers the <see cref="SelectedValueChanged"/> event.
		/// </summary>
		/// <param name="obj">Dependency object (here: the control).</param>
		/// <param name="args">Property changed event arguments.</param>
		protected void OnSelectedValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			if (null != SelectedValueChanged)
				SelectedValueChanged(obj, args);
		}

		#endregion Dependency property
	}
}