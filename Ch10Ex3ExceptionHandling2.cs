using System;
namespace Discounts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to our frequent shopper discount program");
                Console.WriteLine("Please enter your 4 digit PIN");
                int pinNumber = int.Parse(Console.ReadLine());
                double discount = 0;
                if (pinNumber > 5000)
                    discount = .20;
                else if (pinNumber > 1000)
                    discount = .15;
                else if (pinNumber > 100)
                    discount = .10;
                else
                    throw new Exception("You entered an invalid PIN number.");
                Console.WriteLine("How much did you spend today?");
                double spend = double.Parse(Console.ReadLine());
                if (spend <= 0)
                {
                    throw new InvalidDataException("You can not recieve a discount with no purchases");
                }
                Console.WriteLine($"Your discount is {discount * 100}%");
                double cost = spend - (spend * discount);
                Console.WriteLine($"Your total cost is " + String.Format("{0:C}", cost));
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("An Error Has Occured, contact support");
            }
            finally
            {
                Console.WriteLine("Enjoy shopping");
            }
        }
    }
}