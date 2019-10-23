using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using GetConsumingEnumerable on a BlockingCollection
    class Threading29 : Starting
    {
        public Threading29(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var col = new BlockingCollection<string>();
            var read = Task.Run(() =>
            {
                foreach (var v in col.GetConsumingEnumerable())
                {
                    Console.WriteLine(v);
                }
            });

            var write = Task.Run(() =>
            {
                while (true)
                {
                    var s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });

            write.Wait();
        }


    }
}
