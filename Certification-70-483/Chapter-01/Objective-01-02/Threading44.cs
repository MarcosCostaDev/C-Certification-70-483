using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_02
{
    //Adding a continuation for canceled tasks
    class Threading44 : Starting
    {
        public Threading44(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            CancellationToken token = cancellationTokenSource.Token;

            var task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }

            }, token)
            .ContinueWith((t) => {
                t.Exception.Handle((e) => true);
            }, TaskContinuationOptions.OnlyOnCanceled);

            try
            {
                Console.WriteLine("Press enter to stop the task");
                Console.ReadLine();

                cancellationTokenSource.Cancel();
                task.Wait();
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions[0].Message);
            }
           

            Console.WriteLine("Press enter to end the application");
            Console.ReadLine();

        }


    }
}
