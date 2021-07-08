using System;

namespace PzuZadania
{
    public class Calculator
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }

        public int Subtract(int x, int y)
        {
            return x - y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public float Divide(int x, int y)
        {
            if (y == 0)
                throw new DivideByZeroException("Pamiętaj h***ro nie dziel przez 0!");

            return x / (float)y;
        }

        public float Modulo(int x, int y)
        {
            return x % y;
        }
    }
}