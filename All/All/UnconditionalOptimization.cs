
using System.Collections.Generic;


namespace All
{
    class UnconditionalOptimization: Multidimensial
    {
        //Шаг
        double h;
        //Коэффициент уменьшения шага
        double beta;
        //Список новых точек, среди которых нужно искать минимум
        List<Coord> x_new = new List<Coord>();

        //Конструктор
        public UnconditionalOptimization(IntroducedFunction _y, Coord _x0, double _Eps, int _maxIter) : base(_y, _Eps, _maxIter)
        {
            x = new Coord[5];
            x[0] = _x0;
            x[1] = x[0];
            h = 0.01 * x[0].Norma;
            beta = 2;
        }
        //Поиск новых точек и добавление их в список
        void SuitablePoints(Coord x, int length, List<Coord> p)
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
        //Исследовательский поиск среди новых точек и стартовой точки
        Coord Research(Coord x)
        {
            x_new = new List<Coord>();
            x_new.Add(x);
            SuitablePoints(x, x.coord.Length, x_new);
            //Предположительный минимум
            Coord x_ = new Coord(x);
            foreach (Coord p in x_new)
                if (y.Answer(p) < y.Answer(x_))
                    x_ = new Coord(p);
            return x_;

        }
        public int HookeJeeves()
        {
            while(true)
            {
                //Получение новой точки с помощью исследовательского поиска
                x[2] = Research(x[1]);
                //Если не удалось найти подходящую точку, уменьшаем шаг
                if (y.Answer(x[2]) >= y.Answer(x[1]))
                {
                    h /= beta;
                    k++;
                }
                else
                {
                    do
                    {
                        //Ускоряющий поиск в новую точку в направлении минимума
                        x[3] = 2 * x[2] - x[1];
                        //Исследовательский поиск из новой точки
                        x[4] = Research(x[3]);
                        //Если удалось найти точку, лучшую чем точка найденная при первом исследовательском поиске, 
                        //стартовыя точка становится равна предыдущей лучшей точке, а предыдущая лучшая точка равна новой лучшей точке
                        if (y.Answer(x[4]) < y.Answer(x[2]))
                        {                           
                            x[1] = x[2];
                            x[2] = x[4];
                        }
                        //Иначе стартовая точка равна предыдущей лучшей точке и переход к началу алгоритма
                        else
                        {
                            x[1] = x[2];
                            x[1].output();
                            break;
                        }
                    } while (y.Answer(x[4]) > y.Answer(x[2]));                                      
                }
                if (h <= Eps || k >= maxIter)
                {
                    min = x[2];
                    break;
                }
            }
            return k;
        }
    }
}
