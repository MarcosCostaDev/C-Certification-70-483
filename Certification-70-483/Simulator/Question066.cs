using Certification_70_483.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification_70_483.Simulator
{
    public class Question066 : Starting
    {
        public Question066(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            /*
             * to get the location the assembly is executing from
             * (not necessarily where the it normally resides on disk)
             * in the case of the using shadow copies, for instance in NUnit tests, 
             * this will be in a temp directory.
             */
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            /* To get the location the assembly normally resides on disk or the install directory */
            //string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            //* once you have the path you get the directory with: */
            var directory = System.IO.Path.GetDirectoryName(path);



            using (var fsSource = File.OpenRead($"{directory}/AppContent/sample.pdf"))
            //  Create a file named header.dat that contains the first 20 bytes of the input file.
            using (var fsHeader = File.OpenWrite($"{directory}/AppContent/header.dat"))
            // Create a file named body.dat that contains the remainder of the input file.
            using (var fsBody = File.OpenWrite($"{directory}/AppContent/body.dat"))
            {
                var header = new byte[20];
                var body = new byte[fsSource.Length - 20];
                fsSource.Read(header, 0, 20);
                fsHeader.Write(header, 0, header.Length);
                fsSource.Read(body, 0, body.Length);
                fsBody.Write(body, 0, body.Length);
            }
        }
    }
}
