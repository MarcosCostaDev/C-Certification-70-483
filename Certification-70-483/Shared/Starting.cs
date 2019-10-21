using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification_70_483.Shared
{
    public abstract class Starting : IStarting
    {
        public Starting(params string[] args)
        {
            Start(args);
        }

        public abstract void Start(params string[] args);
    }
}
