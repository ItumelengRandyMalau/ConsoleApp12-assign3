using System;
using System.Collections.Generic;

namespace ConsoleApp12_assign3
{
    internal class NumberToWordConverter
    {
        private static readonly Dictionary<int, string> units = new Dictionary<int, string>
        {
            { 0, "Zero" }, { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" },
            { 5, "Five" }, { 6, "Six" }, { 7, "Seven" }, { 8, "Eight" }, { 9, "Nine" }
        };

        private static readonly Dictionary<int, string> teens = new Dictionary<int, string>
        {
            { 10, "Ten" }, { 11, "Eleven" }, { 12, "Twelve" }, { 13, "Thirteen" }, { 14, "Fourteen" },
            { 15, "Fifteen" }, { 16, "Sixteen" }, { 17, "Seventeen" }, { 18, "Eighteen" }, { 19, "Nineteen" }
        };

        private static readonly Dictionary<int, string> tens = new Dictionary<int, string>
        {
            { 20, "Twenty" }, { 30, "Thirty" }, { 40, "Forty" }, { 50, "Fifty" },
            { 60, "Sixty" }, { 70, "Seventy" }, { 80, "Eighty" }, { 90, "Ninety" }
        };

        public static string ConvertNumbersToWords(int number)
        {
            if (number == 0) return units[0];

            string words = "";

            if (number / 1000 > 0)
            {
                words += ConvertNumbersToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if (number / 100 > 0)
            {
                words += ConvertNumbersToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "") words += "and ";

                if (number < 10)
                {
                    words += units[number];
                }
                else if (number < 20)
                {
                    words += teens[number];
                }
                else
                {
                    words += tens[number / 10 * 10];
                    if (number % 10 > 0)
                    {
                        words += "-" + units[number % 10];
                    }
                }
            }

            return words.Trim();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number (up to 4 digits): ");
            if (int.TryParse(Console.ReadLine(), out int userNumber) && userNumber >= 0 && userNumber <= 9999)
            {
                string result = ConvertNumbersToWords(userNumber);
                Console.WriteLine($"In words: {result}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number up to 4 digits.");
            }
        }
    }
}
