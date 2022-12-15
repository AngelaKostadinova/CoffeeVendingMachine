using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineServices.Interfaces
{
    public interface ICoffeeBuilder
    {
        ICoffeeBuilder SetType(string typeName);
        ICoffeeBuilder SetIngridient(int ingridientId);
        ICoffeeBuilder SetIntensity(int intensityId);
        ICoffeeBuilder SetBaseIngridientsAndIntensities();
    }
}
