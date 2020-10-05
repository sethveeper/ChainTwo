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

            Chain<int> chain = new Chain<int>();

            for (int i = 0; i < random.Next(5,10); i++)
            {
                chain.Add(random.Next(max));
            }
            // End of For loop (Assignments)

            Console.WriteLine("Successfully created a Chain!");

            GetCont();

            Console.WriteLine("We can iterate through it like this:");
            for (int i = 0; i < chain.Length; i++)
            {
                int output = chain.Select(i);
                Console.WriteLine("Index " + i.ToString() + ": " + output.ToString());
            }
            // End of For loop

            GetCont();

            Console.WriteLine("Or like this:");
            chain.Select(chain.Length);
            for (bool exit = false; !exit; exit = chain.Iter(false))
            {
                Console.Write("Index " + chain.Selected.Index + ": ");
                Console.WriteLine(chain.Selected.ToString());
            }
            // End of For loop

            GetCont();

            Console.WriteLine("We can add values freely, as well; go ahead, enter an integer:");
            int addon = GetInt();
            chain.Add(addon);

            Console.WriteLine("See it there on the end?");
            for (int i = 0; i < chain.Length; i++)
            {
                int output = chain.Select(i);
                Console.WriteLine("Index " + i.ToString() + ": " + output.ToString());
            }
            // End of For loop

            GetCont();

            Console.WriteLine("What if we have a Chain, but want an array? We can easily do that!");

            int[] array = chain.ToArray();

            foreach(int item in array)
            {
                Console.WriteLine("- " + item.ToString());
            }
            // End of foreach

            GetCont();

            Console.WriteLine("What about the opposite? We can also make a Chain out of an array!");

            int[] newArray = { 3, 6, 9, 12, 15, 18 };
            Chain<int> newChain = new Chain<int>(newArray);

            for (int i = 0; i < chain.Length; i++)
            {
                int output = chain.Select(i);
                Console.WriteLine("Index " + i.ToString() + ": " + output.ToString());
            }
            // End of For loop

            GetCont();

            Console.WriteLine("That's all I've got for today. Check out the source code at this link:");
            Console.WriteLine("https://github.com/sethveeper/ChainTwo");
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
    }
    // End of Program Class
}
// End of namespace