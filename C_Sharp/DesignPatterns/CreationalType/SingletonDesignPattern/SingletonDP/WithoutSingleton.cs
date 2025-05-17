using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDP
{
    internal class WithoutSingleton
    {
        private static int _count = 0;
        
        public WithoutSingleton()
        {
            _count++;
            Console.WriteLine($"Number of times constructor is called: {_count}");
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
