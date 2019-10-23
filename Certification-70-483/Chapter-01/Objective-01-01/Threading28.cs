using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using BlockingCollection<T>
    class Threading28 : Starting
    {
        public Threading28(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var col = new BlockingCollection<string>();
            var read = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(col.Take());
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
