

namespace All
{
    
    class NewtonMod: Multidimensial
    {
        //Коэффициент уменьшения шага
        double beta;
        //Направление
        Coord p;
        //Конструктор
        public NewtonMod(IntroducedFunction _y, Coord _x0, double _Eps, int _maxIter) : base(_y, _Eps, _maxIter)
        {
            x = new Coord[3];
            x[0] = _x0;
            x[1] = x[0];
        }
        //Метод Ньютона с регулировкой шага
        public int NewtonWithAdjustingStep()
        {
            k = 0;
            while (true)
            {
                Coord Grad = x[1].Gradient(y);
                //Если не существует обратной матрицы
                if (-Matrix.H(y, amountVar, x[1]).Det == 0)
                {
                    k = -1;
                    break;
                }
                p = -Matrix.H(y, amountVar, x[1]).InverseMatrix * x[1].Gradient(y);
                //p = p / p.Norma;
                alfa = 1;
                beta = 2;
                x[2] = x[1] + alfa * p;
                k++;
                if (x[2].Gradient(y).Norma <= Eps)
                {
                    min = x[2];
                    break;
                }
                else
                {
                    alfa /= beta;
                    x[1] = x[2];
                }
            }
            return k;
        }
    }
}
