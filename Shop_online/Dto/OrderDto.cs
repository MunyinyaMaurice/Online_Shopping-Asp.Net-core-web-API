namespace Shop_online.Model
{
    public class OrderDto
    {
        public int order_id { get; set; }
        public int p_id { get; set; }
        public int customer_id { get; set; }
        public float paymentMethod { get; set; }
        public float totalPaid { get; set; }
        public  Product Product { get; set; }
        public  Customer Cutomer { get; set; }
    }
}
