﻿using System;
using System.Numerics;
namespace _11.Snowballs
{
    class Snowballs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger maxValue = 0;
            string bestResult = "";
            for (int i = 0; i < n; i++)
            {
                int snowBalls = int.Parse(Console.ReadLine());
                int snowBallTime = int.Parse(Console.ReadLine());
                int snowBallQuality = int.Parse(Console.ReadLine());
                BigInteger value = BigInteger.Pow((snowBalls / snowBallTime), snowBallQuality);
                if (value >= maxValue)
                {
                    maxValue = value;
                    string result = ($"{snowBalls} : {snowBallTime} = {maxValue} ({snowBallQuality})");
                    bestResult = result;
                }
            }
            Console.WriteLine(bestResult);
        }
    }
}
