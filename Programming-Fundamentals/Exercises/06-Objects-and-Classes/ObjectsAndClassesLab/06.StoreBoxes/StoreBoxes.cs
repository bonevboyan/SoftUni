using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StoreBoxes
{
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceBox { get; set; }
    }
    class StoreBoxes
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] input = line.Split();

                Box box = new Box()
                {
                    SerialNumber = int.Parse(input[0]),
                    Quantity = int.Parse(input[2])
                };
                box.Item = new Item
                {
                    Name = input[1],
                    Price = decimal.Parse(input[3])
                };
                box.PriceBox = box.Item.Price * box.Quantity;
                boxes.Add(box);
                line = Console.ReadLine();
            }
            List<Box> sortedBoxes = boxes.OrderBy(o => o.PriceBox).ToList();
            sortedBoxes.Reverse();
            for (int i = 0; i < boxes.Count; i++)
            {
                Console.WriteLine($"{sortedBoxes[i].SerialNumber}\n-- {sortedBoxes[i].Item.Name} - ${sortedBoxes[i].Item.Price:f2}: {sortedBoxes[i].Quantity}\n-- ${sortedBoxes[i].PriceBox:f2} ");
            }
        }
    }
}
