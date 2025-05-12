using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace MusicSys.Models
{

    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(500)]
        public string Biography { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual ICollection<Album> Albums { get; set; }

        [JsonIgnore]
        public virtual ICollection<Song> Songs { get; set; }

        public Artist()
        {
            Albums = new HashSet<Album>();
            Songs = new HashSet<Song>();
        }
    }
}

