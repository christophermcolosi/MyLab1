using System;
using System.Configuration;

namespace HelloConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"C:\Code\MyLab1\App.config");

            string name = "";
            int age = 0;

            switch (args.Length)
            {
                case 0:
                    string appConfigName = ConfigurationManager.AppSettings["name"];
                    string appConfigAge = ConfigurationManager.AppSettings["age"];

                    if (!string.IsNullOrEmpty(appConfigName) && !string.IsNullOrEmpty(appConfigAge))
                    {
                        name = appConfigName;
                        age = ConvertToNumber(appConfigAge);
                    }
                    else if (!string.IsNullOrEmpty(appConfigName))
                    {
                        name = appConfigName;
                        age = PromptUserForAge();
                    }
                    else if (!string.IsNullOrEmpty(appConfigAge))
                    {
                        name = PromptUserForName();
                        age = ConvertToNumber(appConfigAge);
                    }
                    else
                    {
                        name = PromptUserForName();
                        age = PromptUserForAge();
                    }

                    break;
                case 1:
                    if (IsNumber(args[0]))
                    {
                        name = PromptUserForName();
                        age = ConvertToNumber(args[0]);
                    }
                    else
                    {
                        name = args[0];
                        age = PromptUserForAge();
                    }

                    break;
                case 2:
                    name = args[0];
                    age = ConvertToNumber(args[1]);
                    break;
                default:
                    Console.WriteLine("You messed up");
                    break;

            }

            Report(name, age);

            Console.ReadKey();
        }

        private static void Report(string name, int age)
        {
            Console.WriteLine($"{name} is {age} years old.");
        }

        private static int PromptUserForAge()
        {
            var age = 0;
            bool correctAge = false;

            do
            {
                Console.Write("How old are you?: ");
                age = ConvertToNumber(Console.ReadLine());
                correctAge = age > 0 ? true : false;

                if (!correctAge)
                    Console.WriteLine("Please enter a valid age");
            } while (!correctAge);

            return age;
        }

        private static int ConvertToNumber(string v)
        {
            int age = 0;

            try
            {
                age = int.Parse(v);
            }
            catch (Exception e)
            {
                age = -1;
            }

            return age;
        }

        private static bool IsNumber(string v)
        {
            return ConvertToNumber(v) > 0 ? true : false;
        }

        private static string PromptUserForName()
        {
            Console.Write("What is your name?: ");
            return Console.ReadLine();
        }
    }
}
