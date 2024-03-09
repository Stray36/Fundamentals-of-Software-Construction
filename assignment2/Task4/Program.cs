using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[3, 4];
        }

        public bool toeplitz(int[, ] arr)
        {
            for (int i = 0; i < arr.Rank - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[i, j] != arr[i + 1, j + 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
