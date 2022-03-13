using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using RVAPRODAVNICA.Data;

namespace RVAPRODAVNICA.Repositories
{

    public interface IProductRepository {

        Product GetOne(int id);

        List <Product> GetAll();
    }

    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAll()
        {
            var connection = new MySqlConnection("Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=;");         
            List<Product> products = connection.Query<Product>("SELECT * FROM products").ToList();
            return products;
       
        }

        public Product GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
