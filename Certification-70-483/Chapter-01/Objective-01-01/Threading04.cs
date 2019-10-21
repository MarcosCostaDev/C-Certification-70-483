using Certification_70_483.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Stopping a thread
    class Threading04 : Starting
    {
        public Threading04(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var stopped = false;

            var t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));

            t.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            stopped = true;

            t.Join();
        }


    }
}
