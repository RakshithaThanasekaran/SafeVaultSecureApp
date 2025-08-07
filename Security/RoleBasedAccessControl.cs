using Microsoft.AspNetCore.Http;
using SafeVaultSecureApp.Data;

public class RoleBasedAccessControl
{
    private readonly UserRepository _userRepo;

    public RoleBasedAccessControl(UserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public bool IsUserInRole(HttpContext context, string role)
    {
        var username = context.User.Identity.Name;
        var user = _userRepo.GetByUsername(username);
        return user != null && user.Role == role;
    }
}
