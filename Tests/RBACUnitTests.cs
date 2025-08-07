using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using SafeVaultSecureApp.Data;
using SafeVaultSecureApp.Models;
using SafeVaultSecureApp.Security;

public class RBACUnitTests
{
    [Fact]
    public void IsUserInRole_ShouldReturnTrue_ForAdminUser()
    {
        // Arrange
        var userRepoMock = new Mock<UserRepository>(null);
        userRepoMock.Setup(repo => repo.GetByUsername("adminUser"))
            .Returns(new User { Username = "adminUser", Role = "Admin" });

        var context = new DefaultHttpContext();
        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "adminUser") });
        context.User = new ClaimsPrincipal(identity);

        var rbac = new RoleBasedAccessControl(userRepoMock.Object);

        // Act
        bool isAdmin = rbac.IsUserInRole(context, "Admin");

        // Assert
        Assert.True(isAdmin);
    }

    [Fact]
    public void IsUserInRole_ShouldReturnFalse_ForNonAdminUser()
    {
        // Arrange
        var userRepoMock = new Mock<UserRepository>(null);
        userRepoMock.Setup(repo => repo.GetByUsername("regularUser"))
            .Returns(new User { Username = "regularUser", Role = "User" });

        var context = new DefaultHttpContext();
        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "regularUser") });
        context.User = new ClaimsPrincipal(identity);

        var rbac = new RoleBasedAccessControl(userRepoMock.Object);

        // Act
        bool isAdmin = rbac.IsUserInRole(context, "Admin");

        // Assert
        Assert.False(isAdmin);
    }

    [Fact]
    public void IsUserInRole_ShouldReturnFalse_IfUserNotFound()
    {
        // Arrange
        var userRepoMock = new Mock<UserRepository>(null);
        userRepoMock.Setup(repo => repo.GetByUsername("ghostUser")).Returns((User)null);

        var context = new DefaultHttpContext();
        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "ghostUser") });
        context.User = new ClaimsPrincipal(identity);

        var rbac = new RoleBasedAccessControl(userRepoMock.Object);

        // Act
        bool isAdmin = rbac.IsUserInRole(context, "Admin");

        // Assert
        Assert.False(isAdmin);
    }
}
