using System;
using System.Net.NetworkInformation;
namespace ItsMyParty
{
    class Program
    {
        static void Main(string[] args)
        {
            // prompt the user to enter their name
            Console.WriteLine("What is your name? ");
            // create a string variable called myName and set it equal to the value you read in from the console
            string myName = Convert.ToString(Console.ReadLine());
            // prompt the user to enter their birthday
            Console.WriteLine("When is your birthday? (MMDDYYYY) ");
            // create a string variable named myBirthday and set it equal to the value you read in from the console
            string myBirthday = Convert.ToString(Console.ReadLine());
            // prompt the user to enter their favorite kind of cake
            Console.WriteLine("What is your favorite cake? ");
            // create a string variable named cake and set it equal to the value you read in from the console
            string cake = Convert.ToString(Console.ReadLine());
            // prompt the user to enter their ideal location for a birthday party
            Console.WriteLine("Where would you like your Birthday party? ");
            // create a string variable named venue and set it equal to the value you read in from the console
            string venue = Convert.ToString(Console.ReadLine());
            // prompt the user to enter the number of guests they are inviting to the party
            Console.WriteLine("How many guests are attending? ");
            // create an integer variable named guests and set it equal to the value you read in from the console
            int guests = int.Parse(Console.ReadLine());
            // using string interpolation, print the following information
            // "{myName} has a birthday on {myBirthday}. There will be a party at {venue} with {guests} people."
            // "Save room for the {cake} cake!" 
            Console.WriteLine($"\n{myName} has a birthday on {myBirthday}.\nThere will be a party at {venue} with {guests} people.");
            Console.WriteLine($"\nSave room for the {cake} cake!");
        }
    }
}
