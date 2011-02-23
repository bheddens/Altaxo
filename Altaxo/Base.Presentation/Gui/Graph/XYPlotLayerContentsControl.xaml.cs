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

using Altaxo.Collections;

namespace Altaxo.Gui.Graph
{
	/// <summary>
	/// Interaction logic for XYPlotLayerContentsControl.xaml
	/// </summary>
	public partial class XYPlotLayerContentsControl : UserControl, ILineScatterLayerContentsView
	{
		private ILineScatterLayerContentsController m_Ctrl;


		public XYPlotLayerContentsControl()
		{
			InitializeComponent();
		}

		void EhCommand_CopyPreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
		}

		void EhCommand_CopyCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = m_Contents_lbContents.SelectedItems.Count > 0;
			e.Handled = true;
		}

		void EhCommand_CopyExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			Controller.EhView_CopyClipboard(SelectedNodes(this.m_Contents_lbContents));
			e.Handled = true;
		}

		void EhCommand_PasteCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = Controller.EhView_CanPasteFromClipboard();
			e.Handled = true;
		}

		void EhCommand_PasteExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			Controller.EhView_PasteClipboard();
			e.Handled = true;
		}

		protected override void OnPreviewKeyDown(KeyEventArgs e)
		{
			base.OnPreviewKeyDown(e);
		}

		NGTreeNode[] SelectedNodes(Altaxo.Gui.Common.MultiSelectTreeView tree)
		{
			var sel = tree.SelectedItems;
			var list = new List<NGTreeNode>();
			foreach (var s in sel)
			{
				var item = s.Header as NGTreeNode;
				if (null != item)
					list.Add(item);
			}
			var result = list.ToArray();
			NGTreeNode.SortByOrder(result);
			return result;
		}


		private void EhPutData_Click(object sender, RoutedEventArgs e)
		{
			if (null != Controller)
			{
				Controller.EhView_PutData(SelectedNodes(this.m_Content_tvDataAvail));
				this.m_Contents_lbContents.Focus();
			}
		}

		private void EhPullData_Click(object sender, RoutedEventArgs e)
		{
			if (null != Controller)
			{
				Controller.EhView_PullDataClick(SelectedNodes(this.m_Contents_lbContents));
			}
		}

		private void EhListSelUp_Click(object sender, RoutedEventArgs e)
		{
			if (null != Controller)
			{
				Controller.EhView_ListSelUpClick(SelectedNodes(this.m_Contents_lbContents));
				this.m_Contents_lbContents.Focus();
			}
		}

		private void EhListSelDown_Click(object sender, RoutedEventArgs e)
		{
			if (null != Controller)
			{
				Controller.EhView_SelDownClick(SelectedNodes(this.m_Contents_lbContents));
				this.m_Contents_lbContents.Focus();
			}
		}

		private void EhPlotAssociations_Click(object sender, RoutedEventArgs e)
		{
			if (null != Controller)
			{
				Controller.EhView_PlotAssociationsClick(SelectedNodes(this.m_Contents_lbContents));
				this.m_Contents_lbContents.Focus();
			}
		}

		private void EhGroup_Click(object sender, RoutedEventArgs e)
		{
			if (null != Controller)
			{
				Controller.EhView_GroupClick(SelectedNodes(this.m_Contents_lbContents));
				this.m_Contents_lbContents.Focus();
			}
      
		}

		private void EhUngroup_Click(object sender, RoutedEventArgs e)
		{
			if (null != Controller)
			{
				Controller.EhView_UngroupClick(SelectedNodes(this.m_Contents_lbContents));
				this.m_Contents_lbContents.Focus();
			}
		}

		private void EhEditRange_Click(object sender, RoutedEventArgs e)
		{
			if (null != Controller)
			{
				Controller.EhView_EditRangeClick(SelectedNodes(this.m_Contents_lbContents));
				this.m_Contents_lbContents.Focus();
			}
		}

		private void EhShowRange_CheckedChanged(object sender, RoutedEventArgs e)
		{

		}

		#region ILineScatterLayerContentsView

		public ILineScatterLayerContentsController Controller
		{
			get
			{
				return m_Ctrl;
			}
			set
			{
				m_Ctrl = value;
			}
		}

		Collections.NGTreeNodeCollection _dataAvailable;
		public void DataAvailable_Initialize(Collections.NGTreeNodeCollection nodes)
		{
			var oldItems = _dataAvailable;
			_dataAvailable = nodes;
			if (oldItems != _dataAvailable) 
			m_Content_tvDataAvail.ItemsSource = _dataAvailable;
		}

		public void DataAvailable_ClearSelection()
		{
			if (null != _dataAvailable)
				foreach (var n in _dataAvailable)
					n.ClearSelectionRecursively();
		}

		Collections.NGTreeNodeCollection _layerContents;
		public void Contents_SetItems(Collections.NGTreeNodeCollection items)
		{
			var oldItems = _layerContents;
			_layerContents = items;
			if(oldItems!=_layerContents)
			m_Contents_lbContents.ItemsSource = _layerContents;
		}

		public void Contents_RemoveItems(Collections.NGTreeNode[] items)
		{
			foreach (NGTreeNode node in items)
				node.Remove();				
		}

		public void Contents_SetSelected(int idx, bool bSelected)
		{
			
		}

		public void Contents_InvalidateItems(int idx1, int idx2)
		{
			
		}

		public object ControllerObject
		{
			get
			{
				return m_Ctrl;
			}
			set
			{
				m_Ctrl = value as ILineScatterLayerContentsController;
			}
		}

		#endregion

		private void EhItemMouseDoubleClick(object sender, EventArgs e)
		{
			if (null != Controller)
			{
				if (this.m_Contents_lbContents.SelectedItems.Count == 1)
				{
					Controller.EhView_ContentsDoubleClick(m_Contents_lbContents.SelectedItems[0].Header as NGTreeNode);
				}
				this.m_Contents_lbContents.Focus();
			}
		}
	}
}
