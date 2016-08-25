using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm {
    static public class FinderSearches {
        static public Dictionary<String, Func<List<Person>, Comparison>> option = new Dictionary<String, Func<List<Person>, Comparison>>() {
            {"Closest", (List<Person> ListOfPeople) =>
                { List<Comparison> comparisons = MakeListOfClosestPeople(ListOfPeople);
                return comparisons.OrderBy(c => c.Difference).First(); }
            },

            {"Furthest", (List<Person> ListOfPeople) =>
                { return new Comparison {
                    Person1 = ListOfPeople.First(),
                    Person2 = ListOfPeople.Last(),
                    Difference = ListOfPeople.Last().BirthDate - ListOfPeople.First().BirthDate};}
            }
        };

        static List<Comparison> MakeListOfClosestPeople(List<Person> ListOfPeople) {
            List<Comparison> comparisons = new List<Comparison>();
            for (int i = 0; i < ListOfPeople.Count - 1; i++) {
                comparisons.Add(MakeComparison(ListOfPeople[i], ListOfPeople[i + 1]));
            }
            return comparisons;
        }

        static Comparison MakeComparison(Person younger, Person older) {
            return new Comparison {
                Person1 = younger,
                Person2 = older,
                Difference = older.BirthDate - younger.BirthDate
            };
        }
    }
}
