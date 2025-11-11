using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
namespace Chapter6ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList List = new ArrayList()
            {
                "Work", 8, "Family", 5, "College work", 3
            };
            ArrayList newEntry = new ArrayList() { };
            const string name = "Justin";
            const int year = 2025;
            int selection = 0;
            while (selection != 4)
            {
                Console.WriteLine($"Hello {name}, Make a Selection:\n" +
                    "[1] View List of To Do's\n" +
                    "[2] Add a To Do entry\n" +
                    "[3] Remove a To Do entry\n" +
                    "[4] Quit the Program\n" +
                    "[5] Clear all To Do entries\n");

                selection = int.Parse(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        PrintByIndex(List);
                        Console.WriteLine("\n\n********************\n" +
                            "[any key] to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        
                        newEntry = AddListEntry();
                        List.AddRange(newEntry);
                        break;
                    case 3:
                        
                        int indexToDelete = 0;
                        int deletenumber=RemoveListEntry();
                            
                        if ((deletenumber * 2) > List.Count)
                        {
                            Console.WriteLine("Selection is higher than the amount of entries available\n" +
                                "no deletions made\n" +
                                "********************\n");
                            break;
                        }
                        else {
                            
                                indexToDelete = deletenumber + (deletenumber - 2);
                            List.RemoveRange(indexToDelete, 2);
                        }
                            Console.WriteLine("Selection has been deleted successfully!");
                        break;
                    case 4:
                        break;
                        case 5:
                            List.Clear();
                        Console.WriteLine("Nothing to see here folks, its all gone...not a thing in sight\n" +
                            "...best be getting home now...not missing much here...\n\n" +
                            "seriously...its gone....as in nothing To Do, congrats! you now have so much more time on your hands.\n" +
                            "but don't chill here...bye bye");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("You have made a wrong selection, try again.");
                        break;
                }
            }
            static void PrintByIndex(ArrayList List)
            {
                Console.WriteLine($"{name}'s {year} To Do List\n" +
                    $"********************\n");
                int index = 0;
                int number = 1;
                foreach (var e in List)
                { 
                   if(index%2 == 0)
                    {
                        
                        Console.WriteLine(number + ". " + e.ToString());
                        number++;
                    }
                    else
                    {
                        Console.WriteLine($"Hours reserved: {e.ToString()}\n");
                    }
                    index++;
                }
            }
            static ArrayList AddListEntry()
            {
                Console.Write("How many To Do entries will you add? ");
                int number = int.Parse(Console.ReadLine());
                ArrayList Entries = new ArrayList { };
                for (int i = 0; i < number; i++)
                {
                    Console.Write("To Do subject line: ");
                    Entries.Add(Console.ReadLine());
                    Console.Write("How many Hours should be allotted? ");
                    Entries.Add(int.Parse(Console.ReadLine()));
                    

                }
                Console.WriteLine("\nTransfering and Adding new entries...\n\n" +
                    "********************\n" +
                    "[any key] to continue");
                Console.ReadKey();
                Console.Clear();
                return Entries;
            }
            static int RemoveListEntry()
            {
                Console.WriteLine ("Choose a index # to delete the entry and its allotted time:\n");
                int number = int.Parse(Console.ReadLine());
                return number;
            }
        }
    }
}
