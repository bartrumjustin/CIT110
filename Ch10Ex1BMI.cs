using System;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

class BMICalculator
{
    public static void Main()
    {
        int height, weight;
        Console.Write("Enter your height in inches (to the nearest whole number): ");
        while (!int.TryParse(Console.ReadLine(), out height))
        {
            Console.WriteLine("Please enter a valid height");
        }
        Console.Write("Enter your weight to the nearest whole number: ");
        while (!int.TryParse(Console.ReadLine(), out weight))
        {
            Console.WriteLine("Please enter a valid weight: ");
        }
        // create try block
        try
        {
            if (height < 24 || height > 100)
            {
                height = 65;
                throw new InvalidDataException("Height is out of range, a default of 65 has been used.");
                
                
            }
            
            if (weight < 80 || weight > 700)
            {
                weight = 150;
                throw new InvalidDataException("Weight is out of range, a default of 150 has been used");
            }
        }

        // create catch block
        catch(InvalidDataException ex) {
            Console.WriteLine(ex.Message);

        }
        catch(Exception) {
            Console.WriteLine("An error occured");
        }
        finally
        {
            decimal bmi = (weight * 703) / (height * height);
            Console.WriteLine($"Your BMI is: {Math.Floor(bmi)}");
            Console.WriteLine("For healthy adults BMI values between 18.5-24.9 indicate a healthy weight");
        }
    }
}