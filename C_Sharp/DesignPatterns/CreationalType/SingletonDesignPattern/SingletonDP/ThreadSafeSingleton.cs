using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDP
{
    public class ThreadSafeSingleton
    {
        private static int _count = 0;

        #region Achieving Thread Safety With Using Lock
        //private static ThreadSafeSingleton _instance = null;

        /// <summary>
        /// Achieving Thread Safety with using lock
        /// </summary>
        //private static readonly object _lockObject = new();

        //public static ThreadSafeSingleton GetThreadSafeInstanceUsingLockObject
        //{
        //    get
        //    {
        //        if (_instance is null)
        //        {
        //            lock (_lockObject)
        //            {
        //                if (_instance is null)
        //                {
        //                    _instance = new ThreadSafeSingleton();
        //                }
        //            } 
        //        }
        //        return _instance;
        //    }
        //}
        #endregion

        #region Achieving Thread Safety using Static Constructor Initialization (Without using lock)
        /// <summary>
        /// Achieving Thread Safety using Static Constructor Initialization (Without using lock)
        /// Static constructors are thread-safe
        /// </summary>
        private static readonly ThreadSafeSingleton _threadSafeInstance = new();

        public static ThreadSafeSingleton GetThreadSafeInstanceUsingStaticConstructor
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
        private ThreadSafeSingleton()
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
