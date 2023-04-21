using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("software_houses")]
    [Index(nameof(Id), IsUnique = true)]
    public class SoftwareHouse
    {
        [Key]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("tax_id")]
        public string TaxId { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("country")]
        public string Country { get; set; }

    }
}
