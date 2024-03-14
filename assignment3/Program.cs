using System;

namespace Shape
{
    // 抽象基类
    public abstract class Shape
    {
        public abstract double getArea();
    }

    // 长方形类
    public class Rectangle : Shape
    {
        private double length;
        private double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        // 使用属性的set访问器判断形状是否合法
        public double Length
        {
            get { return length; }
            set
            {
                if (length <= 0)
                {
                    throw new ArgumentException("length must be greater than zero");
                }
                length = value;
            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (width <= 0)
                {
                    throw new ArgumentException("width must be greater than zero");
                }
                width = value;
            }
        }

        public override double getArea()
        {
            return length * width;
        }
    }

    // 正方形类
    public class Square : Shape
    {
        private double side;

        // 在构造函数中判断形状是否合法
        public Square(double side)
        {
            if (side <= 0)
            {
                throw new ArgumentException("Side must be greater than zero");
            }
            this.side = side;
        }

        public override double getArea() 
        {
            return side * side;
        }
    }

    // 三角形类
    public class Triangle : Shape
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("All sides must be greater than zero");
            }
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public override double getArea()
        {
            if (!isValid())
            {
                return 0;
            }
            double s = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
        }

        public bool isValid()
        {
            return sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA;
        }
    }

    // 形状工厂类
    public static class ShapeFactory
    {
        private static readonly Random random = new Random();

        public static Shape CreateShape()
        {
            int shapeType = random.Next(3);
            switch (shapeType)
            {
                case 0:
                    Rectangle r = new Rectangle(random.NextDouble() * 10 + 1, random.NextDouble() * 10 + 1);
                    return r;
                case 1:
                    return new Square(random.NextDouble() * 10 + 1);
                case 2:
                    double a, b, c;
                    // 保证生成的三角形一定合法
                    do
                    {
                        a = random.NextDouble() * 10 + 1;
                        b = random.NextDouble() * 10 + 1;
                        c = random.NextDouble() * 10 + 1;
                    } while (!(a + b > c && a + c > b && b + c > a));
                    return new Triangle(a, b, c);
                default:
                    throw new ArgumentException("Invalid shape type.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;

            for (int i = 0; i < 10; i++)
            {
                Shape shape = ShapeFactory.CreateShape();
                sum += shape.getArea();
                Console.WriteLine($"Shape area: {shape.getArea()}");
            }
            Console.WriteLine($"The sum of the shapes' area: {sum}");
        }
    }
}
