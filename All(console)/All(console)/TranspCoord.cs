using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_console_
{
    class TranspCoord
    {
        public double[] coord;

        public TranspCoord(double[] _coord)
        {
            coord = new double[_coord.Length];
            for (int i = 0; i < _coord.Length; i++)
                this.coord[i] = _coord[i];
        }
        public TranspCoord(Coord c)
        {
            coord = new double[c.coord.Length];
            for (int i = 0; i < c.coord.Length; i++)
                this.coord[i] = c.coord[i];
        }
        public static double operator *(TranspCoord t, Coord c)
        {
            double answ = 0;
            for (int i = 0; i < c.coord.Length; i++)
                answ += t.coord[i] * c.coord[i];
            return answ;
        }
        public static Matrix operator *(Coord c, TranspCoord t)
        {
            int length = c.coord.Length;
            double[,] arr = new double[length, length];
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    arr[i, j] = c.coord[i] * t.coord[j];
            return new Matrix(arr);    
        }
        public void output()
        {
            foreach (double d in coord)
                Console.Write(" {0} ", d);
            Console.Write("\n");
        }
    }
}
