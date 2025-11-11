using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

namespace Chapter5Ex3
{
    internal class Program
    {


        static void Main(string[] args)
        {
            int weaponsEnergy = 4;
            int shields = 4;
            int propulsion = 2;
            int round = 0;
            int choice = 0;
            int number = 0;
            int selection = 0;
            bool again = false;
           
            Random r = new Random();

            Console.WriteLine("You are the commander of a small destroyer type space craft\n" +
                "\nyour task is to navigate between 3 main areas and to finish 13 rounds\n" +
                $"\nweapons energy:{weaponsEnergy}\n\n" +
                
                $"shields:{shields}\n\n" +
                
                $"propulsion:{propulsion}\n\n" +
                
                "At random you may encounter damage from travel\n\n" +
                "At random your enemies will enter your field and battle you\n\n" +
                "when you get hit your shields will decrease\n\n" +
                "once exhausted, the values of your weapons will begin to be decreased\n\n" +
                "lastly, your propulsion will be next" +
                "\n\nonce you have lost them all you will lose." +
                "\n\n\n[press any key] to continue...");
            Console.ReadKey();
            Console.Clear();
            PrintHud(weaponsEnergy, shields, propulsion);
            while (round <= 12)
            {
                if (propulsion <= 0)
                {

                    Console.Clear();
                    PrintHud(weaponsEnergy, shields, propulsion);
                    Console.WriteLine("You have failed to win!");
                    
                    round = 13;
                    Console.ReadKey();

                }
                else if (round == 12)
                {
                    Console.WriteLine("You made to 12 rounds alive!! You win!");
                    again = TryAgain(again);
                    if (again == true)
                    {
                        Main(null);
                    }
                }
                else
                {
                    if (number == 0 && propulsion > 0)
                    {
                        round++;




                        choice = ChoiceMethod(choice);
                        Console.Clear();
                        Console.WriteLine($"this is round #{round}");
                        switch (choice)
                        {
                            case 1:
                                PrintHud(weaponsEnergy, shields, propulsion);
                                Console.WriteLine("You have set your vector to the asteroid belt!");
                                
                                number = ActionRoll(choice, number, r, propulsion, shields, weaponsEnergy);

                                break;
                            case 2:
                                PrintHud(weaponsEnergy, shields, propulsion);
                                Console.WriteLine("You have begun to close in on the moon base!");
                                
                                number = ActionRoll(choice, number, r, propulsion ,shields, weaponsEnergy);
                                break;
                            case 3:
                                PrintHud(weaponsEnergy, shields, propulsion);
                                Console.WriteLine("You slowly approach the Star Gate!");
                                
                                number = ActionRoll(choice, number, r, propulsion, shields, weaponsEnergy);
                                break;
                            default:
                                PrintHud(weaponsEnergy, shields, propulsion);
                                Console.WriteLine("you didn't pick a valid selection");
                                break;

                        }



                    }
                    else
                    {


                        if (number > 0)
                        {


                            Console.Clear();
                            Console.WriteLine("Please select system to upgrade\n\n" +
                                "[1] Weapons...\n\n" +
                                "[2] Shields...\n\n" +
                                "[3] Propulsion...");
                            selection = int.Parse(Console.ReadLine());
                            if (selection == 1)
                            {
                                weaponsEnergy += number;
                            }
                            else if (selection == 2)
                            {
                                shields += number;
                            }
                            else
                            {
                                propulsion += number;
                            }
                            number = 0;

                        }

                        else if (number < 0)
                        {

                            for (int i = number; i < 0; i++)
                            {
                                if (shields > 0)
                                {
                                    shields--;
                                   
                                }
                                else if (weaponsEnergy > 0)
                                {
                                    weaponsEnergy--;
                                    

                                }
                                else
                                {
                                    propulsion--;
                                    

                                }
                            }

                            number = 0;
                        }





                    }
                }
            }

            




            static void PrintHud(int weaponsEnergy, int shields, int propulsion)
                {
                    Console.WriteLine("**********\n\n" +
                        $"Weapons:[{weaponsEnergy}]\n\n" +
                        $"Shields:[{shields}]\n\n" +
                        $"Propulsion:[{propulsion}]\n\n" +
                        $"**********");
                }
                static int ChoiceMethod(int choice)
                {

                    Console.WriteLine("Select your destination:\n\n" +
                        "[1] Asteroid belt...\n\n" +
                        "[2] Moon base...\n\n" +
                        "[3] Star Gate...");


                    return choice = int.Parse(Console.ReadLine()); ;



                }
                static int ActionRoll(int choice, int number, Random r, int propulsion, int weaponsEnergy, int shields)
                {
                 int modSelector = r.Next(1,4);
                int modifier = propulsion;
                switch (modSelector)
                {
                    case 1:
                        modifier = shields; 
                        break;
                        case 2:
                        modifier = weaponsEnergy;
                        break;
                    default:
                        break;
                        
                }
                
                    switch (choice)
                    {
                        case 1:
                        
                            number = r.Next(-modifier-1, modifier);
                            break;
                        case 2:
                        
                            number = r.Next(-modifier-2, modifier);
                            break;
                        case 3:
                            number = r.Next(-modifier, modifier);
                            break;
                        default:
                            Console.WriteLine("this is unexpected");
                            break;

                    }
                    if (number < 0)
                    {
                        Console.WriteLine($"You have taken on {number} damage during your voayage");

                    }
                    else if (number > 0)
                    {
                        Console.WriteLine($"You have recieved upgrades totaling {number}!\n\n\n" +
                            $"[any key] to enter selection menu");
                    Console.ReadKey();
                    Console.Clear();

                    }
                    else
                    {
                        Console.WriteLine("You have encountered an enemy vessel!!\n\n" +
                            "[any key] to calculate outcome...");
                    Console.ReadKey();
                     
                    int chance = r.Next(1, 3);
                    if (chance == 1)
                    {
                        
                        number += r.Next(-4, -1);
                        Console.WriteLine($"You have lost and sustained {number} of damage\n\n" +
                            $"[any key] to continue...");
                        Console.ReadKey();
                        Console.Clear() ;
                        
                    }
                    else {
                        number += r.Next(1, 5);
                        Console.WriteLine($"You have won the battle, you have recieved {number} points\n\n" +
                            $"[any key] to continue to upgrade selection menu");
                        Console.ReadKey();
                        Console.Clear();
                        
                    }


                    }
                
                    return number;
                }
            static bool TryAgain(bool again)
            {
                Console.WriteLine("[q] to quit, [any other key] to restart");
               string ans =Convert.ToString(Console.ReadLine());
                if ( ans == "Q" || ans == "q")
                {
                    again = false; 
                }
                else
                {
                    again = true;
                }
                return again;
                
            }
            }
        }
    }
