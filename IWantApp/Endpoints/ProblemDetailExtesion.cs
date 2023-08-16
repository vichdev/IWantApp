using Microsoft.AspNetCore.Identity;
namespace src.Endpoints;

public static class ProblemDetailExtensions
{

    public static Dictionary<string, string[]> ConvertToProblemDetails(this IEnumerable<IdentityError> error)
    {
        var dictionary = new Dictionary<string, string[]>
        {
            { "Error", error.Select(error => error.Description).ToArray() }
        };

        return dictionary;
    }
}
