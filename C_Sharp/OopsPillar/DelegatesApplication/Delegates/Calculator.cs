using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate int ArithmeticDelegate(int firstNumber, int secondNumber);

    public class Calculator
    {
        private ArithmeticDelegate _arithmeticDelegate = null;
        private static ArithmeticProcess _arithmeticProcess = null;

        public Calculator()
        {
            _arithmeticProcess = new ArithmeticProcess();
        }

        public void Add(int firstNumber, int secondNumber)
        {
            _arithmeticDelegate = new ArithmeticDelegate(_arithmeticProcess.Addition);
            Console.WriteLine($"Addition Result: {_arithmeticDelegate.Invoke(firstNumber, secondNumber)}");
        }

        public void Sub(int firstNumber, int secondNumber)
        {
            _arithmeticDelegate = new ArithmeticDelegate(_arithmeticProcess.Subtraction);
            Console.WriteLine($"Subtraction Result: {_arithmeticDelegate.Invoke(firstNumber, secondNumber)}");
        }

        public void Mult(int firstNumber, int secondNumber)
        {
            _arithmeticDelegate = new ArithmeticDelegate(_arithmeticProcess.Multiplication);
            Console.WriteLine($"Multiplication Result: {_arithmeticDelegate.Invoke(firstNumber, secondNumber)}");
        }
    }
}
