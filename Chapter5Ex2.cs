using System;
namespace pirateGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool piratesTurn = true;
            bool winner = false;
            Random rand = new Random();
            int call, toss;
            int numFlips = 0;
            int myScore = 0;
            int pirateScore = 0;
            while (numFlips < 25 && !winner)
            {
                toss = rand.Next(1, 3);
                if (piratesTurn == true)
                {
                    call = rand.Next(1, 3);


                    if (call == toss)
                    {
                        pirateScore += 5;

                    }
                    else
                    {
                        pirateScore -= 1;
                    }
                    int eval = call;
                    string guessAns = GetCoinFace(eval);
                    Console.WriteLine($"Pirate: Yar, the coin be {guessAns}!");
                    eval = toss;
                    string resultAns = GetCoinFace(eval);
                    Console.WriteLine($"The coin is revealed as {resultAns}!\n" +
                            $"Totaling {pirateScore}");
                    piratesTurn = false;
                }
                else
                {
                    call = rand.Next(1, 3);


                    if (call == toss)
                    {
                        myScore += 4;

                    }
                    else
                    {
                        myScore -= 2;
                    }
                    int eval = call;
                    string guessAns = GetCoinFace(eval);
                    Console.WriteLine($"Player: the coin is {guessAns}!");
                    eval = toss;
                    string resultAns = GetCoinFace(eval);
                    Console.WriteLine($"The coin is revealed as {resultAns}!\n" +
                            $"Totaling {myScore}");
                    piratesTurn = true;
                }
                if (pirateScore >= 50 || myScore >= 50)
                {
                    winner = true;
                    continue;
                }
                else
                {
                    numFlips++;
                    if (numFlips == 25)
                    {
                        Console.WriteLine("25 toss limit has been reached!");
                        continue;
                    }
                }
            }
                if (pirateScore > myScore)
                {
                    Console.WriteLine("Pirates Win! Ye be walking the plank to see davey jones locker!");
                }
                // display a message about walking the plank
                else if (pirateScore == myScore)
                {
                    Console.WriteLine("Draw! To the hoosegow with you, lock em up and throw away the key!");
                }
                // display a message about being thrown in the hoosegow
                else
                {
                    Console.WriteLine("Player Wins! ARRRGH, I keep me word, heres the map!");
                }
                // display a message about receiving a treasure map
            
            static string GetCoinFace(int eval)
            {
                if (eval == 1)
                {
                    return "heads";
                }
                else
                {
                    return "tails";
                }
            }
        }
    }
}