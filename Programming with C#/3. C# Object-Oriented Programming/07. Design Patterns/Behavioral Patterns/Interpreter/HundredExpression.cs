namespace Interpreter
{
    /// <summary>
    /// A 'TerminalExpression' class
    /// <remarks>
    /// Hundred checks C, CD, D or CM
    /// </remarks>
    /// </summary>
    internal class HundredExpression : Expression
    {
        public override string One()
        {
            return "C";
        }

        public override string Four()
        {
            return "CD";
        }

        public override string Five()
        {
            return "D";
        }

        public override string Nine()
        {
            return "CM";
        }

        public override int Multiplier()
        {
            return 100;
        }
    }
}