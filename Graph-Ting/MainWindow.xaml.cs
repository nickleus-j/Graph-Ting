using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GraphTing.Models.BinaryTrees;

namespace Graph_Ting
{
    public partial class MainWindow : Window
    {
        public GivenElements WindowElements { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            int[] values = { 78, 54, 23, 90, 34, 170, 21, 89, 123, 12, 6, 45, 190 };
            WindowElements =new GivenElements();
            WindowElements.Numbers = values.ToList();
            Elements.Numbers = WindowElements.Numbers;
            listTreeView?.Redraw(WindowElements?.Numbers);
            DivGraphView.Redraw(WindowElements?.Numbers.ToImmutableSortedSet());
        }

        private void ReDrawBtn_Click(object sender, RoutedEventArgs e)
        {
            BinaryTreeView.Redraw(WindowElements.Numbers);
            WindowElements.CurrentGraphView = avlTreeView;
            WindowElements?.Draw();
            listTreeView?.Redraw(WindowElements?.Numbers);
            DivGraphView.Redraw(WindowElements?.Numbers.ToImmutableSortedSet());
        }
    }
}
