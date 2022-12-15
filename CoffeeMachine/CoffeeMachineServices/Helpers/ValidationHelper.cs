using CoffeeMachineServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineServices.Helpers
{
    public class ValidationHelper
    {
        private readonly ICoffeeTypeService _coffeeTypeService;
        public ValidationHelper()
        {
            _coffeeTypeService = DIModule.GetService<ICoffeeTypeService>();
        }
        public int ValidateNumber()
        {
            int selectedOption;
            var lastCoffeeTypeId = _coffeeTypeService.GetAll().LastOrDefault().Id;
            while (!int.TryParse(Console.ReadLine(), out selectedOption) || selectedOption <= 0 || selectedOption > lastCoffeeTypeId + 1)
            {
                Console.Write("Please choose a number from the menu: ");
            }
            return selectedOption;
        }
    }
}
