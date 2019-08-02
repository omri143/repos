using System;

namespace ComplexNumbers
{
    class Program
    {
       
        static void Main(string[] args)
        {
            ComplexNumber complexNumber = new ComplexNumber(- 3,-3  );
            ComplexNumber cn = complexNumber.ConjugateNumber(); 
            Console.WriteLine("complex number: " + complexNumber.ToString() +"\r\n"+ "the conjugate is: " + cn.ToString());
            Console.WriteLine("R = " + complexNumber.Abs() + "\r\n" + "Theta = " + complexNumber.AngleDeg());
        }
    }
}
