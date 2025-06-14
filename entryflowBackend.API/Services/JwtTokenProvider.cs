using System.Security.Claims;
using System.Text;
using entryflowBackend.API.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace entryflowBackend.API.Services;

public class JwtTokenProvider(IConfiguration config)
{
    public string Create(Admin admin)
    {
        string secretKey = config["Jwt:SecretKey"];
        if (string.IsNullOrEmpty(secretKey))
            throw new InvalidOperationException("JWT SecretKey is not configured.");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptior = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(JwtRegisteredClaimNames.Sub, admin.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, admin.Email)
            ]),
            Expires = DateTime.Now.AddHours(1),
            SigningCredentials = credentials,
            Issuer = config["Jwt:Issuer"],
            Audience = config["Jwt:Audience"],
        };
        
        var tokenHandler = new JsonWebTokenHandler();
        
        string token = tokenHandler.CreateToken(tokenDescriptior);

        return token;
    }
}