using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using a ConcurrentBag
    class Threading30 : Starting
    {
        public Threading30(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var bag = new ConcurrentBag<int>();
            bag.Add(42);
            bag.Add(21);

            int result;
            if (bag.TryTake(out result))
            {
                Console.WriteLine(result);
            }

            if(bag.TryPeek(out result))
            {
                Console.WriteLine($"There is a next item: {result}");
            }
        }

    }
}
