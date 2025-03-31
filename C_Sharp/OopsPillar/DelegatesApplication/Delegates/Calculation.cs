using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Calculation
    {
        private static Calculator _calculator = new();
        
        public void DisplayResult()
        {
            _calculator.Add(firstNumber: 5, secondNumber: 2);
            _calculator.Sub(firstNumber: 5, secondNumber: 2);
            _calculator.Mult(firstNumber: 5, secondNumber: 2);
        }
    }
}
