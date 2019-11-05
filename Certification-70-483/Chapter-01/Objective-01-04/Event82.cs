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
    //Using an Action to expose an event
    class Event82 : Starting
    {
        public Event82(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
            Pub p = new Pub();
            p.OnChange += () => Console.WriteLine("Event raised to method 1");
            p.OnChange += () => Console.WriteLine("Event raised to method 2");
            p.Raise();
        }

        public class Pub
        {
            public Action OnChange { get; set; }
            public void Raise()
            {
                if (OnChange != null)
                {
                    OnChange();
                }
            }
        }


    }
}
