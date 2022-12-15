using CoffeeMachineDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineDataAccess.Interfaces
{
    public interface ICoffeeRepository
    {
        IEnumerable<Coffee> GetAll();

        Coffee GetById(int id);

        void Insert(Coffee entity);
    }
}
