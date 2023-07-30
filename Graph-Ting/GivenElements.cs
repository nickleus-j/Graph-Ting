using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Ting
{
    public class GivenElements
    {
        public ICollection<int> Numbers { get; set; }
        public INodeView? CurrentGraphView { get; set; }
        public GivenElements() { 
            Numbers = new List<int>();
        }
        public void Draw()
        {
            if(CurrentGraphView != null&&Numbers!=null)
            {
                CurrentGraphView.Redraw(Numbers);
            }
        }
        public void Draw(ICollection<int> _numbers)
        {
            Numbers=_numbers;
            Draw();
        }
    }
}
