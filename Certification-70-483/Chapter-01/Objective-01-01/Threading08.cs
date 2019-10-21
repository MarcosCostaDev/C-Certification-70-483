using Certification_70_483.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Starting a new Task
    class Threading08 : Starting
    {

        public Threading08(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            Task t = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine('*');
                }
            });

            t.Wait();
        }


    }
}
