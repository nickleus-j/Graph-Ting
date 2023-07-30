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
    /// Interaction logic for ElementsCompo.xaml
    /// </summary>
    public partial class ElementsCompo : UserControl
    {
        private ICollection<int> _numbers { get; set; }
        public ICollection<int> Numbers { get { return _numbers; } set { _numbers = value; AddNumbers(value); } }
        public ElementsCompo()
        {
            InitializeComponent();
            Numbers=new List<int>();
        }
        private void AddNumbers(ICollection<int> numbers)
        {
            foreach(var number in numbers) 
            {
                if ( number >= 0)
                {
                    NumbersBox.Items.Add(number.ToString());
                }
            }
        }
        private void AddNumberButton_Click(object sender, RoutedEventArgs e)
        {
            int number;
            if (int.TryParse(IntBox.Text, out number) && number >= 0)
            {
                Numbers.Add(number);
                NumbersBox.Items.Add(number.ToString());
                IntBox.Text = "";
            }
        }

        private void RemoveNumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (NumbersBox.SelectedItem != null)
            {
                int index = NumbersBox.SelectedIndex;
                Numbers.Remove(Numbers.ElementAt(index));
                NumbersBox.Items.RemoveAt(index);
            }
        }

    }
}
