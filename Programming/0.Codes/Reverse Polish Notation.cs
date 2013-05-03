using System;
using System.Collections.Generic;

static class ListExtensions
{
    public static void Print(this List<string> list)
    {
        Console.WriteLine(String.Join(" ", list));
    }

    public static void Print(this List<Tuple<string, string>> list)
    {
        foreach (var item in list)
            Console.Write(item.Item1 + " ");

        Console.WriteLine();
    }
}

class Program
{
    static Dictionary<string, Tuple<int, bool>> precedence = new Dictionary<string, Tuple<int, bool>>() {
        { "~",
            new Tuple<int, bool>(5 , true)},
        { "pow",
            new Tuple<int, bool>(4 , true)},
        { "^",
            new Tuple<int, bool>(4 , true)},
        { "sqrt",
            new Tuple<int, bool>(4 , false)},
        { "ln",
            new Tuple<int, bool>(4 , false)},
        { "sin",
            new Tuple<int, bool>(4, false)},
        { "cos",
            new Tuple<int, bool>(4, false)},
        { "tan",
            new Tuple<int, bool>(4, false)},
        { "*",
            new Tuple<int, bool>(3 , false)},
        { "/",
            new Tuple<int, bool>(3 , false)},
        { "+",
            new Tuple<int, bool>(2 , false)},
        { "-",
            new Tuple<int, bool>(2 , false)},
        { "(",
            new Tuple<int, bool>(0 , false)},
        { ")",
            new Tuple<int, bool>(999 , false)}
    };

    // Tokenize a string: "(1 + 2) * 3" -> "(", "1", "+", "2", ")", "*", "3"
    static List<Tuple<string, string>> Tokenize(string s)
    {
        var tokens = new List<Tuple<string, string>>(); // Value, type

        Tuple<string, string> previous = null;

        for (int i = 0; i < s.Length; i++)
        {
            string value = String.Empty, type = null;

            // White space
            if (s[i] == ' ') continue;

            // Number: 1, 123, -123
            else if (Char.IsDigit(s[i]))
            {
                type = "number";

                for (; i < s.Length && (Char.IsDigit(s[i]) || s[i] == '.' || s[i] == '-'); i++) value += s[i];
                i--;
            }

            // Function: pow, sqrt, ln, sin, cos, tan
            else if (Char.IsLetter(s[i]))
            {
                type = "function";

                for (; i < s.Length && Char.IsLetter(s[i]); i++) value += s[i];
                i--;
            }

            // Function separator: ,
            else if (s[i] == ',')
            {
                type = "separator";

                value += s[i];
            }

            // Operator: +, -, *, ^, /, (, )
            else
            {
                type = "operator";

                value += s[i];

                if (value == "-" && (previous == null || previous.Item1 == "(" || (previous.Item2 == "operator" && previous.Item1 != ")")))
                    value = "~";
            }

            previous = new Tuple<string, string>(value, type);
            tokens.Add(previous);
        }

        tokens.Print();

        return tokens;
    }

    // Parse an infix expression to postfix: "(", "1", "+", "2", ")", "*", "3" -> "1" "2" "+" "3" "*"
    static List<string> Parse(List<Tuple<string, string>> infix)
    {
        var postfix = new List<string>();
        var operators = new Stack<string>();

        foreach (var token in infix)
        {
            string value = token.Item1, type = token.Item2;

            if (type == "number")
                postfix.Add(value);

            else if (type == "function") operators.Push(value);

            else if (type == "separator")
                while (operators.Peek() != "(") postfix.Add(operators.Pop());

            else if (value == "(")
                operators.Push(value);

            else if (value == ")")
                while ((value = operators.Pop()) != "(")
                    postfix.Add(value); // Match left paren

            else if (type == "operator")
            {
                while (operators.Count != 0)
                {
                    if (precedence[value].Item2 && (precedence[value].Item1 < precedence[operators.Peek()].Item1))
                        postfix.Add(operators.Pop());

                    else if (precedence[value].Item1 <= precedence[operators.Peek()].Item1)
                        postfix.Add(operators.Pop());

                    else break;
                }

                operators.Push(value);
            }
        }

        while (operators.Count != 0)
            postfix.Add(operators.Pop());

        postfix.Print();

        return postfix;
    }

    // Evaluate a postfix expression - "1" "2" "+" "3" "*" -> 9
    static double Evaluate(List<string> postfix)
    {
        var stack = new Stack<double>();

        foreach (var token in postfix)
            if (token == "+") stack.Push(stack.Pop() + stack.Pop());
            else if (token == "-") stack.Push(-stack.Pop() + stack.Pop());
            else if (token == "~") stack.Push(-stack.Pop());
            else if (token == "*") stack.Push(stack.Pop() * stack.Pop());
            else if (token == "/") stack.Push(1 / stack.Pop() * stack.Pop());
            else if (token == "ln") stack.Push(Math.Log(stack.Pop(), Math.E));
            else if (token == "sin") stack.Push(Math.Sin(stack.Pop()));
            else if (token == "cos") stack.Push(Math.Cos(stack.Pop()));
            else if (token == "tan") stack.Push(Math.Tan(stack.Pop()));
            else if (token == "sqrt") stack.Push(Math.Sqrt(stack.Pop()));
            else if (token == "^" || token == "pow") stack.Push(Math.Pow(y: stack.Pop(), x: stack.Pop())); // x ^ y
            else stack.Push(double.Parse(token));

        return stack.Pop();
    }

    static void Calculate(string expression)
    {
        Console.WriteLine(Evaluate(Parse(Tokenize(expression))));

        Console.WriteLine();
    }

    static void Main()
    {
        Calculate("(3 + 5.3) * 2.7 - ln(22) / 2.2 ^ -1.7");
        Calculate("pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5 * 0.3)");
        Calculate("(1 - -1) * pow(pow(1 + 1, pow(ln(2.71), 1 - 1)), 10)");
        Calculate("-(-1 + -2)");
    }
}