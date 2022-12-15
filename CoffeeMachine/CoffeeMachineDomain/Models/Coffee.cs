using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoffeeMachineDomain.Models
{
    public class Coffee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Description { get; set; }
        public CoffeeType CoffeeType { get; set; }
        public int CoffeeTypeId { get; set; }
        public double? Price { get; set; }
    }
}
