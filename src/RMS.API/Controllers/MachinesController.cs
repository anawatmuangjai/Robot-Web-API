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
    public class MachinesController : ControllerBase
    {
        private readonly IAsyncRepository<Machine> _machineRepository;

        public MachinesController(IAsyncRepository<Machine> machineRepository)
        {
            _machineRepository = machineRepository;
        }

        // GET: api/Machine
        [HttpGet]
        public async Task<IActionResult> GetMachines()
        {
            var machines = await _machineRepository.GetAllAsync();
            return Ok(machines);
        }

        // GET: api/Machine/5
        [HttpGet("{id}", Name = nameof(GetMachineById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetMachineById(int id)
        {
            var machine = await _machineRepository.GetByIdAsync(id);

            if (machine == null)
            {
                return NotFound();
            }

            return Ok(machine);
        }

        /// <summary>
        /// Creates a new machine
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /machine
        ///     {
        ///        "name": "RDX",
        ///        "number": "001",
        ///        "ipAddress: 11.11.11.11",
        ///     }
        ///
        /// </remarks>
        /// <param name="machine"></param>
        /// <returns>A newly created machine</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        // POST: api/Machine
        [HttpPost(Name = nameof(CreateMachine))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateMachine([FromBody]Machine machine)
        {
            if (machine == null)
            {
                return BadRequest();
            }

            await _machineRepository.AddAsync(machine);

            return CreatedAtAction(nameof(GetMachineById), new { id = machine.Id }, machine);
        }

        // PUT: api/Machine/5
        [HttpPut("{id}", Name = nameof(UpdateMachine))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateMachine(int id, [FromBody]Machine machine)
        {
            if (id != machine.Id)
            {
                return BadRequest();
            }

            await _machineRepository.UpdateAsync(machine);

            return NoContent();
        }

        /// <summary>
        /// Deletes individual item by id.
        /// </summary>
        /// <param name="id">ID Value of the item</param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = nameof(DeleteMachineById))]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteMachineById(int id)
        {
            var machine = await _machineRepository.GetByIdAsync(id);

            if (machine == null)
            {
                return NotFound();
            }

            await _machineRepository.DeleteAsync(machine);

            return NoContent();
        }
    }
}
