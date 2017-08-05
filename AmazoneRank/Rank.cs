using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AmazoneRank
{
    class Rank
    {
        string result = null;
        string patternRank = @"<b>Amazon Best Sellers Rank:<\/b>\s+#(\d+|,)+ in Books";

        string patternFindeRank = @"[^<b>Amazon Best Sellers Rank:<\/b>\s+#]+[^\sin Books]";

        CreatePath cp = new CreatePath();
        string path;
        int i = 0;

        internal string GetRank(string ISBNNumber)
        {
            path = cp.Create(ISBNNumber);
            WebClient wc = new WebClient();
            while (true)
            {
                result = wc.DownloadString(path);
                if (result.Contains($"Amazon Best Sellers Rank"))
                {
                    Console.WriteLine($"ok {i}");
                    i += 1;
                    break;
                }
                else result = null;
            }

            string tmp = findString(patternRank, result);

            string rank = $"\"{findString(patternFindeRank, tmp)}\"";

            return rank;
        }


        private string findString(string pattern, string result)
        {
            Regex findString = new Regex(pattern);
            Match match = findString.Match(result);
            return match.ToString();
        }
    }
}
