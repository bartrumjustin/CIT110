using System;
namespace Chapter6MyArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("How many items would you like to enter?");
                if (!int.TryParse(Console.ReadLine(), out int size))
                {
                    throw new FormatException($"Your submission was not a valid number.");
                }
                string[] members = new string[size];
                double[] dues = new double[size];

                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine("Enter the member name: ");
                    members[i] = Console.ReadLine();
                    Console.WriteLine("Enter the dues: ");
                    if (!double.TryParse(Console.ReadLine(), out dues[i]))
                    {
                        throw new FormatException("The amount in Dues is not a valid entry");
                    }
                }




                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine($"Member: {members[i]}  Dues: {dues[i]:C}");
                }

            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("An unspecified error has occured, please contact support");
            }
            finally
            {
                Console.WriteLine("Have a Nice Day");
            }
        }
    }
}