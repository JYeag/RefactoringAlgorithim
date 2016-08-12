using System.Collections.Generic;
using System.Linq;

namespace Algorithm {
    public class Finder {
        private readonly List<Person> ListOfPeople;

        public Finder(List<Person> people) {
            ListOfPeople = people;
        }

        public Comparison FindDesiredComparison(FinderOption option) {
            var arrangedListOfPeople = ArrangeListOfPeopleByBirthdate();
            return CheckForBestComparison(arrangedListOfPeople, option);
        }


        public List<Person> ArrangeListOfPeopleByBirthdate() {
            return ListOfPeople.OrderBy(p => p.BirthDate).ToList();
        }

        public Comparison CheckForBestComparison(List<Person> arrangedListOfPeople, FinderOption option) {
            var result = new Comparison();
            if (arrangedListOfPeople.Count > 1) {
                switch (option) {
                    case FinderOption.Closest:
                        result = FindClosest(arrangedListOfPeople);
                        break;

                    case FinderOption.Furthest:
                        result = FindFurthest(arrangedListOfPeople);
                        break;
                }
            }
            return result;
        }

        public Comparison FindFurthest(List<Person> arrangedListOfPeople) {

            return new Comparison { Person1 = arrangedListOfPeople[0], Person2 = arrangedListOfPeople[arrangedListOfPeople.Count - 1], Difference = arrangedListOfPeople[arrangedListOfPeople.Count - 1].BirthDate - arrangedListOfPeople[0].BirthDate };
        }

        public Comparison FindClosest(List<Person> arrangedListOfPeople) {
            List<Comparison> comparisons = new List<Comparison>();
            for (int i = 0; i < arrangedListOfPeople.Count - 1; i++) {
                comparisons.Add(new Comparison {
                    Person1 = arrangedListOfPeople[i],
                    Person2 = arrangedListOfPeople[i + 1],
                    Difference = arrangedListOfPeople[i + 1].BirthDate - arrangedListOfPeople[i].BirthDate
                });
            }
            return comparisons.OrderBy(c => c.Difference)
                .First();
        }


    }
}