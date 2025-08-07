using Microsoft.EntityFrameworkCore;
using SafeVaultSecureApp.Models;

public class SafeVaultDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<VaultItem> VaultItems { get; set; }

    public SafeVaultDbContext(DbContextOptions<SafeVaultDbContext> options) : base(options) { }
}
