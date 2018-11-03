

namespace All
{
    class Multidimensial
    {
        protected IntroducedFunction y;
        protected int amountVar;
        protected int amountPoints;
        protected Coord[] x ;
        protected double Eps;
        protected int maxIter;
        protected int k;
        protected double alfa;
        public Coord min;
        public Multidimensial(IntroducedFunction _y, double _Eps, int _maxIter)
        {
            y = _y;
            amountVar = y.Variables;            
            Eps = _Eps;
            maxIter = _maxIter;
        }
    }
}
