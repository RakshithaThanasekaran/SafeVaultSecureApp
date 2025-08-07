using Microsoft.AspNetCore.Mvc;
using SafeVaultSecureApp.Services;
using SafeVaultSecureApp.Models;

public class AccountController : Controller
{
    private readonly AuthService _authService;

    public AccountController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (_authService.ValidateUser(username, password))
        {
            _authService.SignIn(HttpContext, username);
            return RedirectToAction("Index", "Vault");
        }

        ViewBag.Error = "Invalid credentials.";
        return View();
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(string username, string password)
    {
        if (_authService.RegisterUser(username, password))
        {
            return RedirectToAction("Login");
        }

        ViewBag.Error = "Registration failed.";
        return View();
    }

    public IActionResult Logout()
    {
        _authService.SignOut(HttpContext);
        return RedirectToAction("Login");
    }
}
