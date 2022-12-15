using CoffeeMachineDataAccess.Interfaces;
using CoffeeMachineDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineDataAccess.Repositories
{
    public class CoffeeTypeRepository : BaseRepository, IRepository<CoffeeType>
    {
        public CoffeeTypeRepository(CoffeeMachineDbContext context) : base(context)
        {
        }

        public IEnumerable<CoffeeType> GetAll()
        {
            return _db.CoffeeTypes;
        }
    }
}
