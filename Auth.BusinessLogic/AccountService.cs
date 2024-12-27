using Auth.Persistence;
using Auth.Persistence.Models;
using Microsoft.AspNetCore.Identity;

namespace Auth.BusinessLogic;

public class AccountService(AccountRepository accountRepository, JwtService jwtService)
{
    public void Register(string requestUserName, string requestFirstName, string requestPassword)
    {
        var newAccount = new Account
        {
            UserName = requestUserName,
            FirstName = requestFirstName,
            Id = Guid.NewGuid(),
        };
        var passHash = new PasswordHasher<Account>().HashPassword(newAccount, requestPassword);
        newAccount.PasswordHash = passHash;
        accountRepository.Add(newAccount);
    }

    public string Login(string userName,  string password)
    {
        var account = accountRepository.GetByUserName(userName);
        var result = new PasswordHasher<Account>().VerifyHashedPassword(account, account.PasswordHash, password);
        if (result == PasswordVerificationResult.Success)
        {
            // generate token
            return jwtService.GenerateToken(account);
        }
        else
        {
            throw new Exception("Unathorized");
        }
    }
}