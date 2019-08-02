using System;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a,b,c;
            double x1 = 0, y1 = 0 , z1 =0 ;
            double x2 = 0, y2 = 0, z2 = 0;
            Console.WriteLine("Enter first vector (x,y,z)");
            Console.Write("x1 = ");
            x1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("y1 = ");
            
            y1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("z1 = ");
           
            z1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("u = (" + x1 + " , " + y1 + " , " + z1+")");

            Console.WriteLine("Enter second vector (x,y,z)");
            Console.Write("x2 = ");
            x2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("y2 = ");

            y2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("z2 = ");

            z2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("v = (" + x2 + " , " + y2 + " , " + z2 + ")");
            Console.WriteLine("");
            a = y1 * z2 - y2 * z1;
            b = -(x1 * z2 - x2 * z1);
            c = x1 * y2 - x2 * y1;
            Console.WriteLine("h = (" + a +" , " + b + " , " + c +")" );
        }
    }
}
