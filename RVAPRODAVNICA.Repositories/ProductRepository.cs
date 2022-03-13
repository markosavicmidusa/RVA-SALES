using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RVAPRODAVNICA.Data;

namespace RVAPRODAVNICA.Repositories
{

    public interface IProductRepository {

        Product GetOne(int id);
    }

    public class ProductRepository
    {
    }
}
