using System.ComponentModel.DataAnnotations;

namespace MusicSys.DTO
{
    public class SongDTO
    {
        public string Title { get; set; }

        public int? Year { get; set; }

        public string Genre { get; set; }

        public TimeSpan? Duration { get; set; }

        public int AlbumId { get; set; }

        public int ArtistId { get; set; }
    }
}
