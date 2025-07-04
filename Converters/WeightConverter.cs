using System;
using System.Collections.Generic;
using Unit_Converter_Application.Models;

namespace Unit_Converter_Application.Converters
{
    public static class WeightConverter
    {
        //Ratios of 1 kilogram to all other weight measurements
        private static readonly Dictionary<WeightUnit, double> ToKilogram = new()
        {
            { WeightUnit.Kilogram, 1.0 },
            { WeightUnit.Gram, 0.001 },
            { WeightUnit.Stone, 6.350293 },
            { WeightUnit.Ton, 907.18474 },
            { WeightUnit.Pound, 0.453592},
            { WeightUnit.Ounce, 0.02835}

        };



        // Converts amount of kilograms to every other type of weight measurement
        public static double Convert(double value, WeightUnit from, WeightUnit to)
        {
            // Error handling if key in ToKilograms dictionary is not found
            if (!ToKilogram.TryGetValue(from, out var fromFactor))
                throw new ArgumentException("Unsupported source unit", nameof(from));
            if (!ToKilogram.TryGetValue(to, out var toFactor))
                throw new ArgumentException("Unsupported target unit", nameof(to));

            double valueInKilograms = value * fromFactor;
            return valueInKilograms / toFactor;


        }
    }
}