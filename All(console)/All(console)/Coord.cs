using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_console_
{
    class Coord
    {
        public double[] coord;
        public int length;
        public double this [int i]
        {
            get
            {
                return coord[i];
            }
            set
            {
                coord[i] = value;
            }
        }
        public Coord()
        {

        }
        public Coord(Coord c)
        {
            coord = new double[c.coord.Length];
            for (int i = 0; i < c.coord.Length; i++)
                this.coord[i] = c.coord[i];
            length = c.coord.Length;
        }
        public Coord(double[] point)
        {
            coord = new double[point.Length];
            for (int i = 0; i < point.Length; i++)
                this.coord[i] = point[i];
            length = coord.Length;
        }
        public static Coord operator +(Coord a, Coord b)
        {
            Coord answ = new Coord(a.coord);
            answ.coord = new double[a.coord.Length];
            for (int i = 0; i < a.coord.Length; i++)
            {
                answ.coord[i] = a.coord[i] + b.coord[i];
            }

            return answ;
        }
        public static Coord operator -(Coord a, Coord b)
        {
            Coord answ = new Coord(a.coord);
            answ.coord = new double[a.coord.Length];
            for (int i = 0; i < a.coord.Length; i++)
            {
                answ.coord[i] = a.coord[i] - b.coord[i];
            }
            return answ;
        }
        public static Coord operator -(Coord c)
        {
            Coord answ = new Coord();
            answ.coord = new double[c.coord.Length];
            for (int i = 0; i < c.coord.Length; i++)
            {
                answ.coord[i] = -c.coord[i];
            }
            return answ;
        }
        public static Coord operator *(double alfa, Coord a)
        {
            Coord answ = new Coord();
            answ.coord = new double[a.coord.Length];
            for (int i = 0; i < a.coord.Length; i++)
            {
                answ.coord[i] = alfa * a.coord[i];
            }
            return answ;
        }
        public static Coord operator /(Coord a, double alfa)
        {
            Coord answ = new Coord();
            answ.coord = new double[a.coord.Length];
            for (int i = 0; i < a.coord.Length; i++)
            {
                answ.coord[i] = a.coord[i] / alfa;
            }
            return answ;
        }
        public double norma()
        {
            double normaSqr = 0;
            foreach (double c in coord)
                normaSqr += c * c;
            return Math.Sqrt(normaSqr);
        }
        public double Norma
        {
            get { return norma(); }
        }
        public static Coord Ort(int amount, int number)
        {
            double[] array = new double[amount];
            for (int i = 0; i < amount; i++)
            {
                if (i == number)
                    array[i] = 1;
                else
                    array[i] = 0;
            }
            return new Coord(array);
        }
        public static Coord Gradient(Func.function f, Coord x, int amount)
        {
            double[] g = new double[amount];
            for (int i = 0; i < amount; i++)
            {
                g[i] = Func.diff_2(f, x, i);
            }
            return new Coord(g);
        }
        public static Coord Gradient_1(Func.function f, Coord x, int amount)
        {
            double[] g = new double[amount];
            for (int i = 0; i < amount; i++)
            {
                g[i] = Func.diff_1(f, x, i);
            }
            return new Coord(g);
        }
        public static Coord Gradient_2(Func.function f, Coord x, int amount)
        {
            double[] g = new double[amount];
            for (int i = 0; i < amount; i++)
            {
                g[i] = Func.diff_2(f, x, i);
            }
            return new Coord(g);
        }
        public static Coord Gradient_3(Func.function f, Coord x, int amount)
        {
            double[] g = new double[amount];
            for (int i = 0; i < amount; i++)
            {
                g[i] = Func.diff_3(f, x, i);
            }
            return new Coord(g);
        }
        public static Coord Gradient_4(Func.function f, Coord x, int amount)
        {
            double[] g = new double[amount];
            for (int i = 0; i < amount; i++)
            {
                g[i] = Func.diff_4(f, x, i);
            }
            return new Coord(g);
        }
        public Coord Gradient(Func.function f)
        {
            return Gradient(f, this, this.coord.Length);
        }
        public void output()
        {
            foreach (double d in coord)
                Console.Write("   {0: 0.000000} ", d);
            Console.Write("\n");
        }
        public TranspCoord transp()
        {
            return new TranspCoord(coord);
        }
        public TranspCoord Transp
        {
            get
            {
                return transp();
            }
        }
        
    }
}
