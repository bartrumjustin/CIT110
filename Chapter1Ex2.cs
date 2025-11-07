namespace Chapter1Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Justin";
            string lastName = "Bartrum";
            string favoriteMovie = "Top Gun";
            string favoriteFood = "Spaghetti";
            int age = 35;
            int birthMonth = 07;
            int birthDay = 25;

            Console.WriteLine("information for ...");
            Console.WriteLine("Name: " + firstName + " " + lastName);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Birthday: " + birthMonth + "/" + birthDay);
            Console.WriteLine("Favorite Movie: " + favoriteMovie);
            Console.WriteLine("Favorite Food: " + favoriteFood);
        }
    }
}
