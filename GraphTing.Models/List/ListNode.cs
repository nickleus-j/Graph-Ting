using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTing.Models.List
{
    public class ListNode
    {
        public ListNode(int val=0) { Value = val; }
        public int Value { get; set; }
        public ListNode? NextNode { get; set; }
    }
}
