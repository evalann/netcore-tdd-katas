using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKataTests
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (input == "") return 0;
            
            var delimiters = GetDelimiters(ref input);            
            var split = input.Split(delimiters, StringSplitOptions.None).Select(int.Parse);
            
            var negativeValues = split.Where(i => i < 0).Select(i => i);
            
            if(!negativeValues.Any()) return split.Sum();
            
            var negativeMessage = string.Join(",", negativeValues);
            throw new IndexOutOfRangeException($"negatives not allowed ({negativeMessage})");
        }

        private string[] GetDelimiters(ref string input)
        {
            List<string> delimiters = new List<string> { ",", "\n" };
            if (input.StartsWith("//"))
            {
                delimiters.Add(input.Substring(2, input.IndexOf("\n") - 2));
                input = input.Remove(0, input.IndexOf("\n") + 1);
            }

            return delimiters.ToArray();
        }

        private static char[] GetDelimiters(string input)
        {
            List<char> delimiters = new List<char> { ',', '\n' };


            return delimiters.ToArray();
        }
    }
}