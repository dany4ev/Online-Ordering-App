using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderingApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public virtual List<Product> Products { get; set; }

        public decimal TotalPrice { get; set; }
    }

    public class OrderVM
    {
        public int Id { get; set; }

        public List<Product> Products { get; set; }

        public decimal TotalPrice { get; set; }
    }
}