using Certification_70_483.Shared;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using ForAll
    class Threading26 : Starting
    {
        public Threading26(params string[] args) : base(args)
        {
        }

        //In contrast to foreach, ForAll does not need all results before it starts executing. In this example, ForAll does, however, remove any sort order that is specified.
        public override void Start(params string[] args)
        {
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers
                .AsParallel()
                .Where(i => i % 2 == 0);

            parallelResult.ForAll(e => Console.WriteLine(e));
        }

    }
}
