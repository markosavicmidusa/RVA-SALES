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
        /// <summary>
        /// CREATE
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>

        public int Create(Product obj)
        {
            return productRepository.Create(obj);
        }
        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="obj"></param>
        public void Delete(Product obj)
        {
           productRepository.Delete(obj);
        }
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product Get(int id)
        {
            return productRepository.readOne(id);
            
        }
        /// <summary>
        /// Read all
        /// </summary>
        /// <returns></returns>
        public List<Product> ReadAll()
        {
          return productRepository.readAll();
            
        }
        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="obj"></param>
        public void Update(Product obj)
        {
            productRepository.Update(obj);
        }
    }
}
