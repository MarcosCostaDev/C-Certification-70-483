using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using a ConcurrentStack
    class Threading32 : Starting
    {
        public Threading32(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var stack = new ConcurrentStack<int>();
            stack.Push(42);

            int result;
            if (stack.TryPop(out result))
            {
                Console.WriteLine($"Popped: {result}");
            }

            stack.PushRange(new[] { 1, 2, 3 });

            var values = new int[2];
            stack.TryPopRange(values);

            foreach (var i in values)
            {
                Console.WriteLine(i);
            }
        }

    }
}
