namespace Hospital_Management.Extensions
{
    public static class StringExtensions
    {
        public static string GetShort(this string value, int maxValue = 20)
            => value.Length > maxValue ? string.Concat(value.AsSpan(0, 20), "...") 
            : value;
    }
}
