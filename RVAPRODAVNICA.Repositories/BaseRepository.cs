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
        TEntity readOne(int id);

        int Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);


    }

    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {

        private IConfiguration configuration;
        public string connectionString;
        public MySqlConnection connection;

        public BaseRepository(IConfiguration configuration) {

            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);

            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
            connection = new MySqlConnection(connectionString);

        }
        /// <summary>
        ///  Get all from any table
        /// </summary>
        /// <returns></returns>
        public List<TEntity> readAll()
        {
            List<TEntity> results = connection.GetList<TEntity>().ToList();
            return results;
        }
        /// <summary>
        /// Get one record 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public TEntity readOne(int id)
        {
            
            TEntity result = connection.Get<TEntity>(id);
            return result;

        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Create(TEntity obj)
        {
            var result = connection.Insert(obj);
            return (int)result;
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Update(TEntity obj)
        {
            connection.Update(obj);
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(TEntity obj)
        {
            connection.Delete(obj);
        }
    }
}
