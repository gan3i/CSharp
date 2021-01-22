using System;

namespace DataStructures
{
    public class Stack<T>
    {
        readonly Deque<T> store = new Deque<T>();

        public void Push(T item)
        {
            store.EnqueueHead(item);
        }

        public T Pop()
        {
            return store.DequeueHead();
        }

        public T Peek()
        {
            T value;
            if (store.PeekHead(out value))
            {
                return value;
            }

            throw new InvalidOperationException();
        }

        public int Count
        {
            get
            {
                return store.Count;
            }
        }
    }
}
