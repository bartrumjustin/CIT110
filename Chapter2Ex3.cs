using System;

namespace myMusic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is the name of your favorite song? ");
            string songName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("What band/person sings this song? ");
            string songSinger = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Pick the genre that best describes the song as follows:\n" +
                "P for pop, R for rock, M for heavy metal, A for alternative, C for country, J for jazz ");
            String genre = Convert.ToString(Console.ReadLine());
            Console.WriteLine($"How often have you listened to {songName} last week? ");
            int freq = int.Parse(Console.ReadLine());
            string fullGenre = "";
            switch (genre)
            {
                case "P":
                case "p":
                    fullGenre = "pop";
                    break;
                case "R":
                case "r":
                    fullGenre = "rock";
                    break;
                case "M":
                case "m":
                    fullGenre = "heavy metal";
                    break;
                case "A":
                case "a":
                    fullGenre = "alternative";
                    break;
                case "C":
                case "c":
                    fullGenre = "country";
                    break;
                case "J":
                case "j":
                    fullGenre = "jazz";
                    break;
                default:
                    fullGenre = "not displayed because you haven't selected from the options given";
                    break;
                    
            }
            Console.WriteLine($"\nYou have been listening to {songName} by {songSinger}." +
                $"\nThe song genre is {fullGenre} and you have listened to the song approximately {freq} times this week.");

        }
    }
}
