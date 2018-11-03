using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_console_
{
    class ConjugatedGrad
    {
        int amountVar; //Количество переменных
        int amountPoints;
        Coord[] x = new Coord[3000];
        public Coord min;
        Func.function y;
        int i;
        double Eps;
        int k;
        int points = 0;
        Coord p;
        double alfa;
        Coord Grad;
        public delegate double opt(Coord x1, Coord x2);
        public ConjugatedGrad(Coord _x0, Func.function d, double _E)
        {
            amountVar = _x0.coord.Length;
            amountPoints = amountVar + 1;
            
            //x = new Coord[100];
            x[0] = _x0;
            x[1] = x[0];
            y = d;
            Eps = _E;
            
        }
        double PolakRibier(Coord x1, Coord x2)
        {
            double Beta;
            Coord gamma;
            Coord grad1 = Coord.Gradient(y, x1, amountVar);
            Coord grad2 = Coord.Gradient(y, x2, amountVar);
            gamma = grad2 - grad1;
            Beta = (grad2.Transp * gamma) / Math.Pow(grad1.Norma, 2);
            return Beta;
        }
        double FletcherReeves(Coord x1, Coord x2)
        {
            double Beta;
            Coord grad1 = Coord.Gradient(y, x1, amountVar);
            Coord grad2 = Coord.Gradient(y, x2, amountVar);
            Beta = (grad2.Norma * grad2.Norma) / (grad1.Norma * grad1.Norma);
            return Beta;
        }
        Coord newPoint(Coord x1, Coord x2, opt OptBeta)
        {
            opt Beta = OptBeta;
            Grad = Coord.Gradient(y, x2, amountVar);
            //Если k = 1, n+1, 2n+1...
            if (k % amountVar == 1)
            //if (k <= 3)
                p = -Grad;
            else
            {
                double beta = Beta(x2, x1);
                p = -Grad + (beta * p);
            }
           
            p = p / p.Norma;
            //Запускаем линейный поиск
            LinearSearch f1 = new LinearSearch(x2, p, y);
            f1.Svenn(20);
            //f1.Svenn2();
            f1.Bolcano(20);
            //f1.Dichotomy(20);
            //f1.Bolcano2();
            f1.Davidon();
            //f1.Davidon2();
            //f1.DSK(30);
            //f1.Davidon2();
            alfa = f1.alfa_min;
            p = p / p.Norma;
            Coord x3 = x2 + alfa * p;
            return x3;
        }
        private int Method(opt OptBeta)
        {
            opt Beta = OptBeta;
            double[] arr_p = new double[amountVar];
            Coord p = new Coord(arr_p);
            p = p / p.Norma;
            k = 1;
            //Высчитываем новую точку, пока квадрат нормы градиента меньше эпсилон
            while (true)
            {
                x[k + 1] = newPoint(x[k - 1], x[k], OptBeta);
                Grad = Coord.Gradient(y, x[k + 1], amountVar);
               // Console.WriteLine("gradNorm^2 = {0}", Grad.Norma * Grad.Norma);
                
                if (Grad.Norma * Grad.Norma<= Eps || k>=300)
                {
                    min = x[k + 1];
                    break;
                }
                k++;
            }
            return k;
        }
        //Методы
        public int PolakRibierMethod()
        {
            return Method(PolakRibier);
        }
        public int FletcherReevesMethod()
        {
            return Method(FletcherReeves);
        }


    }
}
