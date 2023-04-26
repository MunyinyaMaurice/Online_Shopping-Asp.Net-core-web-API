using Shop_online.Data;
using Shop_online.Interfaces;
using Shop_online.Model;

namespace Shop_online.Repository
{
    public class ProductRepository : productInterface

    {
        private readonly DataContext _context;
       

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateProduct(Product product)
        {
            _context.Add(product);
            return Save();
        }

        public bool DeleteProduct(Product product)
        {
            _context.Remove(product);
            return Save();
        }

        public ICollection<Product> GetProduct()
        {
            return _context.Product.ToList();
        }

        public Product GetProduct(int product_Id)
        {
            return _context.Product.Where(o => o.p_id == product_Id).FirstOrDefault();
        }

        public bool productExists(int products)
        {
            return _context.Product.Any(o => o.p_id == products);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateProduct(Product product)
        {
            _context.Update(product);
            return Save();
        }
    }
}
