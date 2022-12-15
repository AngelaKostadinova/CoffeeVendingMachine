using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoffeeMachineDomain.Models
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TypeIngredientIntensity> TypeIngredientIntensities { get; set; }
        public double? Price { get; set; }
    }
}
