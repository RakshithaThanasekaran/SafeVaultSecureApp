using SafeVaultSecureApp.Data;
using SafeVaultSecureApp.Models;

public class VaultService
{
    private readonly VaultRepository _vaultRepo;

    public VaultService(VaultRepository vaultRepo)
    {
        _vaultRepo = vaultRepo;
    }

    public List<VaultItem> GetVaultItems(string username)
    {
        return _vaultRepo.GetItemsByUser(username);
    }
}
