namespace Command
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The 'Invoker' class
    /// </summary>
    internal class User
    {
        private readonly Calculator calculator = new Calculator();
        private readonly List<Command> commands = new List<Command>();
        private int current;

        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);
            for (int i = 0; i < levels; i++)
            {
                if (this.current < this.commands.Count - 1)
                {
                    var command = this.commands[this.current++];
                    command.Execute();
                }
            }
        }

        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);
            for (int i = 0; i < levels; i++)
            {
                if (this.current > 0)
                {
                    var command = this.commands[--this.current];
                    command.UnExecute();
                }
            }
        }

        public void Compute(char @operator, int operand)
        {
            Command command = new CalculatorCommand(this.calculator, @operator, operand);
            command.Execute();

            this.commands.Add(command);
            this.current++;
        }
    }
}
