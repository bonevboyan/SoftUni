using System;

namespace _01.EncryptSortAndPrintArray
{
    class EncryptSortAndPrintArray
    {
        static bool IsVowel(char ch)
        {
            switch (char.ToLower(ch))
            {
                case 'a':
                case 'i':
                case 'o':
                case 'u':
                case 'e':
                    return true;
                default:
                    return false;
            }
        }
        static int CalculateValue(string name)
        {
            int value = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (IsVowel(name[i]))
                {
                    value += name[i] * name.Length;
                }
                else
                {
                    value += name[i] / name.Length;
                }
            }
            return value;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] names = new int[n];
            for (int i = 0; i < names.Length; i++)
            {
                string name = Console.ReadLine();
                names[i] = CalculateValue(name);
            }
            Array.Sort(names);
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}
