using Microsoft.AspNetCore.Mvc;
using SafeVaultSecureApp.Services;
using SafeVaultSecureApp.Security;

public class VaultController : Controller
{
    private readonly VaultService _vaultService;

    public VaultController(VaultService vaultService)
    {
        _vaultService = vaultService;
    }

    public IActionResult Index()
    {
        var username = User.Identity.Name;
        var items = _vaultService.GetVaultItems(username);
        return View(items);
    }
}
