using CoffeeMachineDomain.Models;

namespace CoffeeMachineServices.Interfaces
{
    public interface IUIService
    {
        void DisplayMenu();

        Coffee ProcessMenuSelectedOption();

        void DisplayIngredients();

        void DisplayIntensities();

        int GetSelectedOption();
        string ChooseCoffeeTypeName();
    }
}
