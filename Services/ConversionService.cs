using Unit_Converter_Application.Converters;
using Unit_Converter_Application.Models;

namespace Unit_Converter_Application.Services
{
    public class ConversionService
    {
        public double ConvertLength(double value, LengthUnit from, LengthUnit to)
            => LengthConverter.Convert(value, from, to);
    }
}