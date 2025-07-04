using System;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using Unit_Converter_Application.Models;
using Unit_Converter_Application.Services;

namespace Unit_Converter_Application
{
    class UnitConverterProgram
    {
        private static void Main(string[] args)
        {
            bool repeat = true;
            do
            {
                Explanation();
                string choice = InitialMenu();
                UserChoiceInput(choice);
                repeat = ProgramRepeat();
            } while (repeat);

        }


        //Program Explanation and request to continue
        static void Explanation()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Unit Converter Application");
            Console.WriteLine("Please enter what unit you would like to convert, ");
            Console.WriteLine("and I will do my best to give you either the Imperial/Metric counter part, or");
            Console.WriteLine("turn it into a different ratio.");

            // Outputs "To begin press space..." until space is pressed then gets to the main portion of the program
            do
            {
                Console.Write("\nTo begin press space... ");

                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    break;


            } while (true);

            Console.Clear();
        }
        
        // Initial Menu for the User to choose what measurement they would like to covert
        static string InitialMenu()
        {
            string[] choices = //Add number of choices compared to number of system units
            [
                "0", // Length
                "1", // Weight
                "2", // Temperature
                "3", // Volume
            ];
            string[] names = Enum.GetNames(typeof(SystemUnit));

            Console.WriteLine("Please select one of the following units by entering the corresponding number:\n");

            for (int i = 0; i < Enum.GetNames(typeof(SystemUnit)).Length; i++)
            {
                Console.WriteLine($"{i + 1}. {names[i]}");
            }

            string choice;
            bool found = true;

            // Loop until a valid number is inputted for a list
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

        //Get initial user input choice for what kind of conversion they want to do, i.e., the list of system units
        static void UserChoiceInput(string choice)
        {
            string convertFrom;
            string convertTo;
            double value;
            double result;
            var helper = new ConversionService();
            switch (choice)
            {
                case "0": //Length
                    ListItems(typeof(LengthUnit));
                    convertFrom = UserSelectUnits(1);
                    convertTo = UserSelectUnits(2);
                    value = UserInputValue();
                    result = helper.ConvertLength(
                        value, 
                        ConvertChoiceToUnitsLength(convertFrom, typeof(LengthUnit)), 
                        ConvertChoiceToUnitsLength(convertTo, typeof(LengthUnit))
                        );
                    Console.WriteLine(
                        $"{value:F2} {GetEnumValue(convertFrom, typeof(LengthUnit))} " + 
                        $"=> {result:F2} {GetEnumValue(convertTo, typeof(LengthUnit))}" 
                        );
                    break;
                
                case "1": //Weight
                    ListItems(typeof(WeightUnit));
                    convertFrom = UserSelectUnits(1);
                    convertTo = UserSelectUnits(2);
                    value = UserInputValue();
                    result = helper.ConvertWeight(
                        value,
                        ConvertChoiceToUnitsWeight(convertFrom, typeof(WeightUnit)),
                        ConvertChoiceToUnitsWeight(convertTo, typeof(WeightUnit))
                        );
                    Console.WriteLine(
                        $"{value:F2} {GetEnumValue(convertFrom, typeof(WeightUnit))} " +
                        $"=> {result:F2} {GetEnumValue(convertTo, typeof(WeightUnit))}"
                        );
                    break;
                
                case "2": //Temperature
                    ListItems(typeof(TemperatureUnit));
                    convertFrom = UserSelectUnits(1);
                    convertTo = UserSelectUnits(2);
                    value = UserInputValue();
                    result = helper.ConvertTemperature(
                        value,
                        ConvertChoiceToUnitsTemperature(convertFrom, typeof(TemperatureUnit)),
                        ConvertChoiceToUnitsTemperature(convertTo, typeof(TemperatureUnit))
                    );
                    Console.WriteLine(
                        $"{value:F2} {GetEnumValue(convertFrom, typeof(TemperatureUnit))} " +
                        $"=> {result:F2} {GetEnumValue(convertTo, typeof(TemperatureUnit))}"
                        );
                    break;
                
                case "3": //Volume
                    ListItems(typeof(VolumeUnit));
                    convertFrom = UserSelectUnits(1);
                    convertTo = UserSelectUnits(2);
                    value = UserInputValue();
                    result = helper.ConvertVolume(
                        value,
                        ConvertChoiceToUnitsVolume(convertFrom, typeof(TemperatureUnit)),
                        ConvertChoiceToUnitsVolume(convertTo, typeof(VolumeUnit))
                    );
                    Console.WriteLine(
                        $"{value:F2} {GetEnumValue(convertFrom, typeof(VolumeUnit))} " +
                        $"=>  {result:F2} {GetEnumValue(convertTo, typeof(VolumeUnit))}"
                        );
                    break;
            }
        }

        //Outputs bool of if the user wants to repeat the program
        static bool ProgramRepeat()
        {
            string repeat;
            do
            {
                Console.Write("Would you like to enter a new conversion?(Y/N): ");
                repeat = Console.ReadLine();
                if (repeat == "Y" || repeat == "y")
                    return true;
                else if (repeat == "n" || repeat == "n")
                    return false;
            } while (true);
        }
        
        static void UserInputValidation()
        {

        }

        static void ListItems(Type enumType)
        {
            Console.WriteLine("Please select on of the following measurements to convert by the corresponding number:");
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
                Console.Write("Value: ");
                input = Console.ReadLine();

                if (Double.TryParse(input, out value))
                {
                    return value;
                }
            } while (true);

        }

        static string UserSelectUnits(int convert)
        {
            string unit;
            switch (convert)
            {
                case 1:
                    Console.Write("Convert From: ");
                    unit = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Convert To: ");
                    unit = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid Option!");
                    unit = null;
                    break;
            }
            return unit;
        }

        //Used to return enum of type length unit
        static LengthUnit ConvertChoiceToUnitsLength(string choice, Type enumType)
        {
            return (LengthUnit)Enum.GetValues(enumType).GetValue(Convert.ToInt32(choice) - 1);
        }


        //Used to return enum of type weight unit
        static WeightUnit ConvertChoiceToUnitsWeight(string choice, Type enumType)
        {
            return (WeightUnit)Enum.GetValues(enumType).GetValue(Convert.ToInt32(choice) - 1);
        }
        
        //Used to return enum of type temperature
        static TemperatureUnit ConvertChoiceToUnitsTemperature(string choice, Type enumType)
        {
            return (TemperatureUnit)Enum.GetValues(enumType).GetValue(Convert.ToInt32(choice) - 1);
        }
        
        //Used to return enum of type volume
        static VolumeUnit ConvertChoiceToUnitsVolume(string choice, Type enumType)
        {
            return (VolumeUnit)Enum.GetValues(enumType).GetValue(Convert.ToInt32(choice) - 1);
        }
        
        // Return the value from the given convert selection
        static string GetEnumValue(string convertChoice, Type enumType)
        {
            int choice = Int32.Parse(convertChoice);
            Array values = Enum.GetValues(enumType);

            if (choice < 1 || choice > values.Length)
                throw new ArgumentException("Choice is out of range.");
            object enumValue = values.GetValue(choice - 1);
            return enumValue.ToString();
        }
        
    }
}