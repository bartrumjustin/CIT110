using System;
namespace MyPay
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a string variable named empName and set it equal to your name

            string empName = "Justin Bartrum";

            // create an string variable named title and set it equal to "Developer"
            
            string title = "Developer";

            // create an integer variable named hourlyPay and set it equal to 50

            int hourlyPay = 50;

            // create an integer variable named hoursWorked and set it equal to 40

            int hoursWorked = 40;

            //create an integer variable named weeklyPay and
            //set it equal to hourlyPay * hoursWorked

            int weeklyPay = hourlyPay * hoursWorked;
            
            // use Console.WriteLine() statements with concatenation operators
            // to print out the employee’s name, title, the Weekly Pay heading and
            // the weekly pay amount.

            Console.WriteLine(empName + ", " + title);
            Console.WriteLine("Weekly Pay = " + weeklyPay);
        }
    }
}