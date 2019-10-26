using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_02
{
    //Using the Interlocked class
    class Threading40 : Starting
    {
        //Interlocked guarantees that the increment and decrement operations are executed atomically. No other thread will see any intermediate results. Of course, adding and subtracting is a simple operation. If you have more complex operations, you would still have to use a lock.
        public Threading40(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
            // IncrementAndDecrement();
            Exchange();
        }

        private void IncrementAndDecrement()
        {
            var n = 0;

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Interlocked.Increment(ref n);
                }
            });

            for (int i = 0; i < 1000000; i++)
                Interlocked.Decrement(ref n);

            up.Wait();
            Console.WriteLine(n);
        }

        //This code retrieves the current value and immediately sets it to the new value in the same operation. It returns the previous value before changing it.
        private void Exchange()
        {
            var isInUse = 0;
            if (Interlocked.Exchange(ref isInUse, 1) == 0) {
                Console.WriteLine(isInUse);
            }
        }

    }
}
