using System;

namespace All
{
    class ConjugatedGrad: Multidimensial
    {           
        //Направление поиска   
        Coord p;
        //Градиент
        Coord Grad; 
        //Функция для оптимизации       
        public delegate double opt(Coord x1, Coord x2);
        //Конструктор
        public ConjugatedGrad(IntroducedFunction _y, Coord _x0, double _Eps, int _maxIter) : base(_y, _Eps, _maxIter)
        {
            x = new Coord[maxIter + 2];
            x[0] = _x0;
            x[1] = x[0];   
        }
        //Формула Полака-Рибьера
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
        //Формула Флетчера-Ривса
        double FletcherReeves(Coord x1, Coord x2)
        {
            double Beta;
            Coord grad1 = Coord.Gradient(y, x1, amountVar);
            Coord grad2 = Coord.Gradient(y, x2, amountVar);
            Beta = (grad2.Norma * grad2.Norma) / (grad1.Norma * grad1.Norma);
            return Beta;
        }
        //Функция для высчитывания новой точки
        Coord newPoint(Coord x1, Coord x2, opt OptBeta)
        {
            opt Beta = OptBeta;
            Grad = Coord.Gradient(y, x2, amountVar);
            //Если k = 1, n+1, 2n+1...
            if (k % amountVar == 1)
                p = -Grad;
            else
            {
                double beta = Beta(x2, x1);
                p = -Grad + (beta * p);
            }
            //Запускаем линейный поиск
            p = p / p.Norma;
            LinearSearch f1 = new LinearSearch(x2, p, y);
            f1.Svenn(20);
            f1.Bolcano(20);            
            f1.Davidon();
            alfa = f1.alfa_min;
            p = p / p.Norma;
            Coord x3 = x2 + alfa * p;         
            return x3;
        }
        //Метод сопряжённых градиентов
        public int Method(opt OptBeta)
        {            
            opt Beta = OptBeta;
            double[] arr_p = new double[amountVar];
            Coord p = new Coord(arr_p);            
            k = 1;
            //Высчитываем новую точку, пока квадрат нормы градиента меньше эпсилон
            while (true)
            {
                x[k + 1] = newPoint(x[k - 1], x[k], OptBeta);
                Grad = Coord.Gradient(y, x[k + 1], amountVar);
                if (Grad.Norma*Grad.Norma <= Eps || k >= maxIter ) 
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
