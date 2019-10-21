using Certification_70_483.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using the ParameterizedThreadStart
    class Threading03 : Starting
    {
        public Threading03(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(5);
            t.Join();

        }

        private static void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
    }
}
