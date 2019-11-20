using System;

namespace Lab1_SunnyTravel.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static T? TryToType<T>(this string value) where T : struct
        {
            if (value.IsNullOrEmpty())
                return null;

            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
