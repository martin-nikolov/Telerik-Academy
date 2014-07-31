namespace Command
{
    using System;

    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>
    internal class CalculatorCommand : Command
    {
        private readonly Calculator calculator;
        private char @operator;
        private int operand;

        public CalculatorCommand(Calculator calculator, char @operator, int operand)
        {
            this.calculator = calculator;
            this.@operator = @operator;
            this.operand = operand;
        }

        public char Operator
        {
            set { this.@operator = value; }
        }

        public int Operand
        {
            set { this.operand = value; }
        }

        public override void Execute()
        {
            this.calculator.Operation(this.@operator, this.operand);
        }

        public override void UnExecute()
        {
            this.calculator.Operation(Undo(this.@operator), this.operand);
        }

        private static char Undo(char operatorToUndo)
        {
            switch (operatorToUndo)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default: throw new ArgumentException("@operator");
            }
        }
    }
}
