namespace Interpreter
{
    /// <summary>
    /// A 'TerminalExpression' class
    /// <remarks>
    /// Thousand checks for the Roman Numeral M 
    /// </remarks>
    /// </summary>
    internal class ThousandExpression : Expression
    {
        public override string One()
        {
            return "M";
        }

        public override string Four()
        {
            return " ";
        }

        public override string Five()
        {
            return " ";
        }

        public override string Nine()
        {
            return " ";
        }

        public override int Multiplier()
        {
            return 1000;
        }
    }
}
