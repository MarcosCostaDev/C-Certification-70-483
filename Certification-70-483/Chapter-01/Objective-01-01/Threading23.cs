using Certification_70_483.Shared;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Unordered parallel query
    class Threading23 : Starting
    {
        public Threading23(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var numbers = Enumerable.Range(0, 10);
            var parallelResult = numbers.AsParallel()
                .Where(i => i % 2 == 0)
                .ToArray();

            foreach (var i in parallelResult)
            {
                Console.WriteLine(i);
            }
        }

    }
}
