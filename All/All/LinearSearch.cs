
using System;
namespace All
{
    class LinearSearch : OneDimensialSearch
    {
        //Стартовая точка
        new public Coord x0;
        //Новая точка и направление
        public Coord x1, p;
        //Введённая функция
        IntroducedFunction y;
        //Конструктор
        public LinearSearch(Coord _x0, Coord _p, IntroducedFunction _y)
        {
            x0 = _x0;
            p = _p;
            y = _y;
        }
        //Новая точка
        public void point(double alfa)
        {
            x1 = x0 + alfa * p;
        }
        //Значение функции в новой точке
        override public double f(double alfa)
        {
            point(alfa);
            return y.Answer(x1);
        }
        //Производная по направлению
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
        //Шаг в сторону минимума
        public double alfa_min
        {
            get { return x_min; }
        }
        //Свенн-5
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
            } while (dy(alfa_1) * dy(alfa_2) > 0);
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
            return k;
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
        public int Davidon()
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
                if (Func.diff_4(f, d) < Eps || d == _a || d == _b)
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
        //Координаты минимума
        public Coord min
        {
            get
            {
                point(alfa_min);
                return x1;
            }
        }
    }
}
