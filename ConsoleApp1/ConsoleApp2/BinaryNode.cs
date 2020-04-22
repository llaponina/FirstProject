using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public enum Side
    {
        Left,
        Right
    }

    public class BinaryNode<T> where T : IComparable
    {
        public BinaryNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }

        public BinaryNode<T> LeftNode { get; set; }

        public BinaryNode<T> RightNode { get; set; }

        public BinaryNode<T> ParentNode { get; set; }

        public Side? NodeSide =>
            ParentNode == null
                ? (Side?)null
                : ParentNode.LeftNode == this
                    ? Side.Left
                    : Side.Right;

        public override string ToString() => Data.ToString();
    }
}
