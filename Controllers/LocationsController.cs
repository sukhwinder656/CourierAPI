using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourierAPI.Data;
using CourierAPI.Models;

namespace CourierAPI.Controllers
{
    /// <summary>
    /// Location Controller Class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly CourierDBContext _context;

        /// <summary>
        /// Location Constructor with Courier DB context
        /// </summary>
        /// <param name="context"></param>
        public LocationsController(CourierDBContext context)
        {
            _context = context;
        }

        // GET: api/Locations
        /// <summary>
        /// GET all Method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        // GET: api/Locations/5
        /// <summary>
        /// GET Location by id Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// PUT Location Method for updating a Location
        /// </summary>
        /// <param name="id"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// POST Method for creating a Location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        }

        // DELETE: api/Locations/5
        /// <summary>
        /// DELETE Method for deleting a Location
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.Id == id);
        }
    }
}
