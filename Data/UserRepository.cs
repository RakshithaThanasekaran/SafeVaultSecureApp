using SafeVaultSecureApp.Models;
using System.Linq;

public class UserRepository
{
    private readonly SafeVaultDbContext _context;

    public UserRepository(SafeVaultDbContext context)
    {
        _context = context;
    }

    public User GetByUsername(string username)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username);
    }

    public bool CreateUser(User user)
    {
        _context.Users.Add(user);
        return _context.SaveChanges() > 0;
    }
}
