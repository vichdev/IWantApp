using Flunt.Validations;
namespace IWantApp.Domain.Products;
public class Category : Entity
{
    public Category(string name) {

        var contract = new Contract<Category>().IsNotNullOrEmpty(name, "Name", "Name is required");

        AddNotifications(contract);

        Name = name;

}

}
