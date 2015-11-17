using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsSort
{
    public class Students
    {
        public double _average;
        public string _name;
        public int _point1, _point2, _point3, _point4;

        public Students()
        {

        }

        public Students(string name, int point1, int point2, int point3, int point4)
        {
            Students student = new Students();
            _name = name;
            _point1 = point1;
            _point2 = point2;
            _point3 = point3;
            _point4 = point4;
            _average = student.calcAverage(_point1, _point2, _point3, _point4);
        }

        public void printName()
        {
            Console.WriteLine(_name);
        }

        public double calcAverage(int _point1, int _point2, int _point3, int _point4)
        {
            double result = (_point1 + _point2 + _point3 + _point4) / 4;
            return result;
        }
    }
    class List
    {
        private Students[] arr;
        const int n = 1000;
        private int _counter;

        public List()
        {//создание
            arr = new Students[n];
            _counter = -1;
        }

        public int size()
        {//размер
            return _counter + 1;
        }

        public void clear()
        {//очистить
            _counter = 0;
        }

        public void push(string name, int point1, int point2, int point3, int point4)
        {//добавить
            if (_counter < 1000)
            {
                _counter++;
                Students student = new Students(name, point1, point2, point3, point4);
                arr[_counter] = student;
            }
            else
                Console.WriteLine("Overflow");
        }

        public Students lookInd(int ind)
        {//посмотреть
            Students result = arr[ind];
            return result;
        }

        public void removeInd(int ind)
        {//удалить
            if (_counter > 0)
            {
                for (int i = ind; i < _counter; i++)
                    arr[i] = arr[i + 1];
                _counter--;
            }
            else
                Console.WriteLine("Empty");
        }

        public Students getInd(int ind)
        {//взять
            Students result = arr[ind];
            for (int i = ind; i < _counter; i++)
                arr[i] = arr[i + 1];
            _counter--;
            return result;
        }

        public void sort()
        {
            for (int i = 0; i <= _counter; i++)
            {
                for (int j = i; j <= _counter; j++)
                {
                    if (arr[i]._average > arr[j]._average)
                    {
                        Students b = arr[i];
                        arr[i] = arr[j];
                        arr[j] = b;
                    }
                }
            }
        }



        public void print()
        {
            if (_counter == -1)
                Console.WriteLine("Empty");
            else
            {
                for (int i = 0; i <= _counter; i++)
                {
                    Console.WriteLine(arr[i]._name + " " + arr[i]._average);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int point1, point2, point3, point4;
            List arr = new List();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Введите имя");
                name = Console.ReadLine();
                Console.WriteLine("Введите 4 оценки");
                point1 = Convert.ToInt32(Console.ReadLine());
                point2 = Convert.ToInt32(Console.ReadLine());
                point3 = Convert.ToInt32(Console.ReadLine());
                point4 = Convert.ToInt32(Console.ReadLine());
                arr.push(name, point1, point2, point3, point4);
            }
            arr.print();
            arr.sort();
            arr.print();
            Console.ReadLine();
        }
    }
}

