using System.Diagnostics.Metrics;

namespace Chapter8Ex2
{
    internal class Program
    {
        const int SIZE = 50;
        static void Main(string[] args)
        {
            int counter = 0;
            string[] players = new string[SIZE];
            double[] dues = new double[SIZE];
            string value;
            int changePlayer;
            char select = menu();
            while (select != 'q')
            {
                switch (select)
                {
                    case '1':
                        addOnePlayer(players, dues, ref counter);
                        //counter++;
                        break;
                    case '2':
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"Enter the player# you wish to change (1 to {counter}) ");
                        value = Console.ReadLine();
                        while (!int.TryParse(value, out changePlayer) || changePlayer <= 0 || changePlayer > counter)
                        {
                            Console.Write($"The number you entered wasn't valid." +
                                $" Enter a number between 1 and {counter}");
                            value = Console.ReadLine();
                        }
                        changePlayer--;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Is player, {players[changePlayer]} the one you want to change? (y for yes)");
                        char answer = char.ToLower(char.Parse(Console.ReadLine()));
                        if (answer == 'y')
                        {
                            changeOnePlayer(players, dues, changePlayer);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"Please make another selection from the menu");
                        }
                        break;
                    case '3':
                        counter = addMultiPlayers(players, dues, counter);
                        break;
                    case '4':
                        printPlayerInfo(players, dues);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"You made an invalid selection, please try again");
                        break;
                }
                select = menu();

            }

        }

        private static void printPlayerInfo(string[] players, double[] dues)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"--------------Current Membership Roster--------------");
            for (int i = 0; i < players.Length; i++)
            {
                if (dues[i] > 0)
                    Console.WriteLine($"\t\t{players[i]}  {dues[i]:C}");
            }
            Console.WriteLine();
        }

        private static int addMultiPlayers(string[] players, double[] dues, int counter)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("How many players do you want to add?");
            string strNum = Console.ReadLine();
            int number;
            while (!int.TryParse(strNum, out number) || counter + number > SIZE || number <= 0)
            {
                Console.WriteLine("Please enter a valid number,less than {SIZE} and greater than 0");
                strNum = Console.ReadLine();
            }
            string strDues;
            for (int i = counter; i < counter + number; i++)
            {
                Console.Write($"Name: ");
                players[i] = Console.ReadLine();
                Console.Write($"Dues: ");
                strDues = Console.ReadLine();
                while (!double.TryParse(strDues, out dues[i]))
                {
                    Console.WriteLine("The number you entered was invalid, try again");
                    strDues = Console.ReadLine();
                }
            }
            return counter + number;
        }

        private static void changeOnePlayer(string[] p, double[] d, int changePlayer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"New Name: ");
            p[changePlayer] = Console.ReadLine();
            Console.Write($"Dues: ");
            string dues = Console.ReadLine();
            while (!double.TryParse(dues, out d[changePlayer]))
            {
                Console.WriteLine("The number you entered was invalid, try again");
                dues = Console.ReadLine();
            }
           
            
        }

        private static void addOnePlayer(string[] p, double[] d, ref int counter)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Name: ");
            p[counter] = Console.ReadLine();
            Console.Write($"Dues: ");
            string dues= Console.ReadLine();
            while (!double.TryParse(dues, out d[counter]))
            {
                Console.WriteLine("The number you entered was invalid, try again");
                dues = Console.ReadLine();
            }
            counter++;
            
        }

        private static char menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Acme Membership System");
            Console.WriteLine($"-------------------------------------------------------------");
            Console.WriteLine("1 = add a player\n2 = change a player\n3 = add multiple players\n4 = print\nq = quit");
            Console.WriteLine($"-------------------------------------------------------------");
            Console.WriteLine();
            char choice = char.Parse(Console.ReadLine());
            return Char.ToLower(choice);
        }

    }
}