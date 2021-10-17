using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Models
{
    [Table("Albums")]
    public class Albums
    {
        [Key]
        public int AlbumID { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey(nameof(Artists))]
        public int ArtistID { get; set; }

        [Required]
        public string Label { get; set; }

        [NotMapped]
        public virtual Tracks Track { get; set; }

        [NotMapped]
        public virtual ICollection<Tracks> Tracks { get; set; }


        public Albums()
        {
            Tracks = new HashSet<Tracks>();
        }



    }
}
