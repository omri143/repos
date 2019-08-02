using System;

namespace ArmstrongNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int buttomLimit = 0;
            int upperLimit =678567876;
            int[] num = new int[upperLimit.ToString().Length];
            int count = 0;
            int num1;
            int sum = 0;
            for(int i = buttomLimit;i<= upperLimit; i++)
            {
               // Console.WriteLine("At:"+ i);
                num1 = i;
                while (num1 > 0)
                {
                    num[count] = num1 % 10;
                    num1 /= 10;
                    count++;
                }

                for (int k = 0; k <= count-1; k++)
                {
                    sum += (int)Math.Pow(num[k], count);
                  //  Console.WriteLine("Sum : " + sum);
                }
                
                if (sum == i)
                {
                    Console.WriteLine(i);
                }
                count = 0;
                sum = 0;
            }
        }
    } 
}
