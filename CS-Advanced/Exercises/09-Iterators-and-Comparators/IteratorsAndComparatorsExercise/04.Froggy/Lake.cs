using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Froggy
{
    class Lake : IEnumerable<int>
    {
        public Lake(IEnumerable<int> stones)
        {
            Stones = stones.ToArray();
        }
        public int[] Stones { get; set; }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Stones.Length; i+=2)
            {
                yield return Stones[i];
            }
            for (int i = (Stones.Length - 1) % 2 == 0? Stones.Length - 2: Stones.Length - 1; i >=1; i -= 2)
            {
                yield return Stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
