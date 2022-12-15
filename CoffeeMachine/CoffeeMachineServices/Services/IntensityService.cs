using CoffeeMachineDataAccess.Interfaces;
using CoffeeMachineDataAccess.Repositories;
using CoffeeMachineDomain.Models;
using CoffeeMachineServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineServices.Services
{
    public class IntensityService : IIntensityService
    {
        protected readonly IRepository<Intensity> _intensityRepository;
        public IntensityService(IRepository<Intensity> intensityRepository)
        {
            _intensityRepository = intensityRepository;
        }
        public List<Intensity> GetAll()
        {
			try
			{
                return _intensityRepository.GetAll().OrderBy(x => x.Id).ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
        }
    }
}
