using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVAPRODAVNICA.Data
{
    public class Base
     {
        [Column("id")]
        public string? Id { get; set; }

        [Column("date_created_at")]
        public DateTime? DataCreatedAt { get; set; }

        [Column("date_update_dat")]
        public DateTime? DataUreatedAt { get; set; }

        [Column("active")]
        public bool? Active { get; set; }


    }
}