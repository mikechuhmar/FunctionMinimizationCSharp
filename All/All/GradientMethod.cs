using System;

namespace All
{
    class GradientMethod: Multidimensial
    {
        int points = 0;       

        public GradientMethod(IntroducedFunction _y, Coord _x0, double _Eps, int _maxIter): base(_y, _Eps, _maxIter)
        {         
            amountPoints = amountVar + 2;
            x = new Coord[amountPoints];
            x[0] = _x0;
            x[1] = x[0];
        }

        Coord newPointGZ(Coord x)
        {
            int length = x.coord.Length;
            double[] arr_p = new double[length];
            Coord p = new Coord(arr_p);
            points = points % amountVar;
            p.coord[points] = Func.diff_4(y, x, points);
            p = p / p.Norma;
            LinearSearch f1 = new LinearSearch(x, p, y);
            f1.Svenn5();
            f1.Bolcano(5);
            f1.Davidon();
            alfa = f1.alfa_min;
            Coord x_2 = x + alfa * p;
            points++;
            return x_2;
        }
        public int GaussZeidel()
        {
            

            k = 0;
            Coord d;


            while (true)
            {
                int i = 2;

                Console.Write("\nx1: ");
                x[1].output();
                for (; i <= amountPoints - 1; i++)
                {
                    x[i] = newPointGZ(x[i - 1]);
                    Console.Write("\nx{0}: ", i);
                    x[i].output();

                }

                d = x[points] - x[1];
                //Console.Write("\nd: ");
                Console.Write("\n norma: {0}", d.norma());
                //d.output();
                k++;
                if (d.norma() <= Eps || x[points].Gradient(y).Norma <= Eps || k >= maxIter)
               
                {
                    min = x[i - 1];
                    break;
                }
                else
                {
                    x[1] = x[i - 1];
                }
            }
            return k;
        }
    }
}
