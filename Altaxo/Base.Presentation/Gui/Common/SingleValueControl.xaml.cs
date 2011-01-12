﻿using System;
using System.Collections.Generic;
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
	/// Interaction logic for SingleValueControl.xaml
	/// </summary>
	public partial class SingleValueControl : UserControl , ISingleValueView
	{
		public SingleValueControl()
		{
			InitializeComponent();
		}

		#region ISingleValueView

		public string DescriptionText
		{
			set { _lblDescription.Content = value; }
		}

		public string ValueText
		{
			get
			{
				return _edEditText.Text;
			}
			set
			{
			_edEditText.Text = value;
			}
		}

		public event Action<ValidationEventArgs<string>> ValueText_Validating;

		#endregion
	

		private void EhValidating(object sender, ValidationEventArgs<string> e)
		{
			if (null != ValueText_Validating)
				ValueText_Validating(e);
		}
	}
}