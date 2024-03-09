using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = new int[10];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }

            Program p = new Program();
            int max = p.FindMax(arr);
            int min = p.FindMin(arr);
            int average = p.FindAverage(arr);
            int sum = p.getSum(arr);

            Console.WriteLine("最大值是： {0}", max);
            Console.WriteLine("最小值是： {0}", min);
            Console.WriteLine("平均值是： {0}", average);
            Console.WriteLine("总和是： {0}", sum);
        }

        public int FindMax(int[] arr)
        {
            int res = arr[0];
            foreach( int i in arr )
            {
                if (i > res)
                {
                    res = i;
                }
            }
            return res;
        }

        public int FindMin(int[] arr)
        {
            int res = arr[0];
            foreach (int i in arr)
            {
                if (i < res)
                {
                    res = i;
                }
            }
            return res;
        }

        public int FindAverage(int[] arr)
        {
            return getSum(arr) / arr.Length;
        }

        public int getSum(int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            return sum;
        }
    }
}
