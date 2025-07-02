using System;


namespace Unit_Converter_Application.Models
{
    public enum SystemUnit
    {
        Length,
        Weight,
        Temperature,
        Volume
    }

    public enum LengthUnit
    {
        Meters,
        Feet,
        Inches,
        Miles,
        Milimeters,
        Centimeters,
        Yards
    }

    public enum WeightUnit
    {
        Stone,
        Kilogram,
        Gram,
        Ton,
        Pound,
        Ounce,
    }

    public enum TemperatureUnit
    {
        Celsius,
        Fahrenheit,
        Kelvin
    }
}