using CoffeeMachineDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineServices.Interfaces
{
    public interface ITypeIngredientIntensityService
    {
        void DisplayIngredientsByCoffeeType(StringBuilder builder, int coffeeTypeId);
    }
}
