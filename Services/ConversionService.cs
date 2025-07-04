using Unit_Converter_Application.Converters;
using Unit_Converter_Application.Models;

namespace Unit_Converter_Application.Services
{
    public class ConversionService
    {
        public double ConvertLength(double value, LengthUnit from, LengthUnit to)
            => LengthConverter.Convert(value, from, to);

        public double ConvertWeight(double value, WeightUnit from, WeightUnit to)
            => WeightConverter.Convert(value, from, to);
        
        public double ConvertTemperature(double value, TemperatureUnit from, TemperatureUnit to)
            => TemperatureConverter.Convert(value, from, to);

        public double ConvertVolume(double value, VolumeUnit from, VolumeUnit to)
            => VolumeConverter.Convert(value, from, to);
    }
}