using Certification_70_483.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using a Task that returns a value.
    class Threading09 : Starting
    {
        public Threading09(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });

            Console.WriteLine(t.Result);
            Console.ReadKey();
        }


    }
}
