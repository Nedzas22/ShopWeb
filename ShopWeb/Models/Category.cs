namespace ShopWeb.Models
{
    public class Category
    {
        public long id { get; set; }
        public string name { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
