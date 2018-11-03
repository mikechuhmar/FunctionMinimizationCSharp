

namespace All
{
    class TranspCoord
    {
        //Массив координат
        public double[] coord;
        public double this[int i]
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
        //Конструкторы
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
        //Перегрузки операторов
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
    }
}
