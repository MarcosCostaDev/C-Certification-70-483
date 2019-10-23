using Certification_70_483.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Queuing some work to the thread pool
    class Threading07 : Starting
    {
        public Threading07(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });

            Console.ReadLine();
        }
    }

    class Threading07_01 : Starting
    {
        public Threading07_01(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            // Queue the task.
            ThreadPool.QueueUserWorkItem(ThreadProc);
            Console.WriteLine("Main thread does some work, then sleeps.");
            Thread.Sleep(1000);

            Console.WriteLine("Main thread exits.");

            Console.ReadKey();
        }  // This thread procedure performs the task.
        static void ThreadProc(Object stateInfo)
        {
            // No state object was passed to QueueUserWorkItem, so stateInfo is null.
            Console.WriteLine("Hello from the thread pool.");
        }
    }
    // The example displays output like the following:
    //       Main thread does some work, then sleeps.
    //       Hello from the thread pool.
    //       Main thread exits.
}
