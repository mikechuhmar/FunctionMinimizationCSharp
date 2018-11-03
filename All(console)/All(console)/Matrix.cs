using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_console_
{
    class Matrix
    {
        public double[,] elements;
        public int length;
        public double this[int i, int j]
        {
            get
            {
                return elements[i, j];
            }
            set
            {
                elements[i, j] = value;
            }
        }
        public Matrix(double [,] _elements)
        {
            length = (int) Math.Sqrt(_elements.Length);
            elements = new double[length, length];
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    elements[i, j] = _elements[i, j];
        }
        public Matrix()
        {

        }
        public static Coord operator *(Matrix m, Coord c)
        {
            Coord answ = new Coord();
            answ.coord = new double[c.coord.Length];
            for (int i = 0; i < m.length; i++)
            {
                answ[i] = 0;
                for (int j =  0; j < m.length; j++)
                {
                    answ[i] += m[i, j] * c[j];
                }
            }
            return answ;
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            double[,] elements = new double[a.length, a.length];
            int i, j;
            for (i = 0; i < a.length; i++)
            {

                for (j = 0; j < a.length; j++)
                {
                    elements[i, j] = a[i, j] + b[i, j];                    
                }
            }
            Matrix answ = new Matrix(elements);
            return answ;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            double[,] elements = new double[a.length, a.length];
            int i, j;
            for (i = 0; i < a.length; i++)
            {

                for (j = 0; j < a.length; j++)
                {
                    elements[i, j] = a[i, j] - b[i, j];
                }
            }
            Matrix answ = new Matrix(elements);
            return answ;
        }
        public static Matrix operator -(Matrix m)
        {
            double[,] elements = new double[m.length, m.length];
            int i, j;
            for (i = 0; i < m.length; i++)
            {

                for (j = 0; j < m.length; j++)
                {
                    elements[i, j] = - m[i, j];
                }
            }
            Matrix answ = new Matrix(elements);
            return answ;
        }
        public static Matrix operator *(double alfa, Matrix m)
        {
            double[,] elements = new double[m.length, m.length];
            int i, j;
            for (i = 0; i < m.length; i++)
            {
                for (j = 0; j < m.length; j++)
                {
                    elements[i, j] = alfa * m[i, j];
                }
            }
            Matrix answ = new Matrix(elements);
            return answ;
        }
        public static Matrix operator *(Matrix m, double alfa)
        {
            double[,] elements = new double[m.length, m.length];
            int i, j;
            for (i = 0; i < m.length; i++)
            {
                for (j = 0; j < m.length; j++)
                {
                    elements[i, j] = alfa * m[i, j];
                }
            }
            Matrix answ = new Matrix(elements);
            return answ;
        }
        public static Matrix operator /(Matrix m, double alfa)
        {
            double[,] elements = new double[m.length, m.length];
            int i, j;
            for (i = 0; i < m.length; i++)
            {
                for (j = 0; j < m.length; j++)
                {
                    elements[i, j] = m[i, j] / alfa;
                }
            }
            Matrix answ = new Matrix(elements);
            return answ;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {            
            double [,] elements = new double[a.length, a.length];
            int i, j;
            for(i = 0; i < a.length; i++)
            {              
                
                for(j = 0; j < a.length; j++)
                {
                    elements[i, j] = 0;
                    for (int k = 0; k < a.length; k++)
                    {
                        elements[i, j] += a[i, k] * b[k, j];                       
                    }                   
                }
            }
            Matrix answ = new Matrix(elements);
            return answ;
        }
        public static Matrix minor(Matrix matr, int a, int b)
        {
            int m = matr.length;
            double[,] answ = new double[m - 1, m - 1];
            int di = 0, dj;
            for (int i = 0; i < m - 1; i++)
            {
                if (i == a)
                    di = 1;
                dj = 0;
                for (int j = 0; j < m - 1; j++)
                {
                    if (j == b)
                        dj = 1;
                    answ[i, j] = matr[i + di, j + dj];
                }
            }
            return new Matrix(answ);
        }
        public static Matrix transp(Matrix m)
        {
            double[,] elements = new double[m.length, m.length];
            int i, j;
            for (i = 0; i < m.length; i++)
            {
                for (j = 0; j < m.length; j++)
                {
                    elements[i, j] = m[j, i];
                }
            }
            Matrix answ = new Matrix(elements);
            return answ;
        }
        public Matrix Transp
        {
            get
            {
                return transp(this);
            }
        }
        public static double det(Matrix matr)
        {
            int m = matr.length;
            double[,] p = new double[m, m];
            double answ = 0;
            int k = 1;
            int n = m - 1;
            if (m == 1)
            {
                answ = matr[0, 0];
                return answ;
            }
            if (m == 2)
            {
                answ = matr[0, 0] * matr[1, 1] - matr[1, 0] * matr[0, 1];
            }
            if (m > 2)
            {
                for (int i = 0; i < m; i++)
                {
                    Console.WriteLine(i);
                    Matrix minor = matr.Minor(i, 0);
                    //Console.WriteLine(matr[i,0]);
                    //minor.output();
                    answ += k * matr[i, 0] * det(minor);
                    
                    k = -k;
                }
            }
            return answ;
        }
        public double Det
        {
            get
            {
                return det(this);
            }
        }
        public Matrix Minor(int a, int b)
        {
            return minor(this, a, b);
        }
        public static Matrix alliedMatrix(Matrix matr)
        {
            
            int m = matr.length;
            double[,] answ = new double[m, m];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < m; j++)
                    answ[i, j] = Math.Pow(-1, i + j) * matr.Minor(i, j).Det;
            return new Matrix(answ);
        }
        public Matrix AlliedMatrix
        {
            get
            {
                return alliedMatrix(this);
            }
        }
        public static Matrix inverseMatrix(Matrix matr)
        {
            if (matr.Det == 0)
                Console.WriteLine("нет");
            Matrix answ = matr.AlliedMatrix.Transp / matr.Det;
            return answ;
        }
        public Matrix InverseMatrix
        {
            get { return inverseMatrix(this); }
        }
        public static Matrix inverseMatrixGJ(Matrix matr)
        {
            /*if (matr.Det == 0)
                Console.WriteLine("нет");*/
            Matrix a = new Matrix(matr.elements);
            Matrix answ = Matrix.E(matr.length);

            for(int i = 0; i < a.length; i++)
            {
                if (a[i,i] == 0)
                {
                    for(int j = i + 1; j < a.length; j++)
                    {
                        if (a[j,i] != 0)
                        {
                            for (int l = 0; l < a.length; l++)
                            {
                                double var1 = a[j, l];
                                a[j, l] = a[i,l];
                                a[i, l] = var1;
                                double var2 = answ[j, l];
                                answ[j, l] = answ[i, l];
                                answ[i, l] = var2;
                            }
                            break;
                        }
                        
                    }
                }
            }

            for (int i = 0; i < a.length; i++)
            {
                double var = a[i, i];
                for (int l = 0; l < a.length; l++)
                {
                    
                    a[i, l] /= var;
                    answ[i, l] /= var;
                }
                for (int j = i + 1; j < a.length; j++)
                {
                    for (int l = 0; l < a.length; l++)
                    {
                        var = a[j, i];
                        a[j, l] -= a[i, l] * var;
                        answ[j, l] -= answ[i, l] * var;
                        Console.WriteLine("i = {0}  j = {1}  l = {2} ", i,j,l);
                        a.output();
                        Console.WriteLine();
                        answ.output();
                        Console.WriteLine();
                    }
                }
            }
            /*for (int i = a.length - 2; i >= 0; i--)
            {
                double var;
                for (int j = a.length - 1; j > i; j--)
                {
                    for (int l = 0; l < a.length; l++)
                    {
                        var = a[i, j];
                        a[i, l] -= a[j, l] * var;
                        answ[i, l] -= answ[j, l] * var;
                    }
                }
            }*/
            //matr.output();
            //a.output();
            //answ.output();
            return answ;
        }
        public void output()
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write("{0}  ", elements[i, j]);
                }
                Console.Write("\n");
            }
        }

        public static Matrix E (int length)
        {
            double[,] el = new double[length, length];
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                {
                    if (i == j)
                        el[i, j] = 1;
                    else
                        el[i, j] = 0;
                }
            return new Matrix(el);
        }
        public static Matrix H (Func.function f, int length, Coord x)
        {
            double[,] el = new double[length, length];
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    el[i, j] = Func.second_diff_2(f, x, i, j);
            return new Matrix(el);
        }
        public static Matrix H_1(Func.function f, int length, Coord x)
        {
            double[,] el = new double[length, length];
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    el[i, j] = Func.second_diff_1(f, x, i, j);
            return new Matrix(el);
        }
        public static Matrix H_2(Func.function f, int length, Coord x)
        {
            double[,] el = new double[length, length];
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    el[i, j] = Func.second_diff_2(f, x, i, j);
            return new Matrix(el);
        }
    }
}
