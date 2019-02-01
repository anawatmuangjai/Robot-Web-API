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
    public class DestinationsController : ControllerBase
    {
        private readonly IAsyncRepository<Destination> _destinationRepository;

        public DestinationsController(IAsyncRepository<Destination> destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetDestinations()
        {
            var destinations = await _destinationRepository.GetAllAsync();
            return Ok(destinations);
        }

        [HttpGet("{id}", Name = nameof(GetDestinationById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetDestinationById(int id)
        {
            var destination = await _destinationRepository.GetByIdAsync(id);

            if (destination == null)
            {
                return NotFound();
            }

            return Ok(destination);
        }

        [HttpPost(Name = nameof(CreateDestination))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateDestination([FromBody]Destination destination)
        {
            if (destination == null)
            {
                return BadRequest();
            }

            await _destinationRepository.AddAsync(destination);

            return CreatedAtAction(nameof(GetDestinationById), new { id = destination.Id }, destination);
        }

        [HttpPut("{id}", Name = nameof(UpdateDestination))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateDestination(int id, [FromBody]Destination destination)
        {
            if (id != destination.Id)
            {
                return BadRequest();
            }

            await _destinationRepository.UpdateAsync(destination);

            return NoContent();
        }

        [HttpDelete("{id}", Name = nameof(DeleteDestinationById))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteDestinationById(int id)
        {
            var destination = await _destinationRepository.GetByIdAsync(id);

            if (destination == null)
            {
                return NotFound();
            }

            await _destinationRepository.DeleteAsync(destination);

            return NotFound();
        }

    }
}