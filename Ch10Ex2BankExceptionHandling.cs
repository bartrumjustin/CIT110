using System;
namespace MoreMoney
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variable Declarations - must be above try block
            //if you want to use variables outside of try,catch and finally
            string? accountName = "";
            double begBalance = 0, endBalance = 0;
            int size = 0;
            List<double> checks = new List<double>();

            // Fill in and validate data
            try
            {
                Console.Write("What is the name of the account? ");
                accountName = ValidateString(Console.ReadLine());
                Console.Write("What is the beginning balance?  ");
                begBalance = ValidateDouble(Console.ReadLine());
                endBalance = begBalance;

                //Check processing
                Console.Write("How many checks would you like to enter? ");
                while (!int.TryParse(Console.ReadLine(), out size) && size <= 0)
                {
                    Console.WriteLine("Please enter a whole number ");
                }
                for (int c = 0; c < size; c++)
                {
                    Console.Write("Please enter the check amount: ");
                    double tempCheck = ValidateDouble(Console.ReadLine());
                    checks.Add(tempCheck);  // add the check to the list
                    endBalance -= tempCheck;
                }
                if (endBalance < 0)
                    throw new ArithmeticException("You are overdrawn. Money will be transferred and NSF will be applied");
                if (begBalance == 0)
                    throw new ArithmeticException("Your balance is zero, please make a deposit");
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown error has occured, please contact Tech Support");
            }
            finally {
                PrintSummary(accountName, checks, begBalance, endBalance);
            }

        }

        private static void PrintSummary(string accountName, List<double> checks, double begBalance, double endBalance)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Print Account Summary
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"Here is your account activity");
            Console.WriteLine($"Account Name: {accountName}");
            // Beginning balance
            Console.WriteLine($"Beginning Balance: {begBalance:C}");
            // Checks
            for (int i = 0; i < checks.Count; i++)
            {
                Console.WriteLine($"Check Amount: {checks[i]:C}");
            }
            // Print out the last item in the list which is the ending balance
            Console.WriteLine($"Ending Balance: {endBalance:C}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static double ValidateDouble(string strValue)
        {
            double number;
            while (!double.TryParse(strValue, out number) || number <= 0)
            {
                Console.WriteLine("Please enter a number greater than zero");
                strValue = Console.ReadLine();
            }
            return number;
        }
        public static string ValidateString(string strValue)
        {
            while (string.IsNullOrEmpty(strValue))
            {
                Console.WriteLine("Text entries cannot be blank or empty, please try again");
                strValue = Console.ReadLine();
            }
            return strValue;
        }

    }
}