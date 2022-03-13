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
        List<TEntity> getAll();
    }

    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {

        private IConfiguration configuration;
        public string connectionString;

        private BaseRepository(IConfiguration configuration) { 
        
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        /// <summary>
        ///  Get all from any table
        /// </summary>
        /// <returns></returns>
        public List<TEntity> getAll()
        {
            var connection = new MySqlConnection(connectionString);
            List<TEntity> results = connection.GetList<TEntity>().ToList();
            return results;

        }
    }
}
