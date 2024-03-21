using System;
using System.Diagnostics.CodeAnalysis;

namespace Task1
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t) 
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            head = tail = null;
        }
        
        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
    
        public void Foreach(Action<T> action)
        {
            Node<T> n = head;
            while (n != null)
            {
                action(n.Data);
                n = n.Next;
            }
        }

    }

    class Program
    {
        static void Main(string[] args) {
            GenericList<int> list = new GenericList<int>();
            // 初始化链表元素
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            // 1. 打印输出
            list.Foreach(m => Console.WriteLine(m));
            // 2. 求最小值
            int min = 100;
            Action<int> action1 = delegate (int x)
            {
                if (x < min)
                {
                    min = x;
                }
            };
            list.Foreach(action1);
            Console.WriteLine($"最小值是：{min}");
            // 3. 求最大值
            int max = -1;
            Action<int> action2 = delegate (int x)
            {
                if (x > max)
                {
                    max = x;
                }
            };
            list.Foreach(action2);
            Console.WriteLine($"最大值是：{max}");
            // 4.求和
            int sum = 0;
            Action<int> action3 = delegate (int x)
            {
                sum += x;
            };
            list.Foreach(action3);
            Console.WriteLine($"元素之和为：{sum}");
        }
    }
}
