namespace Chapter8Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string club = string.Empty;
            double cost = 0;
            int players = 0;
            club = changeClub(club);
            cost=changeCost(cost);
            changePlayers(ref players);
            printEvent(club, cost, players);
        }
        private static void changePlayers(ref int players)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("How many players are in the tournement?");
            players = int.Parse(Console.ReadLine());
            return;
        }
        private static double changeCost(double cost)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"What is the cost per player?");
            cost = double.Parse(Console.ReadLine());
            return cost;
        }
        private static string changeClub(string club)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What type of club is holding the competition?");
            club = Console.ReadLine();
            return club;
        }
        private static void printEvent(string club, double cost, int players)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"=========================================================");
            Console.WriteLine($"Welcome to the {club} club");
            Console.WriteLine($"The cost to join today's competition is {cost:C}");
            Console.WriteLine($"The number of players is {players}");
            Console.WriteLine($"=========================================================");
        }
    }
}