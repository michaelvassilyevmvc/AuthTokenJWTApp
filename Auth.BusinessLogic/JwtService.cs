using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Auth.Persistence.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Auth.BusinessLogic;

public class JwtService(IOptions<AuthSettings> settings)
{
    public string GenerateToken(Account account)
    {
        // Claim это та часть что попадает в payload в JWT
        var claims = new List<Claim>
        {
            new Claim("userName", account.UserName),
            new Claim("firstName", account.FirstName),
            new Claim("id",account.Id.ToString())
        };
        var jwtToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.Add(settings.Value.Expires),
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Value.SecretKey)),
                                                    SecurityAlgorithms.HmacSha256)
            );
        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}