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
    [Table("Albums")]
    public class Albums
    {
        [Key]
        [Required]
        public int AlbumID { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey(nameof(Artists))]
        public int ArtistID { get; set; }

        [Required]
        public string Label { get; set; }

        [Required]
        [JsonIgnore]
        public TimeSpan Length { get; set; }


        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Genre { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual Artists Artist { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Tracks> Tracks { get; set; }

        [NotMapped]
        public long LengthTicks
        {
            get
            {
                return Length.Ticks;
            }
            set
            {
                Length = TimeSpan.FromTicks(value);
            }
        }
        public Albums()
        {
            Tracks = new HashSet<Tracks>();
        }



    }
}
