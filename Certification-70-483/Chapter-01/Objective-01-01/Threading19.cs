using Certification_70_483.Shared;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //Scalability versus responsiveness
    class Threading19 : Starting
    {
        public Threading19(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            
        }

        //The SleepAsyncA method uses a thread from the thread pool while sleeping. The sec-ond method, however, which has a completely different implementation, does not occupy a thread while waiting for the timer to run. The second method gives you scalability.
        private Task SleepAsyncA(int millisecondsTimeout)
        {
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }

        private Task SleepAsyncB(int millisecondsTimeout)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1);
            return tcs.Task;

        }
    }
}
