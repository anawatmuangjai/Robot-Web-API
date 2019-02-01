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
    public class StatusController : ControllerBase
    {
        private readonly IAsyncRepository<Status> _statusRepository;

        public StatusController(IAsyncRepository<Status> statusRepository)
        {
            _statusRepository = statusRepository;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<IActionResult> GetStatuses()
        {
            var status = await _statusRepository.GetAllAsync();
            return Ok(status);
        }

        // GET: api/Status/5
        [HttpGet("{id}", Name = nameof(GetStatusById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetStatusById(int id)
        {
            var status = await _statusRepository.GetByIdAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return Ok(status);
        }

        /// <summary>
        /// Creates a new status
        /// </summary>
        /// <param name="status"></param>
        /// <returns>A newly created status</returns>
        /// <response code="201">Return the newly created item</response>
        /// <response code="400">If the item is null</response>
        // POST: api/Status
        [HttpPost(Name = nameof(CreateStatus))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateStatus([FromBody]Status status)
        {
            if (status == null)
            {
                return BadRequest();
            }

            await _statusRepository.AddAsync(status);

            return CreatedAtAction(nameof(GetStatusById), new { id = status.Id }, status);
        }

        // PUT: api/Status/5
        [HttpPut("{id}", Name = nameof(UpdateStatus))]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody]Status status)
        {
            var oldStatus = await _statusRepository.GetByIdAsync(id);

            if (oldStatus == null)
            {
                return NotFound();
            }

            await _statusRepository.UpdateAsync(status);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = nameof(DeleteStatusById))]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteStatusById(int id)
        {
            var status = await _statusRepository.GetByIdAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            await _statusRepository.DeleteAsync(status);

            return NoContent();
        }
    }
}
