using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsurance.Fezile_Test
{
    public class CsvDataFunction
    {
        public static void WriteToTextFile(string file, List<string> fileData)
        {
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                foreach (string s in fileData)
                {
                    sw.WriteLine(s);
                }
            }
        }

        public static List<EntityPersonDetail> ReadCSV(string filePath)
        {
            return File.ReadLines(filePath)
                .Skip(1)
                .Where(s => s != null)
                .Select(s => s.Split(new[] { ',' }))
                .Select(a => new EntityPersonDetail
                {
                    FirstName = a[0],
                    LastName = a[1],
                    Address = a[2],
                    PhoneNumber = a[3]
                }).ToList();
        }
    }
}
