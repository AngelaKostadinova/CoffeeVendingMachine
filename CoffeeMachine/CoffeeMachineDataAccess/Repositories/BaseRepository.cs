using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineDataAccess.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly CoffeeMachineDbContext _db;
        public BaseRepository(CoffeeMachineDbContext db)
        {
            _db = db;
        }
    }
}
