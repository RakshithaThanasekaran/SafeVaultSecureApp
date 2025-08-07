using System.Web;

public static class InputSanitizer
{
    public static string Sanitize(string input)
    {
        return HttpUtility.HtmlEncode(input);
    }
}
