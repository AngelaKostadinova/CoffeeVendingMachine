using CoffeeMachineDataAccess.Interfaces;
using CoffeeMachineDomain.Models;
using CoffeeMachineServices.Helpers;
using CoffeeMachineServices.Interfaces;

namespace CoffeeMachineServices.Services
{
    public class CoffeeService : ICoffeeService
    {
        protected readonly ICoffeeRepository _coffeeRepository;

        public CoffeeService(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        public void CreateNewCoffeeType(CoffeeBuilder builder)
        {
            try
            {
                builder.SetBaseIngridientsAndIntensities();
                var coffee = builder.Build();
                _coffeeRepository.Insert(coffee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Coffee> GetAll()
        {
            try
            {
                List<Coffee> coffies = _coffeeRepository.GetAll().OrderBy(x => x.Id).ToList();

                return coffies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Coffee GetById(int id)
        {
            try
            {
                return _coffeeRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
