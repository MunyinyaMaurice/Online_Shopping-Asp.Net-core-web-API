using Shop_online.Data;
using Shop_online.Interfaces;
using Shop_online.Model;

namespace Shop_online.Repository
{
    public class CustomerRepository : CustomerInterface
    {
        private readonly DataContext _context;


        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateCustmer(Customer customer)
        {
            _context.Add(customer);
            return Save();
        }

        public bool CustmerExists(int customer_id)
        {
            return _context.Customer.Any(o => o.customer_id == customer_id);
        }

        public bool DeleteCustmer(Customer customer)
        {
            _context.Remove(customer);
            return Save();
        }

        public Customer GetCustomer(int customer_Id)
        {
            return _context.Customer.Where(o => o.customer_id == customer_Id).FirstOrDefault();

        }

        public ICollection<Customer> GetCustomers()
        {
            return _context.Customer.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCustmer(Customer customer)
        {
            _context.Update(customer);
            return Save();
        }
    }
}
