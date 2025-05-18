using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDP
{
    /// <summary>
    /// This is also known as Static Constructor Initialization
    /// </summary>
    public class EagerLoadingSingleton
    {
        private static int _count = 0;

        private static readonly EagerLoadingSingleton _instance = new();

        public static EagerLoadingSingleton GetEagerLoadingSingletonInstance 
        { 
            get
            {
                return _instance;
            }
        }

        private EagerLoadingSingleton()
        {
            _count++;
            Console.WriteLine($"Number of times constructor is called: {_count}");
        }

        public void DisplayEagerLoadingName(string name)
        {
            Console.WriteLine(name);
        }
    }
}
