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
    [Table("Artists")]
    public class Artist
    {
        [Key]
        [Required]
        public int ArtistID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public bool GrammyWinner { get; set; }
        /*
        [NotMapped]
        [JsonIgnore]
        public virtual Albums Album { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Tracks Track { get; set; }
        */
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Album> Albums { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Track> Tracks { get; set; }
        public Artist()
        {
            Albums = new HashSet<Album>();
            Tracks = new HashSet<Track>();
        }
    }
}
