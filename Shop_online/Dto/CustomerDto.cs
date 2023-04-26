using System.ComponentModel.DataAnnotations;

namespace Shop_online.Model
{
    public class CustomerDto
    {
        
        public int customer_id { get; set; }
        public String customer_names { get; set; }
        public String customer_email { get; set; }
        public String customer_phoneNo { get; set; }
        public int customer_yearOfDate { get; set; }
        public String customer_nationality { get; set; }
        public String customer_address { get; set; }
        public ICollection<OrderDto>? orders { get; set; }
    }
}
