using Certification_70_483.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using a ThreadStaticAttribute
    class Threading05 : Starting
    {
        //With the ThreadStaticAttribute applied, the maximum value of _field becomes 10. If you remove it, you can see that both threads access the same value and it becomes 20.
        [ThreadStatic]
        public static int _field;
        public Threading05(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread B: {0}", _field);
                }
            }).Start();

            Console.ReadKey();
        }


    }
}
