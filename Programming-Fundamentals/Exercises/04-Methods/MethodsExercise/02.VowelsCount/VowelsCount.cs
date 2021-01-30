using System;

namespace _02.VowelsCount
{
    class VowelsCount
    {
        public static int countVowels(string str)
        {
            string vowels = "aeoui";
            int count = 0;
            for (int i = 0; i < vowels.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (char.ToLower(str[j]) == vowels[i])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            int vowelCount = countVowels(str);

            Console.WriteLine(vowelCount);
        }
    }
}
