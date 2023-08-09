using GraphTing.Models.Avl;
using GraphTing.Models.List;
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
    /// Interaction logic for ListCompo.xaml
    /// </summary>
    public partial class ListCompo : UserControl, INodeView
    {
        public ListCompo()
        {
            InitializeComponent();
            // Sample collection of integers
            int[] values = { 78, 54, 23, 12, 190 };

            Redraw(values);
        }

        public void Redraw(ICollection<int> values)
        {
            listCanvas.Children.Clear();
            ListNode node = new ListNode(),start=node;
            foreach (int value in values)
            {
                ListNode nextNode = new ListNode();
                node.Value = value;
                node.NextNode = nextNode;
                node=nextNode;
            }
            node.NextNode = null;
            DrawList(start, listCanvas, 100, 20, 0);
        }
        private void DrawList(ListNode root, Canvas canvas, double x, double y, double offsetX)
        {
            if (root == null)
            {
                return;
            }

            DrawNode(root.Value.ToString(), canvas, x, y);
            double startY = y + 20, endY = y + 50;
            
            if (root.NextNode != null)
            {
                DrawEdge(canvas, x, startY, x, endY);
                DrawList(root.NextNode, canvas, x , endY, offsetX/2 );
            }
            
        }
        private void DrawNode(string value, Canvas canvas, double x, double y)
        {
            double diameter = 40, radius = diameter / 2;
            Ellipse ellipse = new Ellipse
            {
                Width = diameter,
                Height = diameter,
                Fill = Brushes.LightSeaGreen,
                Stroke = Brushes.Teal,
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
