using Certification_70_483.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using Task.WaitAll
    class Threading14 : Starting
    {
        //you can use the method WaitAll to wait for multiple Tasks to finish before continuing execution. 
        public Threading14(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var tasks = new Task[3];
            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });

            Task.WaitAll(tasks);
            Console.ReadKey();
        }


    }
}
