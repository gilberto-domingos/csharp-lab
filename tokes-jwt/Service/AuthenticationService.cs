using JwtBearer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtBearer.Config;
using Microsoft.IdentityModel.Tokens;

namespace JwtBearer.Service;

public class AuthenticationService
{
    public string Generater(User user)
    {
        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(Configuration.Privatekey);

       var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

       var tokenDescriptor = new SecurityTokenDescriptor
       { 
           Subject = GeneraticClaims(user),
           SigningCredentials = credentials,
           Expires = DateTime.UtcNow.AddHours(2)
       };

        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }

    private static ClaimsIdentity GeneraticClaims(User user)
    {
        var ci = new ClaimsIdentity();
        ci.AddClaim(new Claim(ClaimTypes.Name, user.Email));
        foreach (var roles in user.Roles)
                 ci.AddClaim(new Claim(ClaimTypes.Role, roles));
        
        ci.AddClaim((new Claim("TypeKey","ValueKey")));
        
        return ci;
    }
    
}