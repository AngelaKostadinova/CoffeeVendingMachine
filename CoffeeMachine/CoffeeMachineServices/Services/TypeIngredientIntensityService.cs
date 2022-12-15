using CoffeeMachineDataAccess.Interfaces;
using CoffeeMachineDomain.Models;
using CoffeeMachineServices.Interfaces;
using System.Text;

namespace CoffeeMachineServices.Services
{
    public class TypeIngredientIntensityService : ITypeIngredientIntensityService
    {
        protected readonly IRepository<TypeIngredientIntensity> _typeIngredientIntensitiesRepository;

        public TypeIngredientIntensityService(IRepository<TypeIngredientIntensity> typeIngredientIntensitiesRepository)
        {
            _typeIngredientIntensitiesRepository = typeIngredientIntensitiesRepository;
        }
        public void DisplayIngredientsByCoffeeType(StringBuilder builder, int coffeeTypeId)
        {
            try
            {
               var ingredientsByCoffeeType = _typeIngredientIntensitiesRepository.GetAll()
                                                                                 .Where(x => x.CoffeeTypeId == coffeeTypeId)
                                                                                 .Select(x => x.Ingredient)
                                                                                 .ToList();
                foreach (var ingredient in ingredientsByCoffeeType)
                {
                    builder.AppendFormat("{0}{1}",ingredient.Name, " ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
