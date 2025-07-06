using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Unit_Converter_Application.Utilities
{
    public class EnumExtension
    {
        public string GetDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field?.GetCustomAttribute<DisplayAttribute>();
            return attr?.Name ?? value.ToString();
        }
    }
}