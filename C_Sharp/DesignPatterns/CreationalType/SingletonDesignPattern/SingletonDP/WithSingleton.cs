using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDP
{
    public sealed class WithSingleton
    {
        private static int _count = 0;

        private static WithSingleton _instance = null;

        public static WithSingleton GetInstance 
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new WithSingleton(); 
                }
                return _instance;
            } 
        }

        private WithSingleton()
        {
            _count++;
            Console.WriteLine($"Number of times constructor is called: {_count}");
        }

        public void DisplayName(string name)
        {
            Console.WriteLine(name);
        }
    }
}
