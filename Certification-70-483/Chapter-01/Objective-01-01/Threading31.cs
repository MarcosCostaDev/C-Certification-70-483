using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Enumerating a ConcurrentBag
    class Threading31 : Starting
    {
        public Threading31(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var bag = new ConcurrentBag<int>();

            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });

            Task.Run(() =>
            {
                foreach (var i in bag)
                {
                    Console.WriteLine(i);
                }
            }).Wait();
        }

    }
}
