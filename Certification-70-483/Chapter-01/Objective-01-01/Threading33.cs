using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using a ConcurrentQueue.
    class Threading33 : Starting
    {
        public Threading33(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var queue = new ConcurrentQueue<int>();
            queue.Enqueue(42);

            int result;
            if (queue.TryDequeue(out result))
            {
                Console.WriteLine($"Dequeued: {result}");
            }

        }

    }
}
