using System;
using System.Collections;
using System.Text;

namespace CountWordsWithCapitalLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sentence");
            string sen = Console.ReadLine();
            char[] letters = sen.ToCharArray();
            ArrayList ar = new ArrayList();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sen.Length; i++)
            {
                if (letters[i] != ' ')
                {
                    sb.Append(letters[i]);
                }
                else
                {
                    ar.Add(sb.ToString());
                    sb.Clear();
                }
            }
            ar.Add(sb.ToString());
            object[] words = ar.ToArray();
            int count = 0;
            string word;
            char c;
            for(int i = 0; i< words.Length;i++)
            {
                word = words[i].ToString();
                if(!word.Equals(""))
                {
                    if(word.Length == 1)
                    {
                        c = word[0];
                        if (c <= 90 && c >= 65)
                        {
                            count++;
                        }
                    }
                    else
                    {
                        c = word.Substring(0, word.Length - 1)[0];
                        if (c <= 90 && c >= 65)
                        {
                            count++;
                        }
                    }
                 
                }
            
               
            }
        }
    }
}
