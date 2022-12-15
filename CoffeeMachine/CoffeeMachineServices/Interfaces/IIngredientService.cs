using CoffeeMachineDomain.Models;

namespace CoffeeMachineServices.Interfaces
{
    public interface IIngredientService
    {
        List<Ingredient> GetAll();
    }
}
