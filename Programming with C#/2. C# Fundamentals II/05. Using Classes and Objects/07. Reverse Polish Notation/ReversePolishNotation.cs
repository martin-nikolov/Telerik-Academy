using System;
using System.Linq;
using System.Collections.Generic;

namespace RPN
{
    // REVERSE POLISH NOTATION (Contains 30 unit tests)
    //
    // THIS PROGRAM WORKS FOR:
    // - integers
    // - floating-points numbers
    // - positive numbers
    // - negative numbers
    //
    // If you want the program to works correctly, separate the operators with spaces...
    // For example -> Incorrect: (9-3*4) is equal to (9 -3*4) -> the program does not know that '-' is Operator (subtraction) or Indicator for negative number
    //                Correct: (9 - 3 * 4) == (9 - 3*4) or (9 + -3 * 4) == (9- 3*4) => -3

    public class ReversePolishNotation
    {
        static List<char> operators = new List<char>() { '+', '-', '*', '/' };
        static List<char> functions = new List<char>() { 'p', '^', 's', 'l', 'n', 'c', 't' };

        static void Main()
        {
            Calculate(Console.ReadLine());

            //Calculate("(3 + 5.3) * 2.7 - ln(22) / 2.2 ^ -1.7");
            //Calculate("pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5 * 0.3)");
            //Calculate("(1 - -1) * pow(pow(1 + 1, pow(ln(2.71), 1 - 1)), 10)");
            //Calculate("-(-1 + -2)");
        }

        static void Calculate(string expression)
        {
            Console.WriteLine(expression);
            Console.WriteLine(Tokenize(expression));
            Console.WriteLine(Parse(Tokenize(expression)) + "\n");
        }

        public static string Tokenize(string expression)
        {
            Stack<char> st = new Stack<char>();
            string result = string.Empty;

            expression = RenameFunctionNames(expression);

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == ' ') continue;

                if (char.IsDigit(expression[i]) || (expression[i] == '-' && char.IsDigit(expression[i + 1])))
                {
                    if (char.IsDigit(expression[i + 1]) || expression[i + 1] == '.' || expression[i + 1] == ' ')
                    {
                        while (i < expression.Length && expression[i] != ' ' && (char.IsDigit(expression[i]) || expression[i] == '.' || expression[i] == '-'))
                            result += expression[i++];
                        i--;
                    }
                    else result += expression[i];

                    if (!char.IsDigit(expression[i])) result = result + expression[i] + ' ';
                    else result += ' ';
                }
                else if (operators.Contains(expression[i]) || functions.Contains(expression[i]))
                {
                    if (st.Count > 0)
                    {
                        int on1 = op(expression[i]);
                        int on2 = op(st.Peek());

                        if (on1 > on2)
                        {
                            st.Push(expression[i]);
                        }
                        else
                        {
                            while (on1 <= on2 && st.Count > 0)
                            {
                                result = result + st.Peek() + ' ';
                                st.Pop();

                                if (st.Count > 0)
                                {
                                    on1 = op(expression[i]);
                                    on2 = op(st.Peek());
                                }
                            }

                            st.Push(expression[i]);
                        }
                    }
                    else
                    {
                        st.Push(expression[i]);
                    }
                }
                else if (expression[i] == '(') st.Push(expression[i]);
                else if (expression[i] == ')' || expression[i] == ',')
                {
                    bool comma = expression[i] == ',';

                    while (st.Peek() != '(' && st.Count > 0)
                    {
                        result = result + st.Peek() + ' ';
                        st.Pop();

                        if (st.Count == 0)
                        {
                            Console.WriteLine("Incorrect expression!");
                            return string.Empty;
                        }
                    }

                    if (!comma) st.Pop();

                    if (st.Count > 0 && !comma && (st.Peek() == 'p' || st.Peek() == 's' || st.Peek() == 'l')) result = result + st.Pop() + " ";
                }
            }

            while (st.Count > 0)
            {
                if (st.Peek() == '(')
                {
                    Console.WriteLine("Incorrect expression!");
                    return string.Empty;
                }

                result = result + ' ' + st.Peek();
                st.Pop();
            }

            return result.Replace("  ", " ");
        }

        public static string Parse(string result)
        {
            Stack<double> resh = new Stack<double>();
            string con = string.Empty;

            for (int i = 0; i < result.Length; i++)
            {
                if (char.IsDigit(result[i]) || (i + 1 < result.Length && result[i] == '-' && char.IsDigit(result[i + 1])))
                {
                    while (i < result.Length && result[i] != ' ' && (char.IsDigit(result[i]) || result[i] != '.' || result[i] != '-'))
                    {
                        i++;
                        con += result[i - 1];
                    }

                    i--;
                }
                else
                {
                    if (result[i] == ' ')
                    {
                        if (con.Length > 0)
                        {
                            double currentResult = 0;
                            if (!double.TryParse(con, out currentResult)) return "Incorrect expression!";

                            resh.Push(currentResult);
                        }

                        con = string.Empty;
                    }
                    else
                    {
                        if (resh.Count >= 1)
                        {
                            double on1 = 0;
                            double on2 = resh.Pop();

                            if (!"slnct".Contains(result[i]) && resh.Count > 0) on1 = resh.Pop();

                            if (result[i] == '+') resh.Push(on1 + on2); // x + y
                            else if (result[i] == '-') resh.Push(on1 - on2); // x - y
                            else if (result[i] == '*') resh.Push(on1 * on2); // x * y
                            else if (result[i] == '/') resh.Push(on1 / on2); // x / y
                            else if (result[i] == '^' || result[i] == 'p') resh.Push(Math.Pow(on1, on2)); // pow(x, y) or x ^ y
                            else if (result[i] == 's') resh.Push(Math.Sqrt(on2)); // Sqrt(x)
                            else if (result[i] == 'l') resh.Push(Math.Log(on2, Math.E)); // ln(x)
                            else if (result[i] == 'n') resh.Push(Math.Sin(on2)); // Sin(x)
                            else if (result[i] == 'c') resh.Push(Math.Cos(on2)); // Cos(x)
                            else if (result[i] == 't') resh.Push(Math.Tan(on2)); // Tg(x)
                            else
                            {
                                resh.Push(on1);
                                resh.Push(on2);
                            }
                        }
                    }
                }
            }

            if (resh.Count > 1) return "Incorrect expression!";
            else return resh.Peek().ToString();
        }

        static string RenameFunctionNames(string expression)
        {
            string exp = string.Empty;

            for (int i = 0; i < expression.Length; i++)
                if (char.IsUpper(expression[i])) exp += char.ToLower(expression[i]);
                else exp += expression[i];

            exp += " ";

            exp = exp.Replace("pow", "p");
            exp = exp.Replace("sqrt", "s");
            exp = exp.Replace("ln", "l");
            exp = exp.Replace("sin", "n");
            exp = exp.Replace("cos", "c");
            exp = exp.Replace("tan", "t");
            exp = exp.Replace("tg", "t");
            exp = exp.Replace("  ", " ");
            return exp;
        }

        static int op(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-': return 1;
                case '*':
                case '/': return 3;
                case '^':
                case 'p':
                case 's':           // sqrt(x)
                case 'n':           // sin(x)
                case 'c':           // cos(x)
                case 't':           // tan(x)
                case 'l': return 4; // ln(x)
                default: return 0;
            }
        }
    }
}
