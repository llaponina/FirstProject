using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public T getData()
        {
            return Data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
}
