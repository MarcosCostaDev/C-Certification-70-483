using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static Certification_70_483.Chapter_01.Objective_01_03.Flow72;

namespace Certification_70_483.Chapter_01.Objective_01_04
{
    //A multicast delegate
    class Event76 : Starting
    {
        public void MethodOne()
        {
            Console.WriteLine("MethodOne");
        }
        public void MethodTwo()
        {
            Console.WriteLine("MethodTwo");
        }

       
        public delegate void Del();

        public void Multicast()
        {
            Del d = MethodOne;
            d += MethodTwo;

            int invocationCount = d.GetInvocationList().GetLength(0);

            Console.WriteLine($"There are {invocationCount} methods in multicast delegate");
            d();
        }

        public Event76(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
            Multicast();
        }


    }
}
