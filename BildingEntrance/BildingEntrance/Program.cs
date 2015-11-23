using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCard
{
    class Student
    {
        string _name;

        public string Name 
        { 
            get { return this._name; } 
        }

        public Student(string name)
        {
            this._name = name;
        }

        public bool Enter(Building building, Card card)
        {
            return UseCard(card, building.Tourniquet);
        }

        public bool UseCard(Card card, Tourniquet tourniquet)
        {
            return tourniquet.Allow(card);
        }

        public void Print(Building building, Card card)
        {
            if (Enter(building, card))
            {
                Console.WriteLine(Name + " yспешно вошёл в здание по адресу: " + building.Address);
            }
            else
            {
                Console.WriteLine(Name + " не смогла войти в здание по адресу: " + building.Address);
            }
        }
    }

    class Card
    {
        int _id;
        string _holder;

        public int ID 
        {
            get { return this._id; } 
        }

        public Card(int id, string holder)
        {
            this._id = id;
            this._holder = holder;
        }
    }

    class Tourniquet
    {
        public bool Allow(Card card)
        {
            if (DataBase.Check(card.ID))
                return true;
            else
                return false;
        }
    }

    class Building
    {
        string _address;

        Tourniquet _tourniquet;

        public Tourniquet Tourniquet
        { 
            get { return this._tourniquet; } 
        }

        public string Address 
        { 
            get { return this._address; } 
        }
        
        public Building(string address, Tourniquet tourniquet)
        {
            this._address = address;
            this._tourniquet = tourniquet;
        }

    }

    class DataBase
    {
        public static bool Check(int data)
        {
            if (data % 2 == 0)
                return true;
            else return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Building uv = new Building("Universiade Village", new Tourniquet());
            Student student1 = new Student("Alsy");
            Card card1 = new Card(1, student1.Name);
            Student student2 = new Student("Andrey");
            Card card2 = new Card(2, student2.Name);

            student1.Print(uv, card1);
            student2.Print(uv, card2);
            
            Console.ReadLine();
        }
    }
}
