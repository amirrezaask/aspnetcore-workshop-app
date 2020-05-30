using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConferenceApp.Backend.Data;
using ConferenceApp.Domain;

namespace Backend
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SpeakersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Speakers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpeakerDTO>>> GetSpeakers()
        {
            var speakers = await _context.Speakers
                .AsNoTracking()
                .Include(s=> s.Sessions)
                    .ThenInclude(sp => sp.Session)
                .Select(s => s.SpeakerRespone())
                .ToListAsync();
            if (speakers == null) return NotFound();
            return speakers;
        }

        // GET: api/Speakers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpeakerDTO>> GetSpeaker(int id)
        {
            var speaker = await _context.Speakers
                .AsNoTracking()
                .Include(s => s.Sessions)
                    .ThenInclude(ss => ss.Session)
                .Select(s => s.SpeakerRespone())
                .SingleOrDefaultAsync(s => s.ID == id);

            if (speaker == null)
                return NotFound();

            return speaker;
        }
        // POST: api/Speakers
        [HttpPost("")]
        public async Task CreateSpeaker(ConferenceApp.Domain.Speaker speaker) 
        {
            await _context.Speakers.AddAsync(
                new ConferenceApp.Backend.Data.Speaker
                { 
                    Name = speaker.Name,
                    Bio = speaker.Bio,
                    Website = speaker.Website,
            });
            await _context.SaveChangesAsync();
            
        }
        private bool SpeakerExists(int id)
        {
            return _context.Speakers.Any(e => e.ID == id);
        }
    }
}
