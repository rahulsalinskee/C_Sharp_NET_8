using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDP
{
    public class LazyLoadingSingleton
    {
        private static int _count = 0;

        private static readonly Lazy<LazyLoadingSingleton> _instance = new(() => new LazyLoadingSingleton());

        public static LazyLoadingSingleton GetLazyLoadingSingletonInstance 
        { 
            get
            {
                return _instance.Value;
            }
        }

        private LazyLoadingSingleton()
        {
            _count++;
            Console.WriteLine($"Number of times constructor is called: {_count}");
        }

        public void LazyLoadingDisplayName(string name)
        {
            Console.WriteLine(name);
        }
    }
}
