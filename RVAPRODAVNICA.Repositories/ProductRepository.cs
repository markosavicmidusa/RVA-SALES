using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using RVAPRODAVNICA.Data;

namespace RVAPRODAVNICA.Repositories
{

    public interface IProductRepository : IBaseRepository<Product>
    {
    }

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
