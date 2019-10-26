using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_02
{
    //A potential problem with multithreaded code
    class Threading39 : Starting
    {
        //You can use locking to fix this, but there is also another class in the .NET Framework that you can use: System.Threading.Volatile. This class has a special Write and Read method, and those methods disable the compiler optimizations so you can force the correct order in your code. Using these methods in the correct order can be quite complex, so .NET offers the volatile keyword that you can apply to a field.
        private static volatile int _flag = 0;
        //private static int _flag = 0;

        private static int _value = 0;

        public void Thread1()
        {
            _value = 5;
            _flag = 1;

        }

        public void Thread2()
        {
            if(_flag == 1)
                Console.WriteLine(_value);
        }

        public Threading39(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
            var t = new Thread(new ThreadStart(Thread1));
            t.Start();

            Thread2();

            t.Join();
        }

    }
}
