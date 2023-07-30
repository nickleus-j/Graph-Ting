using GraphTing.Models.BinaryTrees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Graph_Ting
{
    /// <summary>
    /// Interaction logic for BinaryTreeCompo.xaml
    /// </summary>
    public partial class BinaryTreeCompo : UserControl, INodeView
    {
        public BinaryTreeCompo()
        {
            InitializeComponent();
            // Sample collection of integers
            int[] values = { 90, 4, 56, 100, 21,41, 455, 221, 89, 6,200,122,211 };
            Redraw(values);
        }
        public void Redraw(ICollection<int> values)
        {
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
            treeView.Items.Clear();
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
