static class StringExtensions
{
    private const byte maxLenghtOfTitle = 20;
    public static bool Truncate(int length)
    => length > maxLenghtOfTitle; 
}