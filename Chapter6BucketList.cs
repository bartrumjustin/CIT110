using System.Data.Common;
using System.Globalization;
using System.Threading.Tasks.Dataflow;
using System;

namespace Chapter6BucketList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> placesToVisit = new List<string> { "Japan", "France", "Germany", "Norway" };
            string[] additionals;
            string deletions = "";
            int userChoice = 0;
            while(userChoice != 4) {
                Console.WriteLine("Welcome, please choose from the following:\n" +
                "********************\n" +
                "[1] Print the current list...\n" +
                "**********\n" +
                "[2] Add to the listing...\n" +
                "**********\n" +
                "[3] Delete an entry from the list...\n" +
                "**********\n" +
                "[4] Quit the program\n" +
                "********************");
                userChoice = int.Parse(Console.ReadLine());
                if (userChoice == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Good Bye");
                    Console.ReadKey();
                }
                switch (userChoice)
                {
                    case 1:
                        Console.Clear();
                        PrintList(placesToVisit);
                        break;
                    case 2:
                        Console.Clear();
                        additionals = AddEntries();
                        placesToVisit.AddRange(additionals);
                        break;
                    case 3:
                        Console.Clear();
                        DeleteEntries(placesToVisit);
                        break;
                       
                }
            }
            static void PrintList(List<string> placesToVisit)
            {
                
                placesToVisit.Sort();
                
                foreach (string s in placesToVisit)
                    Console.WriteLine(s);
                return;
            }
            static string[] AddEntries()
            {
                Console.Write("How many members do you wish to add? ");
                int number = int.Parse(Console.ReadLine());
                string[] newEntries = new string[number];
                for (int i = 0; i < number; i++)
                {
                    Console.Write("Type bucket list location... ");
                    newEntries[i] = Console.ReadLine();
                    Console.Clear();    

                }
                return newEntries;
            }
            static List<string> DeleteEntries(List<string> placesToVisit)
            {
                string location = string.Empty;
                
                Console.WriteLine("Enter the location you wish to remove...");
                location = Console.ReadLine();
                
                
                if (placesToVisit.Contains(location))
                {
                    placesToVisit.Remove(location);
                    Console.WriteLine("Entry has been removed from the list...\n" +
                        "[press any key] to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Could not find that entry, no deletions were made...\n" +
                        "[press any key] to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    return null;
                }
                    return placesToVisit;
            }

        }
    }
}
