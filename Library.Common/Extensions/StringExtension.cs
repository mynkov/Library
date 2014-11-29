namespace Library.Common.Extensions
{
    public static class StringExtension
    {
        public static bool HasValue(this string obj)
        {
            return !string.IsNullOrEmpty(obj);
        }
    }
}
