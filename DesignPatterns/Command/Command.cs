using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    //Command
    abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }

    //Concrete Command
    class CalculatorCommand : Command {
        private char _operator;
        private int _operand;
        private Calculator _calculator;

        public CalculatorCommand(Calculator calculator, char operatorKey, int operand)
        {
            _operand = operand;
            _operator = operatorKey;
            _calculator = calculator;
        }

        public char Operator {
            set { _operator = value; }
        }
        public char Operand
        {
            set { _operand = value; }
        }
        //Execute new command
        public override void Execute()
        {
            _calculator.Operation(_operator, _operand);
        }

        public override void UnExecute()
        {
            _calculator.Operation(Undo(_operator), _operand);
        }
        //Return opposite for operatorkey
        private char Undo(char operatorKey)
        {
            switch (operatorKey)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default: throw new Exception("Not Found");

            }
        }


    }
    //Receiver
    class Calculator {
        private int _curr = 0;
        public void Operation(char operatorKey, int operand) {
            switch (operatorKey)
            {
                case '+': _curr += operand; break;
                case '-': _curr += operand; break;
                case '*': _curr += operand; break;
                case '/': _curr += operand; break;
            }
            Console.WriteLine("Current Value = {0,3} (following {1} {2})", _curr, operatorKey, operand);
        }      
    }

    //Invoker
    class User {
        private Calculator _calculator = new Calculator();
        private List<Command> _commands = new List<Command>();
        private int _current = 0;

        public void Redo(int levels) {
            Console.WriteLine(Environment.NewLine + $"Redo {levels} levels");
            for (int i = 0; i < levels; i++)
            {
                if (_current<_commands.Count -1)
                {
                    var command = _commands[_current++];
                    command.Execute();

                }
            }
        }
        public void Undo(int levels)
        {
            Console.WriteLine(Environment.NewLine + $"Redo {levels} levels");
            for (int i = 0; i < levels; i++)
            {
                if (_current >0)
                {
                    var command = _commands[--_current];
                    command.UnExecute();

                }
            }
        }

        public void Compute(char operatorKey, int operand) {
            //Create commmand and execute
            Command command = new CalculatorCommand(_calculator, operatorKey, operand);
            command.Execute();
            //Add command to undo list
            _commands.Add(command);
            _current++;
        }

    }


}
