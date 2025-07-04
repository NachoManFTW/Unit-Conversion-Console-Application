using System;
using System.ComponentModel.DataAnnotations;


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

    public enum VolumeUnit
    {
        [Display(Name = "Cubic Feet")]
        CubicFeet,
        [Display(Name = "Cubic Yard")]
        CubicYard,
        [Display(Name = "Cubic Inch")]
        CubicInch,
        [Display(Name = "Cubic Centimeter")]
        CubicCentimeter,
        [Display(Name = "Cubic Meter")]
        CubicMeter,
    }
}