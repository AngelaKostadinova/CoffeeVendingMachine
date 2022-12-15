using CoffeeMachineDomain.Models;
using CoffeeMachineServices.Interfaces;
using CoffeeMachineServices.Services;

namespace CoffeeMachineServices.Helpers
{
    public class CoffeeBuilder : ICoffeeBuilder
    {
        private Coffee _coffee = new Coffee();

        private readonly ICoffeeTypeService _coffeeTypeService;
        public CoffeeBuilder()
        {
            _coffeeTypeService = DIModule.GetService<ICoffeeTypeService>();
            _coffee.CoffeeType = new CoffeeType();
            _coffee.CoffeeType.TypeIngredientIntensities = new List<TypeIngredientIntensity>();
        }
        public ICoffeeBuilder SetIngridient(int ingridientId)
        {
            _coffee.CoffeeType.TypeIngredientIntensities.Add(new TypeIngredientIntensity()
            {
                IngredientId = ingridientId,
                CoffeeTypeId = _coffee.CoffeeTypeId,
            });

            return this;
        }

        public ICoffeeBuilder SetType(string typeName)
        {
            var lastCoffeeTypeId = _coffeeTypeService.GetAll().LastOrDefault().Id;
            _coffee.CoffeeType.Name = typeName;
            _coffee.CoffeeTypeId = lastCoffeeTypeId + 1;
            _coffee.Description = "Base caffee with custom ingredients";
            _coffee.CoffeeType.Price = 10;
            return this;
        }

        public ICoffeeBuilder SetBaseIngridientsAndIntensities()
        {
            _coffee.CoffeeType.TypeIngredientIntensities.Add(new TypeIngredientIntensity()
            {
                IngredientId = 6,
                IntensityId = 2,
                CoffeeTypeId = _coffee.CoffeeTypeId,
            });

            return this;
        }

        public void BuildNewCoffeeType(ICoffeeBuilder builder, int ingridientId, int intensityId, string typeName)
        {
            builder.SetType(typeName)
                   .SetIngridient(ingridientId)
                   .SetIntensity(intensityId);
        }

        public ICoffeeBuilder SetIntensity(int intensityId)
        {
            _coffee.CoffeeType.TypeIngredientIntensities.LastOrDefault().IntensityId = intensityId;

            return this;
        }
        public Coffee Build() => _coffee;
    }
}
