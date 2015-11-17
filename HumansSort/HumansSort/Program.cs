using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumansSort
{
    class Person
    {
        public string _name;
        public int _age;

        public Person()
        {
            _name = null;
            _age = 0;
        }

        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }
    }
    class List
    {
        private Person[] arrayList;
        private int _counter;
        const int n = 1000;

        public List()
        {//создание
            arrayList = new Person[1000];
            _counter = -1;
        }

        public int Size()
        {//размер
            return _counter + 1;
        }

        public void Clear()
        {//очистить
            _counter = -1;
        }

        public void Push(Person k)
        {//добавить
            if (_counter < 1000)
            {
                _counter++;
                arrayList[_counter] = k;
            }
            else
                Console.WriteLine("Overflow");
        }

        public Person LookInd(int k)
        {//посмотреть
            return arrayList[k];
        }

        public void DeleteInd(int k)
        {//удалить
            if (_counter >= 0)
            {
                for (int i = k; i < _counter; i++)
                    arrayList[i] = arrayList[i + 1];
                _counter--;
            }
            else
                Console.WriteLine("Empty");
        }

        public Person GetInd(int k)
        {//взять
            for (int i = k; i < _counter; i++)
                arrayList[i] = arrayList[i + 1];
            _counter--;
            return arrayList[k];
        }

        public void Print()
        {//печать
            for (int i = 0; i <= _counter; i++)
            {
                Console.WriteLine(arrayList[i]._name + " " + arrayList[i]._age);
            }
        }

        public void Sort()
        {
            Person[] array = new Person[100];
            for (int i = 0; i < 100; i++)
                array[i] = new Person();
            for (int i = 0; i <= _counter; i++)
            {
                array[arrayList[i]._age]._age = array[arrayList[i]._age]._age + 1;
                array[arrayList[i]._age]._name = array[arrayList[i]._age]._name + arrayList[i]._name + " ";
            }
            int b = 0;
            for (int j = 0; j < 100; j++)
                for (int i = 0; i < array[j]._age; i++)
                {
                    arrayList[b]._age = j;
                    if (array[j]._age != 1)
                    {
                        arrayList[b]._name = null;
                        for (int k = 0; k <= array[j]._name.IndexOf(' '); k++)
                            arrayList[b]._name = arrayList[b]._name + array[j]._name[k];
                        array[j]._name = array[j]._name.Remove(0, array[j]._name.IndexOf(' ') + 1);
                    }
                    else
                        arrayList[b]._name = array[j]._name;
                    b++;
                }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List arr = new List();
            Person pers1 = new Person("Zylfar", 49);
            Person pers4 = new Person("Anjelika", 20);
            Person pers2 = new Person("Raifa", 45);
            Person pers3 = new Person("Alsy", 19);
            Person pers5 = new Person("Dilara", 24);
            arr.Push(pers1);
            arr.Push(pers2);
            arr.Push(pers3);
            arr.Push(pers4);
            arr.Push(pers5);
            arr.Print();
            arr.Sort();
            arr.Print();
            Console.ReadLine();
        }
    }
}

