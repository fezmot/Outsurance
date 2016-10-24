using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsurance.Fezile_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Personal\Dev\Github\Outsurance.Fezile_Test\Outsurance.Fezile_Test\csvFile\data.csv";
            var queryResults = CsvDataFunction.ReadCSV(filePath);

            var queryOrderLastName = queryResults.GroupBy(l => l.LastName)
               .OrderByDescending(r => r.Count())
               .Select(r => r.Key + "," + r.Count()).ToList();

            Console.WriteLine("The first should show thefrequency of the first and last names ordered by frequency descending and then alphabetically ascending. ");
            foreach (var itemLastName in queryOrderLastName)
            {
                Console.WriteLine(itemLastName);
            }
            Console.WriteLine("----------------------------------------------------------------------------");


            //Writing to Text file
            CsvDataFunction.WriteToTextFile("queryOrderLastName.txt", queryOrderLastName);

            var queryOrderAddress = queryResults
               .Select(g => new
               {
                   Address = g.Address,
               })
               .OrderBy(r => r.Address.Substring(r.Address.IndexOf(" ", StringComparison.CurrentCulture))).ToList();

            Console.WriteLine("The second should show the addresses sorted alphabetically by street name. ");
            foreach (var itemAddress in queryOrderAddress)
            {
                Console.WriteLine(itemAddress.Address);
            }
            Console.WriteLine("----------------------------------------------------------------------------");

            Console.WriteLine("So ordered by frequency first (descending) and then alphabetically (ascending).");

            var queryOrderFullFirstName = queryResults
              .Select(g => new
              {
                  FirstName = g.FirstName,
                  LastName = g.LastName
              })
              .OrderByDescending(r => r.FirstName).ToList();
            foreach (var itemFirstName in queryOrderFullFirstName)
            {
                Console.WriteLine(itemFirstName.FirstName + " " + itemFirstName.LastName);
            }
            Console.WriteLine("----------------------------------------------------------------------------");

            var queryOrderFirstName = queryResults.GroupBy(l => l.FirstName)
               .OrderByDescending(r => r.Count())
               .Select(r => r.Key + "," + r.Count()).ToList();

            //Writing to Text file
            CsvDataFunction.WriteToTextFile("queryOrderFirstName.txt", queryOrderFirstName);

            Console.WriteLine("The first list should be: Johnson, 2,Brown, 1,Heinrich, 1,Jones, 1,Matt, 1,Smith, 1,Tim, 1,");
            foreach (var itemFirstName in queryOrderFirstName)
            {
                Console.WriteLine(itemFirstName);
            }
            Console.WriteLine("----------------------------------------------------------------------------");

            Console.ReadLine();

        }
    }
}
