using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_console_
{
    abstract class Func
    {
        public delegate double _function(double x);
        public delegate double function(Coord x);
        public delegate double _Method (int max);
        public delegate Coord Method(int max);
        public delegate double df_o(_function f, double x);
        public delegate double df_m(function f, Coord x, int number);
        public delegate double interp(_function f, double a, double b, double c);

        public static double tau_1 = (Math.Sqrt(5) - 1) / 2;
        public static double tau_2 = (3 - Math.Sqrt(5)) / 2;
        public static double d1(_function f, double a, double b, double c)
        {
            return 0.5 * (f(a) * (b * b - c * c) + f(b) * (c * c - a * a) + f(c) * (a * a - b * b)) / (f(a) * (b - c) + f(b) * (c - a) + f(c) * (a - b));
        }

        public static double d2(_function f, double a, double b, double c)
        {            
            return 0.5 * (a + b) + 0.5 * ((f(a) - f(b)) * (f(a) - f(b)) * (b - c) * (c - a)) / (f(a) * (b - c) + f(b) * (c - a) + f(c) * (a - b));
        }
        public static double d3(_function f, double a, double b, double c)
        {
            return b + 0.5 * ((b - a) * (b - a) * (f(b) - f(c)) - (b - c) * (b - c) * (f(b) - f(a))) / ((b - a) * (f(b) - f(c)) - (b - c) * (f(b) - f(a)));
        }
        public static double d4(_function f, double a, double b, double c)
        {
            return b + 0.5 * ((b - a) * (f(a) - f(c)) / (f(a) - 2 * f(b) + f(c)));
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
        //Производные для многомерных функций
        public static double diff_1(function f, Coord x, int number)
        {
            double dx = 1e-7;
            int length = x.coord.Length;
            Coord x_dx = dx * Coord.Ort(length, number);
            return (f(x + x_dx) - f(x)) / dx;
        }
        public static double diff_2(function f, Coord x, int number)
        {
            double dx = 1e-7;
            int length = x.coord.Length;
            Coord x_dx = dx * Coord.Ort(length, number);
            return (f(x + x_dx) - f(x - x_dx)) / (2 * dx);
        }
        public static double diff_3(function f, Coord x, int number)
        {
            double dx = 1e-7;
            int length = x.coord.Length;
            Coord x_dx = dx * Coord.Ort(length, number);
            return (f(x - x_dx) - 4 * f(x) + 3 * f(x + x_dx)) / (2 * dx);
        }
        public static double diff_4(function f, Coord x, int number)
        {
            double dx = 1e-7;
            int length = x.coord.Length;
            Coord x_dx = dx * Coord.Ort(length, number);
            return (-f(x + 2 * x_dx) + 8 * f(x + x_dx) - 8 * f(x - x_dx) + f(x - 2 * x_dx)) / (12 * dx);
        }
        public static double second_diff_1(function f, Coord x, int number_1, int number_2)
        {
            double dx = 1e-5;
            int length = x.coord.Length;
            Coord x_dx_1 = dx * Coord.Ort(length, number_1);
            Coord x_dx_2 = dx * Coord.Ort(length, number_2);
            return (f(x + x_dx_1 + x_dx_2) - f(x + x_dx_1) - f(x + x_dx_2) + f(x)) / (dx * dx);
        }
        public static double second_diff_2(function f, Coord x, int number_1, int number_2)
        {
            double dx = 1e-5;
            int length = x.coord.Length;
            Coord x_dx_1 = dx * Coord.Ort(length, number_1);
            Coord x_dx_2 = dx * Coord.Ort(length, number_2);
            return (f(x + x_dx_1 + x_dx_2) - f(x + x_dx_1 - x_dx_2) - f(x - x_dx_1 + x_dx_2) + f(x - x_dx_1 - x_dx_2)) / (4 * dx * dx);
        }
        //Производные для одномерных функций
        public static double diff_1(_function f, double x)
        {
            double dx = 1e-7;
            return (f(x + dx) - f(x)) / dx;
        }
        public static double diff_2(_function f, double x)
        {
            double dx = 1e-7;
            return (f(x + dx) - f(x - dx)) / (2 * dx);
        }
        public static double diff_3(_function f, double x)
        {
            double dx = 1e-7;
            return (f(x - dx) - 4 * f(x) + 3 * f(x + dx)) / (2 * dx);
        }
        public static double diff_4(_function f, double x)
        {
            double dx = 1e-7;
            return (-f(x + 2 * dx) + 8 * f(x + dx) - 8 * f(x - dx) + f(x - 2 * dx)) / (12 * dx);
        }
        public static double second_diff_1(_function f, double x)
        {
            double dx = 1e-7;
            return (f(x + 2 * dx) - 2 * f(x + dx) + f(x)) / (dx * dx);
        }
        public static double second_diff_2(_function f, double x)
        {
            double dx = 1e-7;
            return (f(x + 2 * dx) - 2 * f(x) + f(x - 2 * dx)) / (4 * dx * dx);
        }


    }
}
