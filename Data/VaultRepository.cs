using SafeVaultSecureApp.Models;
using System.Collections.Generic;
using System.Linq;

public class VaultRepository
{
    private readonly SafeVaultDbContext _context;

    public VaultRepository(SafeVaultDbContext context)
    {
        _context = context;
    }

    public List<VaultItem> GetItemsByUser(string username)
    {
        return _context.VaultItems
            .Where(v => v.OwnerUsername == username)
            .OrderByDescending(v => v.CreatedAt)
            .ToList();
    }
}
