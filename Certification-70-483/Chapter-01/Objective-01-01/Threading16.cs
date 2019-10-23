using Certification_70_483.Shared;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using Parallel.For and Parallel.Foreach
    class Threading16 : Starting
    {
        public Threading16(params string[] args) : base(args)
        {
        }

        //Parallelism involves taking a certain task and splitting it into a set of related tasks that can be executed concurrently. This also means that you shouldn’t go through your code to re-place all your loops with parallel loops. You should use the Parallel class only when your code doesn’t have to be executed sequentially. 
        //Increasing performance with parallel processing happens only when you have a lot of work to be done that can be executed in parallel. For smaller work sets or for work that has to synchronize access to resources, using the Parallel class can hurt performance.
        public override void Start(params string[] args)
        {
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
            });

            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
            });
        }


    }
}
