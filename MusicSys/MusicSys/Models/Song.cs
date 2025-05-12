using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSys.Models
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public int? Year { get; set; }

        [StringLength(100)]
        public string Genre { get; set; }

        public TimeSpan? Duration { get; set; }

        [StringLength(500)]
        public string Lyrics { get; set; }

        // Foreign keys
        public int AlbumId { get; set; }

        public int ArtistId { get; set; }

        // Navigation properties
        [ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }

        [ForeignKey("ArtistId")]
        public virtual Artist Artist { get; set; }
    }  
}

