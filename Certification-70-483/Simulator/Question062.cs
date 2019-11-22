using Certification_70_483.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification_70_483.Simulator
{
    public class Question062 : Starting
    {

        public Question062(params string[] args) : base(args)
        {
        }
        public override void Start(params string[] args)
        {
            decimal value1 = 1, value2 = 2;
//#if DEBUG
            Log(value1, value2, value1 + 2);
//#endif
        }

        [Conditional("DEBUG")]
        public static void Log(decimal a, decimal b, decimal result)
        {
            Console.WriteLine($"Value 1: {a}, Value 2: {b}, value 3: {result}");
        }
    }
}
