using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindWord
{
    public class FindWordSolver
    {
        public async Task<FindWordResult> OnFile(string path, string find)
        {
            FindWordResult result = new FindWordResult { Path = path  };

            string content = File.ReadAllText(result.Path);
            result.Count = FindOnContent(content, find);

            return result;
        }

        public async Task<List<FindWordResult>> OnDirectory(string path, string find)
        {
            List<FindWordResult> result = new List<FindWordResult>();

            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string content = File.ReadAllText(file);
                int count = FindOnContent(content, find);
                if(count > 0)
                {
                    result.Add(new FindWordResult { Path = file, Count = count });
                }
            }

            return result;
        }

        private int FindOnContent(string content, string find)
        {
            return Regex.Matches(content, find).Count;
        }
    }
    public class FindWordResult
    {
        public int Count { get; set; } = 0;
        public string Path { get; set; } = null;
    }
}
