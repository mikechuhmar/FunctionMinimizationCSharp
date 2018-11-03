using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_console_
{
    class LinearSearch : OneDimensialSearch_for
    {
        new public Coord x0;
        public Coord x1, p;

        Func.function y;
        public LinearSearch(Coord _x0, Coord _p, Func.function _y)
        {
            methods();
            x0 = _x0;
            p = _p;
            y = _y;
        }
        public void point(double alfa)
        {
            x1 = x0 + alfa * p;
        }
        override public double f(double alfa)
        {
            point(alfa);
            return y(x1);
        }
        public double dy(double alfa)
        {
            point(alfa);
            double[] g = new double[x1.coord.Length];
            for (int i = 0; i < g.Length; i++)
            {
                g[i] = Func.diff_4(y, x1, i);
            }
            double answ = 0;
            for (int i = 0; i < g.Length; i++)
            {
                answ += g[i] * p.coord[i];
            }
            return answ;
        }
        public double alfa_min
        {
            get { return x_min; }
        }
        public int Svenn2()
        {
            double h = Eps;
            double step = 0;
            int k = 1;
            if (f(step) < f(step + h))
                h = -h;
            while (f(step + h) < f(step))
            {
                step = step + h;
                h = 2 * h;
                k++;
            }
            if (h > 0)
            {
                a = step - h / 2;
                b = step + h;
            }
            else
            {
                a = step + h;
                b = step - h / 2;
            }

            //Console.WriteLine("k = {0}", k);
            return k;
        }
        public int Svenn5()
        {
            double alfa_h = 0.001;
            double alfa_1 = 0;
            double alfa_2 = alfa_1 + alfa_h;
            int k = 1;
            if (f(alfa_2) > f(alfa_1))
            {
                alfa_h = -alfa_h;
                alfa_2 = alfa_1 + alfa_h;
            }
            do
            {
                alfa_1 = alfa_2;
                alfa_h = 2 * alfa_h;
                alfa_2 = alfa_1 + alfa_h;
                k++;
            } while (Func.diff_4(f, alfa_1) * Func.diff_4(f, alfa_2) > 0);
            if (alfa_1 < alfa_2)
            {
                a = alfa_1;
                b = alfa_2;
            }
            else
            {
                a = alfa_2;
                b = alfa_1;
            }
            //Console.WriteLine("k = {0}", k);
            return k;
        }
        public int Bolcano2()
        {
            int k = 1;
            double d;
            d = (a + b) / 2;

            while (true)
            {
                if (dy(d) > 0)
                    b = d;
                else
                    a = d;
                d = (a + b) / 2;
                k++;
                if((Math.Abs(dy(d)) < Eps) || (Math.Abs(b - a) < Eps))
                {
                    break;
                }
            }
            
            return k;
        }
        public int Davidon()
        {
            Func.df_o dif;
            dif = Func.diff_4;
            double x1, x2, _a, _b, h, d;
            x1 = (a + b) / 2;
            if (dif(f, x1) > 0)
                h = -0.01 * Math.Abs(x1);
            else
                h = 0.01 * Math.Abs(x1);
            x2 = x1 + h;
            while (dif(f, x1) * dif(f, x2) >= 0)
            {
                x1 = x2;
                h *= 2;
                x2 = x1 + h;
            }
            int k = 1;
            if (x1 < x2)
            {
                _a = x1;
                _b = x2;
            }
            else
            {
                _a = x2;
                _b = x1;
            }
            while (true)
            {
                d = Func.d5(f, _a, _b);
                k++;
                if (dif(f, d) < Eps || d == _a || d == _b)
                {
                    x_min = d;
                    break;
                }
                else
                {
                    if (dif(f, d) > 0)
                        _b = d;
                    else
                        _a = d;
                }
            }
            return k;
        }
        public int Davidon2()
        {
            Func.df_o dif;
            dif = Func.diff_4;
            double _a, _b, d;
            _a = a;
            _b = b;
            int k = 0;
            
            while (true)
            {
                double z = dy(a) + dy(b) + 3 * (f(a) - f(b)) / (b - a);
                double w = Math.Sqrt(z * z - dy(a) * dy(b));
                double g = (z + w - dy(a)) / (dy(b) - dy(a) + 2 * w);
                
                k++;
                if (g >= 0 && g <= 1)
                {
                    d = _a + g * (_b - _a);
                }
                else
                if (g < 0)
                {
                    d = _a;
                }
                else
                    d = _b;
                if (Math.Abs(dy(d)) < Eps || d == _a || d == _b)
                {
                    break;
                }
                else
                {
                    if (dif(f, d) > 0)
                        _b = d;
                    else
                        _a = d;
                }
            }
            x_min = d;
            return k;
        }

        public Coord min
        {
            get
            {
                point(alfa_min);
                return x1;
            }
        }
        Coord M1(int max)
        {
            int k = Svenn(20);
            Console.Write("{0} + ", k);
            k = GS_2(5);
            Console.Write("{0} + ", k);
            k = Davidon();
            Console.Write("{0}", k);
            return min;
        }
        Coord M2(int max)
        {
            int k = Svenn(20);
            Console.Write("{0} + ", k);
            k = GS_1(5);
            Console.Write("{0} + ", k);
            k = Pauell(max);
            Console.Write("{0}", k);
            return min;
        }

        Coord M3(int max)
        {
            int k = Svenn(20);
            Console.Write("{0} + ", k);
            k = Bolcano(10);
            Console.Write("{0} + ", k);
            k = Davidon();
            Console.Write("{0}", k);
            return min;
        }
        Coord M4(int max)
        {
            int k = Svenn(20);
            Console.Write("{0} + ", k);
            k = Fib_1(5);
            Console.Write("{0} + ", k);
            k = Davidon();
            Console.Write("{0}", k);
            return min;
        }
        Coord M5(int max)
        {
            int k = Svenn(20);
            Console.Write("{0} + ", k);
            k = Fib_2(5);
            Console.Write("{0} + ", k);
            k = Pauell(max);
            Console.Write("{0}", k);
            return min;
        }
        Coord M6(int max)
        {
            int k = Svenn(20);
            //Console.Write("{0} + ", k);
            k = Bolcano(5);
            //Console.Write("{0} + ", k);
            k = DSK(max);
            //Console.Write("{0}", k);
            return min;
        }
        Coord M7(int max)
        {
            int k = Svenn(20);
            Console.Write("{0} + ", k);
            k = Dichotomy(5);
            Console.Write("{0} + ", k);
            k = DSK(max);
            Console.Write("{0}", k);
            return min;
        }
        Coord M8(int max)
        {
            int k = Svenn(20);
            Console.Write("{0} + ", k);
            k = DSK(5);
            Console.Write("{0} + ", k);
            k = Davidon();
            Console.Write("{0}", k);
            return min;
        }

        public Func.Method[] M;
        void methods()
        {
            M = new Func.Method[20];
            M[1] = M1;
            M[2] = M2;
            M[3] = M3;
            M[4] = M4;
            M[5] = M5;
            M[6] = M6;
            M[7] = M7;
            M[8] = M8;
            

        }
    }
}
