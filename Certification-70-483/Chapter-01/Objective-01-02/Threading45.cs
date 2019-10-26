using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_02
{
    //Setting a timeout on a task
    class Threading45 : Starting
    {
        public Threading45(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
            var longRunning = Task.Run(() =>
            {
                Thread.Sleep(100000);
            });

            int index = Task.WaitAny(new[] { longRunning }, 1000);

            if (index == -1)
                Console.WriteLine("Task timed out");
        }


    }
}
