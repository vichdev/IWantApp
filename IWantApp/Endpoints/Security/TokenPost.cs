﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace src.Endpoints.Security;

public class TokenPost
{
    public static string Template => "/token";
    public static string[] Methods => new string[] {HttpMethod.Post.ToString()};
    public static Delegate Handle => Action;
    [AllowAnonymous]
    public static async Task<IResult> Action(LoginRequest loginRequest, IConfiguration configuration, UserManager<IdentityUser> userManager) 
    { 
        var user = await userManager.FindByNameAsync(loginRequest.Phone);
        Console.WriteLine(loginRequest.Phone);
        if (user == null) return Results.BadRequest();
        if(!await userManager.CheckPasswordAsync(user, loginRequest.Password)) return Results.BadRequest();
        var key = Encoding.ASCII.GetBytes(configuration["JwtBearerTokenSettings:SecretKey"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.MobilePhone, loginRequest.Phone) }),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Audience = configuration["JwtBearerTokenSettings:Audience"],
            Issuer = configuration["JwtBearerTokenSettings:Issuer"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Results.Ok(new
        {
            token = tokenHandler.WriteToken(token),
        });

    }
}


