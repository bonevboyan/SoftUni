using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int equalElement = arr[0], sequenceLength = 0, currElement = arr[0], currSequence = 0;

            for (int i = 0; i < arr.Length; i++)
            {

                if (currElement == arr[i])
                {
                    currSequence++;
                }
                else
                {
                    currElement = arr[i];
                    currSequence = 1;
                }
                if (currSequence > sequenceLength)
                {
                    sequenceLength = currSequence;
                    equalElement = currElement;
                }
            }
            for (int i = 0; i < sequenceLength; i++)
            {
                Console.Write(equalElement + " ");
            }
        }
    }
}
