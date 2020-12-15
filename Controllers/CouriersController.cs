using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourierAPI.Data;
using CourierAPI.Models;
using CourierAPI.ViewModel;

namespace CourierAPI.Controllers
{
    /// <summary>
    /// Courier Controller class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CouriersController : ControllerBase
    {
        private readonly CourierDBContext _context;

        /// <summary>
        /// Constructor with Courier DB context
        /// </summary>
        /// <param name="context"></param>
        public CouriersController(CourierDBContext context)
        {
            _context = context;
        }

        // GET: api/Couriers
        /// <summary>
        /// GET Method for getting all Couriers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourierSummaryViewModel>>> GetCouriers()
        {
            try
            {
                return await _context.Couriers.Include(e=>e.Location)
                    .Select(s=> new CourierSummaryViewModel
                    {
                        Id=s.Id,
                        FromName=s.FromName,
                        FromAddress=s.FromAddress,
                        FromContactNumber=s.FromContactNumber,
                        ToName=s.ToName,
                        ToAddress=s.ToAddress,
                        ToContactNumber=s.ToContactNumber,
                        Location=s.Location.Name,
                        Insured=s.Insured
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Couriers/5
        /// <summary>
        /// GET Courier by id method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Courier>> GetCourier(int id)
        {
            var courier = await _context.Couriers.FindAsync(id);

            if (courier == null)
            {
                return NotFound();
            }

            return courier;
        }

        // PUT: api/Couriers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// PUT Method for updating an Courier
        /// </summary>
        /// <param name="id"></param>
        /// <param name="courier"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourier(int id, Courier courier)
        {
            if (id != courier.Id)
            {
                return BadRequest();
            }

            _context.Entry(courier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourierExists(id))
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

        // POST: api/Couriers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// POST Method for updating an Courier
        /// </summary>
        /// <param name="courier"></param>
        /// <returns></returns>
        [HttpPost]
        //[IgnoreAntiforgeryTokenAttribute]
        public async Task<ActionResult<Courier>> PostCourier(Courier courier)
        {
            _context.Couriers.Add(courier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourier", new { id = courier.Id }, courier);
        }

        // DELETE: api/Couriers/5
        /// <summary>
        /// DELETE Method for deleting an Courier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourier(int id)
        {
            var courier = await _context.Couriers.FindAsync(id);
            if (courier == null)
            {
                return NotFound();
            }

            _context.Couriers.Remove(courier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourierExists(int id)
        {
            return _context.Couriers.Any(e => e.Id == id);
        }
    }
}
