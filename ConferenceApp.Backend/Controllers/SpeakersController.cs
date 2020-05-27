using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConferenceApp.Backend.Data;

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
        public async Task<ActionResult<IEnumerable<Speaker>>> GetSpeakers()
        {
            return await _context.Speakers
                .AsNoTracking()
                .Include(s=> s.Sessions)
                .ThenInclude(ss => ss.Session)
                .ToListAsync();
        }

        // GET: api/Speakers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Speaker>> GetSpeaker(int id)
        {
            var speaker = await _context.Speakers
                .AsNoTracking()
                .Include(s => s.Sessions)
                .ThenInclude(ss => ss.Session)
                .SingleOrDefaultAsync();

            if (speaker == null)
            {
                return NotFound();
            }

            return speaker;
        }

        private bool SpeakerExists(int id)
        {
            return _context.Speakers.Any(e => e.ID == id);
        }
    }
}
