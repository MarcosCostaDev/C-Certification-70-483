using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_02
{
    //Creating a deadlock
    class Threading37 : Starting
    {
        //it also causes the threads to block while they are waiting for each other. This can give performance problems and it could even lead to a deadlock, where both threads wait on each other, causing neither to ever complete.
        public Threading37(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
            var lockA = new object();
            var lockB = new object();

            var up = Task.Run(() =>
            {
                lock (lockA)
                {
                    Thread.Sleep(1000);
                    lock (lockB)
                    {
                        Console.WriteLine("Locked A and B");
                    }
                }
            });

            lock(lockB)
            {
                lock (lockA)
                {
                    Console.WriteLine("Locked B and A");
                }
            }

            up.Wait();
        }

    }
}
