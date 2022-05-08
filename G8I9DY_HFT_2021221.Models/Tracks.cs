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
    public class Track
    {
        [Key]
        [Required]
        public int TrackID { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey(nameof(Models.Album))]
        public int? AlbumID { get; set; }


        [ForeignKey(nameof(Models.Artist))]
        public int? ArtistID { get; set; }

        [Required]
        public int Plays { get; set; }

        [Required]
        [JsonIgnore]
        public TimeSpan Duration { get; set; }

        [Required]
        public bool IsExplicit { get; set; }

        [NotMapped]
        public long DurationTicks
        {
            get
            {
                return Duration.Ticks;
            }
            set
            {
                Duration = TimeSpan.FromTicks(value);
            }
        }

        [NotMapped]
        [JsonIgnore]
        public virtual Album Album { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Artist Artist { get; set; }



    }
}
