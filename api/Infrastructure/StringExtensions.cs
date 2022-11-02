using System.Text.RegularExpressions;

namespace Infrastructure;

public static class StringExtensions
{
    private static readonly Regex LineBreakRegex = new(@"(\r\n|\r|\n)+");
    private static readonly Regex DoubleSpacesRegex = new(@"\s{2,}");
    
    public static string RemoveLineBreaks(this string input)
    {
        return LineBreakRegex.Replace(input, " ");
    }

    public static string RemoveDoubleSpaces(this string input)
    {
        return DoubleSpacesRegex.Replace(input, " ");
    }
}