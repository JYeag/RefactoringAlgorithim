using System.Collections.Generic;
using System.Linq;

namespace Algorithm {
    public class Finder {
        private readonly List<Person> ListOfPeople;

        public Finder(List<Person> people) {
            ListOfPeople = people.OrderBy(p => p.BirthDate).ToList();
        }

        public Comparison FindDesiredComparison(string option) {
            return CheckForBestComparison(ListOfPeople, option);
        }

        public Comparison CheckForBestComparison(List<Person> ListOfPeople, string option) {
            var result = new Comparison();
            if (ListOfPeople.Count > 1) {
                result = FinderSearches.option[option](ListOfPeople);
            }
            return result;
        }
    }
}