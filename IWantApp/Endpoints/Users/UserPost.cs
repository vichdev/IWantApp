using Microsoft.AspNetCore.Identity;
using src.Endpoints;
using src.Endpoints.Employees;

namespace IWantApp.Endpoints.Employees;

public class UserPost
{
    public static string Template => "/users";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(UserRequest userRequest, UserManager<IdentityUser> userManager)
    {

        var user = new IdentityUser { UserName = userRequest.Phone, PhoneNumber = userRequest.Phone,};

        var result = userManager.CreateAsync(user).Result;

        if(!result.Succeeded)
        {
            return Results.ValidationProblem(result.Errors.ConvertToProblemDetails());
        }

        return Results.Created($"/users/{user.Id}", user.Id);
  
    }

}
