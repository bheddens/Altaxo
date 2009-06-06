﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision: 3559 $</version>
// </file>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.Gui;

namespace ICSharpCode.SharpDevelop.Project.Commands
{
	public class RenameEntryEvent : AbstractMenuCommand
	{
		public override void Run()
		{
			AbstractProjectBrowserTreeNode node  = ProjectBrowserPad.Instance.SelectedNode;
			if (node == null) {
				return;
			}
			
			ProjectBrowserPad.Instance.ProjectBrowserControl.Select();
			ProjectBrowserPad.Instance.ProjectBrowserControl.Focus();
			ProjectBrowserPad.Instance.StartLabelEdit(node);
		}
	}
	
	public class OpenFileFromProjectBrowser : AbstractMenuCommand
	{
		public override void Run()
		{
			AbstractProjectBrowserTreeNode node  = ProjectBrowserPad.Instance.SelectedNode;
			if (node == null) {
				return;
			}
			
			node.ActivateItem();
		}
	}
	
	public class OpenFileFromProjectBrowserWith : AbstractMenuCommand
	{
		public override void Run()
		{
			SolutionItemNode solutionItemNode = ProjectBrowserPad.Instance.SelectedNode as SolutionItemNode;
			if (solutionItemNode != null) {
				OpenWith(solutionItemNode.FileName);
				return;
			}
			
			FileNode fileNode = ProjectBrowserPad.Instance.SelectedNode as FileNode;
			if (fileNode != null) {
				OpenWith(fileNode.FileName);
				return;
			}
			
			ProjectNode projectNode = ProjectBrowserPad.Instance.SelectedNode as ProjectNode;
			if (projectNode != null) {
				OpenWith(projectNode.Project.FileName);
				return;
			}
		}
		
		/// <summary>
		/// Shows the OpenWith dialog for the specified file.
		/// </summary>
		static void OpenWith(string fileName)
		{
			var codons = DisplayBindingService.GetCodonsPerFileName(fileName);
			int defaultCodonIndex = codons.IndexOf(DisplayBindingService.GetDefaultCodonPerFileName(fileName));
			using (OpenWithDialog dlg = new OpenWithDialog(codons, defaultCodonIndex, Path.GetExtension(fileName))) {
				if (dlg.ShowDialog(WorkbenchSingleton.MainForm) == DialogResult.OK) {
					FileUtility.ObservedLoad(new FileService.LoadFileWrapper(dlg.SelectedBinding.Binding, true).Invoke, fileName);
				}
			}
		}
	}
	
	/// <summary>
	/// Opens the containing folder in the clipboard.
	/// </summary>
	public class OpenFolderContainingFile : AbstractMenuCommand
	{
		public override void Run()
		{
			SolutionItemNode solutionItemNode = ProjectBrowserPad.Instance.SelectedNode as SolutionItemNode;
			if (solutionItemNode != null) {
				OpenContainingFolderInExplorer(solutionItemNode.FileName);
				return;
			}
			
			FileNode fileNode = ProjectBrowserPad.Instance.SelectedNode as FileNode;
			if (fileNode != null) {
				OpenContainingFolderInExplorer(fileNode.FileName);
				return;
			}
			
			ProjectNode projectNode = ProjectBrowserPad.Instance.SelectedNode as ProjectNode;
			if (projectNode != null) {
				OpenContainingFolderInExplorer(projectNode.Project.FileName);
				return;
			}
		}
		
		public static void OpenContainingFolderInExplorer(string fileName)
		{
			if (File.Exists(fileName)) {
				Process.Start("explorer", "/select,\"" + fileName + "\"");
			}
		}
	}
	
