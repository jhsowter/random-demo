using System;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static int peopleCount = 3;
        static int repeat = 2000;
        static Random random = new Random();

        // an array of people
        static string[] people = new string[peopleCount];

        // a count of how many times that person was randomly selected
        static int[] selectionCount = new int[peopleCount];
        
        static void Main(string[] args)
        {
            // initialise the array
            people = people.Select((person, i) => "Person " + i).ToArray();

            // randomly select a person, repeat. 
            for (var i = 0; i < repeat; i++)
            {
                var x = random.Next(0, peopleCount);
                selectionCount[x]++;
                Console.WriteLine(people[x]);
            }

            Console.WriteLine("----");
            Console.WriteLine("Summary:");

            // write the results of the counts
            for (var i = 0; i < peopleCount; i++)
            {
                Console.WriteLine(people[i] + " was selected " + selectionCount[i] + " times.");
            }

            Console.ReadLine();
        }
    }
}
