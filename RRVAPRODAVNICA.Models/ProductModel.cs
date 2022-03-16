using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRVAPRODAVNICA.Models
{
    public class ProductModel
    {

  
        public string? Id { get; set; }  
        public DateTime? DataCreatedAt { get; set; }
        public DateTime? DataUreatedAt { get; set; }
        public bool? Active { get; set; }  
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
    }
}
