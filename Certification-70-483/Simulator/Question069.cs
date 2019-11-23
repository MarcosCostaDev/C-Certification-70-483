using Certification_70_483.Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification_70_483.Simulator
{
    public class Question069 : Starting
    {
        public Question069(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var counter = new Counter();
            counter.ProccessDirectory();
           
        }

        class Counter
        {
            private ConcurrentDictionary<string, int> _wordCounts = new ConcurrentDictionary<string, int>();

            public Action<DirectoryInfo> ProccessDirectory()
            {
                return (dirInfo =>
                {
                    var files = dirInfo.GetFiles("*.cs").AsParallel<FileInfo>();
                    files.ForAll<FileInfo>(
                        fileInfo =>
                        {
                            var fileContent = File.ReadAllText(fileInfo.FullName);
                            var sb = new StringBuilder();
                            foreach (var val in fileContent)
                            {
                                sb.Append(char.IsLetter(val) ? val.ToString().ToLowerInvariant() : " ");

                            }
                            var wordsInFile = sb.ToString().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var word in wordsInFile)
                            {
                                _wordCounts.AddOrUpdate(word, 1, (s, n) => n + 1);
                            }

                        });
  
                    
                });
            }
        }
    }
}
