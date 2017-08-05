using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazoneRank
{
    class FileCsvMaker
    {
        const string fileName = "Rnak.csv";
        Rank rank = new Rank();
        List<string> patternForCsvFile = new List<string>();
        string[] ISBNMass = { "0394837363", "0394873386", "0062187821", "0743254368", "0743255062", "0743256204",
                              "0345354621", "0345452607", "0873523792", "0743292545", "0385371217", "1591857147" };


        internal void CreatFile()
        {
            var date = DateTime.Now.ToString("MM/dd/yy HH:mmtt", CultureInfo.InvariantCulture);
            date = $"\"{date}\"";
            FileInfo fileInfo = new FileInfo(fileName);

            if (!fileInfo.Exists)
            {
                patternForCsvFile.Add("ISBN");
                patternForCsvFile.AddRange(ISBNMass);
                WriteToFile(patternForCsvFile, fileName);
            }

            else
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        patternForCsvFile.Add(line);
                    }
                }
            }

            for (int i = 0; i < patternForCsvFile.Count; i++)
            {
                if (i == 0)
                {
                    patternForCsvFile[i] += $",{date}";
                }
                else
                    patternForCsvFile[i] += $",{rank.GetRank(ISBNMass[i - 1])}";
            }

            WriteToFile(patternForCsvFile, fileName);
        }

        private void WriteToFile(IEnumerable<string> patternForCsvFile, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (var item in patternForCsvFile)
                {
                    sw.WriteLine(item);
                }
            }
        }
    }
}
