using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_02
{
    //Generated code from a lock statement
    class Threading38 : Starting
    {
        public Threading38(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {

            var gate = new object();
            var __lockTaken = false;
            try
            {
                Monitor.Enter(gate, ref __lockTaken);
            }
            finally
            {
                if (__lockTaken)
                    Monitor.Exit(gate);
            }

        }

    }
}
