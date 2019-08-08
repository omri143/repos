using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Drawing;
using System.Diagnostics;

namespace DebugConsole
{
    public class Logging
    {
        
        internal static List<string> verbose = new List<string>();
        internal static List<string> warning = new List<string>();
        internal static List<string> error = new List<string>();
        internal static List<string> info = new List<string>();
        
        public enum Level
        {
            ERROR, INFO , WARNING , VERBOSE
        }
        public static void initConsole()
        {
            Form1 f = new Form1();
        }
        internal static void println(string log)
        {
            if (Form1.main.richTextBoxText.Equals(""))
            {
                Form1.main.richTextBoxText = log;
            }
            else
            {
                Form1.main.richTextBoxText = Form1.main.richTextBoxText + "\r\n" +log;
            }
        }
        public static void println(string log, Level l)
        {
           
            if (Form1.main.richTextBoxText.Equals(""))
            {
                Form1.main.richTextBoxText = getDateAndTime()+" "+"["+l.ToString()+"]"+": "+log;
               
            }
            else
            {
                Form1.main.richTextBoxText = Form1.main.richTextBoxText + "\r\n" + getDateAndTime()+ " " + "[" + l.ToString() + "]" + ": " + log;
            }

            if (l == Level.ERROR)
            {
                error.Add(log);
                
                
            }
            else if (l == Level.INFO)
            {
                info.Add(log);
                

            }
            else if (l == Level.VERBOSE)
            {
                verbose.Add(log);
                
            }
            else if (l == Level.WARNING)
            {
                warning.Add(log);
            }
            
        }
        public static void showDebugConsole(bool b)
        {
            if (b)
            {
                Form1.main.Show();
            }
            else
            {
                Form1.main.Hide();
            }
        }
        private static string getDateAndTime()
        {
            string time = DateTime.Now.ToLongTimeString().ToString();
            string s = time+" " + DateTime.Today.ToShortDateString();
            return s;
        }
    
        public static void clearDebugConsole()
        {
            Form1.main.richTextBoxText = "";
        }
        public static void assemblyInfo()
        {
            println("                                                       Software Information                                                      ");
            println("---------------------------------------------------------------------------------------------------------------------------------");
            println("Debug Console Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            var legalCopyright = versionInfo.LegalCopyright;
            var tradmark = versionInfo.LegalTrademarks;
            println("Debug Console copyrights: " + legalCopyright.ToString());
            println("Trademark: " + tradmark);                                        
            println("----------------------------------------------------------------------------------------------------------------------------------");
        }
      
       
     
       
    }
}
