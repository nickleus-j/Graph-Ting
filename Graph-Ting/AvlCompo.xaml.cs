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
using GraphTing.Models.Avl;

namespace Graph_Ting
{
    /// <summary>
    /// Interaction logic for AvlCompo.xaml
    /// </summary>
    public partial class AvlCompo : UserControl, INodeView
    {
        public AvlCompo()
        {
            InitializeComponent();
            // Sample collection of integers
            int[] values = { 78,54,23,90,21,89,123,12,190 };

            Redraw(values);
        }
        public void Redraw(ICollection<int> values)
        {
            AvlCanvas.Children.Clear();
            AVLTree avlTree = new AVLTree();
            foreach (int value in values)
            {
                avlTree.Insert(value);
            }
            DrawAVLTree(avlTree.Root, AvlCanvas, 150, 40, 75);
        }
        private void DrawAVLTree(AVLNode root, Canvas canvas, double x, double y, double offsetX)
        {
            if (root == null)
            {
                return;
            }

            DrawNode(root.Value.ToString(), canvas, x, y);
            double startY = y + 20, endY = y + 90;
            if (root.Left != null)
            {
                DrawEdge(canvas, x, startY, x - offsetX, endY);
                DrawAVLTree(root.Left, canvas, x - offsetX, endY, offsetX / 2);
            }

            if (root.Right != null)
            {
                DrawEdge(canvas, x, startY, x + offsetX, endY);
                DrawAVLTree(root.Right, canvas, x + offsetX, endY, offsetX / 2);
            }
        }

        private void DrawNode(string value, Canvas canvas, double x, double y)
        {
            double diameter = 40, radius = diameter / 2;
            Ellipse ellipse = new Ellipse
            {
                Width = diameter,
                Height = diameter,
                Fill = Brushes.LightCyan,
                Stroke = Brushes.DarkCyan,
                StrokeThickness = 1
            };

            canvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, x - radius);
            Canvas.SetTop(ellipse, y - radius);

            TextBlock textBlock = new TextBlock
            {
                Text = value,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            
            canvas.Children.Add(textBlock);
            Canvas.SetLeft(textBlock, x - radius);
            Canvas.SetTop(textBlock, y - radius);
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

}
