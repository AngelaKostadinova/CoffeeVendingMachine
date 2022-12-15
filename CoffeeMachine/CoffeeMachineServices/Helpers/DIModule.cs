using CoffeeMachineDataAccess;
using CoffeeMachineDataAccess.Interfaces;
using CoffeeMachineDataAccess.Repositories;
using CoffeeMachineDomain.Models;
using CoffeeMachineServices.Interfaces;
using CoffeeMachineServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeMachineServices.Helpers
{
    public static class DIModule
    {
        public static ServiceProvider Services { get; set; }
        public static void RegisterModule()
        {
            var sqlConnectionString = "Server=localhost\\SQLEXPRESS;Initial Catalog=CoffeeVendingMachineDb; Integrated Security=true; TrustServerCertificate=True;";
            Services = new ServiceCollection().AddDbContext<DbContext, CoffeeMachineDbContext>(options => options.UseSqlServer(sqlConnectionString))
                                              .AddSingleton<ICoffeeRepository, CoffeeRepository>()
                                              .AddSingleton<IRepository<CoffeeType>, CoffeeTypeRepository>()
                                              .AddSingleton<IRepository<Intensity>, IntensityRepository>()
                                              .AddSingleton<IRepository<Ingredient>, IngredientRepository>()
                                              .AddSingleton<IRepository<TypeIngredientIntensity>, TypeIngredientIntensityRepository>()
                                              .AddSingleton<ICoffeeService, CoffeeService>()
                                              .AddSingleton<IIntensityService, IntensityService>()
                                              .AddSingleton<ICoffeeTypeService, CoffeeTypeService>()
                                              .AddSingleton<IUIService, UIService>()
                                              .AddSingleton<ITypeIngredientIntensityService, TypeIngredientIntensityService>()
                                              .AddSingleton<IIngredientService, IngredientService>()
                                              .BuildServiceProvider();
        }
        public static T GetService<T>()
        {
            return Services.GetService<T>();
        }
    }
}
