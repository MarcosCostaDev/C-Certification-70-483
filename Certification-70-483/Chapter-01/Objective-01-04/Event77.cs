﻿using Certification_70_483.Shared;
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
    //shows an example of covariance
    class Event77 : Starting
    {
        public delegate TextWriter CovarianceDel();
        public StreamWriter MethodStream() { return null; }
        public StringWriter MethodString() { return null; }
        
        public Event77(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
            CovarianceDel del;
            del = MethodStream;
            del = MethodString;
        }


    }
}
