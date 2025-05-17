using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDP
{
    public class ThreadSafetySingleton
    {
        private static int _count = 0;
        private static ThreadSafetySingleton _instance = null;

        #region Achieving Thread Safety With Using Lock
        /// <summary>
        /// Achieving Thread Safety with using lock
        /// </summary>
        private static readonly object _lockObject = new();

        public static ThreadSafetySingleton GetThreadSafeInstanceUsingLockObject
        {
            get
            {
                lock (_lockObject)
                {
                    if (_instance is null)
                    {
                        _instance = new ThreadSafetySingleton();
                    }
                }
                return _instance;
            }
        }
        #endregion

        #region Achieving Thread Safety using Static Constructor Initialization (Without using lock)
        /// <summary>
        /// Achieving Thread Safety using Static Constructor Initialization (Without using lock)
        /// Static constructors are thread-safe
        /// </summary>
        private static readonly ThreadSafetySingleton _threadSafeInstance = new(); 


        public static ThreadSafetySingleton GetThreadSafeInstanceUsingStaticConstructor
        {
            get
            {
                return _threadSafeInstance;
            }
        }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        private ThreadSafetySingleton()
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
