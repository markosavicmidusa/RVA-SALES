using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace RVAPRODAVNICA.Repositories
{

    public interface IBaseRepository<TEntity> 
    {
    }

    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {

        private IConfiguration configuration;

        private BaseRepository(IConfiguration configuration) { 
        
            this.configuration = configuration;
        }


    }
}
