using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AmazoneRank
{
    class Program
    {
        static void Main(string[] args)
        {
            FileCsvMaker fileMake = new FileCsvMaker();
            fileMake.CreatFile();
            Console.Write("ok");
        }        
    }
}
