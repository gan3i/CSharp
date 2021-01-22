using System.Collections;

namespace DataStructures
{
    /// <summary>
    /// A node in the LinkedList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedListNode<T>
    {
        /// <summary>
        /// Constructs a new node with the specified value.
        /// </summary>
        /// <param name="value"></param>
        public LinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// The node value
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The next node in the linked list (null if last node)
        /// </summary>
        public LinkedListNode<T> Next { get; set; }
    }

    /// <summary>
    /// A linked list collection capable of basic operations such as 
    /// Add, Remove, Find and Enumerate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : 
        System.Collections.Generic.ICollection<T>
    {

        public T Head
        {
            get { return head.Value; }
        }

        public T Tail
        {
            get { return tail.Value; }
        }

        /// <summary>
        /// The first node in the list or null if empty
        /// </summary>
        private LinkedListNode<T> head
        {
            get;
            set;
        }

        /// <summary>
        /// The last node in the list or null if empty
        /// </summary>
        private LinkedListNode<T> tail
        {
            get;
            set;
        }

        #region Add
        /// <summary>
        /// Adds the specified value to the start of the linked list
        /// </summary>
        /// <param name="value">The value to add to the start of the list</param>
        public void AddHead(T value)
        {
            AddHead(new LinkedListNode<T>(value));
        }

        /// <summary>
        /// Adds the specified node to the start of the link list
        /// </summary>
        /// <param name="node">The node to add to the start of the list</param>
        public void AddHead(LinkedListNode<T> node)
        {
            // Save off the head node so we don't lose it
            LinkedListNode<T> temp = head;

            // Point head to the new node
            head = node;

            // Insert the rest of the list behind the head
            head.Next = temp;

            Count++;

            if (Count == 1)
            {
                // if the list was empty then Head and Tail should
                // both point to the new node.
                tail = head;
            }
        }

        /// <summary>
        /// Add the value to the end of the list
        /// </summary>
        /// <param name="value">The value to add</param>
        public void AddTail(T value)
        {
            AddTail(new LinkedListNode<T>(value));
        }

        /// <summary>
        /// Add the node to the end of the list
        /// </summary>
        /// <param name="value">The node to add</param>
        public void AddTail(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }

            tail = node;

            Count++;
        }
        #endregion

        #region Remove
        /// <summary>
        /// Removes the first node from the list.
        /// </summary>
        public void RemoveFirst()
        {
            if (Count != 0)
            {
                // Before: Head -> 3 -> 5
                // After:  Head ------> 5

                // Head -> 3 -> null
                // Head ------> null
                head = head.Next;
                Count--;

                if (Count == 0)
                {
                    tail = null;
                }
            }
        }

        /// <summary>
        /// Removes the last node from the list
        /// </summary>
        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    // Before: Head --> 3 --> 5 --> 7
                    //         Tail = 7
                    // After:  Head --> 3 --> 5 --> null
                    //         Tail = 5
                    LinkedListNode<T> current = head;
                    while (current.Next != tail)
                    {
                        current = current.Next;
                    }

                    current.Next = null;
                    tail = current;
                }

                Count--;
            }
        }
        #endregion

        #region ICollection

        /// <summary>
        /// The number of items currently in the list
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        /// <summary>
        /// Adds the specified value to the front of the list
        /// </summary>
        /// <param name="item">The value to add</param>
        public void Add(T item)
        {
            AddHead(item);
        }

        /// <summary>
        /// Returns true if the list contains the specified item,
        /// false otherwise.
        /// </summary>
        /// <param name="item">The item to search for</param>
        /// <returns>True if the item is found, false otherwise.</returns>
        public bool Contains(T item)
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Copies the node values into the specified array.
        /// </summary>
        /// <param name="array">The array to copy the linked list values to</param>
        /// <param name="arrayIndex">The index in the array to start copying at</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// True if the collection is readonly, false otherwise.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Removes the first occurance of the item from the list (searching
        /// from Head to Tail).
        /// </summary>
        /// <param name="item">The item to remove</param>
        /// <returns>True if the item was found and removed, false otherwise</returns>
        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = head;

            // 1: Empty list - do nothing
            // 2: Single node: (previous is null)
            // 3: Many nodes
            //    a: node to remove is the first node
            //    b: node to remove is the middle or last

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    // it's a node in the middle or end
                    if (previous != null)
                    {
                        // Case 3b

                        // Before: Head -> 3 -> 5 -> null
                        // After:  Head -> 3 ------> null
                        previous.Next = current.Next;

                        // it was the end - so update Tail
                        if (current.Next == null)
                        {
                            tail = previous;
                        }

                        Count--;
                    }
                    else
                    {
                        // Case 2 or 3a
                        RemoveFirst();
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Removes all the nodes from the list
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        #endregion
    }
}
