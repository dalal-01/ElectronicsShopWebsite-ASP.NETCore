using System.ComponentModel.DataAnnotations;

namespace ElectronicShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public string CompanyName { get; set; }

        [Required]
        public float Price { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
