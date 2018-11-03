using System;
namespace All
{
    class Func
    {
        //Одномерная функция
        public delegate double _function(double x);
        //Введённая функция
        public delegate double function(Coord x);
        //Производные
        public static double diff_4(_function f, double x)
        {
            double dx = 1e-7;
            return (-f(x + 2 * dx) + 8 * f(x + dx) - 8 * f(x - dx) + f(x - 2 * dx)) / (12 * dx);
        }        
        public static double diff_4(IntroducedFunction f, Coord x, int number)
        {
            double dx = 1e-5;
            int length = x.coord.Length;
            Coord x_dx = dx * Coord.Ort(length, number);
            return (-f.Answer(x + 2 * x_dx) + 8 * f.Answer(x + x_dx) - 8 * f.Answer(x - x_dx) + f.Answer(x - 2 * x_dx)) / (12 * dx);
            //return (-f(x + 2 * x_dx, parts) + 8 * f(x + x_dx, parts) - 8 * f(x - x_dx, parts) + f(x - 2 * x_dx, parts)) / (12 * dx);
        }
        public static double second_diff_2(_function f, double x)
        {
            double dx = 1e-7;
            return (f(x + 2 * dx) - 2 * f(x) + f(x - 2 * dx)) / (4 * dx * dx);
        }
        public static double second_diff_2(IntroducedFunction f, Coord x, int number_1, int number_2)
        {
            double dx = 1e-5;
            int length = x.coord.Length;
            Coord x_dx_1 = dx * Coord.Ort(length, number_1);
            Coord x_dx_2 = dx * Coord.Ort(length, number_2);
            return (f.Answer(x + x_dx_1 + x_dx_2) - f.Answer(x + x_dx_1 - x_dx_2) - f.Answer(x - x_dx_1 + x_dx_2) + f.Answer(x - x_dx_1 - x_dx_2)) / (4 * dx * dx);
        }
        public static double d5(_function f, double a, double b)
        {
            double z = diff_4(f, a) + diff_4(f, b) + 3 * (f(a) - f(b)) / (b - a);
            double w = Math.Sqrt(z * z - diff_4(f, a) * diff_4(f, b));
            double g = (z + w - diff_4(f, a)) / (diff_4(f, b) - diff_4(f, a) + 2 * w);
            if (g > 1)
                return b;
            else
            {
                if (g < 0)
                    return a;
                else
                    return a + g * (b - a);
            }
        }
    }
}
