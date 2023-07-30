using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTing.Models.Avl
{
    public class AVLTree
    {
        public AVLNode Root { get; set; }

        public AVLTree()
        {
            Root = null;
        }

        // AVL tree insert method (omitted for brevity)
        // Helper method to get the height of a node
        private int GetHeight(AVLNode? node)
        {
            if (node == null)
                return 0;
            return node.Height;
        }

        // Helper method to calculate the balance factor of a node
        private int GetBalance(AVLNode? node)
        {
            if (node == null)
                return 0;
            return GetHeight(node?.Left) - GetHeight(node?.Right);
        }

        // Helper method to update the height of a node
        private void UpdateHeight(AVLNode node)
        {
            if (node != null)
                node.Height = Math.Max(GetHeight(node?.Left), GetHeight(node?.Right)) + 1;
        }

        // Helper method to perform right rotation
        private AVLNode RotateRight(AVLNode? y)
        {
            AVLNode x = y?.Left;
            AVLNode T2 = x?.Right;

            x.Right = y;
            y.Left = T2;

            UpdateHeight(y);
            UpdateHeight(x);

            return x;
        }

        // Helper method to perform left rotation
        private AVLNode RotateLeft(AVLNode? x)
        {
            AVLNode y = x?.Right;
            AVLNode T2 = y?.Left;

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

        private AVLNode Insert(AVLNode? node, int value)
        {
            // Perform standard BST insertion
            if (node == null)
                return new AVLNode(value);

            if (value < node.Value)
                node.Left = Insert(node.Left, value);
            else if (value > node.Value)
                node.Right = Insert(node.Right, value);
            else // No Duplicate values in the AVL tree
                return node;

            // Update the height of the current node
            UpdateHeight(node);

            // Get the balance factor to check if the node is unbalanced
            int balance = GetBalance(node);

            // Left-Left case: Rotate Right
            if (balance > 1 && value < node.Left.Value)
                return RotateRight(node);

            // Right-Right case: Rotate left
            if (balance < -1 && value > node.Right.Value)
                return RotateLeft(node);

            // Left-Right case:  left rotation on left child and then right rotation on the current node
            if (balance > 1 && value > node.Left.Value)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            // Right-Left case:  right rotation on right child and then left rotation on the current node
            if (balance < -1 && value < node.Right.Value)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            // Return the unchanged node
            return node;
        }
    }
}
