using System.Collections.Generic;
using System.Linq;

namespace Algorithm {
    public class Finder {
        private readonly List<Person> ListOfPeople;

        public Finder(List<Person> people) {
            ListOfPeople = people;
        }

        public Comparison FindDesiredComparison(FinderOption option) {
            var comparisons = MakeListOfComparisons();
            return CheckForBestComparison(comparisons, option);
        }


        public List<Comparison> MakeListOfComparisons() {
            var listOfComparisons = new List<Comparison>();
            for (var i = 0; i < ListOfPeople.Count - 1; i++) {
                for (var j = i + 1; j < ListOfPeople.Count; j++) {
                    var currentComparison = new Comparison();
                    if (ListOfPeople[i].BirthDate < ListOfPeople[j].BirthDate) {
                        currentComparison.Person1 = ListOfPeople[i];
                        currentComparison.Person2 = ListOfPeople[j];
                    }
                    else {
                        currentComparison.Person1 = ListOfPeople[j];
                        currentComparison.Person2 = ListOfPeople[i];
                    }
                    currentComparison.Difference = currentComparison.Person2.BirthDate - currentComparison.Person1.BirthDate;
                    listOfComparisons.Add(currentComparison);
                }
            }
            return listOfComparisons;
        }

        public Comparison CheckForBestComparison(List<Comparison> comparisons, FinderOption option) {
            var result = new Comparison();
            if (comparisons.Count > 0) {
                result = comparisons[0];

                switch (option) {
                    case FinderOption.Closest:
                        result = FindClosest(comparisons);
                        break;

                    case FinderOption.Furthest:
                        result = FindFurthest(comparisons);
                        break;
                }
            }
            return result;
        }

        public Comparison FindFurthest(List<Comparison> comparisons) {
            return comparisons.OrderByDescending(c => c.Difference)
                .First();
        }

        public Comparison FindClosest(List<Comparison> comparisons) {
            return comparisons.OrderBy(c => c.Difference)
                .First();
        }
    }
}