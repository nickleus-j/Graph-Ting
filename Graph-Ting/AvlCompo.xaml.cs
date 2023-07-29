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
    /// Interaction logic for AvlCompo.xaml
    /// </summary>
    public partial class AvlCompo : UserControl
    {
        public AvlCompo()
        {
            InitializeComponent();
            // Sample collection of integers
            int[] values = { 78,54,23,90,34,170,21,89,123,12,6,45 };

            // Create the AVL tree and add nodes
            AVLTree avlTree = new AVLTree();
            foreach (int value in values)
            {
                avlTree.Insert(value);
            }

            // Display the AVL tree on the Canvas
            DrawAVLTree(avlTree.Root, AvlCanvas, 400, 50, 40);
        }
        private void DrawAVLTree(AVLNode root, Canvas canvas, double x, double y, double offsetX)
        {
            if (root == null)
            {
                return;
            }

            DrawNode(root.Value.ToString(), canvas, x, y);

            if (root.Left != null)
            {
                DrawEdge(canvas, x, y, x - offsetX, y + 80);
                DrawAVLTree(root.Left, canvas, x - offsetX, y + 80, offsetX / 2);
            }

            if (root.Right != null)
            {
                DrawEdge(canvas, x, y, x + offsetX, y + 80);
                DrawAVLTree(root.Right, canvas, x + offsetX, y + 80, offsetX / 2);
            }
        }

        private void DrawNode(string value, Canvas canvas, double x, double y)
        {
            Ellipse ellipse = new Ellipse
            {
                Width = 30,
                Height = 30,
                Fill = Brushes.LightCyan,
                Stroke = Brushes.DarkCyan,
                StrokeThickness = 1
            };

            canvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, x - 15);
            Canvas.SetTop(ellipse, y - 15);

            TextBlock textBlock = new TextBlock
            {
                Text = value,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            canvas.Children.Add(textBlock);
            Canvas.SetLeft(textBlock, x - 15);
            Canvas.SetTop(textBlock, y - 15);
        }

        private void DrawEdge(Canvas canvas, double startX, double startY, double endX, double endY)
        {
            Line line = new Line
            {
                X1 = startX,
                Y1 = startY,
                X2 = endX,
                Y2 = endY,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };

            canvas.Children.Add(line);
        }
    }

    public class AVLNode
    {
        public int Value { get; set; }
        public int Height { get; set; }
        public AVLNode Left { get; set; }
        public AVLNode Right { get; set; }

        public AVLNode(int value)
        {
            Value = value;
            Height = 1;
            Left = null;
            Right = null;
        }
    }

    public class AVLTree
    {
        public AVLNode Root { get; set; }

        public AVLTree()
        {
            Root = null;
        }

        // AVL tree insert method (omitted for brevity)
        // Helper method to get the height of a node
        private int GetHeight(AVLNode node)
        {
            if (node == null)
                return 0;
            return node.Height;
        }

        // Helper method to calculate the balance factor of a node
        private int GetBalance(AVLNode node)
        {
            if (node == null)
                return 0;
            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        // Helper method to update the height of a node
        private void UpdateHeight(AVLNode node)
        {
            if (node != null)
                node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }

        // Helper method to perform right rotation
        private AVLNode RotateRight(AVLNode y)
        {
            AVLNode x = y.Left;
            AVLNode T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            UpdateHeight(y);
            UpdateHeight(x);

            return x;
        }

        // Helper method to perform left rotation
        private AVLNode RotateLeft(AVLNode x)
        {
            AVLNode y = x.Right;
            AVLNode T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            UpdateHeight(x);
            UpdateHeight(y);

            return y;
        }

        // Insert a new value into the AVL tree
        public void Insert(int value)
        {
            Root = Insert(Root, value);
        }

        private AVLNode Insert(AVLNode node, int value)
        {
            // Perform standard BST insertion
            if (node == null)
                return new AVLNode(value);

            if (value < node.Value)
                node.Left = Insert(node.Left, value);
            else if (value > node.Value)
                node.Right = Insert(node.Right, value);
            else // Duplicate values are not allowed in the AVL tree
                return node;

            // Update the height of the current node
            UpdateHeight(node);

            // Get the balance factor to check if the node is unbalanced
            int balance = GetBalance(node);

            // Left-Left case: Perform right rotation
            if (balance > 1 && value < node.Left.Value)
                return RotateRight(node);

            // Right-Right case: Perform left rotation
            if (balance < -1 && value > node.Right.Value)
                return RotateLeft(node);

            // Left-Right case: Perform left rotation on left child and then right rotation on the current node
            if (balance > 1 && value > node.Left.Value)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            // Right-Left case: Perform right rotation on right child and then left rotation on the current node
            if (balance < -1 && value < node.Right.Value)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            // Return the unchanged node
            return node;
        }
        // Implement AVL rotation methods to keep the tree balanced

        // You can find these methods in AVL tree implementations
    }
}
