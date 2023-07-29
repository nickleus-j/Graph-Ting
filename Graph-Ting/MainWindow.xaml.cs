using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GraphTing.Models.BinaryTrees;

namespace Graph_Ting
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Sample collection of integers
            int[] values = { 90,4,56,100,21,455,221,89,6};

            // Create the binary tree and add nodes
            BinaryTree binaryTree = new BinaryTree();
            foreach (int value in values)
            {
                binaryTree.Insert(value);
            }

            // Display the binary tree in the TreeView
            DisplayBinaryTree(binaryTree, BinaryTreeView);
        }

        private void DisplayBinaryTree(BinaryTree binaryTree, TreeView treeView)
        {
            TreeNode root = binaryTree.Root;
            treeView.Items.Add(CreateTreeViewItem(root));
        }

        private TreeViewItem CreateTreeViewItem(TreeNode node)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = node.Value.ToString();

            if (node.Left != null)
            {
                item.Items.Add(CreateTreeViewItem(node.Left));
            }

            if (node.Right != null)
            {
                item.Items.Add(CreateTreeViewItem(node.Right));
            }

            return item;
        }
    }
}
