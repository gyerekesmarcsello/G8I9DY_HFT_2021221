using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Models
{
    [Table("Artists")]
    public class Artists
    {
        [Key]
        public int ArtistID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Birthday { get; set; }

        [Required]
        public string Country { get; set; }


    }
}
