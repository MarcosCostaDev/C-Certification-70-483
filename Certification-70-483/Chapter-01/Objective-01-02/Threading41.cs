using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_02
{
    //Compare and exchange as a nonatomic operation
    class Threading41 : Starting
    {
        static int value = 1;
        public Threading41(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
            // Test01();
            Test02();
        }

        //Task t1 starts running and sees that value is equal to 1. At the same time, t2 changes the value to 3 and then t1 changes it back to 2.
        void Test01()
        {

            var t1 = Task.Run(() =>
            {
                if (value == 1)
                {
                    // Removing the following line will change the output
                    Thread.Sleep(1000);
                    value = 2;
                }
            });

            var t2 = Task.Run(() =>
            {
                value = 3;
            });

            Task.WaitAll(t1, t2);
            Console.WriteLine(value); //Display 2
        }
        //To avoid this, you can use the following Interlocked statement
        void Test02()
        {

            var t1 = Task.Run(() =>
            {

                Interlocked.CompareExchange(ref value, 2, 1);
            });

            var t2 = Task.Run(() =>
            {
                value = 3;
            });

            Task.WaitAll(t1, t2);
            Console.WriteLine(value); //Display 2
        }
    }
}
