using System.ComponentModel.DataAnnotations;

namespace ElectronicShop.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        public Product products { get; set; }

        public int CustomerID { get; set; }

        public Customer Customers { get; set; }


        [Required]
        [Range(1,10)]
        public int Quantity { get; set; }

    }
}
