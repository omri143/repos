using System;
using System.IO;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("C:\\Users\\" + Environment.UserName+"\\Test");
        }
    }
}
