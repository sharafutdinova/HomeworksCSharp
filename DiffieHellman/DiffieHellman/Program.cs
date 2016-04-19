using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffieHellman
{
    class Person
    {
        public static ulong _p;
        public static ulong _g;
        public ulong _privateKey;
        public ulong _publicKey;
        public List<float> _binary;

        public Person(ulong p, ulong g, ulong privateKey)
        {
            _p = p;
            _g = g;
            _privateKey = privateKey;
            GetBinary();
        }

        public void GetBinary()
        {
            _binary = new List<float>();
            ulong key = _privateKey;
            while (key > 0)
            {
                _binary.Add(key % 2);
                key = key / 2;
            }
        }

        public Person(ulong privateKey)
        {
            _privateKey = privateKey;
            GetBinary();
        }

        public static void Swap(Person a, Person b)
        {
            ulong key = a._publicKey;
            a._publicKey = b._publicKey;
            b._publicKey = key;
        }

        public ulong ObtainThePublicKey(ulong g)
        {
            ulong residue = g;
            
            residue = residue % _p;

            for (int i = _binary.Count - 2; i >= 0; i--)
            {
                if (_binary[i] == 0)
                {
                    residue = residue * residue % _p;
                }
                else
                {
                    residue = residue * residue * g % _p;
                }
            }
            return residue;
        }

        public static void Exchange(Person a, Person b)
        {
            a._publicKey = a.ObtainThePublicKey(_g);
            b._publicKey = b.ObtainThePublicKey(_g);
            Console.WriteLine(a._publicKey);
            Console.WriteLine(b._publicKey);
            Swap(a, b);
            a._publicKey = a.ObtainThePublicKey(a._publicKey);
            b._publicKey = b.ObtainThePublicKey(b._publicKey);
            Console.WriteLine(a._publicKey);
            Console.WriteLine(b._publicKey);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person Alisa = new Person(19283, 10, 12345);
            Person Bob = new Person(98765);
            Person.Exchange(Alisa, Bob);
            Console.ReadKey();
        }
    }
}
