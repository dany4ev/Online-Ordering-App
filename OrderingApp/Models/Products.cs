using System.ComponentModel.DataAnnotations;

namespace OrderingApp.Models
{
    public class Product
    {
        [Key]
       public int Id { get; set; }

       public string Name { get; set; }
    
       public string Description { get; set; }

       public decimal Price { get; set; }
    
       public int Quantity { get; set; }

       public virtual Category Category { get; set; }
    }

    public class ProductVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public Category Category { get; set; }
    }
}