using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polinom
{
    class Polinom
    {
        protected double[] _coef;
        protected int _n;

        public Polinom(double[] coef, int n)
        {
            _coef = coef;
            _n = n;
        }

        public Polinom()
        {
        }

        public int GetN
        {
            get
            {
                return _n;
            }
        }

        public double[] GetCoef
        {
            get
            {
                return _coef;
            }
        }

        public static Polinom operator +(Polinom pol1, Polinom pol2)
        {
            int max = Math.Max(pol1._n, pol2._n);
            if (pol1._n > pol2._n)
            {
                for (int i = pol2._n; i < pol1._n; i++)
                    pol2._coef[i] = 0;
            }
            else
            {
                for (int i = pol1._n; i < pol2._n; i++)
                    pol1._coef[i] = 0;
            }
            double[] sum = new double[max];
            for (int i = 0; i < max; i++)
            {
                sum[i] = pol1._coef[i] + pol2._coef[i];
            }
            Polinom pol = new Polinom(sum, max);
            return pol;
        }

        public static Polinom operator -(Polinom pol1, Polinom pol2)
        {
            int max = Math.Max(pol1._n, pol2._n);

            if (pol1._n > pol2._n)
            {
                for (int i = pol2._n; i <= pol1._n; i++)
                    pol2._coef[i] = 0;
            }
            else
            {
                for (int i = pol1._n; i <= pol2._n; i++)
                    pol1._coef[i] = 0;
            }
            double[] difference = new double[max];
            for (int i = 0; i <= max - 1; i++)
            {
                difference[i] = pol1._coef[i] - pol2._coef[i];
            }
            Polinom pol = new Polinom(difference, max);
            return pol;
        }

        public static Polinom operator *(Polinom pol1, Polinom pol2)
        {
            int n = pol1._n + pol2._n - 1;
            double[] composition = new double[n];
            double sum = 0;
            for (int k = 0; k < n; k++)
            {
                sum = 0;
                int i = 0;
                while ((i <= pol1._n - 1) && (i <= k))
                {
                    int j = 0;
                    while ((i + j <= k) && (j <= pol2._n - 1))
                    {
                        if (i + j == k)
                            sum = sum + pol1._coef[i] * pol2._coef[j];
                        j++;
                    }
                    i++;
                }
                composition[k] = sum;
            }
            Polinom pol = new Polinom(composition, n);
            return pol;
        }

        private double[] InitializeArr()
        {
            double[] coef = new double[_n];
            for (int i = 0; i < _n; i++)
                coef[i] = _coef[i];
            return coef;
        }

        public static Polinom operator +(Polinom pol, double summand)
        {
            double[] coef = pol.InitializeArr();
            Polinom polinom = new Polinom(coef, pol._n);
            polinom._coef[0] = polinom._coef[0] + summand;
            return polinom;
        }

        public static Polinom operator -(Polinom pol, double subtrahend)
        {
            double[] coef = pol.InitializeArr();
            Polinom polinom = new Polinom(coef, pol._n);
            polinom._coef[0] = polinom._coef[0] - subtrahend;
            return polinom;
        }

        public static Polinom operator /(Polinom pol, double divider)
        {
            double[] coef = pol.InitializeArr();
            Polinom polinom = new Polinom(coef, pol._n);
            for (int i = 0; i < polinom._n; i++)
                polinom._coef[i] = polinom._coef[i] / divider;
            return polinom;
        }

        public static Polinom operator *(Polinom pol, double factor)
        {
            double[] coef = pol.InitializeArr();
            Polinom polinom = new Polinom(coef, pol._n);
            for (int i = 0; i < polinom._n; i++)
                polinom._coef[i] = polinom._coef[i] * factor;
            return polinom;
        }

        public virtual double Calc(int x)
        {
            double val = _coef[0];
            int degree = x;
            for (int i = 1; i < _n; i++)
            {
                val = val + _coef[i] * degree;
                degree = degree * x;
            }
            return val;
        }

        public void Print()
        {
            Console.Write(_coef[0]);
            for (int i = 1; i <= _n - 1; i++)
                Console.Write(" + (" + _coef[i] + " * " + "x^" + i + ")");
            Console.WriteLine(" ");
        }

    }

    class PLagrange : Polinom
    {
        public PLagrange(double[] coef, int n)
        {
            _coef = coef;
            _n = n;
        }

        private double f(double x)
        {
            return Math.Tan(x);
        }

        public override double Calc(int x)
        {
            double lpol = 0;
            double value = 1;
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                    if (i != j)
                        value = value * (x - _coef[j]) / (_coef[i] - _coef[j]);
                lpol = lpol + value * f(_coef[i]);
                value = 1;
            }
            return lpol;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            double[] a = new double[10];
            a[0] = 3;
            a[1] = 5;
            a[2] = 4;
            a[3] = 1;
            Polinom pol1 = new Polinom(a, n);
            int m = 7;
            double[] b = new double[10];
            b[0] = 7;
            b[1] = 3;
            b[2] = 7;
            b[3] = 9;
            b[4] = 1;
            b[5] = 5;
            b[6] = 6;
            Polinom pol2 = new Polinom(b, m);
            Polinom pol3 = new Polinom();
            pol1.Print();
            pol2.Print();
            pol3 = pol1 + pol2;
            pol3.Print();
            pol3 = pol1 - pol2;
            pol3.Print();
            pol3 = pol1 * pol2;
            pol3.Print();
            pol3 = pol1 * 5;
            pol3.Print();
            pol3 = pol1 / 2;
            pol3.Print();
            pol3 = pol1 + 2;
            pol3.Print();
            pol3 = pol1 - 6;
            pol3.Print();
            PLagrange pl = new PLagrange(a, n);
            Console.WriteLine(pl.Calc(5));
            Console.ReadLine();
        }
    }
}

