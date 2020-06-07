using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternalSort_n11b_
{
    public class DoublyNode
    {
        public DoublyNode(int data)
        {
            Data = data;
        }
        public int Data { get; set; }
        public DoublyNode Previous { get; set; }
        public DoublyNode Next { get; set; }
    }
}
