using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream source = new FileStream("../../../../Resources/copyMe.png", FileMode.Open))
            {
                using (FileStream destination = new FileStream("../../../../Outputs/image.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    int bytes;
                    while ((bytes = source.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        destination.Write(buffer, 0, bytes);
                    }
                }
            }
        }
    }
}
