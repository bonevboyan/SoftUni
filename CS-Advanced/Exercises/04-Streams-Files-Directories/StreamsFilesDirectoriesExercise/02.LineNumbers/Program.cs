using System;
using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../../Resources/text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../../Outputs/output.txt"))
                {
                    string line = reader.ReadLine();
                    int row = 1;
                    while (line != null)
                    {
                        int countPuncMarks = 0, countLetters = 0;
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i] == '!' || line[i] == ',' || line[i] == ';' || line[i] == '.' || line[i] == '?' || line[i] == '-' ||
                                       line[i] == '\'' || line[i] == '\"' || line[i] == ':')
                            {
                                countPuncMarks++;
                            }
                        }
                        for (int i = 0; i < line.Length; i++)
                        {
                            if ((line[i] >= 'a' && line[i] <= 'z') || (line[i] >= 'A' && line[i] <= 'Z'))
                            {
                                countLetters++;
                            }
                        }
                        writer.WriteLine($"Line {row}: {line} ({countLetters})({countPuncMarks})");
                        row++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}