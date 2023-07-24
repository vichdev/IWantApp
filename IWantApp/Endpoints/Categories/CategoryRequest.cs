using IWantApp.Domain.Products;

namespace IWantApp.Endpoints.Categories;

public record CategoryRequest(string Name, bool Active);