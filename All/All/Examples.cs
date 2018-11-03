using System.Collections.Generic;
using System.Windows.Forms;

namespace All
{
    class Examples
    {
        List<string> exampleFunc = new List<string>();
        public static List<string> Methods = new List<string>();
        void create()
        {
            exampleFunc.Add("100*(x2-x1^2)^2+(1-x1)^2");
            exampleFunc.Add("(x1-1)^2+(x2-3)^2+4*(x3+5)^2");
            exampleFunc.Add("8*x1^2+4*x1*x2+5*x2^2");
            exampleFunc.Add("4*(x1-5)^2+(x2-6)^2");
            exampleFunc.Add("(x2-x1^2)^2+(1-x1)^2");
            exampleFunc.Add("(x2-x1^2)^2+100*(1-x1^2)^2");
            exampleFunc.Add("3*(x1-4)^2+5*(x2+3)^2+7*(2*x3+1)^2");
            exampleFunc.Add("x1^3+x2^2-3*x1-2*x2+2");
            exampleFunc.Add("4*x1^2+4*x2^2-4*x1*x2-12*x2");
            exampleFunc.Add("(x1-2)^4+(x1-2*x2)^2");
            exampleFunc.Add("(x1*x2*x3-1)^2+5*(x3*(x1+x2)-2)^2+2*(x1+x2+x3-3)^2");
            exampleFunc.Add("4*x1^2+3*x2^2-4*x1*x2^2+x1");
            exampleFunc.Add("(x1^2+x2-11)^2+(x1+x2^2-7)^2");
            exampleFunc.Add("100*(x2-x1^3)^2+(1-x1)^2");
            exampleFunc.Add("(1,5-x1*(1-x2))^2+(2,25-x1*(1-x2^2))^2+(2,625-x1*(1-x2^3))^2");
            exampleFunc.Add("(x1+10*x2)^2+5*(x3-x4)^2+(x2-2*x3)^4+10*(x1-x4)^4");
            exampleFunc.Add("100*(x2-x1^2)^2+(1-x1)^2+90*(x4-x3^2)^2+(1-x3)^3+10,1*((x2-1)^2+(x4-1)^2)+19,8*(x2-1)*(x4-1)");
            exampleFunc.Add("(2*x1^2+3*x2^2)*exp(x1^2-x2^2)");
            exampleFunc.Add("0,1*(12+x1^2+(1+x2^2)/x1^2+(x1^2*x2^2+100)/(x1^4*x2^4))");
            exampleFunc.Add("100*(x3-0,25*(x1+x2)^2)^2+(1-x1)^2+(1-x2)^2");
            Methods.Add("Метод Гаусса-Зейделя");
            Methods.Add("Метод Полака-Рибьера");
            Methods.Add("Метод Флетчера-Ривза");
            Methods.Add("Метод Бройдена-Флетчера-Шенно");
            Methods.Add("Метод Ньютона с регулировкой шага");
            Methods.Add("Метод Хука-Дживса");
        }
        void print(ComboBox box, ComboBox m)
        {
            box.DataSource = exampleFunc;
            m.DataSource = Methods;
        }
        public Examples(ComboBox box, ComboBox m)
        {
            create();
            print(box, m);
        }
    }
}
