using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MixedUpLists
{
    class MixedUpLists
    {
        static void Main(string[] args)
        {
            List<int> firstNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> newList = new List<int>();
            List<int> maxList = new List<int>();
            List<int> finalList = new List<int>();

            int firstNum = 0;
            int secondNum = 0;
            int last = 0;
            int previous = 0;

            if (firstNums.Count > secondNums.Count)
            {
                maxList = firstNums;
            }

            else
            {
                maxList = secondNums;
                maxList.Reverse();
            }

            for (int i = 0; i < maxList.Count; i++)
            {
                last = maxList[maxList.Count - 1];
                previous = maxList[maxList.Count - 2];
            }

            for (int i = 0; i < firstNums.Count; i++)
            {
                newList.Add(firstNums[i]);
            }

            newList.Remove(previous);
            newList.Remove(last);

            for (int i = 0; i < secondNums.Count; i++)
            {
                newList.Add(secondNums[i]);
            }

            if (previous > last)
            {
                firstNum = last;
                secondNum = previous;
            }

            else
            {
                secondNum = last;
                firstNum = previous;
            }

            for (int i = 0; i < newList.Count; i++)
            {
                if (newList[i] > firstNum && newList[i] < secondNum)
                {
                    finalList.Add(newList[i]);
                }
            }

            finalList.Sort();

            Console.WriteLine(string.Join(" ", finalList));

        }
    }
}
