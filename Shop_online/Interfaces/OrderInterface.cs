using Shop_online.Model;

namespace Shop_online.Interfaces
{
    public interface OrderInterface
    {
        ICollection<Order> GetOrders();
        Order GetOrders(int order_id);
        ICollection<Order> GetOrderOfProduct(int product_id);
        ICollection<Order> GetOrderByCustomer(int custmoer_id);
        bool OrderExists(Order order);
        bool CreateOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(Order Order);
        bool Save();
    }
}


