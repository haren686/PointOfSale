using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Models;

namespace PointOfSale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly PointOfSaleContext _context;

        public ApplicationsController(PointOfSaleContext context)
        {
            _context = context;
        }

        // GET: api/Applications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Applications>>> GetApplications()
        {
            return await _context.Applications.ToListAsync();
        }

        // GET: api/Applications/5
        [HttpGet("{applicationNumber}")]
        public async Task<ActionResult<Applications>> GetApplications(string applicationNumber)
        {
            var applications = await _context.Applications.FindAsync(applicationNumber);

            if (applications == null)
            {
                return NotFound();
            }

            return applications;
        }

        // PUT: api/Applications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplications(int id, Applications applications)
        {
            if (id != applications.Id)
            {
                return BadRequest();
            }

            _context.Entry(applications).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationsExists(id))
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

        // POST: api/Applications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Applications>> PostApplications(Applications applications)
        {
            _context.Applications.Add(applications);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplications", new { id = applications.Id }, applications);
        }

        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Applications>> DeleteApplications(int id)
        {
            var applications = await _context.Applications.FindAsync(id);
            if (applications == null)
            {
                return NotFound();
            }

            _context.Applications.Remove(applications);
            await _context.SaveChangesAsync();

            return applications;
        }

        private bool ApplicationsExists(int id)
        {
            return _context.Applications.Any(e => e.Id == id);
        }
    }
}
