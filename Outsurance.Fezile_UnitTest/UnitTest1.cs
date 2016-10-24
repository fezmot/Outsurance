using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Outsurance.Fezile_Test;
using System.Linq;
using System.Collections.Generic;

namespace Outsurance.Fezile_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LastNameFrequency()
        {

            string filePath = @"C:\Personal\Dev\Github\Outsurance.Fezile_Test\Outsurance.Fezile_Test\csvFile\data.csv";
            var queryResults = CsvDataFunction.ReadCSV(filePath);

            var query = queryResults.GroupBy(l => l.LastName)
               .OrderByDescending(r => r.Count())
               .Select(r => r.Key + "," + r.Count()).ToList();

            List<string> listLastName = new List<string>() { "Smith,2", "Owen,2", "Brown,2", "Howe,2" };
            CollectionAssert.AreEqual(query, listLastName);
        }

        [TestMethod]
        public void SortedAlphabeticallyByStreetName()
        {

            string filePath = @"C:\Personal\Dev\Github\Outsurance.Fezile_Test\Outsurance.Fezile_Test\csvFile\data.csv";
            var queryResults = CsvDataFunction.ReadCSV(filePath);
            var queryOrderAddress = queryResults
             .Select(g => new
             {
                 g.Address,
             })
             .OrderBy(r => r.Address.Substring(r.Address.IndexOf(" ", StringComparison.CurrentCulture))).Select(r => r.Address).ToList();

            var listExpectedAddress = new List<string>() { "65 Ambling Way", "8 Crimson Rd", "12 Howard St", "102 Long Lane", "94 Roland St", "78 Short Lane",
            "82 Stewart St","49 Sutherland St"};
            CollectionAssert.AreEqual(listExpectedAddress, queryOrderAddress);
        }

        [TestMethod]
        public void FirstNameFrequency()
        {
            string filePath = @"C:\Personal\Dev\Github\Outsurance.Fezile_Test\Outsurance.Fezile_Test\csvFile\data.csv";
            var queryResults = CsvDataFunction.ReadCSV(filePath);

            var query = queryResults.GroupBy(l => l.FirstName)
               .OrderByDescending(r => r.Count())
               .Select(r => r.Key + "," + r.Count()).ToList();

            List<string> listLastName = new List<string>() { "Clive,2", "James,2", "Graham,2", "Jimmy,1", "John,1" };
            CollectionAssert.AreEqual(query, listLastName);
        }
    }
}
