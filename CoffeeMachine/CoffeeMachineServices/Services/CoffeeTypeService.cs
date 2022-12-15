using CoffeeMachineDataAccess.Interfaces;
using CoffeeMachineDomain.Models;
using CoffeeMachineServices.Interfaces;

namespace CoffeeMachineServices.Services
{
    public class CoffeeTypeService : ICoffeeTypeService
    {
        protected readonly IRepository<CoffeeType> _coffeeTypeRepository;

        public CoffeeTypeService(IRepository<CoffeeType> coffeeRepository)
        {
            _coffeeTypeRepository = coffeeRepository;
        }
        public List<CoffeeType> GetAll()
        {
            try
            {
                return _coffeeTypeRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
