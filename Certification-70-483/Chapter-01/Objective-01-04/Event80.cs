using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static Certification_70_483.Chapter_01.Objective_01_03.Flow72;

namespace Certification_70_483.Chapter_01.Objective_01_04
{
    //Creating a lambda expression with multiple statements
    class Event80 : Starting
    {
        public delegate int Calculate(int x, int y);
        public Event80(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
            Calculate calc = (x, y) =>
            {
                Console.WriteLine("Adding numbers");
                return x + y;
            };
            int result = calc(3, 4);
            // Displays
            // Adding numbers
        }


    }
}
