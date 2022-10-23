using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lesson7
{
    public class Homework : MonoBehaviour
    {
        private sealed class Person
        {
            public string Name { get; }
            public int Age { get; }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }

        private List<Person> people = new List<Person>
        {
            new Person ("Alice", 31),
            new Person ("Bob", 42),
            new Person ("Charlie", 25),
            new Person ("Dave", 31),
            new Person ("Eve", 42),
            new Person ("Mallory", 31),
            new Person ("Trudy", 32)
        };

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Task 2"); // =======================================================================
            string text = "1234qwer!$%@"; // 12 sybols here
            var result = text.CountSymbols();
            Debug.Log($"there are {result} symblos in a string");


            Debug.Log("Task 3"); // =======================================================================
            // first I wanted to sort, find where age of person changes and simply nake ++ to counter
            var sortedPersons = from p in people
                                orderby p.Age
                                select p;

            // but then I found out, that there are groups, so I decided to make groups of people with same age, works fine
            var groups = from pep in sortedPersons
                         group pep by pep.Age;
            foreach (IGrouping<int, Person> g in groups)
            {
                Debug.Log(g.Key);
                foreach (var t in g)
                {
                    Debug.Log(t.Name);
                }
            }


            Debug.Log("Task 4"); // =======================================================================
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                { "two",2 },
                { "one",1 },
                { "three",3 },
            };
            //var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            var d = dict.OrderBy(pair => pair.Value);
            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
        }
    }
}
