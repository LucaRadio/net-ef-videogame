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
    [Table("videogames")]
    [Index(nameof(Id),IsUnique =true)]
    public class Videogame
    {
        [Key]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("overview")]
        public string Overview { get;  set; }
        [Column("release_date")]
        public DateTime ReleaseDate { get;  set; }
        [Column("software_house_id")]
        public long SoftwareHouseID { get;  set; }
        SoftwareHouse SoftwareHouse { get; set; }

        
    }
}
