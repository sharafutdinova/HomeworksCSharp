using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shape
{
    abstract class Shape
    {
        abstract public double Area();
    }

    class Rectangle : Shape
    {
        private double _side1;
        private double _side2;

        public Rectangle(double side1, double side2)
        {
                _side1 = side1;
                _side2 = side2;
        }

        public override double Area()
        {
            return this._side1 * this._side2;
        }
    }

    class Round : Shape
    {
        private double _radius;

        public Round(double radius)
        {
                _radius = radius;
        }

        public override double Area()
        {
            return Math.PI * this._radius * this._radius;
        }
    }

    class Triangle : Shape
    {
        private double _side1;
        private double _side2;
        private double _side3;

        public Triangle(double side1, double side2, double side3)
        {
            _side1 = side1;
            _side2 = side2;
            _side3 = side3;
        }

        public override double Area()
        {
            double p = (this._side1 + this._side2 + this._side3) / 2;
            return Math.Sqrt(p * (p - this._side1) * (p - this._side2) * (p - this._side3));
        }
    }
        
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] arr = new Shape[100];
            Round shape1 = new Round(10);
            Triangle shape2 = new Triangle(8, 6, 4);
            Rectangle shape3 = new Rectangle(3, 5);            
            arr[0] = shape1;
            arr[1] = shape2;
            arr[2] = shape3;
            for (int i = 0; arr[i] != null; i++)
                Console.WriteLine(arr[i].Area());
            Console.ReadLine();
        }
    }
}
