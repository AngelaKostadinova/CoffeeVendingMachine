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
    public class IngredientRepository : BaseRepository, IRepository<Ingredient>
    {
        public IngredientRepository(CoffeeMachineDbContext context) : base(context) { }

        public IEnumerable<Ingredient> GetAll() => _db.Ingredients;

    }
}
