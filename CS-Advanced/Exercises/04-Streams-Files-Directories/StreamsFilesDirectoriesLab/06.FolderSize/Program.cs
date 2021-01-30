using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("../../../../Resources/06. Folder Size/TestFolder");

            double sum = 0;

            foreach (string file in files)

            {

                FileInfo fileInfo = new FileInfo(file);

                sum += fileInfo.Length;

            }

            sum = sum / 1024 / 1024;

            File.WriteAllText("../../../../Outputs/06. Folder Size/Output.txt", sum.ToString());
        }
    }
}
