using Shop_online.Model;

namespace Shop_online.Interfaces
{
    public interface productInterface
    {
        ICollection<Product> GetProduct();
        Product GetProduct(int product_id);
        bool productExists(int product);
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(Product product);
        bool Save();
    }
}
