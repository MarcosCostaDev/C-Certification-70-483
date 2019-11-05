using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static Certification_70_483.Chapter_01.Objective_01_03.Flow72;

namespace Certification_70_483.Chapter_01.Objective_01_04
{
    //Custom event arguments
    class Event84 : Starting
    {
        public Event84(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
            CreateAndRaise();
        }

        public class MyArgs : EventArgs
        {
            public MyArgs(int value)
            {
                Value = value;
            }
            public int Value { get; set; }
        }
        public class Pub
        {
            public event EventHandler<MyArgs> OnChange = delegate { };
            public void Raise()
            {
                OnChange(this, new MyArgs(42));
            }
        }
        public void CreateAndRaise()
        {
            Pub p = new Pub();
            p.OnChange += (sender, e)
            =>
            {
                Console.WriteLine("Event raised: {0}", e.Value);
                Console.WriteLine("object sender: {0}", sender.GetType().FullName);
            };
            p.Raise();
        }


    }
}
