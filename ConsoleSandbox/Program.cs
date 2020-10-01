using System;
using ChainTwo;
namespace ConsoleSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int max = 99;
            // Just in case.

            Console.WriteLine("Hello, fox! Let's play around with Chains.");
            GetCont();
            // Start!

            Chain<int> intChain = new Chain<int>();

            for (int i = 0; i < random.Next(5, 10); i++)
            {
                intChain.Add(random.Next(max));
            }
            // End of For loop (Assignments)

            Console.WriteLine("Successfully created a Chain!");
            Console.WriteLine("There are currently " + intChain.Length + " items in the chain!");
            GetCont();

            Console.WriteLine("We can iterate through the Chain like this:");
            for (int i = 0; i < intChain.Length; i++)
            {
                intChain.Select(i);
                Console.WriteLine("Index " + intChain.Selected.Index + ": " + intChain.Selected.ToString());
            }
            // End of For loop
            GetCont();

            Console.WriteLine("Or we can iterate like this:");
            intChain.Select(intChain.Length);
            for (bool exit = false; !exit; exit = intChain.Iter(false))
            {
                Console.Write("Index " + intChain.Selected.Index + ": ");
                Console.WriteLine(intChain.Selected.ToString());
            }
            // End of For loop
            GetCont();

            Console.WriteLine("Or, if you prefer, we can port it to a regular array first:");
            int[] intArray = intChain.ToArray();

            foreach(int item in intArray)
            {
                Console.WriteLine("- " + item);
            }
            // End of Foreach loop
            GetCont();

        }
        // End of Main method

        static void GetCont()
        {
            Console.WriteLine("\n[==========================]\n");
            Console.WriteLine("Press enter to continue...\n");
            Console.ReadKey();
        }
        // End of Get Continue method
    }
    // End of Program Class
}
// End of namespace