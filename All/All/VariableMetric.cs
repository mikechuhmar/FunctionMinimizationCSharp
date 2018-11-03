

namespace All
{
    class VariableMetric : Multidimensial
    {
        //Функция оптимизации
        public delegate Matrix opt(Coord x1, Coord x2);
        //Матрица А
        Matrix A;
        //Направление поиска
        Coord p;
        //Конструктор
        public VariableMetric(IntroducedFunction _y, Coord _x0, double _Eps, int _maxIter) : base(_y, _Eps, _maxIter)
        {
            x = new Coord[maxIter + 2];
            x[0] = _x0;
            x[1] = x[0];
        }
        //Разность градиентов
        Coord Gamma(Coord x1, Coord x2)
        {
            Coord grad1 = Coord.Gradient(y, x1, amountVar);
            Coord grad2 = Coord.Gradient(y, x2, amountVar);
            Coord gamma = grad2 - grad1;
            return gamma;
        }
        //s
        Coord s(Coord x1, Coord x2)
        {
            return A * Gamma(x1, x2);
        }
        //Разность точек
        Coord dx(Coord x1, Coord x2)
        {
            return x2 - x1;
        }
        //В
        Matrix B(Coord x1, Coord x2)
        {
            Matrix E = Matrix.E(A.length);
            Matrix answ;
            answ = E - (dx(x1, x2) * Gamma(x1, x2).Transp) / (Gamma(x1, x2).Transp * dx(x1, x2));
            return answ;
        }
        //Функция Бройдена-Флетчера-Шенно
        Matrix BroidenFletcherShenno(Coord x1, Coord x2)
        {
            Matrix answ;
            answ = B(x1, x2) * A * B(x1, x2) + (dx(x1, x2) * dx(x1, x2).Transp) / (dx(x1, x2).Transp * dx(x1, x2));
            return answ;
        }
        //Функция для высчитывания новой точки
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
            p = p / p.Norma;
            LinearSearch f1 = new LinearSearch(x2, p, y);
            f1.Svenn(20);
            f1.Bolcano(10);
            f1.Davidon();
            alfa = f1.alfa_min;
            Coord x3 = x2 + alfa * p/p.Norma;
            return x3;
        }
        //Метод переменной метрики
        public int Method(opt opt_A)
        {
            k = 1;
            Coord Grad;
            while (true)
            {
                x[k + 1] = newPoint(x[k - 1], x[k], opt_A);
                Grad = Coord.Gradient(y, x[k + 1], amountVar);
                if (Grad.Norma <= Eps || k >= maxIter)
                {
                    min = x[k + 1];
                    break;
                }
                k++;
            }
            return k;
        }
        public int BroidenFletcherShennoMethod()
        {
            return Method(BroidenFletcherShenno);
        }
    }
}
