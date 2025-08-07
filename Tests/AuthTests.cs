using Xunit;
using SafeVaultSecureApp.Services;
using SafeVaultSecureApp.Data;
using Moq;

public class AuthTests
{
    [Fact]
    public void ValidateUser_ShouldReturnFalseForWrongPassword()
    {
        var repo = new Mock<UserRepository>(null);
        repo.Setup(r => r.GetByUsername("test")).Returns(new Models.User { Username = "test", PasswordHash = BCrypt.Net.BCrypt.HashPassword("correct") });

        var service = new AuthService(repo.Object);
        bool result = service.ValidateUser("test", "wrong");
        Assert.False(result);
