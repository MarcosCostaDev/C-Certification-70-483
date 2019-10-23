using Certification_70_483.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Attaching child tasks to a parent task
    class Threading12 : Starting
    {
        public Threading12(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];

                new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();

                return results;

            });

            var finalTask = parent.ContinueWith(parentTask =>
            {
                foreach (var item in parentTask.Result)
                {
                    Console.WriteLine(item);
                }
            });

            finalTask.Wait();
            Console.ReadKey();
        }


    }
}
