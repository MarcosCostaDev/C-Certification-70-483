using Certification_70_483.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Certification_70_483.Chapter_01.Objective_01_01
{
    //async and await
    class Threading18 : Starting
    {
        public Threading18(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var result = DownloadContent().Result;
            Console.WriteLine(result);

            Console.ReadKey();
        }

        private async Task<string> DownloadContent()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }
    }
}
