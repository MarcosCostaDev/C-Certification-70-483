﻿using Certification_70_483.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using a TaskFactory
    class Threading13 : Starting
    {
        public Threading13(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];

                var tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                tf.StartNew(() => results[0] = 0);
                tf.StartNew(() => results[1] = 1);
                tf.StartNew(() => results[2] = 2);

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
