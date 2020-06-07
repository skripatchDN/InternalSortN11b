using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalSort_n11b_;

namespace testing
{
 
    class Program
    {
        static void Main(string[] args)
        {
            /*DoublyLinkedList list = new DoublyLinkedList();
            list.OrderAddFromLeft(5);
            list.OrderAddFromRight(6);
            list.OrderAddFromLeft(6);
            list.OrderAddFromLeft(12);
            list.OrderAddFromRight(4);
            list.OrderAddFromRight(25);
            list.OrderAddFromLeft(2);
            list.OrderAddFromRight(6);
            list.OrderAddFromRight(15);
            list.OrderAddFromLeft(9);
            list.OrderAddFromRight(10);
            list.OrderAddFromLeft(11);
            list.OrderAddFromRight(-3);
            list.OrderAddFromLeft(-1);
            list.Print();*/

            Sorter s = new Sorter();
            int[] arr = new[] {4, 3, 5, 1, 2};
            List<ActionHandle> tmp = new List<ActionHandle>();
            s.DoubleSidedInsertSort(ref arr);

            foreach (var i in arr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
