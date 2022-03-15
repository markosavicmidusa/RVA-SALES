using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVAPRODAVNICA.Data
{
    [Table("products")]
    public class Product : Base
    {

        [Column("name")]
        public string? Name { get; set; }
    }
}
