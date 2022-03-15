using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace RVAPRODAVNICA.Repositories
{

    public interface IBaseRepository<TEntity> 
    {
        List<TEntity> readAll();
    }

    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {

        private IConfiguration configuration;
        public string connectionString;

        public BaseRepository(IConfiguration configuration) {

            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");

        }
        /// <summary>
        ///  Get all from any table
        /// </summary>
        /// <returns></returns>
        public List<TEntity> readAll()
        {
            var connection = new MySqlConnection(connectionString);
            List<TEntity> results = connection.GetList<TEntity>().ToList();
            return results;

        }
    }
}
