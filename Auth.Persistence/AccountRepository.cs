using Auth.Persistence.Models;

namespace Auth.Persistence;

public class AccountRepository
{
    private static Dictionary<string, Account> Accounts = new Dictionary<string, Account>();

    public void Add(Account account)
    {
        Accounts[account.UserName] = account;
    }

    public Account? GetByUserName(string userName)
    {
        return Accounts.TryGetValue(userName, out Account account) ? account : null;
    }
}