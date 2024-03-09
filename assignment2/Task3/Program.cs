using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] st = new bool[200]; // st[x]存储x是否被筛过

            for (int i = 2; i <= 100; i++)
            {
                if (st[i])
                {
                    continue;
                }
                Console.WriteLine(i);
                for (int j = i + i; j <= 100; j += i)
                {
                    st[j] = true;
                }
            }
        }
    }
}