using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All
{
    class HookeJeeves: Multidimensial
    {
        double h;
        public HookeJeeves(IntroducedFunction _y, Coord _x0, double _Eps, int _maxIter) : base(_y, _Eps, _maxIter)
        {
            h = 0.01 * x[0].Norma;
        }

    }
}
