using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace All
{
    public partial class Form1 : Form
    {
        //Масивы текстовых полей для ввода координат и названий
        TextBox[] t = new TextBox[10];
        Label[] l = new Label[10];
        //Введённая функция
        IntroducedFunction func;
        //Номер и название метода
        int indexMethod;
        string selectedMethod;
        public Form1()
        {
            InitializeComponent();
        }
        //Событие загрузки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            //Вывод примеров функций и методов на экран в списки
            Examples ex = new Examples(FunctionComboBox, ChangeMethodComboBox);
            //Скрыть текстовые поля и названия координат
            t[0] = textBox1;
            t[1] = textBox2;
            t[2] = textBox3;
            t[3] = textBox4;
            t[4] = textBox5;
            t[5] = textBox6;
            t[6] = textBox7;
            t[7] = textBox8;
            t[8] = textBox9;
            t[9] = textBox10;
            
            foreach (TextBox te in t)
                te.Hide();

            l[0] = label1;
            l[1] = label2;
            l[2] = label3;
            l[3] = label4;
            l[4] = label5;
            l[5] = label6;
            l[6] = label7;
            l[7] = label8;
            l[8] = label9;
            l[9] = label10;
            foreach (Label la in l)
                la.Hide();
            //Скрытие полей для ввода
            EpsLabel.Visible = false;
            EpsTextBox.Visible = false;
            ChangeMethodLabel.Visible = false;
            ChangeMethodComboBox.Visible = false;
            CoordinatesLabel.Visible = false;
            minTextBox.ReadOnly = true;
            mLabel.Visible = false;
            mTextBox.Visible = false;
            IterationsTextBox.ReadOnly = true;
            
        }
        //Событие при нажатии на кнопку рассчитать минимум
        private void button2_Click(object sender, EventArgs e)
        {
            bool c = true;            
            try
            {
                int m = Convert.ToInt32(mTextBox.Text);
                double[] coordinates = new double[func.Variables];
                for (int i = 0; i < func.Variables; i++)
                {
                    coordinates[i] = Convert.ToDouble(t[i].Text);
                }
                Coord x0 = new Coord(coordinates);
                double Eps = Convert.ToDouble(EpsTextBox.Text);
                
                indexMethod = ChangeMethodComboBox.SelectedIndex;
                List<string> Methods = Examples.Methods;
                //Запуск выбранного метода           
                if (selectedMethod == Methods[0])
                {
                    GradientMethod f = new GradientMethod(func, x0, Eps, m);
                    IterationsTextBox.Text = f.GaussZeidel().ToString();
                    Coord min = f.min;
                    min.output(minTextBox, func.Variables);
                }
                if (selectedMethod == Methods[1])
                {
                    ConjugatedGrad f = new ConjugatedGrad(func, x0, Eps, m);
                    IterationsTextBox.Text = f.PolakRibierMethod().ToString();
                    Coord min = f.min;
                    min.output(minTextBox, func.Variables);
                }
                if (selectedMethod == Methods[2])
                {
                    ConjugatedGrad f = new ConjugatedGrad(func, x0, Eps, m);
                    IterationsTextBox.Text = f.FletcherReevesMethod().ToString();
                    Coord min = f.min;
                    min.output(minTextBox, func.Variables);
                }
                if (selectedMethod == Methods[3])
                {
                    VariableMetric f = new VariableMetric(func, x0, Eps, m);
                    IterationsTextBox.Text = f.BroidenFletcherShennoMethod().ToString();
                    Coord min = f.min;
                    min.output(minTextBox, func.Variables);
                }
                if (selectedMethod == Methods[4])
                {
                    NewtonMod f = new NewtonMod(func, x0, Eps, m);
                    
                    IterationsTextBox.Text = f.NewtonWithAdjustingStep().ToString();
                    if((IterationsTextBox.Text == "-1"))
                        MessageBox.Show("Невозможно найти обратную матрицу");
                    else
                    {
                        Coord min = f.min;
                        min.output(minTextBox, func.Variables);
                    }                    
                }
                if (selectedMethod == Methods[5])
                {
                    UnconditionalOptimization f = new UnconditionalOptimization(func, x0, Eps, m);

                    IterationsTextBox.Text = f.HookeJeeves().ToString();
                    Coord min = f.min;
                    min.output(minTextBox, func.Variables);
                }
            }
            //Ошибки
            catch
            {
                foreach (TextBox te in t)
                    if (te.Text == "" && te.Visible == true)
                        c = false;
                if (EpsTextBox.Text == "")
                    MessageBox.Show("Не введена точность");
                if (mTextBox.Text == "")
                    MessageBox.Show("Не введено максимальное количество итераций");
                if (ChangeMethodComboBox.Text == "")
                    MessageBox.Show("Не выбран метод оптимизации");
                if (!c)
                    MessageBox.Show("Не все координаты введены");
                else
                    MessageBox.Show(""); 
            }                
        }
        //Событие при нажатии на кнопку ввести функцию
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (TextBox te in t)
            {
                te.Hide();
                te.Text = "";
            }
            foreach (Label la in l)
            {
                la.Hide();
            }

            minTextBox.Text = "";
            IterationsTextBox.Text = "";

            EpsLabel.Visible = true;
            EpsTextBox.Visible = true;

            ChangeMethodLabel.Visible = true;
            ChangeMethodComboBox.Visible = true;
            ChangeMethodComboBox.Text = "";
            mLabel.Visible = true;
            mTextBox.Visible = true;
            CoordinatesLabel.Visible = true;
            func = new IntroducedFunction(FunctionComboBox.Text);            
            if (func.IsRightFunction())
            {

                func.CountVariables();
                func.Postfix();
                for (int i = 0; i < func.Variables; i++)
                {
                    t[i].Visible = true;
                    l[i].Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Неправильная функция");
            }
        }       
        //Запрет на ввод недопустимых данных
        private void EpsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '0':
                case '-':
                case ',':
                case 'e':
                case (char)Keys.Back:
                case (char)Keys.Delete:
                    e.Handled = false;
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }
        private void mTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '0':
                case (char)Keys.Back:
                case (char)Keys.Delete:
                    e.Handled = false;
                    break;
                default:
                    e.Handled = true;
                    break;
            }
            if (mTextBox.Text.Length >= 3)
                if(e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
        }
        private void FunctionComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '0':
                case '(':
                case ')':
                case '-':
                case '+':
                case '*':
                case '/':
                case '^':
                case ',':
                case 'e':
                case 'x':
                case 'p':
                case 's':
                case 'i':
                case 'n':
                case 'c':
                case 'o':
                case 'l':
                case (char)Keys.Back:
                case (char)Keys.Delete:
                    e.Handled = false;
                    break;
                default:
                    e.Handled = true;
                    break;
            }            
        }
        private void ChangeMethodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedMethod = ChangeMethodComboBox.Text;
        }
        
    }
}
