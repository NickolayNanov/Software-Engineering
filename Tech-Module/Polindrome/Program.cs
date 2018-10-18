using System;
using System.Collections.Generic;
using System.Linq;

namespace Polindrome
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> palindromes = new List<string>();
            string[] word = Console.ReadLine().Split(new char[] { ',', ' ', '!', '?', '.' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < word.Length - 1; i++)
            {
                if (isTextPalindrome(word[i]))
                {
                palindromes.Add(word[i]);
                }
            }
            

            palindromes = palindromes.Distinct().OrderBy(s => s).ToList();

            Console.WriteLine(string.Join(", ", palindromes));
        }

        public static bool isTextPalindrome(string text)
        {
            if (text == null)
            {
                return false;
            }

            int left = 0;
            int right = text.Length - 1;
            while (left < right)
            {
                if (text[left++] != text[right--])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
