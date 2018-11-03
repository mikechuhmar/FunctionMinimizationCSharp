using System;
using System.Collections.Generic;
using System.Linq;

namespace All
{
    class IntroducedFunction: Part
    {
        //Части выражения
        public Part[] parts;
        //Количество переменных
        int variables;
        public int Variables
        {
            get
            {
                return variables;
            }
        }
        //Конструктор
        public IntroducedFunction(string s)
        {
            parts = SplitIntoPieces(s).ToArray<Part>();
        }
        //Список частей
        public List<Part> SplitIntoPieces(string expression)
        {
            string term = "";
            List<Part> parts = new List<Part>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (IsSign(expression[i]))
                {
                    //if (expression[i] != ' ')
                    term = Convert.ToString(expression[i]);
                }
                else
                {
                    int j;
                    for (j = i; j < expression.Length && !IsSign(expression[j]); j++) ;
                    term = expression.Substring(i, j - i);
                    i = j - 1;
                }
                parts.Add(new Part(term));
            }
            return parts;
        }
        public bool IsRightFunction()
        {
            TypeOfPart current = parts[0].ttype;
            int am_brackets = 0;
            if ((current == TypeOfPart.closeBracket) && (parts[0].Term != "-"))
                return false;
            if (current == TypeOfPart.openBracket)
                am_brackets++;
            int[] u = new int[56];
            for (int i = 1; i < parts.Length; i++)
            {
                switch (parts[i].ttype)
                {
                    case TypeOfPart.number:
                    case TypeOfPart.variable:
                    case TypeOfPart.function:
                        if (current == TypeOfPart.openBracket || current == TypeOfPart.operation)
                            current = parts[i].ttype;
                        else
                            return false;
                        break;
                    case TypeOfPart.operation:
                        if (current == TypeOfPart.variable || current == TypeOfPart.number || current == TypeOfPart.closeBracket)
                            current = parts[i].ttype;
                        else
                            return false;
                        break;
                    case TypeOfPart.openBracket:
                        am_brackets++;
                        if (current == TypeOfPart.operation || current == TypeOfPart.function || current == TypeOfPart.openBracket)
                            current = parts[i].ttype;
                        else
                            return false;
                        break;
                    case TypeOfPart.closeBracket:
                        am_brackets--;
                        if (current == TypeOfPart.number || current == TypeOfPart.variable || current == TypeOfPart.closeBracket)
                            current = parts[i].ttype;
                        else
                            return false;
                        break;
                }
            }
            if (am_brackets != 0)
                return false;
            if (current == TypeOfPart.operation || current == TypeOfPart.function || current == TypeOfPart.openBracket)
                return false;
            return true;
        }
        //Приоритет различных операций
        public short priority(string s)
        {
            short proirity = 0;
            switch (s)
            {
                case "+": proirity = 1; break;
                case "-": proirity = 1; break;
                case "*": proirity = 2; break;
                case "/": proirity = 2; break;
                case "cos": proirity = 3; break;
                case "sin": proirity = 3; break;
                case "tg": proirity = 3; break;
                case "ctg": proirity = 3; break;
                case "ln": proirity = 3; break;
                case "^": proirity = 3; break;
                case "exp": proirity = 3; break;                    
            }
            return proirity;
        }
        //Подсчёт количества пременных
        public void CountVariables()
        {
            variables = 0;
            List<string> early = new List<string>();
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].ttype == TypeOfPart.variable && !early.Contains(parts[i].Term))

                {
                    early.Add(parts[i].Term);
                    variables++;
                }
            }
        }
        //Постфиксная запись 
        public void Postfix()
        {
            List<Part> result = new List<Part>();
            Stack<Part> stack = new Stack<Part>();
            Part current;

            foreach (Part p in parts)
            {
                switch (p.ttype)
                {
                    case TypeOfPart.number:
                    case TypeOfPart.variable:
                        result.Add(p);
                        break;
                    case TypeOfPart.openBracket:
                        stack.Push(p);
                        break;
                    case TypeOfPart.closeBracket:
                        while ((current = stack.Pop()).ttype != TypeOfPart.openBracket)
                        {
                            result.Add(current);
                        }
                        break;
                    case TypeOfPart.operation:
                    case TypeOfPart.function:
                        if (stack.Count > 0)
                        {
                            current = stack.Peek();
                            while (stack.Count > 0 && current.ttype != TypeOfPart.openBracket && priority(p.Term) <= priority(current.Term))
                            {
                                result.Add(stack.Pop());
                                if (stack.Count > 0)
                                    current = stack.Peek();
                            }
                        }
                        stack.Push(p);
                        break;
                }
            }
            while (stack.Count > 0)
                result.Add(stack.Pop());

            parts = result.ToArray<Part>();
        }
        //Результат функции
        public double Answer(Coord x)
        {
            Stack<double> stack = new Stack<double>();
            int index;
            double first = 0;
            double second = 0;
            bool minus = false;

            foreach (Part p in parts)
            {
                switch (p.ttype)
                {
                    case TypeOfPart.number:
                        stack.Push(Convert.ToDouble(p.Term));
                        break;
                    case TypeOfPart.variable:
                        index = Convert.ToInt32(p.Term.Remove(0, 1));
                        stack.Push(x.coord[index - 1]);
                        break;
                    case TypeOfPart.operation:
                        first = stack.Pop();
                        if (stack.Count == 0 && p.Term == "-")
                            minus = true;
                        else
                            second = stack.Pop();

                        switch (p.Term)
                        {
                            case "+":
                                stack.Push(second + first);
                                break;
                            case "-":
                                if (minus)
                                    stack.Push(-first);
                                else
                                    stack.Push(second - first);
                                break;
                            case "*":
                                stack.Push(second * first);
                                break;
                            case "/":
                                stack.Push(second / first);
                                break;
                            case "^":
                                stack.Push(Math.Pow(second, first));
                                break;
                        }
                        break;
                    case TypeOfPart.function:
                        first = stack.Pop();
                        switch (p.Term)
                        {
                            case "sin":
                                stack.Push(Math.Sin(first));
                                break;
                            case "cos":
                                stack.Push(Math.Cos(first));
                                break;
                            case "tg":
                                stack.Push(Math.Tan(first));
                                break;
                            case "ctg":

                                stack.Push(1 / Math.Tan(first));
                                break;
                            case "ln":
                                stack.Push(Math.Log(first));
                                break;
                            case "exp":
                                stack.Push(Math.Exp(first));
                                break;
                        }
                        break;
                }
            }

            return stack.Pop();
        }
        
    }
}
