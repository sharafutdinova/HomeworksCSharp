using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollardsMethod
{
    class Program
    {
        public static bool Simple(decimal number)
        {
            int k = 0;
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                    k++;
            }
            if (k > 1)
                return false;
            else
                return true;
        }

        public static int FindM(int b)
        {
            int m = 1;
            for (int i = 2; i < b; i++)
            {
                if (Simple(i))
                {
                    int k = i;
                    while (k < b)
                    {
                        k = k * i;
                    }
                    m = m * k / i;
                }
            }
            return m;
        }

        public static int FindMod(int m, int a, int x)
        {
            decimal mod = 1;
            while (m > 100)
            {
                mod = mod * (int)Math.Pow(a, 500) % x;
                m = m - 100;
            }
            mod = mod * (int)Math.Pow(a, m) % x;
            Console.WriteLine(Math.Pow(a, m));
            return (int)mod;
        }

        public static int FindNOD(decimal x, int mod)
        {
            bool find = false;
            int result = mod;
            while(result > 0 && !find)
            {
                decimal a = x % result;
                double b = mod % result;
                if (a == 0 && b == 0)
                {
                    find = true;
                }
                else
                {
                    result--;
                }
            }
            return result;
        }

        public static int SecondState(int b, int n, int mod)
        {
            //Random rand = new Random();
            //int b1 = rand.Next(b, b * b);
            int b1 = b * b;
            List<int> q = new List<int>();
            for (int i = b; i <= b1; i++)
            {
                if (Simple(i))
                {
                    q.Add(i);
                }
            }

            int c;
            int d = 1;
            int j = 0;
            int count = q.Count;
            while (d == 1 && j != count - 1)
            {
                c = FindMod(q[j], mod, n);
                d = FindNOD(n, c - 1);
                j++;
            }
            return d;
        }

        static void Main(string[] args)
        {
            int x = Convert.ToInt32(Console.ReadLine());
            int b = 10;
            int m = FindM(b);
            Console.WriteLine(m);
            Random rand = new Random();
            int a = rand.Next(2, b - 1);
            int mod = FindMod(m, a, x);
            Console.WriteLine(mod);
            int nod = FindNOD(x, mod - 1);
            //while (nod <= 1)
            //{
            //    b = b + 5;
            //    m = FindM(b);
            //    mod = FindMod(m, a, x);
            //    nod = FindNOD(x, mod - 1);
            //    //Console.WriteLine("2 state");
            //}
            if (nod <= 1)
            {
                nod = SecondState(b, x, mod);
            }
            Console.WriteLine(nod);
            Console.ReadKey();            
        }
    }
}
