using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = "./";
            string[] files = Directory.GetFiles(directory);
            Dictionary<string, Dictionary<string, double>> dictionary = new Dictionary<string, Dictionary<string, double>>();
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (dictionary.ContainsKey(fileInfo.Extension))
                {

                    dictionary[fileInfo.Extension].Add(fileInfo.Name, fileInfo.Length);
                }
                else
                {
                    Dictionary<string, double> dict = new Dictionary<string, double>();
                    dict.Add(fileInfo.Name, fileInfo.Length);
                    dictionary.Add(fileInfo.Extension, dict);
                }
            }
            using (StreamWriter writer = new StreamWriter("C:/Users/PC/Desktop/report.txt"))
            {
                foreach (var kvp in dictionary.OrderByDescending(o => o.Value.Count).ThenBy(o => o.Key))
                {
                    writer.WriteLine(kvp.Key);
                    foreach (var value in kvp.Value.OrderBy(size => size.Value))
                    {
                        writer.WriteLine($"--{value.Key} - {value.Value / 1024:f3}kb");
                    }
                }
            }
        }
    }
}
