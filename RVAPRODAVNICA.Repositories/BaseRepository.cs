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

    public interface IBaseRepository<TEntity> where TEntity : Base
    {
        List<TEntity> readAll();
        TEntity readOne(int id);

        int Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        List<TEntity> TableSearch(int pageNumber, int rowsPerPage, string v);

    }

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Base
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
            obj.Active = true;
            obj.DataCreatedAt = DateTime.Now;
            obj.DataUreatedAt = DateTime.Now;
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



        /// <summary>
        /// table search for pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="rowsPerPage"></param>
        /// <param name="conditions"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<TEntity> TableSearch(int pageNumber, int rowsPerPage, string search)
        {

            return connection.GetListPaged<TEntity>(pageNumber, rowsPerPage, $"WHERE Name like '%{search}%' or Description like '%{search}%'","").ToList();

        }


    }
}
