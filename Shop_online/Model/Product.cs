using System.ComponentModel.DataAnnotations;

namespace Shop_online.Model
{
    
    public class Product
    {
        [Key]
        public int p_id { get; set; }
        public String product_id { get; set; }
        public String product_name { get; set; }
        public float product_price { get; set; }
        public int product_quantity { get; set; }
        public String product_details { get; set; }
        public String product_photo { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
