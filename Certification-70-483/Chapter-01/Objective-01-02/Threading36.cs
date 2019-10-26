using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_02
{
    //Using the lock keyword
    class Threading36 : Starting
    {
        //It’s important to synchronize access to shared data. One feature the C# language offers is the lock operator, which is some syntactic sugar that the compiler translates in a call to System.Thread.Monitor.
        public Threading36(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
            int n = 0;
            object _lock = new object();

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000 ; i++)
                {
                    lock(_lock)
                    {
                        n++;
                    }                  
                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                lock (_lock)
                {
                    n--;
                }
            }

            up.Wait();
            Console.WriteLine(n);
        }

    }
}
