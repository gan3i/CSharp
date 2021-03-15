using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;

namespace DataStructure
{
    public class SinglyLinkedListNode<T>
    {
        public SinglyLinkedListNode(T value)
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
        public SinglyLinkedListNode<T> Next { get; set; }

    }
    public class SinglyLinkedList<T>:System.Collections.Generic.ICollection<T>
    {
        /// <summary>
        /// the first node in the linked list or null if empty
        /// </summary>
        public SinglyLinkedListNode<T> Head{
            get;
            private set;        
        }
        /// <summary>
        /// last node in the linked list or null if empty
        /// </summary>
        public SinglyLinkedListNode<T> Tail
        {
            get;
            private set;
        }
        /// <summary>
        /// Number of elements in the list or 0 if empty
        /// </summary>
        public int Count { get; private set; }

        public bool IsReadOnly => throw new NotImplementedException();

        /// <summary>
        /// to add new node to the linked list
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            
            var newNode = new SinglyLinkedListNode<T>(value);
            if (this.Tail == null)
            {
                this.Head = newNode;
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
