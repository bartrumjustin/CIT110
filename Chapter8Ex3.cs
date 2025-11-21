using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Chapter8Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> racerName= new List<string>();
            List<int> pickNum= new List<int>();
            ArrayList racerAndScore = new ArrayList();
            bool racerNameIsDone = false;
            bool passPrompt = false;
            int number = 0;
            int rounds = 0;
            string finalWinner = "";
            Prompt( ref passPrompt, ref number, ref racerName, ref racerNameIsDone, ref pickNum);
            Console.WriteLine("The racer's will now begin to race!, How many rounds shall they attempt?");
            string userRounds = Console.ReadLine();
            while(!int.TryParse(userRounds, out rounds))
            {
                Console.WriteLine("Amount not a valid number.");
                userRounds = Console.ReadLine();
            }
            LetsRace(rounds, number, racerName, pickNum, ref racerAndScore, ref finalWinner);
            Console.WriteLine($"The final winner is {finalWinner}");
            
           
           
        }
        static void Prompt(ref bool passPrompt, ref int number, 
            ref List<string> racerName, ref bool racerNameIsDone, ref List<int> pickNum)
        {
            racerName = new List<string>();
            while (passPrompt == false) { 
                
                    Console.WriteLine("Enter amount of racers (must be greater than 1)");
                    string num = Console.ReadLine();
                if(!int.TryParse(num, out number)|| int.Parse(num)<=1) { 
                    Console.WriteLine("not a valid choice, try again");

                }
                else
                {
                    passPrompt = true;
                }
        }
            while (racerNameIsDone == false)
            {
                for (int i = 0; i < number; i++)
                {
                    string userans = "";
                    Console.WriteLine("what are the names of your racers?");
                    userans = Console.ReadLine();
                    while (string.IsNullOrEmpty(userans) || string.IsNullOrWhiteSpace(userans))
                    {
                        Console.WriteLine("not a valid name, may not be empty, null or white space");
                        userans = Console.ReadLine();
                    }
                    racerName.Insert(i,Convert.ToString(userans));
                    Console.Clear();
                    Console.WriteLine($"{(i +1)}");
                    foreach (string item in racerName)
                    {
                        Console.WriteLine(item);
                    }

                }
                racerNameIsDone=true;
                Console.Clear();
            }
            bool pickIsDone = false;
            while (pickIsDone == false) {
                Console.WriteLine($"Pick a number 1 - {number} for each racer.");
                for (int i = 0; i < number; i++)
                {
                    int userAns = 0;
                    Console.WriteLine($"Pick a number for {racerName[i]}");
                    if (!int.TryParse(Console.ReadLine(), out userAns)) {
                        Console.WriteLine("Your selection is not a number");
                        i--;
                    }
                    else if (userAns > number || userAns <= 0)
                    {
                        Console.WriteLine("Your choice was not with in the range offered.");
                        i--;
                    }
                    
                    
                        else
                    {
                        pickNum.Insert(i, userAns);
                        Console.WriteLine("\nCurrent list is:");
                        foreach (int item in pickNum)
                        {
                            Console.WriteLine($"\n{item}");
                        }
                        if (i == (number-1))
                        {
                            pickIsDone = true;
                        }
                    }
                    

                }
            }
        }
        static void LetsRace(int rounds, int number, List<string> racerName, List<int> pickNum, ref ArrayList racerAndScore, ref string finalWinner)
        {
            bool tieFlag = false;
            int count = 0;
            string racerResult = "";
            int[] amounts = new int[number];
            //List<string> currentRace = new List<string>();
            Random rand = new Random();
            List<int> totalList = new List<int>();

            while (count < rounds)
            {
                Console.WriteLine("The distance traveled will be marked as '*'\n" +
                    "the racer with the most traveled distance will win that round.\n" +
                    "the racer with the most traveled value will utimately win.\n\n" +
                    "Let's Race!!!\n\n" +
                    "[any key to continue]");

                Console.ReadKey();
                Console.Clear();
                for (int i = 0; i < number; ++i)
                {
                    string traveled = "";
                    int amount = pickNum[i] * rand.Next(-pickNum[i], number + 1) + number + rand.Next(-pickNum[i], pickNum[i]);
                    if (amount < 0)
                    {
                        amount = 0;
                    }
                    for (int x = 0; x < amount; ++x)
                    {
                        traveled += "*";

                    }
                    int racerIndex = racerName.IndexOf(racerName[i]);
                    racerResult = $"{racerName[i]}:{amount}|{traveled}|";
                    racerAndScore.Insert(racerIndex, amount);
                    Console.WriteLine(racerResult);
                    //currentRace.Insert(i, racerResult);
                    amounts[i] += amount;

                }

                count++;


                Console.WriteLine($"Who is our #{count} heat winner?\n\n" +
                    $"[any key to continue]");

                Console.ReadKey();
                Console.Clear();
                int compare = amounts[0];
                int y = 1;
                int topNumber = 0;
                
               

                while (y < number)
                {
                    if (compare > amounts[y])
                    {
                        ++y;
                        tieFlag = false;
                    }
                    else if (compare < amounts[y])
                    {
                        compare = amounts[y];

                        topNumber = y;
                        ++y;
                        tieFlag = false;
                    }
                    else if (compare == amounts[y])
                    {
                        tieFlag = true;
                        ++y;
                    }

                }
                if (tieFlag == true)
                {
                    Console.WriteLine("**********" +
                        "\nA tie has occured\n" +
                        "**********");
                }


                
                

                if (tieFlag != true)
                {
                    Console.WriteLine($"********************\n" +
                        $"The winner for this heat is {racerName[topNumber]}\n" +
                        $"********************");
                }
                else
                {
                    Console.WriteLine("////////////////////" +
                        "\n\nA Tie, no winner, points logged for final victory!\n\n" +
                        "////////////////////");
                }
                Console.WriteLine("Overall Standings:\n\n");
                foreach (string var in racerName)
                {
                    int varIndex = racerName.IndexOf(var);
                    Console.WriteLine($"\n{var} ************ {amounts[varIndex]}");
                    totalList.Insert(varIndex, amounts[varIndex]);
                }
            }
            FinalWinner(racerName, totalList, ref finalWinner);
                
               static void FinalWinner(List<string> racerName, List<int> totalList, ref string finalWinner)
            {
                int highIndex = 0;
                int highNumber = 0;
                string highName = "";
                for (int i = 0; i < racerName.Count; i++)
                {
                    if (highNumber < totalList[i])
                    {
                        highNumber = totalList[i];
                        highName = racerName[i];
                        highIndex = i;
                    }
                    
                }
                finalWinner = highName;
                
            }
                
                



            
        }


    }
}
