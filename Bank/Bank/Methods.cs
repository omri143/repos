using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bank
{
    class Methods
    {
        //Class of shared methods.
        public static ArrayList ReadFile(string file)
        {
            ArrayList array = new ArrayList();
            using (StreamReader sr = File.OpenText(file))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    array.Add(s);
                }
                sr.Close();
            }
            return array;
        }

        public static void WriteFile(string file, string data)
        {
            StreamWriter sw = File.CreateText(file);
            sw.WriteLine(data);
            sw.Close();
        }

       
        public static List<String> ComplexString(string s, char seperator)
        {
            var sentences = new List<String>();
            int position;
            int start = 0;
            // Extract sentences from the string.
            do
            {
                position = s.IndexOf(seperator, start);
                if (position >= 0)
                {
                    sentences.Add(s.Substring(start, position - start + 1).Trim());
                    start = position + 1;
                }
            } while (position > 0);

         /*   // Display the sentences.
            foreach (var sentence in sentences)
                Console.WriteLine(sentence);*/
            return sentences;
        }

        public static string HidePassword()
        {
            ConsoleKeyInfo inf;
            StringBuilder input = new StringBuilder();
            inf = Console.ReadKey(true);
            while (inf.Key != ConsoleKey.Enter)
            {
                if(inf.Key !=ConsoleKey.Spacebar && inf.Key != ConsoleKey.Tab && inf.Key != ConsoleKey.Backspace)
                {
                    input.Append(inf.KeyChar);
                }
                
                inf = Console.ReadKey(true);
            }
            return input.ToString();
        }


    }
}
