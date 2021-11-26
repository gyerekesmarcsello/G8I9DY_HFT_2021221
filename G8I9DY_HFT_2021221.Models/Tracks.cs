using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Models
{
    [Table("Tracks")]
    public class Tracks
    {
        [Key]
        public int TrackID { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey(nameof(Albums))]
        public int AlbumID { get; set; }


        [ForeignKey(nameof(Artists))]
        public int ArtistID { get; set; }

        [Required]
        public int Plays { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public bool IsExplicit { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Albums Album { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Artists Artist { get; set; }



    }
}
