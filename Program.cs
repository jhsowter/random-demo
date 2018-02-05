using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static int peopleCount = 3;
        static int repeat = 200;
        static Random random = new Random();

        // an array of people
        static string[] people = new string[peopleCount];

        // a count of how many times that person was randomly selected
        static int[] selectionCount = new int[peopleCount];

        // count the longest streaks
        static Dictionary<string, int> streaks = new Dictionary<string, int>();
        
        static void Main(string[] args)
        {
            // initialise the array
            people = people.Select((person, i) => "Person " + i).ToArray();

            // initialise the streaks recording
            streaks = people.ToDictionary(p => p, p => 0);

            var streakCount = 0;
            var previousPerson = "";

            // randomly select a person, repeat. 
            for (var i = 0; i < repeat; i++)
            {
                // select the random next person
                var personIndex = random.Next(0, peopleCount);
                selectionCount[personIndex]++;

                // check if they are on a streak
                if(previousPerson != people[personIndex])
                {
                    streakCount = 0;
                }

                // record their longest streak
                streakCount++;
                streaks["Person " + personIndex] = Math.Max(streaks["Person " + personIndex], streakCount);

                // track the 
                previousPerson = people[personIndex];

                Console.WriteLine(people[personIndex]);
            }

            Console.WriteLine("----");
            Console.WriteLine("Summary:");

            // write the results of the counts
            for (var i = 0; i < peopleCount; i++)
            {
                Console.WriteLine(people[i] + " was selected " + selectionCount[i] + " times.");
            }

            // write the results of the streaks
            foreach(var key in streaks.Keys)
            {
                Console.WriteLine(key + ": " + streaks[key] + " in a row!");
            }

            Console.ReadLine();
        }
    }
}
