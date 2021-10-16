using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Models
{
    [Table("Tracks")]
    public class Tracks
    {
        [Key]
        public int BattleID { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(Albums))]
        public int AlbumID { get; set; }

        [Required]
        public string Genre { get; set; }

        [ForeignKey(nameof(Artists))]
        public int ArtistID { get; set; }

        [Required]
        public string ReleaseDate { get; set; }
    }
}
