namespace Static
{
    internal class Program
    {
        class MyCalculator
        {
            public double Add(double x, double y)
            {
                return x + y;
            }
            public double Subtract(double x, double y)
            {
                return x - y;
            }
            public double Multiply(double x, double y)
            {
                return x * y;
            }
            public double Divide(double x, double y)
            {
                if(y == 0)
                {
                    Console.WriteLine("0으로 나누어 에러 발생");
                    return 0;
                }
                return x / y;
            }
            public double Squard(double x, double y)
            {
                return (double)MathF.Pow((float)x , (float)y);
            }
        }
        static void Main(string[] args)
        {
            
        }
    }
}
