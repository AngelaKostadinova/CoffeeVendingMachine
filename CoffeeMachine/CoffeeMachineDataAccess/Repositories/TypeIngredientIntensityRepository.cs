using CoffeeMachineDataAccess.Interfaces;
using CoffeeMachineDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineDataAccess.Repositories
{
    public class TypeIngredientIntensityRepository : BaseRepository, IRepository<TypeIngredientIntensity>
    {
        public TypeIngredientIntensityRepository(CoffeeMachineDbContext context) : base(context) { }

        public IEnumerable<TypeIngredientIntensity> GetAll()
        {
            return _db.TypeIngredientIntensities.Include(x => x.Ingredient)
                                                .Include(x => x.Intensity)
                                                .Include(x => x.CoffeeType)
                                                .ToList();
        }
    }
}
