using System.ComponentModel.DataAnnotations;

namespace Shop_online.Model
{
    
    public class Order
    {
        [Key]
        public int order_id { get; set; }
        public int customer_id { get; set; }
        public float paymentMethod { get; set; }
        public float totalPaid { get; set; }

        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
