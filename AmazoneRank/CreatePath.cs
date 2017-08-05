using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazoneRank
{
    class CreatePath
    {
        public const string PartPath = "https://www.amazon.com/dp/";

        public string Path { get; set; }

        public string ISBN { get; set; }

        
        internal string Create(string ISBNNumder)
        {
            Path = PartPath + ISBNNumder + "/";
            return Path;
        }
    }
}
