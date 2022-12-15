using CoffeeMachineDataAccess.Interfaces;
using CoffeeMachineDomain.Models;
using CoffeeMachineServices.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace CoffeeMachineServices.Services
{
    public class IngredientService : IIngredientService
    {
        protected readonly IRepository<Ingredient> _ingredientRepository;

        public IngredientService(IRepository<Ingredient> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public List<Ingredient> GetAll()
        {
            try
            {
                return _ingredientRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
