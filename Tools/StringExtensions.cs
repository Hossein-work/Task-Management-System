static class StringExtensions
{
    private const byte maxLenghtOfTitle = 20;
    public static string Truncate(this string input)
    => input.Length > maxLenghtOfTitle ? "..." : input; 
}