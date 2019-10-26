using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static Certification_70_483.Chapter_01.Objective_01_03.Flow72;

namespace Certification_70_483.Chapter_01.Objective_01_03
{
    //goto statement with a label
    class Flow74 : Starting
    {
        public Flow74(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
            var x = 3;
            if (x == 3) goto customLabel;



            customLabel:
            Console.WriteLine(x);

        }


    }
}
