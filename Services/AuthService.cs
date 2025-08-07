using Microsoft.AspNetCore.Http;
using SafeVaultSecureApp.Data;
using SafeVaultSecureApp.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

public class AuthService
{
    private readonly UserRepository _userRepo;

    public AuthService(UserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public bool ValidateUser(string username, string password)
    {
        var user = _userRepo.GetByUsername(username);
        return user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
    }

    public bool RegisterUser(string username, string password)
    {
        if (_userRepo.GetByUsername(username) != null) return false;
        var hash = BCrypt.Net.BCrypt.HashPassword(password);
        return _userRepo.CreateUser(new User { Username = username, PasswordHash = hash, Role = "User" });
    }

    public void SignIn(HttpContext context, string username)
    {
        var claims = new[] { new Claim(ClaimTypes.Name, username) };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity)).Wait();
    }

    public void SignOut(HttpContext context)
    {
        context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
    }
}
