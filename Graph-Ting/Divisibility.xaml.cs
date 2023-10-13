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
    /// Interaction logic for Divisibility.xaml
    /// </summary>
    public partial class Divisibility : UserControl, INodeView
    {
        public Divisibility()
        {
            InitializeComponent();

            // Sample collection of integers
            List<int> integers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Redraw(integers);
        }

        public void Redraw(ICollection<int> values)
        {
            // Create a canvas
            Canvas canvas = DivCanvas;
            canvas.Children.Clear();
            // Create nodes for each integer
            Dictionary<int, Ellipse> nodes = new Dictionary<int, Ellipse>();
            int index = 0;
            foreach (int number in values)
            {
                Ellipse ellipse = new Ellipse
                {
                    Width = 30,
                    Height = 30,
                    Fill = Brushes.LightSeaGreen,
                    Stroke = Brushes.LightCyan
                };

                TextBlock textBlock = new TextBlock
                {
                    Text = number.ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize=14,
                };
                int yOffset = index % 2 == 0 ? (index * 20) : index * 5;
                // Position the ellipse and text
                Canvas.SetLeft(ellipse, index * 40);
                Canvas.SetTop(ellipse, 50 + yOffset);
                Canvas.SetLeft(textBlock, index * 40 + 10);
                Canvas.SetTop(textBlock, 50 + 10+ yOffset);

                // Add the ellipse and text to the canvas
                canvas.Children.Add(ellipse);
                canvas.Children.Add(textBlock);

                nodes[number] = ellipse;
                index++;
            }

            // Create edges (lines) between nodes based on divisibility
            foreach (int a in values)
            {
                foreach (int b in values)
                {
                    if (a != b && a % b == 0)
                    {
                        Line line = new Line
                        {
                            X1 = Canvas.GetLeft(nodes[a]) + 15,
                            Y1 = Canvas.GetTop(nodes[a]) + 15,
                            X2 = Canvas.GetLeft(nodes[b]) + 15,
                            Y2 = Canvas.GetTop(nodes[b]) + 15,
                            Stroke = Brushes.LightGray,
                            StrokeThickness = 1,
                        };

                        canvas.Children.Add(line);
                    }
                }
            }
        }
    }
}
