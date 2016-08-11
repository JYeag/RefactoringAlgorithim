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

        public Comparison FindDifferences(FinderOption option)
        {
            var comparisons = MakeListOfComparisons();
            
            if (comparisons.Count < 1)
            {
                return new Comparison();
            }

            Comparison result = comparisons[0];
            foreach (var comparison in comparisons)
            {
                switch (option)
                {
                    case FinderOption.Closest:
                        if (comparison.Difference < result.Difference)
                        {
                            result = comparison;
                        }
                        break;

                    case FinderOption.Furthest:
                        if (comparison.Difference > result.Difference)
                        {
                            result = comparison;
                        }
                        break;
                }
            }

            return result;
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
    }
}