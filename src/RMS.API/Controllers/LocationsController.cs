using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS.Core.Entities;
using RMS.Core.Interfaces;

namespace RMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly IAsyncRepository<Location> _locationRepository;

        public LocationsController(IAsyncRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        // GET: api/Location
        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _locationRepository.GetAllAsync();
            return Ok(locations);
        }

        // GET: api/Location/5
        [HttpGet("{id}", Name = nameof(GetLocationById))]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var location = await _locationRepository.GetByIdAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        /// <summary>
        /// Creates a new location
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     
        ///     POST/location
        ///     {
        ///         "locationName": "Location 1",
        ///         "locationCode": "X1"
        ///     }
        ///     
        /// </remarks>
        /// <param name="location"></param>
        /// <returns>A newly created location</returns>
        /// <response code="201">Returns the newly create item</response>
        /// <response code="400">Id the item is null</response>
        // POST: api/Location
        [HttpPost(Name = nameof(CreateLocation))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateLocation([FromBody]Location location)
        {
            if (location == null)
            {
                return BadRequest();
            }

            await _locationRepository.AddAsync(location);

            return CreatedAtAction(nameof(GetLocationById), new { id = location.Id }, location);
        }

        // PUT: api/Location/5
        [HttpPut("{id}", Name = nameof(UpdateLocation))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody]Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            await _locationRepository.UpdateAsync(location);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = nameof(DeleteLocationById))]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteLocationById(int id)
        {
            var location = await _locationRepository.GetByIdAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            await _locationRepository.DeleteAsync(location);

            return NoContent();
        }
    }
}
