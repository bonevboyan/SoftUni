using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    class CustomStack<T> : IEnumerable<T>
    {
        private const int initialCapacity = 4;
        private T[] items;
        private int count;
        public CustomStack()
        {
            count = 0;
            items = new T[initialCapacity];
        }
        public int Count
        {
            get
            {
                return count;
            }
        }
        public void Push(T element)
        {
            if (items.Length == Count)
            {
                var nextItems = new T[items.Length * 2];
                for (int i = 0; i < items.Length; i++)
                {
                    nextItems[i] = items[i];
                }
                items = nextItems;
            }
            items[count] = element;
            count++;
        }
        public T Pop()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
            if(count == 0)
            {
                Console.Write("No elements");
                return default;
            }
            var lastIndex = count - 1;
            T last = items[lastIndex];
            count--;
            return last;
        }
        public T Peek()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
            return items[count - 1];
        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(items[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
