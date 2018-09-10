using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args.Length > 2)
                {
                    Console.WriteLine("Error: You may only enter a maximum of 2 arguments: a name and age.");
                }

                var name = args[0];

                if (args.Length == 2)
                {
                    int age;

                    bool success = Int32.TryParse(args[1], out age);

                    if (success)
                    {
                        Console.WriteLine($"{name} is {age} years old.");
                    }
                    else
                    {
                        Console.WriteLine("Error: please enter a valid age.");
                    }
                }
                else
                {
                    Console.WriteLine($"Hello, {name}!");
                }
            }
            else
            {
                Console.Write("Type your first name and press enter: ");
                var name = Console.ReadLine();

                Console.Write($"How old are you, {name}?: ");
                var age = Console.ReadLine();

                int convertedAge;

                bool success = Int32.TryParse(age, out convertedAge);

                if (success)
                {
                    Console.WriteLine($"{name} is {convertedAge} years old.");
                }
                else
                {
                    Console.WriteLine("Error: please enter a valid age.");
                }
            }

            Console.ReadKey();
        }
    }
}
