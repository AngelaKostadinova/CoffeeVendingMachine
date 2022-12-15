using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoffeeMachineDomain.Models
{
    public class Intensity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IntensityNumber { get; set; }
        public string Description { get; set; }
        public IEnumerable<TypeIngredientIntensity> TypeIngredientIntensities { get; set; }
    }
}
