using System;
using System.IO;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader1 = new StreamReader("../../../../Resources/04. Merge Files/FileOne.txt"))
            {
                using (StreamReader reader2 = new StreamReader("../../../../Resources/04. Merge Files/FileTwo.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("../../../../Outputs/04. Merge Files/Output.txt"))
                    {
                        string r1 = reader1.ReadLine();
                        string r2 = reader2.ReadLine();
                        while (r1 != null && r2 != null)
                        {
                            writer.WriteLine(r1);
                            writer.WriteLine(r2);
                            r1 = reader1.ReadLine();
                            r2 = reader2.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
