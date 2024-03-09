using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = Convert.ToInt32(Console.ReadLine());

            for (int i = 2; i <= x / i; i++)
            {
                if (x % i != 0)
                {
                    continue;
                }
                while (x % i == 0)
                {
                    x /= i;
                }
                Console.WriteLine(i);
            }

            if (x > 1)
            {
                Console.WriteLine(x);
            }

        }
    }
}
