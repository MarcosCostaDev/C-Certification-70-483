using Certification_70_483.Shared;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Catching AggregateException
    class Threading27 : Starting
    {
        public Threading27(params string[] args) : base(args)
        {
        }

        //In contrast to foreach, ForAll does not need all results before it starts executing. In this example, ForAll does, however, remove any sort order that is specified.
        public override void Start(params string[] args)
        {
            var numbers = Enumerable.Range(0, 20);

            try
            {
                var parallelResult = numbers.AsParallel().Where(i => IsEven(i));

                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine($"There where {e.InnerExceptions.Count} exceptions");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private bool IsEven(int i)
        {
            if (i % 10 == 0) throw new AggregateException("i");

            return i % 2 == 0;
        }
    }
}
