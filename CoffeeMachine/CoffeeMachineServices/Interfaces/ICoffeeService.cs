using CoffeeMachineDomain.Models;
using CoffeeMachineServices.Helpers;

namespace CoffeeMachineServices.Interfaces
{
    public interface ICoffeeService
    {
        List<Coffee> GetAll();
        Coffee GetById(int id);
        void CreateNewCoffeeType(CoffeeBuilder builder);
    }
}
