using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Ting
{
    public interface INodeView
    {
        public void Redraw(ICollection<int> values);
    }
}