	public class ExcludeFileFromProject : AbstractMenuCommand
	{
		public static void ExcludeFileNode(FileNode fileNode)
		{
			List<FileNode> dependentNodes = new List<FileNode>();
			foreach (TreeNode subNode in fileNode.Nodes) {
				// exclude dependent files
				if (subNode is FileNode)
					dependentNodes.Add((FileNode)subNode);
			}
			dependentNodes.ForEach(ExcludeFileNode);
			
			bool isLink = fileNode.IsLink;
			if (fileNode.ProjectItem != null) { // don't try to exclude same node twice
				ProjectService.RemoveProjectItem(fileNode.Project, fileNode.ProjectItem);
			}
			if (isLink) {
				fileNode.Remove();
			} else {
				fileNode.ProjectItem = null;
				fileNode.FileNodeStatus = FileNodeStatus.None;
				if (fileNode.Parent is ExtTreeNode) {
					((ExtTreeNode)fileNode.Parent).UpdateVisibility();
				}
			}
		}
		
		static void ExcludeDirectoryNode(DirectoryNode directoryNode)
		{
			if (directoryNode.ProjectItem != null) {
				ProjectService.RemoveProjectItem(directoryNode.Project, directoryNode.ProjectItem);
				directoryNode.ProjectItem = null;
			}
			directoryNode.FileNodeStatus = FileNodeStatus.None;
			if (directoryNode.Parent is ExtTreeNode) {
				((ExtTreeNode)directoryNode.Parent).UpdateVisibility();
			}
		}
		
		public override void Run()
		{
			AbstractProjectBrowserTreeNode node  = ProjectBrowserPad.Instance.SelectedNode;
			if (node == null) {
				return;
			}
			
			if (node is FileNode) {
				ExcludeFileNode((FileNode)node);
			} else if (node is DirectoryNode) {
				node.Expanding();
				Stack<TreeNode> nodeStack = new Stack<TreeNode>();
				nodeStack.Push(node);
				while (nodeStack.Count > 0) {
					TreeNode cur = nodeStack.Pop();
					
					if (cur is FileNode) {
						ExcludeFileNode((FileNode)cur);
					} else if (cur is DirectoryNode) {
						ExcludeDirectoryNode((DirectoryNode)cur);
					}
					
					foreach (TreeNode childNode in cur.Nodes) {
						if (childNode is ExtTreeNode) {
							((ExtTreeNode)childNode).Expanding();
						}
						nodeStack.Push(childNode);
					}
				}
			}
			
			ProjectService.SaveSolution();
			((AbstractProjectBrowserTreeNode)node.Parent).Refresh();
		}
	}
	
	public class IncludeFileInProject : AbstractMenuCommand
	{
		public static FileProjectItem IncludeFileNode(FileNode fileNode)
		{
			if (fileNode.Parent is FileNode) {
				if (((FileNode)fileNode.Parent).FileNodeStatus != FileNodeStatus.InProject) {
					IncludeFileNode((FileNode)fileNode.Parent);
				}
			}
			
			if (fileNode.Parent is DirectoryNode && !(fileNode.Parent is ProjectNode)) {
				if (((DirectoryNode)fileNode.Parent).FileNodeStatus != FileNodeStatus.InProject) {
					IncludeDirectoryNode((DirectoryNode)fileNode.Parent, false);
				}
			}
			
			ItemType type = fileNode.Project.GetDefaultItemType(fileNode.FileName);
			
			FileProjectItem newItem = new FileProjectItem(fileNode.Project, type);
			newItem.Include = FileUtility.GetRelativePath(fileNode.Project.Directory, fileNode.FileName);
			
			ProjectService.AddProjectItem(fileNode.Project, newItem);
			
			fileNode.ProjectItem    = newItem;
			fileNode.FileNodeStatus = FileNodeStatus.InProject;
			
			if (fileNode.Parent is ExtTreeNode) {
				((ExtTreeNode)fileNode.Parent).UpdateVisibility();
			}
			fileNode.Project.Save();
			return newItem;
		}
		
