using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class Logger
    {
        /* Lazy<T> provides thread-safe initialization */
        private static Lazy<Logger>? _logger = null;
        private static readonly object _lock = new object();

        private Logger()
        {
            /* Private Constructor to prevent object creation */
        }

        public static Logger GetInstance
        {
            get
            {
                if (_logger is null)
                {
                    _logger = new Lazy<Logger>(() => new Logger());
                }
                return _logger.Value;
            }
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
