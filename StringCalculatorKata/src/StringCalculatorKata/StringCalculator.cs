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
            if (delimiters.Any(d => input.Contains(d)))
            {
                var split = input.Split(delimiters, StringSplitOptions.None).Select(int.Parse);
                return split.Sum();
            }

            return int.Parse(input);
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