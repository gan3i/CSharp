using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }
        /// <summary>
        /// the node value
        /// </summary>
        public T Value { get; set; }
        /// <summary>
        /// pointer to next node
        /// </summary>
        public DoublyLinkedListNode<T> Next { get; set; }
        /// <summary>
        /// pointer to previous node
        /// </summary>
        public DoublyLinkedListNode<T> Previous { get; set; }


    }
    public class DoubleLinkedList
    {
        class Node
        {


        }
    }
}
