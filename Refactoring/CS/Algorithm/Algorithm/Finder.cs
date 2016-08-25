using System.Collections.Generic;
using System.Linq;

namespace Algorithm {
    public class Finder {
        private readonly List<Person> ListOfPeople;

        public Finder(List<Person> people) {
            ListOfPeople = people;
        }

        public Comparison FindDesiredComparison(string option) {
            var arrangedListOfPeople = ListOfPeople.OrderBy(p => p.BirthDate).ToList();
            return CheckForBestComparison(arrangedListOfPeople, option);
        }

        public Comparison CheckForBestComparison(List<Person> arrangedListOfPeople, string option) {
            var result = new Comparison();
            if (arrangedListOfPeople.Count > 1) {
                result = FinderOption.option[option](arrangedListOfPeople);
            }
            return result;
        }

        public Comparison FindFurthest(List<Person> arrangedListOfPeople) {
            return new Comparison {
                Person1 = arrangedListOfPeople.First(),
                Person2 = arrangedListOfPeople.Last(),
                Difference = arrangedListOfPeople.Last().BirthDate - arrangedListOfPeople.First().BirthDate };
        }

        public Comparison FindClosest(List<Person> arrangedListOfPeople) {
            List<Comparison> comparisons = MakeListOfClosestPeople(arrangedListOfPeople);
            return comparisons.OrderBy(c => c.Difference).First();
        }

        public List<Comparison> MakeListOfClosestPeople(List<Person> arrangedListOfPeople) {
            List<Comparison> comparisons = new List<Comparison>();
            for (int i = 0; i < arrangedListOfPeople.Count - 1; i++) {
                comparisons.Add(MakeComparison(arrangedListOfPeople[i], arrangedListOfPeople[i + 1]));
            }
            return comparisons;
        }

        public Comparison MakeComparison(Person younger, Person older) {
            return new Comparison {
                Person1 = younger,
                Person2 = older,
                Difference = older.BirthDate - younger.BirthDate
            };
        }

    }
}