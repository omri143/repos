using System;

namespace ComplexNumbers
{
    class ComplexNumber
    {
        private double x;
        private double y;
        public double Y { get => y; set => y = value; }
        public double X { get => x; set => x = value; }
        public ComplexNumber(double x, double y)
        {
            this.X = Convert.ToDouble(x);
            this.Y = Convert.ToDouble(y) ;
        }

        //Calculate the sum of two complex numbers
        public ComplexNumber Sum (ComplexNumber complex)
        {
            double y_sum = Y + complex.Y;
            double x_sum = X + complex.X;
            return new ComplexNumber(x_sum, y_sum);
        }

        // Calculate the result of (a+bi)*(x+yi) where a,b,x,y are real numbers or zero
        public ComplexNumber Multiply (ComplexNumber complex)
        {
            double y_sum = (Y * complex.X) + X * complex.Y;
            double x_sum = X * complex.X - Y * complex.Y;
            return new ComplexNumber(x_sum , y_sum);
        }

        public ComplexNumber ConjugateNumber()
        {
            return new ComplexNumber(X, -Y);
        }
        public double AngleDeg()
        {
            double angle = Math.Round(Math.Atan(Y / X) * 360 / (2 * Math.PI), 3);
            if (x>0 &&y<0)
            {
                angle += 360;
            }
            else if(x<0 && y<0)
            {
                angle -= +270;
            }
            else if(x<0 && y>0)
            {
                angle -= 180;
            }
            return Math.Abs(angle);
        }
        public double AngleRnd()
        {
            double angle = Math.Round(Math.Atan(Y / X) * 360 / (2 * Math.PI), 3);
            if (x > 0 && y < 0)
            {
                angle += 2*Math.PI;
            }
            else if (x < 0 && y < 0)
            {
                angle -= +3*Math.PI/2;
            }
            else if (x < 0 && y > 0)
            {
                angle -= Math.PI;
            }
            return Math.Abs(angle);
          
        }
        public double Abs ()
        {
            return Math.Round(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) , 3);
        }
        public ComplexNumber Cis(double R , double thetaDeg)
        {
            double y_sum = R * Math.Sin((thetaDeg*2*Math.PI/360));
            double x_sum = R * Math.Cos(thetaDeg* 2 * Math.PI / 360);
            return new ComplexNumber(Math.Round(x_sum , 3),Math.Round( y_sum,3));

        }
        public ComplexNumber Cis(float R, float thetaRnd)
        {
            double y_sum = R * Math.Sin(thetaRnd);
            double x_sum = R * Math.Cos(thetaRnd);
            return new ComplexNumber(Math.Round(x_sum, 3), Math.Round(y_sum, 3));
        }
        static bool Approximate(double value1, double value2, double acceptableDifference)
        {
            return Math.Abs(value1 - value2) <= acceptableDifference;
        }
        public override string ToString()
        {
            if (Approximate(0,X,0)  && Approximate(0, Y, 0) )
            {
                return "0";
            }
            else if(Y == 1 || Y ==-1)
            {
             
               
                if (Y == 1)
                {
                    return X + "+" + "i";

                }
                else
                {
                    return X + "-"  + "i";
                }
            }
            else if (X == 0 && Y != 0)
            {
                return Y + "i" ;
            }
            else if(X != 0 && Y!=0)
            {
                return Y > 0 ? X + "+" + Y + "i" : X + "" + Y + "i";
            }
            else if(X != 0 && Y ==0)
            {
                return Convert.ToString(X);
            }
            return X + "+" + Y + "i";
        }
    }
}
