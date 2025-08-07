using Xunit;
using SafeVaultSecureApp.Security;

public class XSSTests
{
    [Fact]
    public void Sanitizer_ShouldEscapeScriptTags()
    {
        string input = "<script>alert('XSS')</script>";
        string sanitized = InputSanitizer.Sanitize(input);
        Assert.DoesNotContain("<script>", sanitized);
    }
}
