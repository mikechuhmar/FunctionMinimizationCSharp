using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_console_
{
    class OneDimensialSearch
    {
        protected double a, b;
        public double x0;
        public double x_min;
        double Eps;

        Func._function f;
        

        public Func._Method[] M;



        public OneDimensialSearch()
        {
            methods();
        }
        public OneDimensialSearch(double _x0, Func._function _f, double _Eps)
        {
            x0 = _x0;
            f = _f;
            Eps = _Eps;
            methods();
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
        public int GS_1(int max)
        {
            int k = 1; // max 20 до 30
            double Mu, Lambda;
            double L1 = b - a;
            double tau_1 = Func.tau_1;
            double tau_2 = Func.tau_2;

            Lambda = a + tau_2 * L1;
            Mu = a + tau_1 * L1;

            // Основной этап
            while (true)
            {

                if (f(Lambda) < f(Mu))
                {
                    b = Mu;
                    Mu = Lambda;
                    L1 = b - a;
                    Lambda = a + tau_2 * L1;
                }
                else
                {
                    a = Lambda;
                    Lambda = Mu;
                    L1 = b - a;
                    Mu = a + tau_1 * L1;
                }

                k = k + 1;
                if ((Math.Abs(b - a) <= Eps) || (k >= max))
                {
                    x_min = (a + b) / 2;
                    break;
                }

            }
            return k;
        }
        public int GS_2(int max)
        {
            int k = 1; // max 20 до 30
            double L1 = b - a;
            double x1, x2;
            double tau_1 = Func.tau_1;
            double tau_2 = Func.tau_2;
            double L_1 = b - a;
            x1 = a + tau_1 * L_1;

            while (true)
            {
                x2 = a + b - x1;
                if (x1 < x2)
                {
                    if (f(x1) < f(x2))
                    {
                        b = x2;
                    }
                    else
                    {
                        a = x1;
                        x1 = x2;
                    }
                }
                else
                {
                    if (f(x1) < f(x2))
                    {
                        a = x2;
                    }
                    else
                    {
                        b = x1;
                        x1 = x2;
                    }
                }

                k = k + 1;
                if ((Math.Abs(a - b) <= Eps) || (k >= max))
                {
                    x_min = (a + b) / 2;
                    break;
                }
            }
            return k;
        }
        public int Fib_1(int max)
        {
            int k = 1; // max 20 до 30
            double Mu, Lambda;
            double L_n = 1e-3;// 10^(-3) до 10^(-7)
            double L_1 = b - a;
            double[] Fib = new double[1000];
            int n;
            //Начальный этап
            Fib[0] = 1;
            Fib[1] = 1;
            n = 2;
            while (true)
            {
                Fib[n] = Fib[n - 1] + Fib[n - 2];
                if (Fib[n] > L_1 / L_n)
                    break;
                n++;
            }
            //выбираем 2 стартовые точки
            Lambda = a + (Fib[n - 2] / Fib[n]) * L_1;
            Mu = a + (Fib[n - 1] / Fib[n]) * L_1;
            //Основной этап
            while (true)
            {
                if (f(Lambda) < f(Mu))
                {
                    b = Mu;
                    Mu = Lambda;
                    Lambda = a + (Fib[n - k - 2] / Fib[n - k]) * (b - a);
                }
                else
                {
                    a = Lambda;
                    Lambda = Mu;
                    Mu = a + (Fib[n - k - 1] / Fib[n - k]) * (b - a);
                }
                k++;

                //КОП
                if ((k == n - 1) || (k >= max - 1))
                {
                    if (f(Lambda) < f(Mu))
                        x_min = (a + Mu) / 2;
                    if (f(Lambda) >= f(Mu))
                        x_min = (b + Lambda) / 2;
                    break;
                }
            }
            return k;
        }
        public int Fib_2(int max)
        {
            double L_n = Eps;
            int k = 1;
            double x1, x2, L_1;
            double[] Fib = new double[1000];

            //Начальный этап

            Fib[0] = 1;
            Fib[1] = 1;
            int n = 2;
            while (true)
            {
                Fib[n] = Fib[n - 1] + Fib[n - 2];
                if (Fib[n] > (b - a) / L_n)
                    break;
                n++;
            }
            L_1 = Fib[n] * L_n - Fib[n - 2] * Eps;
            x1 = a + (Fib[n - 1] / Fib[n]) * L_1 + Math.Pow(-1, n)/ Fib[n] * Eps;
            //Основный этап

            while (true)
            {
                x2 = a + b - x1;
                if (x1 < x2)
                {
                    if (f(x1) < (x2))
                    {
                        b = x2;
                    }
                    else
                    {
                        a = x1;
                        x1 = x2;
                    }
                }
                else
                {
                    if (f(x1) < f(x2))
                    {
                        a = x2;
                    }
                    else
                    {
                        b = x1;
                        x1 = x2;
                    }
                }
                k++;

                if (k==n || k>=max || (b-a) <= Eps)
                {
                    x_min = x1;
                    break;
                }
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
        public int Newton()
        {
            int k = 1;
            double x1, x2;
            x1 = x0;
            while (true)
            {
                x2 = x1 - Func.diff_4(f, x1) / Func.second_diff_2(f, x1);
                k++;
                if ((Math.Abs(x2 - x1) <= Eps) || (Math.Abs(Func.diff_4(f, x1)) <= Eps))
                {
                    x_min = x2;
                    break;
                }
                x1 = x2;
            }
            return k;
        }
        public int ThreePoints()
        {
            double xm, x1, x2, L_k;
            int k = 1;
            xm = (a + b) / 2;
            do
            {
                L_k = Math.Abs(b - a);
                x1 = a + L_k / 4;
                x2 = b - L_k / 4;
                if (f(x1) < f(xm))
                {
                    b = xm;
                    xm = x1;
                }
                else
                {
                    if (f(xm) <= f(x2))
                    {
                        a = x1;
                        b = x2;
                    }
                    else
                    {
                        xm = x2;
                    }
                }
                k++;

            } while (Math.Abs(b - a) <= Eps);
            return k;
        }
        public int LinearInterpolation(int max)
        {
            int k = 1;
            do
            {
                x_min = b - Func.diff_4(f, b) * (b - a) / (Func.diff_4(f, b) - Func.diff_4(f, a));
                if (Func.diff_4(f, x_min) > 0)
                    b = x_min;
                else
                    a = x_min;
                k++;
            } while (Func.diff_4(f, x_min) > Eps && k < max);
            return k;
        }
        public int Svenn_2(double h, ref double x1, ref double x2, ref double x3)
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
        public int DSK(int max)
        {

            int k = 1;
            double h;
            double x1, x2, x3, x4;
            double _a, _b, _c, d;
            Func.interp d4 = Func.d4;

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
                d = d4(f, _a, _b, _c);
                if (((Math.Abs((d - _b) / _b)) <= Eps) || (Math.Abs((f(d) - f(_b)) / f(_b)) <= Eps)||k>=max)
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
            Func.interp d1 = Func.d1;
            Func.interp d2 = Func.d2;

            _a = a;
            _c = b;
            _b = (_a + _c) / 2;

            while (true)
            {
                if (k == 1)
                {
                    _d = d1(f, _a, _b, _c);
                }

                else
                {
                    _d = d2(f, _a, _b, _c);
                }

                if (Math.Abs((_b - _d)) / Math.Abs(_b) <= Eps || Math.Abs((f(_b) - f(_d))) / Math.Abs(f(_b)) <= Eps)
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
        public int QuadrInterpExtrap()
        {
            double h, _a, _b, _c, _d;
            int k = 1;
            Func.interp d1 = Func.d1;
            Func.interp d2 = Func.d2;
            _b = (a + b) / 2;
            h = 0.01 * Math.Abs(_b); 
            while (true)
            {
                _a = _b - h;
                _c = _b + h;
                _d = d1(f, _a, _b, _c);
                k++;
                if (Math.Abs((_b - _d)) / Math.Abs(_b) <= Eps && Math.Abs((f(_b) - f(_d))) / Math.Abs(f(_b)) <= Eps)
                {
                    x_min = (_b + _d) / 2;
                    break;
                }
                else
                    _b = _d;
            }
            return k;

        }
        public int CubicInterp()
        {
            double x1, x2, _a, _b, h, d;
            x1 = (a + b) / 2;
            if (Func.diff_4(f, x1) > 0)
                h = -0.01 * Math.Abs(x1);
            else
                h = 0.01 * Math.Abs(x1);
            x2 = x1 + h;
            while (Func.diff_4(f, x1) * Func.diff_4(f, x2) >= 0)
            {
                x1 = x2;
                h *= 2;
                x2 = x1 + h;
            }
            int k = 1;
            if(x1 < x2)
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
                if (Func.diff_4(f, d) < Eps || d==_a || d==_b)
                {
                    x_min = d;
                    break;
                }
                else
                {
                    if (Func.diff_4(f, d) > 0)
                        _b = d;
                    else
                        _a = d;
                }
            }
            return k;
        }


        double M1(int max)
        {
            int k = Svenn(max);
            k = GS_1(max);
            return x_min;
        }
        double M2(int max)
        {
            int k = Svenn(max);
            k = GS_2(max);
            return x_min;
        }
        double M3(int max)
        {
            int k = Svenn(max);
            k = Fib_1(max);
            return x_min;
        }
        double M4(int max)
        {
            int k = Svenn(max);
            k = Fib_2(max);
            //Console.WriteLine(k);
            return x_min;
        }
        double M5(int max)
        {
            int k = Svenn(max);
            k = Dichotomy(5);
            k = Newton();
            return x_min;
        }
        double M6(int max)
        {
            int k = Svenn(max);
            k = ThreePoints();
            k = LinearInterpolation(20);
            return x_min;
        }
        double M7(int max)
        {
            int k = Svenn(max);
            k = Bolcano(5);
            k = GS_1(max);
            return x_min;
        }
        double M8(int max)
        {
            int k = Svenn(max);
            k = Bolcano(5);
            k = Fib_1(max);
            return x_min;
        }
        double M9(int max)
        {
            int k = Svenn(max);
            k = Fib_1(10);
            k = DSK(max);
            return x_min;
        }
        double M10(int max)
        {
            int k = Svenn(max);
            k = Fib_2(10);
            k = DSK(max);
            return x_min;
        }
        double M11(int max)
        {
            int k = Svenn(max);
            k = Dichotomy(10);
            k = Pauell(max);
            return x_min;
        }
        double M12(int max)
        {
            int k = Svenn(max);
            k = Bolcano(10);
            k = Pauell(max);
            return x_min;
        }
        double M13(int max)
        {
            int k = Svenn(max);
            k = GS_1(5);
            k = QuadrInterpExtrap();
            return x_min;
        }
        double M14(int max)
        {
            int k = Svenn(max);
            k = Dichotomy(5);
            //Console.WriteLine(k);
            k = CubicInterp();
            return x_min;
        }
        double M15(int max)
        {
            int k = Svenn(max);
            k = LinearInterpolation(5);
            k = CubicInterp();
            return x_min;
        }
        double M16(int max)
        {
            int k = Svenn(max);
            k = GS_1(10);
            k = Pauell(max);
            return x_min;
        }
        void methods()
        {
            M = new Func._Method[20];
            M[1] = M1;
            M[2] = M2;
            M[3] = M3;
            M[4] = M4;
            M[5] = M5;
            M[6] = M6;
            M[7] = M7;
            M[8] = M8;
            M[9] = M9;
            M[10] = M10;
            M[11] = M11;
            M[12] = M12;
            M[13] = M13;
            M[14] = M14;
            M[15] = M15;
            M[16] = M16;
        }


    }
}
