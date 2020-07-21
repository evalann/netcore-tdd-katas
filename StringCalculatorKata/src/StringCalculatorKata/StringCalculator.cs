using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
            if(negativeValues.Any()) 
            {            
                var negativeMessage = string.Join(",", negativeValues);
                throw new IndexOutOfRangeException($"negatives not allowed ({negativeMessage})");
            }

            var numbers = split.Where(i => i <= 1000);

            return numbers.Sum();
        }

        private string[] GetDelimiters(ref string input)
        {
            List<string> delimiters = new List<string> { ",", "\n" };
            if (input.StartsWith("//"))
            {
                var delimiterSection = input.Substring(2, input.IndexOf("\n")-2);                
                var delimiter = delimiterSection.Replace("[", "").Replace("]", "");
                delimiters.Add(delimiter);
                input = input.Remove(0, delimiterSection.Length + 3);
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