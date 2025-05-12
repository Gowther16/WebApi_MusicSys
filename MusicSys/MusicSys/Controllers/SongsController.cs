using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicSys.DTO;
using MusicSys.Models;
using MusicSys.Repositories.Interfaces;

namespace MusicSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly IRepository<Song> _songRepository;

        public SongsController(IRepository<Song> songRepository)
        {
            _songRepository = songRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSongs()
        {
            var songs = await _songRepository.GetAllAsync();
            return Ok(songs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSong(int id)
        {
            var song = await _songRepository.GetByIdAsync(id);
            if (song == null) return NotFound();
            return Ok(song);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSong([FromBody] SongDTO dto)
        {
            var song = new Song
            {
                Title = dto.Title,
                Year = dto.Year,
                Genre = dto.Genre,
                Duration = dto.Duration,
                AlbumId = dto.AlbumId,
                ArtistId = dto.ArtistId
            };
            await _songRepository.AddAsync(song);
            await _songRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSong), new { id = song.SongId }, song);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSong(int id, [FromBody] SongDTO dto)
        {
            var song = await _songRepository.GetByIdAsync(id);

            song.Title = dto.Title;
            song.Year = dto.Year;
            song.Genre = dto.Genre;
            song.Duration = dto.Duration;
            song.AlbumId = dto.AlbumId;
            song.ArtistId = dto.ArtistId;

            if (id != song.SongId) return BadRequest();
            _songRepository.Update(song);
            await _songRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var song = await _songRepository.GetByIdAsync(id);
            if (song == null) return NotFound();
            _songRepository.Delete(song);
            await _songRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
