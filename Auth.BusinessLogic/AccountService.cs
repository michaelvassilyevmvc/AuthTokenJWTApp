using Auth.Persistence;

namespace Auth.BusinessLogic;

public class AccountService(AccountRepository accountRepository)
{
    public void Register(string requestUserName, string requestFirstName, string requestPassword)
    {
        // accountRepository.Add(account);
    }

    public void Login(string userName, string firstName, string password)
    {
        
    }
}