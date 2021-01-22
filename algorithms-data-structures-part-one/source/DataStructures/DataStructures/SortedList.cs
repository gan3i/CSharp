using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class SortedList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        class SortedListNode<TNode>
            where TNode : IComparable<TNode>
        {
            public SortedListNode(
                TNode value,
                SortedListNode<TNode> prev = null,
                SortedListNode<TNode> next = null)
            {
                this.data = value;
                this.prev = prev;
                this.next = next;
            }

            public SortedListNode<TNode> prev;
            public SortedListNode<TNode> next;
            public TNode data;
        }

        SortedListNode<T> head = null;
        SortedListNode<T> tail = null;

        public int Count
        {
            get;
            private set;
        }

        public IEnumerator<T> GetEnumerator()
        {
            SortedListNode<T> temp = head;
            while (temp != null)
            {
                yield return temp.data;
                temp = temp.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> GetReverseEnumerator()
        {
            return new ReverseEnumerator(tail);
        }

        class ReverseEnumerator : IEnumerable<T>
        {
            public ReverseEnumerator(SortedListNode<T> tail)
            {
                this.tail = tail;
            }

            private SortedListNode<T> tail;

            public IEnumerator<T> GetEnumerator()
            {
                SortedListNode<T> temp = tail;
                while (temp != null)
                {
                    yield return temp.data;
                    temp = temp.prev;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public void Add(T value)
        {
            if(head == null)
            {
                // empty list
                head = new SortedListNode<T>(value);
                tail = head;
            }
            else if (head.data.CompareTo(value) >= 0)
            {
                // adding at head
                SortedListNode<T> newHead = new SortedListNode<T>(value);
                newHead.next = head;
                head.prev = newHead;
                head = newHead;
            }
            else if (tail.data.CompareTo(value) < 0)
            {
                // adding at tail
                SortedListNode<T> newtail = new SortedListNode<T>(value);
                newtail.prev = tail;
                tail.next = newtail;
                tail = newtail;
            }
            else
            {
                // find the insertion point
                SortedListNode<T> insertBefore = head;
                while (insertBefore.data.CompareTo(value) < 0)
                {
                    insertBefore = insertBefore.next;
                }

                // insert the node
                SortedListNode<T> toInsert = new SortedListNode<T>(value);
                toInsert.next = insertBefore;
                toInsert.prev = insertBefore.prev;
                insertBefore.prev.next = toInsert;
                insertBefore.prev = toInsert;
            }

            Count++;
        }

        private SortedListNode<T> FindNode(T value)
        {
            SortedListNode<T> current = head;
            while(current != null)
            {
                if(current.data.Equals(value))
                {
                    return current;
                }

                current = current.next;

            }

            return null;
        }

        public bool Find(T value, out T found)
        {
            SortedListNode<T> node = FindNode(value);
            if(node != null)
            {
                found = node.data;
                return true;
            }

            found = default(T);
            return false;
        }

        public bool Contains(T value)
        {
            return FindNode(value) != null;
        }

        public bool Remove(T value)
        {
            SortedListNode<T> toRemove = FindNode(value);
            if(toRemove == null)
            {
                return false;
            }

            SortedListNode<T> prev = toRemove.prev;
            SortedListNode<T> next = toRemove.next;

            if(prev == null && next == null)
            {
                head = null;
                tail = null;
            }
            else if(prev != null && next != null)
            {
                prev.next = next;
                next.prev = prev;
            }
            else if(prev != null && next == null)
            {
                prev.next = null;
                tail = prev;
            }
            else
            {
                next.prev = null;
                head = next;
            }

            Count--;
            return true;
        }
    }
}
