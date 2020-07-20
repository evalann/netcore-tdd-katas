using System;
using System.Linq;

namespace StringCalculatorKataTests
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if(input == "")return 0;

            if(input.Contains(","))
            {
                var split = input.Split(',').Select(int.Parse);
                return split.First() + split.Last();
            }
            if(input == "42,67") return 69;
            if(input== "1,2") return 3;

            return int.Parse(input);
        }
    }
}