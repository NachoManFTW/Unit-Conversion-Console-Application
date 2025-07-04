using System;
using System.Collections.Generic;
using Unit_Converter_Application.Models;

namespace Unit_Converter_Application.Converters
{
    public static class TemperatureConverter
    {
        // Contains
        private static readonly TemperatureUnit[] ToCelsius = new TemperatureUnit[]
        { 
            TemperatureUnit.Celsius,
            TemperatureUnit.Fahrenheit,
            TemperatureUnit.Kelvin,
        };



        // Converts amount of meters to every other type of temperature measurement
        public static double Convert(double value, TemperatureUnit from, TemperatureUnit to)
        {
            // Error handling if key in ToCelsius dictionary is not found
            if (!ToCelsius.Contains(from))
                throw new ArgumentException("Unsupported source unit", nameof(from));
            if (!ToCelsius.Contains(to))
                throw new ArgumentException("Unsupported target unit", nameof(to));

            //Funky switch case for incoming requests for conversions
            switch (from)
            {
                case TemperatureUnit.Celsius:
                    switch (to)
                    {
                        case TemperatureUnit.Fahrenheit:
                            return (value * 9 / 5) + 32;

                        case TemperatureUnit.Kelvin:
                            return value + 273.15;
                    }
                    break;
                case TemperatureUnit.Fahrenheit:
                    switch (to)
                    {
                        case TemperatureUnit.Kelvin:
                            return ((value - 32) * 5 / 9) + 273.15;
                        case TemperatureUnit.Celsius:
                            return (value - 32) * 5 / 9;
                    }
                    break;
                case TemperatureUnit.Kelvin:
                    switch (to)
                    {
                        case TemperatureUnit.Fahrenheit:
                            return ((value - 32) * 5 / 9) + 273.15;
                        case TemperatureUnit.Celsius:
                            return value - 273.15;
                    }
                    break;
            }
            return 0;
        }
    }
}