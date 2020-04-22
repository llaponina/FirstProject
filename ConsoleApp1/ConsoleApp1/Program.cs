using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2;

namespace ConsoleApp1
{
    class Program
    {
        //метод обмена элементов
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        //сортировка вставками
        static int[] InsertionSort(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                while ((j > 1) && (array[j - 1] > key))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }

                array[j] = key;
            }

            return array;
        }

        static void Main(string[] args)
        {
            MyList<int> intList = new MyList<int>();
            MyList<string> stringList = new MyList<string>();

            Console.WriteLine("CREATE LIST");

            intList.Add(1);
            intList.Add(2);
            intList.Add(3);
            intList.Add(4);
            intList.Add(5);

            Console.WriteLine("Add 1, 2, 3, 4, 5 to intList:");

            foreach (var item in intList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            intList.Remove(2);
            Console.WriteLine("Delete 2 from intList:");
            foreach (var item in intList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            bool f = intList.Contains(3);
            Console.WriteLine(f == true ? "List contain 3" : "List doesn't contain 3");

            Console.WriteLine("Add 0 first in intList:");
            intList.AppendFirst(0);
            foreach (var item in intList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Reverse 0 1 3 4 5:");
            foreach (var item in intList.Reverse())
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            intList.Clear();
            Console.ReadKey();
            Console.Clear();

            
            Console.WriteLine("CREATE BINARY TREE:");

            
            var binaryTree = new BinaryTree<int>();

            binaryTree.Add(8);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(1);
            binaryTree.Add(6);
            binaryTree.Add(4);
            binaryTree.Add(7);
            binaryTree.Add(14);
            binaryTree.Add(18);

            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Delete 3 from tree:");
            binaryTree.Remove(3);
            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Delete 8 from tree:");
            binaryTree.Remove(8);
            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));

            if (binaryTree.FindNode(10) == null)
            {
                Console.WriteLine("DON'T FIND 10 in tree");
            }
            else
            {
                Console.WriteLine("FIND 10 in tree");
            }
            
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("SORT:");
            foreach (var item in MyInsertionSort.MySort(new[] {-5, 25, 25, 5, 0, -1, 0, -50}))
            {
                Console.Write(item + " ");
            }
            
            Console.ReadKey();
            
        }
    }
}
