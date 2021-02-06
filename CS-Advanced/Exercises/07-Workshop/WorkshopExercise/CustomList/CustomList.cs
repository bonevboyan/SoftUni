using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    class CustomList
    {
        private const int initialCapacity = 2;
        private int[] items;
        public CustomList()
        {
            items = new int[initialCapacity];
        }
        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
        }
        private void Resize()
        {
            int[] copy = new int[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
        public void Add(int item)
        {
            if(Count == items.Length)
            {
                Resize();
            }
            items[Count] = item;
            Count++;
        }
        private void Shift(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }
        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
        public int RemoveAt(int index)
        {
            if(index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var item = items[index];
            items[index] = default;
            Shift(index);

            Count++;
            if (Count <= items.Length / 4) 
            { 
                Shrink(); 
            }
            return item;
        }
        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
        }
        public void Insert(int index, int element)
        {
            if(index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if(Count == items.Length)
            {
                Resize();
            }
            ShiftToRight(index);
            items[index] = element;
            Count++;
        }
        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if(items[i] == element)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
