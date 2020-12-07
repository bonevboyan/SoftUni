using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class LegendaryFarming
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            List<string> keyMats = new List<string>();
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("shards", 0);
            keyMaterials.Add("motes", 0);
            string keyMat = string.Empty;
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                for (int i = 1; i < input.Length; i += 2)
                {
                    string material = input[i].ToLower();
                    int count = int.Parse(input[i - 1]);
                    if (materials.ContainsKey(material))
                    {
                        materials[material] += count;
                        
                    }
                    else if (keyMaterials.ContainsKey(material)) 
                    {
                        keyMaterials[material] += count;
                        if (keyMaterials[material] >= 250)
                        {
                            switch (material)
                            {
                                case "shards":
                                    Console.WriteLine("Shadowmourne obtained!");
                                    break;
                                case "fragments":
                                    Console.WriteLine("Valanyr obtained!");
                                    break;
                                case "motes":
                                    Console.WriteLine("Dragonwrath obtained!");
                                    break;
                            }
                            keyMaterials[material] -= 250;
                            goto end;
                        }
                    }
                    else 
                    {
                        materials.Add(material, count);
                    }
                }
            }
        end:;
            keyMaterials = keyMaterials.OrderByDescending(o => o.Value).ThenBy(o => o.Key).ToDictionary(o => o.Key, o => o.Value);
            materials = materials.OrderBy(o => o.Key).ToDictionary(o => o.Key, o => o.Value);
            foreach (var material in keyMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
            foreach (var material in materials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
