using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoffeeMachineDomain.Models
{
    public class TypeIngredientIntensity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int IntensityId { get; set; }
        public Intensity Intensity { get; set; }
        public CoffeeType CoffeeType { get; set; }
        public int CoffeeTypeId { get; set; }
    }
}
