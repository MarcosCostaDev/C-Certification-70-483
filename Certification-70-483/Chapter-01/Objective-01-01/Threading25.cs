using Certification_70_483.Shared;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Making a parallel query sequential
    class Threading25 : Starting
    {
        public Threading25(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers
                .AsParallel()
                .AsOrdered()
                .Where(i => i % 2 == 0)
                .AsSequential();

            foreach (var i in parallelResult.Take(3))
            {
                Console.WriteLine(i);
            }
        }

    }
}
