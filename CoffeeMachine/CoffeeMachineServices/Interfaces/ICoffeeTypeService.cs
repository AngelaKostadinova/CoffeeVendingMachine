using CoffeeMachineDomain.Models;

namespace CoffeeMachineServices.Interfaces
{
    public interface ICoffeeTypeService
    {
        List<CoffeeType> GetAll();
    }
}
