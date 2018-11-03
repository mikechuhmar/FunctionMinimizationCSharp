using System;



namespace All_console_
{
    
    class Program
    {
        //public Coord delegate diff_ex()
        static void Main(string[] args)
        {
            Examples ex = new Examples();
            Func.function y;

            Coord x0;
            Coord min;




            //3 lab

            /*for (int j = 1; j <= 8; j++)
            {
                Console.WriteLine("\nMethod {0}: ", j);
                for (int i = 1; i <= 9; i++)
                {
                    Console.WriteLine("Function {0}: ", i);
                    Coord p = new Coord(ex.direction[i]);
                    x0 = new Coord(ex.start[9 + i]);
                    Func.function y = ex.y[9 + i];
                    LinearSearch l = new LinearSearch(x0, p, y);
                    min = l.M[j](20);
                    min.output();
                }
            }*/
            /*for (int j = 1; j <= 9; j++)
            {
                Console.WriteLine("\nFunction {0}: ", j);
                for (int i = 1; i <= 8; i++)
                {
                    Console.WriteLine("Method {0}: ", i);
                    Coord p = new Coord(ex.direction[j]);
                    x0 = new Coord(ex.start[9 + j]);
                    y = ex.y[9 + j];
                    LinearSearch l = new LinearSearch(x0, p, y);
                    min = l.M[i](20);
                    min.output();
                }
            }*/


            /*f = new LinearSearch(x0, p, ex.y[10]);
            Coord c = f.M[3](20);
            c.output();*/
            //4 lab
            /*for (int i = 19; i <= 26; i++)
            {
                Console.Write("\nFunction {0}:   ", i);
                y = ex.y[i];
                double[] start = ex.start[i];
                
                x0 = new Coord(start);
                GradientMethod g = new GradientMethod(x0, start.Length, y, 1e-3);
                int k = g.GaussZeidel(50);
                Console.Write("\nmin: ");
                min = g.min;

                min.output();

                Console.Write("\nIterations:  {0}\n", k);

            }*/
            /*Coord dx = new Coord(ex.start[16]);
            double d = Func.diff_4(ex.y[16], dx, 1);
            Console.Write("dx = {0}", d);*/


            /*ConjugatedGrad f1 = new ConjugatedGrad(new Coord(ex.start[19]), ex.y[19], 1e-3);
            int k = f1.Method();
            Console.Write("\nmin: ");
            min = f1.min;

            min.output();*/

            //Console.Write("\nIterations:  {0}\n", k);
            //lab 8
            for (int i = 19; i <= 38; i++)
            { 
                Console.Write("\nFunction {0}:   ", i);
                y = ex.y[i];
                double[] start = ex.start[i];
                x0 = new Coord(start);
                ConjugatedGrad f1 = new ConjugatedGrad(x0, y, 1e-3);
                //int k = f1.PolakRibierMethod();
                int k = f1.FletcherReevesMethod();
                Console.Write("\nmin: ");
                min = f1.min;

                min.output();

                Console.Write("\nIterations:  {0}\n", k);

            }
            //lab 7
            /*for (int i = 19; i <= 38; i++)
            {
                Console.Write("\nFunction {0}:   ", i);
                y = ex.y[i];
                double[] start = ex.start[i];
                x0 = new Coord(start);
                VariableMetric f1 = new VariableMetric(x0, y, 1e-3);
                int k = f1.Method();
                Console.Write("\nmin: ");
                min = f1.min;

                min.output();

                Console.Write("\nIterations:  {0}\n", k);

            }*/
            //lab 6
            /*for (int i = 9; i <= 27; i++)
            {
                Console.Write("\nFunction {0}:   ", i);
                y = ex.y[i];
                double[] start = ex.start[i];
                x0 = new Coord(start);
                NewtonMod f1 = new NewtonMod(x0, y, 1e-3);
                int k = f1.NewtonWithAdjustingStep();
                Console.Write("\nmin: ");
                min = f1.min;

                min.output();

                Console.Write("\nIterations:  {0}\n", k);

            }*/
            /* y = ex.y[26];
            
            //lab 9
            /*for (int i = 30; i <= 33; i++)
            {
                Console.Write("\nFunction {0}:   ", i);
                y = ex.y[i];
                double[] start = ex.start[i];
                x0 = new Coord(start);
                HookeJeeves f1 = new HookeJeeves(x0, y, 1e-3);
                int k = f1.Method();
                Console.Write("\nmin: ");
                min = f1.min;

                min.output();

                Console.Write("\nIterations:  {0}\n", k);

            }*/
            /*for (int j = 1; j <= 9; j++)
            {
                Console.WriteLine("\nFunction {0}: ", j);
                Coord p = new Coord(ex.direction[j]);
                x0 = new Coord(ex.start[9 + j]);
                y = ex.y[9 + j];
                LinearSearch l = new LinearSearch(x0, p, y);
                min = l.M[3](20);
                min.output();
                /*l = new LinearSearch(x0, p/p.Norma, y);
                min = l.M[3](20);
                min.output();
            }*/
            /*double[,] arr = { { 0, 2, 3 }, { 4, 5, 3 }, { 6, 7, 2 } };
            //double[,] arr = { { 0, 0, 3 }, { 4, 5, 3 }, { 6, 7, 2 } };
            Matrix m = new Matrix(arr);
            Matrix.inverseMatrixGJ(m);
            /*for(int i = 10; i <= 18; i++)
            {
                Console.WriteLine("\nFunction {0}: ", i);
                x0 = new Coord(ex.start[i]);
                y = ex.y[i];
                Coord.Gradient_1(y, x0, x0.coord.Length).output();
                Coord.Gradient_2(y, x0, x0.coord.Length).output();
                Coord.Gradient_3(y, x0, x0.coord.Length).output();
                Coord.Gradient_4(y, x0, x0.coord.Length).output();
            }*/
            /*for (int i = 10; i <= 18; i++)
            {
                Console.WriteLine("\nFunction {0}: ", i);
                x0 = new Coord(ex.start[i]);
                y = ex.y[i];
                Matrix.H_1(y, x0.coord.Length, x0).output();
                Matrix.H_2(y, x0.coord.Length, x0).output();
            }*/
            Console.ReadKey();
        }
    }
}
