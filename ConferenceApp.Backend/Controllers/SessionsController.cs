using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConferenceApp.Backend.Data;

namespace ConferenceApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SessionsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Sessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Session>>> GetSessions()
        {
            return await _context.Sessions
                .AsNoTracking()
                .Include(s => s.Speakers)
                .Include(s => s.Attendees)
                .ToListAsync();
        }

        // GET: api/Sessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> GetSession(int id)
        {
            var session = await _context.Sessions
                .AsNoTracking()
                .Include(s => s.Attendees)
                .Include(s => s.Speakers)
                .SingleOrDefaultAsync(s => s.ID == id);
                
            if (session == null)
            {
                return NotFound();
            }

            return session;
        }

         
        // POST: api/Sessions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task PostSession(CreateSessionRequest session)
        {
            _context.Sessions.Add(new Session {
                 Title = session.Title,
                 Description = session.Description,
                 StartTime = session.StartTime,
                 EndTime = session.EndTime
            });
            await _context.SaveChangesAsync();
            
        }

        private bool SessionExists(int id)
        {
            return _context.Sessions.Any(e => e.ID == id);
        }
    }
}
