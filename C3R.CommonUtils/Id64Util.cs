using System;
using System.Threading;

namespace C3R.CommonUtils
{
    public static class Id64Util
    {
        private static object _gate = new object();
        private static long _current, _counter;
        private const long CounterMask = 0x01FFFFFFL;  // 25 bits

        static Id64Util()
        {
            _current = ComposeCurrent();
            _counter = -1;
        }

        /// <summary>
        /// Get new unique Id
        /// </summary>
        /// <returns></returns>
        public static long NewId()
        {
            lock (_gate)
            {
                var current = ComposeCurrent();

                if (current > _current)
                {
                    _current = current;
                    _counter = -1;
                }

                Interlocked.Increment(ref _counter);
                _counter &= CounterMask;

                return _current + _counter;
            }
        }
        
        /// <summary>
        /// Create a ID-base from current time
        /// </summary>
        /// <returns></returns>
        private static long ComposeCurrent()
        {
            var result = 0L;
            result |= (long)DateTime.UtcNow.Year << 51;
            result |= (long)DateTime.UtcNow.Month << 47;
            result |= (long)DateTime.UtcNow.Day << 42;
            result |= (long)DateTime.UtcNow.Hour << 37;
            result |= (long)DateTime.UtcNow.Minute << 31;
            result |= (long)DateTime.UtcNow.Second << 25;
            return result;
        }        
    }
}

