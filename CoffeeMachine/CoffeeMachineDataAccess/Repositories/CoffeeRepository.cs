using CoffeeMachineDataAccess.Interfaces;
using CoffeeMachineDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMachineDataAccess.Repositories
{
    public class CoffeeRepository : BaseRepository, ICoffeeRepository
    {
        public CoffeeRepository(CoffeeMachineDbContext context) : base(context) { }
        public IEnumerable<Coffee> GetAll()
        {
            return _db.Coffees.Include(x => x.CoffeeType).ThenInclude(x => x.TypeIngredientIntensities)
                                                         .ThenInclude(x => x.Ingredient)
                                                         .ThenInclude(x => x.TypeIngredientIntensities)
                                                         .ThenInclude(x => x.Intensity)
                                                         .ToList();
        }

        public Coffee GetById(int id)
        {
            return _db.Coffees.Include(x => x.CoffeeType).ThenInclude(x => x.TypeIngredientIntensities)
                                                         .ThenInclude(x => x.Ingredient)
                                                         .ThenInclude(x => x.TypeIngredientIntensities)
                                                         .ThenInclude(x => x.Intensity)
                                                         .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Coffee entity)
        {
            _db.Coffees.Add(entity);
            _db.SaveChanges();
        }
    }
}
