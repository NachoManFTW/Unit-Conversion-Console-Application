using System;
using System.Collections.Generic;
using Unit_Converter_Application.Models;

namespace Unit_Converter_Application.Converters
{
    public static class LengthConverter
    {
        //Ratios of 1 meter to all other length measurements
        private static readonly Dictionary<LengthUnit, double> ToMeters = new()
    {
        { LengthUnit.Meters, 1.0 },
        { LengthUnit.Feet, 0.3048 },
        { LengthUnit.Inches, 0.0254 },
        { LengthUnit.Miles, 1609.34 }

    };



        // Converts amount of meters to every other type of legnth measurement
        public static double Convert(double value, LengthUnit from, LengthUnit to)
        {
            // Error handling if key in ToMeters dictionary is not found
            if (!ToMeters.TryGetValue(from, out var fromFactor))
                throw new ArgumentException("Unsupported source unit", nameof(from));
            if (!ToMeters.TryGetValue(to, out var toFactor))
                throw new ArgumentException("Unsupported target unit", nameof(to));

            double valueInMeters = value * fromFactor;
            return valueInMeters / toFactor;


        }
    }
}
