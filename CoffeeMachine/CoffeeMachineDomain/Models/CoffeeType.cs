using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoffeeMachineDomain.Models
{
    public class CoffeeType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public List<TypeIngredientIntensity> TypeIngredientIntensities { get; set; }
    }
}
