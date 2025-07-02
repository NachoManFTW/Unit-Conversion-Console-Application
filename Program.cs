using System;
using System.Xml.Serialization;
using Unit_Converter_Application.Models;
using Unit_Converter_Application.Services;

namespace Unit_Converter_Application
{
    class UnitConverterProgram
    {
        static void Main()
        {

            Explanation();

            string choice = InitialMenu();
            UserChoiceInput(choice);
        }


        //Program Explanation and request to continue
        static void Explanation()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Unit Converter Application");
            Console.WriteLine("Please enter what unit you would like to convert, ");
            Console.WriteLine("and I will do my best to give you either the Imperial/Metric counter part, or");
            Console.WriteLine("turn it into a different ratio.");

            // Outputs "To begin press space... until space is pressed then gets to main portion of program
            do
            {
                Console.WriteLine("To begin press space... ");

                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    break;


            } while (true);
            Console.Clear();
        }


        // Initial Menu for the User to choose what measurement they would like to covert
        static string InitialMenu()
        {
            string[] choices = new string[]
            {
                "0", // Length
                "1", // Weight
                "2", // Temperature
                "3", // Volumne
            };
            string[] names = Enum.GetNames(typeof(SystemUnit));

            Console.WriteLine("Please select one of the following units by entering the corresponding number:\n");

            for (int i = 0; i < Enum.GetNames(typeof(SystemUnit)).Length; i++)
            {
                Console.WriteLine($"{i + 1}. {names[i]}");
            }


            string choice;
            bool found = true;

            // Loop until a vaild number is inputed for list
            do
            {
                int choiceConversion;
                Console.Write("\n\nOption: ");
                choice = Console.ReadLine();

                Int32.TryParse(choice, out choiceConversion);
                choiceConversion -= 1;
                choice = Convert.ToString(choiceConversion);

                foreach (string option in choices)
                {
                    if (choice == option)
                    {
                        found = false;
                        break;
                    }
                }
            } while (found);

            return choice;

        }


        static void UserChoiceInput(string choice)
        {
            switch (choice)
            {
                case "0":
                    ListItems(typeof(LengthUnit));
                    UserInputValue();
                    break;
                case "1":
                    break;
                case "2":
                    break; 
                case "3":
                    break;
            }
        }

        static void UserInputValidation()
        {

        }

        static void ListItems(Type enumType)
        {
            int i = 1;
            foreach (var item in Enum.GetValues(enumType))
            {
                Console.WriteLine(i + ". " + item);
                i++;
            }
        }


        //User input for values to be converted 
        static double UserInputValue()
        {
            string input;
            double value;

            do
            {

                Console.WriteLine("Value: ");
                input = Console.ReadLine();

                if (Double.TryParse(input, out value))
                {
                    return value;
                }
            } while (true);

        }
    }





}