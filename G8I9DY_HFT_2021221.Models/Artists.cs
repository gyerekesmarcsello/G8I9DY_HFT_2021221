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
    public class Artists
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

        [NotMapped]
        [JsonIgnore]
        public virtual Albums Album { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Tracks Track { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Albums> Albums { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Tracks> Tracks { get; set; }
        public Artists()
        {
            Albums = new HashSet<Albums>();
            Tracks = new HashSet<Tracks>();
        }
    }
}
