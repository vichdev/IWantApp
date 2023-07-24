using IWantApp.Domain.Products;
using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categories;

public class CategoryGetAll
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(AplicationDbContext context)
    {

        var categories = context.Categories.ToList();
        var response = categories.Select(category => new CategoryResponse { Name = category.Name, Active = category.Active });

        return Results.Ok(response);

    }

}
