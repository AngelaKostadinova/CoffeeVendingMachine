using CoffeeMachineDomain.Models;
using CoffeeMachineServices.Helpers;
using CoffeeMachineServices.Interfaces;
using System.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        DIModule.RegisterModule();
        var uiService = DIModule.GetService<IUIService>();
        var coffeeService = DIModule.GetService<ICoffeeService>();

        var builder = new CoffeeBuilder();
        uiService.DisplayMenu();
        var selectedCoffee = uiService.ProcessMenuSelectedOption();
        int ingredientsCounter = 0;
        var typeName = string.Empty;

        if (selectedCoffee == null)
        {
            while (true)
            {
                Console.WriteLine("Please select ingredient by menu number: ");
                uiService.DisplayIngredients();
                var selectedIngridientId = uiService.GetSelectedOption();
                Console.Clear();
                uiService.DisplayIntensities();
                Console.WriteLine();
                var selectedIntensityId = uiService.GetSelectedOption();
                if (ingredientsCounter == 0)
                {
                    typeName = uiService.ChooseCoffeeTypeName();
                }
                builder.BuildNewCoffeeType(builder, selectedIngridientId, selectedIntensityId, typeName);
                ingredientsCounter++;
                Console.WriteLine("Do you want to add more ingridients? Y/N");
                if (Console.ReadLine().ToUpper() == "N")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            coffeeService.CreateNewCoffeeType(builder);
            Console.WriteLine("Enjoy your custom coffee type!");
        }
    }
}