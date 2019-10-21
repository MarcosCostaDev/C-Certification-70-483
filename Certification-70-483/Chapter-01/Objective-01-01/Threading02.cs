using Certification_70_483.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Using a background thread
    class Threading02 : Starting
    {
        public Threading02(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var t = new Thread(new ThreadStart(ThreadMethod));
            //If you run this application with the IsBackground property set to true, the application exits immediately. If you set it to false (creating a foreground thread), the application prints the ThreadProc message ten times.
            t.IsBackground = false;
            t.Start();

        }

       private static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }
    }
}
