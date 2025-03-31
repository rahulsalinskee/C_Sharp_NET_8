using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class ArithmeticProcess
    {
        public int Addition(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public int Subtraction(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public int Multiplication(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}
