using Certification_70_483.Shared;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using Parallel.Break
    class Threading17 : Starting
    {
        //You can cancel the loop by using the ParallelLoopState object. You have two options to do this: Break or Stop. Break ensures that all iterations that are currently running will be finished. Stop just terminates everything.
        public Threading17(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var result = Parallel.For(0, 1000, (int i, ParallelLoopState loopState) =>
            {
                //When breaking the parallel loop, the result variable has an IsCompleted value of false and a LowestBreakIteration of 500. When you use the Stop method, the LowestBreakIteration is null.
                if (i == 500)
                {
                    Console.WriteLine("Breaking Loop");
                    loopState.Break();
                }

                return;
            });

            Console.ReadKey();
        }
    }
}
