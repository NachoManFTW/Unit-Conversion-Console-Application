using System;
using System.Collections.Generic;
using Unit_Converter_Application.Models;

namespace Unit_Converter_Application.Converters
{
    public static class VolumeConverter
    {
        //Ratios of 1 meter to all other length measurements
        private static readonly Dictionary<VolumeUnit, double> ToCubicMeters = new()
        {
            { VolumeUnit.CubicMeter, 1.0 },
            { VolumeUnit.CubicCentimeter, 0.000001 },
            { VolumeUnit.CubicYard, 0.764555 },
            { VolumeUnit.CubicFeet, 0.028317 },
            { VolumeUnit.CubicInch, 0.000016387 }
        };



        // Converts amount of meters to every other type of volume measurement
        public static double Convert(double value, VolumeUnit from, VolumeUnit to)
        {
            // Error handling if key in ToCubicMeters dictionary is not found
            if (!ToCubicMeters.TryGetValue(from, out var fromFactor))
                throw new ArgumentException("Unsupported source unit", nameof(from));
            if (!ToCubicMeters.TryGetValue(to, out var toFactor))
                throw new ArgumentException("Unsupported target unit", nameof(to));

            double valueInCubicMeters = value * fromFactor;
            return valueInCubicMeters / toFactor;


        }
    }
}