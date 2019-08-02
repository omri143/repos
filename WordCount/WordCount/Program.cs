using System;
using System.Collections;
using System.Text;

namespace WordCount
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
            for(int i = 0; i <sen.Length; i++)
            {
                if(letters[i] != ' ')
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
            int count = 1;
            for(int k = 0; k<words.Length; k++)
            {
                for(int j = 1;j<=words.Length-1;j++)
                {
                    if(words[k].ToString().Equals(words[j].ToString()))
                    {
                        count++;
                    }
                }
                Console.WriteLine(words[k].ToString() + " :" +count);
                count = 0;
            }
        }
    }
}
