using System;


namespace StandardLib.Extensions
{
    public static class ConversionExtensions
    {
        public static T ConvertValue<T>(this object value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
