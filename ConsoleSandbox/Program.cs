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

            for (int i = 0; i < random.Next(5,10); i++)
            {
                intChain.Add(random.Next(max));
            }
            // End of For loop (Assignments)

            Console.WriteLine("Successfully created a Chain!");

            PrintChain(intChain);
        }
        // End of Main method

        static void GetCont()
        {
            Console.WriteLine("\n[==========================]\n");
            Console.WriteLine("Press enter to continue...\n");
            Console.ReadKey();
        }
        // End of Get Continue method

        static int GetInt()
        {
            int result = 0;
            string input = "nop";
            while (!Int32.TryParse(input, out result))
            {
                Console.WriteLine("Please select an integer:");
                input = Console.ReadLine();
            }
            // End of While loop (Validation)

            return result;
        }
        // End of Get Integer method

        static void PrintChain(Chain<int> chain, int start = 0)
        {
            chain.Select(start);
            Console.WriteLine("Iterating through " + chain.Length + " links:");
            for (bool exit = false; !exit; exit = chain.Iter())
            {
                Console.Write("Index " + chain.Selected.Index + ": ");
                Console.WriteLine(chain.Selected.ToString());
            }
            // End of For loop

            GetCont();
        }
        // End of Print Chain method
    }
    // End of Program Class
}
// End of namespace