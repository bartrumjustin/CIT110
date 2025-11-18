using System.ComponentModel.Design;

namespace Chapter7passwordValidationRevision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int letters = 0;
            int letterCap = 0;
            int numbers = 0;
            bool isSymbol = false;
            bool validated = false;
            while (validated == false){
                Console.WriteLine("Enter a Password that covers this criteria:\n" +
                    "a) Must be at least 12 characters long\r\nb) Must include at least 6 letters\r\nc) Must include at least 1 capital letter\r\nd) Must include at least 1 number\r\ne) Must include at least 1 symbol ($, ->, -<, =, +=, *=, /=, -=, ||, ~)\r\nf) Cannot include any spaces.");
                string userInput = Convert.ToString(Console.ReadLine());
                if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput) ||
                    userInput.Length < 12)
                {
                    Console.WriteLine("Password has not been entered or met the required length");
                    continue;
                }
                for (int i = 0; i < userInput.Length; i++)
                {
                    char test = userInput[i];
                    if (char.IsLetter(test))
                    {
                        letters++;
                        if (char.IsUpper(test))
                        {
                            letterCap++;
                        }
                    }
                    else if (char.IsDigit(test))
                    {
                        numbers++;
                    }
                    switch (test)
                    {
                        case '$':
                            isSymbol = true; 
                            break;
                        case '-':
                            if (userInput[(i + 1)] == '>' || userInput[(i + 1)] == '<')
                            {
                                isSymbol = true;
                            }
                            break;
                        case '=':
                            isSymbol = true;
                            
                            break;
                        case '|':
                            if ((i + 1) < userInput.Length)
                            {
                                if (userInput[(i + 1)] == '|' || userInput[(i - 1)] == '|')
                                {
                                    isSymbol = true;
                                }
                            }
                            break;
                        case '~':
                            isSymbol = true;
                            break;
                    }
                }
                if (letters > 5 && letterCap > 0 && numbers > 0 && isSymbol == true)
                {
                    validated = true;
                    Console.WriteLine("Your Password has fulfilled the requirements, please re-enter to confirm");
                    
                    int resultConfirm = Console.ReadLine().CompareTo(userInput);
                    while(resultConfirm != 0)
                    {
                        Console.WriteLine("Your rentry does not match the original, try again.");
                        resultConfirm = Console.ReadLine().CompareTo(userInput);
                    }
                    Console.WriteLine("your password has been confirmed");
                }
                else 
                { 
                    Console.WriteLine("Your submission did not satisfy the requirements, " +
                        "please review and resubmit"); 
                }
            }
            
            Console.WriteLine($"letters:{letters} numbers:{numbers} Capitalized:{letterCap} symbol:{isSymbol}\n\n" +
                $"[any key to exit]");
            Console.ReadKey();
        }
    }
}
