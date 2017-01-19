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
        private static Queue<int> _queue;
        private Random _random;

        [ImportingConstructor]
        public MyRandom()
        {
            _queue = new Queue<int>(10);
        }

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
            _random = new Random((int)DateTime.Now.Ticks);
            var result = _random.Next(min, max + 1);

            RecordTheRandom(result);

            return result;
        }

        private static void RecordTheRandom(int number)
        {
            if (_queue.Count > 9)
                _queue.Dequeue();
            _queue.Enqueue(number);
        }
    }
}