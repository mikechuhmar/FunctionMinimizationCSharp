using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_console_
{

    class VariableMetric
    {
        protected Func.function y;
        protected int amountVar;
        protected int amountPoints;
        protected Coord[] x = new Coord [1000] ;
        protected double Eps;
        protected int maxIter;
        protected int k;
        protected double alfa;
        Matrix A;
        public Coord min;
        public delegate Matrix opt(Coord x1, Coord x2);
        Coord p;
        public VariableMetric(Coord _x0, Func.function _y, double _Eps)
        {
            x[0] = _x0;
            x[1] = x[0];
            y = _y;
            Eps = _Eps;
            amountVar = _x0.coord.Length;
        }
        Coord Gamma(Coord x1, Coord x2)
        {
            Coord grad1 = Coord.Gradient(y, x1, amountVar);
            Coord grad2 = Coord.Gradient(y, x2, amountVar);
            Coord gamma = grad2 - grad1;
            return gamma;
        }
        Coord s(Coord x1, Coord x2)
        {
            return A * Gamma(x1, x2);
        }
        Coord dx(Coord x1, Coord x2)
        {
            return x2 - x1;
        }
        Matrix B(Coord x1, Coord x2)
        {
            Matrix E = Matrix.E(A.length);
            Matrix answ;
            answ = E - (dx(x1, x2) * Gamma(x1, x2).Transp) / (Gamma(x1, x2).Transp * dx(x1, x2));
            return answ;
        }
        Matrix BroidenFletcherShenno(Coord x1, Coord x2)
        {
            Matrix answ;
            answ = B(x1, x2) * A * B(x1, x2) + (dx(x1, x2) * dx(x1, x2).Transp) / (dx(x1, x2).Transp * dx(x1, x2));
            return answ;
        }
        Coord newPoint(Coord x1, Coord x2, opt opt_A)
        {
            
            Matrix E = Matrix.E(amountVar);
            Coord grad = Coord.Gradient(y, x2, amountVar);
            if (k % amountVar == 1)
            //if (k == 1)
                A = E;
            else
                A = opt_A(x1, x2);
            p = -A * grad;
            LinearSearch f1 = new LinearSearch(x2, p, y);
            
            return f1.M[6](50);
        }
        public int Method()
        {
            k = 1;
            Coord Grad;
            while (true)
            {
                x[k + 1] = newPoint(x[k - 1], x[k], BroidenFletcherShenno);
                //x[k + 1].output();
                

                //Console.WriteLine("k = {0}", k);
                Grad = Coord.Gradient(y, x[k+1], amountVar);
                //Grad.output();
                //Console.WriteLine("Norma = {0}", Grad.Norma);
                if (Grad.Norma <= Eps || k >= 300)
                {
                    min = x[k+1];
                    break;
                }
                k++;
            }
            return k;
        }
    }
}
