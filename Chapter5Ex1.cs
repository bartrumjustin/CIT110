namespace Chapter5Ex1
{
    class Program
    {
      
         private static void Main(string[] args)
        {
            int input = Menu();

            int n1, n2;
            Random rnd = new Random();
            while (input != '3')
            {
                n1 = rnd.Next(1, 100);
                n2 = rnd.Next(1, 100);
                if (input == '1')
                {
                    addition(n1,n2);
                }
                else
                {
                    subtraction(n1,n2);
                }
                input = Menu();
            }
        }
        // add menu method here
        static int Menu()
        {
            Console.WriteLine("Hello, I'm here to help you with math problems");
            Console.WriteLine("Please make a selection from our menu.");
            Console.WriteLine("1 for addition\n2 for subtraction\n3 to quit");
            int input = Console.Read();
            Console.ReadLine();
            return input = Convert.ToChar(input);
        }

        // add addition method here
        static void addition(int n1, int n2)
        {
            int correctAns = n1 + n2;
            Console.Write($"The sum of {n1}+{n2}= ");
            int answer = int.Parse(Console.ReadLine());
            while (answer != correctAns)
            {
                Console.WriteLine("Oooops, that was incorrect, please try again");
                Console.Write($"The sum of {n1}+{n2}= ");
                answer = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Great answer!");
        }
        // add subtraction method here
        static void subtraction(int n1, int n2)
        {
            int correctAns = n1 - n2;
            Console.Write($"The result of {n1}-{n2}= ");
            int answer = int.Parse(Console.ReadLine());
            while (answer != correctAns)
            {
                Console.WriteLine("Wrong answer, please try again");
                Console.Write($"The result of {n1}-{n2}= ");
               answer = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Fabulous!");
        }
    }
}