using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicSys.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public int? Year { get; set; }

        [StringLength(100)]
        public string Producer { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<Song> Songs { get; set; }

        [JsonIgnore]
        public virtual ICollection<Artist> Artists { get; set; }

        public Album()
        {
            Songs = new HashSet<Song>();
            Artists = new HashSet<Artist>();
        }
    }
}

