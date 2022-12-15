using CoffeeMachineDomain.Models;
using CoffeeMachineServices.Helpers;
using CoffeeMachineServices.Interfaces;
using System.Text;

namespace CoffeeMachineServices.Services
{
    public class UIService : IUIService
    {
        private readonly ICoffeeService _coffeeService;
        private readonly ITypeIngredientIntensityService _typeIngredientIntensityService;
        private readonly IIngredientService _ingredientService;
        private readonly IIntensityService _intensityService;


        public UIService()
        {
            _coffeeService = DIModule.GetService<ICoffeeService>();
            _ingredientService = DIModule.GetService<IIngredientService>();
            _intensityService = DIModule.GetService<IIntensityService>();
            _typeIngredientIntensityService = DIModule.GetService<ITypeIngredientIntensityService>();
        }

        public void DisplayMenu()
        {
            var coffeeOptions = _coffeeService.GetAll();

            var builder = new StringBuilder();
            var manuNumber = 1;
            builder.AppendLine("Menu");
            builder.AppendLine();

            foreach (var option in coffeeOptions)
            {
                builder.AppendFormat("{0}.{1} | price:{2}$ - with ingredients: ", manuNumber, option.CoffeeType.Name, option.CoffeeType.Price);
                _typeIngredientIntensityService.DisplayIngredientsByCoffeeType(builder, option.CoffeeTypeId);
                builder.AppendLine();
                manuNumber++;
            }
            builder.AppendFormat("{0}.{1}", manuNumber, "Create custom type of coffee");
            builder.AppendLine();
            builder.AppendLine();
            builder.Append("Choose an option number: ");
            Console.Write(builder);
        }

        public Coffee ProcessMenuSelectedOption()
        {
            var builder = new StringBuilder();
            var validationHelper = new ValidationHelper();
            var selectedOption = validationHelper.ValidateNumber();

            var selectedCoffee = _coffeeService.GetById(selectedOption);

            if (selectedCoffee is not null)
            {
                Console.Clear();
                builder.AppendFormat("{0}|{1}-{2}", $"You selected:{selectedCoffee.CoffeeType.Name}", $"Total price is:{selectedCoffee.CoffeeType.Price}$", "Enjoy your coffee!");
                Console.Write(builder);
            }
            else
            {
                Console.Clear();
            }

            return selectedCoffee;
        }

        public void DisplayIngredients()
        {
            var allIngredients = _ingredientService.GetAll();

            var manuNumber = 1;

            foreach (var ingredient in allIngredients)
            {
                Console.WriteLine(string.Format("{0}.{1}-Price:{2}$", manuNumber, ingredient.Name, ingredient.Price));
                manuNumber++;
            }
        }

        public void DisplayIntensities()
        {
            var allIntensities = _intensityService.GetAll();
            Console.WriteLine("Choose from 1 to 5 scale of ingredient intensity: ");
            foreach (var intensity in allIntensities)
            {
                Console.Write(string.Format("{0}{1}", intensity.IntensityNumber, " "));
            }
        }

        public string ChooseCoffeeTypeName()
        {
            Console.Clear();
            Console.WriteLine("Please write the name of your custom coffee type: ");
            var typeName = Console.ReadLine();
            return typeName;
        }

        public int GetSelectedOption()
        {
            var validationHelper = new ValidationHelper();
            var selectedOption = validationHelper.ValidateNumber();

            return selectedOption;
        }
    }
}
