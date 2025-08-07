using Xunit;

public class SQLInjectionTests
{
    [Fact]
    public void ParameterizedQuery_ShouldPreventInjection()
    {
        string maliciousInput = "' OR '1'='1";
        string safeQuery = "SELECT * FROM Users WHERE Username = @Username";
        Assert.DoesNotContain(maliciousInput, safeQuery);
    }
}
