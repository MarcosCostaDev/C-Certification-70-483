using Certification_70_483.Shared;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using Task.Wait Any
    class Threading15 : Starting
    {
        public Threading15(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var tasks = new Task<int>[3];
            tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(1000); return 3; });
            while (tasks.Length > 0)
            {
                var i = Task.WaitAny(tasks);
                var completedTask = tasks[i];

                Console.WriteLine(completedTask.Result);

                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();

            }
            Console.ReadKey();
        }


    }
}
