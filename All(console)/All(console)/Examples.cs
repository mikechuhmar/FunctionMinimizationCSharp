using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_console_
{
    class Examples
    {
        //Функции для Практических работ 1 и 2
        //С использованием double
        double _y1(double x)
        {
            return 2 * x * x + 3 * Math.Exp(-x);
        }
        double _y2(double x)
        {
            return -Math.Exp(-x) * Math.Log(x);
        }
        double _y3(double x)
        {
            return 2 * x * x - Math.Exp(x);
        }
        double _y4(double x)
        {
            return Math.Pow(x, 4) - 14 * Math.Pow(x, 3) + 60 * Math.Pow(x, 2) - 70 * x;
        }
        double _y5(double x)
        {
            if (x >= 0)
                return 4 * Math.Pow(x, 3) - 3 * Math.Pow(x, 4);
            else
                return 4 * Math.Pow(x, 3) + 3 * Math.Pow(x, 4);
        }
        double _y6(double x)
        {
            return Math.Pow(x, 2) + 2 * x;
        }
        double _y7(double x)
        {
            return 2 * Math.Pow(x, 2) + 16 / x;
        }
        double _y8(double x)
        {
            return Math.Pow(10 * Math.Pow(x, 3) + 3 * Math.Pow(x, 2) + x + 5, 2);
        }
        double _y9(double x)
        {
            return 3 * Math.Pow(x, 2) + 12 / Math.Pow(x, 3) - 5;
        }
        //С использованием Coord
        double y0(Coord x)
        {
            return 2 * x[0] * x[0] + 2 * x[1] * x[1] - x[0] * x[1] + x[0];
        }
        double y1(Coord x)
        {
            return 2 * x[0] * x[0] + 3 * Math.Exp(-x[0]);
        }       
        double y2(Coord x)
        {
            return -Math.Exp(-x[0]) * Math.Log(x[0]);
        }
        double y3(Coord x)
        {
            return 2 * x[0] * x[0] - Math.Exp(x[0]);
        }
        double y4(Coord x)
        {
            return Math.Pow(x[0], 4) - 14 * Math.Pow(x[0], 3) + 60 * Math.Pow(x[0], 2) - 70 * x[0];
        }
        double y5(Coord x)
        {
            if (x.coord[0] >= 0)
                return 4 * Math.Pow(x[0], 3) - 3 * Math.Pow(x[0], 4);
            else
                return 4 * Math.Pow(x[0], 3) + 3 * Math.Pow(x[0], 4);
        }
        double y6(Coord x)
        {
            return Math.Pow(x[0], 2) + 2 * x[0];
        }
        double y7(Coord x)
        {
            return 2 * Math.Pow(x[0], 2) + 16 / x[0];
        }
        double y8(Coord x)
        {
            return Math.Pow(10 * Math.Pow(x[0], 3) + 3 * Math.Pow(x[0], 2) + x[0] + 5, 2);
        }
        double y9(Coord x)
        {
            return 3 * Math.Pow(x[0], 2) + 12 / Math.Pow(x[0], 3) - 5;
        }
        //Функции для Практической работы 3 
        double y10(Coord x)
        {
            return Math.Pow(x[0], 2) + 3 * Math.Pow(x[1], 2) + 2 * x[0] * x[1];
        }
        double y11(Coord x)
        {
            return 100 * Math.Pow(x[1] - x[0] * x[0], 2) + Math.Pow(1 - x[0], 2);
        }
        double y12(Coord x)
        {
            //return -12 * x.coord[1] + 4 * x.coord[0] * x.coord[0] + 4 * x.coord[1] * x.coord[1] - 4 * x.coord[0] * x.coord[1];
            return -12 * x[1] + 4 * Math.Pow(x[0], 2) + 4 * Math.Pow(x[1], 2) - 4 * x[0] * x[1];
        }
        double y13(Coord x)
        {
            return Math.Pow(x[0] - 2, 4) + Math.Pow(x[0] - 2 * x[1], 2);
        }
        double y14(Coord x)
        {
            return 4 * Math.Pow(x[0] - 5, 2) + Math.Pow(x[1] - 6, 2);
        }

        double y16(Coord x)
        {
            return 2 * Math.Pow(x[0], 3) + 4 * x[0] * Math.Pow(x[1], 3) - 10 * x[0] * x[1] + Math.Pow(x[1], 2);
        }
        double y17(Coord x)
        {
            return 8 * Math.Pow(x[0], 2) + 4 * x[0] * x[1] + 5 * Math.Pow(x[1], 2);
        }

        //Функции для Практических работ 4, 5 и 6

        double y20(Coord x)
        {
            return Math.Pow(x[0] - 1, 2) + Math.Pow(x[1] - 3, 2) + 4 * Math.Pow(x[2] + 5, 2);
        }


        double y23(Coord x)
        {
            return Math.Pow(x[1] - Math.Pow(x[0], 2), 2) + Math.Pow(1 - x[0], 2);
        }
        double y24(Coord x)
        {
            return Math.Pow(x[1] - Math.Pow(x[0], 2), 2) + 100 * Math.Pow(1 - Math.Pow(x[0], 2), 2);
        }
        double y25(Coord x)
        {
            return 3 * Math.Pow(x[0] - 4, 2) + 5 * Math.Pow(x[1] + 3, 2) + 7 * Math.Pow(2 * x[2] + 1, 2);
        }
        double y26(Coord x)
        {
            return Math.Pow(x[0], 3) + Math.Pow(x[1], 2) - 3 * x[0] - 2 * x[1] + 2;
        }
        //Функции для практических работ 7, 8, 9 и 10
        double y27(Coord x)
        {
            return -12 * x[1] + 4 * Math.Pow(x[0], 2) + 4 * Math.Pow(x[1], 2) - 4 * x[0] * x[1];
        }
        double y28(Coord x)
        {
            return Math.Pow(x[0] - 2, 4) + Math.Pow(x[0] - 2 * x[1], 2);
        }
        double y29(Coord x)
        {
            return Math.Pow(x[0] * x[1] * x[2] - 1, 2) + 5 * Math.Pow(x[2] * (x[0] + x[1]), 2) + 2 * Math.Pow(x[0] + x[1] + x[2] - 3, 2);
        }
        double y30(Coord x)
        {
            return 4 * Math.Pow(x[0], 2) + 3 * Math.Pow(x[1], 2) - 4 * x[0] * Math.Pow(x[1], 2) + x[0];
        }
        double y31(Coord x)
        {
            return Math.Pow(Math.Pow(x[0], 2) + x[1] - 11, 2) + Math.Pow(x[0] + Math.Pow(x[1], 2) - 7, 2);
        }
        double y32(Coord x)
        {
            return 100 * Math.Pow(x[1] - Math.Pow(x[0], 3), 2) + Math.Pow(1 - x[0], 2);
        }
        double y33(Coord x)
        {
            return Math.Pow(1.5 - x[0] * (1 - x[1]), 2) + Math.Pow(2.25 - x[0] * (1 - Math.Pow(x[1], 2)), 2) + Math.Pow(2.625 - x[0] * (1 - Math.Pow(x[1], 3)), 2);
        }
        double y34(Coord x)
        {
            return Math.Pow(x[0] + 10 * x[1], 2) + 5 * Math.Pow(x[2] - x[3], 2) + Math.Pow(x[1] - 2 * x[2], 4) + 10 * Math.Pow(x[0] - x[3], 4);
        }
        double y35(Coord x)
        {
            return 100 * Math.Pow(x[1] - Math.Pow(x[0], 2), 2) + Math.Pow(1 - x[0], 2) + 90 * Math.Pow(x[3] - Math.Pow(x[2], 2), 2) + Math.Pow(1 - x[2], 3) + 10.1 * (Math.Pow(x[1] - 1, 2) + Math.Pow(x[3] - 1, 2)) + 19.8 * (x[1] - 1) * (x[3] - 1);
        }
        double y36(Coord x)
        {
            return (2 * Math.Pow(x[0], 2) + 3 * Math.Pow(x[1], 2)) * Math.Exp(Math.Pow(x[0], 2) - Math.Pow(x[1], 2));
        }
        double y37(Coord x)
        {
            return 0.1 * (12 + Math.Pow(x[0], 2) + (1 + Math.Pow(x[1], 2)) / (Math.Pow(x[0], 2) + (Math.Pow(x[0], 2) * Math.Pow(x[1], 2) + 100) / (Math.Pow(x[0], 4) * Math.Pow(x[1], 4))));
        }
        double y38(Coord x)
        {
            return 100 * Math.Pow(x[2] - 0.25 * Math.Pow(x[0] + x[1], 2), 2) + Math.Pow(1 - x[0], 2) + Math.Pow(1 - x[1], 2);
        }




        public Func.function[] y;
        public Func._function[] _y;
        void ArrayFunc()
        {
            _y = new Func._function[10];
            _y[1] = _y1;
            _y[2] = _y2;
            _y[3] = _y3;
            _y[4] = _y4;
            _y[5] = _y5;
            _y[6] = _y6;
            _y[7] = _y7;
            _y[8] = _y8;
            _y[9] = _y9;
            y = new Func.function[100];
            y[0] = y0;
            y[1] = y1;
            y[2] = y2;
            y[3] = y3;
            y[4] = y4;
            y[5] = y5;
            y[6] = y6;
            y[7] = y7;
            y[8] = y8;
            y[9] = y9;
            y[10] = y10;
            y[11] = y11;
            y[12] = y12;
            y[13] = y13;
            y[14] = y14;
            y[15] = y[13];
            y[16] = y16;
            y[17] = y17;
            y[18] = y[14];
            y[19] = y[11];
            y[20] = y20;
            y[21] = y[17];
            y[22] = y[14];
            y[23] = y23;
            y[24] = y24;
            y[25] = y25;
            y[26] = y26;
            y[27] = y27;
            y[28] = y28;
            y[29] = y29;
            y[30] = y30;
            y[31] = y31;
            y[32] = y32;
            y[33] = y33;
            y[34] = y34;
            y[35] = y35;
            y[36] = y36;
            y[37] = y37;
            y[38] = y38;
        }
        //public ArrayList start = new ArrayList(100);
        public double[][] start = new double[100][];
        public double[] _start = { Double.NaN, 1, 0, 1, 2, 0.4, 4, 1, 2, 0.5 };
        void ArrayStart()
        {
            
            double[] start1 = { 1.0 };
            double[] start2 = { 0.0 };
            double[] start3 = { 1.0 };
            double[] start4 = { 2.0 };
            double[] start5 = { 0.4 };
            double[] start6 = { 4.0 };
            double[] start7 = { 1.0 };
            double[] start8 = { 2.0 };
            double[] start9 = { 0.5 };
            double[] start10 = { 1.0, 1.0 };
            double[] start11 = { -1, 0 };
            double[] start12 = { -0.5, 1.0 };
            double[] start13 = { 0.0, 3.0 };
            double[] start14 = { 8.0, 9.0 };
            double[] start15 = { 0.0, 3.0 };
            double[] start16 = { 5.0, 2.0 };
            double[] start17 = { 10.0, 16.0 };
            double[] start18 = { 8.0, 9.0 };
            double[] start19_1 = { -1.2, 1.0 };
            double[] start19_2 = { 1.5, 2.0 };
            double[] start19_3 = { -2.0, -2.0 };
            double[][] start19 = { start19_1, start19_2, start19_3 };
            double[] start20 = { 4.0, -1.0, 2.0 };
            double[] start21 = { 10.0, 10.0 };
            double[] start22_1 = { 8.0, 9.0 };
            double[] start22_2 = { 0.5, 0.0 };
            double[][] start22 = { start22_1, start22_2 };
            double[] start23_1 = { 1.5, 2.0 };
            double[] start23_2 = { 0.5, 0.0 };
            double[] start23_3 = { -1.2, 1.0 };
            double[][] start23 = { start23_1, start23_2, start23_3 };
            double[] start24_1 = { 1.5, 2.0 };
            double[] start24_2 = { 1.0, 2.0 };
            double[][] start24 = { start24_1, start24_2 };
            double[] start25_1 = { 2.0, -2.0, -2.0 };
            double[] start25_2 = { 0.0, 0.0, 0.0 };
            double[][] start25 = { start25_1, start25_2 };
            double[] start26_1 = { 0.0, 0.0 };
            double[] start26_2 = { -1.0, -1.0 };
            double[][] start26 = { start26_1, start26_2 };
            double[] start27 = { 1.0, 0.0 };
            double[] start28 = { 0.0, 3.0 };
            double[] start29 = { -5.0, 4.0, 2.0 };
            double[] start30 = { 0.0, 0.0 };
            double[] start31 = { 0.0, 0.0 };
            double[] start32 = { -1.2, 1.0 };
            double[] start33 = { 0.0, 0.0 };
            double[] start34 = { -3.0, -1.0, 0.0, 1.0 };
            double[] start35 = { -3.0, -1.0, -3.0, 1.0 };
            double[] start36 = { 1.0, 0.5 };
            double[] start37 = { 0.5, 0.5 };
            double[] start38 = { -1.5, 2.0, 0.0 };
            start[1] = start1;
            start[2] = start2;
            start[3] = start3;
            start[4] = start4;
            start[5] = start5;
            start[6] = start6;
            start[7] = start7;
            start[8] = start8;
            start[9] = start9;
            start[10] = start10;
            start[11] = start11;
            start[12] = start12;
            start[13] = start13;
            start[14] = start14;
            start[15] = start15;
            start[16] = start16;
            start[17] = start17;
            start[18] = start18;
            start[19] = start19_1;
            start[20] = start20;
            start[21] = start21;
            start[22] = start22_1;
            start[23] = start23_1;
            start[24] = start24_2;
            start[25] = start25_2;
            start[26] = start26_1;
            start[27] = start27;
            start[28] = start28;
            start[29] = start29;
            start[30] = start30;
            start[31] = start31;
            start[32] = start32;
            start[33] = start33;
            start[34] = start34;
            start[35] = start35;
            start[36] = start36;
            start[37] = start37;
            start[38] = start38;
        }
        public double[][] direction = new double[10][];
        void ArrayDirection()
        {
            double[] dir1 = { 2, 3 };
            direction[1] = dir1;
            double[] dir2 = { 5, 2 };
            direction[2] = dir2;
            double[] dir3 = { 1, 0 };
            direction[3] = dir3;
            double[] dir4 = { 1, 0 };
            direction[4] = dir4;
            double[] dir5 = { 1, 0 };
            direction[5] = dir5;
            double[] dir6 = { 44, -24.1 };
            direction[6] = dir6;
            double[] dir7 = { 0, 1 };
            direction[7] = dir7;
            double[] dir8 = { 224, 200 };
            direction[8] = dir8;
            double[] dir9 = { 0, 1 };
            direction[9] = dir9;
        }
        public Examples()
        {
            ArrayFunc();
            ArrayStart();
            ArrayDirection();
        }
    }
}
