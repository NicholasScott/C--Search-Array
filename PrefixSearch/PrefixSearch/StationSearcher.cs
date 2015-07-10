using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixSearch
{
    class StationSearcher
    {
        string[] stationList;

        public StationSearcher(string[] stationList)
        {
            this.stationList = stationList;
        }
        public HashSet<string> validNextCharacters(List<string> matchedStrings, string prefix)
        {
            //Use Hashset to ensure no duplicate next characters.
            HashSet<string> validCharacterList = new HashSet<string>();
            foreach (string s in matchedStrings)
            {
                //Check the length of the matches vs the prefix to rule out complete matches from the set of valid next characters (avoids index out of bounds errors)
                if (s.Length > prefix.Length)
                {
                    validCharacterList.Add("" + s[prefix.Length]);
                }
            }
            return validCharacterList;
        }

        public List<string> stationsMatchingPrefix(string prefix)
        {
            List<string> matches = new List<string>();

            foreach (string s in stationList)
            {
                //convert strings to upper case for ease of matching, can be removed if input is guaranteed to be upper case which would improve performance slightly.
                //Ordinal is used as it is faster than alternative startswith arguments.
                if (s.ToUpper().StartsWith(prefix.ToUpper(), StringComparison.Ordinal))
                {
                    matches.Add(s);
                }
            }
            return matches;
        }
    }
}
