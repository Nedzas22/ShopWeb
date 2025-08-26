using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWeb.Models
{
    public class Product
    {
        public long id { get; set; }
        public string name { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal price { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
