using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace StandardLib.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string source)
        {
            var normal = source.ToLowerInvariant();
            return Char.ToUpperInvariant(normal[0]) + normal.Substring(1);
        }
        public static string ToJsonPropertyName(this string source)
        {
            var value = Char.ToLowerInvariant(source[0]) + source.Substring(1);
            // Strip whitespace
            value.Trim();
            value = value.Replace(" ", "");
            // Strip all non word characters
            Regex.Replace(value, @"^\w", "");

            return value;
        }
        public static string ToTitleCase(this string source, bool inPlace = false)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var res = source.ToLowerInvariant();
            if (inPlace) { source = textInfo.ToTitleCase(res); }

            return textInfo.ToTitleCase(res);
        }
        public static string ToSnakeCase(this string source)
        {
            var temp = source.SanitizeString().ToLower();
            return temp.Replace(" ", "-");
        }
        public static string SanitizeString(this string source, bool inPlace = false)
        {
            var value = source.Trim();
            Regex.Replace(value, @"^\w", "");
            if (inPlace)
            {
                source = value;
            }
            return value;
        }
        public static string AddPadding<TIn>(this TIn source, char paddingCharacter, int totalLength)
        {
            // Set base string
            var baseStr = source.ToString();
            while(baseStr.Length < totalLength)
            {
                baseStr = paddingCharacter + baseStr;
            }
            return baseStr;
        }
    }
}
