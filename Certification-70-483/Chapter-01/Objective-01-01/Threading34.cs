using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using a ConcurrentDictionary
    class Threading34 : Starting
    {
        public Threading34(params string[] args) : base(args)
        {
        }
        // When working with a ConcurrentDictionary you have methods that can atomically add, get, and update items. An atomic operation means that it will be started and finished as a single step without other threads interfering. TryUpdate checks to see whether the current value is equal to the existing value before updating it. AddOrUpdate makes sure an item is added if it’s not there, and updated to a new value if it is. GetOrAdd gets the current value of an item if it’s available; if not, it adds the new value by using a factory method.

        public override void Start(params string[] args)
        {
            var dict = new ConcurrentDictionary<string, int>();
            if (dict.TryAdd("k1", 42))
            {
                Console.WriteLine("Added");
            }

            if(dict.TryUpdate("k1", 41, 42))
            {
                Console.WriteLine("42 updated to 21");
            }

            dict["k1"] = 42;

            var r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
            var r2 = dict.GetOrAdd("k2", 3);
        }

    }
}
