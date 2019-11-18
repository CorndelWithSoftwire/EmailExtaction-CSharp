using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Email_Extraction
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = @"sample.txt";

            if (TryReadFile(filePath, out string fileText))
            {
                Part1(fileText);
            }
        }

        private static bool TryReadFile(string filePath, out string fileText)
        {
            try
            {
                fileText = File.ReadAllText(filePath);
                return true;
            }
            catch (IOException e)
            {
                Console.WriteLine($"Oh no! An exception was thrown while trying to read {filePath}.\nException message: {e.Message}");
                fileText = null;
                return false;
            }
        }

        //This finds the number of substrings matching @softwire.com so @softwire.comet will also be matched here.
        private static void Part1(string fileText)
        {
            var softwireDomain = "@softwire.com";

            var matchCount = 0;

            for (var i = 0; i <= fileText.Length - softwireDomain.Length; i++)
            {
                //Domains are case insensitive so StringComparison.OrdinalIgnoreCase is used.
                if (fileText.Substring(i, softwireDomain.Length).Equals(softwireDomain, StringComparison.OrdinalIgnoreCase))
                {
                    matchCount++;
                }
            }
            Console.WriteLine($"Part 1\nNumber of substrings matching {softwireDomain}:\t{matchCount}\n");
        }
    }
}
