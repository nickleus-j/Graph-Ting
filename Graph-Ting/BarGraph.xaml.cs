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
    /// Interaction logic for BarGraph.xaml
    /// </summary>
    public partial class BarGraph : UserControl, INodeView
    {
        public BarGraph()
        {
            InitializeComponent();
            // Sample collection of integers
            int[] values = { 90, 4, 56, 100, 21, 41, 45, 221, 89, 6, 200, 122, 211 };
            Redraw(values);
        }

        public void Redraw(ICollection<int> values)
        {
            GraphCanvas.Children.Clear();

            if (values.Count == 0)
                return;

            double canvasWidth = GraphCanvas.ActualWidth;
            double canvasHeight = GraphCanvas.ActualHeight;

            // Wait for layout if necessary
            if (canvasWidth == 0 || canvasHeight == 0)
            {
                Loaded += (_, __) => Redraw(values);
                return;
            }

            int maxVal = 0;
            foreach (var val in values)
                if (val > maxVal) maxVal = val;

            double barWidth = canvasWidth / values.Count;
            double spacing = 5;

            for (int i = 0; i < values.Count; i++)
            {
                double heightRatio = (double)values.ElementAt(i) / maxVal;
                double barHeight = heightRatio * canvasHeight;

                Rectangle rect = new Rectangle
                {
                    Width = barWidth - spacing,
                    Height = barHeight,
                    Fill = Brushes.DarkKhaki
                };

                Canvas.SetLeft(rect, i * barWidth);
                Canvas.SetTop(rect, canvasHeight - barHeight);

                GraphCanvas.Children.Add(rect);
                TextBlock textBlock = new TextBlock
                {
                    Text = values.ElementAt(i).ToString(),
                    FontFamily = new FontFamily("Consolas"),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                Canvas.SetLeft(textBlock, i * barWidth);
                Canvas.SetTop(textBlock, canvasHeight-5);
                GraphCanvas.Children.Add(textBlock);
            }
        }
    }
}
