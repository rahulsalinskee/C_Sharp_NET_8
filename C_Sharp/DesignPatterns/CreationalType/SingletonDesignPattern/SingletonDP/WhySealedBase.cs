using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDP
{
    public class WhySealedBase
    {
        private static int _count = 0;
        private static WhySealedBase _instance = null;

        public WhySealedBase GetInstance 
        { 
            get
            {
                if (_instance is null)
                {
                    _instance = new WhySealedBase(); 
                }

                return _instance;
            } 
        }

        private WhySealedBase()
        {
            _count++;
            Console.WriteLine($"Number of times constructor is called: {_count}");
        }

        public void DisplayClassName(string className)
        {
            Console.WriteLine(className);
        }

        public class WhySealedChild : WhySealedBase
        {
           
        }
    }
}
