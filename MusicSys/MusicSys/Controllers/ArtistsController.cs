using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicSys.DTO;
using MusicSys.Models;
using MusicSys.Repositories.Interfaces;

namespace MusicSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IRepository<Artist> _artistRepository;

        public ArtistsController(IRepository<Artist> artistRepository)
        {
            _artistRepository = artistRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtists()
        {
            var artists = await _artistRepository.GetAllAsync();
            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtist(int id)
        {
            var artist = await _artistRepository.GetByIdAsync(id);
            if (artist == null) return NotFound();
            return Ok(artist);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtist([FromBody] ArtistDTO dto)
        {
            var artist = new Artist
            {
                Name = dto.Name,
                Country = dto.Country,
                DateOfBirth = dto.DateOfBirth,
                Biography = dto.Biography
            };
            await _artistRepository.AddAsync(artist);
            await _artistRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArtist), new { id = artist.ArtistId }, artist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int id, [FromBody] ArtistDTO dto)
        {
            var artist = await _artistRepository.GetByIdAsync(id);

            artist.Name = dto.Name;
            artist.Country = dto.Country;
            artist.DateOfBirth = dto.DateOfBirth;
            artist.Biography = dto.Biography;

            if (id != artist.ArtistId) return BadRequest();
            _artistRepository.Update(artist);
            await _artistRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _artistRepository.GetByIdAsync(id);
            if (artist == null) return NotFound();
            _artistRepository.Delete(artist);
            await _artistRepository.SaveChangesAsync();
            return NoContent();
        }
    }

}
