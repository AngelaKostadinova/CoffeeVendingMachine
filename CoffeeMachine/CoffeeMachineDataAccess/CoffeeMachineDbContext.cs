using CoffeeMachineDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineDataAccess
{
    public class CoffeeMachineDbContext : DbContext
    {
        public CoffeeMachineDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<CoffeeType> CoffeeTypes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Intensity> Intensities { get; set; }

        public DbSet<TypeIngredientIntensity> TypeIngredientIntensities { get; set; }

        public void Seed(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CoffeeType>()
                .HasData(
                    new CoffeeType
                    {
                        Id = 1,
                        Name = "Latte",
                        Price = 24
                    },
                    new CoffeeType
                    {
                        Id = 2,
                        Name = "Macchiato",
                        Price = 50
                    },
                    new CoffeeType
                    {
                        Id = 3,
                        Name = "Espresso",
                        Price = 20.50
                    },
                    new CoffeeType
                    {
                        Id = 4,
                        Name = "Americano",
                        Price = 78
                    },
                    new CoffeeType
                    {
                        Id = 5,
                        Name = "Mocha",
                        Price = 27
                    }
                );

            modelBuilder.Entity<Ingredient>()
                .HasData(
                    new Ingredient
                    {
                        Id = 1,
                        Name = "Milk",
                        Price = 5
                    },
                    new Ingredient
                    {
                        Id = 2,
                        Name = "Sugar",
                        Price = 3
                    },
                    new Ingredient
                    {
                        Id = 3,
                        Name = "Ice",
                        Price = 2
                    },
                    new Ingredient
                    {
                        Id = 4,
                        Name = "Cream",
                        Price = 6
                    },
                    new Ingredient
                    {
                        Id = 5,
                        Name = "Chocolate",
                        Price = 10
                    },
                    new Ingredient
                    {
                        Id = 6,
                        Name = "Coffee",
                        Price = 10
                    }
                );

            modelBuilder.Entity<Coffee>()
                .HasData(
                    new Coffee
                    {
                        Id = 1,
                        Description = "Latte Coffee",
                        CoffeeTypeId = 1
                    },
                    new Coffee
                    {
                        Id = 2,
                        Description = "Macchiato Coffee",
                        CoffeeTypeId = 2,
                    },
                    new Coffee
                    {
                        Id = 3,
                        Description = "Espresso Coffee",
                        CoffeeTypeId = 3,
                    },
                    new Coffee
                    {
                        Id = 4,
                        Description = "Americano Coffee",
                        CoffeeTypeId = 4,
                    },
                    new Coffee
                    {
                        Id = 5,
                        Description = "Mocha Coffee",
                        CoffeeTypeId = 5,
                    }
                );

            modelBuilder.Entity<TypeIngredientIntensity>()
                .HasData(
                new TypeIngredientIntensity
                {
                    Id = 1,
                    IngredientId = 1,
                    IntensityId = 1,
                    CoffeeTypeId = 1
                },
                new TypeIngredientIntensity
                {
                    Id = 2,
                    IngredientId = 2,
                    IntensityId = 3,
                    CoffeeTypeId = 2
                },
                new TypeIngredientIntensity
                {
                    Id = 3,
                    IngredientId = 1,
                    IntensityId = 2,
                    CoffeeTypeId = 3
                },
                new TypeIngredientIntensity
                {
                    Id = 4,
                    IngredientId = 4,
                    IntensityId = 2,
                    CoffeeTypeId = 4
                },
                new TypeIngredientIntensity
                {
                    Id = 5,
                    IngredientId = 2,
                    IntensityId = 3,
                    CoffeeTypeId = 5

                },
                new TypeIngredientIntensity
                {
                    Id = 6,
                    IngredientId = 5,
                    IntensityId = 2,
                    CoffeeTypeId = 5
                },
                new TypeIngredientIntensity
                {
                    Id = 7,
                    IngredientId = 5,
                    IntensityId = 4,
                    CoffeeTypeId = 2
                },
                new TypeIngredientIntensity
                {
                    Id = 8,
                    IngredientId = 2,
                    IntensityId = 5,
                    CoffeeTypeId = 1
                },
                new TypeIngredientIntensity
                {
                    Id = 9,
                    IngredientId = 1,
                    IntensityId = 1,
                    CoffeeTypeId = 2
                },
                new TypeIngredientIntensity
                {
                    Id = 10,
                    IngredientId = 2,
                    IntensityId = 3,
                    CoffeeTypeId = 3
                });

            modelBuilder.Entity<Intensity>()
                .HasData(
                new Intensity
                {
                    Id = 1,
                    IntensityNumber = 1,
                    Description = "Intensity of ingredient with the value of 1"
                },
                new Intensity
                {
                    Id = 2,
                    IntensityNumber = 2,
                    Description = "Intensity of ingredient with the value of 2"
                },
                new Intensity
                {
                    Id = 3,
                    IntensityNumber = 3,
                    Description = "Intensity of ingredient with the value of 3"
                },
                new Intensity
                {
                    Id = 4,
                    IntensityNumber = 4,
                    Description = "Intensity of ingredient with the value of 4"
                },
                new Intensity
                {
                    Id = 5,
                    IntensityNumber = 5,
                    Description = "Intensity of ingredient with the value of 5"
                });

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=CoffeeVendingMachineDb; Integrated Security=true; TrustServerCertificate=True;", builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
