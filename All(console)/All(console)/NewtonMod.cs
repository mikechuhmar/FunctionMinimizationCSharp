using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_console_
{
    class NewtonMod
    {
        protected Func.function y;
        protected int amountVar;
        protected int amountPoints;
        protected Coord[] x = new Coord[1000];
        protected double Eps;
        protected int maxIter;
        protected int k;
        protected double alfa, beta;
        
        public Coord min;
        
        Coord p;
        public NewtonMod(Coord _x0, Func.function _y, double _Eps)
        {
            x[0] = _x0;
            x[1] = x[0];
            y = _y;
            Eps = _Eps;
            amountVar = _x0.coord.Length;
        }
        public int NewtonWithAdjustingStep()
        {
            k = 0;
            (-Matrix.H(y, amountVar, x[1])).output();
            while (true)
            {
                Coord Grad = x[1].Gradient(y);
                
                p = -Matrix.H(y, amountVar, x[1]).InverseMatrix * x[1].Gradient(y);
                alfa = 1;
                beta = 2;
                x[2] = x[1] + alfa * p;
                //x[2].output();
                k++;
                if (x[2].Gradient(y).Norma <= Eps)
                {
                    min = x[2];
                    break;
                }
                else
                {
                    alfa /= beta;
                    //Console.WriteLine(alfa);
                    x[1] = x[2];
                }
                
            }
            return k;
        }
    }
}
