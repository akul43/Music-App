using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music.Models;

namespace Music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Songs1Controller : ControllerBase
    {
        private readonly SongContext1Context _context;

        public Songs1Controller(SongContext1Context context)
        {
            _context = context;
        }

        // GET: api/Songs1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<viewModel>>> GetSong()
        {
            IQueryable<viewModel> labels = from a in _context.Songs
                                           select new viewModel
                                           {
                                               Id = a.Id,
                                               
                                               Title = a.Title,
                                               Genre = a.Genre,
                                               ReleaseDate = a.ReleaseDate,
                                               Artist = a.Label.Artist,
                                               LabelName = a.Label.LabelName,

                                           };
            return await labels.ToListAsync();
        }

        // GET: api/Songs1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<viewModel>>> GetSong(int id)
        {
            IQueryable<viewModel> labels = from a in _context.Songs
                                           where a.LabelId == id
                                           select new viewModel
                                           {
                                             LabelName = a.Label.LabelName,
                                             Artist = a.Label.Artist
                                       };
            return await labels.ToListAsync();
        }

        // PUT: api/Songs1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Songs1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = song.Id }, song);
        }

        // DELETE: api/Songs1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.Id == id);
        }
    }
}
