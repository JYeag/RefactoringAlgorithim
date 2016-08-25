using System;
using System.Collections.Generic;

namespace Algorithm
{
    static public class FinderOption {
        static public Dictionary<String, Func<List<Person>, Comparison>> option = new Dictionary<String, Func<List<Person>, Comparison>>() {
            {"Closest", (List<Person> input) =>
            { return new Comparison(); }
            },
            {"Furthest", (List<Person> input) =>
            { return new Comparison(); }
            }
        };
    }
}
