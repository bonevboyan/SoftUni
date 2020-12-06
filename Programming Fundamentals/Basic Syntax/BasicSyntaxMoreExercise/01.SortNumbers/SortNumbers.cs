using System;

namespace _01.SortNumbers
{
    class SortNumbers
    {
        static void Main(string[] args)
        {
            int[] a = new int[3];
            a[0] = int.Parse(Console.ReadLine());
            a[1] = int.Parse(Console.ReadLine());
            a[2] = int.Parse(Console.ReadLine());
            Array.Sort(a);
            Console.WriteLine(a[2] + "\n" + a[1] + "\n" + a[0]);
        }

    }
}
