using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_console_
{
    class HookeJeeves
    {
        protected Func.function y;
        protected int amountVar;
        protected int amountPoints;
        protected Coord[] x = new Coord[6];
        protected double Eps;
        protected int maxIter;
        protected int k = 1;
        public Coord min;
        public double h = 0.5;
        public double beta = 2;
        public List<Coord> points = new List<Coord>();
        public HookeJeeves(Coord _x0, Func.function _y, double _Eps)
        {
            x[0] = _x0;
            x[1] = x[0];
            y = _y;
            Eps = _Eps;
            //h = 0.01 * x[0].Norma;
        }
        
        public void SuitablePoints(Coord x, int length, List<Coord> p)
        {
            
            Coord Ort = Coord.Ort(x.coord.Length, length - 1);          
            p.Add(x + h * Ort);
            
            p.Add(x - h * Ort);
            
            if (length - 1 > 0)
            {
                SuitablePoints(new Coord(x + h * Ort), length - 1, p);
                SuitablePoints(new Coord(x - h * Ort), length - 1, p);
                SuitablePoints(new Coord(x), length - 1, p);               

            }
            
        }
        public Coord Research(Coord x)
        {
            points = new List<Coord>();
            points.Add(x);
            SuitablePoints(x, x.coord.Length, points);
            Coord x_ = new Coord(x);
            foreach (Coord p in points)
                if (y(p) < y(x_))
                    x_ = new Coord(p);
            return x_;

        }
        public int Method()
        {
            while(true)
            {
                
                x[2] = Research(x[1]);
                
                if (y(x[2]) >= y(x[1]))
                {
                    h /= beta;
                    Console.WriteLine("h = {0}", h);
                    k++;
                }
                else
                {
                    do
                    {
                        x[3] = 2 * x[2] - x[1];
                        
                        x[4] = Research(x[3]);
                        x[4].output();
                        if (y(x[4]) < y(x[2]))
                        {
                            //Console.WriteLine("x2: {0}", y(x[2]));
                            
                            x[1] = x[2];
                            x[2] = x[4];
                        }
                        else
                        {
                            x[1] = x[2];
                            x[1].output();
                            break;
                        }

                    } while (y(x[4]) > y(x[2]));


                }
                
                if(h <= Eps)
                {
                    min = x[1];
                    
                    break;
                }
            }
            return k;
        }
    }
}
