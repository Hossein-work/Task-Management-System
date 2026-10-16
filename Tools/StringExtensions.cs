static class StringExtensions
{
    private const byte maxLenghtOfTitle = 20;
    internal static string Truncate(this string input)
    => input.Length > maxLenghtOfTitle ? input.Substring(0,maxLenghtOfTitle) + "..." : input; 
}