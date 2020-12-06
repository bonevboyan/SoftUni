using System;

namespace _01.ValidUsernames
{
    class ValidUsernames
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            foreach (var str in input)
            {
                if(str.Length<3 || str.Length>16)
                {
                    goto end;
                }
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsLetterOrDigit(str[i])){
                        if(str[i] != '-' && str[i] != '_')
                        goto end;
                    }
                }
                Console.WriteLine(str);
            end:;
            }
        }
    }
}
