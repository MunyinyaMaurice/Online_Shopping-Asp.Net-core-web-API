using Shop_online.Model;
namespace Shop_online.Interfaces
{
    public interface CustomerInterface
    {
        ICollection<Customer> GetCustomers();
        Customer GetCustomer(int customer_Id);
        bool CustmerExists(int customer_id);
        bool CreateCustmer(Customer customer);
        bool UpdateCustmer(Customer customer);
        bool DeleteCustmer(Customer customer);
        bool Save();

    }
}
