using System;
using System.Linq;

namespace _05.MultiplyBigNumber
{
	class MultiplyBigNumber
	{
		static void Main(string[] args)
		{
			char[] bigNum = Console.ReadLine().TrimStart(new char[] { '0' }).Reverse().ToArray();
			int mult = int.Parse(Console.ReadLine());
			int naum = 0;
			string result = string.Empty;
			if(mult == 0)
            {
                Console.WriteLine(0);
				return;
            }
            foreach (char ch in bigNum)
            {
				int num = int.Parse(ch.ToString());
				int n = num * mult + naum;
				result += (n % 10).ToString();
				naum = n / 10;
            }
            if (naum != 0)
            {
				result += naum.ToString();
            }
            Console.WriteLine(result.Reverse().ToArray());
		}
	}
}
