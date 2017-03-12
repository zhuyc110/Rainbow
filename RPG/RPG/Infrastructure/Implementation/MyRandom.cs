using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;

namespace RPG.Infrastructure.Implementation
{
    [Export(typeof(IRandom))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MyRandom : IRandom
    {
        [ImportingConstructor]
        public MyRandom()
        {
            _queue = new Queue<int>(10);
        }

        #region IRandom Members

        public int Next()
        {
            return Next(int.MaxValue);
        }

        public int Next(int max)
        {
            return Next(0, max);
        }

        public int Next(int min, int max)
        {
            _random = new Random((int) DateTime.Now.Ticks);
            var result = _random.Next(min, max);

            RecordTheRandom(result);

            return result;
        }

        #endregion

        #region Private methods

        private static void RecordTheRandom(int number)
        {
            if (_queue.Count > 9)
                _queue.Dequeue();
            _queue.Enqueue(number);
        }

        #endregion

        #region Fields

        private static Queue<int> _queue;
        private Random _random;

        #endregion
    }
}