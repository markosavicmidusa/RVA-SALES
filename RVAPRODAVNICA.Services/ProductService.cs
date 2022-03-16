using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RRVAPRODAVNICA.Models;
using RVAPRODAVNICA.Data;
using RVAPRODAVNICA.Repositories;


namespace RVAPRODAVNICA.Services
{

    public interface IProductService
    {

        List<ProductModel>ReadAll();
        ProductModel Get(int id);
        int Create(Product obj);
        void Update(Product obj);
        void Delete(Product obj);

    }
    public class ProductService : IProductService
    {

        private readonly IProductRepository productRepository;
        private readonly IMapper mapperService;

        public ProductService(IProductRepository productRepository, IMapper mapperService) { 
        
            this.productRepository = productRepository;
            this.mapperService = mapperService;
        
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
        public ProductModel Get(int id)
        {
            Product result = productRepository.readOne(id);
            ProductModel resultModel = mapperService.Map<ProductModel>(result);
            return resultModel;
            
        }
        /// <summary>
        /// Read all
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> ReadAll()
        {
            List<Product>? result = productRepository.readAll();
            List<ProductModel> resultModel = mapperService.Map<List<ProductModel>>(result);
            return resultModel;
            
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
