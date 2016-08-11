using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> ListOfPeople;

        public Finder(List<Person> people)
        {
            ListOfPeople = people;
        }

        public Comparison FindDesiredComparison(FinderOption option)
        {
            var comparisons = MakeListOfComparisons();
            return CheckForBestComparison(comparisons, option);
        }


        public List<Comparison> MakeListOfComparisons()
        {
            var listOfComparisons = new List<Comparison>();
            for (var i = 0; i < ListOfPeople.Count - 1; i++)
            {
                for (var j = i + 1; j < ListOfPeople.Count; j++)
                {
                    var currentComparison = new Comparison();
                    if (ListOfPeople[i].BirthDate < ListOfPeople[j].BirthDate)
                    {
                        currentComparison.Person1 = ListOfPeople[i];
                        currentComparison.Person2 = ListOfPeople[j];
                    }
                    else
                    {
                        currentComparison.Person1 = ListOfPeople[j];
                        currentComparison.Person2 = ListOfPeople[i];
                    }
                    currentComparison.Difference = currentComparison.Person2.BirthDate - currentComparison.Person1.BirthDate;
                    listOfComparisons.Add(currentComparison);
                }
            }
            return listOfComparisons;
        }

        public Comparison CheckForBestComparison(List<Comparison> comparisons, FinderOption option)
        {
            var result = new Comparison();
            if (comparisons.Count > 0)
            {
                result = comparisons[0];
                if (comparisons.Count > 1)
                {
                    switch (option)
                    {
                        case FinderOption.Closest:
                            foreach (var comparison in comparisons)
                            {
                                if (comparison.Difference < result.Difference)
                                {
                                    result = comparison;
                                }
                            }
                            break;

                        case FinderOption.Furthest:
                            foreach (var comparison in comparisons)
                            {
                                if (comparison.Difference > result.Difference)
                                {
                                    result = comparison;
                                }
                            }
                            break;

                    }
                }
            }
            return result;
        }
    }
}