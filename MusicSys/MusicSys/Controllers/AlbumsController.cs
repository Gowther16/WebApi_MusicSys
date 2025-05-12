using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicSys.DTO;
using MusicSys.Models;
using MusicSys.Repositories.Interfaces;

namespace MusicSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IRepository<Album> _AlbumRepository;

        public AlbumsController(IRepository<Album> albumRepository)
        {
            _AlbumRepository = albumRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbums()
        {
            var albums = await _AlbumRepository.GetAllAsync();
            return Ok(albums);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum(int id)
        {
            var album = await _AlbumRepository.GetByIdAsync(id);
            if (album == null) return NotFound();
            return Ok(album);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbum([FromBody] AlbumDTO dto)
        {
            var Album = new Album
            {
                Title = dto.Title,
                Year = dto.Year,
                Producer = dto.Producer,
                Description = dto.Description
            };
            await _AlbumRepository.AddAsync(Album);
            await _AlbumRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAlbum), new { id = Album.AlbumId }, Album);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlbum(int id, [FromBody] AlbumDTO dto)
        {
            var album = await _AlbumRepository.GetByIdAsync(id);

            album.Title = dto.Title;
            album.Year = dto.Year;
            album.Producer = dto.Producer;
            album.Description = dto.Description;

            if (id != album.AlbumId) return BadRequest();
            _AlbumRepository.Update(album);
            await _AlbumRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await _AlbumRepository.GetByIdAsync(id);
            if (album == null) return NotFound();
            _AlbumRepository.Delete(album);
            await _AlbumRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
