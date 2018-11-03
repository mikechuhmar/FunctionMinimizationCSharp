using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_console_
{
    class GradientMethod
    {
        int amountVar; //Количество переменных
        int amountPoints;
        Coord[] x = new Coord[100];
        public Coord min;
        double Eps;
        int k;
        int points = 0;
        Coord Grad;

        Func.function y;


        double alfa;

        public GradientMethod(Coord _x0, int _amountVar, Func.function d, double _E)
        {
            amountVar = _amountVar;
            amountPoints = amountVar + 2;
            x = new Coord[amountPoints];            
            x[0] = _x0;
            x[1] = x[0];
            y = d;
            Eps = _E;
            

        }
        public int Koshi(int max)
        {
            k = 0;
            Coord p = - Coord.Gradient(y, x[1], amountVar);
            while (true)
            {
                
                LinearSearch f1 = new LinearSearch(x[1], p, y);
                x[2] = f1.M[2](20);
                Grad = Coord.Gradient(y, x[2], amountVar);
                k++;
                if (Grad.norma() <= Eps || k >= max)
                {
                    min = x[2];
                    break;
                }
                else
                {
                    x[1] = x[2];
                    p = Grad;
                }
            }
            return k;
        }
        public int Gelfond(int max)
        {
            k = 0;
            double delta = 0.01;
            Coord _x1;
            Coord _x2;
            Coord d, dif;
            Coord p, _p, p2;
            while (true)
            {
                _x1 = x[1] + delta * Coord.Ort(amountVar, 0);
                p = -Coord.Gradient(y, x[1], amountVar);
                LinearSearch f1 = new LinearSearch(x[1], p, y);
                x[2] = f1.M[2](20);
                _p = -Coord.Gradient(y, _x1, amountVar);
                LinearSearch f2 = new LinearSearch(_x1, _p, y);
                _x2 = f2.M[2](20);
                d = x[2] - _x2;
                p2 = -Coord.Gradient(y, x[2], amountVar);
                LinearSearch f3 = new LinearSearch(x[2], p2, y);
                x[3] = f3.M[2](20);
                dif = x[3] - x[2];
                k++;
                if (dif.norma() <= Eps)
                {
                    min = x[3];
                    break;
                }
                else
                {
                    x[1] = x[3];
                }
                
            }
            return k;

        }
        public Coord newPointGZ(Coord x)
        {
            int length = x.coord.Length;
            double[] arr_p = new double[length];
            Coord p = new Coord(arr_p);

            points = points % amountVar;
            p.coord[points] = Func.diff_4(y, x, points);
            p = p / p.Norma;        
            LinearSearch f1 = new LinearSearch(x, p, y);            
            Coord x_2 = f1.M[3](50);           
            points++;
            return x_2;
        }
        public int GaussZeidel(int max)
        {      

            k = 0;
            Coord d;
            Console.Write("\nx0: ");
            x[0].output();
            while (true)
            {
                int i = 2;

                //Console.Write("\nx1: ");
                //x[1].output();
                for (; i <= amountPoints - 1; i++)
                {
                    x[i] = newPointGZ(x[i - 1]);
                    Console.Write("\nx{0}: ", i);
                    x[i].output();

                }
                
                d = x[points] - x[1];
                //Console.Write("\nd: ");
                //d.output();               

                k++;
                
                if (d.norma() <= Eps)
                {
                    min = x[i - 1];
                    break;
                }
                else
                {
                    x[1] = x[i - 1];
                }
            }
            return k;
        }
    }
}
