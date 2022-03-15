using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RVAPRODAVNICA.Data;
using RVAPRODAVNICA.Repositories;

namespace RVAPRODAVNICA.Services
{

    public interface IProductService
    {

        List<Product> ReadAll();
        Product Get(int id);
        int Create(Product obj);
        void Update(Product obj);
        void Delete(Product obj);

    }
    public class ProductService : IProductService
    {

        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository) { 
        
            this.productRepository = productRepository;
        
        }


        public int Create(Product obj)
        {
            return productRepository.Create(obj);
        }

        public void Delete(Product obj)
        {
           productRepository.Delete(obj);
        }

        public Product Get(int id)
        {
            return productRepository.readOne(id);
            
        }

        public List<Product> ReadAll()
        {
          return productRepository.readAll();
            
        }

        public void Update(Product obj)
        {
            productRepository.Update(obj);
        }
    }
}
