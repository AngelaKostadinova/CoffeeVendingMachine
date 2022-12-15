using CoffeeMachineDataAccess.Interfaces;
using CoffeeMachineDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineDataAccess.Repositories
{
    public class IntensityRepository : BaseRepository, IRepository<Intensity>
    {
        public IntensityRepository(CoffeeMachineDbContext context) : base(context)
        {
        }

        public IEnumerable<Intensity> GetAll()
        {
            return _db.Intensities;
        }
    }
}
