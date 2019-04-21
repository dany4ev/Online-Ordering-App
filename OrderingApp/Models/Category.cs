using System.ComponentModel.DataAnnotations;

namespace OrderingApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class CategoryVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}