using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PrefixSearch
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //unit tests are run when the form is closed (you can also test it manually using the form)
            //All stations used in the tests are stored in one string array
            string[] testStations = { "DARTFORD", "DARTMOUTH", "TOWERHILL", "DERBY", "LIVERPOOL","PADDINGTON","LIVERPOOL LIME STREET", "EUSTON", "LONDON BRIDGE", "VICTORIA"};
            
            StationSearcher searcher = new StationSearcher(testStations);
            List<string> expected = new List<string>{"DARTFORD","DARTMOUTH"};
            HashSet<string> expected2 = new HashSet<string> {"F","M"};
            string searchTerm1 = "DART";
            CollectionAssert.AreEquivalent(expected,searcher.stationsMatchingPrefix(searchTerm1));
            CollectionAssert.AreEquivalent(expected2.ToArray(),searcher.validNextCharacters(searcher.stationsMatchingPrefix(searchTerm1), searchTerm1).ToArray());

            List<string> expected3 = new List<string> {"LIVERPOOL", "LIVERPOOL LIME STREET"};
            HashSet<string> expected4 = new HashSet<string> {" "};
            string searchTerm2 = "LIVERPOOL";
            CollectionAssert.AreEquivalent(expected3, searcher.stationsMatchingPrefix(searchTerm2));
            CollectionAssert.AreEquivalent(expected4.ToArray(), searcher.validNextCharacters(searcher.stationsMatchingPrefix(searchTerm2), searchTerm2).ToArray());

            List<string> expected5 = new List<string> {};
            HashSet<string> expected6 = new HashSet<string> {};
            string searchTerm3 = "KINGS CROSS";
            CollectionAssert.AreEquivalent(expected5, searcher.stationsMatchingPrefix(searchTerm3));
            CollectionAssert.AreEquivalent(expected6.ToArray(), searcher.validNextCharacters(searcher.stationsMatchingPrefix(searchTerm3), searchTerm3).ToArray());

        }
    }
}
