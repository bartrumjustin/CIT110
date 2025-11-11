namespace Chapter6MyArrays
{
    internal class Program
    {
        static void Main(string[] args) { 
        Console.WriteLine("How many new hires are their?");
            int size = int.Parse(Console.ReadLine());
        string[] newHire = new string[size];
        bool[] isFullTime = new bool[size];
            for (int i = 0; i<size; i++)
            {
                Console.WriteLine("Enter the name of new hire: ");
                newHire[i] = Console.ReadLine();
                Console.WriteLine($"is {newHire[i]} a full time employee?:\n\n" +
                    $"[y] for full-time or [any other key] for part-time");
                string ans = Console.ReadLine();
                if(ans== "y" || ans == "Y")
                {
                    isFullTime[i] = true;
                }
                else
                {
                    isFullTime[i]= false;
                }
            }
            for(int i=0; i<size; i++)
            {
                Console.WriteLine($"Employee name: {newHire[i]}  Full-time?: {isFullTime[i]}");
            }
        }
    }
}
