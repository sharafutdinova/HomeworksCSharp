using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PollardsMethod
{
    class Program
    {
        public static bool IsSimple(int p)
        {
            bool b = true;
            int i = 2;
            while (i < p && b)
            {
                if (p % i == 0)
                    b = false;
                i++;
            }
            return b;
        }

        public static int FindM(int b)
        {
            int m = 1;
            for (int i = 2; i < b; i++)
            {
                if (IsSimple(i))
                {
                    int p = i;
                    while (p * i < b)
                    {
                        p = p * i;
                    }
                    m = m * p;
                }
            }

            return m;
        }

        public static List<int> GetBinary(int m)
        {
            List<int> binary = new List<int>();
            while (m > 0)
            {
                binary.Add(m % 2);
                m = m / 2;
            }
            return binary;
        }

        public static BigInteger FindMod(BigInteger x, int m, int a )
        {
            BigInteger mod = new BigInteger();
            List<int> binary = GetBinary(m);
            mod = a % x;
            for (int i = binary.Count - 2; i >= 0; i--)
            {
                if (binary[i] == 0)
                {
                    mod = mod * mod % x;
                }
                else
                {
                    mod = mod * mod * a % x;
                }
            }
            return mod;
        }

        public static BigInteger FindNOD(BigInteger x, BigInteger mod)
        {
            List<BigInteger> q = new List<BigInteger>();
            List<BigInteger> r = new List<BigInteger>();

            q.Add(mod);
            r.Add(x % mod);
            int i = 0;

            while (r[i] != 0)
            {
                i++;
                q.Add(r[i - 1]);
                r.Add(q[i - 1] % r[i - 1]);
            }
            return q[i];
        }

        static void Main(string[] args)
        {
            BigInteger x = BigInteger.Parse(Console.ReadLine());

            int b = 10;

            int m = FindM(b);
            //Console.WriteLine(m);

            Random rand = new Random();
            int a = rand.Next(b);
            //int a = 2;
            BigInteger mod = FindMod(x, m, a);
            //Console.WriteLine(mod);
            BigInteger nod = FindNOD(x, mod - 1);

            while (nod == 1)
            {
                b += 5; 
                a = rand.Next(b);
                m = FindM(b);
                mod = FindMod(x, m, a);
                nod = FindNOD(x, mod - 1);
            }
            Console.WriteLine(nod);
            Console.ReadLine();
        }
    }
}
