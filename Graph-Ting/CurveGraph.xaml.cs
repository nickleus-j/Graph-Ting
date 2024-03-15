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
    /// Interaction logic for CurveGraph.xaml
    /// </summary>
    public partial class CurveGraph : UserControl, INodeView
    {
        public CurveGraph()
        {
            InitializeComponent();
            DrawCurvedGraph([100, 24, 78, 56, 67, 90]);
        }

        public void Redraw(ICollection<int> points)
        {
            GraphCanvas.Children.Clear();
            DrawCurvedGraph(points.ToArray());
        }

        private void DrawCurvedGraph(int[] points)
        {
            var pathGeometry = new PathGeometry();
            var pathFigure = new PathFigure();

            for (int i = 0; i < points.Length; i++)
            {
                var point = new Point(i * 20, 200 - points[i]);
                if (i == 0)
                    pathFigure.StartPoint = point;
                else
                    pathFigure.Segments.Add(new LineSegment(point, true));
            }

            pathGeometry.Figures.Add(pathFigure);

            var path = new Path
            {
                Stroke = Brushes.BlueViolet,
                StrokeThickness = 2,
                Data = pathGeometry
            };

            GraphCanvas.Children.Add(path);
        }
    }
}