		public static void IncludeDirectoryNode(DirectoryNode directoryNode, bool includeSubNodes)
		{
			if (directoryNode.Parent is DirectoryNode && !(directoryNode.Parent is ProjectNode)) {
				if (((DirectoryNode)directoryNode.Parent).FileNodeStatus != FileNodeStatus.InProject) {
					IncludeDirectoryNode((DirectoryNode)directoryNode.Parent, false);
				}
			}
			FileProjectItem newItem = new FileProjectItem(
				directoryNode.Project, ItemType.Folder,
				FileUtility.GetRelativePath(directoryNode.Project.Directory, directoryNode.Directory)
			);
			ProjectService.AddProjectItem(directoryNode.Project, newItem);
			directoryNode.ProjectItem = newItem;
			directoryNode.FileNodeStatus = FileNodeStatus.InProject;
			
			if (includeSubNodes) {
				foreach (TreeNode childNode in directoryNode.Nodes) {
					if (childNode is ExtTreeNode) {
						((ExtTreeNode)childNode).Expanding();
					}
					if (childNode is FileNode) {
						IncludeFileNode((FileNode)childNode);
					} else if (childNode is DirectoryNode) {
						IncludeDirectoryNode((DirectoryNode)childNode, includeSubNodes);
					}
				}
			}
			directoryNode.Project.Save();
		}
		
		public override void Run()
		{
			AbstractProjectBrowserTreeNode node  = ProjectBrowserPad.Instance.SelectedNode;
			if (node == null) {
				return;
			}
			node.Expanding();
			
			if (node is FileNode) {
				IncludeFileNode((FileNode)node);
			} else if (node is DirectoryNode) {
				IncludeDirectoryNode((DirectoryNode)node, true);
			}
			ProjectService.SaveSolution();
			((AbstractProjectBrowserTreeNode)node.Parent).Refresh();
		}
	}
	
	public class AddNewDependentItemsToProject : AddNewItemsToProject
	{
		public override void Run()
		{
			AddDependentItemsToProject(base.AddNewItems);
		}
		
		public static void AddDependentItemsToProject(Func<IEnumerable<FileProjectItem>> itemAdder)
		{
			DirectoryNode dir = ProjectBrowserPad.Instance.ProjectBrowserControl.SelectedDirectoryNode;
			if (dir == null) return;
			
			FileNode fileNode = ProjectBrowserPad.Instance.ProjectBrowserControl.SelectedNode as FileNode;
			if (fileNode == null) {
				LoggingService.Warn("ProjectBrowser: AddNewDependentItemsToProject called on node that is not a FileNode, but: " + fileNode);
				return;
			}
			
			LoggingService.Debug("ProjectBrowser: AddNewDependentItemsToProject on '" + fileNode.FileName + "'");
			
			// Attention: base.AddNewItems may recreate the subnodes,
			// thus invalidating fileNode.
			var addedItems = itemAdder();
			if (addedItems == null) return;
			
			fileNode = dir.AllNodes.OfType<FileNode>().Single(node => FileUtility.IsEqualFileName(node.FileName, fileNode.FileName));
			
			// Find the file nodes that correspond to the added items which
			// do not already have a dependency.
			var dict = addedItems
				.Where(fpi => String.IsNullOrEmpty(fpi.DependentUpon))
				.ToDictionary(
					fpi => dir.AllNodes.OfType<FileNode>().Single(
						node => node.ProjectItem == fpi
					)
				);
			
			if (dict.Count == 0) return;
			
			foreach (KeyValuePair<FileNode, FileProjectItem> pair in dict) {
				LoggingService.Debug("ProjectBrowser: AddNewDependentItemsToProject: Creating dependency for '" + pair.Value.FileName + "' upon '" + fileNode.FileName + "'");
				pair.Value.DependentUpon = Path.GetFileName(fileNode.FileName);
				pair.Key.Remove();
				pair.Key.FileNodeStatus = FileNodeStatus.BehindFile;
				pair.Key.InsertSorted(fileNode);
			}
			
			fileNode.Project.Save();
			
			FileNode primaryAddedNode = dict.Keys.First();
			primaryAddedNode.EnsureVisible();
			primaryAddedNode.TreeView.SelectedNode = primaryAddedNode;
		}
	}
	
	public class AddExistingItemsToProjectAsDependent : AddExistingItemsToProject
	{
		public override void Run()
		{
			AddNewDependentItemsToProject.AddDependentItemsToProject(base.AddExistingItems);
		}
	}
}