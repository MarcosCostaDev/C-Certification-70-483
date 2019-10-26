using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_03
{
    //Changing items in a foreach
    class Flow72 : Starting
    {
        public Flow72(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
            var people = new List<Person>
           {
               new Person() { FirstName = "John", LastName = "Doe"},
               new Person() { FirstName = "Jane", LastName = "Doe"},
           };

            foreach (var p in people)
            {
                p.LastName = "Changed"; // This is allowed;
                // p = new Person(); //This gives a compile error
            }
        }


        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

        }

    }
}
