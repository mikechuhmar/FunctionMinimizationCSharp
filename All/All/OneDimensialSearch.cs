using System;

namespace All
{
    class OneDimensialSearch
    {
        protected double a, b;
        double x0;
        protected double x_min;
        public static double tau_1 = (Math.Sqrt(5) - 1) / 2;
        public static double tau_2 = (3 - Math.Sqrt(5)) / 2;
        public double Eps = 1e-3;
        virtual public double f(double x)
        {
            return x;
        }

        public OneDimensialSearch()
        {

        }
        double d1(double a, double b, double c)
        {
            return 0.5 * (f(a) * (b * b - c * c) + f(b) * (c * c - a * a) + f(c) * (a * a - b * b)) / (f(a) * (b - c) + f(b) * (c - a) + f(c) * (a - b));
        }

        double d2(double a, double b, double c)
        {
            return 0.5 * (a + b) + 0.5 * ((f(a) - f(b)) * (f(a) - f(b)) * (b - c) * (c - a)) / (f(a) * (b - c) + f(b) * (c - a) + f(c) * (a - b));
        }
        protected double d4(double a, double b, double c)
        {
            return b + 0.5 * ((b - a) * (f(a) - f(c)) / (f(a) - 2 * f(b) + f(c)));
        }
        public int Svenn(int max)
        {
            double h;
            double x1, x2, x3;
            if (x0 != 0)
                h = 0.01 * Math.Abs(x0); //коэффициент от 0.01 до 0.1
            else h = 0.01;
            x1 = x0;
            //Основной этап

            x2 = x1 + h;
            if (f(x2) > f(x1))
            {
                h = -h;
                x2 = x1 + h;
            }
            int k = 2;
            while (true)
            {
                h = 2 * h;
                x3 = x2 + h;
                if (f(x3) >= f(x2) || (k >= max))
                    break;
                x1 = x2;
                x2 = x3;
                k++;

            }
            if (x1 > x3)
            {
                a = x3;
                b = x1;
            }
            else
            {
                a = x1;
                b = x3;
            }
            return k;
        }
        public int Dichotomy(int max)
        {
            double delta = 0.1 * Eps;
            int k = 1;
            double Lambda, Mu;
            while (true)
            {
                Lambda = (a + b - delta) / 2;
                Mu = (a + b + delta) / 2;
                if (f(Lambda) < f(Mu))
                {
                    b = Mu;
                }
                else
                {
                    a = Lambda;
                }
                k++;
                if (b - a <= Eps || k >= max)
                    break;
            }
            return k;
        }
        public int GS_1(int max)
        {
            int k = 1; // max 20 до 30
            double M, A;
            double E = Math.Pow(10, (-3));     // 10^(-3) до 10^(-7)
            double L1 = b - a;

            M = a + tau_1 * L1;
            A = a + tau_2 * L1;
            // Основной этап
            for (;;)
            {

                if (f(A) < f(M))
                {
                    b = M;
                    M = A;
                    L1 = b - a;
                    A = a + tau_2 * L1;
                }
                else
                {
                    a = A;
                    A = M;
                    L1 = b - a;
                    M = a + tau_1 * L1;
                }

                k = k + 1;
                if ((Math.Abs(b - a) <= E) || (k >= max))
                    break;
            }
            return k;

        }
        public int Bolcano(int max)
        {
            int k = 1;
            do
            {
                x_min = (a + b) / 2;
                if (Func.diff_4(f, x_min) > 0)
                    b = x_min;
                else
                    a = x_min;
                k++;
            } while ((Math.Abs(Func.diff_4(f, x_min)) >= Eps) && (Math.Abs(b - a) >= Eps) && (k < max));
            return k;
        }
        protected int Svenn_2(double h, ref double x1, ref double x2, ref double x3)
        {
            //Начальный этап
            int k = 1;


            //Основной этап

            x2 = x1 + h;
            if (f(x2) > f(x1))
            {
                h = -h;
                x2 = x1 + h;
            }

            while (true)
            {
                h = 2 * h;
                x3 = x2 + h;
                if (f(x3) >= f(x2))
                    break;
                x1 = x2;
                x2 = x3;
                k++;
            }

            return k;
        }
        public int DSK()
        {

            int k = 1;
            double h;
            double x1, x2, x3, x4;
            double _a, _b, _c, d;
            double E1 = Math.Pow(10, -3);
            double E2 = E1;

            x1 = (a + b) / 2;
            x2 = 0;
            x3 = 0;
            if (x1 != 0)
                h = 0.001 * Math.Abs(x1);
            else h = 0.001;

            //Основной этап
            while (true)
            {
                k = Svenn_2(h, ref x1, ref x2, ref x3);
                x4 = (x3 + x2) / 2;
                if (f(x2) < f(x4))
                {
                    _a = x1;
                    _b = x2;
                    _c = x4;
                }
                else
                {
                    _a = x2;
                    _b = x4;
                    _c = x3;
                }
                d = d4(_a, _b, _c);
                if (((Math.Abs((d - _b) / _b)) <= E1) && (Math.Abs((f(d) - f(_b)) / f(_b)) <= E2))
                {
                    x_min = (_b + d) / 2;
                    break;
                }
                else
                {
                    if (f(_b) < f(d))
                        x1 = _b;
                    else
                        x1 = d;

                }
                h = h / 2;
                k++;

            }
            //Console.WriteLine("k = {0}",k);
            return k;

        }
        public int Pauell(int max) //Реализация алгоритма Пауэлла
        {

            double E1 = Math.Pow(10, -3);
            double E2 = E1;
            double _a, _b, _c, _d;
            int k = 1;

            _a = a;
            _c = b;
            _b = (_a + _c) / 2;

            while (true)
            {
                if (k == 1)
                {
                    _d = d1(_a, _b, _c);
                }

                else
                {
                    _d = d2(_a, _b, _c);
                }

                if (Math.Abs((_b - _d)) / Math.Abs(_b) <= E1 || Math.Abs((f(_b) - f(_d))) / Math.Abs(f(_b)) <= E2 || k >= max)
                {

                    a = (_b < _d) ? _b : _d;
                    b = (_b > _d) ? _b : _d;
                    x_min = (_b + _d) / 2;
                    break;
                }

                else
                {
                    if (_b < _d)
                    {
                        if (f(_b) < f(_d))
                        {
                            _c = _d;
                        }
                        else
                        {
                            _a = _b;
                            _b = _d;
                        }
                    }
                    else
                    {
                        if (f(_b) < f(_d))
                        {
                            _a = _d;
                        }
                        else
                        {
                            _c = _b;
                            _b = _d;
                        }
                    }

                }
                k++;
            }
            return k;
        }
    }
}
