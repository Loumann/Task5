using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task5_sort;

namespace Task5
{
    class Program
    {
        public static string GlobalRev = "";
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string xuai = "";
            string line = Console.ReadLine();
            string vowels = "aeiouy";
            string longestSubstring = "";
            string wrongChars = "";


            char[] charsEnglish = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] chars = line.ToCharArray();
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            List<char> invalidCharsList = new List<char>();
            Sort FuncStort = new Sort();


            foreach (char c in line)
            {
                if (!charsEnglish.Contains(c))
                {
                    if (!invalidCharsList.Contains(c))
                    {
                        invalidCharsList.Add(c);
                    }
                }
            }

            if (invalidCharsList.Count > 0)
            {
                string invalidCharsString = string.Join(", ", invalidCharsList.ToArray());

                Console.WriteLine($"Не подходящие символы: {invalidCharsString}");
                Console.ReadKey();
            }

            foreach (char c in chars)
            {
                if (!charsEnglish.Contains(c))
                {
                    wrongChars += c + " ";
                }
            }


            foreach (char c in chars)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount.Add(c, 1);
                }
            }



            if (wrongChars != "")
            {

            }

            else
            {

                if ((line.Length % 2) == 0)
                {
                    Console.Write("Четная обработаная строка: ");

                    var str1 = line.Substring(0, line.Length / 2);
                    var str2 = line.Substring(line.Length / 2, line.Length / 2);

                    char[] charArray1 = str1.ToCharArray();
                    char[] charArray2 = str2.ToCharArray();
                    Array.Reverse(charArray1);
                    Array.Reverse(charArray2);

                    string s1 = new string(charArray1);
                    string s2 = new string(charArray2);
                    string LinePlus = s1 + s2;
                    Console.WriteLine(LinePlus);
                    xuai = LinePlus;
                    GlobalRev = LinePlus;

                }
                else
                {
                    Console.Write("Не четная обработаная строка: ");

                    char[] charArray1 = line.ToCharArray();
                    Array.Reverse(charArray1);
                    string a1 = new string(charArray1);
                    string LineMinus = a1 + line;
                    Console.WriteLine(LineMinus);
                    xuai = LineMinus;
                    GlobalRev = LineMinus;
                    Console.WriteLine(GlobalRev);

                }



                for (int i = 0; i < xuai.Length; i++)
                {
                    for (int j = i + 1; j <= xuai.Length; j++)
                    {
                        string subString = xuai.Substring(i, j - i);

                        if (vowels.Contains(subString[0]) && vowels.Contains(subString[subString.Length - 1]))
                        {
                            if (subString.Length > longestSubstring.Length)
                            {
                                longestSubstring = subString;
                            }
                        }
                    }
                }
                Console.WriteLine("Самая длинная подстрока, начинающаяся и заканчивающаяся гласной буквой, - это: " + longestSubstring);




                Console.WriteLine("Cколько раз входил в обработанную строку каждый символ:");

                foreach (KeyValuePair<char, int> kvp in charCount)
                {
                    Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                }

                FuncStort.Sorts();

                Console.ReadKey();

            }
        }
    }
}
